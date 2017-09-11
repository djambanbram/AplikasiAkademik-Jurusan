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
    public partial class FormReportDosenWali : Syncfusion.Windows.Forms.MetroForm
    {
        public static string baseAddress = ConfigurationManager.AppSettings["baseAddress"];
        private string URLGetDepartment = baseAddress + "/jurusan_api/api/organisasi/get_department";
        private string URLGetDosenWali = baseAddress + "/jurusan_api/api/dosen/get_dosen_wali";

        private List<Department> listDepartment;
        private List<Fakultas> listFakultas;
        private List<Prodi> listProdi;

        private WebApi webApi;
        private HttpResponseMessage response;

        public string kodeProgramDipilih;
        public string idProdiDipilih;

        public FormReportDosenWali()
        {
            InitializeComponent();
            webApi = new WebApi();
        }

        private void Loading(bool isLoading)
        {
            gradientPanel2.Enabled = !isLoading;
            flowLayoutPanel1.Enabled = !isLoading;
            reportViewer1.Enabled = !isLoading;

            progressBar1.Visible = isLoading;
        }

        private void btnTutup_Click(object sender, EventArgs e)
        {
            Close();
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
            if (cmbProdi.SelectedIndex > 0)
            {
                await PreviewDosenWali();
            }
        }

        private async void FormReportDosenWali_Load(object sender, EventArgs e)
        {
            Loading(true);

            listFakultas = new List<Fakultas>(Organisasi.listFakultas);
            listFakultas.Insert(0, new Fakultas() { KodeFakultas = "-", NamaFakultas = "Pilih" });
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

            for (int i = DateTime.Now.Year; i >= DateTime.Now.Year - 5; i--)
            {
                cmbAngkatan.Items.Add(i);
            }
            cmbAngkatan.SelectedIndex = 0;
            Loading(false);
        }

        private async Task PreviewDosenWali()
        {
            var angkatan = int.Parse(cmbAngkatan.Text);

            var data = new { Angkatan = angkatan };
            var jsonData = JsonConvert.SerializeObject(data);
            response = await webApi.Post(URLGetDosenWali, jsonData, true);
            if (!response.IsSuccessStatusCode)
            {
                MessageBox.Show(webApi.ReturnMessage(response));
                Loading(false);
                return;
            }
            List<DosenWali> listDosenWali = JsonConvert.DeserializeObject<List<DosenWali>>(response.Content.ReadAsStringAsync().Result);

            if (listDosenWali.Count == 0)
            {
                MessageBox.Show("Dosen wali belum dialokasikan oleh Prodi");
                Loading(false);
                return;
            }

            //MessageBox.Show(Organisasi.listProgram.Find(p => p.Prodi.Uid == cmbProdi.SelectedValue.ToString()).Prodi.SingkatanProdi);
            var singkatanProdi = Organisasi.listProgram.Find(p => p.Prodi.Uid == cmbProdi.SelectedValue.ToString()).Prodi.SingkatanProdi;

            string KodeProgramReguler = Organisasi.listProdi.Find(pr => pr.Uid == cmbProdi.SelectedValue.ToString()).KodeProgramReguler;
            List<ReportParameter> listParams = new List<ReportParameter>();
            listParams.Add(new ReportParameter("TglPengesahaan", CultureInfo.CurrentCulture.TextInfo.ToTitleCase(DateTime.Now.ToString("dd MMMM yyyy", CultureInfo.GetCultureInfo("id-ID")))));
            listParams.Add(new ReportParameter("TahunAkademik", LoginAccess.TahunAkademik));
            listParams.Add(new ReportParameter("Prodi", cmbProdi.Text));
            listParams.Add(new ReportParameter("Kaprodi", listDepartment.Find(d => d.KodeDepartment == KodeProgramReguler).NamaKepala));
            listParams.Add(new ReportParameter("NikKaprodi", listDepartment.Find(d => d.KodeDepartment == KodeProgramReguler).NikKepala));
            listParams.Add(new ReportParameter("NoSurat", string.Format("{0}/{1}/AMIKOM/{2}/{3}",
                                                            DateTime.Now.Day, singkatanProdi, CommonLib.NumberToRoman(DateTime.Now.Month), DateTime.Now.Year)));

            List<DosenWali> listTemp = listDosenWali.Where(w => w.IdProdi == cmbProdi.SelectedValue.ToString()).ToList();
            DataTable dtDosenWaliPerProdi = CommonLib.ToDataTable(listTemp);

            reportViewer1.LocalReport.SetParameters(listParams);
            IDataReader dr = dtDosenWaliPerProdi.CreateDataReader();
            dsDosen.Tables["DosenWali"].Clear();
            dsDosen.Tables["DosenWali"].Load(dr);
            reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
            reportViewer1.ZoomMode = ZoomMode.Percent;
            reportViewer1.LocalReport.Refresh();
            reportViewer1.RefreshReport();
        }

        private async void cmbAngkatan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbProdi.SelectedIndex > 0)
            {
                await PreviewDosenWali();
            }
        }
    }

    public class DosenWali
    {
        public string Npm { get; set; }
        public string Nik { get; set; }
        public string NamaDosen { get; set; }
        public string NamaProgram { get; set; }
        public string IdProdi { get; set; }
        public string NamaProdi { get; set; }
    }
}
