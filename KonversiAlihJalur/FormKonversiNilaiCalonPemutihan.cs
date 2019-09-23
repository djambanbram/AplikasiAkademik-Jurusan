#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
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
using System.Windows.Forms;

namespace KonversiAlihJalur
{
    public partial class FormKonversiNilaiCalonPemutihan : Syncfusion.Windows.Forms.MetroForm
    {
        public static string baseAddress = ConfigurationManager.AppSettings["baseAddress"];
        private string URLGetCalonMhsPemutihan = baseAddress + "/jurusan_api/api/pemutihan/get_calon_mhs_pemutihan";

        private WebApi webApi;
        private HttpResponseMessage response;

        private List<Fakultas> listFakultas;
        private List<Prodi> listProdi;
        private List<Program> listProgram;

        private List<PendaftarAlihJalur> listPendaftarPemutihan;
        public FormKonversiNilaiCalonPemutihan()
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

        private void FormKonversiNilaiCalonPemutihan_Load(object sender, EventArgs e)
        {
            listFakultas = new List<Fakultas>(Organisasi.listFakultas);
            listFakultas.Insert(0, new Fakultas() { KodeFakultas = "-", NamaFakultas = "Pilih" });
            cmbFakultas.DataSource = listFakultas;
            cmbFakultas.DisplayMember = "NamaFakultas";
            cmbFakultas.ValueMember = "KodeFakultas";
            cmbFakultas.SelectedIndex = 0;

            for (int i = DateTime.Now.Year; i > DateTime.Now.Year - 10; i--)
            {
                cmbAngkatan.Items.Add(i.ToString());
            }
            cmbAngkatan.Items.Insert(0, "Pilih");
            cmbAngkatan.SelectedIndex = 0;
        }

        private void cmbFakultas_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvPendaftar.Rows.Clear();

            if (cmbFakultas.SelectedIndex > 0)
            {
                string kodeFakultas = cmbFakultas.SelectedValue.ToString();
                listProdi = Organisasi.listProdi.Where(pr => pr.Fakultas.KodeFakultas == kodeFakultas).
                            OrderBy(pr => pr.Jenjang)
                            .ThenBy(pr => pr.NamaProdi)
                            .ToList();
                listProdi.Insert(0, new Prodi() { IdProdi = "-", NamaProdi = "Pilih" });
                cmbProdi.DataSource = listProdi;
                cmbProdi.DisplayMember = "NamaProdi";
                cmbProdi.ValueMember = "Uid";
                cmbProdi.SelectedIndex = 0;
            }
        }

        private void cmbProdi_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvPendaftar.Rows.Clear();
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

        private void cmbProgram_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbProgram.SelectedIndex <= 0 || cmbAngkatan.SelectedIndex <= 0)
            {
                return;
            }
            LoadPendaftarPemutihan(int.Parse(cmbAngkatan.Text), cmbProgram.SelectedValue.ToString());
        }

        private void cmbAngkatan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbProgram.SelectedIndex <= 0 || cmbAngkatan.SelectedIndex <= 0)
            {
                return;
            }
            LoadPendaftarPemutihan(int.Parse(cmbAngkatan.Text), cmbProgram.SelectedValue.ToString());
        }

        private async void LoadPendaftarPemutihan(int angkatan, string kodeProgram)
        {
            Loading(true);
            var data = new { kodeProgram = kodeProgram, Angkatan = angkatan };
            var jsonData = JsonConvert.SerializeObject(data);
            response = await webApi.Post(URLGetCalonMhsPemutihan, jsonData, true);
            if (!response.IsSuccessStatusCode)
            {
                MessageBox.Show(webApi.ReturnMessage(response));
                Loading(false);
                return;
            }

            listPendaftarPemutihan = JsonConvert.DeserializeObject<List<PendaftarAlihJalur>>(response.Content.ReadAsStringAsync().Result).OrderBy(p => p.NpmLama).ToList();
            if (listPendaftarPemutihan.Count <= 0)
            {
                Loading(false);
                return;
            }

            var no = 1;
            dgvPendaftar.Rows.Clear();
            foreach (var item in listPendaftarPemutihan)
            {
                dgvPendaftar.Rows.Add(no, item.Nodaf, item.NpmLama, item.Nama, item.Approve);
                no++;
            }

            Loading(false);
        }

        private void btnTutup_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dgvPendaftar_MouseDown(object sender, MouseEventArgs e)
        {
            var hit = dgvPendaftar.HitTest(e.X, e.Y);
            if (hit.RowIndex <= -1 || hit.ColumnIndex <= -1)
            {
                //contextMenuStrip1.Items[0].Text = "Lihat";
                contextMenuStrip1.Items[0].Enabled = false;
                contextMenuStrip1.Items[1].Enabled = false;
                return;
            }
            dgvPendaftar.ClearSelection();
            dgvPendaftar.Rows[hit.RowIndex].Selected = true;
            var nama = dgvPendaftar.Rows[hit.RowIndex].Cells["Nama"].Value.ToString();
            var npm = dgvPendaftar.Rows[hit.RowIndex].Cells["Npm"].Value.ToString();
            var nodaf = dgvPendaftar.Rows[hit.RowIndex].Cells["Nodaf"].Value.ToString();
            //contextMenuStrip1.Items[0].Text = string.Format("Lihat nilai {0}", nama);
            contextMenuStrip1.Items[0].Tag = new { Npm = npm, Nodaf = nodaf };
            contextMenuStrip1.Items[0].Enabled = true;
            contextMenuStrip1.Items[1].Tag = new { Npm = npm, Nodaf = nodaf };
            contextMenuStrip1.Items[1].Enabled = true;
        }

        private void lihatNilaiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var nama = (sender as ToolStripItem).Text.Replace("Lihat nilai ", "");
            var npm = ((sender as ToolStripItem).Tag as dynamic).Npm as string;
            var nodaf = ((sender as ToolStripItem).Tag as dynamic).Nodaf as string;
            //using (var form = new FormDetailNilaiMhsPemutihan(npm, nama, int.Parse(cmbAngkatan.Text), nodaf, cmbProdi.SelectedValue.ToString()))
            //{
            //    form.ShowDialog(this);
            //}
            using (var form = new FormDetailNilaiMhsAlihJalurNonAmikomAtauPemutihan(
                                npm,
                                nama,
                                int.Parse(cmbAngkatan.Text),
                                nodaf,
                                Organisasi.listProgram.Find(p => p.KodeProgram == cmbProgram.SelectedValue.ToString()).Prodi.Uid.ToString().ToLower()))
            {
                form.ShowDialog(this);
            }
        }

        private void konversiNilaiOtomatisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var nama = (sender as ToolStripItem).Text.Replace("Lihat nilai ", "");
            var npm = ((sender as ToolStripItem).Tag as dynamic).Npm as string;
            var nodaf = ((sender as ToolStripItem).Tag as dynamic).Nodaf as string;
            using (var form = new FormDetailNilaiMhsPemutihan(npm, nama, int.Parse(cmbAngkatan.Text), nodaf, cmbProdi.SelectedValue.ToString()))
            {
                form.ShowDialog(this);
            }
        }
    }
}
