#region Copyright Syncfusion Inc. 2001 - 2016
// Copyright Syncfusion Inc. 2001 - 2016. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using AdvancedDataGridView;
using ApiService;
using ClassModel;
using Newtonsoft.Json;
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

namespace PenawaranKurikulum
{
    public partial class FormAlokasiLabMK : Syncfusion.Windows.Forms.MetroForm, IRefreshAlokasiRuang
    {
        public static string baseAddress = ConfigurationManager.AppSettings["baseAddress"];
        private string URLGetMKSudahDitawarkan = baseAddress + "/jurusan_api/api/kurikulum/get_mk_sudah_ditawarkan";
        private string URLGetRuangan = baseAddress + "/jurusan_api/api/kelas/get_ruangan";
        private string URLGetMemberRuangan = baseAddress + "/jurusan_api/api/kelas/get_member_lab";
        private string URLSaveMemberRuangan = baseAddress + "/jurusan_api/api/kelas/save_member_lab";
        private string URLDelMemberRuangan = baseAddress + "/jurusan_api/api/kelas/del_member_lab";
        private string URLUpdateMemberRuangan = baseAddress + "/jurusan_api/api/kelas/update_member_lab";

        private WebApi webApi;
        private HttpResponseMessage response;

        private List<Fakultas> listFakultas;
        private List<Prodi> listProdi;
        private List<Program> listProgram;
        private List<MemberKelas> listMemberRuangan;

        private string kodeProgramDipilih;
        private string idProdiDipilih;

        private DragandDrop dragAndDropAdd;
        private DragandDrop dragAndDropDelete;

        private dynamic valueAdd;
        private dynamic valueDelete;
        private dynamic valueUpdate;

        public FormAlokasiLabMK()
        {
            InitializeComponent();
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
            gradientPanel2.Enabled = !isLoading;
            flowLayoutPanel1.Enabled = !isLoading;
            progressBar1.Visible = isLoading;
        }

        private void FormAlokasiLabMK_Load(object sender, EventArgs e)
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

        private async void cmbProgram_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbProgram.SelectedIndex > 0)
            {
                Loading(true);
                kodeProgramDipilih = cmbProgram.SelectedValue.ToString();
                var data = new
                {
                    TahunAkademik = LoginAccess.TahunAkademik,
                    KodeJurusan = kodeProgramDipilih,
                    Semester = LoginAccess.KodeSemester,
                    IdProdi = cmbProdi.SelectedValue.ToString()
                };

                string jsonData = JsonConvert.SerializeObject(data);

                await LoadMK(jsonData);
                await LoadLabDanMember(jsonData);

                Loading(false);
            }
        }

        private async Task LoadMK(string jsonData)
        {

            //Load Mata Kuliah
            response = await webApi.Post(URLGetMKSudahDitawarkan, jsonData, true);
            if (response.IsSuccessStatusCode)
            {
                List<dynamic> oListMkSudahDitawarkan = JsonConvert.DeserializeObject<List<dynamic>>(response.Content.ReadAsStringAsync().Result);
                MataKuliahSudahDitawarkanBinding mkBinding = new MataKuliahSudahDitawarkanBinding(oListMkSudahDitawarkan);
                dgvMKPraktikum.Rows.Clear();
                List<MataKuliahDitawarkan> tempList = new List<MataKuliahDitawarkan>(ClassModel.MataKuliah.listMataKuliahSudahDitawarkan);
                int no = 1;
                foreach (MataKuliahDitawarkan mk in tempList.Where(mktsd => mktsd.SksPraktikum != 0).ToList())
                {
                    dgvMKPraktikum.Rows.Add(no, mk.Kode, mk.MataKuliah, mk.SksTeori, mk.SksPraktikum, mk.JumlahKelasPraktikum);
                    no++;
                }
            }
            else
            {
                MessageBox.Show(webApi.ReturnMessage(response));
            }
            dgvMKPraktikum.PerformLayout();
        }

        private async Task LoadLabDanMember(string jsonData)
        {

            //Load Ruangan
            response = await webApi.Post(URLGetRuangan, string.Empty, true);
            dgvDaftarLab.Nodes.Clear();
            if (response.IsSuccessStatusCode)
            {
                List<dynamic> listRuangan = JsonConvert.DeserializeObject<List<dynamic>>(response.Content.ReadAsStringAsync().Result);
                listRuangan = listRuangan.Where(r => r.IsDipakaiPraktikum == 1).ToList();
                foreach (var item in listRuangan)
                {
                    dgvDaftarLab.Nodes.Add(null, item.Ruang, null, null, null, null, null, null, "1");
                }
            }
            else
            {
                MessageBox.Show(webApi.ReturnMessage(response));
            }

            //Load member ruangan
            response = await webApi.Post(URLGetMemberRuangan, jsonData, true);
            if (response.IsSuccessStatusCode)
            {
                listMemberRuangan = JsonConvert.DeserializeObject<List<MemberKelas>>(response.Content.ReadAsStringAsync().Result);
                foreach (TreeGridNode tgn in dgvDaftarLab.Nodes)
                {
                    int i = 0;
                    foreach (var item in listMemberRuangan)
                    {
                        if (tgn.Cells["Ruang"].Value.ToString() == item.Ruang)
                        {
                            tgn.Nodes.Add(null, null, item.Kode, item.MataKuliah, item.JumlahKelas, item.TotalKelas, item.KodeProgram, item.NamaProgram, "0");
                            tgn.Nodes[i].DefaultCellStyle.BackColor = Color.LightGray;
                            i++;
                        }
                    }
                    tgn.Expand();
                    i = 0;
                }
            }
            else
            {
                MessageBox.Show(webApi.ReturnMessage(response)); ;
            }
            dgvDaftarLab.PerformLayout();
        }

        private void dgvDaftarLab_MouseMove(object sender, MouseEventArgs e)
        {
            dragAndDropDelete.DragMove(e, dgvDaftarLab, valueDelete);
        }

        private void dgvDaftarLab_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var hittestRightClick = dgvDaftarLab.HitTest(e.X, e.Y);
                if (hittestRightClick.ColumnIndex < 0 || hittestRightClick.RowIndex < 0)
                {
                    contextMenuStrip1.Items[0].Enabled = false;
                    return;
                }
                if (dgvDaftarLab.Rows[hittestRightClick.RowIndex].Cells["Parent"].Value.ToString() == "1")
                {
                    contextMenuStrip1.Items[0].Enabled = false;
                    return;
                }

                contextMenuStrip1.Items[0].Enabled = true;
                DataGridViewRow dgvRow = dgvDaftarLab.Rows[hittestRightClick.RowIndex];
                string kode = dgvRow.Cells["tKode"].Value.ToString();
                string ruang = dgvDaftarLab.GetNodeForRow(hittestRightClick.RowIndex).Parent.Cells["Ruang"].Value.ToString();
                string mataKuliah = dgvRow.Cells["tMataKuliah"].Value.ToString();
                string totalKelas = dgvRow.Cells["TotalKelas"].Value.ToString();
                string jmlKelas = dgvRow.Cells["tJumlahKelas"].Value.ToString();
                string namaProgram = dgvRow.Cells["NamaProgram"].Value.ToString();

                valueUpdate = new
                {
                    kode,
                    ruang,
                    mataKuliah,
                    totalKelas,
                    jmlKelas,
                    namaProgram
                };
                return;
            }


            var hittest = dragAndDropDelete.DragMouseDownFirst(e, dgvDaftarLab);
            if (hittest == null)
            {
                return;
            }

            if (hittest.RowIndex < 0 || hittest.ColumnIndex < 0)
            {
                return;
            }

            if (dgvDaftarLab.Rows[hittest.RowIndex].Cells["Parent"].Value.ToString() == "1")
            {
                valueDelete = null;
                return;
            }

            TreeGridNode dgRow = dgvDaftarLab.Rows[hittest.RowIndex] as TreeGridNode;

            valueDelete = new
            {
                TahunAkademik = LoginAccess.TahunAkademik,
                Semester = LoginAccess.KodeSemester,
                KodeJurusan = kodeProgramDipilih,
                KodeJurusanMKDel = dgRow.Cells["KodeProgram"].Value.ToString(),
                IdProdi = idProdiDipilih,
                Kode = dgRow.Cells["tKode"].Value.ToString(),
                Ruang = dgRow.Parent.Cells["Ruang"].Value.ToString(),
                JumlahKelas = dgRow.Cells["tJumlahKelas"].Value.ToString(),
                RowChild = dgRow.Parent.Nodes.IndexOf(dgRow),
                RowCurrent = hittest.RowIndex
            };
            dragAndDropDelete.DragMouseDownSecond(e, dgvMKPraktikum, hittest, valueDelete);
        }

        private void dgvDaftarLab_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void dgvDaftarLab_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void dgvDaftarLab_DragDrop(object sender, DragEventArgs e)
        {
            if (valueAdd == null)
            {
                return;
            }

            var hittest = dragAndDropAdd.DragDrop(e, dgvDaftarLab);
            if (hittest == null)
            {
                return;
            }
            if (hittest.RowIndex < 0 || hittest.ColumnIndex < 0)
            {
                return;
            }
            if (dgvDaftarLab.Rows[hittest.RowIndex].Cells["Parent"].Value.ToString() == "0")
            {
                MessageBox.Show("Drag di mata kuliah yang perlu prasyarat (baris berwarna putih)");
                valueAdd = null;
                return;
            }

            TreeGridNode nodeParent = dgvDaftarLab.Rows[hittest.RowIndex] as TreeGridNode;
            using (var dialogSetJumlahKelas = new DialogSetJumlahKelas(listMemberRuangan,
                nodeParent.Cells["Ruang"].Value.ToString(),
                valueAdd.Kode,
                valueAdd.MataKuliah,
                valueAdd.JumlahKelas,
                cmbProgram.Text,
                this
                ))
            {
                dialogSetJumlahKelas.ShowDialog(this);
            }
            valueAdd = null;
        }

        private void dgvMKPraktikum_MouseMove(object sender, MouseEventArgs e)
        {
            dragAndDropAdd.DragMove(e, dgvMKPraktikum, valueAdd);
        }

        private void dgvMKPraktikum_MouseDown(object sender, MouseEventArgs e)
        {
            var hittest = dragAndDropAdd.DragMouseDownFirst(e, dgvMKPraktikum);
            if (hittest == null)
            {
                return;
            }

            if (hittest.RowIndex < 0 || hittest.ColumnIndex < 0)
            {
                return;
            }

            DataGridViewRow dgRow = dgvMKPraktikum.Rows[hittest.RowIndex];

            valueAdd = new
            {
                TahunAkademik = LoginAccess.TahunAkademik,
                Semester = LoginAccess.KodeSemester,
                KodeJurusan = kodeProgramDipilih,
                IdProdi = idProdiDipilih,
                Kode = dgRow.Cells["Kode"].Value.ToString(),
                JumlahKelas = int.Parse(dgRow.Cells["JumlahKelas"].Value.ToString()),
                MataKuliah = dgRow.Cells["MataKuliah"].Value.ToString()
            };

            dragAndDropAdd.DragMouseDownSecond(e, dgvDaftarLab, hittest, valueAdd);
        }

        private void dgvMKPraktikum_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void dgvMKPraktikum_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private async void dgvMKPraktikum_DragDrop(object sender, DragEventArgs e)
        {
            if (valueDelete == null)
            {
                return;
            }
            var hittest = dragAndDropDelete.DragDrop(e, dgvMKPraktikum);

            int rowParent = valueDelete.RowCurrent;
            int rowDel = valueDelete.RowChild;

            if(valueDelete.KodeJurusanMKDel != valueDelete.KodeJurusan)
            {
                MessageBox.Show("Anda tidak bisa menghapus alokasi jurusan lain");
                return;
            }

            //Delete Alokasi Lab
            string jsonData = JsonConvert.SerializeObject(valueDelete);
            response = await webApi.Post(URLDelMemberRuangan, jsonData, true);
            if (response.IsSuccessStatusCode)
            {
                var nodeParent = dgvDaftarLab.GetNodeForRow(rowParent).Parent;
                if (nodeParent.HasChildren)
                {
                    nodeParent.Nodes.RemoveAt(rowDel);
                }
            }
            else
            {
                MessageBox.Show(webApi.ReturnMessage(response));
            }

            await LoadLabDanMember(jsonData);
            valueDelete = null;
        }

        public async void saveJumlahKelas(string ruang, int jumlahKelas, string kode)
        {
            var dataSave = new
            {
                TahunAkademik = LoginAccess.TahunAkademik,
                Semester = LoginAccess.KodeSemester,
                KodeJurusan = kodeProgramDipilih,
                IdProdi = idProdiDipilih,
                Ruang = ruang,
                JumlahKelas = jumlahKelas,
                Kode = kode
            };
            string jsonData = JsonConvert.SerializeObject(dataSave);

            response = await webApi.Post(URLSaveMemberRuangan, jsonData, true);
            if (!response.IsSuccessStatusCode)
            {
                MessageBox.Show(webApi.ReturnMessage(response));
                Loading(false);
                return;
            }

            await LoadLabDanMember(jsonData);

            valueAdd = null;
            Loading(false);
        }

        public async void updateJumlahKelas(string ruang, int jumlahKelas, string kode)
        {
            var dataSave = new
            {
                TahunAkademik = LoginAccess.TahunAkademik,
                Semester = LoginAccess.KodeSemester,
                KodeJurusan = kodeProgramDipilih,
                IdProdi = idProdiDipilih,
                Ruang = ruang,
                JumlahKelas = jumlahKelas,
                Kode = kode
            };
            string jsonData = JsonConvert.SerializeObject(dataSave);

            response = await webApi.Post(URLUpdateMemberRuangan, jsonData, true);
            if (!response.IsSuccessStatusCode)
            {
                MessageBox.Show(webApi.ReturnMessage(response));
                return;
            }

            await LoadLabDanMember(jsonData);
        }

        private void ubahJumlahKelasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(valueUpdate == null)
            {
                return;
            }

            using (var dialogSetJumlahKelas = new DialogSetJumlahKelas(valueUpdate.ruang, valueUpdate.kode, valueUpdate.mataKuliah, int.Parse(valueUpdate.totalKelas), int.Parse(valueUpdate.jmlKelas), valueUpdate.namaProgram, this))
            {
                dialogSetJumlahKelas.ShowDialog(this);
            }
        }
    }
}
