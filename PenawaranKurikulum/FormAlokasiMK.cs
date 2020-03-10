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
using Newtonsoft.Json.Linq;
using PenawaranKurikulum.DataBinding;
using PenawaranKurikulum.Dialog;
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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PenawaranKurikulum
{
    public partial class FormAlokasiMK : Syncfusion.Windows.Forms.MetroForm
    {
        public static string baseAddress = ConfigurationManager.AppSettings["baseAddress"];
        private string URLGetMKBelumDitawarkan = baseAddress + "/jurusan_api/api/kurikulum/get_mk_belum_ditawarkan";
        private string URLGetMKSudahDitawarkan = baseAddress + "/jurusan_api/api/kurikulum/get_mk_sudah_ditawarkan";
        private string URLSaveMKDitawarkan = baseAddress + "/jurusan_api/api/kurikulum/save_penawaran_mk";
        private string URLSaveMKDitawarkanRemidial = baseAddress + "/jurusan_api/api/kurikulum/save_penawaran_mk_remidial";
        private string URLDelMKDitawarkan = baseAddress + "/jurusan_api/api/kurikulum/del_penawaran_mk";
        private string URLCekMKSudahDiambilMhs = baseAddress + "/jurusan_api/api/kurikulum/is_mk_diambil_mhs";

        private List<Fakultas> listFakultas;
        private List<Prodi> listProdi;
        private List<Program> listProgram;

        private WebApi webApi;
        private HttpResponseMessage response;

        private List<int> listAngkatan;
        private DragandDrop dragAndDropAdd;
        private DragandDrop dragAndDropDelete;
        private dynamic valueMKPrasyaratAdd;
        private dynamic valueMKPrasyaratDelete;

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
            dragAndDropDelete = new DragandDrop();
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

        private async void cmbFakultas_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvMK.Rows.Clear();
            dgvMktsd.Rows.Clear();
            if (cmbFakultas.SelectedIndex > 0)
            {
                string kodeFakultas = cmbFakultas.SelectedValue.ToString();
                listProdi = Organisasi.listProdi.Where(pr => pr.Fakultas.KodeFakultas == kodeFakultas).ToList();
                listProdi.Insert(0, new Prodi() { Uid = "", IdProdi = "-", NamaProdi = "Pilih" });
                cmbProdi.DataSource = listProdi;
                cmbProdi.DisplayMember = "NamaProdi";
                cmbProdi.ValueMember = "Uid";
                cmbProdi.SelectedIndex = 0;

                await LoadData();
            }
        }

        private async void cmbProdi_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvMK.Rows.Clear();
            dgvMktsd.Rows.Clear();
            if (cmbFakultas.SelectedIndex > 0 && cmbProdi.SelectedIndex > 0)
            {
                string idProdi = cmbProdi.SelectedValue.ToString();
                listProgram = Organisasi.listProgram.Where(program => program.Prodi.Uid == idProdi).ToList();
                listProgram.Insert(0, new Program() { KodeProgram = "-", NamaProgram = "Pilih" });
                cmbProgram.DataSource = listProgram;
                cmbProgram.DisplayMember = "NamaProgram";
                cmbProgram.ValueMember = "KodeProgram";
                cmbProgram.SelectedIndex = 0;

                await LoadData();
            }
        }

        private async void cmbProgram_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvMK.Rows.Clear();
            dgvMktsd.Rows.Clear();
            if (cmbProdi.SelectedIndex == 0 || cmbProgram.SelectedIndex == 0)
            {
                dgvMK.Rows.Clear();
                dgvMktsd.Rows.Clear();
                return;
            }

            Loading(true);
            await LoadData();
        }

        private async Task LoadData()
        {
            if(!(cmbFakultas.SelectedIndex > 0 && cmbProdi.SelectedIndex > 0 && cmbProgram.SelectedIndex > 0))
            {
                return;
            }

            //Force Data 
            //var data = new { TahunAkademik = "2017/2018", KodeJurusan = cmbProgram.SelectedValue.ToString(), Semester = 7, IdProdi = cmbProdi.SelectedValue.ToString() };
            var data = new { TahunAkademik = LoginAccess.TahunAkademik, KodeJurusan = cmbProgram.SelectedValue.ToString(), Semester = LoginAccess.KodeSemester, IdProdi = cmbProdi.SelectedValue.ToString() };

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
                if (LoginAccess.KodeSemester == 7 || LoginAccess.KodeSemester == 8 || LoginAccess.KodeSemester == 3)
                {
                    dgvMK.Columns["Angkatan"].Visible = false;
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
                    dgvMktsd.Columns["AngkatanBerlaku"].Visible = false;
                }
            }
            else
            {
                MessageBox.Show(webApi.ReturnMessage(response));
            }
            Loading(false);
            dgvMK.PerformLayout();
            dgvMktsd.PerformLayout();
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
            return;

            //Sementara disable (2020-01-28)
            var hitTestInfo = dragAndDropAdd.DragMouseDownFirst(e, dgvMK);
            if (hitTestInfo != null)
            {
                //Mandatory Data
                var KodeProgram = cmbProgram.SelectedValue.ToString();
                var Semester = LoginAccess.KodeSemester;
                var TahunAkademik = LoginAccess.TahunAkademik;
                var Angkatan = dgvMK.Rows[hitTestInfo.RowIndex].Cells["Angkatan"].Value;
                var Kode = dgvMK.Rows[hitTestInfo.RowIndex].Cells["Kode"].Value;
                var IsT = dgvMK.Rows[hitTestInfo.RowIndex].Cells["T"].Value;
                var IsP = dgvMK.Rows[hitTestInfo.RowIndex].Cells["P"].Value;
                var IsTP = dgvMK.Rows[hitTestInfo.RowIndex].Cells["TP"].Value;
                var DaftarKelasMK = dgvMK.Rows[hitTestInfo.RowIndex].Cells["DaftarKelasMK"].Value;

                var MataKuliah = dgvMK.Rows[hitTestInfo.RowIndex].Cells["MataKuliah"].Value;
                var SifatMK = dgvMK.Rows[hitTestInfo.RowIndex].Cells["SifatMK"].Value;
                var SksTeori = dgvMK.Rows[hitTestInfo.RowIndex].Cells["SksTeori"].Value;
                var SksPraktikum = dgvMK.Rows[hitTestInfo.RowIndex].Cells["SksPraktikum"].Value;
                var SemesterDitawarkan = dgvMK.Rows[hitTestInfo.RowIndex].Cells["Semester"].Value;

                var numRow = hitTestInfo.RowIndex;
                valueMKPrasyaratAdd = new
                {
                    KodeProgram,
                    Semester,
                    TahunAkademik,
                    Angkatan,
                    Kode,
                    IsT,
                    IsP,
                    IsTP,
                    DaftarKelasMK,
                    MataKuliah,
                    SifatMK,
                    SksTeori,
                    SksPraktikum,
                    SemesterDitawarkan,
                    numRow
                };
                dragAndDropAdd.DragMouseDownSecond(e, dgvMktsd, hitTestInfo, valueMKPrasyaratAdd);
            }
        }

        private void dgvMktsd_MouseDown(object sender, MouseEventArgs e)
        {

            //sementara disable (2020-01-28)
            var hitTestInfo = dragAndDropDelete.DragMouseDownFirst(e, dgvMktsd);
            if (e.Button == MouseButtons.Right)
            {
                if (dgvMktsd.Rows.Count <= 0)
                {
                    menuStripTawarkan.Items[0].Enabled = false;
                    return;
                }
                menuStripTawarkan.Items[0].Enabled = true;
                dgvMktsd.Rows[hitTestInfo.RowIndex].Selected = true;
                MataKuliahDitawarkan mktsd = new MataKuliahDitawarkan();
                mktsd.Kode = dgvMktsd.Rows[hitTestInfo.RowIndex].Cells["mKode"].Value.ToString();
                mktsd.MataKuliah = dgvMktsd.Rows[hitTestInfo.RowIndex].Cells["mMataKuliah"].Value.ToString();
                mktsd.DaftarKelasMK = bool.Parse(dgvMktsd.Rows[hitTestInfo.RowIndex].Cells["mDaftarKelasMK"].Value.ToString());
                mktsd.JenisMK = dgvMktsd.Rows[hitTestInfo.RowIndex].Cells["JenisMK"].Value.ToString();
                menuStripTawarkan.Items[0].Tag = mktsd;
                return;
            }

            return;
            if (hitTestInfo != null)
            {
                //Mandatory Data
                var KodeProgram = cmbProgram.SelectedValue.ToString();
                var Semester = LoginAccess.KodeSemester;
                var TahunAkademik = LoginAccess.TahunAkademik;
                var Angkatan = dgvMktsd.Rows[hitTestInfo.RowIndex].Cells["AngkatanBerlaku"].Value;
                var Kode = dgvMktsd.Rows[hitTestInfo.RowIndex].Cells["mKode"].Value;

                var IsT = dgvMktsd.Rows[hitTestInfo.RowIndex].Cells["jenisMK"].Value.ToString().Trim() == "T" ? true : false;
                var IsP = dgvMktsd.Rows[hitTestInfo.RowIndex].Cells["jenisMK"].Value.ToString().Trim() == "P" ? true : false;
                var IsTP = dgvMktsd.Rows[hitTestInfo.RowIndex].Cells["jenisMK"].Value.ToString().Trim() == "TP" ? true : false;
                var MataKuliah = dgvMktsd.Rows[hitTestInfo.RowIndex].Cells["mMataKuliah"].Value;
                var SksTeori = dgvMktsd.Rows[hitTestInfo.RowIndex].Cells["mSksTeori"].Value;
                var SksPraktikum = dgvMktsd.Rows[hitTestInfo.RowIndex].Cells["mSksPraktikum"].Value;
                var SifatMK = dgvMktsd.Rows[hitTestInfo.RowIndex].Cells["mSifatMK"].Value;
                var SemesterDitawarkan = dgvMktsd.Rows[hitTestInfo.RowIndex].Cells["mSemester"].Value;
                var DaftarKelasMK = dgvMktsd.Rows[hitTestInfo.RowIndex].Cells["mDaftarKelasMK"].Value;

                var numRow = hitTestInfo.RowIndex;
                valueMKPrasyaratDelete = new
                {
                    KodeProgram,
                    Semester,
                    TahunAkademik,
                    Angkatan,
                    Kode,
                    IsT,
                    IsP,
                    IsTP,
                    MataKuliah,
                    SksTeori,
                    SksPraktikum,
                    SifatMK,
                    SemesterDitawarkan,
                    DaftarKelasMK,
                    numRow
                };
                dragAndDropDelete.DragMouseDownSecond(e, dgvMK, hitTestInfo, valueMKPrasyaratDelete);
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

        private void dgvMktsd_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void dgvMK_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void dgvMktsd_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void dgvMktsd_MouseMove(object sender, MouseEventArgs e)
        {
            dragAndDropDelete.DragMove(e, dgvMktsd, valueMKPrasyaratDelete);
        }

        private async void dgvMK_DragDrop(object sender, DragEventArgs e)
        {
            return;

            //Sementara disable (2020-01-28)
            if (valueMKPrasyaratDelete == null)
            {
                return;
            }

            var hitTest = dragAndDropDelete.DragDrop(e, dgvMK);
            Loading(true);

            var dataDelete = new
            {
                TahunAkademik = LoginAccess.TahunAkademik,
                Semester = LoginAccess.KodeSemester,
                KodeJurusan = cmbProgram.SelectedValue.ToString(),
                Kode = valueMKPrasyaratDelete.Kode,
                Angkatan = valueMKPrasyaratDelete.Angkatan
            };
            string jsonData = JsonConvert.SerializeObject(dataDelete);
            int isMKSudahDiambil = 1;
            response = await webApi.Post(URLCekMKSudahDiambilMhs, jsonData, true);
            if (response.IsSuccessStatusCode)
            {
                isMKSudahDiambil = int.Parse(JObject.Parse(response.Content.ReadAsStringAsync().Result)["Status"].ToString());
                if (isMKSudahDiambil == 1)
                {
                    DialogResult dr = MessageBox.Show(
                        string.Format("Mata kuliah {0} ({1}) sudah diambil oleh mahasiswa, apakah akan dihapus?", valueMKPrasyaratDelete.MataKuliah, valueMKPrasyaratDelete.Kode),
                        "Warning",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning);
                    if (dr == DialogResult.No)
                    {
                        Loading(false);
                        valueMKPrasyaratDelete = null;
                        return;
                    }
                }
            }
            else
            {
                MessageBox.Show(webApi.ReturnMessage(response));
                valueMKPrasyaratDelete = null;
                Loading(false);
                return;
            }

            response = await webApi.Post(URLDelMKDitawarkan, jsonData, true);
            if (response.IsSuccessStatusCode)
            {
                dgvMK.Rows.Add(
                    false,
                    valueMKPrasyaratDelete.SemesterDitawarkan,
                    valueMKPrasyaratDelete.Angkatan,
                    valueMKPrasyaratDelete.Kode,
                    valueMKPrasyaratDelete.MataKuliah,
                    valueMKPrasyaratDelete.SifatMK,
                    valueMKPrasyaratDelete.SksTeori,
                    valueMKPrasyaratDelete.SksPraktikum,
                    valueMKPrasyaratDelete.IsT,
                    valueMKPrasyaratDelete.IsP,
                    valueMKPrasyaratDelete.IsTP,
                    valueMKPrasyaratDelete.DaftarKelasMK);

                dgvMktsd.Rows.RemoveAt(valueMKPrasyaratDelete.numRow);
            }
            else
            {
                MessageBox.Show(webApi.ReturnMessage(response));
            }

            valueMKPrasyaratDelete = null;
            Loading(false);
        }

        private async void dgvMktsd_DragDrop(object sender, DragEventArgs e)
        {
            return;

            //Sementara disable (2020-01-28)
            if (valueMKPrasyaratAdd == null)
            {
                return;
            }
            var hitTest = dragAndDropAdd.DragDrop(e, dgvMktsd);

            string jenisMK = string.Empty;
            if (Convert.ToBoolean(valueMKPrasyaratAdd.IsT))
            {
                jenisMK = "T";
            }
            else if (Convert.ToBoolean(valueMKPrasyaratAdd.IsP))
            {
                jenisMK = "P";
            }
            else if (Convert.ToBoolean(valueMKPrasyaratAdd.IsTP))
            {
                jenisMK = "TP";
            }

            Loading(true);

            var dataSave = new
            {
                TahunAkademik = LoginAccess.TahunAkademik,
                Semester = LoginAccess.KodeSemester,
                KodeJurusan = cmbProgram.SelectedValue.ToString(),
                Kode = valueMKPrasyaratAdd.Kode,
                Angkatan = valueMKPrasyaratAdd.Angkatan,
                JenisMK = jenisMK,
                DaftarKelasMK = valueMKPrasyaratAdd.DaftarKelasMK
            };
            string jsonData = JsonConvert.SerializeObject(dataSave);
            if (LoginAccess.KodeSemester == 3 || LoginAccess.KodeSemester == 7 || LoginAccess.KodeSemester == 8)
            {
                response = await webApi.Post(URLSaveMKDitawarkanRemidial, jsonData, true);
            }
            else
            {
                response = await webApi.Post(URLSaveMKDitawarkan, jsonData, true);
            }
            if (!response.IsSuccessStatusCode)
            {
                MessageBox.Show(webApi.ReturnMessage(response));
                Loading(false);
                return;
            }
            dgvMktsd.Rows.Add(
                false,
                valueMKPrasyaratAdd.SemesterDitawarkan,
                valueMKPrasyaratAdd.Angkatan,
                valueMKPrasyaratAdd.Kode,
                valueMKPrasyaratAdd.MataKuliah,
                valueMKPrasyaratAdd.SifatMK,
                valueMKPrasyaratAdd.SksTeori,
                valueMKPrasyaratAdd.SksPraktikum,
                jenisMK,
                valueMKPrasyaratAdd.DaftarKelasMK);

            dgvMK.Rows.RemoveAt(valueMKPrasyaratAdd.numRow);

            //using (var form = new DialogAlokasiKelasCampuran(cmbProgram.SelectedValue.ToString(), valueMKPrasyaratAdd.Kode, valueMKPrasyaratAdd.MataKuliah))
            //{
            //    form.ShowDialog();
            //}

            Loading(false);
            valueMKPrasyaratAdd = null;
        }

        private async void btnHapus_Click(object sender, EventArgs e)
        {
            if (dgvMktsd.Rows.Count == 0)
            {
                return;
            }

            Loading(true);
            List<DataGridViewRow> listRemoveRow = new List<DataGridViewRow>();
            foreach (DataGridViewRow dgvRow in dgvMktsd.Rows)
            {
                if (Convert.ToBoolean(dgvRow.Cells["mHapus"].Value))
                {

                    var KodeProgram = cmbProgram.SelectedValue.ToString();
                    var Semester = LoginAccess.KodeSemester;
                    var TahunAkademik = LoginAccess.TahunAkademik;
                    var Angkatan = dgvRow.Cells["AngkatanBerlaku"].Value;
                    var Kode = dgvRow.Cells["mKode"].Value;

                    var IsT = dgvRow.Cells["jenisMK"].Value.ToString().Trim() == "T" ? true : false;
                    var IsP = dgvRow.Cells["jenisMK"].Value.ToString().Trim() == "P" ? true : false;
                    var IsTP = dgvRow.Cells["jenisMK"].Value.ToString().Trim() == "TP" ? true : false;
                    var MataKuliah = dgvRow.Cells["mMataKuliah"].Value;
                    var SksTeori = dgvRow.Cells["mSksTeori"].Value;
                    var SksPraktikum = dgvRow.Cells["mSksPraktikum"].Value;
                    var SifatMK = dgvRow.Cells["mSifatMK"].Value;
                    var SemesterDitawarkan = dgvRow.Cells["mSemester"].Value;
                    var DaftarKelasMK = dgvRow.Cells["mDaftarKelasMK"].Value;

                    var dataDelete = new
                    {
                        TahunAkademik = LoginAccess.TahunAkademik,
                        Semester = LoginAccess.KodeSemester,
                        KodeJurusan = cmbProgram.SelectedValue.ToString(),
                        Kode = Kode,
                        Angkatan = Angkatan
                    };
                    string jsonData = JsonConvert.SerializeObject(dataDelete);

                    int isMKSudahDiambil = 1;
                    response = await webApi.Post(URLCekMKSudahDiambilMhs, jsonData, true);
                    if (response.IsSuccessStatusCode)
                    {
                        isMKSudahDiambil = int.Parse(JObject.Parse(response.Content.ReadAsStringAsync().Result)["Status"].ToString());
                        if (isMKSudahDiambil == 1)
                        {
                            DialogResult dr = MessageBox.Show(
                                string.Format("Mata kuliah {0} ({1}) sudah diambil oleh mahasiswa, apakah akan dihapus?", MataKuliah, Kode),
                                "Warning",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Warning);
                            if (dr == DialogResult.No)
                            {
                                continue;
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show(webApi.ReturnMessage(response));
                        Loading(false);
                        return;
                    }

                    listRemoveRow.Add(dgvRow);
                    response = await webApi.Post(URLDelMKDitawarkan, jsonData, true);
                    if (response.IsSuccessStatusCode)
                    {
                        dgvMK.Rows.Add(false, SemesterDitawarkan, Angkatan, Kode, MataKuliah, SifatMK, SksTeori, SksPraktikum, IsT, IsP, IsTP, DaftarKelasMK);
                    }
                    else
                    {
                        MessageBox.Show(webApi.ReturnMessage(response));
                    }
                }
            }
            listRemoveRow.ForEach(delegate (DataGridViewRow dgv)
            {
                dgvMktsd.Rows.Remove(dgv);
            });

            valueMKPrasyaratDelete = null;
            Loading(false);
        }

        private async void btnTawarkan_Click(object sender, EventArgs e)
        {
            if (dgvMK.Rows.Count == 0)
            {
                return;
            }

            Loading(true);
            List<DataGridViewRow> listRemoveRow = new List<DataGridViewRow>();
            foreach (DataGridViewRow dgvRow in dgvMK.Rows)
            {
                if (Convert.ToBoolean(dgvRow.Cells["Pilih"].Value))
                {
                    var jenisMK = string.Empty;
                    if (Convert.ToBoolean(dgvRow.Cells["T"].Value))
                    {
                        jenisMK = "T";
                    }
                    else if (Convert.ToBoolean(dgvRow.Cells["P"].Value))
                    {
                        jenisMK = "P";
                    }
                    else if (Convert.ToBoolean(dgvRow.Cells["TP"].Value))
                    {
                        jenisMK = "TP";
                    }

                    var KodeProgram = cmbProgram.SelectedValue.ToString();
                    var Semester = LoginAccess.KodeSemester;
                    var TahunAkademik = LoginAccess.TahunAkademik;
                    var Angkatan = dgvRow.Cells["Angkatan"].Value;
                    var Kode = dgvRow.Cells["Kode"].Value;
                    var IsT = dgvRow.Cells["T"].Value;
                    var IsP = dgvRow.Cells["P"].Value;
                    var IsTP = dgvRow.Cells["TP"].Value;
                    var DaftarKelasMK = Convert.ToBoolean(dgvRow.Cells["DaftarKelasMK"].Value);

                    var MataKuliah = dgvRow.Cells["MataKuliah"].Value;
                    var SifatMK = dgvRow.Cells["SifatMK"].Value;
                    var SksTeori = dgvRow.Cells["SksTeori"].Value;
                    var SksPraktikum = dgvRow.Cells["SksPraktikum"].Value;
                    var SemesterDitawarkan = dgvRow.Cells["Semester"].Value;

                    var dataSave = new
                    {
                        TahunAkademik = LoginAccess.TahunAkademik,
                        Semester = LoginAccess.KodeSemester,
                        KodeJurusan = cmbProgram.SelectedValue.ToString(),
                        Kode = Kode,
                        Angkatan = Angkatan,
                        JenisMK = jenisMK,
                        DaftarKelasMK = DaftarKelasMK
                    };
                    string jsonData = JsonConvert.SerializeObject(dataSave);
                    if (LoginAccess.KodeSemester == 3 || LoginAccess.KodeSemester == 7 || LoginAccess.KodeSemester == 8)
                    {
                        response = await webApi.Post(URLSaveMKDitawarkanRemidial, jsonData, true);
                    }
                    else
                    {
                        response = await webApi.Post(URLSaveMKDitawarkan, jsonData, true);
                    }
                    if (response.IsSuccessStatusCode)
                    {
                        dgvMktsd.Rows.Add(false, SemesterDitawarkan, Angkatan, Kode, MataKuliah, SifatMK, SksTeori, SksPraktikum, jenisMK, DaftarKelasMK);
                        listRemoveRow.Add(dgvRow);
                    }
                    else
                    {
                        MessageBox.Show(webApi.ReturnMessage(response));
                    }
                }
            }

            listRemoveRow.ForEach(delegate (DataGridViewRow dgv)
            {
                dgvMK.Rows.Remove(dgv);
            });
            valueMKPrasyaratAdd = null;
            Loading(false);
        }

        private void dgvMK_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2)
            {
                if (dgvMK.Rows.Count > 0)
                {
                    DataGridViewComboBoxCell cb = dgvMK.Rows[e.RowIndex].Cells["Angkatan"] as DataGridViewComboBoxCell;
                    cb.Value = int.Parse(cb.Value.ToString());
                }
            }
        }

        private void dgvMK_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            dgvMK.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void dgvMktsd_MouseClick(object sender, MouseEventArgs e)
        {
        }

        private async void tawarkanUntukAngkatanLainToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MataKuliahDitawarkan dataMataKuliah = (sender as ToolStripItem).Tag as MataKuliahDitawarkan;
            using (var form = new FormCopyMktsdAngkatanLain(dataMataKuliah, cmbProgram.SelectedValue.ToString()))
            {
                form.ShowDialog();
            }

            var data = new { TahunAkademik = LoginAccess.TahunAkademik, KodeJurusan = cmbProgram.SelectedValue.ToString(), Semester = LoginAccess.KodeSemester, IdProdi = cmbProdi.SelectedValue.ToString() };

            string jsonData = JsonConvert.SerializeObject(data);
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
                    dgvMktsd.Columns["AngkatanBerlaku"].Visible = false;
                }
            }
            else
            {
                MessageBox.Show(webApi.ReturnMessage(response));
            }
        }
    }
}
