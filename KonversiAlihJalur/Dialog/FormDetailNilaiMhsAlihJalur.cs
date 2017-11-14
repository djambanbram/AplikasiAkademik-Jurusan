#region Copyright Syncfusion Inc. 2001 - 2016
// Copyright Syncfusion Inc. 2001 - 2016. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using ApiService;
using KonversiAlihJalur.Models;
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

namespace KonversiAlihJalur.Dialog
{
    public partial class FormDetailNilaiMhsAlihJalur : Syncfusion.Windows.Forms.MetroForm
    {
        public static string baseAddress = ConfigurationManager.AppSettings["baseAddress"];
        private string URLGetDetailCalonMhsAlihJalur = baseAddress + "/jurusan_api/api/alih_jalur/get_detail_calon_mhs_alih_jalur";
        private string URLSaveHistoryNilaiCalonMhsAlihJalur = baseAddress + "/jurusan_api/api/alih_jalur/save_nilai_calon_mhs_alih_jalur";

        private string NpmLama;
        private string Nama;

        private WebApi webApi;
        private HttpResponseMessage response;

        private List<DetailNilaiPendaftarAlihJalur> listDetailNilai;

        public FormDetailNilaiMhsAlihJalur(string npmLama, string nama)
        {
            InitializeComponent();
            webApi = new WebApi();
            NpmLama = npmLama;
            txtNama.Text = nama;
            txtNpmLama.Text = npmLama;
        }

        private void Loading(bool isLoading)
        {
            flowLayoutPanel1.Enabled = !isLoading;
            gradientPanel2.Enabled = !isLoading;
            dgvNilai.Enabled = !isLoading;
            progressBar1.Enabled = isLoading;
        }

        private void btnTutup_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void FormDetailNilaiMhsAlihJalur_Load(object sender, EventArgs e)
        {
            Loading(true);

            var data = new { Npm = NpmLama };
            var jsonData = JsonConvert.SerializeObject(data);
            response = await webApi.Post(URLGetDetailCalonMhsAlihJalur, jsonData, true);
            if (!response.IsSuccessStatusCode)
            {
                MessageBox.Show(webApi.ReturnMessage(response));
                Loading(false);
                return;
            }

            listDetailNilai = JsonConvert.DeserializeObject<List<DetailNilaiPendaftarAlihJalur>>(response.Content.ReadAsStringAsync().Result);
            if (listDetailNilai.Count <= 0)
            {
                Loading(false);
                return;
            }

            dgvNilai.Rows.Clear();
            var no = 1;
            var asciNilaiMinimal = Encoding.ASCII.GetBytes("C")[0];
            foreach (var item in listDetailNilai)
            {
                dgvNilai.Rows.Add(no, item.KodeD3, item.MataKuliahD3, item.SksD3, item.KodeS1, item.MataKuliahS1, item.SksS1, item.Nilai, item.Approve);

                byte asciiNilai = Encoding.ASCII.GetBytes(item.Nilai)[0];
                if (asciiNilai > asciNilaiMinimal)
                {
                    dgvNilai.Rows[no - 1].DefaultCellStyle.BackColor = Color.LightSalmon;
                }
                no++;
            }

            Loading(false);
        }

        private void approveSemuaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvNilai.Rows)
            {
                row.Cells["Approve"].Value = true;
            }
        }

        private void approveKecualiNilaiDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvNilai.Rows)
            {
                if (row.Cells["Nilai"].Value.ToString() == "D")
                {
                    row.Cells["Approve"].Value = false;
                }
                else
                {
                    row.Cells["Approve"].Value = true;
                }
            }
        }

        private void hapusApproveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvNilai.Rows)
            {
                row.Cells["Approve"].Value = false;
            }
        }

        private async void btnSimpan_Click(object sender, EventArgs e)
        {
            if(dgvNilai.Rows.Count <= 0)
            {
                return;
            }

            Loading(true);

            List<HistoryKonversiNilai> listHistoryKonversi = new List<HistoryKonversiNilai>();
            foreach(DataGridViewRow row in dgvNilai.Rows)
            {
                HistoryKonversiNilai h = new HistoryKonversiNilai();
                h.Npm = NpmLama;
                h.KodeD3 = row.Cells["KodeD3"].Value.ToString();
                h.MataKuliahD3 = row.Cells["MataKuliahD3"].Value.ToString();
                h.SksD3 = int.Parse(row.Cells["SksD3"].Value.ToString());
                h.KodeS1 = row.Cells["KodeS1"].Value.ToString();
                h.Nilai = row.Cells["Nilai"].Value.ToString();
                h.Approve = Convert.ToBoolean(row.Cells["Approve"].Value.ToString());
                listHistoryKonversi.Add(h);
            }

            var jsondata = JsonConvert.SerializeObject(listHistoryKonversi);
            response = await webApi.Post(URLSaveHistoryNilaiCalonMhsAlihJalur, jsondata, true);
            if(!response.IsSuccessStatusCode)
            {
                MessageBox.Show(webApi.ReturnMessage(response));
                Loading(false);
                return;
            }
            MessageBox.Show("Konversi nilai berhasil disimpan");

            Loading(false);
        }
    }
}
