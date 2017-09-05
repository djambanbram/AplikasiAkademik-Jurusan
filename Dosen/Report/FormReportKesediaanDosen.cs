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
using System.Windows.Forms;

namespace Dosen.Report
{
    public partial class FormReportKesediaanDosen : Syncfusion.Windows.Forms.MetroForm
    {
        public static string baseAddress = ConfigurationManager.AppSettings["baseAddress"];
        private string URLGetDepartment = baseAddress + "/jurusan_api/api/organisasi/get_department";
        private string URLGetDosenMengajar = baseAddress + "/jurusan_api/api/pengajaran/get_dosen_mengajar_all";

        private List<Department> listDepartment;
        private List<Fakultas> listFakultas;
        private List<Prodi> listProdi;
        private List<Program> listProgram;

        private WebApi webApi;
        private HttpResponseMessage response;

        private List<KesanggupanMengajar> listDosenMengajarAll;

        public string kodeProgramDipilih;
        public string idProdiDipilih;

        public FormReportKesediaanDosen()
        {
            InitializeComponent();
            webApi = new WebApi();
        }

        private void Loading(bool isLoading)
        {
            reportViewer1.Enabled = !isLoading;
            gradientPanel1.Enabled = !isLoading;
            flowLayoutPanel1.Enabled = !isLoading;

            progressBar1.Visible = isLoading;
        }

        private async void FormReportKesediaanDosen_Load(object sender, EventArgs e)
        {
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

            var data = new { TahunAkademik = LoginAccess.TahunAkademik, Semester = LoginAccess.KodeSemester };
            string jsonData = JsonConvert.SerializeObject(data);

            response = await webApi.Post(URLGetDosenMengajar, jsonData, true);
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
            Loading(false);
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
            kodeProgramDipilih = null;
            idProdiDipilih = null;
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

        private void cmbProgram_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbProgram.SelectedIndex <= 0)
            {
                dgvDataDosen.Rows.Clear();
                return;
            }

            kodeProgramDipilih = cmbProgram.SelectedValue.ToString();
            idProdiDipilih = cmbProdi.SelectedValue.ToString();


            dgvDataDosen.Rows.Clear();
            var listNikDosen = listDosenMengajarAll
                .Select(x => new { x.NIK, x.NamaDosen, x.Kode, x.MataKuliah, x.Jenjang, x.JenisMataKuliah, x.SksTotal, x.SksPraktikum, x.IdProdi, x.KodeProgram })
                .Select(y => new { y.NIK, y.NamaDosen, y.Kode, y.MataKuliah, y.Jenjang, JenisMataKuliah = (y.SksPraktikum == 0 ? "T" : y.SksPraktikum == y.SksTotal ? "P" : "TP"), y.SksTotal, y.IdProdi, y.KodeProgram })
                .Distinct().Where(z => z.KodeProgram == kodeProgramDipilih)
                .OrderBy(o => o.NamaDosen);

            int i = 1;
            foreach (var item in listNikDosen)
            {
                int countKelas = listDosenMengajarAll.Where(w => w.NIK == item.NIK && w.Kode == item.Kode && w.Jenjang == item.Jenjang && w.KodeProgram == kodeProgramDipilih).ToList().Count;
                dgvDataDosen.Rows.Add(i, item.NIK, item.NamaDosen, item.MataKuliah, false, item.Jenjang, item.Kode, item.SksTotal, countKelas, item.JenisMataKuliah);
                i++;
            }

            dgvDataDosen.PerformLayout();
        }

        private void cetakSemuaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (cmbProgram.SelectedIndex > 0 && dgvDataDosen.Rows.Count > 0)
            {
                PreviewReport(true);
            }
        }

        private void cetakDipilihToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (cmbProgram.SelectedIndex > 0 && dgvDataDosen.Rows.Count > 0)
            {
                PreviewReport(false);
            }
        }

        private void PreviewReport(bool isCetakSemua)
        {
            List<KesediaanDosen> listKesediaanDosen = new List<KesediaanDosen>();

            if (dgvDataDosen.Rows.Count == 0)
            {
                return;
            }

            dgvDataDosen.PerformLayout();
            if (isCetakSemua)
            {
                foreach (DataGridViewRow row in dgvDataDosen.Rows)
                {
                    listKesediaanDosen.Add(new KesediaanDosen()
                    {
                        NIK = row.Cells["NIK"].Value.ToString(),
                        NamaDosen = row.Cells["NamaDosen"].Value.ToString(),
                        Jenjang = row.Cells["Jenjang"].Value.ToString(),
                        MataKuliah = row.Cells["MataKuliah"].Value.ToString(),
                        Kode = row.Cells["Kode"].Value.ToString(),
                        Sks = int.Parse(row.Cells["Sks"].Value.ToString()),
                        JenisMataKuliah = row.Cells["JenisKuliah"].Value.ToString(),
                        JumlahKelas = int.Parse(row.Cells["Jumlahkelas"].Value.ToString()),
                        TotalSks = int.Parse(row.Cells["Sks"].Value.ToString()) * int.Parse(row.Cells["Jumlahkelas"].Value.ToString())
                    });
                }
            }
            else
            {
                foreach (DataGridViewRow row in dgvDataDosen.Rows)
                {
                    DataGridViewCheckBoxCell cb = row.Cells["Pilih"] as DataGridViewCheckBoxCell;
                    if (bool.Parse(cb.Value.ToString()))
                    {
                        listKesediaanDosen.Add(new KesediaanDosen()
                        {
                            NIK = row.Cells["NIK"].Value.ToString(),
                            NamaDosen = row.Cells["NamaDosen"].Value.ToString(),
                            Jenjang = row.Cells["Jenjang"].Value.ToString(),
                            MataKuliah = row.Cells["MataKuliah"].Value.ToString(),
                            Kode = row.Cells["Kode"].Value.ToString(),
                            Sks = int.Parse(row.Cells["Sks"].Value.ToString()),
                            JenisMataKuliah = row.Cells["JenisKuliah"].Value.ToString(),
                            JumlahKelas = int.Parse(row.Cells["Jumlahkelas"].Value.ToString()),
                            TotalSks = int.Parse(row.Cells["Sks"].Value.ToString()) * int.Parse(row.Cells["Jumlahkelas"].Value.ToString())
                        });
                    }
                }
            }


            List<ReportParameter> listParams = new List<ReportParameter>();

            listParams.Add(new ReportParameter("TglPengesahan", CultureInfo.CurrentCulture.TextInfo.ToTitleCase(DateTime.Now.ToString("    MMMM yyyy", CultureInfo.GetCultureInfo("id-ID")))));
            listParams.Add(new ReportParameter("Semester", LoginAccess.Semester));
            listParams.Add(new ReportParameter("TahunAkademik", LoginAccess.TahunAkademik));
            listParams.Add(new ReportParameter("Prodi", cmbProdi.Text));
            listParams.Add(new ReportParameter("Program", cmbProgram.Text));

            DataTable dtAlokasiDosen = CommonLib.ToDataTable(listKesediaanDosen);

            reportViewer1.LocalReport.SetParameters(listParams);
            IDataReader dr = dtAlokasiDosen.CreateDataReader();
            dsDosen.Tables["KesediaanDosenMengajar"].Clear();
            dsDosen.Tables["KesediaanDosenMengajar"].Load(dr);
            dr.Close();
            reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
            reportViewer1.ZoomMode = ZoomMode.Percent;
            reportViewer1.LocalReport.Refresh();
            reportViewer1.RefreshReport();
        }

        private void dgvDataDosen_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != 4)
            {
                return;
            }

            DataGridViewCheckBoxCell cb = dgvDataDosen.Rows[e.RowIndex].Cells["Pilih"] as DataGridViewCheckBoxCell;
            cb.Value = !bool.Parse(cb.Value.ToString());
        }
    }

    class KesediaanDosen : AlokasiDosenAll
    {
        public int JumlahKelas { get; set; }
        public int TotalSks { get; set; }
        public string Kode { get; set; }
        public string MataKuliah { get; set; }
        public int Sks { get; set; }
        public string JenisMataKuliah { get; set; }
    }
}
