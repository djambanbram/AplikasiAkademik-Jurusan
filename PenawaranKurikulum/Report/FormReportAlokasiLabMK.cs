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
    public partial class FormReportAlokasiLabMK : Syncfusion.Windows.Forms.MetroForm
    {
        public static string baseAddress = ConfigurationManager.AppSettings["baseAddress"];
        private string URLGetDepartment = baseAddress + "/jurusan_api/api/organisasi/get_department";
        private string URLGetRuangan = baseAddress + "/jurusan_api/api/kelas/get_ruangan";
        private string URLGetMemberRuangan = baseAddress + "/jurusan_api/api/kelas/get_member_lab";

        private List<Department> listDepartment;
        private List<MemberKelas> listMemberRuangan;

        private WebApi webApi;
        private HttpResponseMessage response;

        public FormReportAlokasiLabMK()
        {
            InitializeComponent();
            webApi = new WebApi();
        }

        private async void FormReportAlokasiLabMK_Load(object sender, EventArgs e)
        {
            //this.reportViewer1.RefreshReport();
            response = await webApi.Post(URLGetDepartment, string.Empty, false);
            if (response.IsSuccessStatusCode)
            {
                listDepartment = JsonConvert.DeserializeObject<List<Department>>(response.Content.ReadAsStringAsync().Result);
            }
            else
            {
                MessageBox.Show(webApi.ReturnMessage(response));
            }

            response = await webApi.Post(URLGetRuangan, string.Empty, true);
            if (response.IsSuccessStatusCode)
            {
                List<dynamic> listRuangan = JsonConvert.DeserializeObject<List<dynamic>>(response.Content.ReadAsStringAsync().Result);
                listRuangan = listRuangan.Where(r => r.IsDipakaiPraktikum == 1).ToList();
                cmbLab.Items.Add("PILIH");
                cmbLab.Items.Add("SEMUA LAB");
                foreach (var item in listRuangan)
                {
                    cmbLab.Items.Add(item.Ruang);
                }
                cmbLab.SelectedIndex = 0;
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

        private async void cmbLab_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbLab.SelectedIndex <= 0)
            {
                return;
            }

            var data = new
            {
                TahunAkademik = LoginAccess.TahunAkademik,
                Semester = LoginAccess.KodeSemester
            };
            string jsonData = JsonConvert.SerializeObject(data);

            response = await webApi.Post(URLGetMemberRuangan, jsonData, true);
            if (response.IsSuccessStatusCode)
            {
                listMemberRuangan = JsonConvert.DeserializeObject<List<MemberKelas>>(response.Content.ReadAsStringAsync().Result);

                string ruang = cmbLab.Text;

                List<ReportParameter> listParams = new List<ReportParameter>();
                listParams.Add(new ReportParameter("TanggalCetak", CultureInfo.CurrentCulture.TextInfo.ToTitleCase(DateTime.Now.ToString("d MMMM yyyy", CultureInfo.GetCultureInfo("id-ID")))));
                listParams.Add(new ReportParameter("TahunAkademik", LoginAccess.TahunAkademik));
                listParams.Add(new ReportParameter("Semester", LoginAccess.Semester));
                listParams.Add(new ReportParameter("KaUPT", listDepartment.Find(d => d.KodeDepartment == "29").NamaKepala));
                listParams.Add(new ReportParameter("NikKaUPT", listDepartment.Find(d => d.KodeDepartment == "29").NikKepala));

                DataTable dtAlokasiLab = null;
                if (cmbLab.SelectedIndex == 1)
                {
                    dtAlokasiLab = CommonLib.ToDataTable(listMemberRuangan);
                }
                else
                {
                    dtAlokasiLab = CommonLib.ToDataTable(listMemberRuangan.Where(l => l.Ruang == ruang).ToList());
                }

                reportViewer1.LocalReport.SetParameters(listParams);
                IDataReader dr = dtAlokasiLab.CreateDataReader();
                dataSetAlokasi.Tables["AlokasiLab"].Clear();
                dataSetAlokasi.Tables["AlokasiLab"].Load(dr);
                dr.Close();
                reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
                reportViewer1.ZoomMode = ZoomMode.Percent;
                reportViewer1.LocalReport.Refresh();
                reportViewer1.RefreshReport();
            }
            else
            {
                MessageBox.Show(webApi.ReturnMessage(response)); ;
            }
        }
    }
}
