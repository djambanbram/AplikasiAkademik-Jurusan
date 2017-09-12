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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PenawaranKurikulum.Report
{
    public partial class FormReportAlokasiDosen : Syncfusion.Windows.Forms.MetroForm
    {
        public static string baseAddress = ConfigurationManager.AppSettings["baseAddress"];
        private string URLGetDepartment = baseAddress + "/jurusan_api/api/organisasi/get_department";
        private string URLGetDosenMengajar = baseAddress + "/jurusan_api/api/pengajaran/get_dosen_mengajar";
        private string URLGetDosenMengajarAll = baseAddress + "/jurusan_api/api/pengajaran/get_dosen_mengajar_all";

        private List<Fakultas> listFakultas;
        private List<Prodi> listProdi;
        private List<Program> listProgram;
        private List<Department> listDepartment;
        private WebApi webApi;
        private HttpResponseMessage response;
        private List<KesanggupanMengajar> listDosenMengajarAll;

        public FormReportAlokasiDosen()
        {
            InitializeComponent();
            webApi = new WebApi();
        }

        private void btnTutup_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Loading(bool isLoading)
        {
            reportViewer1.Enabled = !isLoading;
            gradientPanel2.Enabled = !isLoading;
            flowLayoutPanel1.Enabled = !isLoading;

            progressBar1.Visible = isLoading;
        }

        private async void FormReportAlokasiDosen_Load(object sender, EventArgs e)
        {
            listFakultas = new List<Fakultas>(Organisasi.listFakultas);
            listFakultas.Insert(0, new Fakultas() { KodeFakultas = "-", NamaFakultas = "Pilih" });
            listFakultas.Insert(1, new Fakultas() { KodeFakultas = "-", NamaFakultas = "Semua Fakultas" });
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

        private async void cmbFakultas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbFakultas.SelectedIndex > 0)
            {
                if (cmbFakultas.SelectedIndex == 1)
                {
                    cmbProdi.Enabled = false;
                    cmbProgram.Enabled = false;
                    await PreviewDosen(true);
                }
                else
                {
                    cmbProdi.Enabled = true;
                    cmbProgram.Enabled = true;
                    string kodeFakultas = cmbFakultas.SelectedValue.ToString();
                    listProdi = Organisasi.listProdi.Where(pr => pr.Fakultas.KodeFakultas == kodeFakultas).ToList();
                    listProdi.Insert(0, new Prodi() { IdProdi = "-", NamaProdi = "Pilih" });
                    cmbProdi.DataSource = listProdi;
                    cmbProdi.DisplayMember = "NamaProdi";
                    cmbProdi.ValueMember = "Uid";
                    cmbProdi.SelectedIndex = 0;
                }
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
            await PreviewDosen(false);
        }

        private async Task PreviewDosen(bool isSemuaFakultas)
        {
            var data = new { TahunAkademik = LoginAccess.TahunAkademik, Semester = LoginAccess.KodeSemester };
            string jsonData = JsonConvert.SerializeObject(data);

            response = await webApi.Post(URLGetDosenMengajarAll, jsonData, true);
            if (!response.IsSuccessStatusCode)
            {
                Loading(false);
                MessageBox.Show(webApi.ReturnMessage(response));
                return;
            }

            listDosenMengajarAll = JsonConvert.DeserializeObject<List<KesanggupanMengajar>>(response.Content.ReadAsStringAsync().Result);
            if (listDosenMengajarAll == null)
            {
                Loading(false);
                MessageBox.Show("Dosen belum teralokasi oleh prodi");
                return;
            }
            if (listDosenMengajarAll.Count == 0)
            {
                Loading(false);
                MessageBox.Show("Dosen belum teralokasi oleh prodi");
                return;
            }

            List<KesediaanDosen> listKesediaanDosen = new List<KesediaanDosen>();
            List<ReportParameter> listParams = new List<ReportParameter>();
            if (isSemuaFakultas)
            {
                var listNikDosen = listDosenMengajarAll
                    .Select(x => new { x.NamaAlias, x.KodeKelas, x.KodeFakultas, x.NIK, x.NamaDosen, x.Kode, x.MataKuliah, x.Jenjang, x.JenisMataKuliah, x.SksTeori, x.SksTotal, x.SksPraktikum, x.IdProdi, x.NamaProdi, x.KodeProgram, x.SemesterDitawarkan, x.NamaProgram })
                    .Select(y => new { y.NamaAlias, y.KodeKelas, y.KodeFakultas, y.NIK, y.NamaDosen, y.Kode, y.MataKuliah, y.Jenjang, JenisMataKuliah = (y.SksPraktikum == 0 ? "T" : y.SksPraktikum == y.SksTotal ? "P" : "TP"), y.SksTeori, y.SksPraktikum, y.SksTotal, y.IdProdi, y.NamaProdi, y.KodeProgram, y.SemesterDitawarkan, y.NamaProgram })
                    .Distinct()
                    .OrderBy(o => o.NamaDosen).ThenBy(p => p.KodeKelas).ThenBy(q => q.MataKuliah);


                int no = 0;
                var tempNik = string.Empty;
                foreach (var item in listNikDosen)
                {
                    int countKelas = listDosenMengajarAll.Where(w => w.NIK == item.NIK && w.Kode == item.Kode && w.Jenjang == item.Jenjang && w.KodeProgram == item.KodeProgram).ToList().Count;

                    if (tempNik != item.NIK)
                    {
                        tempNik = item.NIK;
                        no++;
                    }
                    listKesediaanDosen.Add(new KesediaanDosen()
                    {
                        NIK = item.NIK,
                        NamaDosen = item.NamaDosen,
                        Kode = item.Kode,
                        MataKuliah = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(item.MataKuliah.ToLower()),
                        Jenjang = item.Jenjang,
                        JenisMataKuliah = item.JenisMataKuliah,
                        TotalSks = item.SksTotal,
                        SksTeori = item.SksTeori,
                        SksPraktikum = item.SksPraktikum,
                        NamaProdi = item.NamaProdi,
                        KodeProgram = item.KodeProgram,
                        SemesterDitawarkan = item.SemesterDitawarkan,
                        KodeFakultas = item.KodeFakultas,
                        JumlahKelas = countKelas,
                        KodeKelas = item.NamaAlias,
                        No = no.ToString()
                    });
                }
                listParams.Add(new ReportParameter("HeaderTahun", string.Format("LAMPIRAN TUGAS MENGAJAR DOSEN \nTAHUN AKADEMIK {0} SEMESTER {1}", LoginAccess.TahunAkademik, LoginAccess.Semester.ToString().ToUpper())));
                listParams.Add(new ReportParameter("TanggalPengesahan", DateTime.Now.ToString("d MMMM yyyy", CultureInfo.GetCultureInfo("id-ID"))));
                listParams.Add(new ReportParameter("IsAllFakultas", "1"));
            }
            else
            {
                var listNikDosen = listDosenMengajarAll
                    .Select(x => new { x.NamaAlias, x.KodeKelas, x.KodeFakultas, x.NIK, x.NamaDosen, x.Kode, x.MataKuliah, x.Jenjang, x.JenisMataKuliah, x.SksTeori, x.SksTotal, x.SksPraktikum, x.IdProdi, x.NamaProdi, x.KodeProgram, x.SemesterDitawarkan, x.NamaProgram })
                    .Select(y => new { y.NamaAlias, y.KodeKelas, y.KodeFakultas, y.NIK, y.NamaDosen, y.Kode, y.MataKuliah, y.Jenjang, JenisMataKuliah = (y.SksPraktikum == 0 ? "T" : y.SksPraktikum == y.SksTotal ? "P" : "TP"), y.SksTeori, y.SksPraktikum, y.SksTotal, y.IdProdi, y.NamaProdi, y.KodeProgram, y.SemesterDitawarkan, y.NamaProgram })
                    .Distinct().Where(w => w.KodeProgram == cmbProgram.SelectedValue.ToString())
                    .OrderBy(o => o.NamaDosen).ThenBy(p => p.KodeKelas).ThenBy(q => q.MataKuliah);

                int no = 0;
                var tempNik = string.Empty;
                foreach (var item in listNikDosen)
                {
                    int countKelas = listDosenMengajarAll.Where(w => w.NIK == item.NIK && w.Kode == item.Kode && w.Jenjang == item.Jenjang && w.KodeProgram == cmbProgram.SelectedValue.ToString()).ToList().Count;

                    if (tempNik != item.NIK)
                    {
                        tempNik = item.NIK;
                        no++;
                    }
                    listKesediaanDosen.Add(new KesediaanDosen()
                    {
                        NIK = item.NIK,
                        NamaDosen = item.NamaDosen,
                        Kode = item.Kode,
                        MataKuliah = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(item.MataKuliah.ToLower()),
                        Jenjang = item.Jenjang,
                        JenisMataKuliah = item.JenisMataKuliah,
                        TotalSks = item.SksTotal,
                        SksTeori = item.SksTeori,
                        SksPraktikum = item.SksPraktikum,
                        NamaProdi = item.NamaProdi,
                        KodeProgram = item.KodeProgram,
                        SemesterDitawarkan = item.SemesterDitawarkan,
                        KodeFakultas = item.KodeFakultas,
                        JumlahKelas = countKelas,
                        KodeKelas = item.NamaAlias,
                        No = no.ToString()
                    });
                }
                string KodeProgramReguler = Organisasi.listProdi.Find(pr => pr.Uid == cmbProdi.SelectedValue.ToString()).KodeProgramReguler;
                listParams.Add(new ReportParameter("HeaderTahun", string.Format("LAMPIRAN TUGAS MENGAJAR DOSEN \nTAHUN AKADEMIK {0} SEMESTER {1}\n{2}\nPROGRAM STUDI {3}\nPROGRAM {4}", LoginAccess.TahunAkademik, LoginAccess.Semester.ToString().ToUpper(), cmbFakultas.Text.ToUpper(), cmbProdi.Text.ToUpper(), cmbProgram.Text.ToUpper())));
                listParams.Add(new ReportParameter("TanggalPengesahan", DateTime.Now.ToString("d MMMM yyyy", CultureInfo.GetCultureInfo("id-ID"))));
                listParams.Add(new ReportParameter("IsAllFakultas", "0"));
                listParams.Add(new ReportParameter("Prodi", cmbProdi.Text));
                listParams.Add(new ReportParameter("Kaprodi", listDepartment.Find(d => d.KodeDepartment == KodeProgramReguler).NamaKepala));
                listParams.Add(new ReportParameter("NikKaprodi", listDepartment.Find(d => d.KodeDepartment == KodeProgramReguler).NikKepala));
            }

            string DataSetName = string.Empty;
            string ReportPath = string.Empty;
            ReportDataSource rds = null;
            ReportPath = "PenawaranKurikulum.ReportVieew.ReportAlokasiDosenAll.rdlc";
            rds = new ReportDataSource("DsAlokasiDosenAll", listKesediaanDosen);
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(rds);
            reportViewer1.LocalReport.ReportEmbeddedResource = ReportPath;
            reportViewer1.LocalReport.SetParameters(listParams);
            reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
            reportViewer1.ZoomMode = ZoomMode.Percent;
            reportViewer1.LocalReport.Refresh();
            reportViewer1.RefreshReport();

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
        public string IdProdi { get; set; }
        public string NamaProdi { get; set; }
        public string KodeProgramReguler { get; set; }
        public string KodeProgram { get; set; }
        public string NamaProgram { get; set; }
    }

    class KesediaanDosen : AlokasiDosenAll
    {
        public int JumlahKelas { get; set; }
        public int TotalSks { get; set; }
        public string Kode { get; set; }
        public string MataKuliah { get; set; }
        public int SksTeori { get; set; }
        public int SksPraktikum { get; set; }
        public string JenisMataKuliah { get; set; }
        public int SemesterDitawarkan { get; set; }
        public string No { get; set; }
    }
}
