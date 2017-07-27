#region Copyright Syncfusion Inc. 2001 - 2016
// Copyright Syncfusion Inc. 2001 - 2016. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KelasMahasiswa;
using MataKuliah;
using MataKuliah.DataBindding;
using System.Net.Http;
using ApiService;
using Newtonsoft.Json;
using System.Configuration;
using ClassModel;
using PenawaranKurikulum;

namespace MainAplikasi
{
    public partial class FormMainAplikasi : Syncfusion.Windows.Forms.MetroForm
    {
        public static string baseAddress = ConfigurationManager.AppSettings["baseAddress"];
        private string URLGetProgramAll = baseAddress + "/jurusan_api/api/organisasi/get_program_all";

        private WebApi webApi;
        private FormKelasReguler formKelasReguler;
        private FormDataMataKuliah formDataMataKuliah;
        private FormMataKuliahPrasyarat formMataKuliahPrasyarat;
        private FormAlokasiMK formAlokasiMK;

        private HttpResponseMessage response;

        public FormMainAplikasi()
        {
            InitializeComponent();
            webApi = new WebApi();
        }

        private void Loading(bool isLoading)
        {
            xpTaskBar1.Enabled = !isLoading;
            autoLabel1.Visible = isLoading;
        }

        private void boxKelas_ItemClick(object sender, Syncfusion.Windows.Forms.Tools.XPTaskBarItemClickArgs e)
        {
            if (e.XPTaskBarItem.Name == "itemKelasReguler")
            {
                if (formKelasReguler == null || formKelasReguler.IsDisposed)
                {
                    formKelasReguler = new FormKelasReguler();
                    formKelasReguler.MdiParent = this;
                }
                formKelasReguler.Show();
                tabbedMDIManager1.UpdateActiveTabHost(formKelasReguler);
            }
            if (e.XPTaskBarItem.Name == "itemMataKuliah")
            {
                if (formDataMataKuliah == null || formDataMataKuliah.IsDisposed)
                {
                    formDataMataKuliah = new FormDataMataKuliah();
                    formDataMataKuliah.MdiParent = this;
                }
                formDataMataKuliah.Show();
                tabbedMDIManager1.UpdateActiveTabHost(formDataMataKuliah);
            }
            if (e.XPTaskBarItem.Name == "itemMKPrasyarat")
            {
                if (formMataKuliahPrasyarat == null || formMataKuliahPrasyarat.IsDisposed)
                {
                    formMataKuliahPrasyarat = new FormMataKuliahPrasyarat();
                    formMataKuliahPrasyarat.MdiParent = this;
                }
                formMataKuliahPrasyarat.Show();
                tabbedMDIManager1.UpdateActiveTabHost(formMataKuliahPrasyarat);
            }
            if (e.XPTaskBarItem.Name == "itemAlokasiMK")
            {
                if (formAlokasiMK == null || formAlokasiMK.IsDisposed)
                {
                    formAlokasiMK = new FormAlokasiMK();
                    formAlokasiMK.MdiParent = this;
                }
                formAlokasiMK.Show();
                tabbedMDIManager1.UpdateActiveTabHost(formAlokasiMK);
            }
        }

        private void FormMainAplikasi_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.ExitThread();
        }

        private async void FormMainAplikasi_Load(object sender, EventArgs e)
        {
            Loading(true);

            response = await webApi.Post(URLGetProgramAll, string.Empty, false);
            if (response.IsSuccessStatusCode)
            {
                List<dynamic> oListProgram = JsonConvert.DeserializeObject<List<dynamic>>(response.Content.ReadAsStringAsync().Result);
                OrganisasiBinding organisasiBinding = new OrganisasiBinding(oListProgram);
            }
            stripLabel.Text = string.Format("Tahun Akademik {0} Semester {1}", LoginAccess.TahunAkademik, LoginAccess.Semester);

            Loading(false);
        }
    }
}
