#region Copyright Syncfusion Inc. 2001 - 2016
// Copyright Syncfusion Inc. 2001 - 2016. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using ApiService;
using ClassModel;
using Dosen.Dialog;
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
    public partial class FormReportKesanggupanDosen : Syncfusion.Windows.Forms.MetroForm
    {
        public static string baseAddress = ConfigurationManager.AppSettings["baseAddress"];
        private string URLGetTahunAkademik = baseAddress + "/jurusan_api/api/data_support/init_tahun_akademik";
        private string URLGetSemester = baseAddress + "/jurusan_api/api/data_support/init_data_semester";
        private string URLGetDepartment = baseAddress + "/jurusan_api/api/organisasi/get_department";
        private string URLGetDosenMengajar = baseAddress + "/jurusan_api/api/pengajaran/get_dosen_mengajar_all";

        private List<Department> listDepartment;
        private List<Fakultas> listFakultas;

        private WebApi webApi;
        private HttpResponseMessage response;

        private List<AlokasiDosenMengajar> listDosenMengajarAll;

        public static DateTime dateKesanggupan;

        private bool isPreview;
        private List<AlokasiDosenAll> listPreviewAlokasiDosenAll;
        public FormReportKesanggupanDosen()
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

        private async void FormReportKesanggupanDosen_Load(object sender, EventArgs e)
        {
            Loading(true);


            response = await webApi.Post(URLGetTahunAkademik, string.Empty, false);
            if (!response.IsSuccessStatusCode)
            {
                MessageBox.Show("Data tahun akademik gagal di tampilkan");
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

            listFakultas = new List<Fakultas>(Organisasi.listFakultas);
            listFakultas.Insert(0, new Fakultas() { KodeFakultas = "-", NamaFakultas = "Pilih" });
            cmbFakultas.DataSource = listFakultas;
            cmbFakultas.DisplayMember = "NamaFakultas";
            cmbFakultas.ValueMember = "KodeFakultas";
            cmbFakultas.SelectedIndex = 0;

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


            Loading(false);
        }

        private void cetakSemuaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PreviewReport(true);
        }

        private async void cmbFakultas_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvDataDosen.Rows.Clear();
            if (cmbFakultas.SelectedIndex > 0)
            {
                var data = new { TahunAkademik = cmbTahunAkademik.Text, Semester = int.Parse(cmbSemester.SelectedValue.ToString()) };
                string jsonData = JsonConvert.SerializeObject(data);
                response = await webApi.Post(URLGetDosenMengajar, jsonData, true);
                if (!response.IsSuccessStatusCode)
                {
                    Loading(false);
                    MessageBox.Show(webApi.ReturnMessage(response));
                    return;
                }

                listDosenMengajarAll = JsonConvert.DeserializeObject<List<AlokasiDosenMengajar>>(response.Content.ReadAsStringAsync().Result);
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

                var listNikDosen = listDosenMengajarAll.Select(d => new { d.NIK, d.NamaDosen, d.KodeFakultas, d.NamaFakultas }).Distinct().OrderBy(o => o.NIK).ToList().Where(f => f.KodeFakultas == cmbFakultas.SelectedValue.ToString()).ToList();
                int i = 1;
                foreach (var item in listNikDosen)
                {
                    dgvDataDosen.Rows.Add(i, item.NIK, item.NamaDosen, false, item.KodeFakultas, item.NamaFakultas);
                    i++;
                }
            }
            dgvDataDosen.PerformLayout();
        }

        private void btnTutup_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cetakDipilihToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PreviewReport(false);
        }

        private void PreviewReport(bool isCetakSemua)
        {
            listPreviewAlokasiDosenAll = new List<AlokasiDosenAll>();

            if (dgvDataDosen.Rows.Count == 0)
            {
                return;
            }

            using (var form = new FormSetTanggalKumpulKesanggupan())
            {
                form.ShowDialog();
            }

            isPreview = true;
            dgvDataDosen.PerformLayout();
            if (isCetakSemua)
            {
                foreach (DataGridViewRow row in dgvDataDosen.Rows)
                {
                    listPreviewAlokasiDosenAll.Add(new AlokasiDosenAll()
                    {
                        NIK = row.Cells["NIK"].Value.ToString(),
                        NamaDosen = row.Cells["NamaDosen"].Value.ToString(),
                        KodeFakultas = row.Cells["KodeFakultas"].Value.ToString(),
                        NamaFakultas = row.Cells["NamaFakultas"].Value.ToString(),
                        Dekan = listDepartment.Find(d => d.KodeDepartment == row.Cells["KodeFakultas"].Value.ToString()).NamaKepala,
                        NikDekan = listDepartment.Find(d => d.KodeDepartment == row.Cells["KodeFakultas"].Value.ToString()).NikKepala,
                        NoSurat = string.Format("{0}/{1}/AMIKOM/{2}/{3}",
                                    row.Cells["No"].Value.ToString(),
                                    row.Cells["KodeFakultas"].Value.ToString(),
                                    CommonLib.NumberToRoman(DateTime.Now.Month),
                                    DateTime.Now.Year)
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
                        listPreviewAlokasiDosenAll.Add(new AlokasiDosenAll()
                        {
                            NIK = row.Cells["NIK"].Value.ToString(),
                            NamaDosen = row.Cells["NamaDosen"].Value.ToString(),
                            KodeFakultas = row.Cells["KodeFakultas"].Value.ToString(),
                            NamaFakultas = row.Cells["NamaFakultas"].Value.ToString(),
                            Dekan = listDepartment.Find(d => d.KodeDepartment == row.Cells["KodeFakultas"].Value.ToString()).NamaKepala,
                            NikDekan = listDepartment.Find(d => d.KodeDepartment == row.Cells["KodeFakultas"].Value.ToString()).NikKepala,
                            NoSurat = string.Format("{0}/{1}/AMIKOM/{2}/{3}",
                                        row.Cells["No"].Value.ToString(),
                                        row.Cells["KodeFakultas"].Value.ToString(),
                                        CommonLib.NumberToRoman(DateTime.Now.Month),
                                        DateTime.Now.Year)
                        });
                    }
                }
            }


            List<ReportParameter> listParams = new List<ReportParameter>();

            listParams.Add(new ReportParameter("TglPengesahan", CultureInfo.CurrentCulture.TextInfo.ToTitleCase(DateTime.Now.ToString("d MMMM yyyy", CultureInfo.GetCultureInfo("id-ID")))));
            listParams.Add(new ReportParameter("TglPengumpulan", CultureInfo.CurrentCulture.TextInfo.ToTitleCase(dateKesanggupan.ToString("dddd, d MMMM yyyy", CultureInfo.GetCultureInfo("id-ID")))));
            listParams.Add(new ReportParameter("Semester", LoginAccess.Semester));
            listParams.Add(new ReportParameter("TahunAkademik", LoginAccess.TahunAkademik));

            DataTable dtAlokasiDosen = CommonLib.ToDataTable(listPreviewAlokasiDosenAll);

            reportViewer1.LocalReport.SetParameters(listParams);
            IDataReader dr = dtAlokasiDosen.CreateDataReader();
            dsDosen.Tables["KesanggupanDosenMengajar"].Clear();
            dsDosen.Tables["KesanggupanDosenMengajar"].Load(dr);
            dr.Close();
            reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
            reportViewer1.ZoomMode = ZoomMode.Percent;
            reportViewer1.LocalReport.Refresh();
            reportViewer1.RefreshReport();
        }

        private void dgvDataDosen_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != 3)
            {
                return;
            }

            DataGridViewCheckBoxCell cb = dgvDataDosen.Rows[e.RowIndex].Cells["Pilih"] as DataGridViewCheckBoxCell;
            cb.Value = !bool.Parse(cb.Value.ToString());
        }

        private void saveToWordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (cmbFakultas.SelectedIndex == 0)
            {
                MessageBox.Show("Fakultas belum dipilih");
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

            string file = "KesanggupanMengajar.docx";
            Warning[] warning = null;
            string[] streamId = null;
            string mimeType = null;
            string encoding = null;
            string extension = null;

            byte[] bytes = reportViewer1.LocalReport.Render(
                "WORDOPENXML", null, out mimeType, out encoding, out extension,
                out streamId, out warning);

            using (FileStream fs = new FileStream(file, FileMode.Create))
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

            var app = new Microsoft.Office.Interop.Word.Application();
            if (app == null)
            {
                MessageBox.Show("Word could not be started. Check that your office installation and project references are correct.");
                return;
            }

            try
            {
                Loading(true); object missObj = System.Reflection.Missing.Value;
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
                        var namaDosen = listPreviewAlokasiDosenAll[currentPageIndex - 1].NamaDosen;
                        var namaFakultas = listPreviewAlokasiDosenAll[currentPageIndex - 1].KodeFakultas;
                        Directory.CreateDirectory(pathSave + @"\" + namaDosen);
                        doc2.SaveAs(pathSave + "/" + namaDosen + "/" + namaDosen + "(" + KodeFakultas + ")-KesanggupanMengajar.docx");
                    }
                }

                System.Diagnostics.Process.Start("explorer.exe", pathSave);
                app.Quit();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Loading(false);
            }
            Loading(false);
        }

        private void saveToPDFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbFakultas.SelectedIndex == 0)
                {
                    MessageBox.Show("Fakultas belum dipilih");
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

                string filename = "KesanggupanMengajar.pdf";
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
                foreach (var item in listPreviewAlokasiDosenAll)
                {
                    PdfDocument output = new PdfDocument();
                    output.Version = inputDocument.Version;
                    output.Info.Title = item.NamaDosen + " (" + item.KodeFakultas + ")";
                    output.Info.Creator = inputDocument.Info.Creator;

                    output.AddPage(inputDocument.Pages[i]);
                    Directory.CreateDirectory(path + @"\" + item.NamaDosen);
                    output.Save(path + "/" + item.NamaDosen + "/" + item.NamaDosen + "(" + item.KodeFakultas + ")-KesanggupanMengajar.pdf");
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

    class AlokasiDosenAll
    {
        public string NIK { get; set; }
        public string NamaDosen { get; set; }
        public string KodeFakultas { get; set; }
        public string NamaFakultas { get; set; }
        public string Dekan { get; set; }
        public string NikDekan { get; set; }
        public string Jenjang { get; set; }
        public string NoSurat { get; set; }
        public string KodeKelas { get; set; }
        public string IdProdi { get; set; }
        public string NamaProdi { get; set; }
        public string KodeProgramReguler { get; set; }
        public string KodeProgram { get; set; }
        public string NamaProgram { get; set; }
    }
}
