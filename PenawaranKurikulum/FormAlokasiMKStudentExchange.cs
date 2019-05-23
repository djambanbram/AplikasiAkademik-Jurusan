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
    public partial class FormAlokasiMKStudentExchange : Syncfusion.Windows.Forms.MetroForm
    {
        public static string baseAddress = ConfigurationManager.AppSettings["baseAddress"];
        private string URLGetMKBelumDitawarkanSe = baseAddress + "/jurusan_api/api/kurikulum/get_mk_belum_ditawarkan_student_exchange";
        private string URLGetMKSudahDitawarkanSe = baseAddress + "/jurusan_api/api/kurikulum/get_mk_sudah_ditawarkan_student_exchange";
        private string URLSaveMKDitawarkanStudentExchange = baseAddress + "/jurusan_api/api/kurikulum/save_alokasi_student_exchange";
        private string URLDeleteAlokasiStudentExchange = baseAddress + "/jurusan_api/api/kurikulum/delete_alokasi_student_exchange";

        private List<Fakultas> listFakultas;
        private List<Prodi> listProdi;
        private List<Prodi> listProdiStudentExchange;
        private List<Program> listProgram;

        private WebApi webApi;
        private HttpResponseMessage response;

        private List<int> listAngkatan;
        private DragandDrop dragAndDropAdd;
        private DragandDrop dragAndDropDelete;
        private dynamic valueMKPrasyaratAdd;
        private dynamic valueMKPrasyaratDelete;

        public FormAlokasiMKStudentExchange()
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
            dragAndDropDelete = new DragandDrop();
        }

        private void Loading(bool isLoading)
        {
            splitContainerAdv1.Enabled = !isLoading;
            flowLayoutPanel1.Enabled = !isLoading;
            gradientPanel2.Enabled = !isLoading;
            progressBar1.Visible = isLoading;
        }

        private void btnTutup_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FormAlokasiMKStudentExchange_Load(object sender, EventArgs e)
        {
            listFakultas = new List<Fakultas>(Organisasi.listFakultas);
            listFakultas.Insert(0, new Fakultas() { KodeFakultas = "-", NamaFakultas = "Pilih" });
            cmbFakultas.DataSource = listFakultas;
            cmbFakultas.DisplayMember = "NamaFakultas";
            cmbFakultas.ValueMember = "KodeFakultas";
            cmbFakultas.SelectedIndex = 0;

            listProdiStudentExchange = new List<Prodi>(Organisasi.listProdiStudentExchange);
            listProdiStudentExchange.Insert(0, new Prodi() { Uid = "-", NamaProdi = "Pilih" });
            cmbStudentExchange.DataSource = listProdiStudentExchange;
            cmbStudentExchange.DisplayMember = "NamaProdi";
            cmbStudentExchange.ValueMember = "Uid";
            cmbStudentExchange.SelectedIndex = 0;
        }

        private void cmbFakultas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbFakultas.SelectedIndex > 0)
            {
                string kodeFakultas = cmbFakultas.SelectedValue.ToString();
                listProdi = Organisasi.listProdi.Where(pr => pr.Fakultas.KodeFakultas == kodeFakultas).ToList();
                listProdi.Insert(0, new Prodi() { Uid = "", IdProdi = "-", NamaProdi = "Pilih" });
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
                listProgram = Organisasi.listProgram
                    .Where(program => program.Prodi.Uid == idProdi)
                    //.Where(program => program.KodeProgram.Contains("6"))
                    .ToList();
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
                dgvMKDitawarkan.Rows.Clear();
                groupBox1.Text = string.Format("Mata Kuliah");
                return;
            }

            Loading(true);

            groupBox1.Text = string.Format("Mata Kuliah Ditawarkan Prodi {0} Program {1}", cmbProdi.Text, cmbProgram.Text);
            var data = new { TahunAkademik = LoginAccess.TahunAkademik, KodeJurusan = cmbProgram.SelectedValue.ToString(), Semester = LoginAccess.KodeSemester, IdProdi = cmbProdi.SelectedValue.ToString() };

            string jsonData = JsonConvert.SerializeObject(data);

            response = await webApi.Post(URLGetMKBelumDitawarkanSe, jsonData, true);
            if (response.IsSuccessStatusCode)
            {
                List<dynamic> oListMkSudahDitawarkan = JsonConvert.DeserializeObject<List<dynamic>>(response.Content.ReadAsStringAsync().Result);
                MataKuliahSudahDitawarkanBinding mkBinding = new MataKuliahSudahDitawarkanBinding(oListMkSudahDitawarkan);
                dgvMKDitawarkan.Rows.Clear();

                int no = 1;
                foreach (MataKuliahDitawarkan mk in ClassModel.MataKuliah.listMataKuliahSudahDitawarkan)
                {
                    dgvMKDitawarkan.Rows.Add(
                        false,
                        mk.SemesterDitawarkan,
                        mk.Angkatan,
                        mk.Kode,
                        mk.MataKuliah,
                        mk.SifatMK,
                        mk.SksTeori,
                        mk.SksPraktikum,
                        mk.JenisMK,
                        mk.DaftarKelasMK);
                    no++;
                }
                if (LoginAccess.KodeSemester == 7 || LoginAccess.KodeSemester == 8 || LoginAccess.KodeSemester == 3)
                {
                    dgvMKDitawarkan.Columns["AngkatanBerlaku"].Visible = false;
                }
            }
            else
            {
                MessageBox.Show(webApi.ReturnMessage(response));
            }
            Loading(false);
        }

        private async void cmbStudentExchange_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbStudentExchange.SelectedIndex == 0)
            {
                dgvMKDitawarkanStudentExchange.Rows.Clear();
                return;
            }

            Loading(true);
            var data = new { TahunAkademik = LoginAccess.TahunAkademik, Semester = LoginAccess.KodeSemester, IdProdi = cmbStudentExchange.SelectedValue.ToString() };

            string jsonData = JsonConvert.SerializeObject(data);

            response = await webApi.Post(URLGetMKSudahDitawarkanSe, jsonData, true);
            if (response.IsSuccessStatusCode)
            {
                List<dynamic> oListMkSudahDitawarkan = JsonConvert.DeserializeObject<List<dynamic>>(response.Content.ReadAsStringAsync().Result);
                MataKuliahSudahDitawarkanBinding mkBinding = new MataKuliahSudahDitawarkanBinding(oListMkSudahDitawarkan);
                dgvMKDitawarkanStudentExchange.Rows.Clear();

                int no = 1;
                foreach (MataKuliahDitawarkan mk in ClassModel.MataKuliah.listMataKuliahSudahDitawarkan)
                {
                    dgvMKDitawarkanStudentExchange.Rows.Add(
                        false,
                        mk.SemesterDitawarkan,
                        mk.Angkatan,
                        mk.Kode,
                        mk.MataKuliah,
                        mk.SifatMK,
                        mk.SksTeori,
                        mk.SksPraktikum,
                        mk.JenisMK,
                        mk.DaftarKelasMK);
                    no++;
                }
                if (LoginAccess.KodeSemester == 7 || LoginAccess.KodeSemester == 8 || LoginAccess.KodeSemester == 3)
                {
                    dgvMKDitawarkanStudentExchange.Columns["AngkatanBerlaku"].Visible = false;
                }
            }
            else
            {
                MessageBox.Show(webApi.ReturnMessage(response));
            }
            Loading(false);
        }

        private void dgvMKDitawarkan_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (cmbStudentExchange.SelectedIndex == 0)
            {
                dgvMKDitawarkanStudentExchange.Rows.Clear();
                return;
            }
        }

        private async void dgvMKDitawarkan_DragDrop(object sender, DragEventArgs e)
        {
            if (valueMKPrasyaratDelete == null)
            {
                return;
            }

            int rowIndex = valueMKPrasyaratDelete.NumRow;
            var dgRow = valueMKPrasyaratDelete.DgRow as DataGridViewRow;
            var kode = dgRow.Cells["mKode"].Value.ToString();
            var tahunAkademik = LoginAccess.TahunAkademik;
            var semester = LoginAccess.KodeSemester;
            var idProdi = cmbStudentExchange.SelectedValue.ToString();

            var Data = new
            {
                TahunAkademik = tahunAkademik,
                Semester = semester,
                Kode = kode,
                IdProdi = idProdi
            };
            var jsonData = JsonConvert.SerializeObject(Data);

            Loading(true);
            response = await webApi.Post(URLDeleteAlokasiStudentExchange, jsonData, true);
            if (!response.IsSuccessStatusCode)
            {
                MessageBox.Show(webApi.ReturnMessage(response));
                Loading(false);
                return;
            }
            Loading(false);

            dgvMKDitawarkanStudentExchange.Rows.RemoveAt(rowIndex);
        }

        private void dgvMKDitawarkan_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void dgvMKDitawarkan_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void dgvMKDitawarkan_MouseDown(object sender, MouseEventArgs e)
        {
            var hittest = dragAndDropAdd.DragMouseDownFirst(e, dgvMKDitawarkan);
            var KodeProgram = cmbProgram.SelectedValue.ToString();
            var Semester = LoginAccess.KodeSemester;
            var TahunAkademik = LoginAccess.TahunAkademik;
            var Kode = dgvMKDitawarkan.Rows[hittest.RowIndex].Cells["KodeDitawarkan"].Value.ToString();
            var JenisKuliah = dgvMKDitawarkan.Rows[hittest.RowIndex].Cells["JenisMKDitawarkan"].Value.ToString();
            var MataKuliah = dgvMKDitawarkan.Rows[hittest.RowIndex].Cells["MataKuliahDitawarkan"].Value.ToString();
            var Angkatan = dgvMKDitawarkan.Rows[hittest.RowIndex].Cells["AngkatanDitawarkan"].Value.ToString();

            var NumRow = hittest.RowIndex;
            valueMKPrasyaratAdd = new
            {
                //KodeProgram, Semester, TahunAkademik, Kode, JenisKuliah
                DgRow = dgvMKDitawarkan.Rows[NumRow]
            };
            dragAndDropAdd.DragMouseDownSecond(e, dgvMKDitawarkanStudentExchange, hittest, valueMKPrasyaratAdd);

        }

        private void dgvMKDitawarkan_MouseMove(object sender, MouseEventArgs e)
        {
            dragAndDropAdd.DragMove(e, dgvMKDitawarkan, valueMKPrasyaratAdd);
        }

        private async void dgvMKDitawarkanStudentExchange_DragDrop(object sender, DragEventArgs e)
        {
            if (valueMKPrasyaratAdd == null)
            {
                return;
            }

            if (cmbStudentExchange.SelectedIndex <= 0)
            {
                MessageBox.Show("Pilih dulu prodi Student Exchange");
                return;
            }
            DataGridViewRow dgRowAdd = valueMKPrasyaratAdd.DgRow as DataGridViewRow;
            foreach (DataGridViewRow dgRow in dgvMKDitawarkanStudentExchange.Rows)
            {
                if (dgRow.Cells["mMataKuliah"].Value.ToString().Trim() == dgRowAdd.Cells["MataKuliahDitawarkan"].Value.ToString().Trim())
                {
                    MessageBox.Show("Mata kuliah sudah ditawarkan");
                    return;
                }
            }

            var TahunAkademik = LoginAccess.TahunAkademik;
            var Semester = LoginAccess.KodeSemester;
            var KodeMKAsal = dgRowAdd.Cells["KodeDitawarkan"].Value.ToString();
            var IdProdi = cmbStudentExchange.SelectedValue.ToString();
            var KodeJurusan = cmbProgram.SelectedValue.ToString();

            var Data = new
            {
                TahunAkademik,
                Semester,
                Kode = KodeMKAsal,
                IdProdi,
                KodeJurusan
            };
            var jsonData = JsonConvert.SerializeObject(Data);
            Loading(true);

            response = await webApi.Post(URLSaveMKDitawarkanStudentExchange, jsonData, true);
            if (!response.IsSuccessStatusCode)
            {
                MessageBox.Show(webApi.ReturnMessage(response));
                Loading(false);
                return;
            }

            var KodeSe = JsonConvert.DeserializeObject<string>(response.Content.ReadAsStringAsync().Result);

            var hitTest = dragAndDropAdd.DragDrop(e, dgvMKDitawarkanStudentExchange);
            dgvMKDitawarkanStudentExchange.Rows.Add(
                false,
                dgRowAdd.Cells["SemesterDitawarkan"].Value.ToString(),
                LoginAccess.TahunAkademik.Substring(0, 4),
                KodeSe,
                dgRowAdd.Cells["MataKuliahDitawarkan"].Value.ToString(),
                dgRowAdd.Cells["SifatMKDitawarkan"].Value.ToString(),
                dgRowAdd.Cells["SksTeoriDitawarkan"].Value.ToString(),
                dgRowAdd.Cells["SksPraktikumDitawarkan"].Value.ToString(),
                dgRowAdd.Cells["JenisMKDitawarkan"].Value.ToString(),
                dgRowAdd.Cells["DaftarKelasDitawarkan"].Value.ToString()
                );
            valueMKPrasyaratAdd = null;
            Loading(false);
        }

        private void dgvMKDitawarkanStudentExchange_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void dgvMKDitawarkanStudentExchange_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void dgvMKDitawarkanStudentExchange_MouseDown(object sender, MouseEventArgs e)
        {
            var hittest = dragAndDropDelete.DragMouseDownFirst(e, dgvMKDitawarkanStudentExchange);
            if(hittest == null)
            {
                return;
            }
            valueMKPrasyaratDelete = new { DgRow = dgvMKDitawarkanStudentExchange.Rows[hittest.RowIndex], NumRow = hittest.RowIndex };

            dragAndDropDelete.DragMouseDownSecond(e, dgvMKDitawarkan, hittest, valueMKPrasyaratDelete);
        }

        private void dgvMKDitawarkanStudentExchange_MouseMove(object sender, MouseEventArgs e)
        {
            dragAndDropDelete.DragMove(e, dgvMKDitawarkanStudentExchange, valueMKPrasyaratDelete);
        }

        private async void btnTawarkan_Click(object sender, EventArgs e)
        {
            if (cmbStudentExchange.SelectedIndex <= 0)
            {
                MessageBox.Show("Pilih dulu prodi Student Exchange");
                return;
            }
            foreach (DataGridViewRow dgRow in dgvMKDitawarkan.Rows)
            {
                DataGridViewCheckBoxCell cbCell = dgRow.Cells["PilihDitawarkan"] as DataGridViewCheckBoxCell;
                if (Convert.ToBoolean(cbCell.Value))
                {
                    var isAdaKode = false;
                    foreach (DataGridViewRow dgRowSe in dgvMKDitawarkanStudentExchange.Rows)
                    {
                        if (dgRow.Cells["mMataKuliah"].Value.ToString().Trim() == dgRow.Cells["MataKuliahDitawarkan"].Value.ToString().Trim())
                        {
                            isAdaKode = true;
                            break;
                        }
                    }
                    if (isAdaKode)
                    {
                        continue;
                    }

                    var TahunAkademik = LoginAccess.TahunAkademik;
                    var Semester = LoginAccess.KodeSemester;
                    var KodeMKAsal = dgRow.Cells["KodeDitawarkan"].Value.ToString();
                    var IdProdi = cmbStudentExchange.SelectedValue.ToString();
                    var KodeJurusan = cmbProgram.SelectedValue.ToString();
                    var Data = new { TahunAkademik, Semester, Kode = KodeMKAsal, IdProdi, KodeJurusan };
                    var jsonData = JsonConvert.SerializeObject(Data);

                    response = await webApi.Post(URLSaveMKDitawarkanStudentExchange, jsonData, true);
                    if (!response.IsSuccessStatusCode)
                    {
                        Loading(false);
                        MessageBox.Show(webApi.ReturnMessage(response));
                        continue;
                    }
                    var KodeSe = JsonConvert.DeserializeObject<string>(response.Content.ReadAsStringAsync().Result);
                    dgvMKDitawarkanStudentExchange.Rows.Add(
                        false,
                        dgRow.Cells["SemesterDitawarkan"].Value.ToString(),
                        LoginAccess.TahunAkademik.Substring(0, 4),
                        KodeSe,
                        dgRow.Cells["MataKuliahDitawarkan"].Value.ToString(),
                        dgRow.Cells["SifatMKDitawarkan"].Value.ToString(),
                        dgRow.Cells["SksTeoriDitawarkan"].Value.ToString(),
                        dgRow.Cells["SksPraktikumDitawarkan"].Value.ToString(),
                        dgRow.Cells["JenisMKDitawarkan"].Value.ToString(),
                        dgRow.Cells["DaftarKelasDitawarkan"].Value.ToString());
                }
            }
        }

        private async void btnHapus_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow dgRow in dgvMKDitawarkanStudentExchange.Rows)
            {
                DataGridViewCheckBoxCell cbCell = dgRow.Cells["mHapus"] as DataGridViewCheckBoxCell;
                if (Convert.ToBoolean(cbCell.Value))
                {
                    dgvMKDitawarkanStudentExchange.Rows.Remove(dgRow);
                }
            }
        }

        private void btnManual_Click(object sender, EventArgs e)
        {
            using (var form = new Dialog.DialogManualStudentExchange())
            {
                form.ShowDialog();
            }
        }
    }
}
