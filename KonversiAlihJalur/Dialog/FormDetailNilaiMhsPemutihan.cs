#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
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
using System.Net.Http;
using System.Text;
using System.Windows.Forms;

namespace KonversiAlihJalur.Dialog
{
    public partial class FormDetailNilaiMhsPemutihan : Syncfusion.Windows.Forms.MetroForm
    {
        public static string baseAddress = ConfigurationManager.AppSettings["baseAddress"];
        private string URLGetDetailCalonMhsPemutihan = baseAddress + "/jurusan_api/api/pemutihan/get_detail_calon_mhs_pemutihan";
        private string URLSaveHistoryNilaiCalonMhsPemutihan = baseAddress + "/jurusan_api/api/pemutihan/save_nilai_calon_mhs_pemutihan";

        private string NpmLama;
        private string Nodaf;

        private WebApi webApi;
        private HttpResponseMessage response;

        private List<DetailNilaiPendaftarPemutihan> listDetailNilai;
        private int angkatan;

        public FormDetailNilaiMhsPemutihan(string npmLama, string nama, int angkatan, string nodaf)
        {
            InitializeComponent();
            webApi = new WebApi();
            NpmLama = npmLama;
            txtNama.Text = nama;
            txtNpmLama.Text = npmLama;
            this.angkatan = angkatan;
            Nodaf = nodaf;
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

        private async void FormDetailNilaiMhsPemutihan_Load(object sender, EventArgs e)
        {
            Loading(true);

            var data = new { Npm = NpmLama, Angkatan = angkatan, Nodaf };
            var jsonData = JsonConvert.SerializeObject(data);
            response = await webApi.Post(URLGetDetailCalonMhsPemutihan, jsonData, true);
            if (!response.IsSuccessStatusCode)
            {
                MessageBox.Show(webApi.ReturnMessage(response));
                Loading(false);
                return;
            }

            listDetailNilai = JsonConvert.DeserializeObject<List<DetailNilaiPendaftarPemutihan>>(response.Content.ReadAsStringAsync().Result);
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
                dgvNilai.Rows.Add(
                    no,
                    item.KodeLama,
                    item.MataKuliahLama,
                    item.SksLama,
                    string.IsNullOrWhiteSpace(item.KodeBaru) ? item.KodeLama : item.KodeBaru,
                    string.IsNullOrWhiteSpace(item.MataKuliahBaru) ? item.MataKuliahLama : item.MataKuliahBaru,
                    item.SksBaru == 0 ? item.SksLama : item.SksBaru,
                    item.Nilai,
                    item.Approve);

                byte asciiNilai = Encoding.ASCII.GetBytes(item.Nilai)[0];
                if (asciiNilai > asciNilaiMinimal)
                {
                    dgvNilai.Rows[no - 1].DefaultCellStyle.BackColor = Color.LightSalmon;
                }
                no++;
            }

            Loading(false);
        }

        private void dgvNilai_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private async void btnSimpan_Click(object sender, EventArgs e)
        {
            if (dgvNilai.Rows.Count <= 0)
            {
                return;
            }

            Loading(true);

            List<HistoryKonversiNilai> listHistoryKonversi = new List<HistoryKonversiNilai>();
            foreach (DataGridViewRow row in dgvNilai.Rows)
            {
                HistoryKonversiNilai h = new HistoryKonversiNilai();
                h.Nodaf = Nodaf;
                h.Npm = NpmLama;
                h.KodeD3 = row.Cells["KodeLama"].Value.ToString();
                h.MataKuliahD3 = row.Cells["MataKuliahLama"].Value.ToString();
                h.SksD3 = int.Parse(row.Cells["SksLama"].Value.ToString());
                h.KodeS1 = row.Cells["KodeBaru"].Value.ToString();
                h.Nilai = row.Cells["Nilai"].Value.ToString();
                h.Approve = Convert.ToBoolean(row.Cells["Approve"].Value.ToString());
                listHistoryKonversi.Add(h);
            }

            var jsondata = JsonConvert.SerializeObject(listHistoryKonversi);
            response = await webApi.Post(URLSaveHistoryNilaiCalonMhsPemutihan, jsondata, true);
            if (!response.IsSuccessStatusCode)
            {
                MessageBox.Show(webApi.ReturnMessage(response));
                Loading(false);
                return;
            }
            MessageBox.Show("Konversi nilai berhasil disimpan");

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
    }
}
