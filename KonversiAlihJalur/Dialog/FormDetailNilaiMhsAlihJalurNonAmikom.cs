#region Copyright Syncfusion Inc. 2001 - 2016
// Copyright Syncfusion Inc. 2001 - 2016. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using ApiService;
using ClassModel;
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
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KonversiAlihJalur.Dialog
{
    public partial class FormDetailNilaiMhsAlihJalurNonAmikomAtauPemutihan : Syncfusion.Windows.Forms.MetroForm, IMataKuliah
    {
        public static string baseAddress = ConfigurationManager.AppSettings["baseAddress"];
        private string URLGetDetailCalonMhsAlihJalurNonAmikom = baseAddress + "/jurusan_api/api/alih_jalur/get_detail_calon_mhs_alih_jalur_non_amikom";
        private string URLSaveHistoryNilaiCalonMhsAlihJalur = baseAddress + "/jurusan_api/api/alih_jalur/save_nilai_calon_mhs_alih_jalur";
        //private string URLSaveHistoryNilaiCalonMhsAlihJalurSingle = baseAddress + "/jurusan_api/api/alih_jalur/save_nilai_calon_mhs_alih_jalur_single";
        private string URLDeleteHistoryNilaiCalonMhsAlihJalurSingle = baseAddress + "/jurusan_api/api/alih_jalur/delete_nilai_calon_mhs_alih_jalur_single";
        private string URLGetMK = baseAddress + "/jurusan_api/api/kurikulum/get_mk";

        private string NpmLama;
        private string Nodaf;

        private WebApi webApi;
        private HttpResponseMessage response;

        private List<DetailNilaiPendaftarAlihJalur> listDetailNilai;
        private List<DataMataKuliah> listDataMatakuliah;
        private int angkatan;
        private string idProdi;
        private string jenjang;

        public FormDetailNilaiMhsAlihJalurNonAmikomAtauPemutihan(string  jenjang, string npmLama, string nama, int angkatan, string nodaf, string idProdi)
        {
            InitializeComponent();
            webApi = new WebApi();
            NpmLama = npmLama;
            txtNama.Text = nama;
            txtNpmLama.Text = string.IsNullOrWhiteSpace(npmLama) ? "" : npmLama;
            txtNodaf.Text = nodaf;
            this.angkatan = angkatan;
            Nodaf = nodaf;
            dgvNilai.Rows[0].Cells["No"].Value = 1;
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

        private async void FormDetailNilaiMhsAlihJalur_Load(object sender, EventArgs e)
        {
            Loading(true);

            //if(jenjang == "S2")
            //{
            //    txtNpmLama.ReadOnly = false;
            //}
            //else
            //{
            //    txtNpmLama.ReadOnly = true;
            //}

            await LoadMk();

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
                    item.NilaiD3,
                    item.KodeS1,
                    item.MataKuliahS1,
                    item.SksS1,
                    item.Nilai,
                    "Hapus",
                    item.Id);
                if (item.Nilai != null)
                {
                    byte asciiNilai = Encoding.ASCII.GetBytes(item.Nilai)[0];
                    if (asciiNilai > asciNilaiMinimal)
                    {
                        dgvNilai.Rows[no - 1].DefaultCellStyle.BackColor = Color.LightSalmon;
                    }
                }
                no++;
            }

            Loading(false);
        }

        private async Task LoadMk()
        {
            MKByIdProdi m = new MKByIdProdi() { IdProdi = idProdi };
            string jsonData = JsonConvert.SerializeObject(m);

            response = await webApi.Post(URLGetMK, jsonData, true);
            if (!response.IsSuccessStatusCode)
            {
                MessageBox.Show(webApi.ReturnMessage(response));
                Loading(false);
                return;
            }

            listDataMatakuliah = JsonConvert.DeserializeObject<List<DataMataKuliah>>(response.Content.ReadAsStringAsync().Result).Where(w => w.Sampai > 0).ToList();
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

            var jsondata = string.Empty;
            var tempList = new List<HistoryKonversiNilai>();
            foreach (DataGridViewRow row in dgvNilai.Rows)
            {
                if (row.Cells["KodeD3"].Value == null)
                {
                    continue;
                }
                HistoryKonversiNilai h = new HistoryKonversiNilai();
                h.Nodaf = Nodaf;
                h.Npm = NpmLama;
                h.KodeD3 = row.Cells["KodeD3"].Value.ToString();
                h.MataKuliahD3 = row.Cells["MataKuliahD3"].Value.ToString();
                h.SksD3 = int.Parse(row.Cells["SksD3"].Value.ToString().Trim());
                h.NilaiD3 = row.Cells["NilaiD3"].Value.ToString();
                h.KodeS1 = row.Cells["KodeS1"].Value == null ? null : row.Cells["KodeS1"].Value.ToString();
                h.Nilai = row.Cells["Nilai"].Value == null ? null : row.Cells["Nilai"].Value.ToString();
                h.Approve = row.Cells["KodeS1"].Value == null ? false : true;
                h.Id = row.Cells["Id"].Value == null ? Guid.Empty : new Guid(row.Cells["Id"].Value.ToString());
                tempList.Add(h);
                //jsondata = JsonConvert.SerializeObject(h);
                //response = await webApi.Post(URLSaveHistoryNilaiCalonMhsAlihJalurSingle, jsondata, true);
                //if (!response.IsSuccessStatusCode)
                //{
                //    MessageBox.Show(webApi.ReturnMessage(response));
                //    Loading(false);
                //    return;
                //}

                //var idKonversi = JsonConvert.DeserializeObject<HistoryKonversiNilai>(response.Content.ReadAsStringAsync().Result).Id;
                //row.Cells["Id"].Value = idKonversi;
                //row.Cells["Hapus"].Value = "Hapus";
                //row.Cells["SksS1"].Value = row.Cells["SksS1"].Value == null ? 0 : row.Cells["SksS1"].Value;
            }

            jsondata = JsonConvert.SerializeObject(tempList);
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
            if (e.ColumnIndex != 5 && e.ColumnIndex != 6 && e.ColumnIndex != 9)
            {
                return;
            }

            var kodeLama = dgvNilai.Rows[e.RowIndex].Cells["KodeD3"].Value;
            var mataKuliahLama = dgvNilai.Rows[e.RowIndex].Cells["MataKuliahD3"].Value;
            var sksLama = dgvNilai.Rows[e.RowIndex].Cells["SksD3"].Value;
            var nilaiLama = dgvNilai.Rows[e.RowIndex].Cells["NilaiD3"].Value;
            var rowIndex = e.RowIndex;

            if (e.ColumnIndex != 9)
            {
                if (kodeLama == null || mataKuliahLama == null || sksLama == null || nilaiLama == null)
                {
                    MessageBox.Show("Kode D3, mata kuliah D3, sks D3, dan nilai D3 diisi dulu");
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
                                    nilaiLama.ToString(),
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
                NilaiD3 = dgvNilai.Rows[rowIndex].Cells["NilaiD3"].Value.ToString(),
                KodeS1 = kode,
                Nilai = nilai,
                Nodaf = Nodaf,
                Npm = NpmLama,
                Id = dgvNilai.Rows[rowIndex].Cells["Id"].Value != null ? new Guid(dgvNilai.Rows[rowIndex].Cells["Id"].Value.ToString()) : Guid.Empty
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

            dgvNilai.Rows[rowIndex].Cells["KodeS1"].Value = kode;
            dgvNilai.Rows[rowIndex].Cells["MataKuliahS1"].Value = mataKuliah;
            dgvNilai.Rows[rowIndex].Cells["SksS1"].Value = sks;
            dgvNilai.Rows[rowIndex].Cells["Nilai"].Value = nilai;
            dgvNilai.Rows[rowIndex].Cells["Hapus"].Value = "Hapus";
            //dgvNilai.Rows[rowIndex].Cells["Id"].Value = idKonversi.ToString();

            Loading(false);
        }

        private void dgvNilai_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            for (int i = 0; i < dgvNilai.Rows.Count; i++)
            {
                dgvNilai.Rows[i].Cells["No"].Value = i + 1;
            }
        }

        private void btnImportExcel_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Excel file (*.xlsx)|*.xlsx";
            openFileDialog1.ShowDialog();
        }

        private void btnGenerateExcel_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Kolom-kolom yang di dalam file excel agar tidak di ubah.\nLanjutkan proses?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.No)
            {
                return;
            }

            Loading(true);
            Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();

            if (xlApp == null)
            {
                MessageBox.Show("EXCEL could not be started. Check that your office installation and project references are correct.");
                Loading(false);
                return;
            }

            Microsoft.Office.Interop.Excel.Workbook wb = xlApp.Workbooks.Add(Microsoft.Office.Interop.Excel.XlWBATemplate.xlWBATWorksheet);
            Microsoft.Office.Interop.Excel.Worksheet ws = (Microsoft.Office.Interop.Excel.Worksheet)wb.Worksheets[1];

            if (ws == null)
            {
                MessageBox.Show("Worksheet could not be created. Check that your office installation and project references are correct.");
                Loading(false);
                return;
            }

            Microsoft.Office.Interop.Excel.Range rangeKodeD3 = ws.Range["A1", "A1"];
            ws.Cells[1, 1] = "KODE LAMA";

            Microsoft.Office.Interop.Excel.Range rangeMkD3 = ws.Range["A1", "B1"];
            ws.Cells[1, 2] = "MATA KULIAH LAMA";

            Microsoft.Office.Interop.Excel.Range rangeSksD3 = ws.Range["A1", "C1"];
            ws.Cells[1, 3] = "SKS LAMA";

            Microsoft.Office.Interop.Excel.Range rangeNilaiD3 = ws.Range["A1", "D1"];
            ws.Cells[1, 4] = "NILAI LAMA";

            Microsoft.Office.Interop.Excel.Range rangeKodeS1 = ws.Range["A1", "E1"];
            ws.Cells[1, 5] = "KODE BARU";

            Microsoft.Office.Interop.Excel.Range rangeMkS1 = ws.Range["A1", "F1"];
            ws.Cells[1, 6] = "MATA KULIAH BARU";

            Microsoft.Office.Interop.Excel.Range rangeSksS1 = ws.Range["A1", "G1"];
            ws.Cells[1, 7] = "SKS BARU";

            Microsoft.Office.Interop.Excel.Range rangeNilaiS1 = ws.Range["A1", "H1"];
            ws.Cells[1, 8] = "NILAI BARU";

            var row = 2;
            foreach (var mataKuliah in listDataMatakuliah)
            {
                ws.Cells[row, 5] = mataKuliah.Kode;
                ws.Cells[row, 6] = mataKuliah.MataKuliah;
                ws.Cells[row, 7] = mataKuliah.Sks;
                row++;
            }

            ws.Columns.AutoFit();
            xlApp.Visible = true;
            Loading(false);
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            var filename = openFileDialog1.FileName;

            Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();

            if (xlApp == null)
            {
                MessageBox.Show("EXCEL could not be started. Check that your office installation and project references are correct.");
                Loading(false);
                return;
            }

            Microsoft.Office.Interop.Excel.Workbook wb = xlApp.Workbooks.Open(filename);
            Microsoft.Office.Interop.Excel.Worksheet ws = (Microsoft.Office.Interop.Excel.Worksheet)wb.Worksheets[1];

            if (ws == null)
            {
                MessageBox.Show("Worksheet could not be created. Check that your office installation and project references are correct.");
                Loading(false);
                return;
            }

            Microsoft.Office.Interop.Excel.Range xlRange = ws.UsedRange;
            int rowCount = xlRange.Rows.Count;
            int colCount = xlRange.Columns.Count;
            dgvNilai.Rows.Clear();
            for (int i = 2; i <= rowCount; i++)
            {
                dgvNilai.Rows.Add();
                for (int j = 1; j <= colCount; j++)
                {
                    if (xlRange.Cells[i, j] != null && xlRange.Cells[i, j].Value2 != null)
                    {
                        try
                        {
                            var kodeS1 = xlRange.Cells[i, 5].Value2.ToString();
                            var dataMk = listDataMatakuliah.Find(mk => mk.Kode.Trim().ToLower() == kodeS1.Trim().ToLower());
                            if (dataMk != null)
                            {
                                dgvNilai.Rows[i - 2].Cells[1].Value = xlRange.Cells[i, 1].Value2.ToString();
                                dgvNilai.Rows[i - 2].Cells[2].Value = xlRange.Cells[i, 2].Value2.ToString();
                                dgvNilai.Rows[i - 2].Cells[3].Value = xlRange.Cells[i, 3].Value2.ToString();
                                dgvNilai.Rows[i - 2].Cells[4].Value = xlRange.Cells[i, 4].Value2.ToString();
                                dgvNilai.Rows[i - 2].Cells[5].Value = dataMk.Kode;
                                dgvNilai.Rows[i - 2].Cells[6].Value = dataMk.MataKuliah;
                                dgvNilai.Rows[i - 2].Cells[7].Value = dataMk.Sks;
                                dgvNilai.Rows[i - 2].Cells[8].Value = xlRange.Cells[i, 8].Value2.ToString();
                            }
                            else
                            {
                                dgvNilai.Rows[i - 2].Cells[j].Value = xlRange.Cells[i, j].Value2.ToString();
                            }
                        }
                        catch(Exception ex)
                        {
                            continue;
                        }
                    }
                }
            }

            GC.Collect();
            GC.WaitForPendingFinalizers();

            //rule of thumb for releasing com objects:
            //  never use two dots, all COM objects must be referenced and released individually
            //  ex: [somthing].[something].[something] is bad

            //release com objects to fully kill excel process from running in the background
            Marshal.ReleaseComObject(xlRange);
            Marshal.ReleaseComObject(ws);

            //close and release
            wb.Close();
            Marshal.ReleaseComObject(wb);

            //quit and release
            xlApp.Quit();
            Marshal.ReleaseComObject(xlApp);
        }
    }
}
