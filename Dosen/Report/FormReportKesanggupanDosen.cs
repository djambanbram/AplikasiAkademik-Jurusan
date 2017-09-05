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
    public partial class FormReportKesanggupanDosen : Syncfusion.Windows.Forms.MetroForm
    {
        public static string baseAddress = ConfigurationManager.AppSettings["baseAddress"];
        private string URLGetDepartment = baseAddress + "/jurusan_api/api/organisasi/get_department";
        private string URLGetDosenMengajar = baseAddress + "/jurusan_api/api/pengajaran/get_dosen_mengajar_all";

        private List<Department> listDepartment;
        private List<Fakultas> listFakultas;

        private WebApi webApi;
        private HttpResponseMessage response;

        private List<AlokasiDosenMengajar> listDosenMengajarAll;

        public static DateTime dateKesanggupan;

        public FormReportKesanggupanDosen()
        {
            InitializeComponent();
            webApi = new WebApi();
        }

        private async void FormReportKesanggupanDosen_Load(object sender, EventArgs e)
        {
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
                MessageBox.Show(webApi.ReturnMessage(response));
            }

            response = await webApi.Post(URLGetDepartment, string.Empty, false);
            if (response.IsSuccessStatusCode)
            {
                listDepartment = JsonConvert.DeserializeObject<List<Department>>(response.Content.ReadAsStringAsync().Result);
            }
            else
            {
                MessageBox.Show(webApi.ReturnMessage(response));
            }

            var data = new { TahunAkademik = LoginAccess.TahunAkademik, Semester = LoginAccess.KodeSemester };

            string jsonData = JsonConvert.SerializeObject(data);

            response = await webApi.Post(URLGetDosenMengajar, jsonData, true);
            if (!response.IsSuccessStatusCode)
            {
                MessageBox.Show(webApi.ReturnMessage(response));
                return;
            }

            listDosenMengajarAll = JsonConvert.DeserializeObject<List<AlokasiDosenMengajar>>(response.Content.ReadAsStringAsync().Result);
            if (listDosenMengajarAll == null)
            {
                MessageBox.Show("Dosen belum teralokasi oleh prodi");
                return;
            }
            if (listDosenMengajarAll.Count == 0)
            {
                MessageBox.Show("Dosen belum teralokasi oleh prodi");
                return;
            }
        }

        private void cetakSemuaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PreviewReport(true);
        }

        private void cmbFakultas_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvDataDosen.Rows.Clear();
            if (cmbFakultas.SelectedIndex > 0)
            {
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
            List<AlokasiDosenAll> listAlokasiDosenAll = new List<AlokasiDosenAll>();

            if (dgvDataDosen.Rows.Count == 0)
            {
                return;
            }

            using (var form = new FormSetTanggalKumpulKesanggupan())
            {
                form.ShowDialog();
            }

            dgvDataDosen.PerformLayout();
            if (isCetakSemua)
            {
                foreach (DataGridViewRow row in dgvDataDosen.Rows)
                {
                    listAlokasiDosenAll.Add(new AlokasiDosenAll()
                    {
                        NIK = row.Cells["NIK"].Value.ToString(),
                        NamaDosen = row.Cells["NamaDosen"].Value.ToString(),
                        KodeFakultas = row.Cells["KodeFakultas"].Value.ToString(),
                        NamaFakultas = row.Cells["NamaFakultas"].Value.ToString(),
                        Dekan = listDepartment.Find(d => d.KodeDepartment == row.Cells["KodeFakultas"].Value.ToString()).NamaKepala,
                        NikDekan = listDepartment.Find(d => d.KodeDepartment == row.Cells["KodeFakultas"].Value.ToString()).NikKepala,
                        NoSurat = string.Format("{0}/{1}/AMIKOM/{2}/{3}",
                                    row.Cells["NIK"].Value.ToString().Substring(row.Cells["NIK"].Value.ToString().Length - 3, 3),
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
                        listAlokasiDosenAll.Add(new AlokasiDosenAll()
                        {
                            NIK = row.Cells["NIK"].Value.ToString(),
                            NamaDosen = row.Cells["NamaDosen"].Value.ToString(),
                            KodeFakultas = row.Cells["KodeFakultas"].Value.ToString(),
                            NamaFakultas = row.Cells["NamaFakultas"].Value.ToString(),
                            Dekan = listDepartment.Find(d => d.KodeDepartment == row.Cells["KodeFakultas"].Value.ToString()).NamaKepala,
                            NikDekan = listDepartment.Find(d => d.KodeDepartment == row.Cells["KodeFakultas"].Value.ToString()).NikKepala,
                            NoSurat = string.Format("{0}/{1}/AMIKOM/{2}/{3}",
                                        row.Cells["NIK"].Value.ToString().Substring(row.Cells["NIK"].Value.ToString().Length - 3, 3),
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

            DataTable dtAlokasiDosen = CommonLib.ToDataTable(listAlokasiDosenAll);

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
            if(e.ColumnIndex != 3)
            {
                return;
            }

            DataGridViewCheckBoxCell cb = dgvDataDosen.Rows[e.RowIndex].Cells["Pilih"] as DataGridViewCheckBoxCell;
            cb.Value = !bool.Parse(cb.Value.ToString());
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
    }
}
