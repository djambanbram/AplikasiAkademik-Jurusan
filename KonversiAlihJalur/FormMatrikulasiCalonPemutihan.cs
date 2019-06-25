#region Copyright Syncfusion Inc. 2001 - 2016
// Copyright Syncfusion Inc. 2001 - 2016. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using ApiService;
using ClassModel;
using KonversiAlihJalur.Dialog;
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

namespace KonversiAlihJalur
{
    public partial class FormMatrikulasiCalonPemutihan : Syncfusion.Windows.Forms.MetroForm
    {
        public static string baseAddress = ConfigurationManager.AppSettings["baseAddress"];
        private string URLGetCalonMhsAlihJalur = baseAddress + "/jurusan_api/api/alih_jalur/get_calon_mhs_alih_jalur";
        private string URLGenerateNilaiCalonMhs = baseAddress + "/jurusan_api/api/alih_jalur/generate_history_konversi_nilai";

        private List<Program> listProgram;

        private WebApi webApi;
        private HttpResponseMessage response;

        private List<PendaftarAlihJalur> listPendaftarAlihJalur;

        public FormMatrikulasiCalonPemutihan()
        {
            InitializeComponent();
            webApi = new WebApi();
        }

        private void Loading(bool isLoading)
        {
            flowLayoutPanel1.Enabled = !isLoading;
            gradientPanel2.Enabled = !isLoading;
            dgvPendaftar.Enabled = !isLoading;
            progressBar1.Enabled = isLoading;
        }

        private async Task LoadPendaftarAlihJalur(int angkatan, string kodeProgram)
        {
            Loading(true);
            var data = new { kodeProgram = kodeProgram, Angkatan = angkatan };
            var jsonData = JsonConvert.SerializeObject(data);
            response = await webApi.Post(URLGetCalonMhsAlihJalur, jsonData, true);
            if (!response.IsSuccessStatusCode)
            {
                MessageBox.Show(webApi.ReturnMessage(response));
                Loading(false);
                return;
            }

            listPendaftarAlihJalur = JsonConvert.DeserializeObject<List<PendaftarAlihJalur>>(response.Content.ReadAsStringAsync().Result).OrderBy(p => p.NpmLama).ToList();
            if (listPendaftarAlihJalur.Count <= 0)
            {
                Loading(false);
                return;
            }

            var no = 1;
            dgvPendaftar.Rows.Clear();
            foreach (var item in listPendaftarAlihJalur)
            {
                dgvPendaftar.Rows.Add(no, item.Nodaf, item.NpmLama, item.Nama, item.Approve);
                no++;
            }

            Loading(false);
        }

        private void FormMatrikulasiCalonAlihJalur_Load(object sender, EventArgs e)
        {
            listProgram = Organisasi.listProgram.Where(program => program.KodeProgram == "21" || program.KodeProgram == "22").ToList();
            listProgram.Insert(0, new Program() { KodeProgram = "-", NamaProgram = "Pilih" });
            cmbProgram.DataSource = listProgram;
            cmbProgram.DisplayMember = "NamaProgram";
            cmbProgram.ValueMember = "KodeProgram";
            cmbProgram.SelectedIndex = 0;

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

        private async void cmbProgramAlihJalur_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbProgram.SelectedIndex <= 0 || cmbAngkatan.SelectedIndex <= 0)
            {
                return;
            }

            await LoadPendaftarAlihJalur(int.Parse(cmbAngkatan.Text), cmbProgram.SelectedValue.ToString());
        }

        private async void cmbAngkatan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbProgram.SelectedIndex <= 0 || cmbAngkatan.SelectedIndex <= 0)
            {
                return;
            }

            await LoadPendaftarAlihJalur(int.Parse(cmbAngkatan.Text), cmbProgram.SelectedValue.ToString());
        }

        private void dgvPendaftar_MouseDown(object sender, MouseEventArgs e)
        {
            var hit = dgvPendaftar.HitTest(e.X, e.Y);
            if (hit.RowIndex <= -1 || hit.ColumnIndex <= -1)
            {
                contextMenuStrip1.Items[0].Text = "Lihat";
                contextMenuStrip1.Items[0].Enabled = false;
                return;
            }
            dgvPendaftar.ClearSelection();
            dgvPendaftar.Rows[hit.RowIndex].Selected = true;
            var nama = dgvPendaftar.Rows[hit.RowIndex].Cells["Nama"].Value.ToString();
            var npm = dgvPendaftar.Rows[hit.RowIndex].Cells["Npm"].Value.ToString();
            contextMenuStrip1.Items[0].Text = string.Format("Lihat nilai {0}", nama);
            contextMenuStrip1.Items[0].Tag = npm;
            contextMenuStrip1.Items[0].Enabled = true;
        }

        private void lihatNilaiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var nama = (sender as ToolStripItem).Text.Replace("Lihat nilai ", "");
            var npm = (sender as ToolStripItem).Tag.ToString();
            using (var form = new FormDetailNilaiMhsAlihJalur(npm, nama, int.Parse(cmbAngkatan.Text)))
            {
                form.ShowDialog(this);
            }
        }

        private async void btnKonversiOtomatis_Click(object sender, EventArgs e)
        {
            if (dgvPendaftar.Rows.Count <= 0)
            {
                return;
            }

            var message = string.Format("Konversi nilai otomatis semua mahasiswa dalam daftar tabel, dengan syarat:\n1. Nilai minimal adalah C.\n2. SKS D3 >= SKS S1.\nLanjutkan Proses?");
            DialogResult dr = MessageBox.Show(message, "Perhatian", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.No)
            {
                return;
            }

            List<string> listNpm = new List<string>();
            foreach (DataGridViewRow row in dgvPendaftar.Rows)
            {
                listNpm.Add(row.Cells["Npm"].Value.ToString());
            }

            Loading(true);
            var data = new { ListNpm = listNpm, Angkatan = int.Parse(cmbAngkatan.Text) };
            var jsonData = JsonConvert.SerializeObject(data);
            response = await webApi.Post(URLGenerateNilaiCalonMhs, jsonData, true);
            if (!response.IsSuccessStatusCode)
            {
                MessageBox.Show(webApi.ReturnMessage(response));
                Loading(false);
                return;
            }

            await LoadPendaftarAlihJalur(int.Parse(cmbAngkatan.Text), cmbProgram.SelectedValue.ToString());
            MessageBox.Show("Nilai berhasil di konversi. Silahkan cek konversi nilai di masing-masing mahasiswa");
            Loading(false);
        }
    }
}
