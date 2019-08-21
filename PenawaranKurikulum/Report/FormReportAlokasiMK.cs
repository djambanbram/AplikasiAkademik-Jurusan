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
using PenawaranKurikulum.DataBinding;
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
    public partial class FormReportAlokasiMK : Syncfusion.Windows.Forms.MetroForm
    {
        public static string baseAddress = ConfigurationManager.AppSettings["baseAddress"];
        private string URLGetTahunAkademik = baseAddress + "/jurusan_api/api/data_support/init_tahun_akademik";
        private string URLGetSemester = baseAddress + "/jurusan_api/api/data_support/init_data_semester";
        private string URLGetDepartment = baseAddress + "/jurusan_api/api/organisasi/get_department";
        private string URLGetMKSudahDitawarkan = baseAddress + "/jurusan_api/api/kurikulum/get_mk_sudah_ditawarkan";
        private string URLGetDosenMengajar = baseAddress + "/jurusan_api/api/pengajaran/get_dosen_mengajar";

        private List<Fakultas> listFakultas;
        private List<Prodi> listProdi;
        private List<Program> listProgram;
        private List<Department> listDepartment;

        private WebApi webApi;
        private HttpResponseMessage response;


        public FormReportAlokasiMK()
        {
            InitializeComponent();
            webApi = new WebApi();
        }

        private async void FormReportAlokasiMK_Load(object sender, EventArgs e)
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
            //this.reportViewer1.RefreshReport();
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
            //if (cmbProdi.SelectedIndex == 0 || cmbProgram.SelectedIndex == 0)
            //{
            //    return; 
            //}
            //string idProdi = cmbProdi.SelectedValue.ToString();

            //var data = new { TahunAkademik = LoginAccess.TahunAkademik, KodeJurusan = cmbProgram.SelectedValue.ToString(), Semester = LoginAccess.KodeSemester, IdProdi = cmbProdi.SelectedValue.ToString() };

            //string jsonData = JsonConvert.SerializeObject(data);

            //response = await webApi.Post(URLGetMKSudahDitawarkan, jsonData, true);
            //if (!response.IsSuccessStatusCode)
            //{
            //    MessageBox.Show(webApi.ReturnMessage(response));
            //    return;
            //}
            //List<dynamic> oListMkSudahDitawarkan = JsonConvert.DeserializeObject<List<dynamic>>(response.Content.ReadAsStringAsync().Result);
            //MataKuliahSudahDitawarkanBinding mkBinding = new MataKuliahSudahDitawarkanBinding(oListMkSudahDitawarkan);


            //string KodeProgramReguler = Organisasi.listProdi.Find(pr => pr.Uid == idProdi).KodeProgramReguler;
            //List<ReportParameter> listParams = new List<ReportParameter>();
            //listParams.Add(new ReportParameter("ProgramStudi", Organisasi.listProdi.Find(pr => pr.Uid == cmbProdi.SelectedValue.ToString()).NamaProdi));
            //listParams.Add(new ReportParameter("Fakultas", Organisasi.listFakultas.Find(f => f.KodeFakultas == cmbFakultas.SelectedValue.ToString()).NamaFakultas));
            //listParams.Add(new ReportParameter("TanggalCetak", CultureInfo.CurrentCulture.TextInfo.ToTitleCase(DateTime.Now.ToString("d MMMM yyyy", CultureInfo.GetCultureInfo("id-ID")))));
            //listParams.Add(new ReportParameter("Dekan", listDepartment.Find(d => d.KodeDepartment == cmbFakultas.SelectedValue.ToString()).NamaKepala));
            //listParams.Add(new ReportParameter("NikDekan", listDepartment.Find(d => d.KodeDepartment == cmbFakultas.SelectedValue.ToString()).NikKepala));
            //listParams.Add(new ReportParameter("Kaprodi", listDepartment.Find(d => d.KodeDepartment == KodeProgramReguler).NamaKepala));
            //listParams.Add(new ReportParameter("NikKaprodi", listDepartment.Find(d => d.KodeDepartment == KodeProgramReguler).NikKepala));
            //listParams.Add(new ReportParameter("TahunAkademik", LoginAccess.TahunAkademik));
            //listParams.Add(new ReportParameter("Semester", LoginAccess.Semester));
            //DataTable dtMKDitawarkan = CommonLib.ToDataTable(MataKuliah.listMataKuliahSudahDitawarkan);

            //reportViewer1.LocalReport.SetParameters(listParams);
            //IDataReader dr = dtMKDitawarkan.CreateDataReader();
            //dataSetAlokasi.Tables["MataKuliahDitawarkan"].Clear();
            //dataSetAlokasi.Tables["MataKuliahDitawarkan"].Load(dr);
            //dr.Close();
            //reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
            //reportViewer1.ZoomMode = ZoomMode.Percent;
            //reportViewer1.LocalReport.Refresh();
            //reportViewer1.RefreshReport();
        }

        private async void btnProses_Click(object sender, EventArgs e)
        {
            if (cmbProdi.SelectedIndex == 0 || cmbProgram.SelectedIndex == 0)
            {
                return;
            }
            string idProdi = cmbProdi.SelectedValue.ToString();

            var data = new { TahunAkademik = cmbTahunAkademik.Text, KodeJurusan = cmbProgram.SelectedValue.ToString(), Semester = int.Parse(cmbSemester.SelectedValue.ToString()), IdProdi = cmbProdi.SelectedValue.ToString() };

            string jsonData = JsonConvert.SerializeObject(data);

            response = await webApi.Post(URLGetMKSudahDitawarkan, jsonData, true);
            if (!response.IsSuccessStatusCode)
            {
                MessageBox.Show(webApi.ReturnMessage(response));
                return;
            }
            List<dynamic> oListMkSudahDitawarkan = JsonConvert.DeserializeObject<List<dynamic>>(response.Content.ReadAsStringAsync().Result);
            MataKuliahSudahDitawarkanBinding mkBinding = new MataKuliahSudahDitawarkanBinding(oListMkSudahDitawarkan);


            string KodeProgramReguler = Organisasi.listProdi.Find(pr => pr.Uid == idProdi).KodeProgramReguler;
            List<ReportParameter> listParams = new List<ReportParameter>();
            listParams.Add(new ReportParameter("ProgramStudi", Organisasi.listProdi.Find(pr => pr.Uid == cmbProdi.SelectedValue.ToString()).NamaProdi));
            listParams.Add(new ReportParameter("Fakultas", Organisasi.listFakultas.Find(f => f.KodeFakultas == cmbFakultas.SelectedValue.ToString()).NamaFakultas));
            listParams.Add(new ReportParameter("TanggalCetak", CultureInfo.CurrentCulture.TextInfo.ToTitleCase(DateTime.Now.ToString("d MMMM yyyy", CultureInfo.GetCultureInfo("id-ID")))));
            listParams.Add(new ReportParameter("Dekan", listDepartment.Find(d => d.KodeDepartment == cmbFakultas.SelectedValue.ToString()).NamaKepala));
            listParams.Add(new ReportParameter("NikDekan", listDepartment.Find(d => d.KodeDepartment == cmbFakultas.SelectedValue.ToString()).NikKepala));
            listParams.Add(new ReportParameter("Kaprodi", listDepartment.Find(d => d.KodeDepartment == KodeProgramReguler).NamaKepala));
            listParams.Add(new ReportParameter("NikKaprodi", listDepartment.Find(d => d.KodeDepartment == KodeProgramReguler).NikKepala));
            listParams.Add(new ReportParameter("TahunAkademik", cmbTahunAkademik.Text));
            listParams.Add(new ReportParameter("Semester", cmbSemester.Text));
            DataTable dtMKDitawarkan = CommonLib.ToDataTable(MataKuliah.listMataKuliahSudahDitawarkan);

            reportViewer1.LocalReport.SetParameters(listParams);
            IDataReader dr = dtMKDitawarkan.CreateDataReader();
            dataSetAlokasi.Tables["MataKuliahDitawarkan"].Clear();
            dataSetAlokasi.Tables["MataKuliahDitawarkan"].Load(dr);
            dr.Close();
            reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
            reportViewer1.ZoomMode = ZoomMode.Percent;
            reportViewer1.LocalReport.Refresh();
            reportViewer1.RefreshReport();
        }
    }
}
