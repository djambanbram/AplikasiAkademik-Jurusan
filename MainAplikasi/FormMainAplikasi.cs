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
using MainAplikasi.DataBindding;

namespace MainAplikasi
{
    public partial class FormMainAplikasi : Syncfusion.Windows.Forms.MetroForm
    {
        public static string baseAddress = ConfigurationManager.AppSettings["baseAddress"];
        private string URLGetProgramAll = baseAddress + "/jurusan_api/api/organisasi/get_program_all";
        private string URLGetKategoriMK = baseAddress + "/jurusan_api/api/kurikulum/get_kategori_mk";
        private string URLGetSifatMK = baseAddress + "/jurusan_api/api/kurikulum/get_sifat_mk";

        private WebApi webApi;
        private FromKelasReguler formKelasReguler;
        private FormDataMataKuliah formDataMataKuliah;
        private HttpResponseMessage response;

        public FormMainAplikasi()
        {
            InitializeComponent();
            webApi = new WebApi();
        }

        private void Loading(bool isLoading)
        {
            xpTaskBar1.Enabled = !isLoading;
        }

        private void boxKelas_ItemClick(object sender, Syncfusion.Windows.Forms.Tools.XPTaskBarItemClickArgs e)
        {
            if (e.XPTaskBarItem.Name == "itemKelasReguler")
            {
                if (formKelasReguler == null || formKelasReguler.IsDisposed)
                {
                    formKelasReguler = new FromKelasReguler();
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
        }

        private void FormMainAplikasi_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.ExitThread();
        }

        private async void FormMainAplikasi_Load(object sender, EventArgs e)
        {
            Loading(true);

            response = await webApi.Post(URLGetProgramAll);
            if (response.IsSuccessStatusCode)
            {
                List<dynamic> oListProgram = JsonConvert.DeserializeObject<List<dynamic>>(response.Content.ReadAsStringAsync().Result);
                OrganisasiBinding organisasiBinding = new OrganisasiBinding(oListProgram);
            }

            response = await webApi.Post(URLGetKategoriMK);
            if (response.IsSuccessStatusCode)
            {
                List<dynamic> oListKategoriMK = JsonConvert.DeserializeObject<List<dynamic>>(response.Content.ReadAsStringAsync().Result);
                KategoriMKBinding kategoriMKBinding = new KategoriMKBinding(oListKategoriMK);
            }

            response = await webApi.Post(URLGetSifatMK);
            if (response.IsSuccessStatusCode)
            {
                List<dynamic> oListSifatMK = JsonConvert.DeserializeObject<List<dynamic>>(response.Content.ReadAsStringAsync().Result);
                SifatMKBinding sifatMKBinding = new SifatMKBinding(oListSifatMK);
            }

            Loading(false);
        }
    }
}
