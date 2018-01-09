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
using PenawaranKurikulum.Listener;
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
using static System.Windows.Forms.DataGridView;

namespace PenawaranKurikulum
{
    public partial class FormAlokasiDosen : Syncfusion.Windows.Forms.MetroForm, IRefreshAlokasiDosen
    {
        public static string baseAddress = ConfigurationManager.AppSettings["baseAddress"];
        private string URLGetMKSudahDitawarkan = baseAddress + "/jurusan_api/api/kurikulum/get_mk_sudah_ditawarkan";
        private string URLGetKelasAktif = baseAddress + "/jurusan_api/api/kelas/get_kelas_reguler";
        private string URLGetDosenMengajar = baseAddress + "/jurusan_api/api/pengajaran/get_dosen_mengajar";
        private string URLGetDataDosen = baseAddress + "/jurusan_api/api/pengajaran/get_dosen";
        private string URLSaveAlokasiDosen = baseAddress + "/jurusan_api/api/pengajaran/save_dosen_mengajar";
        private string URLCanDeleteAlokasiDosen = baseAddress + "/jurusan_api/api/pengajaran/is_dosen_sudah_presensi";
        private string URLDeleteAlokasiDosen = baseAddress + "/jurusan_api/api/pengajaran/del_dosen_mengajar";
        private string URLDeleteAlokasiDosenBySemester = baseAddress + "/jurusan_api/api/pengajaran/del_dosen_mengajar_by_semester";
        private string URLGetKelasCampuran = baseAddress + "/jurusan_api/api/kelas/get_kelas_campuran";

        private WebApi webApi;
        private HttpResponseMessage response;

        private List<Fakultas> listFakultas;
        private List<Prodi> listProdi;
        private List<Program> listProgram;
        private List<KelasAktif> listKelasAktif;
        private List<KelasCampuranAktif> listKelasCampuranAktif;
        private List<DataDosen> listDataDosen;

        private List<MataKuliahDitawarkan> listTemp;

        private int[] ganjil = { 1, 3, 5, 7 };
        private int[] genap = { 2, 4, 6, 8 };
        private int[] allSemester = { 1, 2, 3, 4, 5, 6, 7, 8 };

        private int semDipilih;
        private string kodeProgramDipilih;

        private DragandDrop dragAndDropAdd;
        private DragandDrop dragAndDropDelete;
        private dynamic valueAdd;
        private dynamic valueDeleteOrSet;

        private bool isModeCampuran;

        public FormAlokasiDosen()
        {
            InitializeComponent();
            dgvAlokasi.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;
            dgvAlokasi.EnableHeadersVisualStyles = false;
            webApi = new WebApi();

            dragAndDropAdd = new DragandDrop();
            dragAndDropDelete = new DragandDrop();
        }

        private void btnTutup_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Loading(bool isLoading)
        {
            splitContainerAdv1.Enabled = !isLoading;
            flowLayoutPanel1.Enabled = !isLoading;
            gradientPanel2.Enabled = !isLoading;
            progressBar1.Visible = isLoading;
        }

        private void FormAlokasiDosen_Load(object sender, EventArgs e)
        {
            if (LoginAccess.KodeSemester == 7 || LoginAccess.KodeSemester == 8)
            {
                radCampuran.Text = "MK Remidial";
                radCampuran.Checked = true;

                rad1.Enabled = false;
                rad2.Enabled = false;
                rad3.Enabled = false;
                rad4.Enabled = false;
                rad5.Enabled = false;
                rad6.Enabled = false;
                rad7.Enabled = false;
                rad8.Enabled = false;
            }

            listFakultas = new List<Fakultas>(Organisasi.listFakultas);
            listFakultas.Insert(0, new Fakultas() { KodeFakultas = "-", NamaFakultas = "Pilih" });
            cmbFakultas.DataSource = listFakultas;
            cmbFakultas.DisplayMember = "NamaFakultas";
            cmbFakultas.ValueMember = "KodeFakultas";
            cmbFakultas.SelectedIndex = 0;

            //if (LoginAccess.KodeSemester % 2 == 1)
            //{
            rad1.Text = "1";
            rad2.Text = "2";
            rad3.Text = "3";
            rad4.Text = "4";
            //}
            //else
            //{
            rad5.Text = "5";
            rad6.Text = "6";
            rad7.Text = "7";
            rad8.Text = "8";
            //}
        }

        private void cmbFakultas_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvAlokasi.Rows.Clear();

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
            dgvAlokasi.Rows.Clear();
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
            Loading(true);
            dgvAlokasi.Rows.Clear();
            if (cmbProgram.SelectedIndex > 0)
            {
                int sem = 0;
                if (rad1.Checked)
                {
                    sem = int.Parse(rad1.Text);
                    isModeCampuran = false;
                }
                else if (rad2.Checked)
                {
                    sem = int.Parse(rad2.Text);
                    isModeCampuran = false;
                }
                else if (rad3.Checked)
                {
                    sem = int.Parse(rad3.Text);
                    isModeCampuran = false;
                }
                else if (rad4.Checked)
                {
                    sem = int.Parse(rad4.Text);
                    isModeCampuran = false;
                }
                else if (radCampuran.Checked)
                {
                    sem = LoginAccess.KodeSemester;
                    isModeCampuran = true;
                }
                semDipilih = sem;
                kodeProgramDipilih = cmbProgram.SelectedValue.ToString();
                await LoadAlokasiDosen(semDipilih, kodeProgramDipilih);
            }
            Loading(false);
        }

        private async void radioChecked(object sender, EventArgs e)
        {
            Loading(true);
            if (cmbProgram.SelectedIndex > 0 && (((RadioButton)sender).Checked))
            {
                if (((RadioButton)sender).Name == "radCampuran")
                {
                    semDipilih = LoginAccess.KodeSemester;
                    isModeCampuran = true;
                }
                else
                {
                    semDipilih = int.Parse(((RadioButton)sender).Text);
                    isModeCampuran = false;
                }
                kodeProgramDipilih = cmbProgram.SelectedValue.ToString();
                await LoadAlokasiDosen(semDipilih, kodeProgramDipilih);
            }
            Loading(false);
        }

        private async Task LoadAlokasiDosen(int semester, string kodeProgram)
        {
            ///Load MK Ditawarkan
            var data = new
            {
                TahunAkademik = LoginAccess.TahunAkademik,
                KodeJurusan = kodeProgramDipilih,
                Semester = LoginAccess.KodeSemester,
                IdProdi = cmbProdi.SelectedValue.ToString()
            };
            string jsonData = JsonConvert.SerializeObject(data);
            await LoadMKDitawarkan(jsonData);
            await LoadKelas(jsonData);
            await LoadAlokasiDosen(jsonData);
            await LoadDataDosen(jsonData);
            if (radCampuran.Checked)
            {
                btnHapusAlokasi.Text = "Hapus Alokasi MK Campuran";
            }
            else
            {
                btnHapusAlokasi.Text = string.Format("Hapus Alokasi Semester {0}", semester);
            }
        }

        private async Task LoadMKDitawarkan(string jsonData)
        {
            response = await webApi.Post(URLGetMKSudahDitawarkan, jsonData, true);
            if (response.IsSuccessStatusCode)
            {
                List<dynamic> oListMkSudahDitawarkan = JsonConvert.DeserializeObject<List<dynamic>>(response.Content.ReadAsStringAsync().Result);
                MataKuliahSudahDitawarkanBinding mkBinding = new MataKuliahSudahDitawarkanBinding(oListMkSudahDitawarkan);
                dgvAlokasi.Columns.Clear();

                DataGridViewTextBoxColumn dgColumnKodeCampuran = new DataGridViewTextBoxColumn();
                dgColumnKodeCampuran.Name = "Kode";
                dgColumnKodeCampuran.HeaderText = "Kode";
                dgColumnKodeCampuran.Visible = false;
                dgColumnKodeCampuran.ValueType = typeof(string);
                dgColumnKodeCampuran.SortMode = DataGridViewColumnSortMode.NotSortable;
                dgColumnKodeCampuran.Frozen = true;
                dgvAlokasi.Columns.Add(dgColumnKodeCampuran);

                DataGridViewTextBoxColumn dgColumnIdKelas = new DataGridViewTextBoxColumn();
                dgColumnIdKelas.Name = "IdKelas";
                dgColumnIdKelas.HeaderText = "IdKelas";
                dgColumnIdKelas.Visible = false;
                dgColumnIdKelas.ValueType = typeof(string);
                dgColumnIdKelas.SortMode = DataGridViewColumnSortMode.NotSortable;
                dgColumnIdKelas.Frozen = true;
                dgvAlokasi.Columns.Add(dgColumnIdKelas);

                DataGridViewTextBoxColumn dgColumnKelas = new DataGridViewTextBoxColumn();
                dgColumnKelas.Name = "KELAS";
                dgColumnKelas.HeaderText = "KELAS";
                if (!isModeCampuran)
                {
                    dgColumnKelas.Width = 100;
                }
                else
                {
                    dgColumnKelas.Width = 200;
                }
                dgColumnKelas.ValueType = typeof(string);
                dgColumnKelas.SortMode = DataGridViewColumnSortMode.NotSortable;
                dgColumnKelas.DefaultCellStyle.BackColor = Color.LightGray;
                dgColumnKelas.DefaultCellStyle.SelectionBackColor = Color.LightGray;
                dgColumnKelas.DefaultCellStyle.SelectionForeColor = Color.Black;
                dgColumnKelas.Frozen = true;
                dgvAlokasi.Columns.Add(dgColumnKelas);

                if (!isModeCampuran)
                {
                    listTemp = MataKuliah.listMataKuliahSudahDitawarkan.Where(m => m.SemesterDitawarkan == semDipilih && m.KodeSifatMK == "W").ToList();
                }
                else
                {
                    if (LoginAccess.KodeSemester == 7 || LoginAccess.KodeSemester == 8)
                    {
                        listTemp = MataKuliah.listMataKuliahSudahDitawarkan.Where(m => m.KodeSifatMK == "P" || m.KodeSifatMK == "K" || m.KodeSifatMK == "W" ||
                                    m.MataKuliah.Contains("NON MUSLIM")).OrderBy(mk => mk.Kode).ToList();
                    }
                    else
                    {
                        listTemp = MataKuliah.listMataKuliahSudahDitawarkan.Where(m => m.KodeSifatMK == "P" || m.KodeSifatMK == "K" || m.DaftarKelasMK == true ||
                                    m.MataKuliah.Contains("NON MUSLIM")).OrderBy(mk => mk.Kode).ToList();
                    }
                }

                foreach (MataKuliahDitawarkan mk in listTemp)
                {
                    DataGridViewTextBoxColumn dgColumnTeori = new DataGridViewTextBoxColumn();
                    dgColumnTeori.Name = string.Format("{0}-SKST", mk.Kode);
                    dgColumnTeori.HeaderText = mk.SksTeori.ToString() + "T";
                    dgColumnTeori.Width = 200;
                    dgColumnTeori.ValueType = typeof(string);
                    dgColumnTeori.SortMode = DataGridViewColumnSortMode.NotSortable;

                    DataGridViewTextBoxColumn dgColumnPraktikum = new DataGridViewTextBoxColumn();
                    dgColumnPraktikum.Name = string.Format("{0}-SKSP", mk.Kode);
                    dgColumnPraktikum.HeaderText = mk.SksPraktikum.ToString() + "P";
                    dgColumnPraktikum.Width = 200;
                    dgColumnPraktikum.ValueType = typeof(string);
                    dgColumnPraktikum.SortMode = DataGridViewColumnSortMode.NotSortable;

                    dgvAlokasi.Columns.Add(dgColumnTeori);
                    dgvAlokasi.Columns.Add(dgColumnPraktikum);

                }

                this.dgvAlokasi.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
                this.dgvAlokasi.ColumnHeadersHeight = 46;//this.dgvAlokasi.ColumnHeadersHeight;
                this.dgvAlokasi.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;
            }
            else
            {
                MessageBox.Show(webApi.ReturnMessage(response));
            }
            dgvAlokasi.PerformLayout();
        }

        private async Task LoadKelas(string jsonData)
        {
            ///Load Kelas
            if (!isModeCampuran)
            {
                response = await webApi.Post(URLGetKelasAktif, jsonData, true);
            }
            else
            {
                response = await webApi.Post(URLGetKelasCampuran, jsonData, true);
            }
            if (response.IsSuccessStatusCode)
            {
                if (!isModeCampuran)
                {
                    //semesntara hardcode, untuk transfer, kelas akan di tampilkan di seluruh semester
                    if (kodeProgramDipilih == "21" || kodeProgramDipilih == "22")
                    {
                        listKelasAktif = JsonConvert.DeserializeObject<List<KelasAktif>>(response.Content.ReadAsStringAsync().Result).ToList();
                    }
                    else
                    {
                        listKelasAktif = JsonConvert.DeserializeObject<List<KelasAktif>>(response.Content.ReadAsStringAsync().Result).Where(kls => kls.SemesterDitawarkan == semDipilih).ToList();
                    }

                    foreach (KelasAktif item in listKelasAktif)
                    {
                        dgvAlokasi.Rows.Add(null, item.IdKelas, item.NamaKelas);
                    }
                }
                else
                {
                    listKelasCampuranAktif = JsonConvert.DeserializeObject<List<KelasCampuranAktif>>(response.Content.ReadAsStringAsync().Result).OrderBy(kls => kls.Kode).ToList();
                    foreach (KelasCampuranAktif item in listKelasCampuranAktif)
                    {
                        dgvAlokasi.Rows.Add(item.Kode, item.IdKelas, item.NamaKelas);
                    }
                }
            }
            else
            {
                MessageBox.Show(webApi.ReturnMessage(response));
            }

            foreach (DataGridViewTextBoxColumn dgc in dgvAlokasi.Columns)
            {
                if (LoginAccess.KodeSemester == 7 || LoginAccess.KodeSemester == 8)
                {
                    foreach (DataGridViewRow dgr in dgvAlokasi.Rows)
                    {
                        if (dgr.Cells["Kode"].Value.ToString() != dgc.Name.Split('-')[0].ToString())
                        {
                                dgr.Cells[dgc.DisplayIndex].Style.BackColor = Color.LightGray;
                        }
                        else
                        {
                            if (dgc.HeaderText.Contains("P"))
                            {
                                dgr.Cells[dgc.DisplayIndex].Style.BackColor = Color.LightGray;
                            }
                        }
                    }
                }
                else
                {
                    if (dgc.HeaderText.Contains("0"))
                    {
                        dgc.DefaultCellStyle.BackColor = Color.LightGray;
                    }

                    if (isModeCampuran)
                    {
                        foreach (DataGridViewRow dgr in dgvAlokasi.Rows)
                        {
                            if (dgr.Cells["Kode"].Value.ToString() != dgc.Name.Split('-')[0].ToString())
                            {
                                dgr.Cells[dgc.DisplayIndex].Style.BackColor = Color.LightGray;
                            }
                        }
                    }
                }
            }
            dgvAlokasi.PerformLayout();

        }

        private async Task LoadAlokasiDosen(string jsonData)
        {
            ///Load AlokasiDosen
            response = await webApi.Post(URLGetDosenMengajar, jsonData, true);
            if (response.IsSuccessStatusCode)
            {
                List<AlokasiDosenMengajar> listAlokasiDosenMengajar = JsonConvert.DeserializeObject<List<AlokasiDosenMengajar>>(response.Content.ReadAsStringAsync().Result);
                AlokasiDosenMengajar alokasi = null;
                foreach (DataGridViewRow dgRow in dgvAlokasi.Rows)
                {
                    int idKelas = int.Parse(dgRow.Cells["IdKelas"].Value.ToString());
                    foreach (DataGridViewColumn dgColumn in dgvAlokasi.Columns)
                    {
                        if (dgColumn.HeaderText.Contains('0') || dgColumn.Name.ToLower().Contains("kelas") || dgColumn.DisplayIndex == 0)
                        {
                            continue;
                        }
                        string kode = dgColumn.Name.Split('-')[0];
                        string jenisMataKuliah = dgColumn.HeaderText.Contains('T') ? "T" : "P";
                        int sks = int.Parse(dgColumn.HeaderText[0].ToString());
                        if (!isModeCampuran)
                        {
                            if (kodeProgramDipilih == "21" || kodeProgramDipilih == "22")
                            {
                                alokasi = listAlokasiDosenMengajar.Find(
                                                                        a => a.IdKelas == idKelas
                                                                        && a.Kode == kode
                                                                        && a.SemesterDitawarkan == LoginAccess.KodeSemester
                                                                        && a.JenisMataKuliah == jenisMataKuliah
                                                                        && a.Sks == sks);
                            }
                            else
                            {
                                alokasi = listAlokasiDosenMengajar.Find(
                                                                        a => a.IdKelas == idKelas
                                                                        && a.Kode == kode
                                                                        && a.SemesterDitawarkan == semDipilih
                                                                        && a.JenisMataKuliah == jenisMataKuliah
                                                                        && a.Sks == sks);
                            }
                        }
                        else
                        {
                            alokasi = listAlokasiDosenMengajar.Find(
                                                                    a => a.IdKelas == idKelas
                                                                    && a.Kode == kode
                                                                    //&& a.SemesterDitawarkan == 0
                                                                    && a.JenisMataKuliah == jenisMataKuliah
                                                                    && a.Sks == sks);
                        }
                        if (alokasi == null)
                        {
                            continue;
                        }
                        dgRow.Cells[dgColumn.DisplayIndex].Value = alokasi.NamaDosen;
                        dgRow.Cells[dgColumn.DisplayIndex].Tag = alokasi.NIK;
                    }
                }

            }
            else
            {
                MessageBox.Show(webApi.ReturnMessage(response));
            }
            dgvAlokasi.PerformLayout();
        }

        private async Task LoadDataDosen(string jsonData)
        {
            //Load data dosen
            response = await webApi.Post(URLGetDataDosen, jsonData, true);
            if (response.IsSuccessStatusCode)
            {
                listDataDosen = JsonConvert.DeserializeObject<List<DataDosen>>(response.Content.ReadAsStringAsync().Result);

                int no = 1;
                dgvDataDosen.Rows.Clear();
                foreach (var item in listDataDosen)
                {
                    dgvDataDosen.Rows.Add(no, item.Nik, item.NamaDosen, item.Sks);
                    no++;
                }

                txtCariDosen_TextChanged(new object(), new EventArgs());
            }
            else
            {
                MessageBox.Show(webApi.ReturnMessage(response));
            }
            dgvDataDosen.PerformLayout();
        }

        void dgvAlokasi_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            Rectangle rtHeader = this.dgvAlokasi.DisplayRectangle;
            rtHeader.Height = this.dgvAlokasi.ColumnHeadersHeight / 2;
            this.dgvAlokasi.Invalidate(rtHeader);
        }
        void dgvAlokasi_Scroll(object sender, ScrollEventArgs e)
        {
            Rectangle rtHeader = this.dgvAlokasi.DisplayRectangle;
            rtHeader.Height = this.dgvAlokasi.ColumnHeadersHeight / 2;
            this.dgvAlokasi.Invalidate(rtHeader);
        }

        void dgvAlokasi_Paint(object sender, PaintEventArgs e)
        {
            if (listTemp == null)
            { return; }

            List<string> listKodeMK = new List<string>();
            for (int i = 0; i < listTemp.Count; i++)
            {
                listKodeMK.Add(string.Format("{0} - {1}", listTemp[i].Kode, listTemp[i].MataKuliah));
            }

            for (int j = 3; j < (listKodeMK.Count * 2) + 3;)
            {
                Rectangle r1 = this.dgvAlokasi.GetCellDisplayRectangle(j, -1, true);
                int w2 = this.dgvAlokasi.GetCellDisplayRectangle(j, -1, true).Width;
                r1.X += 1;
                r1.Y += 1;
                r1.Width = r1.Width + w2 - 2;
                r1.Height = r1.Height / 2 - 2;
                e.Graphics.FillRectangle(new SolidBrush(this.dgvAlokasi.ColumnHeadersDefaultCellStyle.BackColor), r1);
                StringFormat format = new StringFormat();
                format.Alignment = StringAlignment.Center;
                format.LineAlignment = StringAlignment.Center;
                e.Graphics.DrawString(listKodeMK[(j - 3) / 2],
                    this.dgvAlokasi.ColumnHeadersDefaultCellStyle.Font,
                    new SolidBrush(this.dgvAlokasi.ColumnHeadersDefaultCellStyle.ForeColor),
                    r1,
                    format);
                j += 2;
            }
        }

        void dgvAlokasi_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex == -1 && e.ColumnIndex > -1)
            {
                Rectangle r2 = e.CellBounds;
                r2.Y += e.CellBounds.Height / 2;
                r2.Height = e.CellBounds.Height / 2;

                e.PaintBackground(r2, true);

                e.PaintContent(r2);
                e.Handled = true;
            }
        }

        private void dgvDataDosen_MouseMove(object sender, MouseEventArgs e)
        {
            dragAndDropAdd.DragMove(e, dgvDataDosen, valueAdd);
        }

        private void dgvDataDosen_MouseDown(object sender, MouseEventArgs e)
        {
            HitTestInfo hittest = dragAndDropAdd.DragMouseDownFirst(e, dgvDataDosen);

            if (hittest == null)
            {
                return;
            }

            if (hittest != null)
            {
                valueAdd = new { Nik = dgvDataDosen.Rows[hittest.RowIndex].Cells["Nik"].Value.ToString(), NamaDosen = dgvDataDosen.Rows[hittest.RowIndex].Cells["NamaDosen"].Value.ToString() };
            }
            dragAndDropAdd.DragMouseDownSecond(e, dgvAlokasi, hittest, valueAdd);
        }

        private void dgvDataDosen_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void dgvDataDosen_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void dgvAlokasi_MouseDown(object sender, MouseEventArgs e)
        {

            var hittest = dgvAlokasi.HitTest(e.X, e.Y);
            if (hittest.ColumnIndex < 0 || hittest.RowIndex < 0)
            {
                contextMenuStrip1.Items[0].Text = "Hapus Alokasi";
                contextMenuStrip1.Items[0].Enabled = false;
                contextMenuStrip1.Items[1].Enabled = false;
                return;
            }

            if (dgvAlokasi.Columns[hittest.ColumnIndex].HeaderText.Contains("0"))
            {
                contextMenuStrip1.Items[0].Text = "Hapus Alokasi";
                contextMenuStrip1.Items[0].Enabled = false;
                contextMenuStrip1.Items[1].Enabled = false;
                return;
            }
            if (dgvAlokasi.Rows[hittest.RowIndex].Cells[hittest.ColumnIndex].Value == null)
            {
                contextMenuStrip1.Items[0].Text = "Hapus Alokasi";
                contextMenuStrip1.Items[0].Enabled = false;
                contextMenuStrip1.Items[1].Enabled = false;
                return;
            }
            if (string.IsNullOrWhiteSpace(dgvAlokasi.Rows[hittest.RowIndex].Cells[hittest.ColumnIndex].Value.ToString()))
            {
                contextMenuStrip1.Items[0].Text = "Hapus Alokasi";
                contextMenuStrip1.Items[0].Enabled = false;
                contextMenuStrip1.Items[1].Enabled = false;
                return;
            }

            if (hittest.ColumnIndex == 2)
            {
                contextMenuStrip1.Items[0].Text = "Hapus Alokasi";
                contextMenuStrip1.Items[0].Enabled = false;
                contextMenuStrip1.Items[1].Enabled = false;
                return;
            }

            if (hittest.RowIndex != -1 && hittest.ColumnIndex != -1)
            {
                dgvAlokasi.ClearSelection();
                dgvAlokasi.Rows[hittest.RowIndex].Cells[hittest.ColumnIndex].Selected = true;
                var kode = dgvAlokasi.Columns[hittest.ColumnIndex].Name.Split('-')[0];
                var nik = dgvAlokasi.Rows[hittest.RowIndex].Cells[hittest.ColumnIndex].Tag.ToString();
                var namaDosen = dgvAlokasi.Rows[hittest.RowIndex].Cells[hittest.ColumnIndex].Value.ToString();
                var namaKelas = dgvAlokasi.Rows[hittest.RowIndex].Cells["KELAS"].Value.ToString();
                var idKelas = dgvAlokasi.Rows[hittest.RowIndex].Cells["IdKelas"].Value.ToString();

                contextMenuStrip1.Items[0].Enabled = true;
                contextMenuStrip1.Items[1].Enabled = true;
                //if (isModeCampuran)
                //{
                //    contextMenuStrip1.Items[1].Enabled = false;
                //}
                contextMenuStrip1.Items[0].Text = string.Format("Hapus Alokasi {0} kelas {1}", kode, namaKelas);

                valueDeleteOrSet = new
                {
                    TahunAkademik = LoginAccess.TahunAkademik,
                    Semester = LoginAccess.KodeSemester,
                    JenisMataKuliah = dgvAlokasi.Columns[hittest.ColumnIndex].Name.Contains("SKST") ? "T" : "P",
                    Kode = dgvAlokasi.Columns[hittest.ColumnIndex].Name.Split('-')[0],
                    IdKelas = idKelas,
                    Nik = nik,
                    NamaDosen = namaDosen,
                    KodeJurusan = kodeProgramDipilih,
                    RowNum = hittest.RowIndex,
                    ColNum = hittest.ColumnIndex
                };
            }
        }

        private void dgvAlokasi_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void dgvAlokasi_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private async void dgvAlokasi_DragDrop(object sender, DragEventArgs e)
        {
            if (valueAdd == null)
            {
                return;
            }

            var hittest = dragAndDropAdd.DragDrop(e, dgvAlokasi);

            if (hittest == null)
            {
                return;
            }

            if (dgvAlokasi.Columns[hittest.ColumnIndex].HeaderText.Contains("0"))
            {
                return;
            }

            if (isModeCampuran)
            {
                if (dgvAlokasi.Rows[hittest.RowIndex].Cells["Kode"].Value.ToString() != dgvAlokasi.Columns[hittest.ColumnIndex].Name.Split('-')[0].ToString())
                {
                    return;
                }
            }

            if (dgvAlokasi.Rows[hittest.RowIndex].Cells[hittest.ColumnIndex].Value != null)
            {
                MessageBox.Show("Dosen sudah teralokasi sebelumya. Silahkan hapus dulu alokasi dosen sebelumnya");
                return;
            }

            Loading(true);
            var jenisMataKuliah = dgvAlokasi.Columns[hittest.ColumnIndex].Name.Contains("SKST") ? "T" : "P";
            var kode = dgvAlokasi.Columns[hittest.ColumnIndex].Name.Split('-')[0];
            var idKelas = dgvAlokasi.Rows[hittest.RowIndex].Cells["IdKelas"].Value.ToString();
            var dataSave = new
            {
                TahunAkademik = LoginAccess.TahunAkademik,
                Semester = LoginAccess.KodeSemester,
                JenisMataKuliah = jenisMataKuliah,
                Kode = kode,
                Nik = valueAdd.Nik,
                IdKelas = idKelas,
                KodeJurusan = kodeProgramDipilih
            };

            string jsonData = JsonConvert.SerializeObject(dataSave);
            //Save alokasi dosen
            response = await webApi.Post(URLSaveAlokasiDosen, jsonData, true);
            if (response.IsSuccessStatusCode)
            {

                dgvAlokasi.Rows[hittest.RowIndex].Cells[hittest.ColumnIndex].Value = valueAdd.NamaDosen;
                dgvAlokasi.Rows[hittest.RowIndex].Cells[hittest.ColumnIndex].Tag = valueAdd.Nik;
                await LoadDataDosen(jsonData);
            }
            else
            {
                MessageBox.Show(webApi.ReturnMessage(response));
            }
            Loading(false);
            valueAdd = null;
        }

        private async void hapusAlokasiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (valueDeleteOrSet == null)
            {
                return;
            }

            Loading(true);
            string jsonData = JsonConvert.SerializeObject(valueDeleteOrSet);
            //cek delete alokasi
            response = await webApi.Post(URLCanDeleteAlokasiDosen, jsonData, true);
            if (!response.IsSuccessStatusCode)
            {
                MessageBox.Show(webApi.ReturnMessage(response));
                Loading(false);
                return;
            }

            var data = JObject.Parse(response.Content.ReadAsStringAsync().Result)["IsDosenSudahPresensi"].ToString();
            bool IsDosenSudahPresensi = bool.Parse(data);

            if (IsDosenSudahPresensi)
            {
                DialogResult dr = MessageBox.Show("Dosen sudah melakukan presensi kelas untuk mata kuliah ini, atau perkuliahan telah berlangsung.\nJika alokasi di hapus, maka presensi dosen dan mahasiswa akan ikut terhapus.\nApakah akan memproses hapus alokasi dosen?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dr == DialogResult.No)
                {
                    Loading(false);
                    return;
                }
            }

            //Delete Alokasi
            response = await webApi.Post(URLDeleteAlokasiDosen, jsonData, true);
            if (response.IsSuccessStatusCode)
            {
                int row = valueDeleteOrSet.RowNum;
                int col = valueDeleteOrSet.ColNum;
                dgvAlokasi.Rows[row].Cells[col].Value = null;
                dgvAlokasi.Rows[row].Cells[col].Tag = null;
                await LoadDataDosen(jsonData);
            }
            else
            {
                MessageBox.Show(webApi.ReturnMessage(response));
            }
            Loading(false);
            valueDeleteOrSet = null;
        }

        private void setSemuaKelasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!isModeCampuran)
            {
                using (var dialogSetDosen = new DialogSetDosenKelas(this, listKelasAktif, listKelasCampuranAktif, false, valueDeleteOrSet))
                {
                    dialogSetDosen.ShowDialog(this);
                }
            }
            else
            {
                using (var dialogSetDosen = new DialogSetDosenKelas(this, listKelasAktif, listKelasCampuranAktif, true, valueDeleteOrSet))
                {
                    dialogSetDosen.ShowDialog(this);
                }
            }
        }

        public async void saveMultiKelas(List<int> listIdKelas)
        {
            Loading(true);
            var jenisMataKuliah = valueDeleteOrSet.JenisMataKuliah;
            var kode = valueDeleteOrSet.Kode;
            var nik = valueDeleteOrSet.Nik;
            var namaDosen = valueDeleteOrSet.NamaDosen;
            foreach (int idKelas in listIdKelas)
            {
                var dataSave = new
                {
                    TahunAkademik = LoginAccess.TahunAkademik,
                    Semester = LoginAccess.KodeSemester,
                    JenisMataKuliah = jenisMataKuliah,
                    Kode = kode,
                    Nik = nik,
                    IdKelas = idKelas,
                    KodeJurusan = kodeProgramDipilih
                };

                string jsonData = JsonConvert.SerializeObject(dataSave);
                //Save Data
                response = await webApi.Post(URLSaveAlokasiDosen, jsonData, true);
                if (!response.IsSuccessStatusCode)
                {
                    MessageBox.Show(webApi.ReturnMessage(response));
                }

            }
            await LoadAlokasiDosen(semDipilih, kodeProgramDipilih);
            Loading(false);
            valueDeleteOrSet = null;
        }

        private void txtCariDosen_TextChanged(object sender, EventArgs e)
        {
            dgvDataDosen.Rows.Clear();
            int no = 1;
            foreach (DataDosen d in listDataDosen.Where(ds => ds.NamaDosen.ToLower().Contains(txtCariDosen.Text.ToLower()) || ds.Nik.Contains(txtCariDosen.Text)).ToList())
            {
                dgvDataDosen.Rows.Add(no, d.Nik, d.NamaDosen, d.Sks);
                no++;
            }
        }

        private async void btnHapusAlokasi_Click(object sender, EventArgs e)
        {
            var message = string.Empty;
            if (radCampuran.Checked)
            {
                message = string.Format("Hapus seluruh alokasi dosen mengajar untuk {0}?", radCampuran.Text);
            }
            else
            {
                message = string.Format("Hapus seluruh alokasi dosen mengajar untuk semester {0}?", semDipilih);
            }

            DialogResult dr = MessageBox.Show(message, "Perhatian", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.No)
            {
                return;
            }

            Loading(true);

            var data = new
            {
                TahunAkademik = LoginAccess.TahunAkademik,
                Semester = LoginAccess.Semester,
                IdProdi = cmbProdi.SelectedValue.ToString(),
                KodeJurusan = kodeProgramDipilih,
                SemesterDitawarkan = radCampuran.Checked ? 0 : semDipilih
            };

            var jsonData = JsonConvert.SerializeObject(data);
            response = await webApi.Post(URLDeleteAlokasiDosenBySemester, jsonData, true);
            if (!response.IsSuccessStatusCode)
            {
                MessageBox.Show(webApi.ReturnMessage(response));
                Loading(false);
                return;
            }
            await LoadAlokasiDosen(semDipilih, kodeProgramDipilih);
            MessageBox.Show("Alokasi berhasil dihapus");
            Loading(false);
        }
    }
}
