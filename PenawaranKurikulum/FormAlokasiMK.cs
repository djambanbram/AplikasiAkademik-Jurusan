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
using PenawaranKurikulum.DataBinding;
using PenawaranKurikulum.Lib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Windows.Forms;

namespace PenawaranKurikulum
{
    public partial class FormAlokasiMK : Syncfusion.Windows.Forms.MetroForm
    {
        public static string baseAddress = ConfigurationManager.AppSettings["baseAddress"];
        private string URLGetMKBelumDitawarkan = baseAddress + "/jurusan_api/api/kurikulum/get_mk_belum_ditawarkan";
        private string URLGetMKSudahDitawarkan = baseAddress + "/jurusan_api/api/kurikulum/get_mk_sudah_ditawarkan";

        private List<Fakultas> listFakultas;
        private List<Prodi> listProdi;
        private List<Program> listProgram;

        private WebApi webApi;
        private HttpResponseMessage response;

        private List<int> listAngkatan;
        private DragandDrop dragAndDropAdd;
        private dynamic valueMKPrasyaratAdd;

        public FormAlokasiMK()
        {
            InitializeComponent();
            webApi = new WebApi();
            listAngkatan = new List<int>();
            for (int i = DateTime.Now.Year; i >= DateTime.Now.Year - 4; i--)
            {
                listAngkatan.Add(i);
            }
            listAngkatan.Add(1998);
            dragAndDropAdd = new DragandDrop();
        }

        private void Loading(bool isLoading)
        {
            splitContainerAdv1.Enabled = !isLoading;
            flowLayoutPanel1.Enabled = !isLoading;
            gradientPanel2.Enabled = !isLoading;
            progressBar1.Visible = isLoading;
        }

        private void FormAlokasiMK_Load(object sender, EventArgs e)
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
            if (cmbFakultas.SelectedIndex != 0)
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
            if (cmbFakultas.SelectedIndex != 0 && cmbProdi.SelectedIndex != 0)
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
            if (cmbProdi.SelectedIndex == 0 || cmbProgram.SelectedIndex == 0)
            {
                dgvMK.Rows.Clear();
                dgvMktsd.Rows.Clear();
                return;
            }

            Loading(true);

            //Force Data 
            var data = new { TahunAkademik = "2017/2018", KodeJurusan = cmbProgram.SelectedValue.ToString(), Semester = 1, IdProdi = cmbProdi.SelectedValue.ToString() };
            //var data = new { TahunAkademik = LoginAccess.TahunAkademik, KodeJurusan = cmbProgram.SelectedValue.ToString(), Semester = LoginAccess.KodeSemester, IdProdi = cmbProdi.SelectedValue.ToString() };

            string jsonData = JsonConvert.SerializeObject(data);

            response = await webApi.Post(URLGetMKBelumDitawarkan, jsonData, true);
            if (response.IsSuccessStatusCode)
            {
                List<dynamic> oListMkBelumDitawarkan = JsonConvert.DeserializeObject<List<dynamic>>(response.Content.ReadAsStringAsync().Result);
                MataKuliahBelumDitawarkanBinding mkBinding = new MataKuliahBelumDitawarkanBinding(oListMkBelumDitawarkan);
                dgvMK.Rows.Clear();

                DataGridViewComboBoxColumn cb = (dgvMK.Columns["Angkatan"] as DataGridViewComboBoxColumn);
                cb.DataSource = listAngkatan;
                foreach (MataKuliahDitawarkan mk in ClassModel.MataKuliah.listMataKuliahBelumDitawarkan)
                {
                    bool isT = mk.SksTeori != 0 && mk.SksPraktikum == 0 ? true : false;
                    bool isP = mk.SksTeori == 0 && mk.SksPraktikum != 0 ? true : false;
                    bool isTP = mk.SksTeori != 0 && mk.SksPraktikum != 0 ? true : false;
                    bool isDaftarKelas = mk.KodeSifatMK.Trim() == "P" || mk.KodeSifatMK.Trim() == "K" ? true : false;
                    dgvMK.Rows.Add(
                        false,
                        mk.SemesterDitawarkan,
                        mk.Angkatan,
                        mk.Kode,
                        mk.MataKuliah,
                        mk.SifatMK,
                        mk.SksTeori,
                        mk.SksPraktikum,
                        isT,
                        isP,
                        isTP,
                        isDaftarKelas);
                }
            }
            else
            {
                MessageBox.Show(webApi.ReturnMessage(response));
            }

            response = await webApi.Post(URLGetMKSudahDitawarkan, jsonData, true);
            if (response.IsSuccessStatusCode)
            {
                List<dynamic> oListMkSudahDitawarkan = JsonConvert.DeserializeObject<List<dynamic>>(response.Content.ReadAsStringAsync().Result);
                MataKuliahSudahDitawarkanBinding mkBinding = new MataKuliahSudahDitawarkanBinding(oListMkSudahDitawarkan);
                dgvMktsd.Rows.Clear();

                int no = 1;
                foreach (MataKuliahDitawarkan mk in ClassModel.MataKuliah.listMataKuliahSudahDitawarkan)
                {
                    dgvMktsd.Rows.Add(
                        no,
                        mk.Angkatan,
                        mk.Kode,
                        mk.MataKuliah,
                        mk.JenisMK);
                    no++;
                }
            }
            else
            {
                MessageBox.Show(webApi.ReturnMessage(response));
            }
            Loading(false);
        }

        private void btnTutup_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dgvMK_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void dgvMK_MouseDown(object sender, MouseEventArgs e)
        {
            var hitTestInfo = dragAndDropAdd.DragMouseDownFirst(e, dgvMK);
            if (hitTestInfo != null)
            {
                var kodeMK = dgvMK.Rows[hitTestInfo.RowIndex].Cells["Kode"].Value;
                var namaMK = dgvMK.Rows[hitTestInfo.RowIndex].Cells["MataKuliah"].Value;
                valueMKPrasyaratAdd = new { kodeMK, namaMK };
                dragAndDropAdd.DragMouseDownSecond(e, dgvMktsd, hitTestInfo, valueMKPrasyaratAdd);
            }
        }

        private void dgvMK_MouseMove(object sender, MouseEventArgs e)
        {
            dragAndDropAdd.DragMove(e, dgvMK, valueMKPrasyaratAdd);
        }

        private void dgvMK_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void dgvMK_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void dgvMktsd_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void dgvMktsd_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void dgvMktsd_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }
    }
}
