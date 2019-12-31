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
    public partial class FormDetailNilaiMhsPemutihan : Syncfusion.Windows.Forms.MetroForm, IMataKuliah
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
        private string idProdi;
        private string jenjang;

        public FormDetailNilaiMhsPemutihan(string jenjang, string npmLama, string nama, int angkatan, string nodaf, string idProdi)
        {
            InitializeComponent();
            webApi = new WebApi();
            NpmLama = npmLama;
            txtNama.Text = nama;
            txtNpmLama.Text = npmLama;
            txtNodaf.Text = nodaf;
            this.angkatan = angkatan;
            Nodaf = nodaf;
            this.idProdi = idProdi;
            this.jenjang = jenjang;
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

            if (jenjang == "S2")
            {
                txtNpmLama.ReadOnly = false;
                labelForS2.Text = "(enter)";
            }
            else
            {
                txtNpmLama.ReadOnly = true;
                labelForS2.Text = string.Empty;
            }

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
                    "Ganti MK Baru",
                    string.IsNullOrWhiteSpace(item.KodePemutihan) ? item.KodeLama : item.KodePemutihan,
                    string.IsNullOrWhiteSpace(item.MataKuliahPemutihan) ? item.MataKuliahLama : item.MataKuliahPemutihan,
                    item.SksPemutihan == 0 ? item.SksLama : item.SksPemutihan,
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
            if (e.ColumnIndex == 4)
            {
                var kodeLama = dgvNilai.Rows[e.RowIndex].Cells["KodeLama"].Value.ToString();
                var mkLama = dgvNilai.Rows[e.RowIndex].Cells["MataKuliahLama"].Value.ToString();
                int sksLama = int.Parse(dgvNilai.Rows[e.RowIndex].Cells["SksLama"].Value.ToString());
                var nilaiLama = dgvNilai.Rows[e.RowIndex].Cells["Nilai"].Value.ToString();
                using (var form = new FormMataKuliah(idProdi, kodeLama, mkLama, sksLama, nilaiLama, e.RowIndex, this))
                {
                    form.ShowDialog();
                }
            }

            dgvNilai.CommitEdit(DataGridViewDataErrorContexts.Commit);
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
                if (Convert.ToBoolean(row.Cells["Approve"].Value))
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

        private void approveKecualiNIlaiDDanEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvNilai.Rows)
            {
                if (row.Cells["Nilai"].Value.ToString() == "D" || row.Cells["Nilai"].Value.ToString() == "E")
                {
                    row.Cells["Approve"].Value = false;
                }
                else
                {
                    row.Cells["Approve"].Value = true;
                }
            }
        }

        private void approveKecualiNilaiEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvNilai.Rows)
            {
                if (row.Cells["Nilai"].Value.ToString() == "E")
                {
                    row.Cells["Approve"].Value = false;
                }
                else
                {
                    row.Cells["Approve"].Value = true;
                }
            }
        }

        public void TambahMataKuliah(string kode, string mataKuliah, int sks, string nilai, int rowIndex)
        {
            Loading(true);

            HistoryKonversiNilai hk = new HistoryKonversiNilai()
            {
                Approve = true,
                KodeD3 = dgvNilai.Rows[rowIndex].Cells["KodeLama"].Value.ToString(),
                MataKuliahD3 = dgvNilai.Rows[rowIndex].Cells["MataKuliahLama"].Value.ToString(),
                SksD3 = int.Parse(dgvNilai.Rows[rowIndex].Cells["SksLama"].Value.ToString()),
                NilaiD3 = dgvNilai.Rows[rowIndex].Cells["Nilai"].Value.ToString(),
                KodeS1 = kode,
                Nilai = nilai,
                Nodaf = Nodaf,
                Npm = NpmLama,
                //Id = dgvNilai.Rows[rowIndex].Cells["Id"].Value != null ? new Guid(dgvNilai.Rows[rowIndex].Cells["Id"].Value.ToString()) : Guid.Empty
            };
            //var jsonData = JsonConvert.SerializeObject(hk);
            //response = await webApi.Post(URLSaveHistoryNilaiCalonMhsAlihJalurSingle, jsonData, true);
            //if (!response.IsSuccessStatusCode)
            //{
            //    MessageBox.Show(webApi.ReturnMessage(response));
            //    Loading(false);
            //    return;
            //}

            //var idKonversi = JsonConvert.DeserializeObject<HistoryKonversiNilai>(response.Content.ReadAsStringAsync().Result).Id;

            dgvNilai.Rows[rowIndex].Cells["KodeBaru"].Value = kode;
            dgvNilai.Rows[rowIndex].Cells["MataKuliahBaru"].Value = mataKuliah;
            dgvNilai.Rows[rowIndex].Cells["SksBaru"].Value = sks;
            dgvNilai.Rows[rowIndex].Cells["Nilai"].Value = nilai;
            //dgvNilai.Rows[rowIndex].Cells["Hapus"].Value = "Hapus";
            //dgvNilai.Rows[rowIndex].Cells["Id"].Value = idKonversi.ToString();

            Loading(false);
        }

        private async void txtNpmLama_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (jenjang != "S2")
            {
                return;
            }

            if (e.KeyChar != (char)Keys.Enter)
            {
                return;
            }

            NpmLama = txtNpmLama.Text;
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
                    "Ganti MK Baru",
                    string.IsNullOrWhiteSpace(item.KodePemutihan) ? item.KodeLama : item.KodePemutihan,
                    string.IsNullOrWhiteSpace(item.MataKuliahPemutihan) ? item.MataKuliahLama : item.MataKuliahPemutihan,
                    item.SksPemutihan == 0 ? item.SksLama : item.SksPemutihan,
                    item.Nilai,
                    item.Approve);

                byte asciiNilai = Encoding.ASCII.GetBytes(item.Nilai)[0];
                if (asciiNilai > asciNilaiMinimal)
                {
                    dgvNilai.Rows[no - 1].DefaultCellStyle.BackColor = Color.LightSalmon;
                }
                no++;
            }
        }
    }
}
