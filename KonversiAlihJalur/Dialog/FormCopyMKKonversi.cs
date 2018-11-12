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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KonversiAlihJalur.Dialog
{
    public partial class FormCopyMKKonversi : Syncfusion.Windows.Forms.MetroForm
    {
        public static string baseAddress = ConfigurationManager.AppSettings["baseAddress"];
        private string URLGetKonversiMK = baseAddress + "/jurusan_api/api/alih_jalur/get_konversi_mk";
        private string URLSaveKonversiMK = baseAddress + "/jurusan_api/api/alih_jalur/save_konversi_mk";
        private string URLDeleteKonversiMK = baseAddress + "/jurusan_api/api/alih_jalur/del_konversi_mk";
        private string KodeProgram;

        private List<MataKuliahKonversi> listMataKuliahKonversi;

        private WebApi webApi;
        private HttpResponseMessage response;

        public FormCopyMKKonversi(string kodeProgram, string namaProgram)
        {
            InitializeComponent();
            webApi = new WebApi();
            txtAlihJalur.Text = namaProgram;
            KodeProgram = kodeProgram;
        }

        private void Loading(bool isLoading)
        {
            flowLayoutPanel1.Enabled = !isLoading;
            gradientPanel2.Enabled = !isLoading;
            progressBar1.Visible = isLoading;
        }

        private void btnTutup_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async Task LoadMKKonversi(int angkatan, DataGridView dgv)
        {
            Loading(true);
            var data = new { Angkatan = angkatan, KodeProgram = KodeProgram };
            var jsonData = JsonConvert.SerializeObject(data);
            response = await webApi.Post(URLGetKonversiMK, jsonData, true);
            if (!response.IsSuccessStatusCode)
            {
                MessageBox.Show(webApi.ReturnMessage(response));
                Loading(false);
                return;
            }

            listMataKuliahKonversi = JsonConvert.DeserializeObject<List<MataKuliahKonversi>>(response.Content.ReadAsStringAsync().Result);
            if (listMataKuliahKonversi.Count == 0)
            {
                dgv.Rows.Clear();
                Loading(false);
                return;
            }

            if (listMataKuliahKonversi.Count == 0)
            {
                Loading(false);
                return;
            }
            dgv.Rows.Clear();
            foreach (var item in listMataKuliahKonversi)
            {
                dgv.Rows.Add(item.KodeD3, item.MataKuliahD3, item.KodeS1, item.MataKuliahS1);
            }

            Loading(false);
        }

        private void FormCopyMKKonversi_Load(object sender, EventArgs e)
        {
            for (int i = DateTime.Now.Year; i > DateTime.Now.Year - 10; i--)
            {
                cmbAngkatanSumber.Items.Add(i.ToString());
                cmbAngkatanTarget.Items.Add(i.ToString());
            }
            cmbAngkatanSumber.Items.Insert(0, "Pilih");
            cmbAngkatanSumber.SelectedIndex = 0;
            cmbAngkatanTarget.Items.Insert(0, "Pilih");
            cmbAngkatanTarget.SelectedIndex = 0;
        }

        private async void cmbAngkatanSumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbAngkatanSumber.SelectedIndex <= 0)
            {
                return;
            }

            await LoadMKKonversi(int.Parse(cmbAngkatanSumber.Text), dgvAngkatanSumber);
        }

        private async void cmbAngkatanTarget_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbAngkatanTarget.SelectedIndex <= 0)
            {
                return;
            }

            await LoadMKKonversi(int.Parse(cmbAngkatanTarget.Text), dgvAngkatanTarget);
        }

        private async void btnCopy_Click(object sender, EventArgs e)
        {
            if (cmbAngkatanSumber.Text == cmbAngkatanTarget.Text)
            {
                MessageBox.Show("Angkatan harus berbeda");
                return;
            }

            Loading(true);
            var angkatanSumber = cmbAngkatanSumber.Text;
            var angkatanTarget = cmbAngkatanTarget.Text;
            if (dgvAngkatanTarget.Rows.Count > 0)
            {
                var message = string.Format("Angkatan {0} sudah memiliki konversi mata kuliah. Proses copy akan menghapus data sebelumnya.\nLanjutkan proses?", angkatanTarget);
                DialogResult dr = MessageBox.Show(message, "Perhatian", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.No)
                {
                    Loading(false);
                    return;
                }

                foreach (DataGridViewRow row in dgvAngkatanTarget.Rows)
                {
                    var data = new
                    {
                        KodeD3 = row.Cells["KodeD3Target"].Value.ToString(),
                        KodeS1 = row.Cells["KodeS1Target"].Value.ToString(),
                        KodeProgram = KodeProgram,
                        Angkatan = int.Parse(cmbAngkatanTarget.Text),
                        IsCopy = true
                    };

                    var jsonData = JsonConvert.SerializeObject(data);
                    response = await webApi.Post(URLDeleteKonversiMK, jsonData, true);
                    if (!response.IsSuccessStatusCode)
                    {
                        MessageBox.Show(webApi.ReturnMessage(response));
                        Loading(false);
                        break;
                    }
                }

                foreach (DataGridViewRow row in dgvAngkatanSumber.Rows)
                {
                    var data = new
                    {
                        KodeD3 = row.Cells["KodeD3Sumber"].Value.ToString(),
                        KodeS1 = row.Cells["KodeS1Sumber"].Value.ToString(),
                        KodeProgram = KodeProgram,
                        Angkatan = int.Parse(cmbAngkatanTarget.Text),
                        IsCopy = true
                    };
                    var jsonData = JsonConvert.SerializeObject(data);
                    response = await webApi.Post(URLSaveKonversiMK, jsonData, true);
                    if (!response.IsSuccessStatusCode)
                    {
                        MessageBox.Show(webApi.ReturnMessage(response));
                        Loading(false);
                        break;
                    }
                }
            }
            else
            {
                foreach (DataGridViewRow row in dgvAngkatanSumber.Rows)
                {
                    var data = new
                    {
                        KodeD3 = row.Cells["KodeD3Sumber"].Value.ToString(),
                        KodeS1 = row.Cells["KodeS1Sumber"].Value.ToString(),
                        KodeProgram = KodeProgram,
                        Angkatan = int.Parse(cmbAngkatanTarget.Text),
                        IsCopy = true
                    };
                    var jsonData = JsonConvert.SerializeObject(data);
                    response = await webApi.Post(URLSaveKonversiMK, jsonData, true);
                    if (!response.IsSuccessStatusCode)
                    {
                        MessageBox.Show(webApi.ReturnMessage(response));
                        Loading(false);
                        break;
                    }
                }
            }
            await LoadMKKonversi(int.Parse(cmbAngkatanTarget.Text), dgvAngkatanTarget);
            MessageBox.Show("Proses copy berhasil");
            Loading(false);
        }
    }
}
