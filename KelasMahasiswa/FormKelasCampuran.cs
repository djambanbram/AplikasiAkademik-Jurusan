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
using KelasMahasiswa.Dialog;
using KelasMahasiswa.Listener;
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
    public partial class FormKelasCampuran : Syncfusion.Windows.Forms.MetroForm, IKelas
    {
        public static string baseAddress = ConfigurationManager.AppSettings["baseAddress"];
        private string URLGetMKDitawarkan = baseAddress + "/jurusan_api/api/kurikulum/get_mk_sudah_ditawarkan";
        private string URLGetKelasCampuran = baseAddress + "/jurusan_api/api/kelas/get_kelas_campuran";
        private string URLDelKelasCampuran = baseAddress + "/jurusan_api/api/kelas/del_kelas_campuran";

        private WebApi webApi;
        private HttpResponseMessage response;

        private DialogCreateKelasCampuran dialogCreateKelasCampuran;
        private string kodeProgramDipilih;

        private List<Fakultas> listFakultas;
        private List<Prodi> listProdi;
        private List<Program> listProgram;

        private dynamic dataDel;

        public FormKelasCampuran()
        {
            InitializeComponent();
            webApi = new WebApi();
        }

        private void Loading(bool isLoading)
        {
            flowLayoutPanel1.Enabled = !isLoading;
            gradientPanel1.Enabled = !isLoading;
            splitContainerAdv1.Enabled = !isLoading;
            progressBar1.Visible = isLoading;
        }

        private void btnTutup_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FormKelasCampuran_Load(object sender, EventArgs e)
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
                string idProdi = cmbProdi.SelectedValue.ToString();

                //var jenjangProdi = Organisasi.listProdi.Find(prodi => prodi.Uid == idProdi).Jenjang;
                //if (jenjangProdi == "S2")
                //{
                //    MessageBox.Show("Kelas campuran untuk prodi jenjang S2 masih dalam tahap pengembangan");
                //    cmbProdi.SelectedIndex = 0;
                //    return;
                //}

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
            kodeProgramDipilih = cmbProgram.SelectedValue.ToString();

            if (cmbProgram.SelectedIndex > 0)
            {
                await LoadKelas();
            }
            Loading(false);
        }

        private async Task LoadKelas()
        {
            var data = new { TahunAkademik = LoginAccess.TahunAkademik, Semester = LoginAccess.KodeSemester, KodeJurusan = kodeProgramDipilih };
            var jsonData = JsonConvert.SerializeObject(data);
            response = await webApi.Post(URLGetMKDitawarkan, jsonData, true);
            if (response.IsSuccessStatusCode)
            {
                dgvMKCampuran.Rows.Clear();
                List<dynamic> oListMK = JsonConvert.DeserializeObject<List<dynamic>>(response.Content.ReadAsStringAsync().Result);
                MataKuliahCampuranBinding mkBinding = new MataKuliahCampuranBinding(oListMK);
                List<DataMataKuliahCampuran> listMKCampuran = new List<DataMataKuliahCampuran>(ClassModel.MataKuliah.listDataMataKuliahCampuran);
                listMKCampuran = listMKCampuran.Where(m => m.KodeSifatMK == "P" || m.KodeSifatMK == "K" ||
                                m.MataKuliah.Contains("NON MUSLIM")).OrderBy(mk => mk.Kode).ToList();
                int no = 1;
                foreach (DataMataKuliahCampuran mk in listMKCampuran)
                {
                    dgvMKCampuran.Rows.Add(no, mk.Kode, mk.MataKuliah, mk.JumlahKelas);
                    no++;
                }
            }
            else
            {
                MessageBox.Show(webApi.ReturnMessage(response));
            }

            response = await webApi.Post(URLGetKelasCampuran, jsonData, true);
            if (response.IsSuccessStatusCode)
            {
                dgvKelasCampuran.Rows.Clear();
                List<dynamic> oListMK = JsonConvert.DeserializeObject<List<dynamic>>(response.Content.ReadAsStringAsync().Result);
                KelasCampuranAktifBinding mkBinding = new KelasCampuranAktifBinding(oListMK);

                int no = 1;
                foreach (KelasCampuranAktif mk in ClassModel.Kelas.listKelasCampuranAktif)
                {
                    dgvKelasCampuran.Rows.Add(mk.IdKelas, no, mk.Kode, mk.MataKuliah, mk.NamaKelas);
                    no++;
                }
            }
            else
            {
                MessageBox.Show(webApi.ReturnMessage(response));
            }
            dgvMKCampuran.PerformLayout();
            dgvKelasCampuran.PerformLayout();
        }

        private void btnCreateKelas_Click(object sender, EventArgs e)
        {
            if (cmbProgram.SelectedIndex <= 0)
            {
                return;
            }

            if (dialogCreateKelasCampuran == null || dialogCreateKelasCampuran.IsDisposed)
            {
                dialogCreateKelasCampuran = new DialogCreateKelasCampuran(kodeProgramDipilih, this);
            }
            dialogCreateKelasCampuran.ShowDialog(this);
        }

        private void dgvKelasCampuran_MouseDown(object sender, MouseEventArgs e)
        {
            var hittest = dgvKelasCampuran.HitTest(e.X, e.Y);
            if (hittest.ColumnIndex < 0 || hittest.RowIndex < 0)
            {
                return;
            }

            if (hittest.RowIndex != -1 && hittest.ColumnIndex != -1)
            {
                dgvKelasCampuran.ClearSelection();
                dgvKelasCampuran.Rows[hittest.RowIndex].Selected = true;
                var IdKelas = int.Parse(dgvKelasCampuran.Rows[hittest.RowIndex].Cells["IdKelas"].Value.ToString());
                var numRow = hittest.RowIndex;
                var NamaKelas = dgvKelasCampuran.Rows[hittest.RowIndex].Cells["NamaKelas"].Value.ToString();
                dataDel = new { IdKelas, numRow };
                contextMenuStrip1.Items[0].Text = string.Format("Hapus Kelas {0}", NamaKelas);
            }
        }

        private async void hapusKelasCampuranToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Loading(true);

            if (dataDel != null)
            {
                string jData = JsonConvert.SerializeObject(dataDel);
                response = await webApi.Post(URLDelKelasCampuran, jData, true);
                if (response.IsSuccessStatusCode)
                {
                    dgvKelasCampuran.Rows.RemoveAt(dataDel.numRow);
                }
                else
                {
                    MessageBox.Show(webApi.ReturnMessage(response));
                }
            }

            var data = new { TahunAkademik = LoginAccess.TahunAkademik, Semester = LoginAccess.KodeSemester, KodeJurusan = kodeProgramDipilih };
            var jsonData = JsonConvert.SerializeObject(data);
            response = await webApi.Post(URLGetMKDitawarkan, jsonData, true);
            if (response.IsSuccessStatusCode)
            {
                dgvMKCampuran.Rows.Clear();
                List<dynamic> oListMK = JsonConvert.DeserializeObject<List<dynamic>>(response.Content.ReadAsStringAsync().Result);
                MataKuliahCampuranBinding mkBinding = new MataKuliahCampuranBinding(oListMK);
                List<DataMataKuliahCampuran> listMKCampuran = new List<DataMataKuliahCampuran>(ClassModel.MataKuliah.listDataMataKuliahCampuran);
                listMKCampuran = listMKCampuran.Where(m => m.KodeSifatMK == "P" || m.KodeSifatMK == "K" ||
                                m.MataKuliah.Contains("NON MUSLIM")).OrderBy(mk => mk.Kode).ToList();

                int no = 1;
                foreach (DataMataKuliahCampuran mk in listMKCampuran)
                {
                    dgvMKCampuran.Rows.Add(no, mk.Kode, mk.MataKuliah, mk.JumlahKelas);
                    no++;
                }
            }
            else
            {
                MessageBox.Show(webApi.ReturnMessage(response));
            }
            dataDel = null;
            Loading(false);
        }

        public async void loadKelas()
        {
            Loading(true);
            await LoadKelas();
            Loading(false);
        }
    }
}
