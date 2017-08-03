#region Copyright Syncfusion Inc. 2001 - 2016
// Copyright Syncfusion Inc. 2001 - 2016. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using ApiService;
using ClassModel;
using Microsoft.Reporting.WinForms;
using Newtonsoft.Json;
using PenawaranKurikulum.Lib;
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

namespace PenawaranKurikulum.Report
{
    public partial class FormReportAlokasiDosen : Syncfusion.Windows.Forms.MetroForm
    {
        public static string baseAddress = ConfigurationManager.AppSettings["baseAddress"];
        private string URLGetDepartment = baseAddress + "/jurusan_api/api/organisasi/get_department";
        private string URLGetDosenMengajar = baseAddress + "/jurusan_api/api/pengajaran/get_dosen_mengajar";

        private List<Fakultas> listFakultas;
        private List<Prodi> listProdi;
        private List<Program> listProgram;
        private List<Department> listDepartment;
        private WebApi webApi;
        private HttpResponseMessage response;

        public FormReportAlokasiDosen()
        {
            InitializeComponent();
            webApi = new WebApi();
        }

        private void btnTutup_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void FormReportAlokasiDosen_Load(object sender, EventArgs e)
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

        private async void cmbProgram_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbProdi.SelectedIndex == 0 || cmbProgram.SelectedIndex == 0)
            {
                return;
            }
            string idProdi = cmbProdi.SelectedValue.ToString();

            var data = new { TahunAkademik = LoginAccess.TahunAkademik, KodeJurusan = cmbProgram.SelectedValue.ToString(), Semester = LoginAccess.KodeSemester, IdProdi = cmbProdi.SelectedValue.ToString() };

            string jsonData = JsonConvert.SerializeObject(data);

            response = await webApi.Post(URLGetDosenMengajar, jsonData, true);
            if (response.IsSuccessStatusCode)
            {
                List<AlokasiDosenMengajar> listAlokasiDosenMengajar = JsonConvert.DeserializeObject<List<AlokasiDosenMengajar>>(response.Content.ReadAsStringAsync().Result);

                string KodeProgramReguler = Organisasi.listProdi.Find(pr => pr.Uid == idProdi).KodeProgramReguler;
                List<ReportParameter> listParams = new List<ReportParameter>();
                listParams.Add(new ReportParameter("ProgramStudi", Organisasi.listProdi.Find(pr => pr.Uid == cmbProdi.SelectedValue.ToString()).NamaProdi));
                listParams.Add(new ReportParameter("Fakultas", Organisasi.listFakultas.Find(f => f.KodeFakultas == cmbFakultas.SelectedValue.ToString()).NamaFakultas));
                listParams.Add(new ReportParameter("TanggalCetak", CultureInfo.CurrentCulture.TextInfo.ToTitleCase(DateTime.Now.ToString("d MMMM yyyy", CultureInfo.GetCultureInfo("id-ID")))));
                listParams.Add(new ReportParameter("Dekan", listDepartment.Find(d => d.KodeDepartment == cmbFakultas.SelectedValue.ToString()).NamaKepala));
                listParams.Add(new ReportParameter("NikDekan", listDepartment.Find(d => d.KodeDepartment == cmbFakultas.SelectedValue.ToString()).NikKepala));
                listParams.Add(new ReportParameter("Kaprodi", listDepartment.Find(d => d.KodeDepartment == KodeProgramReguler).NamaKepala));
                listParams.Add(new ReportParameter("NikKaprodi", listDepartment.Find(d => d.KodeDepartment == KodeProgramReguler).NikKepala));
                listParams.Add(new ReportParameter("TahunAkademik", LoginAccess.TahunAkademik));
                listParams.Add(new ReportParameter("Semester", LoginAccess.Semester));
                listParams.Add(new ReportParameter("Program", cmbProgram.Text));

                DataTable dtAlokasiDosen = CommonLib.ToDataTable(listAlokasiDosenMengajar);

                reportViewer1.LocalReport.SetParameters(listParams);
                IDataReader dr = dtAlokasiDosen.CreateDataReader();
                dataSetAlokasi.Tables["AlokasiDosen"].Clear();
                dataSetAlokasi.Tables["AlokasiDosen"].Load(dr);
                dr.Close();
                reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
                reportViewer1.ZoomMode = ZoomMode.Percent;
                reportViewer1.LocalReport.Refresh();
                reportViewer1.RefreshReport();
            }
            else
            {
                MessageBox.Show(webApi.ReturnMessage(response));
            }
        }
    }
}
