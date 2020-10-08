#region Copyright Syncfusion Inc. 2001 - 2016
// Copyright Syncfusion Inc. 2001 - 2016. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using ApiService;
using ClassModel;
using KonversiAlihJalur.Lib;
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

namespace KonversiAlihJalur.Report
{
    public partial class FormReportHasilMatrikulasiPemutihan : Syncfusion.Windows.Forms.MetroForm
    {
        public static string baseAddress = ConfigurationManager.AppSettings["baseAddress"];
        private string URLGetHasilMatrikulasiMhs = baseAddress + "/jurusan_api/api/pemutihan/get_hasil_matrikulasi_mhs_pemutihan";
        private string URLGetDepartment = baseAddress + "/jurusan_api/api/organisasi/get_department";
        
        private List<HasilMatrikulasiMhs> listHasilMatrikulasi;
        private List<Department> listDepartment;

        private List<Fakultas> listFakultas;
        private List<Prodi> listProdi;
        private List<Program> listProgram;

        private WebApi webApi;
        private HttpResponseMessage response;

        private bool isPilihSemua;

        public FormReportHasilMatrikulasiPemutihan()
        {
            InitializeComponent();
            webApi = new WebApi();
        }

        private void Loading(bool isLoading)
        {
            reportViewer1.Enabled = !isLoading;
            gradientPanel1.Enabled = !isLoading;
            gradientPanel2.Enabled = !isLoading;
            flowLayoutPanel1.Enabled = !isLoading;
        }

        private async void FormReportHasilMatrikulasi_Load(object sender, EventArgs e)
        {
            listFakultas = new List<Fakultas>(Organisasi.listFakultas);
            listFakultas.Insert(0, new Fakultas() { KodeFakultas = "-", NamaFakultas = "Pilih" });
            cmbFakultas.DataSource = listFakultas;
            cmbFakultas.DisplayMember = "NamaFakultas";
            cmbFakultas.ValueMember = "KodeFakultas";
            cmbFakultas.SelectedIndex = 0;

            for (int i = DateTime.Now.Year; i > DateTime.Now.Year - 10; i--)
            {
                cmbAngkatan.Items.Add(i.ToString());
            }
            cmbAngkatan.Items.Insert(0, "Pilih");
            cmbAngkatan.SelectedIndex = 0;

            //listProgram = Organisasi.listProgram.ToList();
            //listProgram.Insert(0, new Program() { KodeProgram = "-", NamaProgram = "Pilih" });
            //cmbProgramAlihJalur.DataSource = listProgram;
            //cmbProgramAlihJalur.DisplayMember = "NamaProgram";
            //cmbProgramAlihJalur.ValueMember = "KodeProgram";
            //cmbProgramAlihJalur.SelectedIndex = 0;

            //for (int i = DateTime.Now.Year; i > DateTime.Now.Year - 10; i--)
            //{
            //    cmbAngkatan.Items.Add(i.ToString());
            //}
            //cmbAngkatan.Items.Insert(0, "Pilih");
            //cmbAngkatan.SelectedIndex = 0;


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

        private void btnTutup_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void cmbAngkatan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbAngkatan.SelectedIndex <= 0)
            {
                dgvMhs.Rows.Clear();
                return;
            }

            var dataGet = new { KodeProgram = cmbProgramAlihJalur.SelectedValue.ToString(), Angkatan = cmbAngkatan.Text };
            var jsonData = JsonConvert.SerializeObject(dataGet);

            Loading(true);
            response = await webApi.Post(URLGetHasilMatrikulasiMhs, jsonData, true);
            if (!response.IsSuccessStatusCode)
            {
                MessageBox.Show(webApi.ReturnMessage(response));
                Loading(false);
                return;
            }
            listHasilMatrikulasi = JsonConvert.DeserializeObject<List<HasilMatrikulasiMhs>>(response.Content.ReadAsStringAsync().Result);
            var tempNpm = string.Empty;
            var tempNomor = 0;
            foreach (HasilMatrikulasiMhs h in listHasilMatrikulasi)
            {
                if (tempNpm != h.Nodaf)
                {
                    tempNomor = 1;
                    h.Nomor = tempNomor;
                    tempNpm = h.Nodaf;
                }
                else
                {
                    tempNomor++;
                    h.Nomor = tempNomor;
                }
            }
            var listTemp = listHasilMatrikulasi.Select(h => new { h.Nodaf, h.NpmLama, h.Nama }).Distinct().ToList();
            dgvMhs.Rows.Clear();
            int no = 1;
            foreach (var item in listTemp)
            {
                var tempSksTotal = listHasilMatrikulasi.Where(h => h.Nodaf == item.Nodaf).Select(h => new { h.Kode, h.MataKuliah, h.Sks }).Distinct().Sum(h => int.Parse(h.Sks));
                listHasilMatrikulasi.Where(h => h.Nodaf == item.Nodaf).ToList().ForEach(delegate(HasilMatrikulasiMhs hasil)
                {
                    hasil.SksTotalKonversi = tempSksTotal;
                });
                dgvMhs.Rows.Add(no, item.Nodaf, item.NpmLama, item.Nama, false, tempSksTotal);
                no++;
            }

            Loading(false);
        }

        private void dgvMhs_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex != 2)
            {
                return;
            }
            if (dgvMhs.Rows.Count == 0)
            {
                return;
            }

            isPilihSemua = !isPilihSemua;
            foreach (DataGridViewRow row in dgvMhs.Rows)
            {
                row.Cells["Pilih"].Value = false;
                row.Cells["Pilih"].Value = !isPilihSemua;
            }
        }

        private void printSemuaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadReport(true);
        }

        private void printDipilihToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadReport(false);
        }

        private void LoadReport(bool isPilihSemua)
        {
            string kodeProdiAsal = string.Empty;
            if (cmbProgramAlihJalur.SelectedValue.ToString() == "21")
            {
                kodeProdiAsal = "11";
            }
            else if (cmbProgramAlihJalur.SelectedValue.ToString() == "22")
            {
                kodeProdiAsal = "12";
            }
            else
            {
                kodeProdiAsal = cmbProgramAlihJalur.SelectedValue.ToString();
            }
            //kodeProdiAsal = cmbProgramAlihJalur.SelectedValue.ToString();
            List<ReportParameter> listParams = new List<ReportParameter>();
            listParams.Add(new ReportParameter("Prodi", CultureInfo.CurrentCulture.TextInfo.ToTitleCase(listDepartment.Find(d => d.KodeDepartment == kodeProdiAsal).NamaDepartment.ToLower())));
            listParams.Add(new ReportParameter("TanggalCetak", CultureInfo.CurrentCulture.TextInfo.ToTitleCase(DateTime.Now.ToString("d MMMM yyyy", CultureInfo.GetCultureInfo("id-ID")))));
            listParams.Add(new ReportParameter("Kaprodi", listDepartment.Find(d => d.KodeDepartment == kodeProdiAsal).NamaKepala));
            listParams.Add(new ReportParameter("NikKaprodi", listDepartment.Find(d => d.KodeDepartment == kodeProdiAsal).NikKepala));
            listParams.Add(new ReportParameter("Angkatan", cmbAngkatan.Text));

            DataTable dtHasilMAtrikulasi = null;
            if (isPilihSemua)
            {
                dtHasilMAtrikulasi = CommonLib.ToDataTable(listHasilMatrikulasi);
            }
            else
            {
                List<HasilMatrikulasiMhs> listTemp = new List<HasilMatrikulasiMhs>();
                foreach (DataGridViewRow row in dgvMhs.Rows)
                {
                    if (Convert.ToBoolean(row.Cells["Pilih"].Value) == true)
                    {
                        foreach (HasilMatrikulasiMhs h in listHasilMatrikulasi)
                        {
                            if (h.Nodaf == row.Cells["Nodaf"].Value.ToString())
                            {
                                h.SksTotalKonversi = int.Parse(row.Cells["SksTotal"].Value.ToString());
                                listTemp.Add(h);
                            }
                        }
                    }
                }

                dtHasilMAtrikulasi = CommonLib.ToDataTable(listTemp);
            }

            reportViewer1.LocalReport.SetParameters(listParams);
            IDataReader dr = dtHasilMAtrikulasi.CreateDataReader();
            dataSetAlihJalur.Tables["HasilMatrikulasi"].Clear();
            dataSetAlihJalur.Tables["HasilMatrikulasi"].Load(dr);
            dr.Close();
            reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
            reportViewer1.ZoomMode = ZoomMode.PageWidth;
            reportViewer1.LocalReport.Refresh();
            reportViewer1.RefreshReport();
        }

        private void dgvMhs_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != 4)
            {
                return;
            }

            //DataGridViewCheckBoxCell cb = dgvMhs.Rows[e.RowIndex].Cells["Pilih"] as DataGridViewCheckBoxCell;
            //cb.Value = !bool.Parse(cb.Value.ToString());
            dgvMhs.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void cmbFakultas_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvMhs.Rows.Clear();

            if (cmbFakultas.SelectedIndex > 0)
            {
                string kodeFakultas = cmbFakultas.SelectedValue.ToString();
                listProdi = Organisasi.listProdi.Where(pr => pr.Fakultas.KodeFakultas == kodeFakultas).
                            OrderBy(pr => pr.Jenjang)
                            .ThenBy(pr => pr.NamaProdi)
                            .ToList();
                listProdi.Insert(0, new Prodi() { IdProdi = "-", NamaProdi = "Pilih" });
                cmbProdi.DataSource = listProdi;
                cmbProdi.DisplayMember = "NamaProdi";
                cmbProdi.ValueMember = "Uid";
                cmbProdi.SelectedIndex = 0;
            }
        }

        private void cmbProdi_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvMhs.Rows.Clear();
            if (cmbFakultas.SelectedIndex > 0 && cmbProdi.SelectedIndex > 0)
            {
                string idProdi = cmbProdi.SelectedValue.ToString();
                listProgram = Organisasi.listProgram.Where(program => program.Prodi.Uid == idProdi).ToList();
                listProgram.Insert(0, new Program() { KodeProgram = "-", NamaProgram = "Pilih" });
                cmbProgramAlihJalur.DataSource = listProgram;
                cmbProgramAlihJalur.DisplayMember = "NamaProgram";
                cmbProgramAlihJalur.ValueMember = "KodeProgram";
                cmbProgramAlihJalur.SelectedIndex = 0;
            }
        }
    }
}
