#region Copyright Syncfusion Inc. 2001 - 2016
// Copyright Syncfusion Inc. 2001 - 2016. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using ApiService;
using ClassModel;
using MataKuliah.DataBindding;
using MataKuliah.DataBinding;
using MataKuliah.DialogForm;
using MataKuliah.Lib;
using MataKuliah.Listener;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Syncfusion.Windows.Forms.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MataKuliah
{
    public partial class FormDataMataKuliah : Syncfusion.Windows.Forms.MetroForm, IMataKuliah
    {
        public static string baseAddress = ConfigurationManager.AppSettings["baseAddress"];
        private string URLGetMK = baseAddress + "/jurusan_api/api/kurikulum/get_mk";
        private string URLGetKategoriMK = baseAddress + "/jurusan_api/api/kurikulum/get_kategori_mk";
        private string URLGetSifatMK = baseAddress + "/jurusan_api/api/kurikulum/get_sifat_mk";
        private string URLSaveMK = baseAddress + "/jurusan_api/api/kurikulum/save_mk";

        private List<Fakultas> listFakultas;
        private List<Prodi> listProdi;
        private List<KategoriMK> listKategoriMK;
        private List<SifatMK> listSifatMK;
        private List<object> listTahunBerlaku;


        private object[] arrSemesterD3 = { "Pilih", 1, 2, 3, 4, 5, 6 };
        private object[] arrSemesterS1 = { "Pilih", 1, 2, 3, 4, 5, 6, 7, 8 };
        private object[] arrSemesterS2 = { "Pilih", 1, 2, 3, 4 };

        private string UidProdiDipilih;
        private string KodeMKDipilih;

        private WebApi webApi;
        private HttpResponseMessage response;

        private FormMKPengganti formMKPengganti;

        public FormDataMataKuliah()
        {
            InitializeComponent();
            webApi = new WebApi();
            listTahunBerlaku = new List<object>();
            txtNamaMK.CausesValidation = true;
        }

        private void Loading(bool isLoading)
        {
            tableLayoutPanel1.Enabled = !isLoading;
            gradientPanel2.Enabled = !isLoading;
            tableLayoutPanel2.Enabled = !isLoading;
            progressBar1.Visible = isLoading;
        }

        private async void FormDataMataKuliah_Load(object sender, EventArgs e)
        {
            response = await webApi.Post(URLGetKategoriMK, string.Empty, true);
            if (response.IsSuccessStatusCode)
            {
                List<dynamic> oListKategoriMK = JsonConvert.DeserializeObject<List<dynamic>>(response.Content.ReadAsStringAsync().Result);
                KategoriMKBinding kategoriMKBinding = new KategoriMKBinding(oListKategoriMK);

                listKategoriMK = new List<KategoriMK>(ClassModel.MataKuliah.listKategoriMK);
                listKategoriMK.Insert(0, new KategoriMK() { Kategori = "Pilih" });
                cmbKategoriMK.DataSource = listKategoriMK;
                cmbKategoriMK.DisplayMember = "Kategori";
                cmbKategoriMK.SelectedIndex = 0;
            }
            else
            {
                MessageBox.Show(webApi.ReturnMessage(response));
            }

            response = await webApi.Post(URLGetSifatMK, string.Empty, true);
            if (response.IsSuccessStatusCode)
            {
                List<dynamic> oListSifatMK = JsonConvert.DeserializeObject<List<dynamic>>(response.Content.ReadAsStringAsync().Result);
                SifatMKBinding sifatMKBinding = new SifatMKBinding(oListSifatMK);

                listSifatMK = new List<SifatMK>(ClassModel.MataKuliah.listSifatMK);
                listSifatMK.Insert(0, new SifatMK() { KodeSifat = "-", NamaSifat = "Pilih" });
                cmbSifatMK.DataSource = listSifatMK;
                cmbSifatMK.DisplayMember = "NamaSifat";
                cmbSifatMK.ValueMember = "KodeSifat";
                cmbSifatMK.SelectedIndex = 0;
            }
            else
            {
                MessageBox.Show(webApi.ReturnMessage(response));
            }

            listFakultas = new List<Fakultas>(Organisasi.listFakultas);
            listFakultas.Insert(0, new Fakultas() { KodeFakultas = "-", NamaFakultas = "Pilih" });
            cmbFakultas.DataSource = listFakultas;
            cmbFakultas.DisplayMember = "NamaFakultas";
            cmbFakultas.ValueMember = "KodeFakultas";
            cmbFakultas.SelectedIndex = 0;
            btnSimpan.Visible = false;
            btnBatal.Visible = false;

            for (int i = DateTime.Now.Year; i >= 1998; i--)
            {
                listTahunBerlaku.Add(i);
            }
            listTahunBerlaku.Insert(0, "Pilih");
            cmbTahunBerlaku.DataSource = listTahunBerlaku;

            EnableField(false);
        }

        private void cmbFakultas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbFakultas.SelectedIndex > 0)
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
            if (string.IsNullOrWhiteSpace(UidProdiDipilih))
            {
                return;
            }

            btnSimpan.Visible = true;
            btnBatal.Visible = true;
            btnEdit.Visible = false;
            btnTambah.Visible = false;
            txtSingkatanMK.Enabled = false;

            IsEditField(false);
            ResetField();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvMataKuliah.Rows.Count <= 0 || string.IsNullOrWhiteSpace(txtNamaMK.Text))
            {
                return;
            }

            btnSimpan.Visible = true;
            btnBatal.Visible = true;
            btnEdit.Visible = false;
            btnTambah.Visible = false;

            IsEditField(true);
            KodeMKDipilih = dgvMataKuliah.SelectedRows[0].Cells["Kode"].Value.ToString();
        }

        private void btnBatal_Click(object sender, EventArgs e)
        {
            btnSimpan.Visible = false;
            btnBatal.Visible = false;
            btnEdit.Visible = true;
            btnTambah.Visible = true;

            EnableField(false);
            ResetField();
        }

        private async void btnSimpan_Click(object sender, EventArgs e)
        {
            Loading(true);
            Tuple<bool, string> t = CommonLib.IsValidControlValidation(txtNamaMK, txtNamaMKEn, txtAliasMK, txtSksTotal, txtSksPraktikum,
                                    cmbSemesterPenawaran, cmbTahunBerlaku, cmbKategoriMK, cmbSifatMK);
            if (!t.Item1)
            {
                MessageBox.Show(t.Item2);
                Loading(false);
                return;
            }

            DataMataKuliah mk = new DataMataKuliah();
            if (string.IsNullOrWhiteSpace(KodeMKDipilih))
            {
                //insert
                mk.MataKuliah = txtNamaMK.Text;
                mk.MataKuliahEn = txtNamaMKEn.Text;
                mk.SemesterDitawarkan = int.Parse(cmbSemesterPenawaran.Text);
                mk.Sks = int.Parse(txtSksTotal.Text);
                mk.SksPraktikum = int.Parse(txtSksPraktikum.Text);
                mk.KategoriMK = cmbKategoriMK.Text;
                mk.SifatMK = cmbSifatMK.SelectedValue.ToString();
                mk.SingkatanMK = txtAliasMK.Text;
                mk.TahunMulai = int.Parse(cmbTahunBerlaku.Text);
                mk.IdProdi = UidProdiDipilih;
                mk.SingkatanKelas = txtSingkatanMK.Text;
                mk.KodeKesetaraan = txtKodeMKPengganti.Text;

                string jsonData = JsonConvert.SerializeObject(mk);
                response = await webApi.Post(URLSaveMK, jsonData, true);
                MessageBox.Show(webApi.ReturnMessage(response));
            }
            else
            {
                //update
                mk.Kode = KodeMKDipilih;
                mk.IdProdi = UidProdiDipilih;
                mk.SksPraktikum = int.Parse(txtSksPraktikum.Text);
                mk.SemesterDitawarkan = int.Parse(cmbSemesterPenawaran.Text);
                mk.SingkatanKelas = txtSingkatanMK.Text;

                string jsonData = JsonConvert.SerializeObject(mk);
                response = await webApi.Post(URLSaveMK, jsonData, true);
                MessageBox.Show(webApi.ReturnMessage(response));
            }

            await LoadMK();

            Loading(false);

            btnSimpan.Visible = false;
            btnBatal.Visible = false;
            btnEdit.Visible = true;
            btnTambah.Visible = true;

            EnableField(false);
            ResetField();
        }

        private void EnableField(bool isEnable)
        {
            txtNamaMK.Enabled = isEnable;
            txtNamaMKEn.Enabled = isEnable;
            txtAliasMK.Enabled = isEnable;
            txtSingkatanMK.Enabled = isEnable;
            txtSksTotal.Enabled = isEnable;
            txtSksPraktikum.Enabled = isEnable;
            cmbSemesterPenawaran.Enabled = isEnable;
            cmbKategoriMK.Enabled = isEnable;
            cmbSifatMK.Enabled = isEnable;
            cmbTahunBerlaku.Enabled = isEnable;

            groupBox1.Enabled = isEnable;
            txtKodeMKPengganti.Text = string.Empty;
            txtNamaMKPengganti.Text = string.Empty;
        }

        private void ResetField()
        {
            cmbSifatMK.SelectedIndex = 0;
            cmbKategoriMK.SelectedIndex = 0;
            cmbSemesterPenawaran.SelectedIndex = 0;
            txtSksPraktikum.Text = "0";
            txtSksTotal.Text = "0";
            txtSingkatanMK.Text = string.Empty;
            txtAliasMK.Text = string.Empty;
            txtNamaMKEn.Text = string.Empty;
            txtNamaMK.Text = string.Empty;
            cmbTahunBerlaku.SelectedIndex = 0;
        }

        private void IsEditField(bool isEdit)
        {
            EnableField(!isEdit);
            if (isEdit)
            {
                txtSksPraktikum.Enabled = isEdit;
                cmbSemesterPenawaran.Enabled = isEdit;
                txtSingkatanMK.Enabled = isEdit;
            }
            else
            {
                txtSksPraktikum.Enabled = !isEdit;
                cmbSemesterPenawaran.Enabled = !isEdit;
            }
        }

        private async void cmbProdi_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvMataKuliah.Rows.Clear();
            if (cmbProdi.SelectedIndex > 0)
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

                Loading(true);
                await LoadMK();
                Loading(false);
            }
        }

        private async Task LoadMK()
        {

            MKByIdProdi m = new MKByIdProdi() { IdProdi = UidProdiDipilih };
            string jsonData = JsonConvert.SerializeObject(m);

            response = await webApi.Post(URLGetMK, jsonData, true);
            if (response.IsSuccessStatusCode)
            {
                List<dynamic> oListMK = JsonConvert.DeserializeObject<List<dynamic>>(response.Content.ReadAsStringAsync().Result);
                MataKuliahBinding mkBinding = new MataKuliahBinding(oListMK);

                dgvMataKuliah.Rows.Clear();
                int nomor = 1;
                foreach (DataMataKuliah dataMK in ClassModel.MataKuliah.listDataMataKuliah)
                {
                    dgvMataKuliah.Rows.Add(nomor, dataMK.Kode, dataMK.MataKuliah, dataMK.Sks, dataMK.SksPraktikum, dataMK.SemesterDitawarkan, dataMK.SifatMK, dataMK.TahunMulai);
                    nomor++;
                }
            }
            else
            {
                MessageBox.Show(webApi.ReturnMessage(response));
            }
        }

        private void dgvMataKuliah_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            btnBatal_Click(sender, e);

            string kodeMk = dgvMataKuliah.Rows[e.RowIndex].Cells["Kode"].Value.ToString();

            DataMataKuliah dataMk = ClassModel.MataKuliah.listDataMataKuliah.Find(d => d.Kode == kodeMk);
            txtNamaMK.Text = dataMk.MataKuliah;
            txtNamaMKEn.Text = dataMk.MataKuliahEn;
            txtAliasMK.Text = dataMk.SingkatanMK;
            txtSingkatanMK.Text = dataMk.SingkatanKelas;
            txtSksTotal.Text = dataMk.Sks.ToString();
            txtSksPraktikum.Text = dataMk.SksPraktikum.ToString();
            cmbSemesterPenawaran.Text = dataMk.SemesterDitawarkan.ToString();
            cmbKategoriMK.Text = dataMk.KategoriMK.Trim();
            cmbSifatMK.SelectedValue = dataMk.KodeSifatMK.Trim();
            cmbTahunBerlaku.Text = dataMk.TahunMulai.ToString();

        }

        private void numeric_only(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsNumber(e.KeyChar) && e.KeyChar != (char)Keys.Back;
        }

        private void btnCari_Click(object sender, EventArgs e)
        {
            if (formMKPengganti == null || formMKPengganti.IsDisposed)
            {
                formMKPengganti = new FormMKPengganti(this);
            }
            formMKPengganti.ShowDialog(this);
        }

        public void loadMK(string kodeMK, string mataKuliah)
        {
            txtKodeMKPengganti.Text = kodeMK;
            txtNamaMKPengganti.Text = mataKuliah;
        }

        private void textBox_Validating(object sender, CancelEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (string.IsNullOrWhiteSpace(tb.Text))
            {
                ToolTip toolTip = new ToolTip();
                toolTip.Show("Data ini wajib diisi", tb, 0, 0, 3000);
            }
        }

        private void comboBox_Validating(object sender, CancelEventArgs e)
        {
            ComboBoxAdv cb = (ComboBoxAdv)sender;
            if (cb.SelectedIndex == 0)
            {
                ToolTip toolTip = new ToolTip();
                toolTip.Show("Data ini wajib diisi", cb, 0, 0, 3000);
            }
        }
    }
}
