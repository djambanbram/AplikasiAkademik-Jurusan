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
using MataKuliah.Report;
using PenawaranKurikulum.Report;
using System.Deployment.Application;
using Dosen;
using Dosen.Report;
using KonversiAlihJalur.Report;
using KonversiAlihJalur;

namespace MainAplikasi
{
    public partial class FormMainAplikasi : Syncfusion.Windows.Forms.MetroForm
    {
        public static string baseAddress = ConfigurationManager.AppSettings["baseAddress"];
        private string URLGetProgramAll = baseAddress + "/jurusan_api/api/organisasi/get_program_all";
        private int countDown;
        private TimeSpan time;

        private WebApi webApi;
        private FormKelasReguler formKelasReguler;
        private FormKelasCampuran formKelasCampuran;
        private FormDataMataKuliah formDataMataKuliah;
        private FormMataKuliahPrasyarat formMataKuliahPrasyarat;
        private FormMataKuliahKonsentrasi formMataKuliahKonsentrasi;
        private FormGrupMK formGrupMK;
        private FormAlokasiMK formAlokasiMK;
        private FormAlokasiMKStudentExchange formAlokasiMKStudentExchange;
        private FormAlokasiDosen formAlokasiDosen;
        private FormAlokasiLabMK formAlokasiLabMK;
        private FormKoordinatorMataKuliah formKoordinatorMataKuliah;
        private FormTimDosen formTimDosen;
        private FormHonorDosen formHonorDosen;
        private FormJenjangPendidikanDosen formJenjangPendidikanDosen;
        private FormSetKonversiMK formSetKonversiMK;
        private FormMatrikulasiCalonAlihJalur formMatrikulasiCalonAlihJalur;
        private FormKonversiNilaiCalonPemutihan formKonversiNilaiCalonPemutihan;

        private FormReportDataMK formReportDataMK;
        private FormReportMKPrasyarat formReportMKPrasyarat;
        private FormReportAlokasiMK formReportAlokasiMK;
        private FormReportAlokasiLabMK formReportAlokasiLabMK;
        private FormReportAlokasiDosen formReportAlokasiDosen;
        private FormReportKesanggupanDosen formReportKesanggupanDosen;
        private FormReportKesediaanDosen formReportKesediaanDosen;
        private FormReportDosenWali formReportDosenWali;
        private FormReportHonorDosenMengajar formReportHonorDosenMengajar;
        private FormReportHonorDosenMengajar2 formReportHonorDosenMengajar2;
        private FormReportHonorDosenKoreksi formReportHonorDosenKoreksi;
        private FormReportHasilMatrikulasi formReportHasilMatrikulasi;

        private HttpResponseMessage response;

        public FormMainAplikasi()
        {
            InitializeComponent();
            webApi = new WebApi();
            countDown = int.Parse(LoginAccess.expires_in) - 1;
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
                if (IsSemesterRemidial())
                {
                    return;
                }
                if (formKelasReguler == null || formKelasReguler.IsDisposed)
                {
                    formKelasReguler = new FormKelasReguler();
                    formKelasReguler.MdiParent = this;
                }
                form = formKelasReguler;
            }
            else if (e.XPTaskBarItem.Name == "itemKelasCampuran")
            {
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
            else if (e.XPTaskBarItem.Name == "itemMKKonsentrasi")
            {
                if (formMataKuliahKonsentrasi == null || formMataKuliahKonsentrasi.IsDisposed)
                {
                    formMataKuliahKonsentrasi = new FormMataKuliahKonsentrasi();
                    formMataKuliahKonsentrasi.MdiParent = this;
                }
                form = formMataKuliahKonsentrasi;
            }
            else if (e.XPTaskBarItem.Name == "itemGrupMK")
            {
                if (IsSemesterRemidial())
                {
                    return;
                }
                if (formGrupMK == null || formGrupMK.IsDisposed)
                {
                    formGrupMK = new FormGrupMK();
                    formGrupMK.MdiParent = this;
                }
                form = formGrupMK;
            }
            else if (e.XPTaskBarItem.Name == "itemAlokasiMK")
            {
                //if (formAlokasiMK == null || formAlokasiMK.IsDisposed)
                //{
                //    formAlokasiMK = new FormAlokasiMK();
                //    formAlokasiMK.MdiParent = this;
                //}
                //form = formAlokasiMK;
                XPTaskBarItem item = e.XPTaskBarItem;
                menuAlokasiMataKuliah.Show(item.Parent as Control, new Point(item.Bounds.Width, item.Bounds.Y));
            }
            else if (e.XPTaskBarItem.Name == "itemAlokasiDosen")
            {
                XPTaskBarItem item = e.XPTaskBarItem;
                menuAlokasiDosen.Show(item.Parent as Control, new Point(item.Bounds.Width, item.Bounds.Y));
            }
            else if (e.XPTaskBarItem.Name == "itemAlokasiLabMK")
            {
                if (IsSemesterRemidial())
                {
                    return;
                }
                if (formAlokasiLabMK == null || formAlokasiLabMK.IsDisposed)
                {
                    formAlokasiLabMK = new FormAlokasiLabMK();
                    formAlokasiLabMK.MdiParent = this;
                }
                form = formAlokasiLabMK;
            }
            else if(e.XPTaskBarItem.Name == "itemKoordinatorMk")
            {
                if (IsSemesterRemidial())
                {
                    return;
                }
                if (formKoordinatorMataKuliah == null || formKoordinatorMataKuliah.IsDisposed)
                {
                    formKoordinatorMataKuliah = new FormKoordinatorMataKuliah();
                    formKoordinatorMataKuliah.MdiParent = this;
                }
                form = formKoordinatorMataKuliah;
            }
            else if (e.XPTaskBarItem.Name == "itemTimDosen")
            {
                if (IsSemesterRemidial())
                {
                    return;
                }
                if (formTimDosen == null || formTimDosen.IsDisposed)
                {
                    formTimDosen = new FormTimDosen();
                    formTimDosen.MdiParent = this;
                }
                form = formTimDosen;
            }
            else if (e.XPTaskBarItem.Name == "itemHonorDosen")
            {
                if (formHonorDosen == null || formHonorDosen.IsDisposed)
                {
                    formHonorDosen = new FormHonorDosen();
                    formHonorDosen.MdiParent = this;
                }
                form = formHonorDosen;
            }
            else if (e.XPTaskBarItem.Name == "itemJPDosen")
            {
                if (formJenjangPendidikanDosen == null || formJenjangPendidikanDosen.IsDisposed)
                {
                    formJenjangPendidikanDosen = new FormJenjangPendidikanDosen();
                    formJenjangPendidikanDosen.MdiParent = this;
                }
                form = formJenjangPendidikanDosen;
            }
            else if (e.XPTaskBarItem.Name == "itemSetKonversiMK")
            {
                if (formSetKonversiMK == null || formSetKonversiMK.IsDisposed)
                {
                    formSetKonversiMK = new FormSetKonversiMK();
                    formSetKonversiMK.MdiParent = this;
                }
                form = formSetKonversiMK;
            }
            else if (e.XPTaskBarItem.Name == "itemKonversiMhs")
            {
                if (formMatrikulasiCalonAlihJalur == null || formMatrikulasiCalonAlihJalur.IsDisposed)
                {
                    formMatrikulasiCalonAlihJalur = new FormMatrikulasiCalonAlihJalur();
                    formMatrikulasiCalonAlihJalur.MdiParent = this;
                }
                form = formMatrikulasiCalonAlihJalur;
            }
            else if (e.XPTaskBarItem.Name == "itemKonversiMhsPemutihan")
            {
                if (formKonversiNilaiCalonPemutihan == null || formKonversiNilaiCalonPemutihan.IsDisposed)
                {
                    formKonversiNilaiCalonPemutihan = new FormKonversiNilaiCalonPemutihan();
                    formKonversiNilaiCalonPemutihan.MdiParent = this;
                }
                form = formKonversiNilaiCalonPemutihan;
            }
            else if (e.XPTaskBarItem.Name == "itemLaporanMK")
            {
                XPTaskBarItem item = e.XPTaskBarItem;
                menuLaporanMataKuliah.Show(item.Parent as Control, new Point(item.Bounds.Width, item.Bounds.Y));
            }
            else if (e.XPTaskBarItem.Name == "itemKeluar")
            {
                Application.ExitThread();
            }
            else if (e.XPTaskBarItem.Name == "itemLaporanDosen")
            {
                XPTaskBarItem item = e.XPTaskBarItem;
                menuLaporanDosen.Show(item.Parent as Control, new Point(item.Bounds.Width, item.Bounds.Y));
                //if (formReportAlokasiDosen == null || formReportAlokasiDosen.IsDisposed)
                //{
                //    formReportAlokasiDosen = new FormReportAlokasiDosen();
                //    formReportAlokasiDosen.MdiParent = this;
                //}
                //form = formReportAlokasiDosen;
            }
            else if (e.XPTaskBarItem.Name == "itemLaporanHonorDosen")
            {

                XPTaskBarItem item = e.XPTaskBarItem;
                menuHonorDosen.Show(item.Parent as Control, new Point(item.Bounds.Width, item.Bounds.Y));
            }
            else if (e.XPTaskBarItem.Name == "itemLaporanAlihJalur")
            {
                if (formReportHasilMatrikulasi == null || formReportHasilMatrikulasi.IsDisposed)
                {
                    formReportHasilMatrikulasi = new FormReportHasilMatrikulasi();
                    formReportHasilMatrikulasi.MdiParent = this;
                }
                form = formReportHasilMatrikulasi;
            }
            else if (e.XPTaskBarItem.Name == "itemUpdate")
            {
                InstallUpdateSyncWithInfo();
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
            lblTahunAkademik.Text = string.Format("Tahun Akademik: {0}, Semester: {1}", LoginAccess.TahunAkademik, LoginAccess.Semester);
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

            if (ApplicationDeployment.IsNetworkDeployed)
            {
                stripLabel.Text = string.Format("{0} | Version: {1} | Tahun Akademik {2} Semester {3}", Application.ProductName, ApplicationDeployment.CurrentDeployment.CurrentVersion, LoginAccess.TahunAkademik, LoginAccess.Semester);
            }
            Loading(false);
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

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (formReportDataMK == null || formReportDataMK.IsDisposed)
            {
                formReportDataMK = new FormReportDataMK();
                formReportDataMK.MdiParent = this;
            }
            formReportDataMK.Show();
            tabbedMDIManager1.UpdateActiveTabHost(formReportDataMK);
        }

        private void mataKuliahPrasyaratToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (formReportMKPrasyarat == null || formReportMKPrasyarat.IsDisposed)
            {
                formReportMKPrasyarat = new FormReportMKPrasyarat();
                formReportMKPrasyarat.MdiParent = this;
            }
            formReportMKPrasyarat.Show();
            tabbedMDIManager1.UpdateActiveTabHost(formReportMKPrasyarat);
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (formReportAlokasiMK == null || formReportAlokasiMK.IsDisposed)
            {
                formReportAlokasiMK = new FormReportAlokasiMK();
                formReportAlokasiMK.MdiParent = this;
            }
            formReportAlokasiMK.Show();
            tabbedMDIManager1.UpdateActiveTabHost(formReportAlokasiMK);
        }

        private void alokasiLabToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (formReportAlokasiLabMK == null || formReportAlokasiLabMK.IsDisposed)
            {
                formReportAlokasiLabMK = new FormReportAlokasiLabMK();
                formReportAlokasiLabMK.MdiParent = this;
            }
            formReportAlokasiLabMK.Show();
            tabbedMDIManager1.UpdateActiveTabHost(formReportAlokasiLabMK);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            countDown = countDown - 1;
            time = TimeSpan.FromSeconds(countDown);
            stripLabelSession.Text = string.Format("{0} {1}", "Sesi anda akan habis dalam: ", time.ToString(@"hh\:mm\:ss"));

            if (countDown <= 0)
            {
                timer1.Enabled = false;
                MessageBox.Show("Sesi anda telah habis, silahkan login kembali");
                Application.Restart();
            }
        }

        private void alokasiDosenMengajarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (formReportAlokasiDosen == null || formReportAlokasiDosen.IsDisposed)
            {
                formReportAlokasiDosen = new FormReportAlokasiDosen();
                formReportAlokasiDosen.MdiParent = this;
            }
            formReportAlokasiDosen.Show();
            tabbedMDIManager1.UpdateActiveTabHost(formReportAlokasiDosen);
        }

        private void kesanggupanDosenMengajarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (formReportKesanggupanDosen == null || formReportKesanggupanDosen.IsDisposed)
            {
                formReportKesanggupanDosen = new FormReportKesanggupanDosen();
                formReportKesanggupanDosen.MdiParent = this;
            }
            formReportKesanggupanDosen.Show();
            tabbedMDIManager1.UpdateActiveTabHost(formReportKesanggupanDosen);
        }

        private void kesediaanDosenMengajarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (formReportKesediaanDosen == null || formReportKesediaanDosen.IsDisposed)
            {
                formReportKesediaanDosen = new FormReportKesediaanDosen();
                formReportKesediaanDosen.MdiParent = this;
            }
            formReportKesediaanDosen.Show();
            tabbedMDIManager1.UpdateActiveTabHost(formReportKesediaanDosen);
        }

        private void dosenWaliToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (formReportDosenWali == null || formReportDosenWali.IsDisposed)
            {
                formReportDosenWali = new FormReportDosenWali();
                formReportDosenWali.MdiParent = this;
            }
            formReportDosenWali.Show();
            tabbedMDIManager1.UpdateActiveTabHost(formReportDosenWali);
        }

        private bool IsSemesterRemidial()
        {
            if (LoginAccess.KodeSemester == 7 || LoginAccess.KodeSemester == 8)
            {
                MessageBox.Show("Fitur hanya untuk semester reguler");
                return true;
            }
            return false;
        }

        private void prodiRegulerToolStripItem_Click(object sender, EventArgs e)
        {
            if (formAlokasiMK == null || formAlokasiMK.IsDisposed)
            {
                formAlokasiMK = new FormAlokasiMK();
                formAlokasiMK.MdiParent = this;
            }
            formAlokasiMK.Show();
            tabbedMDIManager1.UpdateActiveTabHost(formAlokasiMK);
        }

        private void ProdiStudentExchangeToolStripItem_Click(object sender, EventArgs e)
        {
            if (formAlokasiMKStudentExchange == null || formAlokasiMKStudentExchange.IsDisposed)
            {
                formAlokasiMKStudentExchange = new FormAlokasiMKStudentExchange();
                formAlokasiMKStudentExchange.MdiParent = this;
            }
            formAlokasiMKStudentExchange.Show();
            tabbedMDIManager1.UpdateActiveTabHost(formAlokasiMKStudentExchange);
        }

        private void InstallUpdateSyncWithInfo()
        {
            UpdateCheckInfo info = null;

            if (ApplicationDeployment.IsNetworkDeployed)
            {
                ApplicationDeployment ad = ApplicationDeployment.CurrentDeployment;

                try
                {
                    info = ad.CheckForDetailedUpdate();

                }
                catch (DeploymentDownloadException dde)
                {
                    MessageBox.Show("The new version of the application cannot be downloaded at this time. \n\nPlease check your network connection, or try again later. Error: " + dde.Message);
                    return;
                }
                catch (InvalidDeploymentException ide)
                {
                    MessageBox.Show("Cannot check for a new version of the application. The ClickOnce deployment is corrupt. Please redeploy the application and try again. Error: " + ide.Message);
                    return;
                }
                catch (InvalidOperationException ioe)
                {
                    MessageBox.Show("This application cannot be updated. It is likely not a ClickOnce application. Error: " + ioe.Message);
                    return;
                }

                if (info.UpdateAvailable)
                {
                    bool doUpdate = true;

                    if (!info.IsUpdateRequired)
                    {
                        DialogResult dr = MessageBox.Show("An update is available. Would you like to update the application now?", "Update Available", MessageBoxButtons.OKCancel);
                        if (!(DialogResult.OK == dr))
                        {
                            doUpdate = false;
                        }
                    }
                    else
                    {
                        // Display a message that the app MUST reboot. Display the minimum required version.
                        MessageBox.Show("This application has detected a mandatory update from your current " +
                            "version to version " + info.MinimumRequiredVersion.ToString() +
                            ". The application will now install the update and restart.",
                            "Update Available", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }

                    if (doUpdate)
                    {
                        try
                        {
                            ad.Update();
                            MessageBox.Show("The application has been upgraded, and will now restart.");
                            Application.Restart();
                        }
                        catch (DeploymentDownloadException dde)
                        {
                            MessageBox.Show("Cannot install the latest version of the application. \n\nPlease check your network connection, or try again later. Error: " + dde);
                            return;
                        }
                    }
                }
            }
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            if (formReportHonorDosenMengajar2 == null || formReportHonorDosenMengajar2.IsDisposed)
            {
                formReportHonorDosenMengajar2 = new FormReportHonorDosenMengajar2();
                formReportHonorDosenMengajar2.MdiParent = this;
            }
            formReportHonorDosenMengajar2.Show();
            tabbedMDIManager1.UpdateActiveTabHost(formReportHonorDosenMengajar2);
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            if (formReportHonorDosenKoreksi == null || formReportHonorDosenKoreksi.IsDisposed)
            {
                formReportHonorDosenKoreksi = new FormReportHonorDosenKoreksi();
                formReportHonorDosenKoreksi.MdiParent = this;
            }
            formReportHonorDosenKoreksi.Show();
            tabbedMDIManager1.UpdateActiveTabHost(formReportHonorDosenKoreksi);
        }
    }
}
