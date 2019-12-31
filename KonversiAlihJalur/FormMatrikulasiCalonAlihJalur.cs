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
    public partial class FormMatrikulasiCalonAlihJalur : Syncfusion.Windows.Forms.MetroForm
    {
        public static string baseAddress = ConfigurationManager.AppSettings["baseAddress"];
        private string URLGetCalonMhsAlihJalur = baseAddress + "/jurusan_api/api/alih_jalur/get_calon_mhs_alih_jalur";
        private string URLGenerateNilaiCalonMhs = baseAddress + "/jurusan_api/api/alih_jalur/generate_history_konversi_nilai";

        private List<Program> listProgram;

        private WebApi webApi;
        private HttpResponseMessage response;

        private List<PendaftarAlihJalur> listPendaftarAlihJalur;

        public FormMatrikulasiCalonAlihJalur()
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

            if(cmbLulusan.SelectedIndex == 1)
            {
                listPendaftarAlihJalur = JsonConvert.DeserializeObject<List<PendaftarAlihJalur>>(response.Content.ReadAsStringAsync().Result)
                                        .Where(p => !string.IsNullOrWhiteSpace(p.NpmLama))
                                        .OrderBy(p => p.NpmLama)
                                        .ToList();
            }
            else
            {
                listPendaftarAlihJalur = JsonConvert.DeserializeObject<List<PendaftarAlihJalur>>(response.Content.ReadAsStringAsync().Result)
                                        .Where(p => string.IsNullOrWhiteSpace(p.NpmLama))
                                        .OrderBy(p => p.NpmLama)
                                        .ToList();
            }
            if (listPendaftarAlihJalur.Count <= 0)
            {
                Loading(false);
                return;
            }

            var no = 1;
            dgvPendaftar.Rows.Clear();
            foreach (var item in listPendaftarAlihJalur)
            {
                dgvPendaftar.Rows.Add(no, item.Nodaf, item.NpmLama, item.Nama, item.Approve, item.Jenjang);
                no++;
            }

            Loading(false);
        }

        private void FormMatrikulasiCalonAlihJalur_Load(object sender, EventArgs e)
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

        private async void cmbProgramAlihJalur_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbProgramAlihJalur.SelectedIndex <= 0 || cmbAngkatan.SelectedIndex <= 0)
            {
                return;
            }

            await LoadPendaftarAlihJalur(int.Parse(cmbAngkatan.Text), cmbProgramAlihJalur.SelectedValue.ToString());
        }

        private async void cmbAngkatan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbProgramAlihJalur.SelectedIndex <= 0 || cmbAngkatan.SelectedIndex <= 0 || cmbLulusan.SelectedIndex <= 0)
            {
                return;
            }

            if(cmbLulusan.SelectedIndex == 1)
            {
                btnKonversiOtomatis.Visible = true;
            }
            else
            {
                btnKonversiOtomatis.Visible = false;
            }
            await LoadPendaftarAlihJalur(int.Parse(cmbAngkatan.Text), cmbProgramAlihJalur.SelectedValue.ToString());
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
            var npm = string.Empty;
            if(dgvPendaftar.Rows[hit.RowIndex].Cells["Npm"].Value == null)
            {
                npm = string.Empty;
            }
            else
            {
                npm = dgvPendaftar.Rows[hit.RowIndex].Cells["Npm"].Value.ToString();
            }
            
            var nodaf = dgvPendaftar.Rows[hit.RowIndex].Cells["Nodaf"].Value.ToString();
            var jenjang = dgvPendaftar.Rows[hit.RowIndex].Cells["Jenjang"].Value == null ? null : dgvPendaftar.Rows[hit.RowIndex].Cells["Jenjang"].Value.ToString();
            contextMenuStrip1.Items[0].Text = string.Format("Lihat nilai {0}", nama);
            contextMenuStrip1.Items[0].Tag = new { Npm = npm, Nodaf = nodaf, Jenjang = jenjang };
            contextMenuStrip1.Items[0].Enabled = true;
        }

        private void lihatNilaiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var nama = (sender as ToolStripItem).Text.Replace("Lihat nilai ", "");
            var npm = ((sender as ToolStripItem).Tag as dynamic).Npm as string;
            var nodaf = ((sender as ToolStripItem).Tag as dynamic).Nodaf as string;
            var jenjang = ((sender as ToolStripItem).Tag as dynamic).Jenjang as string;
            if (string.IsNullOrWhiteSpace(npm))
            {
                using (var form = new FormDetailNilaiMhsAlihJalurNonAmikomAtauPemutihan(
                                    jenjang,
                                    npm, 
                                    nama, 
                                    int.Parse(cmbAngkatan.Text), 
                                    nodaf,
                                    Organisasi.listProgram.Find(p => p.KodeProgram == cmbProgramAlihJalur.SelectedValue.ToString()).Prodi.Uid.ToString().ToLower()))
                {
                    form.ShowDialog(this);
                }
            }
            else
            {
                using (var form = new FormDetailNilaiMhsAlihJalur(
                    npm, 
                    nama, 
                    int.Parse(cmbAngkatan.Text), 
                    nodaf))
                {
                    form.ShowDialog(this);
                }
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

            List<string> listNodaf = new List<string>();
            foreach (DataGridViewRow row in dgvPendaftar.Rows)
            {
                listNodaf.Add(row.Cells["Nodaf"].Value.ToString());
            }

            Loading(true);
            var data = new { ListNodaf = listNodaf, Angkatan = int.Parse(cmbAngkatan.Text) };
            var jsonData = JsonConvert.SerializeObject(data);
            response = await webApi.Post(URLGenerateNilaiCalonMhs, jsonData, true);
            if (!response.IsSuccessStatusCode)
            {
                MessageBox.Show(webApi.ReturnMessage(response));
                Loading(false);
                return;
            }

            await LoadPendaftarAlihJalur(int.Parse(cmbAngkatan.Text), cmbProgramAlihJalur.SelectedValue.ToString());
            MessageBox.Show("Nilai berhasil di konversi. Silahkan cek konversi nilai di masing-masing mahasiswa");
            Loading(false);
        }
    }
}
