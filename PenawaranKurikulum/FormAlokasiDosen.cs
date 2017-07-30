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
using static System.Windows.Forms.DataGridView;

namespace PenawaranKurikulum
{
    public partial class FormAlokasiDosen : Syncfusion.Windows.Forms.MetroForm
    {
        public static string baseAddress = ConfigurationManager.AppSettings["baseAddress"];
        private string URLGetMKSudahDitawarkan = baseAddress + "/jurusan_api/api/kurikulum/get_mk_sudah_ditawarkan";
        private string URLGetKelasAktif = baseAddress + "/jurusan_api/api/kelas/get_kelas_reguler";

        private WebApi webApi;
        private HttpResponseMessage response;

        private List<Fakultas> listFakultas;
        private List<Prodi> listProdi;
        private List<Program> listProgram;

        private List<MataKuliahDitawarkan> listTemp;

        private int[] ganjil = { 1, 3, 5, 7 };
        private int[] genap = { 2, 4, 6, 8 };

        private int semDipilih;
        private string kodeProgramDipilih;

        private DragandDrop dragAndDropAdd;
        private DragandDrop dragAndDropDelete;
        private dynamic valueAdd;
        private dynamic valueDeleteOrSet;

        public FormAlokasiDosen()
        {
            InitializeComponent();
            dgvAlokasi.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;
            dgvAlokasi.EnableHeadersVisualStyles = false;
            webApi = new WebApi();

            dragAndDropAdd = new DragandDrop();
            dragAndDropDelete = new DragandDrop();

            dgvDataDosen.Rows.Add(1, "190302219", "Bram Pratowo", 4);
            dgvDataDosen.Rows.Add(2, "190302220", "Ega Hardianto", 4);
            dgvDataDosen.Rows.Add(3, "190302221", "Nopi Hardiyanti", 4);
            dgvDataDosen.Rows.Add(4, "190302222", "Vivia Ratnawati", 4);
            dgvDataDosen.Rows.Add(5, "190302223", "Puguh Hasta Gunawan", 4);
        }

        private void btnTutup_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FormAlokasiDosen_Load(object sender, EventArgs e)
        {
            listFakultas = new List<Fakultas>(Organisasi.listFakultas);
            listFakultas.Insert(0, new Fakultas() { KodeFakultas = "-", NamaFakultas = "Pilih" });
            cmbFakultas.DataSource = listFakultas;
            cmbFakultas.DisplayMember = "NamaFakultas";
            cmbFakultas.ValueMember = "KodeFakultas";
            cmbFakultas.SelectedIndex = 0;

            if (LoginAccess.KodeSemester % 2 == 1)
            {
                rad1.Text = "1";
                rad2.Text = "3";
                rad3.Text = "5";
                rad4.Text = "7";
            }
            else
            {
                rad1.Text = "2";
                rad2.Text = "4";
                rad3.Text = "6";
                rad4.Text = "8";
            }
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

        private void cmbProgram_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbProgram.SelectedIndex > 0)
            {
                int sem = 0;
                if (rad1.Checked)
                {
                    sem = int.Parse(rad1.Text);
                }
                else if (rad2.Checked)
                {
                    sem = int.Parse(rad2.Text);
                }
                else if (rad3.Checked)
                {
                    sem = int.Parse(rad3.Text);
                }
                else if (rad4.Checked)
                {
                    sem = int.Parse(rad4.Text);
                }
                semDipilih = sem;
                kodeProgramDipilih = cmbProgram.SelectedValue.ToString();
                LoadAlokasiDosen(semDipilih, kodeProgramDipilih);
            }
        }

        private void radioChecked(object sender, EventArgs e)
        {
            if (cmbProgram.SelectedIndex > 0 && (((RadioButton)sender).Checked))
            {
                semDipilih = int.Parse(((RadioButton)sender).Text);
                kodeProgramDipilih = cmbProgram.SelectedValue.ToString();
                LoadAlokasiDosen(semDipilih, kodeProgramDipilih);
            }
        }

        private async void LoadAlokasiDosen(int semester, string kodeProgram)
        {
            var data = new
            {
                TahunAkademik = LoginAccess.TahunAkademik,
                KodeJurusan = cmbProgram.SelectedValue.ToString(),
                Semester = LoginAccess.KodeSemester,
                IdProdi = cmbProdi.SelectedValue.ToString()
            };
            string jsonData = JsonConvert.SerializeObject(data);
            response = await webApi.Post(URLGetMKSudahDitawarkan, jsonData, true);
            if (response.IsSuccessStatusCode)
            {
                List<dynamic> oListMkSudahDitawarkan = JsonConvert.DeserializeObject<List<dynamic>>(response.Content.ReadAsStringAsync().Result);
                MataKuliahSudahDitawarkanBinding mkBinding = new MataKuliahSudahDitawarkanBinding(oListMkSudahDitawarkan);
                dgvAlokasi.Columns.Clear();

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
                dgColumnKelas.Width = 100;
                dgColumnKelas.ValueType = typeof(string);
                dgColumnKelas.SortMode = DataGridViewColumnSortMode.NotSortable;
                dgColumnKelas.DefaultCellStyle.BackColor = Color.LightGray;
                dgColumnKelas.DefaultCellStyle.SelectionBackColor = Color.LightGray;
                dgColumnKelas.DefaultCellStyle.SelectionForeColor = Color.Black;
                dgColumnKelas.Frozen = true;
                dgvAlokasi.Columns.Add(dgColumnKelas);

                listTemp = MataKuliah.listMataKuliahSudahDitawarkan.Where(m => m.SemesterDitawarkan == semDipilih && m.KodeSifatMK == "W").ToList();
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

            var dataKelasMhs = new { KodeJurusan = cmbProgram.SelectedValue.ToString(), TahunAkademik = LoginAccess.TahunAkademik, Semester = LoginAccess.KodeSemester };
            string jsonDataKelas = JsonConvert.SerializeObject(dataKelasMhs);
            response = await webApi.Post(URLGetKelasAktif, jsonDataKelas, true);
            if (response.IsSuccessStatusCode)
            {
                List<KelasAktif> oListKelasAktif = JsonConvert.DeserializeObject<List<KelasAktif>>(response.Content.ReadAsStringAsync().Result).Where(kls => kls.SemesterDitawarkan == semDipilih).ToList();
                foreach (KelasAktif item in oListKelasAktif)
                {
                    dgvAlokasi.Rows.Add(item.IdKelas, item.NamaKelas);
                }
            }
            else
            {
                MessageBox.Show(webApi.ReturnMessage(response));
            }

            foreach (DataGridViewTextBoxColumn dgc in dgvAlokasi.Columns)
            {
                if (dgc.HeaderText.Contains("0"))
                {
                    dgc.DefaultCellStyle.BackColor = Color.LightGray;
                }
            }
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

            for (int j = 0 + 1; j <= listKodeMK.Count * 2;)
            {
                Rectangle r1 = this.dgvAlokasi.GetCellDisplayRectangle(j, -1, true);
                int w2 = this.dgvAlokasi.GetCellDisplayRectangle(j + 1, -1, true).Width;
                r1.X += 1;
                r1.Y += 1;
                r1.Width = r1.Width + w2 - 2;
                r1.Height = r1.Height / 2 - 2;
                e.Graphics.FillRectangle(new SolidBrush(this.dgvAlokasi.ColumnHeadersDefaultCellStyle.BackColor), r1);
                StringFormat format = new StringFormat();
                format.Alignment = StringAlignment.Center;
                format.LineAlignment = StringAlignment.Center;
                e.Graphics.DrawString(listKodeMK[(j - 1) / 2],
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
            if (hittest != null)
            {
                valueAdd = new { Nik = dgvDataDosen.Rows[hittest.RowIndex].Cells["NIK"].Value.ToString() };
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

        private void dgvDataDosen_DragDrop(object sender, DragEventArgs e)
        {
            var hittest = dragAndDropDelete.DragDrop(e, dgvDataDosen);
            if (valueDeleteOrSet == null)
            {
                return;
            }
            if (string.IsNullOrWhiteSpace(valueDeleteOrSet.NIK) ||
                string.IsNullOrWhiteSpace(valueDeleteOrSet.JenisKuliah) ||
                string.IsNullOrWhiteSpace(valueDeleteOrSet.Kode))
            {
                return;
            }

            var dataDelete = new
            {
                TahunAkademik = LoginAccess.TahunAkademik,
                Semester = LoginAccess.KodeSemester,
                JenisKuliah = valueDeleteOrSet.JenisKuliah,
                Kode = valueDeleteOrSet.Kode,
                NIK = valueDeleteOrSet.NIK,
                KodeProgram = kodeProgramDipilih
            };

            //Delete Data

            int row = valueDeleteOrSet.rowNum;
            int col = valueDeleteOrSet.colNum;
            dgvAlokasi.Rows[row].Cells[col].Value = null;
            valueDeleteOrSet = null;
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

            if (hittest.RowIndex != -1 && hittest.ColumnIndex != -1)
            {
                dgvAlokasi.ClearSelection();
                dgvAlokasi.Rows[hittest.RowIndex].Cells[hittest.ColumnIndex].Selected = true;
                var kode = dgvAlokasi.Columns[hittest.ColumnIndex].Name.Split('-')[0];
                var nik = dgvAlokasi.Rows[hittest.RowIndex].Cells[hittest.ColumnIndex].Value.ToString();
                var NamaKelas = dgvAlokasi.Rows[hittest.RowIndex].Cells["KELAS"].Value.ToString();
                var IdKelas = dgvAlokasi.Rows[hittest.RowIndex].Cells["IdKelas"].Value.ToString();

                contextMenuStrip1.Items[0].Enabled = true;
                contextMenuStrip1.Items[1].Enabled = true;
                contextMenuStrip1.Items[0].Text = string.Format("Hapus Alokasi {0} kelas {1}", kode, NamaKelas);

                valueDeleteOrSet = new
                {
                    TahunAkademik = LoginAccess.TahunAkademik,
                    Semester = LoginAccess.KodeSemester,
                    JenisKuliah = dgvAlokasi.Columns[hittest.ColumnIndex].Name.Contains("SKST") ? "T" : "P",
                    Kode = dgvAlokasi.Columns[hittest.ColumnIndex].Name.Split('-')[0],
                    IdKelas = dgvAlokasi.Rows[hittest.RowIndex].Cells["IdKelas"].Value.ToString(),
                    NIK = dgvAlokasi.Rows[hittest.RowIndex].Cells[hittest.ColumnIndex].Value.ToString(),
                    KodeProgram = kodeProgramDipilih,
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

        private void dgvAlokasi_DragDrop(object sender, DragEventArgs e)
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

            if (dgvAlokasi.Rows[hittest.RowIndex].Cells[hittest.ColumnIndex].Value != null)
            {
                MessageBox.Show("Dosen sudah teralokasi sebelumya. Silahkan hapus dulu alokasi dosen sebelumnya");
                return;
            }

            var jenisKuliah = dgvAlokasi.Columns[hittest.ColumnIndex].Name.Contains("SKST") ? "T" : "P";
            var kode = dgvAlokasi.Columns[hittest.ColumnIndex].Name.Split('-')[0];
            var idKelas = dgvAlokasi.Rows[hittest.RowIndex].Cells["IdKelas"].Value.ToString();
            var dataSave = new
            {
                TahunAkademik = LoginAccess.TahunAkademik,
                Semester = LoginAccess.KodeSemester,
                JenisKuliah = jenisKuliah,
                Kode = kode,
                Nik = valueAdd.Nik,
                IdKelas = idKelas,
                KodeProgram = kodeProgramDipilih
            };

            string jsonData = JsonConvert.SerializeObject(dataSave);
            //Save alokasi dosen

            dgvAlokasi.Rows[hittest.RowIndex].Cells[hittest.ColumnIndex].Value = valueAdd.Nik;
            valueAdd = null;
        }

        private void hapusAlokasiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (valueDeleteOrSet == null)
            {
                return;
            }

            string jsonData = JsonConvert.SerializeObject(valueDeleteOrSet);
            //Delete Alokasi

            int row = valueDeleteOrSet.RowNum;
            int col = valueDeleteOrSet.ColNum;
            dgvAlokasi.Rows[row].Cells[col].Value = null;
            valueDeleteOrSet = null;
        }

        private void setSemuaKelasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int row = valueDeleteOrSet.RowNum + 1;
            int col = valueDeleteOrSet.ColNum;
            var nik = valueDeleteOrSet.NIK;
            var kode = valueDeleteOrSet.Kode;
            var jenisKuliah = valueDeleteOrSet.JenisKuliah;

            for (int i = row; i < dgvAlokasi.Rows.Count; i++)
            {
                if (dgvAlokasi.Rows[i].Cells[col].Value == null)
                {
                    var idKelas = dgvAlokasi.Rows[i].Cells["IdKelas"].Value.ToString();
                    var dataSave = new
                    {
                        TahunAkademik = LoginAccess.TahunAkademik,
                        Semester = LoginAccess.KodeSemester,
                        JenisKuliah = jenisKuliah,
                        Kode = kode,
                        NIK = nik,
                        IdKelas = idKelas,
                        KodeProgram = kodeProgramDipilih
                    };

                    string jsonData = JsonConvert.SerializeObject(dataSave);
                    //Save Data

                    dgvAlokasi.Rows[i].Cells[col].Value = nik;
                }
            }

            valueDeleteOrSet = null;
        }
    }
}
