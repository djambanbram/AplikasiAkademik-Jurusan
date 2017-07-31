#region Copyright Syncfusion Inc. 2001 - 2016
// Copyright Syncfusion Inc. 2001 - 2016. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using ApiService;
using ClassModel;
using KelasMahasiswa.DataBinging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KelasMahasiswa
{
    public partial class FormKelasReguler : Syncfusion.Windows.Forms.MetroForm
    {
        public static string baseAddress = ConfigurationManager.AppSettings["baseAddress"];
        private string URLGetKelasMhs = baseAddress + "/jurusan_api/api/kelas/get_kelas_mhs";
        private string URLGetKelasAktif = baseAddress + "/jurusan_api/api/kelas/get_kelas_reguler";
        private string URLGenerateKelasReguler = baseAddress + "/jurusan_api/api/kelas/generate_kelas_reguler";

        private WebApi webApi;
        private HttpResponseMessage response;

        private List<Fakultas> listFakultas;
        private List<Prodi> listProdi;
        private List<Program> listProgram;

        private string kodeProgramDipilih;
        private string idProdiDipilih;

        public FormKelasReguler()
        {
            InitializeComponent();
            webApi = new WebApi();
        }

        private void Loading(bool isLoading)
        {
            splitContainerAdv1.Enabled = !isLoading;
            gradientPanel2.Enabled = !isLoading;
            flowLayoutPanel1.Enabled = !isLoading;
            progressBar1.Visible = isLoading;
        }

        private void FormKelasReguler_Load(object sender, EventArgs e)
        {
            listFakultas = new List<Fakultas>(Organisasi.listFakultas);
            listFakultas.Insert(0, new Fakultas() { KodeFakultas = "-", NamaFakultas = "Pilih" });
            cmbFakultas.DataSource = listFakultas;
            cmbFakultas.DisplayMember = "NamaFakultas";
            cmbFakultas.ValueMember = "KodeFakultas";
            cmbFakultas.SelectedIndex = 0;
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
                idProdiDipilih = cmbProdi.SelectedValue.ToString();
                listProgram = Organisasi.listProgram.Where(program => program.Prodi.Uid == idProdiDipilih).ToList();
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

        private async void cmbProgram_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbProgram.SelectedIndex > 0)
            {
                Loading(true);
                kodeProgramDipilih = cmbProgram.SelectedValue.ToString();
                await LoadKelas(kodeProgramDipilih);

                Loading(false);
            }
        }

        private async Task LoadKelas(string kodeProgram)
        {
            var dataKelasMhs = new { KodeJurusan = kodeProgramDipilih, TahunAkademik = LoginAccess.TahunAkademik, Semester = LoginAccess.KodeSemester };
            string jsonData = JsonConvert.SerializeObject(dataKelasMhs);
            response = await webApi.Post(URLGetKelasMhs, jsonData, true);
            if (response.IsSuccessStatusCode)
            {
                List<dynamic> oListKelasMhs = JsonConvert.DeserializeObject<List<dynamic>>(response.Content.ReadAsStringAsync().Result);
                KelasMhsBinding kelasBinding = new KelasMhsBinding(oListKelasMhs);

                dgvJumlahKelas.Rows.Clear();
                int no = 1;
                foreach (KelasMhs kls in ClassModel.Kelas.listKelasMhs)
                {
                    dgvJumlahKelas.Rows.Add(no, kls.Tha, kls.Jumlahkelas, kls.Aktif);
                    no++;
                }
            }
            else
            {
                MessageBox.Show(webApi.ReturnMessage(response));
            }


            response = await webApi.Post(URLGetKelasAktif, jsonData, true);
            if (response.IsSuccessStatusCode)
            {
                List<dynamic> oListKelasAktif = JsonConvert.DeserializeObject<List<dynamic>>(response.Content.ReadAsStringAsync().Result);
                KelasAktifBinding kelasBinding = new KelasAktifBinding(oListKelasAktif);

                dgvKelasAktif.Rows.Clear();
                int no = 1;
                foreach (KelasAktif kls in ClassModel.Kelas.listKelasAktif)
                {
                    dgvKelasAktif.Rows.Add(no, kls.NamaKelas, kls.Angkatan, kls.SemesterDitawarkan, kls.JumlahMHS);
                    no++;
                }
            }
            else
            {
                MessageBox.Show(webApi.ReturnMessage(response));
            }
        }

        private async void btnGenerate_Click(object sender, EventArgs e)
        {
            Loading(true);
            var dataGenerate = new
            {
                TahunAkademik = LoginAccess.TahunAkademik,
                Semester = LoginAccess.KodeSemester,
                KodeJurusan = kodeProgramDipilih,
                IdProdi = idProdiDipilih
            };
            string jsonData = JsonConvert.SerializeObject(dataGenerate);
            response = await webApi.Post(URLGenerateKelasReguler, jsonData, true);
            MessageBox.Show(webApi.ReturnMessage(response));
            await LoadKelas(kodeProgramDipilih);
            Loading(false);

        }
    }
}
