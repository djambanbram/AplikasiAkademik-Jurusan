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
using System.Windows.Forms;

namespace Dosen.Dialog
{
    public partial class FormHrRemidial : Syncfusion.Windows.Forms.MetroForm
    {
        public static string baseAddress = ConfigurationManager.AppSettings["baseAddress"];
        private string URLGetHonorSoalKoreksiRemidial = baseAddress + "/jurusan_api/api/dosen/get_honor_soal_koreksi_remidial";
        private string URLSaveHonorSoalKoreksiRemidial = baseAddress + "/jurusan_api/api/dosen/save_honor_soal_koreksi_remidial";

        private WebApi webApi;
        private HttpResponseMessage response;

        private void Loading(bool isLoading)
        {
            dgvHr.Enabled = !isLoading;
            flowLayoutPanel1.Enabled = !isLoading;
            progressBar1.Visible = isLoading;
        }

        public FormHrRemidial()
        {
            InitializeComponent();
            webApi = new WebApi();
        }

        private async void FormHrRemidial_Load(object sender, EventArgs e)
        {
            Loading(true);
            response = await webApi.Post(URLGetHonorSoalKoreksiRemidial, string.Empty, true);
            if (!response.IsSuccessStatusCode)
            {
                MessageBox.Show(webApi.ReturnMessage(response));
                Loading(false);
                return;
            }
            HonorSoalKoreksiRemidial hr = JsonConvert.DeserializeObject<HonorSoalKoreksiRemidial>(response.Content.ReadAsStringAsync().Result);

            dgvHr.Rows.Add(1, "HR Soal Ujian Remidial", hr.HonorSoal);
            dgvHr.Rows.Add(2, "HR koreksi Ujian Remidial", hr.HonorKoreksi);

            Loading(false);
        }

        private void btnTutup_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void dgvHr_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            HonorSoalKoreksiRemidial hr = new HonorSoalKoreksiRemidial();
            hr.TanggalMulai = DateTime.Now.ToString("yyyy-MM-dd");
            hr.HonorSoal = decimal.Parse(dgvHr.Rows[0].Cells["Nilai"].Value.ToString());
            hr.HonorKoreksi= decimal.Parse(dgvHr.Rows[1].Cells["Nilai"].Value.ToString());
            var jsonData = JsonConvert.SerializeObject(hr);

            Loading(true);
            response = await webApi.Post(URLSaveHonorSoalKoreksiRemidial, jsonData, true);
            if(!response.IsSuccessStatusCode)
            {
                MessageBox.Show(webApi.ReturnMessage(response));
                Loading(false);
                return;
            }
            Loading(false);
        }
    }
}
