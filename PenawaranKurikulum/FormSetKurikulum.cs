#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using ApiService;
using ClassModel;
using Newtonsoft.Json;
using PenawaranKurikulum.Dialog;
using PenawaranKurikulum.Listener;
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

namespace PenawaranKurikulum
{
    public partial class FormSetKurikulum : Syncfusion.Windows.Forms.MetroForm, IRefreshKurikulum
    {
        public static string baseAddress = ConfigurationManager.AppSettings["baseAddress"];
        private string URLGetKurikulumByProgramProdi = baseAddress + "/jurusan_api/api/kurikulum/list_kurikulum_program_prodi";
        private string URLSaveKurikulumPerAngkatan = baseAddress + "/jurusan_api/api/kurikulum/save_kurikulum_program_prodi";
        private string URLDeleteKurikulumProdi = baseAddress + "/jurusan_api/api/kurikulum/delete_kurikulum_program_prodi";

        private WebApi webApi;
        private HttpResponseMessage response;

        private List<KurikulumProdi> listKurikulumProdi;
        private List<Fakultas> listFakultas;
        private List<Prodi> listProdi;
        private List<Program> listProgram;

        public FormSetKurikulum()
        {
            InitializeComponent();
            webApi = new WebApi();
        }

        private void Loading(bool isLoading)
        {
            flowLayoutPanel1.Enabled = !isLoading;
            flowLayoutPanel2.Enabled = !isLoading;
            dgvKurikulum.Enabled = !isLoading;
            panel1.Enabled = !isLoading;
            progressBar1.Visible = isLoading;
        }

        private void FormSetKurikulum_Load(object sender, EventArgs e)
        {

            listFakultas = new List<Fakultas>(Organisasi.listFakultas);
            listFakultas.Insert(0, new Fakultas() { KodeFakultas = "-", NamaFakultas = "Pilih" });
            cmbFakultas.DataSource = listFakultas;
            cmbFakultas.DisplayMember = "NamaFakultas";
            cmbFakultas.ValueMember = "KodeFakultas";
            cmbFakultas.SelectedIndex = 0;

            cmbAngkatan.Items.Add("Semua Angkatan");
            for (int yearNow = DateTime.Now.Year; yearNow >= 2001; yearNow--)
            {
                cmbAngkatan.Items.Add(yearNow.ToString());
            }
            cmbAngkatan.SelectedIndex = 0;
        }

        private void cmbFakultas_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvKurikulum.Rows.Clear();

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

        private void cmbProdi_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvKurikulum.Rows.Clear();
            if (cmbProdi.SelectedIndex <= 0)
            {
                return;
            }

            if (cmbFakultas.SelectedIndex > 0 && cmbProdi.SelectedIndex > 0)
            {
                string idProdi = cmbProdi.SelectedValue.ToString();
                listProgram = Organisasi.listProgram.Where(program => program.Prodi.Uid == idProdi).ToList();
                listProgram.Insert(0, new Program() { KodeProgram = "-", NamaProgram = "Pilih" });
                cmbProgram.DataSource = listProgram;
                cmbProgram.DisplayMember = "NamaProgram";
                cmbProgram.ValueMember = "KodeProgram";
                cmbProgram.SelectedIndex = 0;
            }
        }

        private void cmbAngkatan_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvKurikulum.Rows.Clear();

            if (cmbAngkatan.SelectedIndex <= 0)
            {
                LoadKurikulum(0);
            }
            else
            {
                LoadKurikulum(int.Parse(cmbAngkatan.Text));
            }
        }

        private void LoadKurikulum(int angkatan)
        {
            if (listKurikulumProdi == null)
            {
                return;
            }

            lblMkWajib.Text = ": 0";
            lblMkPilihan.Text = ": 0";
            lblMkKonsentrasi.Text = ": 0";
            lblSksWajib.Text = ": 0";
            lblSksPilihan.Text = ": 0";
            lblSksKonsentrasi.Text = ": 0";
            lblTotalMk.Text = "0";
            lblTotalSks.Text = "0";

            var no = 1;
            var jumlahMkWajib = 0;
            var jumlahMkPilihan = 0;
            var jumlahMkKonsentrasi = 0;
            var jumlahSksWajib = 0;
            var jumlahSksPilihan = 0;
            var jumlahSksKonsentrasi = 0;
            dgvKurikulum.Rows.Clear();
            foreach (var item in listKurikulumProdi)
            {
                if (angkatan == 0)
                {
                    if (item.SifatMK == "Wajib")
                    {
                        jumlahMkWajib++;
                        jumlahSksWajib = jumlahSksWajib + item.Sks;
                    }
                    else if (item.SifatMK == "Pilihan")
                    {
                        jumlahMkPilihan++;
                        jumlahSksPilihan = jumlahSksPilihan + item.Sks;
                    }
                    else
                    {
                        jumlahMkKonsentrasi++;
                        jumlahSksKonsentrasi = jumlahSksKonsentrasi + item.Sks;
                    }
                    dgvKurikulum.Rows.Add(item.IdKurikulum, no, item.Angkatan, item.Kode, item.MataKuliah, item.NilaiMinimal, item.Sks, item.SifatMK);
                    no++;
                }
                else
                {
                    if (item.Angkatan == angkatan)
                    {
                        if (item.SifatMK == "Wajib")
                        {
                            jumlahMkWajib++;
                            jumlahSksWajib = jumlahSksWajib + item.Sks;
                        }
                        else if (item.SifatMK == "Pilihan")
                        {
                            jumlahMkPilihan++;
                            jumlahSksPilihan = jumlahSksPilihan + item.Sks;
                        }
                        else
                        {
                            jumlahMkKonsentrasi++;
                            jumlahSksKonsentrasi = jumlahSksKonsentrasi + item.Sks;
                        }
                        dgvKurikulum.Rows.Add(item.IdKurikulum, no, item.Angkatan, item.Kode, item.MataKuliah, item.NilaiMinimal, item.Sks, item.SifatMK);
                        no++;
                    }
                }
            }

            lblMkWajib.Text = string.Format(": {0}", jumlahMkWajib.ToString());
            lblMkPilihan.Text = string.Format(": {0}", jumlahMkPilihan.ToString());
            lblMkKonsentrasi.Text = string.Format(": {0}", jumlahMkKonsentrasi.ToString());
            lblSksWajib.Text = string.Format(": {0}", jumlahSksWajib.ToString());
            lblSksPilihan.Text = string.Format(": {0}", jumlahSksPilihan.ToString());
            lblSksKonsentrasi.Text = string.Format(": {0}", jumlahSksKonsentrasi.ToString());
            lblTotalMk.Text = string.Format(": {0}", listKurikulumProdi.Count(k => k.Angkatan == angkatan).ToString());
            lblTotalSks.Text = string.Format(": {0}", (jumlahSksKonsentrasi + jumlahSksPilihan + jumlahSksWajib).ToString());
        }

        private void btnTutup_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void cmbProgram_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvKurikulum.Rows.Clear();
            if (cmbProgram.SelectedIndex <= 0)
            {
                return;
            }

            Loading(true);
            var data = new { KodeProgram = cmbProgram.SelectedValue.ToString() };
            var jsonData = JsonConvert.SerializeObject(data);
            response = await webApi.Post(URLGetKurikulumByProgramProdi, jsonData, true);
            if (!response.IsSuccessStatusCode)
            {
                MessageBox.Show(webApi.ReturnMessage(response));
                Loading(false);
                return;
            }

            listKurikulumProdi = JsonConvert.DeserializeObject<List<KurikulumProdi>>(response.Content.ReadAsStringAsync().Result)
                                    .OrderBy(k => k.Angkatan)
                                    .ThenBy(k => k.Kode)
                                    .ToList();

            if (cmbAngkatan.SelectedIndex == 0)
            {
                LoadKurikulum(0);
            }
            else
            {
                LoadKurikulum(int.Parse(cmbAngkatan.Text));
            }

            Loading(false);
        }

        private void btnSetKurikulum_Click(object sender, EventArgs e)
        {
            if (cmbProgram.SelectedIndex <= 0)
            {
                MessageBox.Show("Pilih program terlebih dahulu");
                return;
            }

            var kodeProgram = cmbProgram.SelectedValue.ToString();
            var idProdi = cmbProdi.SelectedValue.ToString();
            var namaProgram = cmbProgram.Text;
            var namaProdi = cmbProdi.Text;

            using (var form = new DialogSetKurikulumPerAngkatan(kodeProgram, idProdi, namaProgram, namaProdi, this))
            {
                form.ShowDialog();
            }
        }

        public async void RefreshKurikulum(string kodeProgram)
        {
            cmbAngkatan.SelectedIndex = 0;
            dgvKurikulum.Rows.Clear();
            var data = new { KodeProgram = kodeProgram };
            var jsonData = JsonConvert.SerializeObject(data);

            Loading(true);
            response = await webApi.Post(URLGetKurikulumByProgramProdi, jsonData, true);
            if (!response.IsSuccessStatusCode)
            {
                MessageBox.Show(webApi.ReturnMessage(response));
                Loading(false);
                return;
            }

            listKurikulumProdi = JsonConvert.DeserializeObject<List<KurikulumProdi>>(response.Content.ReadAsStringAsync().Result)
                                    .OrderBy(k => k.Angkatan)
                                    .ThenBy(k => k.Kode)
                                    .ToList();

            LoadKurikulum(0);
            Loading(false);
        }

        private async void dgvKurikulum_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != 5)
            {
                return;
            }

            if (e.RowIndex < 0)
            {
                return;
            }

            var arrNilai = "ABCDE";
            if (dgvKurikulum.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == null)
            {
                return;
            }
            if (arrNilai.IndexOf(dgvKurikulum.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Trim().ToUpper()) < 0)
            {
                MessageBox.Show("Nilai tidak valid. Nilai yang diterima adalah A, B, C, D, E");
                dgvKurikulum.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "E";
                return;
            }

            dgvKurikulum.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = string.IsNullOrWhiteSpace(dgvKurikulum.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Trim().ToUpper()) ? null : dgvKurikulum.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Trim().ToUpper();
            KurikulumProdi kp = new KurikulumProdi()
            {
                Angkatan = int.Parse(cmbAngkatan.Text),
                KodeProgram = cmbProgram.SelectedValue.ToString(),
                Kode = dgvKurikulum.Rows[e.RowIndex].Cells["Kode"].Value.ToString(),
                NilaiMinimal = dgvKurikulum.Rows[e.RowIndex].Cells["NilaiMinimal"].Value == null ? null : dgvKurikulum.Rows[e.RowIndex].Cells["NilaiMinimal"].Value.ToString()
            };

            Loading(true);
            var jsonData = JsonConvert.SerializeObject(kp);
            response = await webApi.Post(URLSaveKurikulumPerAngkatan, jsonData, true);
            if (!response.IsSuccessStatusCode)
            {
                MessageBox.Show("Proses penyimpanan gagal");
                Loading(false);
                return;
            }
            Loading(false);
        }

        private void dgvKurikulum_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right)
            {
                return;
            }

            var hittest = dgvKurikulum.HitTest(e.X, e.Y);
            if (hittest.RowIndex < 0 || hittest.ColumnIndex < 0)
            {
                return;
            }

            dgvKurikulum.Rows[hittest.RowIndex].Cells[hittest.ColumnIndex].Selected = true;

            var kode = dgvKurikulum.Rows[hittest.RowIndex].Cells["Kode"].Value.ToString();
            var mk = dgvKurikulum.Rows[hittest.RowIndex].Cells["MataKuliah"].Value.ToString();
            var idKurikulum = dgvKurikulum.Rows[hittest.RowIndex].Cells["IdKurikulum"].Value.ToString();

            contextMenuStrip1.Items[0].Text = string.Format("Hapus {0}({1}) untuk angkatan {2}", mk, kode, cmbAngkatan.Text);
            contextMenuStrip1.Items[0].Tag = new { IdKurikulum = idKurikulum, Index = hittest.RowIndex };

        }

        private async void hapusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Data kurikulum yang dipilih akan di hapus. Lanjurkan proses?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.No)
            {
                return;
            }

            var data = contextMenuStrip1.Items[0].Tag as dynamic;
            var dataKurikulum = data.IdKurikulum as string;
            var dataIndex = (int)data.Index;
            var jsonData = JsonConvert.SerializeObject(new { IdKurikulum = dataKurikulum });

            Loading(true);

            response = await webApi.Post(URLDeleteKurikulumProdi, jsonData, true);
            if (!response.IsSuccessStatusCode)
            {
                MessageBox.Show(webApi.ReturnMessage(response));
                Loading(false);
                return;
            }

            dgvKurikulum.Rows.RemoveAt(dataIndex);

            Loading(false);
        }
    }
}
