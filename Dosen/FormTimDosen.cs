#region Copyright Syncfusion Inc. 2001 - 2016
// Copyright Syncfusion Inc. 2001 - 2016. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using ApiService;
using ClassModel;
using Dosen.Lib;
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

namespace Dosen
{
    public partial class FormTimDosen : Syncfusion.Windows.Forms.MetroForm
    {
        public static string baseAddress = ConfigurationManager.AppSettings["baseAddress"];
        private string URLGetDataDosen = baseAddress + "/jurusan_api/api/pengajaran/get_dosen";
        private string URLSaveTimDosen = baseAddress + "/jurusan_api/api/dosen/save_tim_dosen";
        private string URLGetTimDosen = baseAddress + "/jurusan_api/api/dosen/get_tim_dosen";
        private string URLDelTimDosen = baseAddress + "/jurusan_api/api/dosen/del_tim_dosen";

        private WebApi webApi;
        private HttpResponseMessage response;
        private DragandDrop dragAndDropAdd;
        private DragandDrop dragAndDropDelete;

        private List<DataDosen> listDataDosen;
        private dynamic valueAdd;
        private dynamic valueDelete;

        private List<Fakultas> listFakultas;
        private List<Prodi> listProdi;
        private List<Program> listProgram;

        public FormTimDosen()
        {
            InitializeComponent();
            webApi = new WebApi();
            dragAndDropAdd = new DragandDrop();
            dragAndDropDelete = new DragandDrop();
        }

        private void Loading(bool isLoading)
        {
            gradientPanel2.Enabled = !isLoading;
            dgvTimDosen.Enabled = !isLoading;
            flowLayoutPanel1.Enabled = !isLoading;

            progressBar1.Visible = isLoading;
        }

        private void btnTutup_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void FormTimDosen_Load(object sender, EventArgs e)
        {
            Loading(true);

            listFakultas = new List<Fakultas>(Organisasi.listFakultas);
            listFakultas.Insert(0, new Fakultas() { KodeFakultas = "-", NamaFakultas = "Pilih" });
            cmbFakultas.DataSource = listFakultas;
            cmbFakultas.DisplayMember = "NamaFakultas";
            cmbFakultas.ValueMember = "KodeFakultas";
            cmbFakultas.SelectedIndex = 0;

            var getData = new { TahunAkademik = LoginAccess.TahunAkademik, Semester = LoginAccess.KodeSemester };
            var jsonData = JsonConvert.SerializeObject(getData);
            response = await webApi.Post(URLGetDataDosen, jsonData, true);
            if (!response.IsSuccessStatusCode)
            {
                MessageBox.Show(webApi.ReturnMessage(response));
                Loading(false);
                return;
            }

            dgvDosen.Rows.Clear();
            listDataDosen = JsonConvert.DeserializeObject<List<DataDosen>>(response.Content.ReadAsStringAsync().Result);
            if (listDataDosen.Count > 0)
            {
                listDataDosen.ForEach(delegate (DataDosen d)
                {
                    dgvDosen.Rows.Add(d.Nik, d.NamaDosen);
                });
            }
            Loading(false);
        }

        private void txtCari_TextChanged(object sender, EventArgs e)
        {
            List<DataDosen> tempList = listDataDosen.Where(d => d.Nik.ToLower().Contains(txtCari.Text.ToLower()) || d.NamaDosen.ToLower().Contains(txtCari.Text.ToLower())).ToList();
            dgvDosen.Rows.Clear();
            tempList.ForEach(delegate (DataDosen d)
            {
                dgvDosen.Rows.Add(d.Nik, d.NamaDosen);
            });
        }

        private void dgvDosen_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void dgvDosen_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void dgvDosen_DragDrop(object sender, DragEventArgs e)
        {
            var hittest = dragAndDropDelete.DragDrop(e, dgvDosen);
            var rowDel = int.Parse(valueDelete.RowDel.ToString());
            dgvAddTim.Rows.RemoveAt(rowDel);
            valueAdd = null;
            valueDelete = null;
        }

        private void dgvDosen_MouseMove(object sender, MouseEventArgs e)
        {
            dragAndDropAdd.DragMove(e, dgvDosen, valueAdd);
        }

        private void dgvDosen_MouseDown(object sender, MouseEventArgs e)
        {
            var hittest = dragAndDropAdd.DragMouseDownFirst(e, dgvDosen);
            if (hittest == null)
            {
                return;
            }

            var nik = dgvDosen.Rows[hittest.RowIndex].Cells["tNik"].Value.ToString();
            var namaDosen = dgvDosen.Rows[hittest.RowIndex].Cells["tDosen"].Value.ToString();
            valueAdd = new { Nik = nik, NamaDosen = namaDosen };
            dragAndDropAdd.DragMouseDownSecond(e, dgvAddTim, hittest, valueAdd);
        }

        private void dgvAddTim_DragDrop(object sender, DragEventArgs e)
        {
            var hittest = dragAndDropAdd.DragDrop(e, dgvAddTim);

            var nik = valueAdd.Nik as string;
            var namaDosen = valueAdd.NamaDosen as string;

            foreach (DataGridViewRow row in dgvAddTim.Rows)
            {
                if (row.Cells["Nik"].Value.ToString() == nik)
                {
                    MessageBox.Show(string.Format("{0} ({1}) sudah masuk ke dalam grup ini", namaDosen, nik));
                    return;
                }
            }

            dgvAddTim.Rows.Add(valueAdd.Nik, valueAdd.NamaDosen);
            valueAdd = null;
            valueDelete = null;
        }

        private void dgvAddTim_MouseDown(object sender, MouseEventArgs e)
        {
            var hittest = dragAndDropDelete.DragMouseDownFirst(e, dgvAddTim);
            if (hittest == null)
            {
                return;
            }

            var rowDel = hittest.RowIndex;
            valueDelete = new { RowDel = rowDel };
            dragAndDropDelete.DragMouseDownSecond(e, dgvDosen, hittest, valueDelete);
        }

        private void dgvAddTim_MouseMove(object sender, MouseEventArgs e)
        {
            dragAndDropDelete.DragMove(e, dgvAddTim, valueDelete);
        }

        private void dgvAddTim_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void dgvAddTim_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
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

        private async void btnSimpan_Click(object sender, EventArgs e)
        {
            if (cmbProgram.SelectedIndex <= 0 || string.IsNullOrWhiteSpace(txtNamaGrup.Text))
            {
                MessageBox.Show("Program prodi dan nama tim harus diisi");
                return;
            }

            var kodeProgram = cmbProgram.SelectedValue.ToString();
            var tahunAkademik = LoginAccess.TahunAkademik;
            var semester = LoginAccess.KodeSemester;
            var arrNik = new string[dgvAddTim.Rows.Count];
            int i = 0;
            foreach (DataGridViewRow row in dgvAddTim.Rows)
            {
                arrNik[i] = row.Cells["NIk"].Value.ToString();
                i++;
            }
            var namaTim = txtNamaGrup.Text;
            var dataSave = new
            {
                KodeJurusan = kodeProgram,
                TahunAkademik = tahunAkademik,
                Semester = semester,
                NIK = arrNik,
                NamaTim = namaTim
            };

            Loading(true);
            var jsonData = JsonConvert.SerializeObject(dataSave);
            response = await webApi.Post(URLSaveTimDosen, jsonData, true);
            if (!response.IsSuccessStatusCode)
            {
                MessageBox.Show(webApi.ReturnMessage(response));
                Loading(false);
                return;
            }

            await LoadTimDosen();

            Loading(false);
        }

        private async void cmbProgram_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbProgram.SelectedIndex == 0)
            {
                dgvTimDosen.Rows.Clear();
                return;
            }

            await LoadTimDosen();
        }

        private async Task LoadTimDosen()
        {

            var kodeProgram = cmbProgram.SelectedValue.ToString();
            var tahunAkademik = LoginAccess.TahunAkademik;
            var semester = LoginAccess.KodeSemester;
            var arrNik = new string[dgvAddTim.Rows.Count];
            var dataSave = new
            {
                KodeJurusan = kodeProgram,
                TahunAkademik = tahunAkademik,
                Semester = semester
            };

            var jsonData = JsonConvert.SerializeObject(dataSave);
            response = await webApi.Post(URLGetTimDosen, jsonData, true);
            if (!response.IsSuccessStatusCode)
            {
                MessageBox.Show(webApi.ReturnMessage(response));
                Loading(false);
                return;
            }

            List<TimDosen> listTimDosen = JsonConvert.DeserializeObject<List<TimDosen>>(response.Content.ReadAsStringAsync().Result);

            dgvTimDosen.Rows.Clear();
            foreach (TimDosen td in listTimDosen)
            {
                dgvTimDosen.Rows.Add(td.NamaTim, td.Nik, td.NamaDosen, false);
            }
        }

        private async void btnHapus_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvTimDosen.Rows)
            {
                if (Convert.ToBoolean(row.Cells["Hapus"].Value) == true)
                {
                    var dataDel = new
                    {
                        TahunAkademik = LoginAccess.TahunAkademik,
                        Semester = LoginAccess.KodeSemester,
                        Nik = row.Cells["aNik"].Value.ToString(),
                        NamaTim = row.Cells["NamaTim"].Value.ToString(),
                        KodeJurusan = cmbProgram.SelectedValue.ToString()
                    };

                    var jsonData = JsonConvert.SerializeObject(dataDel);
                    response = await webApi.Post(URLDelTimDosen, jsonData, true);
                }
            }
            await LoadTimDosen();
        }
    }
}
