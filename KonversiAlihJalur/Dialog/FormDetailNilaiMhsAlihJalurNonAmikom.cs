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
    public partial class FormDetailNilaiMhsAlihJalurNonAmikom : Syncfusion.Windows.Forms.MetroForm, IMataKuliah
    {
        public static string baseAddress = ConfigurationManager.AppSettings["baseAddress"];
        private string URLGetDetailCalonMhsAlihJalurNonAmikom = baseAddress + "/jurusan_api/api/alih_jalur/get_detail_calon_mhs_alih_jalur_non_amikom";
        private string URLSaveHistoryNilaiCalonMhsAlihJalur = baseAddress + "/jurusan_api/api/alih_jalur/save_nilai_calon_mhs_alih_jalur";
        private string URLSaveHistoryNilaiCalonMhsAlihJalurSingle = baseAddress + "/jurusan_api/api/alih_jalur/save_nilai_calon_mhs_alih_jalur_single";
        private string URLDeleteHistoryNilaiCalonMhsAlihJalurSingle = baseAddress + "/jurusan_api/api/alih_jalur/delete_nilai_calon_mhs_alih_jalur_single";

        private string NpmLama;
        private string Nodaf;

        private WebApi webApi;
        private HttpResponseMessage response;

        private List<DetailNilaiPendaftarAlihJalur> listDetailNilai;
        private int angkatan;
        private string idProdi;

        public FormDetailNilaiMhsAlihJalurNonAmikom(string npmLama, string nama, int angkatan, string nodaf, string idProdi)
        {
            InitializeComponent();
            webApi = new WebApi();
            NpmLama = npmLama;
            txtNama.Text = nama;
            txtNpmLama.Text = string.IsNullOrWhiteSpace(npmLama) ? "Non AMIKOM" : npmLama;
            this.angkatan = angkatan;
            Nodaf = nodaf;
            dgvNilai.Rows[0].Cells["No"].Value = 1;
            this.idProdi = idProdi;
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

            var data = new { Npm = NpmLama, Angkatan = angkatan, Nodaf };
            var jsonData = JsonConvert.SerializeObject(data);
            response = await webApi.Post(URLGetDetailCalonMhsAlihJalurNonAmikom, jsonData, true);
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
                dgvNilai.Rows.Add(
                    no,
                    item.KodeD3,
                    item.MataKuliahD3,
                    item.SksD3,
                    item.KodeS1,
                    item.MataKuliahS1,
                    item.SksS1,
                    item.Nilai,
                    "Hapus",
                    item.Id);

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
            if (!response.IsSuccessStatusCode)
            {
                MessageBox.Show(webApi.ReturnMessage(response));
                Loading(false);
                return;
            }
            MessageBox.Show("Konversi nilai berhasil disimpan");

            Loading(false);
        }

        private void dgvNilai_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            for (int i = 0; i < dgvNilai.Rows.Count; i++)
            {
                dgvNilai.Rows[i].Cells["No"].Value = i + 1;
            }
        }

        private async void dgvNilai_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != 4 && e.ColumnIndex != 5 && e.ColumnIndex != 8)
            {
                return;
            }

            var kodeLama = dgvNilai.Rows[e.RowIndex].Cells["KodeD3"].Value;
            var mataKuliahLama = dgvNilai.Rows[e.RowIndex].Cells["MataKuliahD3"].Value;
            var sksLama = dgvNilai.Rows[e.RowIndex].Cells["sksD3"].Value;
            var rowIndex = e.RowIndex;

            if (e.ColumnIndex != 8)
            {
                if (kodeLama == null || mataKuliahLama == null || sksLama == null)
                {
                    MessageBox.Show("Kode, mata kuliah dan sks diisi dulu");
                    return;
                }

                if (!sksLama.ToString().All(char.IsNumber))
                {
                    MessageBox.Show("Sks harus berupa angka");
                    return;
                }

                if (dgvNilai.Rows[e.RowIndex].Cells["KodeS1"].Value != null || dgvNilai.Rows[e.RowIndex].Cells["MataKuliahS1"].Value != null)
                {
                    return;
                }

                using (var form = new FormMataKuliah(
                                    idProdi,
                                    kodeLama.ToString(),
                                    mataKuliahLama.ToString(),
                                    int.Parse(sksLama.ToString()),
                                    rowIndex,
                                    this))
                {
                    form.ShowDialog();
                }
            }
            else
            {
                var message = string.Format("Akan menghapus konversi nilai mata kuliah:\nKode\t: {0}\nMK \t: {1}\nSks\t: {2}", kodeLama, mataKuliahLama, sksLama);
                DialogResult dr = MessageBox.Show(message, "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.No)
                {
                    return;
                }

                Loading(true);
                var idKonversi = dgvNilai.Rows[e.RowIndex].Cells["Id"].Value.ToString();
                var jsonData = JsonConvert.SerializeObject(new { Id = idKonversi });
                response = await webApi.Post(URLDeleteHistoryNilaiCalonMhsAlihJalurSingle, jsonData, true);
                if (!response.IsSuccessStatusCode)
                {
                    MessageBox.Show(webApi.ReturnMessage(response));
                    Loading(false);
                    return;
                }
                dgvNilai.Rows.RemoveAt(e.RowIndex);
                Loading(false);
            }
        }

        public async void TambahMataKuliah(string kode, string mataKuliah, int sks, string nilai, int rowIndex)
        {
            Loading(true);

            HistoryKonversiNilai hk = new HistoryKonversiNilai()
            {
                Approve = true,
                KodeD3 = dgvNilai.Rows[rowIndex].Cells["KodeD3"].Value.ToString(),
                MataKuliahD3 = dgvNilai.Rows[rowIndex].Cells["MataKuliahD3"].Value.ToString(),
                SksD3 = int.Parse(dgvNilai.Rows[rowIndex].Cells["SksD3"].Value.ToString()),
                KodeS1 = kode,
                Nilai = nilai,
                Nodaf = Nodaf,
                Npm = NpmLama,
                Id = dgvNilai.Rows[rowIndex].Cells["Id"].Value != null ? new Guid(dgvNilai.Rows[rowIndex].Cells["Id"].Value.ToString()) : Guid.Empty
            };
            var jsonData = JsonConvert.SerializeObject(hk);
            response = await webApi.Post(URLSaveHistoryNilaiCalonMhsAlihJalurSingle, jsonData, true);
            if (!response.IsSuccessStatusCode)
            {
                MessageBox.Show(webApi.ReturnMessage(response));
                Loading(false);
                return;
            }

            var idKonversi = JsonConvert.DeserializeObject<HistoryKonversiNilai>(response.Content.ReadAsStringAsync().Result).Id;

            dgvNilai.Rows[rowIndex].Cells["KodeS1"].Value = kode;
            dgvNilai.Rows[rowIndex].Cells["MataKuliahS1"].Value = mataKuliah;
            dgvNilai.Rows[rowIndex].Cells["SksS1"].Value = sks;
            dgvNilai.Rows[rowIndex].Cells["Nilai"].Value = nilai;
            dgvNilai.Rows[rowIndex].Cells["Hapus"].Value = "Hapus";
            dgvNilai.Rows[rowIndex].Cells["Id"].Value = idKonversi.ToString();

            Loading(false);
        }

        private void dgvNilai_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            for (int i = 0; i < dgvNilai.Rows.Count; i++)
            {
                dgvNilai.Rows[i].Cells["No"].Value = i + 1;
            }
        }
    }
}
