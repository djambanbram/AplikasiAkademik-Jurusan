#region Copyright Syncfusion Inc. 2001 - 2016
// Copyright Syncfusion Inc. 2001 - 2016. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using ApiService;
using ClassModel;
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

namespace KonversiAlihJalur
{
    public partial class FormSetKonversiMK : Syncfusion.Windows.Forms.MetroForm
    {
        public static string baseAddress = ConfigurationManager.AppSettings["baseAddress"];
        private string URLGetMKD3 = baseAddress + "/jurusan_api/api/alih_jalur/get_mk_d3";
        private string URLGetMKS1 = baseAddress + "/jurusan_api/api/alih_jalur/get_mk_s1";
        private string URLGetKonversiMK = baseAddress + "/jurusan_api/api/alih_jalur/get_konversi_mk";

        private List<Program> listProgram;
        private List<DataMataKuliah> listMataKuliah;

        private WebApi webApi;
        private HttpResponseMessage response;
        public FormSetKonversiMK()
        {
            InitializeComponent();
            webApi = new WebApi();
        }

        private void Loading(bool isLoading)
        {
            flowLayoutPanel1.Enabled = !isLoading;
            splitContainer1.Enabled = !isLoading;
            gradientPanel2.Enabled = !isLoading;
            progressBar1.Visible = isLoading;
        }

        private async Task LoadMkD3()
        {
            Loading(true);
            var data = new { Angkatan = int.Parse(cmbAngkatan.Text), KodeProgram = cmbProgramAlihJalur.SelectedValue.ToString() };
            var jsonData = JsonConvert.SerializeObject(data);

            response = await webApi.Post(URLGetMKD3, jsonData, true);
            if (!response.IsSuccessStatusCode)
            {
                MessageBox.Show(webApi.ReturnMessage(response));
                return;
            }

            listMataKuliah = JsonConvert.DeserializeObject<List<DataMataKuliah>>(response.Content.ReadAsStringAsync().Result)
                .Where(mk => !mk.MataKuliah.ToLower().Contains("tak dikenal") 
                && !mk.MataKuliah.ToLower().Contains("tidak dikenal")
                && !mk.MataKuliah.ToLower().Contains("tes dts")
                && !mk.Kode.ToLower().Contains("df")
                && !mk.Kode.ToLower().Contains("xx")
                && mk.SemesterDitawarkan != 0).ToList();
            if (listMataKuliah.Count == 0)
            {
                return;
            }

            dgvMKD3.Rows.Clear();
            foreach (var mk in listMataKuliah)
            {
                dgvMKD3.Rows.Add(mk.Kode, mk.MataKuliah, mk.Sks);
            }
            Loading(false);
        }

        private void FormSetKonversiMK_Load(object sender, EventArgs e)
        {
            listProgram = Organisasi.listProgram.Where(program => program.KodeProgram == "21" || program.KodeProgram == "22").ToList();
            listProgram.Insert(0, new Program() { KodeProgram = "-", NamaProgram = "Pilih" });
            cmbProgramAlihJalur.DataSource = listProgram;
            cmbProgramAlihJalur.DisplayMember = "NamaProgram";
            cmbProgramAlihJalur.ValueMember = "KodeProgram";
            cmbProgramAlihJalur.SelectedIndex = 0;

            for (int i = DateTime.Now.Year; i > DateTime.Now.Year - 10; i--)
            {
                cmbAngkatan.Items.Add(i.ToString());
            }
            cmbAngkatan.Items.Insert(0, "Pilih");
            cmbAngkatan.SelectedIndex = 0;

        }

        private void btnTutup_Click(object sender, EventArgs e)
        {
            Close();
        }


        private async void cmbAngkatan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbAngkatan.SelectedIndex <= 0 || cmbProgramAlihJalur.SelectedIndex <= 0)
            {
                return;
            }
            await LoadMkD3();
        }

        private void txtCari_TextChanged(object sender, EventArgs e)
        {
            if (dgvMKD3.Rows.Count <= 0 || listMataKuliah.Count <= 0)
            {
                return;
            }

            var tempList = listMataKuliah.Where(mk => mk.Kode.ToLower().Contains(txtCari.Text) || mk.MataKuliah.ToLower().Contains(txtCari.Text)).ToList();

            dgvMKD3.Rows.Clear();
            foreach (var mk in tempList)
            {
                dgvMKD3.Rows.Add(mk.Kode, mk.MataKuliah, mk.Sks);
            }
        }

        private async void cmbProgramAlihJalur_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbAngkatan.SelectedIndex <= 0 || cmbProgramAlihJalur.SelectedIndex <= 0)
            {
                return;
            }
            await LoadMkD3();
        }
    }
}
