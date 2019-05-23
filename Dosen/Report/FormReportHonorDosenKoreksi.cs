#region Copyright Syncfusion Inc. 2001 - 2016
// Copyright Syncfusion Inc. 2001 - 2016. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using ApiService;
using ClassModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Windows.Forms;

namespace Dosen.Report
{
    public partial class FormReportHonorDosenKoreksi : Syncfusion.Windows.Forms.MetroForm
    {
        public static string baseAddress = ConfigurationManager.AppSettings["baseAddress"];
        private string URLGetTahunAkademik = baseAddress + "/jurusan_api/api/data_support/init_tahun_akademik";
        private string URLGetSemester = baseAddress + "/jurusan_api/api/data_support/init_data_semester";
        private string URLGethonorDosenKoreksi = baseAddress + "/jurusan_api/api/dosen/get_honor_dosen_koreksi";

        private List<ThnAkademik> listTahunAkademik;
        private List<DataSemester> listSemester;
        private List<Fakultas> listFakultas;
        private List<Prodi> listProdi;
        private List<Program> listProgram;

        private WebApi webApi;
        private HttpResponseMessage response;
        private List<HonorDosenKoreksi> listHonorDosenKoreksi;
        private List<HonorDosenKoreksi> listTempHonorDosenKoreksi;

        public FormReportHonorDosenKoreksi()
        {
            InitializeComponent();
            webApi = new WebApi();
            listTempHonorDosenKoreksi = new List<HonorDosenKoreksi>();
        }

        private void Loading(bool isLoading)
        {
            flowLayoutPanel1.Enabled = !isLoading;
            gradientPanel1.Enabled = !isLoading;
            dgvHonorDosenKoreksi.Enabled = !isLoading;
            progressBar1.Visible = isLoading;
        }

        private async void FormHonorDosenKoreksi_Load(object sender, EventArgs e)
        {
            Loading(true);
            listFakultas = new List<Fakultas>(Organisasi.listFakultas);
            listFakultas.Insert(0, new Fakultas() { KodeFakultas = "-", NamaFakultas = "Pilih" });
            listFakultas.Insert(1, new Fakultas() { KodeFakultas = "Semua", NamaFakultas = "Semua Fakultas" });
            cmbFakultas.DataSource = listFakultas;
            cmbFakultas.DisplayMember = "NamaFakultas";
            cmbFakultas.ValueMember = "KodeFakultas";
            cmbFakultas.SelectedIndex = 0;

            response = await webApi.Post(URLGetTahunAkademik, string.Empty, false);
            if (!response.IsSuccessStatusCode)
            {
                MessageBox.Show("Data tahun akademik gagal di tampilkan");
                Loading(false);
                return;
            }

            List<ThnAkademik> listTahunAkademik = JsonConvert.DeserializeObject<List<ThnAkademik>>(response.Content.ReadAsStringAsync().Result);
            listTahunAkademik.Insert(0, new ThnAkademik() { TahunAkademik = "Pilih" });
            listTahunAkademik.ForEach(delegate (ThnAkademik thnAkademik)
            {
                cmbTahunAkademik.Items.Add(thnAkademik.TahunAkademik);
            });
            cmbTahunAkademik.SelectedIndex = 0;

            response = await webApi.Post(URLGetSemester, string.Empty, false);
            if (!response.IsSuccessStatusCode)
            {
                MessageBox.Show("Data semester gagal di tampilkan");
                Loading(false);
                return;
            }

            List<DataSemester> listSemester = JsonConvert.DeserializeObject<List<DataSemester>>(response.Content.ReadAsStringAsync().Result);
            listSemester.Insert(0, new DataSemester() { Kode = 1, Nama = "Pilih" });
            cmbSemester.DataSource = listSemester;
            cmbSemester.DisplayMember = "Nama";
            cmbSemester.ValueMember = "Kode";
            cmbSemester.SelectedIndex = 0;

            cmbTahunAkademik.Text = LoginAccess.TahunAkademik;
            cmbSemester.Text = LoginAccess.Semester;
            Loading(false);
        }

        private void cmbFakultas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbFakultas.SelectedIndex > 0)
            {
                string kodeFakultas = cmbFakultas.SelectedValue.ToString();
                listProdi = Organisasi.listProdi.Where(pr => pr.Fakultas.KodeFakultas == kodeFakultas).ToList();
                listProdi.Insert(0, new Prodi() { IdProdi = "-", NamaProdi = "Pilih" });
                cmbProdi.DataSource = listProdi;
                cmbProdi.DisplayMember = "NamaProdi";
                cmbProdi.ValueMember = "Uid";
                cmbProdi.SelectedIndex = 0;

                if (cmbProgram.DataSource != null)
                {
                    cmbProgram.SelectedIndex = 0;
                }
            }
        }

        private void cmbProdi_SelectedIndexChanged(object sender, EventArgs e)
        {
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

        private void btnTutup_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void btnProses_Click(object sender, EventArgs e)
        {
            Loading(true);
            if (cmbTahunAkademik.SelectedIndex == 0 || cmbSemester.SelectedIndex == 0)
            {
                Loading(false);
                return;
            }

            var data = new { TahunAkademik = cmbTahunAkademik.Text, Semester = int.Parse(cmbSemester.SelectedValue.ToString()), JenisUjian = cmbJenisUjian.Text };
            var jsonData = JsonConvert.SerializeObject(data);
            response = await webApi.Post(URLGethonorDosenKoreksi, jsonData, true);
            if (!response.IsSuccessStatusCode)
            {
                MessageBox.Show(webApi.ReturnMessage(response));
                Loading(false);
                return;
            }

            listHonorDosenKoreksi = JsonConvert.DeserializeObject<List<HonorDosenKoreksi>>(response.Content.ReadAsStringAsync().Result);
            if (listHonorDosenKoreksi.Count <= 0)
            {
                Loading(false);
                return;
            }


            //List<HonorDosenKoreksi> tempHonorKoreksi = null;
            if (cmbFakultas.SelectedIndex == 1)
            {
                var honorKoreksiMhsNgulang = listHonorDosenKoreksi.Where(k => k.IsKuliahKelasLain).ToList();
                foreach (var item in honorKoreksiMhsNgulang)
                {
                    var honorKoreksiDosen = listHonorDosenKoreksi.Find(p => p.KodeProgram == item.KodeProgramPerkuliahan && p.Kode == item.Kode && p.Nik == item.Nik);
                    if (honorKoreksiDosen != null)
                    {
                        listHonorDosenKoreksi.Find(p => p.KodeProgram == item.KodeProgramPerkuliahan && p.Kode == item.Kode && p.Nik == item.Nik).JumlahKoreksi = honorKoreksiDosen.JumlahKoreksi + item.JumlahKoreksi;
                        listHonorDosenKoreksi.Find(p => p.KodeProgram == item.KodeProgramPerkuliahan && p.Kode == item.Kode && p.Nik == item.Nik).HonorKoreksi = honorKoreksiDosen.HonorKoreksi + item.HonorKoreksi;
                        listHonorDosenKoreksi.Find(p => p.KodeProgram == item.KodeProgramPerkuliahan && p.Kode == item.Kode && p.Nik == item.Nik).HonorTotal = honorKoreksiDosen.HonorTotal + item.HonorTotal;
                        listHonorDosenKoreksi.Find(p => p.KodeProgram == item.KodeProgramPerkuliahan && p.Kode == item.Kode && p.Nik == item.Nik).Pajak = honorKoreksiDosen.Pajak + item.Pajak;
                        listHonorDosenKoreksi.Find(p => p.KodeProgram == item.KodeProgramPerkuliahan && p.Kode == item.Kode && p.Nik == item.Nik).HonorDiterima = honorKoreksiDosen.HonorDiterima + item.HonorDiterima;
                        listHonorDosenKoreksi.Remove(item);
                    }
                }

                listTempHonorDosenKoreksi = listHonorDosenKoreksi;
            }
            else
            {
                var kodeFakultas = string.Empty;
                var uidProdi = string.Empty;
                var kodeProgram = string.Empty;

                if (cmbProdi.SelectedIndex > 1)
                {
                    kodeFakultas = cmbFakultas.SelectedValue.ToString();
                    listTempHonorDosenKoreksi = listHonorDosenKoreksi.Where(hr => hr.KodeFakultas == kodeFakultas).ToList();
                }

                if (cmbProdi.SelectedIndex != 0)
                {
                    uidProdi = cmbProdi.SelectedValue.ToString().ToUpper();
                    listTempHonorDosenKoreksi = listHonorDosenKoreksi.Where(hr => hr.Uid.ToString().ToUpper() == uidProdi).ToList();
                }

                if (cmbProgram.SelectedIndex != 0)
                {
                    kodeProgram = cmbProgram.SelectedValue.ToString();
                    listTempHonorDosenKoreksi = listHonorDosenKoreksi.Where(hr => hr.KodeProgram == kodeProgram).ToList();
                }
            }

            dgvHonorDosenKoreksi.Rows.Clear();
            var no = 1;
            foreach (var item in listTempHonorDosenKoreksi)
            {
                dgvHonorDosenKoreksi.Rows.Add
                    (
                        no,
                        item.Nik,
                        item.NamaDosen,
                        item.Npwp,
                        item.BebanSks,
                        item.Kehadiran,
                        item.NamaProdi.Split(';')[0],
                        item.NamaProgram,
                        DateTime.Parse(item.TanggalUjian).ToString("dd-MM-yyyy"), 
                        item.Kode,
                        item.MataKuliah,
                        item.Sks,
                        item.SifatMk,
                        item.Kelas,
                        item.JumlahKoreksi,
                        item.HonorSoal.ToString("C", CultureInfo.GetCultureInfo("id-ID")),
                        item.HonorSoal,
                        item.HonorKehadiran.ToString("C", CultureInfo.GetCultureInfo("id-ID")),
                        item.HonorKehadiran,
                        item.HonorKoreksi.ToString("C", CultureInfo.GetCultureInfo("id-ID")),
                        item.HonorKoreksi,
                        item.HonorTotal.ToString("C", CultureInfo.GetCultureInfo("id-ID")),
                        item.HonorTotal,
                        item.Pajak.ToString("C", CultureInfo.GetCultureInfo("id-ID")),
                        item.Pajak,
                        item.HonorDiterima.ToString("C", CultureInfo.GetCultureInfo("id-ID")),
                        item.HonorDiterima
                    );
                no++;
            }
            Loading(false);
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
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

            Microsoft.Office.Interop.Excel.Range rangeTitle = ws.get_Range("A1", "T1");
            rangeTitle.Merge();
            rangeTitle.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            ws.Cells[1, 1] = "HONOR DOSEN KOREKSI " + string.Format("T.A. {0} {1}", cmbTahunAkademik.Text, cmbSemester.Text);
            ws.Cells[1, 1].Font.Bold = true;
            ws.Cells[1, 1].Font.Size = 14;

            Microsoft.Office.Interop.Excel.Range rangeNomor = ws.Range["A3", "A3"];
            ws.Cells[3, 1] = "NO";

            Microsoft.Office.Interop.Excel.Range rangeNik = ws.Range["B3", "B3"];
            ws.Cells[3, 2] = "NIK";

            Microsoft.Office.Interop.Excel.Range rangeNama = ws.Range["C3", "C3"];
            ws.Cells[3, 3] = "NAMA DOSEN";

            Microsoft.Office.Interop.Excel.Range rangeNamaProgram = ws.Range["D3", "D3"];
            ws.Cells[3, 4] = "NPWP";

            //Microsoft.Office.Interop.Excel.Range rangeBebanSks = ws.Range["E3", "E3"];
            //ws.Cells[3, 5] = "BEBAN SKS";

            //Microsoft.Office.Interop.Excel.Range rangeKehadiran = ws.Range["F3", "F3"];
            //ws.Cells[3, 6] = "KEHADIRAN";

            Microsoft.Office.Interop.Excel.Range rangeKategoriDosen = ws.Range["G3", "G3"];
            ws.Cells[3, 5] = "PRODI";

            Microsoft.Office.Interop.Excel.Range rangeKode = ws.Range["H3", "H3"];
            ws.Cells[3, 6] = "PROGRAM";

            Microsoft.Office.Interop.Excel.Range rangeTglUjian = ws.Range["H3", "H3"];
            ws.Cells[3, 7] = "TANGGAL UJIAN";

            Microsoft.Office.Interop.Excel.Range rangeMataKuliah = ws.Range["I3", "I3"];
            ws.Cells[3, 8] = "KODE";

            Microsoft.Office.Interop.Excel.Range rangeJenisMK = ws.Range["J3", "J3"];
            ws.Cells[3, 9] = "MATA KULIAH";

            Microsoft.Office.Interop.Excel.Range rangeJumlahKelas = ws.Range["K3", "K3"];
            ws.Cells[3, 10] = "SKS";

            Microsoft.Office.Interop.Excel.Range rangeSksTotal = ws.Range["L3", "L3"];
            ws.Cells[3, 11] = "SIFAT MK";

            Microsoft.Office.Interop.Excel.Range rangeSksBeban = ws.Range["M3", "M3"];
            ws.Cells[3, 12] = "KELAS";

            Microsoft.Office.Interop.Excel.Range rangeSksBayar = ws.Range["N3", "N3"];
            ws.Cells[3, 13] = "JUMLAH KOREKSI";

            Microsoft.Office.Interop.Excel.Range rangeJmlPertemuan = ws.Range["O3", "O3"];
            ws.Cells[3, 14] = "HONOR SOAL";

            Microsoft.Office.Interop.Excel.Range rangePendidikan = ws.Range["P3", "P3"];
            ws.Cells[3, 15] = "HONOR KEHADIRAN";

            Microsoft.Office.Interop.Excel.Range rangeHrFix = ws.Range["Q3", "Q3"];
            ws.Cells[3, 16] = "HONOR KOREKSI";

            Microsoft.Office.Interop.Excel.Range rangeHrFixBulan = ws.Range["R3", "R3"];
            ws.Cells[3, 17] = "HONOR TOTAL";

            Microsoft.Office.Interop.Excel.Range rangeHrVar = ws.Range["S3", "S3"];
            ws.Cells[3, 18] = "PAJAK";

            Microsoft.Office.Interop.Excel.Range rangeHrVarBulan = ws.Range["T3", "T3"];
            ws.Cells[3, 19] = "HONOR DITERIMA";


            int startRow = 4;
            progressBar1.Style = ProgressBarStyle.Continuous;
            foreach (DataGridViewRow dgRow in dgvHonorDosenKoreksi.Rows)
            {
                ws.Cells[startRow, 1] = startRow - 3;
                ws.Cells[startRow, 2].NumberFormat = "@";
                ws.Cells[startRow, 2] = dgRow.Cells["Nik"].Value;// Nik;
                ws.Cells[startRow, 3] = dgRow.Cells["Nama"].Value;// .NamaDosen;
                ws.Cells[startRow, 4] = dgRow.Cells["Npwp"].Value;// .Npwp;
                //ws.Cells[startRow, 5] = dgRow.Cells["BebanSks"].Value;// .BebanSks;
                //ws.Cells[startRow, 6] = dgRow.Cells["Kehadiran"].Value;// .Kehadiran;
                ws.Cells[startRow, 5] = dgRow.Cells["ProgramSTudi"].Value;// .NamaProdi;
                ws.Cells[startRow, 6] = dgRow.Cells["Program"].Value;// .NamaProgram;
                ws.Cells[startRow, 7] = dgRow.Cells["TanggalUjian"].Value;// .NamaProgram;
                ws.Cells[startRow, 8] = dgRow.Cells["Kode"].Value;// .Kode;
                ws.Cells[startRow, 9] = dgRow.Cells["MataKuliah"].Value;// .MataKuliah;
                ws.Cells[startRow, 10] = dgRow.Cells["Sks"].Value;// .Sks;
                ws.Cells[startRow, 11] = dgRow.Cells["SifatMk"].Value;// .SifatMk;
                ws.Cells[startRow, 12] = dgRow.Cells["Kelas"].Value;// .Kelas;
                ws.Cells[startRow, 13] = dgRow.Cells["JumlahKoreksi"].Value;// .JumlahKoreksi;
                ws.Cells[startRow, 14] = dgRow.Cells["HonorSoalVal"].Value;// .HonorSoal;
                ws.Cells[startRow, 15] = dgRow.Cells["HonorKehadiranVal"].Value;// .HonorKehadiran;
                ws.Cells[startRow, 16] = dgRow.Cells["HonorKoreksiVal"].Value;// .HonorKoreksi;
                ws.Cells[startRow, 17] = dgRow.Cells["HonorTotalVal"].Value;// .HonorTotal;
                ws.Cells[startRow, 18] = dgRow.Cells["PajakVal"].Value;// .Pajak;
                ws.Cells[startRow, 19] = dgRow.Cells["HonorDiterimaVal"].Value;// .HonorDiterima;
                startRow++;
                progressBar1.Value = (int)(((double.Parse((startRow - 4).ToString())) / double.Parse(listTempHonorDosenKoreksi.Count.ToString())) * 100);
            }

            ws.Columns.AutoFit();
            xlApp.Visible = true;
            progressBar1.Style = ProgressBarStyle.Marquee;
            Loading(false);
        }
    }
}
