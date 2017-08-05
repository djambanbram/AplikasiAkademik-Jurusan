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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MataKuliah
{
    public partial class FormMataKuliahKonsentrasi : Syncfusion.Windows.Forms.MetroForm
    {
        public static string baseAddress = ConfigurationManager.AppSettings["baseAddress"];
        private string URLGetMK = baseAddress + "/jurusan_api/api/kurikulum/get_mk";
        private string URLGetMasterKonsentrasi = baseAddress + "/jurusan_api/api/kurikulum/get_master_konsentrasi";
        private string URLGetMKKonsentrasi = baseAddress + "/jurusan_api/api/kurikulum/get_mk_konsentrasi";

        private WebApi webApi;
        private HttpResponseMessage response;

        private List<Fakultas> listFakultas;
        private List<Prodi> listProdi;

        private string UidProdiDipilih;
        private string KodeMKDipilih;

        public FormMataKuliahKonsentrasi()
        {
            InitializeComponent();
            webApi = new WebApi();
        }

        private void Loading(bool isLoading)
        {
            splitContainerAdv1.Enabled = !isLoading;
            flowLayoutPanel1.Enabled = !isLoading;
            flowLayoutPanel2.Enabled = !isLoading;
            gradientPanel2.Enabled = !isLoading;

            progressBar1.Visible = isLoading;
        }

        private void FormMataKuliahKonsentrasi_Load(object sender, EventArgs e)
        {
            listFakultas = new List<Fakultas>(Organisasi.listFakultas);
            listFakultas.Insert(0, new Fakultas() { KodeFakultas = "-", NamaFakultas = "Pilih" });
            cmbFakultas.DataSource = listFakultas;
            cmbFakultas.DisplayMember = "NamaFakultas";
            cmbFakultas.ValueMember = "KodeFakultas";
            cmbFakultas.SelectedIndex = 0;
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

        private async void cmbProdi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbProdi.SelectedIndex > 0 && cmbFakultas.SelectedIndex > 0)
            {
                UidProdiDipilih = cmbProdi.SelectedValue.ToString();
                Loading(true);
                await LoadMK();
                await LoadKonsentrasi();
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
                    dgvMataKuliah.Rows.Add(nomor, dataMK.Kode, dataMK.MataKuliah);
                    nomor++;
                }
            }
            else
            {
                MessageBox.Show(webApi.ReturnMessage(response));
            }
            dgvMataKuliah.PerformLayout();
        }

        private async Task LoadKonsentrasi()
        {
            MKByIdProdi m = new MKByIdProdi() { IdProdi = UidProdiDipilih };
            string jsonData = JsonConvert.SerializeObject(m);

            response = await webApi.Post(URLGetMasterKonsentrasi, jsonData, true);
            if (response.IsSuccessStatusCode)
            {
                List<MasterKonsentrasi> oListMK = JsonConvert.DeserializeObject<List<MasterKonsentrasi>>(response.Content.ReadAsStringAsync().Result);
                oListMK.Insert(0, new MasterKonsentrasi() { IdKonsentrasi = 0, NamaKonsentrasi = "Pilih" });
                cmbKonsentrasi.DataSource = oListMK;
                cmbKonsentrasi.DisplayMember = "NamaKonsentrasi";
                cmbKonsentrasi.ValueMember = "IdKonsentrasi";
                cmbKonsentrasi.SelectedIndex = 0;
            }
            else
            {
                MessageBox.Show(webApi.ReturnMessage(response));
            }
        }

        private async void cmbKonsentrasi_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvMKKonsentrasi.Rows.Clear();
            if (cmbKonsentrasi.SelectedIndex > 0 && cmbProdi.SelectedIndex > 0 && cmbFakultas.SelectedIndex > 0)
            {
                int idKonsentrasi = int.Parse(cmbKonsentrasi.SelectedValue.ToString());

                Loading(true);
                string jsonData = JsonConvert.SerializeObject(new { IdKonsentrasi = idKonsentrasi });
                response = await webApi.Post(URLGetMKKonsentrasi, jsonData, true);
                if (!response.IsSuccessStatusCode)
                {
                    MessageBox.Show(webApi.ReturnMessage(response));
                    return;
                }

                List<MataKuliahKonsentrasi> listMKKonsentrasi =
                    JsonConvert.DeserializeObject<List<MataKuliahKonsentrasi>>(response.Content.ReadAsStringAsync().Result);
                int no = 1;
                foreach (MataKuliahKonsentrasi mk in listMKKonsentrasi)
                {
                    dgvMKKonsentrasi.Rows.Add(no, mk.IdKonsentrasi, mk.Kode, mk.MataKuliah);
                    no++;
                }
                Loading(false);
            }
        }

        private void btnTutup_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
