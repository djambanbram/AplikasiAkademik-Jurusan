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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dosen.Report
{
    public partial class FormReportHonorDosenMengajar2 : Syncfusion.Windows.Forms.MetroForm
    {
        public static string baseAddress = ConfigurationManager.AppSettings["baseAddress"];
        private string URLGetTahunAkademik = baseAddress + "/jurusan_api/api/data_support/init_tahun_akademik";
        private string URLGetSemester = baseAddress + "/jurusan_api/api/data_support/init_data_semester";
        private string URLGethonorDosenMengajar = baseAddress + "/jurusan_api/api/dosen/get_honor_dosen_mengajar";

        private WebApi webApi;
        private HttpResponseMessage response;

        private List<Fakultas> listFakultas;
        private List<Prodi> listProdi;
        private List<Program> listProgram;
        private List<HonorMengajarDosen> listHonorDosenMengajar;
        private List<HonorMengajarDosen> listTemp;

        private string KodeFakultas;
        private string IdProdi;
        private string KodeProgram;

        public FormReportHonorDosenMengajar2()
        {
            InitializeComponent();
            webApi = new WebApi();
        }

        private void Loading(bool isLoading)
        {
            flowLayoutPanel1.Enabled = !isLoading;
            dgvHonor.Enabled = !isLoading;
            gradientPanel1.Enabled = !isLoading;
            progressBar1.Visible = isLoading;
        }

        private async void FormHonorDosenMengajar2_Load(object sender, EventArgs e)
        {
            listFakultas = new List<Fakultas>(Organisasi.listFakultas);
            listFakultas.Insert(0, new Fakultas() { KodeFakultas = "-", NamaFakultas = "Pilih" });
            cmbFakultas.DataSource = listFakultas;
            cmbFakultas.DisplayMember = "NamaFakultas";
            cmbFakultas.ValueMember = "KodeFakultas";
            cmbFakultas.SelectedIndex = 0;


            Loading(true);
            response = await webApi.Post(URLGetTahunAkademik, string.Empty, false);
            if (!response.IsSuccessStatusCode)
            {
                MessageBox.Show("Data tahun akademik gagal di tampilkan");
                Loading(false);
                return;
            }

            List<string> listTahunAkademik = JsonConvert.DeserializeObject<List<string>>(response.Content.ReadAsStringAsync().Result);
            listTahunAkademik.Insert(0, "Pilih");
            listTahunAkademik.ForEach(delegate (string thnAkademik)
            {
                cmbTahunAkademik.Items.Add(thnAkademik);
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

            var getData = new { TahunAkademik = cmbTahunAkademik.Text, Semester = cmbSemester.SelectedValue.ToString() };
            var jsonData = JsonConvert.SerializeObject(getData);
            response = await webApi.Post(URLGethonorDosenMengajar, jsonData, true);
            if (!response.IsSuccessStatusCode)
            {
                MessageBox.Show(webApi.ReturnMessage(response));
                Loading(false);
                return;
            }

            dgvHonor.Rows.Clear();
            listHonorDosenMengajar = JsonConvert.DeserializeObject<List<HonorMengajarDosen>>(response.Content.ReadAsStringAsync().Result);

            Loading(false);
        }

        private void cmbFakultas_SelectedIndexChanged(object sender, EventArgs e)
        {
            KodeFakultas = null;
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
                KodeFakultas = cmbFakultas.SelectedValue.ToString();
            }
        }

        private void cmbProdi_SelectedIndexChanged(object sender, EventArgs e)
        {
            IdProdi = null;
            if (cmbFakultas.SelectedIndex > 0 && cmbProdi.SelectedIndex > 0)
            {
                string idProdi = cmbProdi.SelectedValue.ToString();
                listProgram = Organisasi.listProgram.Where(program => program.Prodi.Uid == idProdi).ToList();
                listProgram.Insert(0, new Program() { KodeProgram = "-", NamaProgram = "Pilih" });
                cmbProgram.DataSource = listProgram;
                cmbProgram.DisplayMember = "NamaProgram";
                cmbProgram.ValueMember = "KodeProgram";
                cmbProgram.SelectedIndex = 0;
                IdProdi = cmbProdi.SelectedValue.ToString();
            }
        }

        private void btnTutup_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void LoadHonorDosen(string kodeFakultas, string kodeProdi, string kodeProgram)
        {
            Loading(true);
            listTemp = null;
            dgvHonor.Rows.Clear();
            if (!string.IsNullOrWhiteSpace(KodeProgram))
            {
                listTemp = listHonorDosenMengajar.Where(h => h.KodeProgram == KodeProgram).ToList();
            }
            else if (!string.IsNullOrWhiteSpace(IdProdi))
            {
                listTemp = listHonorDosenMengajar.Where(h => h.IdProdi == IdProdi).ToList();
            }
            else if (!string.IsNullOrWhiteSpace(KodeFakultas))
            {
                listTemp = listHonorDosenMengajar.Where(h => h.KodeFakultas == KodeFakultas).ToList();
            }

            if (cmbKategoriDosen.SelectedIndex > 0)
            {
                listTemp = listTemp.Where(h => h.KategoriDosen == cmbKategoriDosen.Text).ToList();
            }

            var listTemp2 = listTemp
                .Select(h => new { h.NIK, h.NamaDosen, h.BebanSks, h.KategoriDosen, h.NamaProgram, h.JenisMataKuliah, h.Kode, h.MataKuliah, h.Sks, h.SksTp, h.JenjangPendidikan, h.Golongan, h.HFix, h.HVar, h.Npwp, h.NoRekeningBank, h.NamaBank, h.KodeProgram })
                .Distinct()
                .ToList();
            int no = 1;
            decimal pajak = 5;
            int pertemuanPerSKs = 7;
            foreach (var h in listTemp2)
            {
                var jmlKelas = listTemp.Where(j => j.NIK == h.NIK && j.Kode == h.Kode && j.KodeProgram == h.KodeProgram).ToList().Count;
                var jmlSksTotal = jmlKelas * h.SksTp;
                var jmlPertemuanMengajar = jmlSksTotal * pertemuanPerSKs;
                var hrFix = (jmlPertemuanMengajar * h.HFix);
                var hrVar = (jmlPertemuanMengajar * h.HVar);
                var hrTotal = hrFix + hrVar;
                var pajakTotal = hrTotal * (pajak / 100);
                var hrDiterima = hrTotal - pajakTotal;
                dgvHonor.Rows.Add(
                    no,
                    h.NIK,
                    h.NamaDosen,
                    h.NamaProgram,
                    h.KategoriDosen.Replace("Dosen", ""),
                    h.Kode,
                    h.MataKuliah,
                    string.Format("{0}{1}", h.SksTp, h.JenisMataKuliah),
                    jmlKelas,
                    jmlSksTotal,
                    jmlPertemuanMengajar,
                    string.Format("{0}/{1}", h.JenjangPendidikan, h.Golongan),
                    hrFix,
                    hrVar,
                    hrTotal,
                    pajakTotal,
                    hrDiterima,
                    h.Npwp,
                    h.NoRekeningBank,
                    h.NamaBank
                    );
                no++;
            }
            Loading(false);
        }

        private void btnProses_Click(object sender, EventArgs e)
        {
            if (cmbTahunAkademik.SelectedIndex <= 0 || cmbSemester.SelectedIndex <= 0 || cmbFakultas.SelectedIndex <= 0)
            {
                dgvHonor.Rows.Clear();
                return;
            }

            LoadHonorDosen(KodeFakultas, IdProdi, KodeProgram);
        }

        private void cmbProgram_SelectedIndexChanged(object sender, EventArgs e)
        {
            KodeProgram = null;
            if (cmbProgram.SelectedIndex > 0)
            {
                KodeProgram = cmbProgram.SelectedValue.ToString();
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (listHonorDosenMengajar == null || dgvHonor.Rows.Count == 0)
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

            Microsoft.Office.Interop.Excel.Range rangeTitle = ws.get_Range("A1", "T1");
            rangeTitle.Merge();
            rangeTitle.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            ws.Cells[1, 1] = "HONOR DOSEN MENGAJAR " + string.Format("T.A. {0} {1}", cmbTahunAkademik.Text, cmbSemester.Text);

            Microsoft.Office.Interop.Excel.Range rangeNomor = ws.get_Range("A3", "A3");
            ws.Cells[3, 1] = "NO";

            Microsoft.Office.Interop.Excel.Range rangeNik = ws.get_Range("B3", "B3");
            ws.Cells[3, 2] = "NIK";

            Microsoft.Office.Interop.Excel.Range rangeNama = ws.get_Range("C3", "C3");
            ws.Cells[3, 3] = "NAMA DOSEN";

            Microsoft.Office.Interop.Excel.Range rangeKode = ws.get_Range("D3", "D3");
            ws.Cells[3, 4] = "PRODI";

            Microsoft.Office.Interop.Excel.Range rangeMataKuliah = ws.get_Range("E3", "E3");
            ws.Cells[3, 5] = "KATEGORI DOSEN";

            Microsoft.Office.Interop.Excel.Range rangePendGol = ws.get_Range("F3", "F3");
            ws.Cells[3, 6] = "KODE";

            Microsoft.Office.Interop.Excel.Range rangeJenisKuliah = ws.get_Range("G3", "G3");
            ws.Cells[3, 7] = "MATA KULIAH";

            Microsoft.Office.Interop.Excel.Range rangeSks = ws.get_Range("H3", "H3");
            ws.Cells[3, 8] = "SKS MK";

            Microsoft.Office.Interop.Excel.Range rangeJumlahKelas = ws.get_Range("I3", "I3");
            ws.Cells[3, 9] = "JUMLAH KELAS";

            Microsoft.Office.Interop.Excel.Range rangeSksMengajar = ws.get_Range("J3", "J3");
            ws.Cells[3, 10] = "SKS TOTAL";

            Microsoft.Office.Interop.Excel.Range rangeBebanSks = ws.get_Range("K3", "K3");
            ws.Cells[3, 11] = "JML. PERTEMUAN MENGAJAR";

            Microsoft.Office.Interop.Excel.Range rangeSksTotal = ws.get_Range("L3", "L3");
            ws.Cells[3, 12] = "PEND/GOLONGAN";

            Microsoft.Office.Interop.Excel.Range rangePertemuan = ws.get_Range("M3", "M3");
            ws.Cells[3, 13] = "HR FIX";

            Microsoft.Office.Interop.Excel.Range rangeHrFix = ws.get_Range("N3", "N3");
            ws.Cells[3, 14] = "HR VAR";

            Microsoft.Office.Interop.Excel.Range rangeHrvar = ws.get_Range("O3", "O3");
            ws.Cells[3, 15] = "HR TOTAL";

            Microsoft.Office.Interop.Excel.Range rangeFixBulan = ws.get_Range("P3", "P3");
            ws.Cells[3, 16] = "PAJAK";

            Microsoft.Office.Interop.Excel.Range rangeVarBulan = ws.get_Range("Q3", "Q3");
            ws.Cells[3, 17] = "HR DITERIMA";

            Microsoft.Office.Interop.Excel.Range rangeHrTambahan = ws.get_Range("R3", "R3");
            ws.Cells[3, 18] = "NPWP";

            Microsoft.Office.Interop.Excel.Range rangeTotalHr = ws.get_Range("S3", "S3");
            ws.Cells[3, 19] = "NO. REKENING BANK";

            Microsoft.Office.Interop.Excel.Range rangePajak = ws.get_Range("T3", "T3");
            ws.Cells[3, 20] = "BANK";


            int startRow = 4;
            foreach (DataGridViewRow item in dgvHonor.Rows)
            {
                ws.Cells[startRow, 1] = startRow - 3;
                ws.Cells[startRow, 2].NumberFormat = "@";
                ws.Cells[startRow, 2] = item.Cells["NIK"].Value.ToString();
                ws.Cells[startRow, 3] = item.Cells["Nama"].Value.ToString();
                ws.Cells[startRow, 4] = item.Cells["Prodi"].Value.ToString();
                ws.Cells[startRow, 5] = item.Cells["KategoriDosen"].Value.ToString();
                ws.Cells[startRow, 6] = item.Cells["Kode"].Value.ToString();
                ws.Cells[startRow, 7] = item.Cells["MataKuliah"].Value.ToString();
                ws.Cells[startRow, 8] = item.Cells["SksMK"].Value.ToString();
                ws.Cells[startRow, 9] = item.Cells["JmlKelas"].Value.ToString();
                ws.Cells[startRow, 10] = item.Cells["SksTotal"].Value.ToString();
                ws.Cells[startRow, 11] = item.Cells["JmlPertemuan"].Value.ToString();
                ws.Cells[startRow, 12] = item.Cells["PendGol"].Value.ToString();
                ws.Cells[startRow, 13] = item.Cells["HrFix"].Value.ToString();
                ws.Cells[startRow, 14] = item.Cells["HrVar"].Value.ToString();
                ws.Cells[startRow, 15] = item.Cells["HRTotal"].Value.ToString();
                ws.Cells[startRow, 16] = item.Cells["Pajak"].Value.ToString();
                ws.Cells[startRow, 17] = item.Cells["HRDiterima"].Value.ToString();
                ws.Cells[startRow, 18] = item.Cells["Npwp"].Value;
                ws.Cells[startRow, 19] = item.Cells["NoRek"].Value;
                ws.Cells[startRow, 20] = item.Cells["Bank"].Value;
                startRow++;
            }

            xlApp.Visible = true;
            Loading(false);
        }
    }
}
