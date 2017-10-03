#region Copyright Syncfusion Inc. 2001 - 2016
// Copyright Syncfusion Inc. 2001 - 2016. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using ApiService;
using ClassModel;
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
    public partial class FormReportHonorDosenMengajar2 : Syncfusion.Windows.Forms.MetroForm
    {
        public static string baseAddress = ConfigurationManager.AppSettings["baseAddress"];
        private string URLGetTahunAkademik = baseAddress + "/jurusan_api/api/data_support/init_tahun_akademik";
        private string URLGetSemester = baseAddress + "/jurusan_api/api/data_support/init_data_semester";
        private string URLGethonorDosenMengajar = baseAddress + "/jurusan_api/api/dosen/get_honor_dosen_mengajar";

        private WebApi webApi;
        private HttpResponseMessage response;

        private List<Fakultas> listFakultas;
        private List<Prodi> listProdi;
        private List<Program> listProgram;
        private List<HonorMengajarDosen> listHonorDosenMengajar;

        public FormReportHonorDosenMengajar2()
        {
            InitializeComponent();
            webApi = new WebApi();
        }

        private void Loading(bool isLoading)
        {
            flowLayoutPanel1.Enabled = !isLoading;
            dgvHonor.Enabled = !isLoading;
            gradientPanel1.Enabled = !isLoading;
            progressBar1.Visible = isLoading;
        }

        private async void FormHonorDosenMengajar2_Load(object sender, EventArgs e)
        {
            listFakultas = new List<Fakultas>(Organisasi.listFakultas);
            listFakultas.Insert(0, new Fakultas() { KodeFakultas = "-", NamaFakultas = "Pilih" });
            cmbFakultas.DataSource = listFakultas;
            cmbFakultas.DisplayMember = "NamaFakultas";
            cmbFakultas.ValueMember = "KodeFakultas";
            cmbFakultas.SelectedIndex = 0;


            Loading(true);
            response = await webApi.Post(URLGetTahunAkademik, string.Empty, false);
            if (!response.IsSuccessStatusCode)
            {
                MessageBox.Show("Data tahun akademik gagal di tampilkan");
                Loading(false);
                return;
            }

            List<string> listTahunAkademik = JsonConvert.DeserializeObject<List<string>>(response.Content.ReadAsStringAsync().Result);
            listTahunAkademik.Insert(0, "Pilih");
            listTahunAkademik.ForEach(delegate (string thnAkademik)
            {
                cmbTahunAkademik.Items.Add(thnAkademik);
            });
            cmbTahunAkademik.SelectedIndex = 0;

            response = await webApi.Post(URLGetSemester, string.Empty, false);
            if (!response.IsSuccessStatusCode)
            {
                MessageBox.Show("Data semester gagal di tampilkan");
                Loading(false);
                return;
            }

            List<DataSemester> listSemester = JsonConvert.DeserializeObject<List<DataSemester>>(response.Content.ReadAsStringAsync().Result);
            listSemester.Insert(0, new DataSemester() { Kode = 1, Nama = "Pilih" });
            cmbSemester.DataSource = listSemester;
            cmbSemester.DisplayMember = "Nama";
            cmbSemester.ValueMember = "Kode";
            cmbSemester.SelectedIndex = 0;

            var getData = new { TahunAkademik = LoginAccess.TahunAkademik, Semester = LoginAccess.KodeSemester };
            var jsonData = JsonConvert.SerializeObject(getData);
            response = await webApi.Post(URLGethonorDosenMengajar, jsonData, true);
            if (!response.IsSuccessStatusCode)
            {
                MessageBox.Show(webApi.ReturnMessage(response));
                Loading(false);
                return;
            }

            dgvHonor.Rows.Clear();
            listHonorDosenMengajar = JsonConvert.DeserializeObject<List<HonorMengajarDosen>>(response.Content.ReadAsStringAsync().Result);

            List<HonorMengajarDosen> listTemp = listHonorDosenMengajar;
            //foreach (HonorMengajarDosen h in listTemp)
            //{
            //    dgvHonor.Rows.Add(
            //        h.NIK,
            //        h.NamaDosen,
            //        h.Kode,
            //        h.MataKuliah,
            //        h.Sks,
            //        0,
            //        h.SksTp,
            //        string.Format("{0}/{1}", h.JenjangPendidikan, h.Golongan),
            //        h.HFix,
            //        h.HVar,
            //        h.Npwp,
            //        h.NoRekeningBank,
            //        h.NamaBank
            //        );
            //}

            var listTemp2 = listTemp
                .Select(h => new { h.NIK, h.NamaDosen, h.NamaProgram, h.JumlahPertemuan, h.JenisMataKuliah, h.Kode, h.MataKuliah, h.Sks, h.SksTp, h.JenjangPendidikan, h.Golongan, h.HFix, h.HVar, h.Npwp, h.NoRekeningBank, h.NamaBank, h.KodeProgram })
                .Distinct()
                .ToList();
            foreach (var h in listTemp2)
            {
                var jmlKelas = listTemp.Where(j => j.NIK == h.NIK && j.Kode == h.Kode && j.KodeProgram == h.KodeProgram).ToList().Count;
                dgvHonor.Rows.Add(
                    h.NIK,
                    h.NamaDosen,
                    h.NamaProgram,
                    h.Kode,
                    h.MataKuliah,
                    string.Format("{0}{1}", h.SksTp, h.JenisMataKuliah),
                    jmlKelas,
                    (jmlKelas * h.SksTp),
                    (jmlKelas * h.JumlahPertemuan),
                    string.Format("{0}/{1}", h.JenjangPendidikan, h.Golongan),
                    ((jmlKelas * h.JumlahPertemuan) * h.HFix).ToString("C", CultureInfo.GetCultureInfo("id-ID")),
                    ((jmlKelas * h.JumlahPertemuan) * h.HVar).ToString("C", CultureInfo.GetCultureInfo("id-ID")),
                    h.Npwp,
                    h.NoRekeningBank,
                    h.NamaBank
                    );
            }
            Loading(false);
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

        private void btnTutup_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
