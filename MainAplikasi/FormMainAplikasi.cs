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
using Syncfusion.Windows.Forms.Tools;

namespace MainAplikasi
{
    public partial class FormMainAplikasi : Syncfusion.Windows.Forms.MetroForm
    {
        public static string baseAddress = ConfigurationManager.AppSettings["baseAddress"];
        private string URLGetProgramAll = baseAddress + "/jurusan_api/api/organisasi/get_program_all";

        private WebApi webApi;
        private FormKelasReguler formKelasReguler;
        private FormKelasCampuran formKelasCampuran;
        private FormDataMataKuliah formDataMataKuliah;
        private FormMataKuliahPrasyarat formMataKuliahPrasyarat;
        private FormAlokasiMK formAlokasiMK;
        private FormAlokasiDosen formAlokasiDosen;
        private FormAlokasiLabMK formAlokasiLabMK;

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
            Form form = null;
            if (e.XPTaskBarItem.Name == "itemKelasReguler")
            {
                if (formKelasReguler == null || formKelasReguler.IsDisposed)
                {
                    formKelasReguler = new FormKelasReguler();
                    formKelasReguler.MdiParent = this;
                }
                form = formKelasReguler;
            }
            else if (e.XPTaskBarItem.Name == "itemKelasCampuran")
            {
                //if (formKelasCampuran == null || formKelasCampuran.IsDisposed)
                //{
                //    formKelasCampuran = new FormKelasCampuran();
                //    formKelasCampuran.MdiParent = this;
                //}
                //    form = formKelasCampuran;
                XPTaskBarItem item = e.XPTaskBarItem;
                menuKelasCampuran.Show(item.Parent as Control, new Point(item.Bounds.Width, item.Bounds.Y));
            }
            else if (e.XPTaskBarItem.Name == "itemMataKuliah")
            {
                if (formDataMataKuliah == null || formDataMataKuliah.IsDisposed)
                {
                    formDataMataKuliah = new FormDataMataKuliah();
                    formDataMataKuliah.MdiParent = this;
                }
                form = formDataMataKuliah;
            }
            else if (e.XPTaskBarItem.Name == "itemMKPrasyarat")
            {
                if (formMataKuliahPrasyarat == null || formMataKuliahPrasyarat.IsDisposed)
                {
                    formMataKuliahPrasyarat = new FormMataKuliahPrasyarat();
                    formMataKuliahPrasyarat.MdiParent = this;
                }
                form = formMataKuliahPrasyarat;
            }
            else if (e.XPTaskBarItem.Name == "itemAlokasiMK")
            {
                if (formAlokasiMK == null || formAlokasiMK.IsDisposed)
                {
                    formAlokasiMK = new FormAlokasiMK();
                    formAlokasiMK.MdiParent = this;
                }
                form = formAlokasiMK;
            }
            else if (e.XPTaskBarItem.Name == "itemAlokasiDosen")
            {
                //if (formAlokasiDosen == null || formAlokasiDosen.IsDisposed)
                //{
                //    formAlokasiDosen = new FormAlokasiDosen();
                //    formAlokasiDosen.MdiParent = this;
                //}
                //form = formAlokasiDosen;
                XPTaskBarItem item = e.XPTaskBarItem;
                menuAlokasiDosen.Show(item.Parent as Control, new Point(item.Bounds.Width, item.Bounds.Y));
            }
            else if (e.XPTaskBarItem.Name == "itemAlokasiLabMK")
            {
                if (formAlokasiLabMK == null || formAlokasiLabMK.IsDisposed)
                {
                    formAlokasiLabMK = new FormAlokasiLabMK();
                    formAlokasiLabMK.MdiParent = this;
                }
                form = formAlokasiLabMK;
            }
            else if (e.XPTaskBarItem.Name == "itemKeluar")
            {
                Application.ExitThread();
            }
            if (form != null && !form.IsDisposed)
            {
                form.Show();
                tabbedMDIManager1.UpdateActiveTabHost(form);
            }
        }

        private void FormMainAplikasi_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.ExitThread();
        }

        private async void FormMainAplikasi_Load(object sender, EventArgs e)
        {
            Loading(true);
            stripLabel.Text = "Loading...";
            response = await webApi.Post(URLGetProgramAll, string.Empty, false);
            if (response.IsSuccessStatusCode)
            {
                List<dynamic> oListProgram = JsonConvert.DeserializeObject<List<dynamic>>(response.Content.ReadAsStringAsync().Result);
                OrganisasiBinding organisasiBinding = new OrganisasiBinding(oListProgram);
            }
            else
            {
                MessageBox.Show(webApi.ReturnMessage(response));
            }

            Loading(false);
            stripLabel.Text = string.Format("{0} | Version: {1} | Tahun Akademik {2} Semester {3}", Application.ProductName, Application.ProductVersion, LoginAccess.TahunAkademik, LoginAccess.Semester);
        }

        private void menuItemSatuProgramKelasCampuran_Click(object sender, EventArgs e)
        {
            if (formKelasCampuran == null || formKelasCampuran.IsDisposed)
            {
                formKelasCampuran = new FormKelasCampuran();
                formKelasCampuran.MdiParent = this;
            }
            formKelasCampuran.Show();
            tabbedMDIManager1.UpdateActiveTabHost(formKelasCampuran);
        }

        private void menuItemSatuProgramAlokasiDosen_Click(object sender, EventArgs e)
        {
            if (formAlokasiDosen == null || formAlokasiDosen.IsDisposed)
            {
                formAlokasiDosen = new FormAlokasiDosen();
                formAlokasiDosen.MdiParent = this;
            }
            formAlokasiDosen.Show();
            tabbedMDIManager1.UpdateActiveTabHost(formAlokasiDosen);
        }
    }
}
