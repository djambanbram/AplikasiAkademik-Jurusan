#region Copyright Syncfusion Inc. 2001 - 2016
// Copyright Syncfusion Inc. 2001 - 2016. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Dosen.Dialog;
using Dosen.Listener;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassModel;
using System.Configuration;
using ApiService;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace Dosen
{
    public partial class FormHonorDosen : Syncfusion.Windows.Forms.MetroForm, IHonorDosen
    {
        public static string baseAddress = ConfigurationManager.AppSettings["baseAddress"];
        private string URLGetJenjangPendidikanDosen = baseAddress + "/jurusan_api/api/dosen/get_honor_jenjang_dosen";
        private string URLSaveJenjangPendidikanDosen = baseAddress + "/jurusan_api/api/dosen/save_honor_jenjang_dosen";
        private string URLDelJenjangPendidikanDosen = baseAddress + "/jurusan_api/api/dosen/del_honor_jenjang_dosen";

        private WebApi webApi;
        private HttpResponseMessage response;

        List<HonorJenjangDosen> listHonorDosen;
        public FormHonorDosen()
        {
            InitializeComponent();
            webApi = new WebApi();
        }

        private void Loading(bool isLoading)
        {
            flowLayoutPanel2.Enabled = !isLoading;
            flowLayoutPanel1.Enabled = !isLoading;
            dgvHonorDosen.Enabled = !isLoading;
            progressBar1.Visible = isLoading;
        }

        private void btntambah_Click(object sender, EventArgs e)
        {
            using (var form = new FormTambahHonorDosen(this))
            {
                form.ShowDialog(this);
            }
        }

        public async void SaveHonorDosen(HonorJenjangDosen honor)
        {
            string jsonData = JsonConvert.SerializeObject(honor);
            response = await webApi.Post(URLSaveJenjangPendidikanDosen, jsonData, true);
            if (!response.IsSuccessStatusCode)
            {
                MessageBox.Show(webApi.ReturnMessage(response));
                return;
            }

            await LoadHonor();
        }

        private async Task LoadHonor()
        {
            Loading(true);
            txtCari.Text = string.Empty;
            response = await webApi.Post(URLGetJenjangPendidikanDosen, string.Empty, true);
            if (!response.IsSuccessStatusCode)
            {
                MessageBox.Show("Data honor gagal ditampilkan");
                return;
            }
            dgvHonorDosen.Rows.Clear();
            listHonorDosen = JsonConvert.DeserializeObject<List<HonorJenjangDosen>>(response.Content.ReadAsStringAsync().Result);
            foreach (HonorJenjangDosen h in listHonorDosen)
            {
                dgvHonorDosen.Rows.Add(h.IdHonorDosen, h.JenjangPendidikan, h.Golongan, h.HonorFix, h.HonorVariable, h.Pajak, DateTime.Parse(h.TanggalBerlaku).ToString("d-MM-yyyy"));
            }
            Loading(false);
        }

        private async void FormHonorDosen_Load(object sender, EventArgs e)
        {
            await LoadHonor();
        }

        private void txtCari_TextChanged(object sender, EventArgs e)
        {
            List<HonorJenjangDosen> tempList = listHonorDosen.Where(h => h.JenjangPendidikan.ToLower().Contains(txtCari.Text.ToLower()) || h.Golongan.ToLower().Contains(txtCari.Text.ToLower())).ToList();
            dgvHonorDosen.Rows.Clear();
            foreach (HonorJenjangDosen h in tempList)
            {
                dgvHonorDosen.Rows.Add(h.IdHonorDosen, h.JenjangPendidikan, h.Golongan, h.HonorFix, h.HonorVariable, h.Pajak, DateTime.Parse(h.TanggalBerlaku).ToString("d-MM-yyyy"));
            }
        }

        private void btnTutup_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void btnHapus_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Data HR akan di hapus. Apakah akan di proses?", "Perhatian", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.No)
            {
                return;
            }
            Loading(true);
            foreach (DataGridViewRow dgRow in dgvHonorDosen.Rows)
            {
                if(Convert.ToBoolean(dgRow.Cells["Hapus"].Value))
                {
                    int IdHonorDosen = int.Parse(dgRow.Cells["IdHonorDosen"].Value.ToString());
                    HonorJenjangDosen h = new HonorJenjangDosen();
                    h.IdHonorDosen = IdHonorDosen;
                    string jsonData = JsonConvert.SerializeObject(h);
                    response = await webApi.Post(URLDelJenjangPendidikanDosen, jsonData, true);
                    if (!response.IsSuccessStatusCode)
                    {
                        MessageBox.Show(webApi.ReturnMessage(response));
                        return;
                    }
                }
            }
            Loading(false);
            //DataGridViewRow row = dgvHonorDosen.SelectedRows[0];
            //int IdHonorDosen = int.Parse(row.Cells["IdHonorDosen"].Value.ToString());
            //HonorJenjangDosen h = new HonorJenjangDosen();
            //h.IdHonorDosen = IdHonorDosen;
            //string jsonData = JsonConvert.SerializeObject(h);
            //response = await webApi.Post(URLDelJenjangPendidikanDosen, jsonData, true);
            //if (!response.IsSuccessStatusCode)
            //{
            //    MessageBox.Show(webApi.ReturnMessage(response));
            //    return;
            //}

            await LoadHonor();
        }
    }
}
