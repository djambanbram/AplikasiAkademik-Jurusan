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
        //private List<HonorMengajarDosen> listTemp;
        private List<DataHonorDosenMengajar> listDataHonorDosenMengajar;

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
            listFakultas.Insert(1, new Fakultas() { KodeFakultas = "Semua", NamaFakultas = "Semua Fakultas" });
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
            listHonorDosenMengajar = JsonConvert.DeserializeObject<List<HonorMengajarDosen>>(response.Content.ReadAsStringAsync().Result);
            listDataHonorDosenMengajar = new List<DataHonorDosenMengajar>();
            dgvHonor.Columns.Clear();
            List<HonorMengajarDosen> listTemp = new List<HonorMengajarDosen>();
            //if (!string.IsNullOrWhiteSpace(KodeProgram))
            //{
            //    listTemp = listHonorDosenMengajar.Where(h => h.KodeProgram == KodeProgram).ToList();
            //}
            //else if (!string.IsNullOrWhiteSpace(IdProdi))
            //{
            //    listTemp = listHonorDosenMengajar.Where(h => h.IdProdi == IdProdi).ToList();
            //}
            //else if (!string.IsNullOrWhiteSpace(KodeFakultas))
            //{
            //    if (KodeFakultas == "Semua")
            //    {
            //        listTemp = listHonorDosenMengajar;
            //    }
            //    else
            //    {
            //        listTemp = listHonorDosenMengajar.Where(h => h.KodeFakultas == KodeFakultas).ToList();
            //    }
            //}

            listTemp = listHonorDosenMengajar;
            if (cmbKategoriDosen.SelectedIndex > 0)
            {
                listTemp = listTemp.Where(h => h.KategoriDosen == cmbKategoriDosen.Text).ToList();
            }

            var listDataFix = listTemp
                .Select(h => new { h.NIK, h.NamaDosen, h.BebanSks, h.KategoriDosen, h.NamaProgram, h.JenisMataKuliah, h.Kode, h.MataKuliah, h.SksTp, h.JenjangPendidikan, h.Golongan, h.HFix, h.HVar, h.Npwp, h.NoRekeningBank, h.NamaBank, h.KodeProgram, h.IdProdi, h.KodeFakultas })
                .Distinct()
                .ToList();
            var no = 1;
            decimal pajak = 0;
            var pertemuanPerSKs = 7;
            var tempBeban = 0;
            var tempNik = string.Empty;
            foreach (var h in listDataFix)
            {
                var jmlKelas = listTemp.Where(j => j.NIK == h.NIK && j.Kode == h.Kode && j.KodeProgram == h.KodeProgram && j.JenisMataKuliah == h.JenisMataKuliah).ToList().Count;
                var jmlSksTotal = jmlKelas * h.SksTp;
                if (tempNik != h.NIK)
                {
                    tempNik = h.NIK;
                    tempBeban = listTemp.Find(j => j.NIK == tempNik).BebanSks = 6;
                }
                var jmlSksBayar = 0;
                if (tempBeban <= jmlSksTotal && tempBeban != 0)
                {
                    jmlSksBayar = jmlSksTotal - tempBeban;
                }
                else if (tempBeban > jmlSksTotal)
                {
                    jmlSksBayar = 0;
                }
                else if (tempBeban == 0)
                {
                    jmlSksBayar = jmlSksTotal;
                    tempBeban = 0;
                }
                int jmlPertemuanMengajar = jmlSksTotal * pertemuanPerSKs;
                var hrFixBulan = (jmlSksBayar * h.HFix);
                decimal hrVarBulan = 0;
                if (h.KodeProgram == "60" || h.KodeProgram == "61" || h.KodeProgram == "62")
                {
                    if (h.KategoriDosen == "Dosen Tetap")
                    {
                        hrVarBulan = ((jmlPertemuanMengajar * h.HVar) / 6) * 2;
                    }
                    else
                    {
                        hrVarBulan = ((jmlPertemuanMengajar * h.HVar) / 3) * 2;
                    }
                }
                else
                {
                    if (h.KategoriDosen == "Dosen Tetap")
                    {
                        hrVarBulan = (jmlPertemuanMengajar * h.HVar) / 6;
                    }
                    else
                    {
                        hrVarBulan = (jmlPertemuanMengajar * h.HVar) / 3;
                    }
                }
                decimal hrTotal = hrFixBulan + hrVarBulan;
                if (!string.IsNullOrWhiteSpace(h.Npwp))
                {
                    pajak = Convert.ToDecimal(2.5);
                }
                else
                {
                    pajak = 5;
                }
                var pajakTotal = hrTotal * (pajak / 100);
                var hrDiterima = hrTotal - pajakTotal;
                DataHonorDosenMengajar d = new DataHonorDosenMengajar();
                d.Nomor = no;
                d.NIK = h.NIK;
                d.NamaDosen = h.NamaDosen;
                d.NamaProgram = h.NamaProgram;
                d.KategoriDosen = h.KategoriDosen.Replace("Dosen", "");
                d.Kode = h.Kode;
                d.MataKuliah = h.MataKuliah;
                d.JenisMataKuliah = string.Format("{0}{1}", h.SksTp, h.JenisMataKuliah);
                d.JumlahKelas = jmlKelas;
                d.JumlahSksTotal = jmlSksTotal;
                d.BebanSks = tempBeban;
                d.JumlahSksBayar = jmlSksBayar;
                d.JumlahPertemuan = jmlPertemuanMengajar;
                d.PendidikanGolongan = string.Format("{0}/{1}", h.JenjangPendidikan, h.Golongan);
                d.HrVarPerBulan = hrVarBulan;
                d.HrFixPerBulan = hrFixBulan;
                d.HrTotalPerBulan = hrTotal;
                d.PajakTotal = pajakTotal;
                d.HrDiterimaPerBulan = hrDiterima;
                d.Npwp = h.Npwp;
                d.NoRekening = h.NoRekeningBank;
                d.NamaBank = h.NamaBank;
                d.KodeProgram = h.KodeProgram;
                d.IdProdi = h.IdProdi;
                d.KodeFakultas = h.KodeFakultas;
                listDataHonorDosenMengajar.Add(d);

                if (tempBeban <= jmlSksTotal && tempBeban != 0)
                {
                    tempBeban = 0;
                }
                else if (tempBeban > jmlSksTotal)
                {
                    tempBeban = tempBeban - jmlSksTotal;
                }
                no++;
            }

            DataTable dtHonor = Lib.CommonLib.ToDataTable(listDataHonorDosenMengajar);
            if (!string.IsNullOrWhiteSpace(KodeProgram))
            {
                dgvHonor.DataSource = listDataHonorDosenMengajar.Where(p => p.KodeProgram == KodeProgram).ToList();
            }
            else if (!string.IsNullOrWhiteSpace(IdProdi))
            {
                dgvHonor.DataSource = listDataHonorDosenMengajar.Where(i => i.IdProdi == IdProdi).ToList();
            }
            else if (!string.IsNullOrWhiteSpace(KodeFakultas))
            {
                if (KodeFakultas == "Semua")
                {
                    dgvHonor.DataSource = listDataHonorDosenMengajar;
                }
                else
                {
                    dgvHonor.DataSource = listDataHonorDosenMengajar.Where(f => f.KodeFakultas == KodeFakultas).ToList();
                }
            }

            dgvHonor.Columns["KodeFakultas"].Visible = false;
            dgvHonor.Columns["IdProdi"].Visible = false;
            dgvHonor.Columns["KodeProgram"].Visible = false;
            dgvHonor.Columns["Nomor"].Frozen = true;
            dgvHonor.Columns["NIK"].Frozen = true;
            dgvHonor.Columns["NamaDosen"].Frozen = true;
            Loading(false);
        }

        //private void LoadHonorDosen2(string kodeFakultas, string kodeProdi, string kodeProgram)
        //{
        //    Loading(true);
        //    listTemp = null;
        //    dgvHonor.Rows.Clear();
        //    if (!string.IsNullOrWhiteSpace(KodeProgram))
        //    {
        //        listTemp = listHonorDosenMengajar.Where(h => h.KodeProgram == KodeProgram).ToList();
        //    }
        //    else if (!string.IsNullOrWhiteSpace(IdProdi))
        //    {
        //        listTemp = listHonorDosenMengajar.Where(h => h.IdProdi == IdProdi).ToList();
        //    }
        //    else if (!string.IsNullOrWhiteSpace(KodeFakultas))
        //    {
        //        if (KodeFakultas == "Semua")
        //        {
        //            listTemp = listHonorDosenMengajar;
        //        }
        //        else
        //        {
        //            listTemp = listHonorDosenMengajar.Where(h => h.KodeFakultas == KodeFakultas).ToList();
        //        }
        //    }

        //    if (cmbKategoriDosen.SelectedIndex > 0)
        //    {
        //        listTemp = listTemp.Where(h => h.KategoriDosen == cmbKategoriDosen.Text).ToList();
        //    }

        //    var listTemp2 = listTemp
        //        .Select(h => new { h.NIK, h.NamaDosen, h.BebanSks, h.KategoriDosen, h.JenjangPendidikan, h.Golongan, h.HFix, h.HVar, h.Npwp, h.NoRekeningBank, h.NamaBank })
        //        .Distinct()
        //        .ToList();
        //    int no = 1;
        //    decimal pajak = 0;
        //    int pertemuanPerSKs = 7;
        //    foreach (var h in listTemp2)
        //    {
        //        var jmlKelas = listTemp.Where(j => j.NIK == h.NIK).ToList().Count;
        //        var jmlSksTotal = listTemp.Where(k => k.NIK == h.NIK).Sum(s => s.SksTp);//jmlKelas * h.SksTp;
        //        var jmlSksBayar = h.BebanSks >= jmlSksTotal ? 0 : jmlSksTotal - h.BebanSks;
        //        decimal jmlPertemuanMengajar = jmlSksTotal * pertemuanPerSKs;
        //        var hrFix = (jmlSksBayar * h.HFix);
        //        var hrVar = (jmlPertemuanMengajar * h.HVar) / 6;
        //        decimal hrTotal = hrFix + hrVar;
        //        if (!string.IsNullOrWhiteSpace(h.Npwp))
        //        {
        //            pajak = Convert.ToDecimal(2.5);
        //        }
        //        else
        //        {
        //            pajak = 5;
        //        }
        //        var pajakTotal = hrTotal * (pajak / 100);
        //        var hrDiterima = hrTotal - pajakTotal;
        //        dgvHonor.Rows.Add(
        //            no,
        //            h.NIK,
        //            h.NamaDosen,
        //            "",
        //            h.KategoriDosen.Replace("Dosen", ""),
        //            "",
        //            "",
        //            "",
        //            jmlKelas,
        //            jmlSksTotal,
        //            h.BebanSks,
        //            jmlSksBayar,
        //            jmlPertemuanMengajar,
        //            string.Format("{0}/{1}", h.JenjangPendidikan, h.Golongan),
        //            hrFix,
        //            hrVar,
        //            hrTotal,
        //            pajakTotal,
        //            hrDiterima,
        //            h.Npwp,
        //            h.NoRekeningBank,
        //            h.NamaBank
        //            );
        //        no++;
        //    }
        //    Prodi.Visible = false;
        //    Kode.Visible = false;
        //    MataKuliah.Visible = false;
        //    SksMK.Visible = false;

        //    HrFix.Visible = true;
        //    HrVar.Visible = true;
        //    HRTotal.Visible = true;
        //    Pajak.Visible = true;
        //    HRDiterima.Visible = true;

        //    Loading(false);
        //}

        private void btnProses_Click(object sender, EventArgs e)
        {
            if (cmbTahunAkademik.SelectedIndex <= 0 || cmbSemester.SelectedIndex <= 0 || cmbFakultas.SelectedIndex <= 0)
            {
                dgvHonor.Rows.Clear();
                return;
            }
            LoadHonorDosen(KodeFakultas, IdProdi, KodeProgram);
            //LoadHonorDosen(KodeFakultas, IdProdi, KodeProgram);
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

            Microsoft.Office.Interop.Excel.Range rangeTitle = ws.get_Range("A1", "V1");
            rangeTitle.Merge();
            rangeTitle.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            ws.Cells[1, 1] = "HONOR DOSEN MENGAJAR " + string.Format("T.A. {0} {1}", cmbTahunAkademik.Text, cmbSemester.Text);

            Microsoft.Office.Interop.Excel.Range rangeNomor = ws.Range["A3", "A3"];
            ws.Cells[3, 1] = "NO";

            Microsoft.Office.Interop.Excel.Range rangeNik = ws.Range["B3", "B3"];
            ws.Cells[3, 2] = "NIK";

            Microsoft.Office.Interop.Excel.Range rangeNama = ws.Range["C3", "C3"];
            ws.Cells[3, 3] = "NAMA DOSEN";

            Microsoft.Office.Interop.Excel.Range rangeNamaProgram = ws.Range["D3", "D3"];
            ws.Cells[3, 4] = "NAMA PROGRAM";

            Microsoft.Office.Interop.Excel.Range rangeKategoriDosen = ws.Range["E3", "E3"];
            ws.Cells[3, 5] = "KATEGORI DOSEN";

            Microsoft.Office.Interop.Excel.Range rangeKode = ws.Range["F3", "F3"];
            ws.Cells[3, 6] = "KODE";

            Microsoft.Office.Interop.Excel.Range rangeMataKuliah = ws.Range["G3", "G3"];
            ws.Cells[3, 7] = "MATA KULIAH";

            Microsoft.Office.Interop.Excel.Range rangeJenisMK = ws.Range["H3", "H3"];
            ws.Cells[3, 8] = "JENIS MATA KULIAH";

            Microsoft.Office.Interop.Excel.Range rangeJumlahKelas = ws.Range["I3", "I3"];
            ws.Cells[3, 9] = "JUMLAH KELAS";

            Microsoft.Office.Interop.Excel.Range rangeSksTotal = ws.Range["J3", "J3"];
            ws.Cells[3, 10] = "SKS TOTAL";

            Microsoft.Office.Interop.Excel.Range rangeSksBeban = ws.Range["K3", "K3"];
            ws.Cells[3, 11] = "BEBAN SKS";

            Microsoft.Office.Interop.Excel.Range rangeSksBayar = ws.Range["L3", "L3"];
            ws.Cells[3, 12] = "SKS BAYAR";

            Microsoft.Office.Interop.Excel.Range rangeJmlPertemuan = ws.Range["M3", "M3"];
            ws.Cells[3, 13] = "JML. PERTEMUAN MENGAJAR";

            Microsoft.Office.Interop.Excel.Range rangePendidikan = ws.Range["N3", "N3"];
            ws.Cells[3, 14] = "PEND/GOLONGAN";

            Microsoft.Office.Interop.Excel.Range rangeHrFix = ws.Range["O3", "O3"];
            ws.Cells[3, 15] = "HR FIX/BULAN";

            Microsoft.Office.Interop.Excel.Range rangeHrVar = ws.Range["P3", "P3"];
            ws.Cells[3, 16] = "HR VAR/BULAN";

            Microsoft.Office.Interop.Excel.Range rangeHrTotal = ws.Range["Q3", "Q3"];
            ws.Cells[3, 17] = "HR TOTAL";

            Microsoft.Office.Interop.Excel.Range rangePajak = ws.Range["R3", "R3"];
            ws.Cells[3, 18] = "PAJAK";

            Microsoft.Office.Interop.Excel.Range rangeHrDiterima = ws.Range["S3", "S3"];
            ws.Cells[3, 19] = "HR DITERIMA/BULAN";

            Microsoft.Office.Interop.Excel.Range rangeNpwp = ws.Range["T3", "T3"];
            ws.Cells[3, 20] = "NPWP";

            Microsoft.Office.Interop.Excel.Range rangeRekBank = ws.Range["U3", "U3"];
            ws.Cells[3, 21] = "NO. REKENING BANK";

            Microsoft.Office.Interop.Excel.Range rangeBank = ws.Range["V3", "V3"];
            ws.Cells[3, 22] = "BANK";


            int startRow = 4;
            foreach (DataGridViewRow item in dgvHonor.Rows)
            {
                ws.Cells[startRow, 1] = startRow - 3;
                ws.Cells[startRow, 2].NumberFormat = "@";
                ws.Cells[startRow, 2] = item.Cells["NIK"].Value.ToString();
                ws.Cells[startRow, 3] = item.Cells["NamaDosen"].Value.ToString();
                ws.Cells[startRow, 4] = item.Cells["NamaProgram"].Value.ToString();
                ws.Cells[startRow, 5] = item.Cells["KategoriDosen"].Value.ToString();
                ws.Cells[startRow, 6] = item.Cells["Kode"].Value.ToString();
                ws.Cells[startRow, 7] = item.Cells["MataKuliah"].Value.ToString();
                ws.Cells[startRow, 8] = item.Cells["JenisMataKuliah"].Value.ToString();
                ws.Cells[startRow, 9] = item.Cells["JumlahKelas"].Value.ToString();
                ws.Cells[startRow, 10] = item.Cells["JumlahSksTotal"].Value.ToString();
                ws.Cells[startRow, 11] = item.Cells["BebanSks"].Value.ToString();
                ws.Cells[startRow, 12] = item.Cells["JumlahSksBayar"].Value.ToString();
                ws.Cells[startRow, 13] = item.Cells["JumlahPertemuan"].Value.ToString();
                ws.Cells[startRow, 14] = item.Cells["PendidikanGolongan"].Value.ToString();
                ws.Cells[startRow, 15] = item.Cells["HrFixPerBulan"].Value.ToString();
                ws.Cells[startRow, 16] = item.Cells["HrVarPerBulan"].Value.ToString();
                ws.Cells[startRow, 17] = item.Cells["HrTotalPerBulan"].Value.ToString();
                ws.Cells[startRow, 18] = item.Cells["PajakTotal"].Value.ToString();
                ws.Cells[startRow, 19] = item.Cells["HrDiterimaPerBulan"].Value.ToString();
                ws.Cells[startRow, 20] = item.Cells["Npwp"].Value;
                ws.Cells[startRow, 21] = item.Cells["NoRekening"].Value;
                ws.Cells[startRow, 22] = item.Cells["NamaBank"].Value;
                startRow++;
            }
            ws.Columns.AutoFit();
            xlApp.Visible = true;
            Loading(false);
        }
    }

    internal class DataHonorDosenMengajar
    {
        [DisplayName("No")]
        public int Nomor { get; set; }

        public string NIK { get; set; }

        [DisplayName("Nama Dosen")]
        public string NamaDosen { get; set; }

        [DisplayName("Nama Program")]
        public string NamaProgram { get; set; }

        [DisplayName("Kategori Dosen")]
        public string KategoriDosen { get; set; }

        public string Kode { get; set; }

        [DisplayName("Mata Kuliah")]
        public string MataKuliah { get; set; }

        [DisplayName("Jenis MK")]
        public string JenisMataKuliah { get; set; }

        [DisplayName("Jumlah Kelas")]
        public int JumlahKelas { get; set; }

        [DisplayName("SKS Total")]
        public int JumlahSksTotal { get; set; }

        [DisplayName("Beban SKS")]
        public int BebanSks { get; set; }

        [DisplayName("SKS Bayar")]
        public int JumlahSksBayar { get; set; }

        [DisplayName("Jumlah Ptm")]
        public int JumlahPertemuan { get; set; }

        [DisplayName("Pend/Golongan")]
        public string PendidikanGolongan { get; set; }

        [DisplayName("HR Var/Bulan")]
        public decimal HrVarPerBulan { get; set; }

        [DisplayName("HR Fix/Bulan")]
        public decimal HrFixPerBulan { get; set; }

        [DisplayName("Total HR/Bulan")]
        public decimal HrTotalPerBulan { get; set; }

        [DisplayName("Pajak")]
        public decimal PajakTotal { get; set; }

        [DisplayName("HR Diterima/Bulan")]
        public decimal HrDiterimaPerBulan { get; set; }

        public string Npwp { get; set; }

        [DisplayName("No. Rekening")]
        public string NoRekening { get; set; }

        [DisplayName("Nama Bank")]
        public string NamaBank { get; set; }

        [DisplayName("Kode Program")]
        public string KodeProgram { get; set; }

        [DisplayName("Id Prodi")]
        public string IdProdi { get; set; }

        [DisplayName("Kode Fakultas")]
        public string KodeFakultas { get; set; }
    }
}
