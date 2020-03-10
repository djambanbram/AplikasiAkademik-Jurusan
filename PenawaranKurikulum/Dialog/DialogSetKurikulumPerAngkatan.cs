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

namespace PenawaranKurikulum.Dialog
{
    public partial class DialogSetKurikulumPerAngkatan : Syncfusion.Windows.Forms.MetroForm
    {
        public static string baseAddress = ConfigurationManager.AppSettings["baseAddress"];
        private string URLGetMKSudahDitawarkan = baseAddress + "/jurusan_api/api/kurikulum/get_mk_sudah_ditawarkan_by_angkatan";
        private string URLGetMK = baseAddress + "/jurusan_api/api/kurikulum/get_mk";
        private string URLSaveKurikulumPerAngkatan = baseAddress + "/jurusan_api/api/kurikulum/save_kurikulum_matakuliah";

        private WebApi webApi;
        private HttpResponseMessage response;

        private string kodeProgram;
        private string idProdi;
        private string namaProgram;
        private string namaProdi;
        private List<DataMataKuliah> listMataKuliah;
        private IRefreshKurikulum iRefreshKurikulum;

        private bool isPilihSemua;

        public DialogSetKurikulumPerAngkatan(string kodeProgram, string idProdi, string namaProgram, string namaProdi, IRefreshKurikulum iRefreshKurikulum)
        {
            InitializeComponent();
            webApi = new WebApi();

            this.kodeProgram = kodeProgram;
            this.idProdi = idProdi;
            this.namaProgram = namaProgram;
            this.namaProdi = namaProdi;
            this.iRefreshKurikulum = iRefreshKurikulum;

            txtNamaProgramProdi.Text = string.Format("{0}/{1}", namaProdi, namaProgram);

            cmbAngkatan.Items.Add("Pilih");
            for (int i = DateTime.Now.Year; i > 2001; i--)
            {
                cmbAngkatan.Items.Add(i.ToString());
            }
            cmbAngkatan.SelectedIndex = 0;
            cmbJenisMk.SelectedIndex = 0;
        }

        private void Loading(bool isLoading)
        {
            flowLayoutPanel1.Enabled = !isLoading;
            flowLayoutPanel2.Enabled = !isLoading;
            panel1.Enabled = !isLoading;
            dgvMataKuliah.Enabled = !isLoading;
            progressBar1.Visible = isLoading;
        }

        private void btnTutup_Click(object sender, EventArgs e)
        {
            iRefreshKurikulum.RefreshKurikulum(kodeProgram);
            Close();
        }

        private void DialogSetKurikulumPerAngkatan_Load(object sender, EventArgs e)
        {

        }

        private void cmbAngkatan_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvMataKuliah.Rows.Clear();
            if (cmbAngkatan.SelectedIndex <= 0)
            {
                return;
            }

            LoadMataKuliah(cmbJenisMk.Text);
        }

        private void cmbJenisMk_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvMataKuliah.Rows.Clear();
            if (cmbJenisMk.SelectedIndex <= 0)
            {
                return;
            }

            LoadMataKuliah(cmbJenisMk.Text);
        }

        private async void LoadMataKuliah(string jenis)
        {
            if (cmbJenisMk.SelectedIndex <= 0 || cmbAngkatan.SelectedIndex <= 0)
            {
                return;
            }

            Loading(true);
            if (jenis == "Semua Mata Kuliah")
            {
                var data = new { IdProdi = idProdi };
                string jsonData = JsonConvert.SerializeObject(data);
                response = await webApi.Post(URLGetMK, jsonData, true);
            }
            else
            {
                var data = new { KodeJurusan = kodeProgram, Angkatan = int.Parse(cmbAngkatan.Text) };
                string jsonData = JsonConvert.SerializeObject(data);
                response = await webApi.Post(URLGetMKSudahDitawarkan, jsonData, true);
            }

            if (!response.IsSuccessStatusCode)
            {
                MessageBox.Show(webApi.ReturnMessage(response));
                Loading(false);
                return;
            }

            listMataKuliah = JsonConvert.DeserializeObject<List<DataMataKuliah>>(response.Content.ReadAsStringAsync().Result)
                            .GroupBy(mk => mk.Kode)
                            .Select(mk => mk.First())
                            .ToList();

            var no = 1;
            foreach (var item in listMataKuliah)
            {
                dgvMataKuliah.Rows.Add(no, false, item.Kode, item.MataKuliah, item.Sks, item.SifatMK, "Pilih");
                no++;
            }
            Loading(false);
        }

        private void btnPilihSemua_Click(object sender, EventArgs e)
        {
            isPilihSemua = !isPilihSemua;
            foreach (DataGridViewRow dgRow in dgvMataKuliah.Rows)
            {
                dgRow.Cells["Pilih"].Value = isPilihSemua;
            }
        }

        private async void btnSimpan_Click(object sender, EventArgs e)
        {
            if (dgvMataKuliah.Rows.Count <= 0)
            {
                MessageBox.Show("Tidak ada data yang dipilih");
                return;
            }

            var isAdaDipilih = false;
            foreach (DataGridViewRow dgRow in dgvMataKuliah.Rows)
            {
                if (Convert.ToBoolean(dgRow.Cells["Pilih"].Value))
                {
                    isAdaDipilih = true;
                }
            }

            if (!isAdaDipilih)
            {
                MessageBox.Show("Tidak ada data yang dipilih");
                return;
            }

            var message = string.Format("Mata kuliah yang dipilih akan di set menjadi kurikulum angkatan {0}.\n\nLanjutkan proses?", cmbAngkatan.Text);
            DialogResult dr = MessageBox.Show(message, "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.No)
            {
                return;
            }

            Loading(true);
            foreach (DataGridViewRow dgRow in dgvMataKuliah.Rows)
            {
                if (Convert.ToBoolean(dgRow.Cells["Pilih"].Value))
                {
                    KurikulumProdi kp = new KurikulumProdi()
                    {
                        Angkatan = int.Parse(cmbAngkatan.Text),
                        KodeProgram = kodeProgram,
                        Kode = dgRow.Cells["Kode"].Value.ToString(),
                        NilaiMinimal = dgRow.Cells["NilaiMinimal"].Value.ToString() == "Pilih" ? null : dgRow.Cells["NilaiMinimal"].Value.ToString()
                    };

                    var jsonData = JsonConvert.SerializeObject(kp);
                    response = await webApi.Post(URLSaveKurikulumPerAngkatan, jsonData, true);
                    if (!response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Proses penyimpanan gagal");
                        Loading(false);
                        return;
                    }
                }
            }

            MessageBox.Show("Data kurikulum berhasil disimpan");
            Loading(false);
        }

        private void DialogSetKurikulumPerAngkatan_FormClosing(object sender, FormClosingEventArgs e)
        {
            iRefreshKurikulum.RefreshKurikulum(kodeProgram);
        }
    }
}
