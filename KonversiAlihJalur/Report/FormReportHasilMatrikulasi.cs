#region Copyright Syncfusion Inc. 2001 - 2016
// Copyright Syncfusion Inc. 2001 - 2016. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using ApiService;
using ClassModel;
using KonversiAlihJalur.Lib;
using Microsoft.Reporting.WinForms;
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

namespace KonversiAlihJalur.Report
{
    public partial class FormReportHasilMatrikulasi : Syncfusion.Windows.Forms.MetroForm
    {
        public static string baseAddress = ConfigurationManager.AppSettings["baseAddress"];
        private string URLGetHasilMatrikulasiMhs = baseAddress + "/jurusan_api/api/alih_jalur/get_hasil_matrikulasi_mhs";
        private string URLGetDepartment = baseAddress + "/jurusan_api/api/organisasi/get_department";

        private List<Program> listProgram;
        private List<HasilMatrikulasiMhs> listHasilMatrikulasi;
        private List<Department> listDepartment;

        private WebApi webApi;
        private HttpResponseMessage response;

        private bool isPilihSemua;

        public FormReportHasilMatrikulasi()
        {
            InitializeComponent();
            webApi = new WebApi();
        }

        private void Loading(bool isLoading)
        {
            reportViewer1.Enabled = !isLoading;
            gradientPanel1.Enabled = !isLoading;
            gradientPanel2.Enabled = !isLoading;
            flowLayoutPanel1.Enabled = !isLoading;
        }

        private async void FormReportHasilMatrikulasi_Load(object sender, EventArgs e)
        {
            listProgram = Organisasi.listProgram.Where(program => program.KodeProgram == "21" || program.KodeProgram == "22").ToList();
            listProgram.Insert(0, new Program() { KodeProgram = "-", NamaProgram = "Pilih" });
            cmbProgramAlihJalur.DataSource = listProgram;
            cmbProgramAlihJalur.DisplayMember = "NamaProgram";
            cmbProgramAlihJalur.ValueMember = "KodeProgram";
            cmbProgramAlihJalur.SelectedIndex = 0;

            for (int i = DateTime.Now.Year; i > DateTime.Now.Year - 10; i--)
            {
                cmbAngkatan.Items.Add(i.ToString());
            }
            cmbAngkatan.Items.Insert(0, "Pilih");
            cmbAngkatan.SelectedIndex = 0;


            response = await webApi.Post(URLGetDepartment, string.Empty, false);
            if (response.IsSuccessStatusCode)
            {
                listDepartment = JsonConvert.DeserializeObject<List<Department>>(response.Content.ReadAsStringAsync().Result);
            }
            else
            {
                MessageBox.Show(webApi.ReturnMessage(response));
            }
        }

        private void btnTutup_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void cmbAngkatan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbAngkatan.SelectedIndex <= 0)
            {
                dgvMhs.Rows.Clear();
                return;
            }

            var dataGet = new { KodeProgram = cmbProgramAlihJalur.SelectedValue.ToString(), Angkatan = cmbAngkatan.Text };
            var jsonData = JsonConvert.SerializeObject(dataGet);

            Loading(true);
            response = await webApi.Post(URLGetHasilMatrikulasiMhs, jsonData, true);
            if (!response.IsSuccessStatusCode)
            {
                MessageBox.Show(webApi.ReturnMessage(response));
                Loading(false);
                return;
            }
            listHasilMatrikulasi = JsonConvert.DeserializeObject<List<HasilMatrikulasiMhs>>(response.Content.ReadAsStringAsync().Result);
            var tempNpm = string.Empty;
            var tempNomor = 0;
            foreach (HasilMatrikulasiMhs h in listHasilMatrikulasi)
            {
                if (tempNpm != h.NpmLama)
                {
                    tempNomor = 1;
                    h.Nomor = tempNomor;
                    tempNpm = h.NpmLama;
                }
                else
                {
                    tempNomor++;
                    h.Nomor = tempNomor;
                }
            }
            var listTemp = listHasilMatrikulasi.Select(h => new { h.NpmLama, h.Nama }).Distinct().ToList();
            dgvMhs.Rows.Clear();
            int no = 1;
            foreach (var item in listTemp)
            {
                dgvMhs.Rows.Add(no, item.NpmLama, item.Nama, false);
                no++;
            }

            Loading(false);
        }

        private void dgvMhs_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex != 2)
            {
                return;
            }
            if (dgvMhs.Rows.Count == 0)
            {
                return;
            }

            isPilihSemua = !isPilihSemua;
            foreach (DataGridViewRow row in dgvMhs.Rows)
            {
                row.Cells["Pilih"].Value = false;
                row.Cells["Pilih"].Value = !isPilihSemua;
            }
        }

        private void printSemuaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadReport(true);
        }

        private void printDipilihToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadReport(false);
        }

        private void LoadReport(bool isPilihSemua)
        {
            string kodeProdiAsal = string.Empty;
            if (cmbProgramAlihJalur.SelectedValue.ToString() == "21")
            {
                kodeProdiAsal = "11";
            }
            else if (cmbProgramAlihJalur.SelectedValue.ToString() == "22")
            {
                kodeProdiAsal = "12";
            }

            List<ReportParameter> listParams = new List<ReportParameter>();
            listParams.Add(new ReportParameter("Prodi", CultureInfo.CurrentCulture.TextInfo.ToTitleCase(listDepartment.Find(d => d.KodeDepartment == kodeProdiAsal).NamaDepartment.ToLower())));
            listParams.Add(new ReportParameter("TanggalCetak", CultureInfo.CurrentCulture.TextInfo.ToTitleCase(DateTime.Now.ToString("d MMMM yyyy", CultureInfo.GetCultureInfo("id-ID")))));
            listParams.Add(new ReportParameter("Kaprodi", listDepartment.Find(d => d.KodeDepartment == kodeProdiAsal).NamaKepala));
            listParams.Add(new ReportParameter("NikKaprodi", listDepartment.Find(d => d.KodeDepartment == kodeProdiAsal).NikKepala));
            listParams.Add(new ReportParameter("Angkatan", cmbAngkatan.Text));

            DataTable dtHasilMAtrikulasi = null;
            if (isPilihSemua)
            {
                dtHasilMAtrikulasi = CommonLib.ToDataTable(listHasilMatrikulasi);
            }
            else
            {
                List<HasilMatrikulasiMhs> listTemp = new List<HasilMatrikulasiMhs>();
                foreach (DataGridViewRow row in dgvMhs.Rows)
                {
                    if (Convert.ToBoolean(row.Cells["Pilih"].Value) == true)
                    {
                        MessageBox.Show(row.Cells["Npm"].Value.ToString());
                        foreach (HasilMatrikulasiMhs h in listHasilMatrikulasi)
                        {
                            if (h.NpmLama == row.Cells["Npm"].Value.ToString())
                            {
                                listTemp.Add(h);
                            }
                        }
                    }
                }

                dtHasilMAtrikulasi = CommonLib.ToDataTable(listTemp);
            }

            reportViewer1.LocalReport.SetParameters(listParams);
            IDataReader dr = dtHasilMAtrikulasi.CreateDataReader();
            dataSetAlihJalur.Tables["HasilMatrikulasi"].Clear();
            dataSetAlihJalur.Tables["HasilMatrikulasi"].Load(dr);
            dr.Close();
            reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
            reportViewer1.ZoomMode = ZoomMode.PageWidth;
            reportViewer1.LocalReport.Refresh();
            reportViewer1.RefreshReport();
        }
    }
}
