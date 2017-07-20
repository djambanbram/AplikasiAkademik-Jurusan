#region Copyright Syncfusion Inc. 2001 - 2016
// Copyright Syncfusion Inc. 2001 - 2016. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using ApiService;
using ClassModel;
using MataKuliah.DataBinding;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Windows.Forms;

namespace MataKuliah
{
    public partial class FormDataMataKuliah : Syncfusion.Windows.Forms.MetroForm
    {
        public static string baseAddress = ConfigurationManager.AppSettings["baseAddress"];

        private List<Fakultas> listFakultas;
        private List<Prodi> listProdi;
        private List<KategoriMK> listKategoriMK;
        private List<SifatMK> listSifatMK;
        private List<int> listTahunBerlaku;

        private string URLGetMK = baseAddress + "/jurusan_api/api/kurikulum/get_mk";

        private int[] arrSemesterD3 = { 1, 2, 3, 4, 5, 6 };
        private int[] arrSemesterS1 = { 1, 2, 3, 4, 5, 6, 7, 8 };
        private int[] arrSemesterS2 = { 1, 2, 3, 4 };

        private string UidProdiDipilih;
        private HttpResponseMessage response;

        private WebApi webApi;

        public FormDataMataKuliah()
        {
            InitializeComponent();
            webApi = new WebApi();
            listTahunBerlaku = new List<int>();
        }

        private void Loading(bool isLoading)
        {
            tableLayoutPanel1.Enabled = !isLoading;
            gradientPanel2.Enabled = !isLoading;
            tableLayoutPanel2.Enabled = !isLoading;
            progressBar1.Visible = isLoading;
        }

        private void FormDataMataKuliah_Load(object sender, EventArgs e)
        {
            listFakultas = new List<Fakultas>(Organisasi.listFakultas);
            listFakultas.Insert(0, new Fakultas() { KodeFakultas = "-", NamaFakultas = "Pilih" });
            cmbFakultas.DataSource = listFakultas;
            cmbFakultas.DisplayMember = "NamaFakultas";
            cmbFakultas.ValueMember = "KodeFakultas";
            cmbFakultas.SelectedIndex = 0;
            btnSimpan.Visible = false;
            btnBatal.Visible = false;

            listKategoriMK = new List<KategoriMK>(ClassModel.MataKuliah.listKategoriMK);
            listKategoriMK.Insert(0, new KategoriMK() { Kategori = "Pilih" });
            cmbKategoriMK.DataSource = listKategoriMK;
            cmbKategoriMK.DisplayMember = "Kategori";
            cmbKategoriMK.SelectedIndex = 0;

            listSifatMK = new List<SifatMK>(ClassModel.MataKuliah.listSifatMK);
            listSifatMK.Insert(0, new SifatMK() { KodeSifat = "-", NamaSifat = "Pilih" });
            cmbSifatMK.DataSource = listSifatMK;
            cmbSifatMK.DisplayMember = "NamaSifat";
            cmbSifatMK.ValueMember = "KodeSifat";
            cmbSifatMK.SelectedIndex = 0;

            for (int i = DateTime.Now.Year; i >= 1998; i--)
            {
                listTahunBerlaku.Add(i);
            }
            cmbTahunBerlaku.DataSource = listTahunBerlaku;

            ControlIsEdit(false);
        }

        private void cmbFakultas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbFakultas.SelectedIndex != 0)
            {
                string kodeFakultas = cmbFakultas.SelectedValue.ToString();
                listProdi = Organisasi.listProdi.Where(pr => pr.Fakultas.KodeFakultas == kodeFakultas).ToList();
                listProdi.Insert(0, new Prodi() { IdProdi = "-", NamaProdi = "Pilih" });
                cmbProdi.DataSource = listProdi;
                cmbProdi.DisplayMember = "NamaProdi";
                cmbProdi.ValueMember = "Uid";
                cmbProdi.SelectedIndex = 0;
            }
        }

        private void btnTutup_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnTambah_Click(object sender, EventArgs e)
        {
            btnSimpan.Visible = true;
            btnBatal.Visible = true;
            btnEdit.Visible = false;
            btnTambah.Visible = false;

            ControlIsEdit(false);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            btnSimpan.Visible = true;
            btnBatal.Visible = true;
            btnEdit.Visible = false;
            btnTambah.Visible = false;

            ControlIsEdit(true);
        }

        private void btnBatal_Click(object sender, EventArgs e)
        {
            btnSimpan.Visible = false;
            btnBatal.Visible = false;
            btnEdit.Visible = true;
            btnTambah.Visible = true;

            ControlIsEdit(false);
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            btnSimpan.Visible = false;
            btnBatal.Visible = false;
            btnEdit.Visible = true;
            btnTambah.Visible = true;

            ControlIsEdit(false);
        }

        private void ControlIsEdit(bool isEdit)
        {
            txtNamaMK.Enabled = isEdit;
            txtNamaMKEn.Enabled = isEdit;
            txtAliasMK.Enabled = isEdit;
            txtSingkatanMK.Enabled = isEdit;
            txtSksTotal.Enabled = isEdit;
            txtSksPraktikum.Enabled = isEdit;
            cmbSemesterPenawaran.Enabled = isEdit;
            cmbKategoriMK.Enabled = isEdit;
            cmbSifatMK.Enabled = isEdit;
            cmbTahunBerlaku.Enabled = isEdit;
            groupBox1.Enabled = isEdit;
        }

        private async void cmbProdi_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvMataKuliah.Rows.Clear();
            if (cmbProdi.SelectedIndex != 0)
            {
                string jenjang = Organisasi.listProdi.Find(p => p.Uid == cmbProdi.SelectedValue.ToString()).Jenjang;

                if (jenjang == "D3")
                {
                    cmbSemesterPenawaran.DataSource = arrSemesterD3;
                }
                else if (jenjang == "S1")
                {
                    cmbSemesterPenawaran.DataSource = arrSemesterS1;
                }
                else if (jenjang == "S2")
                {
                    cmbSemesterPenawaran.DataSource = arrSemesterS2;
                }
                cmbSemesterPenawaran.SelectedIndex = 0;
                UidProdiDipilih = cmbProdi.SelectedValue.ToString();

                MKByIdProdi m = new MKByIdProdi() { IdProdi = UidProdiDipilih };
                string jsonData = JsonConvert.SerializeObject(m);

                Loading(true);
                response = await webApi.Post(URLGetMK, jsonData);
                if (response.IsSuccessStatusCode)
                {
                    List<dynamic> oListMK = JsonConvert.DeserializeObject<List<dynamic>>(response.Content.ReadAsStringAsync().Result);
                    MataKuliahBinding mkBinding = new MataKuliahBinding(oListMK);

                    foreach (DataMataKuliah dataMK in ClassModel.MataKuliah.listDataMataKuliah)
                    {
                        dgvMataKuliah.Rows.Add(dataMK.Kode, dataMK.MataKuliah, dataMK.Sks, dataMK.SksPraktikum, dataMK.SemesterDitawarkan, dataMK.SifatMK, dataMK.TahunMulai);
                    }
                }
                Loading(false);
            }
        }

        private void dgvMataKuliah_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string kodeMk = dgvMataKuliah.Rows[e.RowIndex].Cells["Kode"].Value.ToString();

            DataMataKuliah dataMk = ClassModel.MataKuliah.listDataMataKuliah.Find(d => d.Kode == kodeMk);
            txtNamaMK.Text = dataMk.MataKuliah;
            txtNamaMKEn.Text = dataMk.MataKuliahEn;
            txtAliasMK.Text = dataMk.Alias;
            txtSingkatanMK.Text = dataMk.SingkatanKelas;
            txtSksTotal.Text = dataMk.Sks.ToString();
            txtSksPraktikum.Text = dataMk.SksPraktikum.ToString();
            cmbSemesterPenawaran.Text = dataMk.SemesterDitawarkan.ToString();
            cmbKategoriMK.Text = dataMk.KategoriMk.Trim();
            cmbSifatMK.SelectedValue = dataMk.KodeSifatMK.Trim();
            cmbTahunBerlaku.Text = dataMk.TahunMulai.ToString();
        }
    }
}
