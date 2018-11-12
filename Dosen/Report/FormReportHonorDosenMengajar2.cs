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
        private string URLGethonorDosenRemidial = baseAddress + "/jurusan_api/api/dosen/get_honor_dosen_remidial";

        private WebApi webApi;
        private HttpResponseMessage response;

        private List<Fakultas> listFakultas;
        private List<Prodi> listProdi;
        private List<Program> listProgram;
        private List<HonorMengajarDosen> listHonorDosenMengajar;
        private List<DataHonorDosenMengajar> listDataHonorDosenMengajar;
        private List<HonorDosenRemidial> listHonorRemidial;
        private List<HonorDosenRemidial> listDataHonorRemidial;

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

            dgvHonor.Rows.Clear();
            rbChecked(sender, e);
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
            }
        }

        private void btnTutup_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async Task LoadHonorRemidial(string kodeFakultas, string kodeProdi, string kodeProgram)
        {
            Loading(true);

            var getData = new { TahunAkademik = cmbTahunAkademik.Text, Semester = cmbSemester.SelectedValue.ToString() };
            var jsonData = JsonConvert.SerializeObject(getData);
            response = await webApi.Post(URLGethonorDosenRemidial, jsonData, true);
            if (!response.IsSuccessStatusCode)
            {
                MessageBox.Show(webApi.ReturnMessage(response));
                Loading(false);
                return;
            }
            listHonorRemidial = JsonConvert.DeserializeObject<List<HonorDosenRemidial>>(response.Content.ReadAsStringAsync().Result);
            listHonorRemidial.ForEach(delegate (HonorDosenRemidial hr)
            {
                hr.JenjangGolongan = string.Format("{0}/{1}", hr.JenjangPendidikan, hr.Golongan);
                //hr.HonorTotal = hr.HonorKoreksiUjian + hr.HonorSoalUjian + hr.HrKisi + hr.HrRemidial;
                hr.HonorTotal = hr.HonorKoreksiUjian + hr.HonorSoalUjian + hr.HrKisi;
            });
            dgvHonorRemidial.Columns.Clear();
            listDataHonorRemidial = listHonorRemidial;

            if(!string.IsNullOrWhiteSpace(kodeProgram))
            {
                listDataHonorRemidial = listHonorRemidial.Where(i => i.KodeProgram == kodeProgram).ToList();
                dgvHonorRemidial.DataSource = listDataHonorRemidial;
            }
            else if (!string.IsNullOrWhiteSpace(kodeProdi))
            {
                listDataHonorRemidial = listHonorRemidial.Where(i => i.IdProdi == kodeProdi).ToList();
                dgvHonorRemidial.DataSource = listDataHonorRemidial;
            }
            else if (!string.IsNullOrWhiteSpace(kodeFakultas))
            {
                if (kodeFakultas == "Semua")
                {
                    ;
                    dgvHonorRemidial.DataSource = listHonorRemidial;
                }
                else
                {
                    listDataHonorRemidial = listHonorRemidial.Where(hr => hr.KodeFakultas == kodeFakultas).ToList();
                    dgvHonorRemidial.DataSource = listDataHonorRemidial;
                }
            }
            dgvHonorRemidial.Columns["NIK"].Frozen = true;
            dgvHonorRemidial.Columns["NamaDosen"].Frozen = true;
            dgvHonorRemidial.Columns["NamaProgram"].Frozen = true;

            var no = 1;
            foreach (DataGridViewRow dgRow in dgvHonorRemidial.Rows)
            {
                dgRow.Cells["Nomor"].Value = no;
                no++;
            }
            Loading(false);
        }

        private async Task LoadHonorDosen(string kodeFakultas, string kodeProdi, string kodeProgram)
        {
            Loading(true);

            var getData = new { TahunAkademik = cmbTahunAkademik.Text, Semester = cmbSemester.SelectedValue.ToString() };
            var jsonData = JsonConvert.SerializeObject(getData);
            response = await webApi.Post(URLGethonorDosenMengajar, jsonData, true);
            if (!response.IsSuccessStatusCode)
            {
                MessageBox.Show(webApi.ReturnMessage(response));
                Loading(false);
                return;
            }
            listHonorDosenMengajar = JsonConvert.DeserializeObject<List<HonorMengajarDosen>>(response.Content.ReadAsStringAsync().Result);
            listDataHonorDosenMengajar = new List<DataHonorDosenMengajar>();
            dgvHonor.Columns.Clear();
            List<HonorMengajarDosen> listTemp = new List<HonorMengajarDosen>();

            listTemp = listHonorDosenMengajar;
            if (cmbKategoriDosen.SelectedIndex > 0)
            {
                listTemp = listTemp.Where(h => h.KategoriDosen == cmbKategoriDosen.Text).ToList();
            }

            var listDataFix = listTemp
                .Select(h => new { h.NIK, h.NamaDosen, h.BebanSks, h.KategoriDosen, h.NamaProgram, h.JenisMataKuliah, h.Kode, h.MataKuliah, h.SksTp, h.JenjangPendidikan, h.Golongan, h.HFix, h.HVar, h.Npwp, h.NoRekeningBank, h.NamaBank, h.KodeProgram, h.IdProdi, h.KodeFakultas })
                .Distinct()
                .ToList();
            decimal pajak = 0;
            var pertemuanPerSKs = 7;
            var tempBeban = 0;
            var viewTempBeban = 0;
            var tempNik = string.Empty;
            foreach (var h in listDataFix)
            {
                var jmlKelas = listTemp.Where(j => j.NIK == h.NIK && j.Kode == h.Kode && j.KodeProgram == h.KodeProgram && j.JenisMataKuliah == h.JenisMataKuliah).ToList().Count;
                var jmlSksTotal = jmlKelas * h.SksTp;
                if (tempNik != h.NIK)
                {
                    tempNik = h.NIK;
                    tempBeban = listTemp.Find(j => j.NIK == tempNik).BebanSks;
                }
                decimal jmlSksBayar = 0;
                if (tempBeban <= jmlSksTotal && tempBeban != 0)
                {
                    jmlSksBayar = jmlSksTotal - tempBeban;
                    viewTempBeban = tempBeban;
                }
                else if (tempBeban > jmlSksTotal)
                {
                    jmlSksBayar = 0;
                    viewTempBeban = int.Parse(jmlSksTotal.ToString());
                }
                else if (tempBeban == 0)
                {
                    jmlSksBayar = jmlSksTotal;
                    tempBeban = 0;
                    viewTempBeban = 0;
                }
                decimal jmlPertemuanMengajar = jmlSksBayar * pertemuanPerSKs;
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
                        if (cmbPeriode.SelectedIndex > 3)
                        {
                            hrVarBulan = 0;
                        }
                        else
                        {
                            hrVarBulan = ((jmlPertemuanMengajar * h.HVar) / 3) * 2;
                        }
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
                        if (cmbPeriode.SelectedIndex > 3)
                        {
                            hrVarBulan = 0;
                        }
                        else
                        {
                            hrVarBulan = ((jmlPertemuanMengajar * h.HVar) / 3);
                        }
                    }
                }
                decimal hrTotal = hrFixBulan + hrVarBulan;
                if (!string.IsNullOrWhiteSpace(h.Npwp))
                {
                    pajak = Convert.ToDecimal((0.5 * 0.05));
                }
                else
                {
                    pajak = Convert.ToDecimal((0.5 * 0.06));
                }
                var pajakTotal = hrTotal * pajak;
                var hrDiterima = hrTotal - pajakTotal;
                DataHonorDosenMengajar d = new DataHonorDosenMengajar();
                d.NIK = h.NIK;
                d.NamaDosen = h.NamaDosen;
                d.NamaProgram = h.NamaProgram;
                d.KategoriDosen = h.KategoriDosen.Replace("Dosen", "");
                d.Kode = h.Kode;
                d.MataKuliah = h.MataKuliah;
                d.JenisMataKuliah = string.Format("{0}{1}", h.SksTp, h.JenisMataKuliah);
                d.JumlahKelas = jmlKelas;
                d.JumlahSksTotal = jmlSksTotal;
                d.BebanSks = viewTempBeban;
                d.JumlahSksBayar = jmlSksBayar;
                d.JumlahPertemuan = jmlPertemuanMengajar;
                d.PendidikanGolongan = string.Format("{0}/{1}", h.JenjangPendidikan, h.Golongan);
                if (h.KodeProgram == "60" || h.KodeProgram == "61" || h.KodeProgram == "62")
                {
                    d.HrVar = h.HVar * 2;
                    d.HrVarFormat = d.HrVar.ToString("C", CultureInfo.GetCultureInfo("id-ID"));
                }
                else
                {
                    d.HrVar = h.HVar;
                    d.HrVarFormat = d.HrVar.ToString("C", CultureInfo.GetCultureInfo("id-ID"));
                }
                d.HrVarPerBulan = hrVarBulan;
                d.HrVarPerBulanFormat = d.HrVarPerBulan.ToString("C", CultureInfo.GetCultureInfo("id-ID"));
                d.HrFix = h.HFix;
                d.HrFixFormat = h.HFix.ToString("C", CultureInfo.GetCultureInfo("id-ID"));
                d.HrFixPerBulan = hrFixBulan;
                d.HrFixPerBulanFormat = d.HrFixPerBulan.ToString("C", CultureInfo.GetCultureInfo("id-ID"));
                d.HrTotalPerBulan = hrTotal;
                d.HrTotalPerBulanFormat = d.HrTotalPerBulan.ToString("C", CultureInfo.GetCultureInfo("id-ID"));
                d.PajakTotal = pajakTotal;
                d.PajakTotalFormat = d.PajakTotal.ToString("C", CultureInfo.GetCultureInfo("id-ID"));
                d.HrDiterimaPerBulan = hrDiterima;
                d.HrDiterimaPerBulanFormat = d.HrDiterimaPerBulan.ToString("C", CultureInfo.GetCultureInfo("id-ID"));
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
            }

            DataTable dtHonor = Lib.CommonLib.ToDataTable(listDataHonorDosenMengajar);
            if (!string.IsNullOrWhiteSpace(KodeProgram))
            {
                dgvHonor.DataSource = listDataHonorDosenMengajar.Where(p => p.KodeProgram == KodeProgram).ToList();
                CekHonorKosong(listDataHonorDosenMengajar.Where(p => p.KodeProgram == KodeProgram).ToList());
            }
            else if (!string.IsNullOrWhiteSpace(IdProdi))
            {
                dgvHonor.DataSource = listDataHonorDosenMengajar.Where(i => i.IdProdi == IdProdi).ToList();
                CekHonorKosong(listDataHonorDosenMengajar.Where(i => i.IdProdi == IdProdi).ToList());
            }
            else if (!string.IsNullOrWhiteSpace(KodeFakultas))
            {
                if (KodeFakultas == "Semua")
                {
                    dgvHonor.DataSource = listDataHonorDosenMengajar;
                    CekHonorKosong(listDataHonorDosenMengajar);
                }
                else
                {
                    dgvHonor.DataSource = listDataHonorDosenMengajar.Where(f => f.KodeFakultas == KodeFakultas).ToList();
                    CekHonorKosong(listDataHonorDosenMengajar.Where(f => f.KodeFakultas == KodeFakultas).ToList());
                }
            }

            dgvHonor.Columns["KodeFakultas"].Visible = false;
            dgvHonor.Columns["IdProdi"].Visible = false;
            dgvHonor.Columns["KodeProgram"].Visible = false;
            dgvHonor.Columns["HrVarPerBulan"].Visible = false;
            dgvHonor.Columns["HrFixPerBulan"].Visible = false;
            dgvHonor.Columns["HrVar"].Visible = false;
            dgvHonor.Columns["HrFix"].Visible = false;
            dgvHonor.Columns["HrTotalPerBulan"].Visible = false;
            dgvHonor.Columns["PajakTotal"].Visible = false;
            dgvHonor.Columns["HrDiterimaPerBulan"].Visible = false;
            dgvHonor.Columns["Npwp"].Visible = false;
            dgvHonor.Columns["NoRekening"].Visible = false;
            dgvHonor.Columns["NamaBank"].Visible = false;
            dgvHonor.Columns["Nomor"].Frozen = true;
            dgvHonor.Columns["NIK"].Frozen = true;
            dgvHonor.Columns["NamaDosen"].Frozen = true;

            var no = 1;
            foreach (DataGridViewRow dgRow in dgvHonor.Rows)
            {
                dgRow.Cells["Nomor"].Value = no;
                no++;
            }
            Loading(false);
        }

        private void CekHonorKosong(List<DataHonorDosenMengajar> list)
        {
            foreach (DataGridViewRow dgRow in dgvHonor.Rows)
            {
                if (list[dgRow.Index].PendidikanGolongan.Split('/')[0] == string.Empty)
                {
                    dgRow.DefaultCellStyle.BackColor = Color.LightSalmon;
                }
            }
        }

        private async void btnProses_Click(object sender, EventArgs e)
        {
            if(rbHrMengajar.Checked && (int.Parse(cmbSemester.SelectedValue.ToString()) != 1 && int.Parse(cmbSemester.SelectedValue.ToString()) != 2))
            {
                MessageBox.Show("Semester harus ganjil atau genap");
                return;
            }

            if (rbHrRemidial.Checked && (int.Parse(cmbSemester.SelectedValue.ToString()) != 7 && int.Parse(cmbSemester.SelectedValue.ToString()) != 8))
            {
                MessageBox.Show("Semester harus remidial ganjil atau remidial genap");
                return;
            }

            if (cmbTahunAkademik.SelectedIndex <= 0 || cmbSemester.SelectedIndex <= 0 || cmbFakultas.SelectedIndex <= 0)
            {
                dgvHonor.Rows.Clear();
                return;
            }
            if (cmbFakultas.SelectedIndex > 0)
            {
                KodeFakultas = cmbFakultas.SelectedValue.ToString();
            }
            if (cmbFakultas.SelectedIndex > 0 && cmbProdi.SelectedIndex > 0)
            {
                IdProdi = cmbProdi.SelectedValue.ToString();
            }
            if (cmbProgram.SelectedIndex > 0)
            {
                KodeProgram = cmbProgram.SelectedValue.ToString();
            }
            if (rbHrMengajar.Checked)
            {
                await LoadHonorDosen(KodeFakultas, IdProdi, KodeProgram);
            }
            else
            {
                await LoadHonorRemidial(KodeFakultas, IdProdi, KodeProgram);
            }
        }

        private void cmbProgram_SelectedIndexChanged(object sender, EventArgs e)
        {
            KodeProgram = null;
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (rbHrMengajar.Checked)
            {
                ExportExcelHrMengajar();
            }
            else
            {
                ExportExcelHrRemidial();
            }
        }

        private void ExportExcelHrMengajar()
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

            Microsoft.Office.Interop.Excel.Range rangeTitle = ws.get_Range("A1", "W1");
            rangeTitle.Merge();
            rangeTitle.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            ws.Cells[1, 1] = "HONOR DOSEN MENGAJAR " + string.Format("T.A. {0} {1}", cmbTahunAkademik.Text, cmbSemester.Text);
            ws.Cells[1, 1].Font.Bold = true;
            ws.Cells[1, 1].Font.Size = 14;

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
            ws.Cells[3, 15] = "HR FIX";

            Microsoft.Office.Interop.Excel.Range rangeHrFixBulan = ws.Range["P3", "P3"];
            ws.Cells[3, 16] = "HR FIX/BULAN";

            Microsoft.Office.Interop.Excel.Range rangeHrVar = ws.Range["Q3", "Q3"];
            ws.Cells[3, 17] = "HR VAR";

            Microsoft.Office.Interop.Excel.Range rangeHrVarBulan = ws.Range["R3", "R3"];
            ws.Cells[3, 18] = "HR VAR/BULAN";

            Microsoft.Office.Interop.Excel.Range rangeHrTotal = ws.Range["S3", "S3"];
            ws.Cells[3, 19] = "HR TOTAL";

            Microsoft.Office.Interop.Excel.Range rangePajak = ws.Range["T3", "T3"];
            ws.Cells[3, 20] = "PAJAK";

            Microsoft.Office.Interop.Excel.Range rangeHrDiterima = ws.Range["U3", "U3"];
            ws.Cells[3, 21] = "HR DITERIMA/BULAN";

            Microsoft.Office.Interop.Excel.Range rangeHrDiterimaTotal = ws.Range["V3", "V3"];
            ws.Cells[3, 22] = "HR DITERIMA TOTAL/BULAN";

            Microsoft.Office.Interop.Excel.Range rangeNpwp = ws.Range["W3", "W3"];
            ws.Cells[3, 23] = "NPWP";

            Microsoft.Office.Interop.Excel.Range rangeRekBank = ws.Range["X3", "X3"];
            ws.Cells[3, 24] = "NO. REKENING BANK";

            Microsoft.Office.Interop.Excel.Range rangeBank = ws.Range["Y3", "Y3"];
            ws.Cells[3, 25] = "BANK";

            Microsoft.Office.Interop.Excel.Range rangeHeader = ws.Range["A3", "W3"];
            rangeHeader.Font.Bold = true;
            //rangeHeader.Style.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            progressBar1.Style = ProgressBarStyle.Continuous;

            int startRow = 4;
            string tempNik = string.Empty;
            Microsoft.Office.Interop.Excel.Range rangeHrDiterimaTotalMerge;
            Microsoft.Office.Interop.Excel.Range rangeNpwpMerge;
            Microsoft.Office.Interop.Excel.Range rangeRekBankMerge;
            Microsoft.Office.Interop.Excel.Range rangeBankMerge;
            int tempStartMerge = 0;
            decimal hrDiterimaPerBulanTotal = 0;

            List<DataHonorDosenMengajar> listTemp = null;
            if (!string.IsNullOrWhiteSpace(KodeProgram))
            {
                listTemp = listDataHonorDosenMengajar.Where(p => p.KodeProgram == KodeProgram).ToList();
            }
            else if (!string.IsNullOrWhiteSpace(IdProdi))
            {
                listTemp = listDataHonorDosenMengajar.Where(i => i.IdProdi == IdProdi).ToList();
            }
            else if (!string.IsNullOrWhiteSpace(KodeFakultas))
            {
                if (KodeFakultas == "Semua")
                {
                    listTemp = listDataHonorDosenMengajar;
                }
                else
                {
                    listTemp = listDataHonorDosenMengajar.Where(f => f.KodeFakultas == KodeFakultas).ToList();
                }
            }

            foreach (DataHonorDosenMengajar item in listTemp)
            {
                if (tempNik != item.NIK)
                {
                    tempNik = item.NIK;
                    tempStartMerge = startRow;
                    rangeHrDiterimaTotalMerge = ws.Range["V" + tempStartMerge, "V" + tempStartMerge];
                    tempStartMerge = startRow;
                    rangeNpwpMerge = ws.Range["W" + tempStartMerge, "W" + tempStartMerge];
                    tempStartMerge = startRow;
                    rangeRekBankMerge = ws.Range["X" + tempStartMerge, "X" + tempStartMerge];
                    tempStartMerge = startRow;
                    rangeBankMerge = ws.Range["Y" + tempStartMerge, "Y" + tempStartMerge];
                    hrDiterimaPerBulanTotal = item.HrDiterimaPerBulan;
                }
                else
                {
                    rangeHrDiterimaTotalMerge = ws.Range["V" + tempStartMerge, "V" + startRow];
                    rangeHrDiterimaTotalMerge.Merge();
                    rangeNpwpMerge = ws.Range["W" + tempStartMerge, "W" + startRow];
                    rangeNpwpMerge.Merge();
                    rangeRekBankMerge = ws.Range["X" + tempStartMerge, "X" + startRow];
                    rangeRekBankMerge.Merge();
                    rangeBankMerge = ws.Range["Y" + tempStartMerge, "Y" + startRow];
                    rangeBankMerge.Merge();
                    hrDiterimaPerBulanTotal = hrDiterimaPerBulanTotal + item.HrDiterimaPerBulan;
                }
                ws.Cells[startRow, 1] = startRow - 3;
                ws.Cells[startRow, 2].NumberFormat = "@";
                ws.Cells[startRow, 2] = item.NIK;
                ws.Cells[startRow, 3] = item.NamaDosen;
                ws.Cells[startRow, 4] = item.NamaProgram;
                ws.Cells[startRow, 5] = item.KategoriDosen;
                ws.Cells[startRow, 6] = item.Kode;
                ws.Cells[startRow, 7] = item.MataKuliah;
                ws.Cells[startRow, 8] = item.JenisMataKuliah;
                ws.Cells[startRow, 9] = item.JumlahKelas;
                ws.Cells[startRow, 10] = item.JumlahSksTotal;
                ws.Cells[startRow, 11] = item.BebanSks;
                ws.Cells[startRow, 12] = item.JumlahSksBayar;
                ws.Cells[startRow, 13] = item.JumlahPertemuan;
                ws.Cells[startRow, 14] = item.PendidikanGolongan;
                ws.Cells[startRow, 15] = item.HrFix;
                ws.Cells[startRow, 16] = item.HrFixPerBulan;
                ws.Cells[startRow, 17] = item.HrVar;
                ws.Cells[startRow, 18] = item.HrVarPerBulan;
                ws.Cells[startRow, 19] = item.HrTotalPerBulan;
                ws.Cells[startRow, 20] = item.PajakTotal;
                ws.Cells[startRow, 21] = item.HrDiterimaPerBulan;
                ws.Cells[tempStartMerge, 22] = hrDiterimaPerBulanTotal;
                ws.Cells[startRow, 23] = item.Npwp;
                ws.Cells[startRow, 23].NumberFormat = "@";
                ws.Cells[startRow, 24] = item.NoRekening;
                ws.Cells[startRow, 24].NumberFormat = "@";
                ws.Cells[startRow, 25] = item.NamaBank;
                startRow++;
                progressBar1.Value = (int)(((double.Parse((startRow - 4).ToString())) / double.Parse(listDataHonorDosenMengajar.Count.ToString())) * 100);
            }

            //Microsoft.Office.Interop.Excel.Range rangeBorder = ws.Range["A3", "W" + --startRow];
            //Microsoft.Office.Interop.Excel.Borders borders = rangeBorder.Borders;
            //borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;

            ws.Columns.AutoFit();
            xlApp.Visible = true;
            progressBar1.Style = ProgressBarStyle.Marquee;
            Loading(false);
        }

        private void ExportExcelHrRemidial()
        {
            if (listDataHonorRemidial == null || dgvHonorRemidial.Rows.Count == 0)
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

            progressBar1.Style = ProgressBarStyle.Continuous;

            Microsoft.Office.Interop.Excel.Range rangeTitle = ws.get_Range("A1", "P1");
            rangeTitle.Merge();
            rangeTitle.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            ws.Cells[1, 1] = "HONOR DOSEN REMIDIAL " + string.Format("T.A. {0} {1}", cmbTahunAkademik.Text, cmbSemester.Text);
            ws.Cells[1, 1].Font.Bold = true;
            ws.Cells[1, 1].Font.Size = 14;

            Microsoft.Office.Interop.Excel.Range rangeNomor = ws.Range["A3", "A3"];
            ws.Cells[3, 1] = "NO";

            Microsoft.Office.Interop.Excel.Range rangeNamaProgram = ws.Range["B3", "B3"];
            ws.Cells[3, 2] = "NAMA PROGRAM";

            Microsoft.Office.Interop.Excel.Range rangeNik = ws.Range["C3", "C3"];
            ws.Cells[3, 3] = "NIK";

            Microsoft.Office.Interop.Excel.Range rangeNama = ws.Range["D3", "D3"];
            ws.Cells[3, 4] = "NAMA DOSEN";

            Microsoft.Office.Interop.Excel.Range rangeSemester = ws.Range["E3", "E3"];
            ws.Cells[3, 5] = "SEMESTER";

            Microsoft.Office.Interop.Excel.Range rangeJenjang = ws.Range["F3", "F3"];
            ws.Cells[3, 6] = "JENJANG";

            Microsoft.Office.Interop.Excel.Range rangeKode = ws.Range["G3", "G3"];
            ws.Cells[3, 7] = "KODE";

            Microsoft.Office.Interop.Excel.Range rangeMataKuliah = ws.Range["H3", "H3"];
            ws.Cells[3, 8] = "MATA KULIAH";

            Microsoft.Office.Interop.Excel.Range rangeSks = ws.Range["I3", "I3"];
            ws.Cells[3, 9] = "SKS";

            Microsoft.Office.Interop.Excel.Range rangeJumlahPeserta = ws.Range["J3", "J3"];
            ws.Cells[3, 10] = "JUMLAH PESERTA UJIAN";

            Microsoft.Office.Interop.Excel.Range rangePendGol = ws.Range["K3", "K3"];
            ws.Cells[3, 11] = "PEND/GOL";

            Microsoft.Office.Interop.Excel.Range rangeHrStandar = ws.Range["L3", "L3"];
            ws.Cells[3, 12] = "HR STANDAR";

            Microsoft.Office.Interop.Excel.Range rangeHrKisi = ws.Range["M3", "M3"];
            ws.Cells[3, 13] = "HR KISI-KISI";

            Microsoft.Office.Interop.Excel.Range rangeHrSoal = ws.Range["N3", "N3"];
            ws.Cells[3, 14] = "HR SOAL";

            Microsoft.Office.Interop.Excel.Range rangeHrKoreksi = ws.Range["O3", "O3"];
            ws.Cells[3, 15] = "HR KOREKSI";

            Microsoft.Office.Interop.Excel.Range rangeHrTotal = ws.Range["P3", "P3"];
            ws.Cells[3, 16] = "HR TOTAL";

            int startRow = 4;
            foreach (var item in listDataHonorRemidial)
            {
                ws.Cells[startRow, 1] = startRow - 3;
                ws.Cells[startRow, 2] = item.NamaProgram;
                ws.Cells[startRow, 3].NumberFormat = "@";
                ws.Cells[startRow, 3] = item.NIK;
                ws.Cells[startRow, 4] = item.NamaDosen;
                ws.Cells[startRow, 5] = item.Semester;
                ws.Cells[startRow, 6] = item.Jenjang;
                ws.Cells[startRow, 7] = item.Kode;
                ws.Cells[startRow, 8] = item.MataKuliah;
                ws.Cells[startRow, 9] = item.Sks;
                ws.Cells[startRow, 10] = item.JumlahPesertaUjian;
                ws.Cells[startRow, 11] = item.JenjangGolongan;
                ws.Cells[startRow, 12] = item.HrRemidial;
                ws.Cells[startRow, 13] = item.HrKisi;
                ws.Cells[startRow, 14] = item.HonorSoalUjian;
                ws.Cells[startRow, 15] = item.HonorKoreksiUjian;
                ws.Cells[startRow, 16] = item.HonorTotal;
                startRow++;
                progressBar1.Value = (int)(((double.Parse((startRow - 4).ToString())) / double.Parse(listHonorRemidial.Count.ToString())) * 100);
            }
            ws.Columns.AutoFit();
            xlApp.Visible = true;
            progressBar1.Style = ProgressBarStyle.Marquee;
            Loading(false);

        }

        private void rbChecked(object sender, EventArgs e)
        {
            if (cmbProgram.DataSource != null)
            {
                cmbProgram.SelectedIndex = 0;
            }
            if (rbHrMengajar.Checked)
            {
                //cmbProgram.Enabled = true;
                dgvHonor.Visible = true;
                dgvHonorRemidial.Visible = false;
            }
            else
            {
                //cmbProgram.Enabled = false;
                dgvHonor.Visible = false;
                dgvHonorRemidial.Visible = true;
            }
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
        public decimal JumlahSksBayar { get; set; }

        [DisplayName("Jumlah Ptm")]
        public decimal JumlahPertemuan { get; set; }

        [DisplayName("Pend/Golongan")]
        public string PendidikanGolongan { get; set; }

        public decimal HrVar { get; set; }
        [DisplayName("Hr Var")]
        public string HrVarFormat { get; set; }
        public decimal HrVarPerBulan { get; set; }
        [DisplayName("HR Var/Bulan")]
        public string HrVarPerBulanFormat { get; set; }

        public decimal HrFix { get; set; }
        [DisplayName("HR Fix")]
        public string HrFixFormat { get; set; }
        public decimal HrFixPerBulan { get; set; }
        [DisplayName("HR Fix/Bulan")]
        public string HrFixPerBulanFormat { get; set; }

        public decimal HrTotalPerBulan { get; set; }
        [DisplayName("Total HR/Bulan")]
        public string HrTotalPerBulanFormat { get; set; }

        public decimal PajakTotal { get; set; }
        [DisplayName("Pajak")]
        public string PajakTotalFormat { get; set; }

        public decimal HrDiterimaPerBulan { get; set; }
        [DisplayName("HR Diterima/Bulan")]
        public string HrDiterimaPerBulanFormat { get; set; }

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
