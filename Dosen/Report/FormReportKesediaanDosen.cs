#region Copyright Syncfusion Inc. 2001 - 2016
// Copyright Syncfusion Inc. 2001 - 2016. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using ApiService;
using ClassModel;
using Dosen.Lib;
using Microsoft.Reporting.WinForms;
using Newtonsoft.Json;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Windows.Forms;

namespace Dosen.Report
{
    public partial class FormReportKesediaanDosen : Syncfusion.Windows.Forms.MetroForm
    {
        public static string baseAddress = ConfigurationManager.AppSettings["baseAddress"];
        private string URLGetDepartment = baseAddress + "/jurusan_api/api/organisasi/get_department";
        private string URLGetDosenMengajar = baseAddress + "/jurusan_api/api/pengajaran/get_dosen_mengajar_all";

        private List<Department> listDepartment;
        private List<Fakultas> listFakultas;
        private List<Prodi> listProdi;
        private List<Program> listProgram;

        private WebApi webApi;
        private HttpResponseMessage response;

        private List<KesanggupanMengajar> listDosenMengajarAll;
        private List<KesediaanDosen> listPreviewKesediaanDosen;

        public string kodeProgramDipilih;
        public string idProdiDipilih;

        private bool isPreview;
        private bool isDipilihSemua;
        public FormReportKesediaanDosen()
        {
            InitializeComponent();
            webApi = new WebApi();
        }

        private void Loading(bool isLoading)
        {
            reportViewer1.Enabled = !isLoading;
            gradientPanel1.Enabled = !isLoading;
            flowLayoutPanel1.Enabled = !isLoading;

            progressBar1.Visible = isLoading;
        }

        private async void FormReportKesediaanDosen_Load(object sender, EventArgs e)
        {
            listFakultas = new List<Fakultas>(Organisasi.listFakultas);
            listFakultas.Insert(0, new Fakultas() { KodeFakultas = "-", NamaFakultas = "Pilih" });
            listFakultas.Insert(1, new Fakultas() { KodeFakultas = "-", NamaFakultas = "Semua Fakultas" });
            cmbFakultas.DataSource = listFakultas;
            cmbFakultas.DisplayMember = "NamaFakultas";
            cmbFakultas.ValueMember = "KodeFakultas";
            cmbFakultas.SelectedIndex = 0;

            Loading(true);
            response = await webApi.Post(URLGetDepartment, string.Empty, false);
            if (response.IsSuccessStatusCode)
            {
                listDepartment = JsonConvert.DeserializeObject<List<Department>>(response.Content.ReadAsStringAsync().Result);
            }
            else
            {
                Loading(false);
                MessageBox.Show(webApi.ReturnMessage(response));
                return;
            }

            response = await webApi.Post(URLGetDepartment, string.Empty, false);
            if (response.IsSuccessStatusCode)
            {
                listDepartment = JsonConvert.DeserializeObject<List<Department>>(response.Content.ReadAsStringAsync().Result);
            }
            else
            {
                Loading(false);
                MessageBox.Show(webApi.ReturnMessage(response));
                return;
            }

            var data = new { TahunAkademik = LoginAccess.TahunAkademik, Semester = LoginAccess.KodeSemester };
            string jsonData = JsonConvert.SerializeObject(data);

            response = await webApi.Post(URLGetDosenMengajar, jsonData, true);
            if (!response.IsSuccessStatusCode)
            {
                Loading(false);
                MessageBox.Show(webApi.ReturnMessage(response));
                return;
            }

            listDosenMengajarAll = JsonConvert.DeserializeObject<List<KesanggupanMengajar>>(response.Content.ReadAsStringAsync().Result);
            if (listDosenMengajarAll == null)
            {
                Loading(false);
                MessageBox.Show("Dosen belum teralokasi oleh prodi");
                return;
            }
            if (listDosenMengajarAll.Count == 0)
            {
                Loading(false);
                MessageBox.Show("Dosen belum teralokasi oleh prodi");
                return;
            }
            Loading(false);
        }

        private void btnTutup_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cmbFakultas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbFakultas.SelectedIndex > 0)
            {
                if (cmbFakultas.SelectedIndex == 1)
                {
                    dgvDataDosen.Rows.Clear();
                    var listNikDosen = listDosenMengajarAll
                        .Select(x => new { x.NIK, x.NamaProgram, x.NamaDosen, x.Kode, x.KodeKelas, x.MataKuliah, x.Jenjang, x.JenisMataKuliah, x.SksTeori, x.SksTotal, x.SksPraktikum, x.IdProdi, x.KodeProgram })
                        .Select(y => new { y.NIK, y.NamaProgram, y.NamaDosen, y.Kode, y.KodeKelas, y.MataKuliah, y.Jenjang, JenisMataKuliah = (y.SksPraktikum == 0 ? "T" : y.SksTeori == 0 ? "P" : "TP"), y.SksTeori, y.SksPraktikum, y.SksTotal, y.IdProdi, y.KodeProgram })
                        .Distinct()//.Where(z => z.KodeProgram == kodeProgramDipilih)
                        .OrderBy(o => o.NamaDosen);

                    int i = 1;
                    foreach (var item in listNikDosen)
                    {
                        int countKelas = listDosenMengajarAll.Where(w => w.NIK == item.NIK && w.Kode == item.Kode && w.Jenjang == item.Jenjang && w.KodeProgram == item.KodeProgram && w.KodeKelas == item.KodeKelas && w.JenisMataKuliah == item.JenisMataKuliah).ToList().Count;
                        int sks = item.SksPraktikum == 0 ? item.SksTeori : item.SksPraktikum;
                        dgvDataDosen.Rows.Add(i, item.NamaProgram, item.NIK, item.NamaDosen, item.MataKuliah, false, item.Jenjang, item.Kode, sks, countKelas, item.JenisMataKuliah, item.KodeKelas);
                        i++;
                    }
                    isPreview = false;
                    dgvDataDosen.PerformLayout();

                }
                else
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

        }

        private void cmbProdi_SelectedIndexChanged(object sender, EventArgs e)
        {
            kodeProgramDipilih = null;
            idProdiDipilih = null;
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
            if (cmbProgram.SelectedIndex <= 0)
            {
                dgvDataDosen.Rows.Clear();
                return;
            }

            kodeProgramDipilih = cmbProgram.SelectedValue.ToString();
            idProdiDipilih = cmbProdi.SelectedValue.ToString();


            dgvDataDosen.Rows.Clear();
            var listNikDosen = listDosenMengajarAll
                .Select(x => new { x.NIK, x.NamaProgram, x.NamaDosen, x.Kode, x.KodeKelas, x.MataKuliah, x.Jenjang, x.JenisMataKuliah, x.SksTeori, x.SksTotal, x.SksPraktikum, x.IdProdi, x.KodeProgram })
                .Select(y => new { y.NIK, y.NamaProgram, y.NamaDosen, y.Kode, y.KodeKelas, y.MataKuliah, y.Jenjang, JenisMataKuliah = (y.SksPraktikum == 0 ? "T" : y.SksTeori == 0 ? "P" : "TP"), y.SksTeori, y.SksPraktikum, y.SksTotal, y.IdProdi, y.KodeProgram })
                .Distinct().Where(z => z.KodeProgram == kodeProgramDipilih)
                .OrderBy(o => o.NamaDosen);

            int i = 1;
            foreach (var item in listNikDosen)
            {
                int countKelas = listDosenMengajarAll.Where(w => w.NIK == item.NIK && w.Kode == item.Kode && w.Jenjang == item.Jenjang && w.KodeProgram == kodeProgramDipilih && w.KodeKelas == item.KodeKelas && w.JenisMataKuliah == item.JenisMataKuliah).ToList().Count;
                int sks = item.SksPraktikum == 0 ? item.SksTeori : item.SksPraktikum;
                dgvDataDosen.Rows.Add(i, item.NamaProgram, item.NIK, item.NamaDosen, item.MataKuliah, false, item.Jenjang, item.Kode, sks, countKelas, item.JenisMataKuliah, item.KodeKelas);
                i++;
            }
            isPreview = false;
            dgvDataDosen.PerformLayout();
        }

        private void cetakSemuaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (cmbProgram.SelectedIndex > 0 && dgvDataDosen.Rows.Count > 0)
            {
                PreviewReport(true);
                isDipilihSemua = true;
            }
            else if (cmbFakultas.SelectedIndex > 0 && dgvDataDosen.Rows.Count > 0)
            {
                PreviewReport(true);
                isDipilihSemua = true;
            }
        }

        private void cetakDipilihToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (cmbProgram.SelectedIndex > 0 && dgvDataDosen.Rows.Count > 0)
            {
                PreviewReport(false);
                isDipilihSemua = false;
            }
            else if (cmbFakultas.SelectedIndex > 0 && dgvDataDosen.Rows.Count > 0)
            {
                PreviewReport(false);
                isDipilihSemua = false;
            }
        }

        private void PreviewReport(bool isCetakSemua)
        {
            listPreviewKesediaanDosen = new List<KesediaanDosen>();

            if (dgvDataDosen.Rows.Count == 0)
            {
                return;
            }

            isPreview = true;
            dgvDataDosen.PerformLayout();
            if (isCetakSemua)
            {
                foreach (DataGridViewRow row in dgvDataDosen.Rows)
                {
                    listPreviewKesediaanDosen.Add(new KesediaanDosen()
                    {
                        NIK = row.Cells["NIK"].Value.ToString(),
                        NamaDosen = row.Cells["NamaDosen"].Value.ToString(),
                        Jenjang = row.Cells["Jenjang"].Value.ToString(),
                        MataKuliah = row.Cells["MataKuliah"].Value.ToString(),
                        Kode = row.Cells["Kode"].Value.ToString(),
                        Sks = int.Parse(row.Cells["Sks"].Value.ToString()),
                        JenisMataKuliah = row.Cells["JenisKuliah"].Value.ToString(),
                        JumlahKelas = int.Parse(row.Cells["Jumlahkelas"].Value.ToString()),
                        TotalSks = int.Parse(row.Cells["Sks"].Value.ToString()) * int.Parse(row.Cells["Jumlahkelas"].Value.ToString()),
                        NamaProgram = row.Cells["NamaProgram"].Value.ToString(),
                        KodeKelas = row.Cells["KodeKelas"].Value.ToString()
                    });
                }
            }
            else
            {
                foreach (DataGridViewRow row in dgvDataDosen.Rows)
                {
                    DataGridViewCheckBoxCell cb = row.Cells["Pilih"] as DataGridViewCheckBoxCell;
                    if (bool.Parse(cb.Value.ToString()))
                    {
                        listPreviewKesediaanDosen.Add(new KesediaanDosen()
                        {
                            NIK = row.Cells["NIK"].Value.ToString(),
                            NamaDosen = row.Cells["NamaDosen"].Value.ToString(),
                            Jenjang = row.Cells["Jenjang"].Value.ToString(),
                            MataKuliah = row.Cells["MataKuliah"].Value.ToString(),
                            Kode = row.Cells["Kode"].Value.ToString(),
                            Sks = int.Parse(row.Cells["Sks"].Value.ToString()),
                            JenisMataKuliah = row.Cells["JenisKuliah"].Value.ToString(),
                            JumlahKelas = int.Parse(row.Cells["Jumlahkelas"].Value.ToString()),
                            TotalSks = int.Parse(row.Cells["Sks"].Value.ToString()) * int.Parse(row.Cells["Jumlahkelas"].Value.ToString()),
                            NamaProgram = row.Cells["NamaProgram"].Value.ToString(),
                            KodeKelas = row.Cells["KodeKelas"].Value.ToString()
                        });
                    }
                }
            }

            //menambah halaman kosong di halaman terakhir
            listPreviewKesediaanDosen.Add(new KesediaanDosen());

            List<ReportParameter> listParams = new List<ReportParameter>();

            listParams.Add(new ReportParameter("TglPengesahan", CultureInfo.CurrentCulture.TextInfo.ToTitleCase(DateTime.Now.ToString("d MMMM yyyy", CultureInfo.GetCultureInfo("id-ID")))));
            listParams.Add(new ReportParameter("Semester", LoginAccess.Semester));
            listParams.Add(new ReportParameter("TahunAkademik", LoginAccess.TahunAkademik));
            listParams.Add(new ReportParameter("Prodi", cmbProdi.Text));
            listParams.Add(new ReportParameter("Program", cmbProgram.Text));

            DataTable dtAlokasiDosen = CommonLib.ToDataTable(listPreviewKesediaanDosen);

            reportViewer1.LocalReport.SetParameters(listParams);
            IDataReader dr = dtAlokasiDosen.CreateDataReader();
            dsDosen.Tables["KesediaanDosenMengajar"].Clear();
            dsDosen.Tables["KesediaanDosenMengajar"].Load(dr);
            dr.Close();
            reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
            reportViewer1.ZoomMode = ZoomMode.Percent;
            reportViewer1.LocalReport.Refresh();
            reportViewer1.RefreshReport();
        }

        private void dgvDataDosen_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != 5)
            {
                return;
            }

            DataGridViewCheckBoxCell cb = dgvDataDosen.Rows[e.RowIndex].Cells["Pilih"] as DataGridViewCheckBoxCell;
            cb.Value = !bool.Parse(cb.Value.ToString());
        }

        private void saveToWordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (cmbProgram.SelectedIndex == 0)
            {
                MessageBox.Show("Program belum dipilih");
                return;
            }

            if (!isPreview)
            {
                MessageBox.Show("Report harus di preview dahulu");
                return;
            }

            DialogResult result = MessageBox.Show("Report akan di konversi ke file Word terpisah untuk setiap halaman. Lanjutkan?", "Export PDF", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.Cancel)
                return;

            string file = "KesediaanMengajar.docx";
            Warning[] warning = null;
            string[] streamId = null;
            string mimeType = null;
            string encoding = null;
            string extension = null;

            byte[] bytes = reportViewer1.LocalReport.Render(
                "WORDOPENXML", null, out mimeType, out encoding, out extension,
                out streamId, out warning);

            using (FileStream fs = File.Create(@Application.StartupPath + "/" + file))
            {
                fs.Write(bytes, 0, bytes.Length);
            }

            string pathsave = string.Empty;
            if (folderBrowserDialog1.ShowDialog(this) == DialogResult.OK)
            {
                pathsave = folderBrowserDialog1.SelectedPath;
            }
            else
            {
                return;
            }

            var app = new Microsoft.Office.Interop.Word.Application();
            if (app == null)
            {
                MessageBox.Show("Word could not be started. Check that your office installation and project references are correct.");
                return;
            }

            try
            {
                Loading(true);
                object missObj = System.Reflection.Missing.Value;
                app.Visible = false;

                string filename = @Application.StartupPath + "/" + file;
                var doc = app.Documents.Open(@Application.StartupPath + "/" + file);
                int pageCount = doc.Range().Information[Microsoft.Office.Interop.Word.WdInformation.wdNumberOfPagesInDocument];
                int pageStart = 0;
                for (int currentPageIndex = 1; currentPageIndex <= pageCount; currentPageIndex++)
                {
                    var page = doc.Range(pageStart);
                    if (currentPageIndex < pageCount)
                    {
                        page.End = page.GoTo(
                        What: Microsoft.Office.Interop.Word.WdGoToItem.wdGoToPage,
                        Which: Microsoft.Office.Interop.Word.WdGoToDirection.wdGoToFirst,
                        Count: currentPageIndex + 1).Start - 1;

                        pageStart = page.End + 1;
                        page.Copy();
                        var doc2 = app.Documents.Add();
                        doc2.PageSetup.BottomMargin = 0;
                        doc2.PageSetup.TopMargin = 0;
                        doc2.PageSetup.LeftMargin = 0;
                        doc2.PageSetup.RightMargin = 0;
                        doc2.Range().Paste();
                        var namaDosen = listPreviewKesediaanDosen[currentPageIndex - 1].NamaDosen;
                        var kode = listPreviewKesediaanDosen[currentPageIndex - 1].Kode;
                        var sks = listPreviewKesediaanDosen[currentPageIndex - 1].Sks;
                        var jenisKuliah = listPreviewKesediaanDosen[currentPageIndex - 1].JenisMataKuliah;
                        var namaProgram = listPreviewKesediaanDosen[currentPageIndex - 1].NamaProgram;
                        var kodeKelas = listPreviewKesediaanDosen[currentPageIndex - 1].KodeKelas;
                        Directory.CreateDirectory(pathsave + @"\" + namaDosen);
                        doc2.SaveAs(pathsave + "/" + NamaDosen + "/" + namaDosen + "(" + kode + "-" + sks + jenisKuliah + "-" + namaProgram + ")-KEsediaanMengajar.docx");
                    }
                }

                System.Diagnostics.Process.Start("explorer.exe", @pathsave);
                app.Quit();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                if (app != null)
                    app.Quit();
                Loading(false);
            }
            Loading(false);
        }


        private void saveToPDFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbProgram.SelectedIndex == 0)
                {
                    MessageBox.Show("Program belum dipilih");
                    return;
                }

                if (!isPreview)
                {
                    MessageBox.Show("Report harus di preview dahulu");
                    return;
                }

                DialogResult result = MessageBox.Show("Report akan di konversi ke file PDF terpisah untuk setiap halaman. Lanjutkan?", "Export PDF", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result == DialogResult.Cancel)
                    return;

                string filename = "KesediaanMengajar.pdf";
                Warning[] warning = null;
                string[] streamId = null;
                string mimeType = null;
                string encoding = null;
                string extension = null;

                byte[] bytes = reportViewer1.LocalReport.Render(
                    "PDF", null, out mimeType, out encoding, out extension,
                    out streamId, out warning);

                using (FileStream fs = new FileStream(filename, FileMode.Create))
                {
                    fs.Write(bytes, 0, bytes.Length);
                }

                string pathSave = string.Empty;
                if (folderBrowserDialog1.ShowDialog(this) == DialogResult.OK)
                {
                    pathSave = folderBrowserDialog1.SelectedPath;
                }
                else
                {
                    return;
                }
                Loading(true);
                PdfDocument inputDocument = PdfReader.Open(filename, PdfDocumentOpenMode.Import);
                string path = pathSave.ToString();
                int i = 0;
                foreach (var item in listPreviewKesediaanDosen)
                {
                    PdfDocument output = new PdfDocument();
                    output.Version = inputDocument.Version;
                    output.Info.Title = item.NamaDosen + " (" + item.Kode + "-" + item.Sks + item.JenisMataKuliah + "-" + item.NamaProgram + ")";
                    output.Info.Creator = inputDocument.Info.Creator;

                    output.AddPage(inputDocument.Pages[i]);
                    Directory.CreateDirectory(path + @"\" + item.NamaDosen);
                    output.Save(path + "/" + item.NamaDosen + "/" + item.NamaDosen + " (" + item.Kode + "-" + item.Sks + item.JenisMataKuliah + "-" + item.NamaProgram + ")-KesediaanMengajar.pdf");
                    i++;
                }
                System.Diagnostics.Process.Start("explorer.exe", @path);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Loading(false);
            }
            Loading(false);
        }
    }

    class KesediaanDosen : AlokasiDosenAll
    {
        public int JumlahKelas { get; set; }
        public int TotalSks { get; set; }
        public string Kode { get; set; }
        public string MataKuliah { get; set; }
        public int Sks { get; set; }
        public string JenisMataKuliah { get; set; }
    }
}
