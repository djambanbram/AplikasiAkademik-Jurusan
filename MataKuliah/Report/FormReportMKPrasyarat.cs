#region Copyright Syncfusion Inc. 2001 - 2016
// Copyright Syncfusion Inc. 2001 - 2016. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using ApiService;
using ClassModel;
using MataKuliah.DataBinding;
using MataKuliah.Lib;
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

namespace MataKuliah.Report
{
    public partial class FormReportMKPrasyarat : Syncfusion.Windows.Forms.MetroForm
    {
        public static string baseAddress = ConfigurationManager.AppSettings["baseAddress"];
        private string URLGetMK = baseAddress + "/jurusan_api/api/kurikulum/get_mk";
        private string URLGetDepartment = baseAddress + "/jurusan_api/api/organisasi/get_department";
        private string URLGetMKPrasyarat = baseAddress + "/jurusan_api/api/kurikulum/get_mk_prasyarat";

        private List<Fakultas> listFakultas;
        private List<Prodi> listProdi;
        private List<Department> listDepartment;
        private List<DataMataKuliahPrasyarat> listDataMKPrasyarat;

        private WebApi webApi;
        private HttpResponseMessage response;

        public FormReportMKPrasyarat()
        {
            InitializeComponent();
            webApi = new WebApi();
        }

        private void btnTutup_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void FormReportMKPrasyarat_Load(object sender, EventArgs e)
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
            this.reportViewer2.RefreshReport();
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

        private async void cmbProdi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbProdi.SelectedIndex <= 0)
            {
                return;
            }

            string idProdi = cmbProdi.SelectedValue.ToString();

            MKByIdProdi m = new MKByIdProdi() { IdProdi = idProdi };
            string jsonData = JsonConvert.SerializeObject(m);

            response = await webApi.Post(URLGetMKPrasyarat, jsonData, true);
            if (!response.IsSuccessStatusCode)
            {
                MessageBox.Show(webApi.ReturnMessage(response));
                return;
            }

            List<dynamic> oListMK = JsonConvert.DeserializeObject<List<dynamic>>(response.Content.ReadAsStringAsync().Result);
            MataKuliahPrasyaratBinding mkBinding = new MataKuliahPrasyaratBinding(oListMK);
            listDataMKPrasyarat = new List<DataMataKuliahPrasyarat>((ClassModel.MataKuliah.listDataMataKuliahPrasyarat).Where(p => string.IsNullOrWhiteSpace(p.KodePrasyarat) == false).ToList());

            string KodeProgramReguler = Organisasi.listProdi.Find(pr => pr.Uid == idProdi).KodeProgramReguler;
            List<ReportParameter> listParams = new List<ReportParameter>();
            listParams.Add(new ReportParameter("ProgramStudi", Organisasi.listProdi.Find(pr => pr.Uid == cmbProdi.SelectedValue.ToString()).NamaProdi));
            listParams.Add(new ReportParameter("Fakultas", Organisasi.listFakultas.Find(f => f.KodeFakultas == cmbFakultas.SelectedValue.ToString()).NamaFakultas));
            listParams.Add(new ReportParameter("TanggalCetak", CultureInfo.CurrentCulture.TextInfo.ToTitleCase(DateTime.Now.ToString("d MMMM yyyy", CultureInfo.GetCultureInfo("id-ID")))));
            listParams.Add(new ReportParameter("Dekan", listDepartment.Find(d => d.KodeDepartment == cmbFakultas.SelectedValue.ToString()).NamaKepala));
            listParams.Add(new ReportParameter("NikDekan", listDepartment.Find(d => d.KodeDepartment == cmbFakultas.SelectedValue.ToString()).NikKepala));
            listParams.Add(new ReportParameter("Kaprodi", listDepartment.Find(d => d.KodeDepartment == KodeProgramReguler).NamaKepala));
            listParams.Add(new ReportParameter("NikKaprodi", listDepartment.Find(d => d.KodeDepartment == KodeProgramReguler).NikKepala));

            DataTable dtMKPrasyarat = CommonLib.ToDataTable(listDataMKPrasyarat);

            reportViewer2.LocalReport.SetParameters(listParams);
            IDataReader dr = dtMKPrasyarat.CreateDataReader();
            dataSetMataKuliah.Tables["MKPrasyarat"].Clear();
            dataSetMataKuliah.Tables["MKPrasyarat"].Load(dr);
            dr.Close();
            reportViewer2.SetDisplayMode(DisplayMode.PrintLayout);
            reportViewer2.ZoomMode = ZoomMode.Percent;
            reportViewer2.LocalReport.Refresh();
            reportViewer2.RefreshReport();
        }
    }
}
