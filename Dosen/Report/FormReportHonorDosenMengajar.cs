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
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Windows.Forms;

namespace Dosen.Report
{
    public partial class FormReportHonorDosenMengajar : Syncfusion.Windows.Forms.MetroForm
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

        private List<dynamic> listHonorDosen;

        public FormReportHonorDosenMengajar()
        {
            InitializeComponent();
            webApi = new WebApi();
        }

        private void Loading(bool isLoading)
        {
            flowLayoutPanel1.Enabled = !isLoading;
            dataGridView1.Enabled = !isLoading;
            gradientPanel1.Enabled = !isLoading;
            progressBar1.Visible = isLoading;
        }

        private void btnTutup_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void FormReportHonorDosenMengajar_Load(object sender, EventArgs e)
        {
            Loading(true);
            listFakultas = new List<Fakultas>(Organisasi.listFakultas);
            listFakultas.Insert(0, new Fakultas() { KodeFakultas = "-", NamaFakultas = "Pilih" });
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

        private async void btnProses_Click(object sender, EventArgs e)
        {
            if (!(cmbTahunAkademik.SelectedIndex > 0 &&
                cmbSemester.SelectedIndex > 0 &&
                cmbFakultas.SelectedIndex > 0 &&
                cmbProdi.SelectedIndex > 0 &&
                cmbProgram.SelectedIndex > 0))
            {
                return;
            }
            var tahunAkademik = cmbTahunAkademik.Text;
            var semester = int.Parse(cmbSemester.SelectedValue.ToString());
            var isPertemuan = checkBox1.Checked ? true : false;
            var isDosebTetap = cmbKategoriDosen.SelectedIndex == 1 ? true : false;
            var kodeJurusan = cmbProgram.SelectedValue.ToString();

            Loading(true);
            var getData = new
            {
                TahunAkademik = tahunAkademik,
                Semester = semester,
                IsPertemuan = isPertemuan,
                IsDosebTetap = isDosebTetap,
                KodeJurusan = kodeJurusan
            };
            var jsonData = JsonConvert.SerializeObject(getData);
            response = await webApi.Post(URLGethonorDosenMengajar, jsonData, true);
            if (!response.IsSuccessStatusCode)
            {
                MessageBox.Show(webApi.ReturnMessage(response));
                Loading(false);
                return;
            }

            listHonorDosen = JsonConvert.DeserializeObject<List<dynamic>>(response.Content.ReadAsStringAsync().Result);
            dataGridView1.Rows.Clear();
            int no = 1;
            foreach (var item in listHonorDosen)
            {
                dataGridView1.Rows.Add(no, item.NamaDosen, item.MataKuliah, item.PendGol, item.JumlahKelas, item.SksMengajar, item.BebanSks, item.SksTotal,
                    item.Pertemuan, item.FixBulan, item.VarBulan, item.HrTambahan, item.TotalHr, item.Pajak, item.HrDiterima);
                no++;
            }
            Loading(false);
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if(listHonorDosen == null)
            {
                MessageBox.Show("Tidak ada data yang akan di proses"); 
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

            Microsoft.Office.Interop.Excel.Range rangeTitle = ws.get_Range("A1", "U1");
            rangeTitle.Merge();
            rangeTitle.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            ws.Cells[1, 1] = "HONOR DOSEN MENGAJAR " + string.Format("{0} T.A. {1} {2}", cmbKategoriDosen.Text, cmbTahunAkademik.Text, cmbSemester.Text);

            Microsoft.Office.Interop.Excel.Range rangeNomor = ws.get_Range("A3", "A3");
            ws.Cells[3, 1] = "NO";

            Microsoft.Office.Interop.Excel.Range rangeNik = ws.get_Range("B3", "B3");
            ws.Cells[3, 2] = "NIK";

            Microsoft.Office.Interop.Excel.Range rangeNama = ws.get_Range("C3", "C3");
            ws.Cells[3, 3] = "NAMA DOSEN";

            Microsoft.Office.Interop.Excel.Range rangeKode = ws.get_Range("D3", "D3");
            ws.Cells[3, 4] = "KODE";

            Microsoft.Office.Interop.Excel.Range rangeMataKuliah = ws.get_Range("E3", "E3");
            ws.Cells[3, 5] = "MATA KULIAH";

            Microsoft.Office.Interop.Excel.Range rangePendGol = ws.get_Range("A3", "A3");
            ws.Cells[3, 6] = "PENDIDIKAN/GOLONGAN";

            Microsoft.Office.Interop.Excel.Range rangeJenisKuliah = ws.get_Range("B3", "B3");
            ws.Cells[3, 7] = "JENIS KULIAH";

            Microsoft.Office.Interop.Excel.Range rangeSks = ws.get_Range("C3", "C3");
            ws.Cells[3, 8] = "SKS";

            Microsoft.Office.Interop.Excel.Range rangeJumlahKelas = ws.get_Range("D3", "D3");
            ws.Cells[3, 9] = "JUMLAH KELAS";

            Microsoft.Office.Interop.Excel.Range rangeSksMengajar = ws.get_Range("E3", "E3");
            ws.Cells[3, 10] = "SKS MENGAJAR";

            Microsoft.Office.Interop.Excel.Range rangeBebanSks = ws.get_Range("A3", "A3");
            ws.Cells[3, 11] = "BEBAN SKS";

            Microsoft.Office.Interop.Excel.Range rangeSksTotal = ws.get_Range("B3", "B3");
            ws.Cells[3, 12] = "SKS TOTAL";

            Microsoft.Office.Interop.Excel.Range rangePertemuan = ws.get_Range("C3", "C3");
            ws.Cells[3, 13] = "JML PERTEMUAN";

            Microsoft.Office.Interop.Excel.Range rangeHrFix = ws.get_Range("D3", "D3");
            ws.Cells[3, 14] = "HR FIX";

            Microsoft.Office.Interop.Excel.Range rangeHrvar = ws.get_Range("E3", "E3");
            ws.Cells[3, 15] = "HR VARIABLE";

            Microsoft.Office.Interop.Excel.Range rangeFixBulan = ws.get_Range("A3", "A3");
            ws.Cells[3, 16] = "HR FIX/BULAN";

            Microsoft.Office.Interop.Excel.Range rangeVarBulan = ws.get_Range("B3", "B3");
            ws.Cells[3, 17] = "HR VARIABLE/BULAN";

            Microsoft.Office.Interop.Excel.Range rangeHrTambahan = ws.get_Range("C3", "C3");
            ws.Cells[3, 18] = "HR TAMBAHAN";

            Microsoft.Office.Interop.Excel.Range rangeTotalHr = ws.get_Range("D3", "D3");
            ws.Cells[3, 19] = "TOTAL HR";

            Microsoft.Office.Interop.Excel.Range rangePajak = ws.get_Range("E3", "E3");
            ws.Cells[3, 20] = "PAJAK";

            Microsoft.Office.Interop.Excel.Range rangeDiterima = ws.get_Range("E3", "E3");
            ws.Cells[3, 21] = "HR DITERIMA";

            int startRow = 4;
            foreach (var peserta in listHonorDosen)
            {
                ws.Cells[startRow, 1] = startRow - 3;
                ws.Cells[startRow, 2] = peserta.Nik;
                ws.Cells[startRow, 3] = peserta.NamaDosen;
                ws.Cells[startRow, 4] = peserta.Kode;
                ws.Cells[startRow, 5] = peserta.MataKuliah;
                ws.Cells[startRow, 6] = peserta.PendGol;
                ws.Cells[startRow, 7] = peserta.JenisKuliah;
                ws.Cells[startRow, 8] = peserta.Sks;
                ws.Cells[startRow, 9] = peserta.JumlahKelas;
                ws.Cells[startRow, 10] = peserta.SksMengajar;
                ws.Cells[startRow, 11] = peserta.BebanSks;
                ws.Cells[startRow, 12] = peserta.SksTotal;
                ws.Cells[startRow, 13] = peserta.Pertemuan;
                ws.Cells[startRow, 14] = peserta.HrFix;
                ws.Cells[startRow, 15] = peserta.Hrvar;
                ws.Cells[startRow, 16] = peserta.FixBulan;
                ws.Cells[startRow, 17] = peserta.VarBulan;
                ws.Cells[startRow, 18] = peserta.HrTambahan;
                ws.Cells[startRow, 19] = peserta.TotalHr;
                ws.Cells[startRow, 20] = peserta.Pajak;
                ws.Cells[startRow, 21] = peserta.HrDiterima;
                startRow++;
            }
            Loading(false);

            xlApp.Visible = true;
        }
    }
}
