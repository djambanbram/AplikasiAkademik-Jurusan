#region Copyright Syncfusion Inc. 2001 - 2016
// Copyright Syncfusion Inc. 2001 - 2016. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using ApiService;
using ClassModel;
using KelasMahasiswa.Listener;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Windows.Forms;

namespace KelasMahasiswa.Dialog
{
    public partial class DialogCreateKelasCampuran : Syncfusion.Windows.Forms.MetroForm
    {
        public static string baseAddress = ConfigurationManager.AppSettings["baseAddress"];
        private string URLSaveKelasCampuran = baseAddress + "/jurusan_api/api/kelas/save_kelas_campuran";
        private string URLGetKodeKelas = baseAddress + "/jurusan_api/api/kelas/get_kode_kelas";

        private List<DataMataKuliahCampuran> listTemp1;
        private List<DataMataKuliahCampuran> listTemp2;

        private string KodeProgram;

        private WebApi webApi;
        private HttpResponseMessage response;

        private IKelas iKelas;

        public DialogCreateKelasCampuran(string kodeProgram, IKelas iKelas)
        {
            InitializeComponent();
            KodeProgram = kodeProgram;
            webApi = new WebApi();
            this.iKelas = iKelas;
        }

        private void Loading(bool isLoading)
        {
            splitContainerAdv1.Enabled = !isLoading;
            flowLayoutPanel1.Enabled = !isLoading;
            progressBar1.Visible = isLoading;
        }

        private async void btnCreate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNamaKelas.Text))
            {
                MessageBox.Show("Isi singkatan kelas campuran berdasarkan mata kuliah, pada menu\nMata Kuliah -> Data Mata Kuliah -> Singkatan Kelas");
                return;
            }

            if (string.IsNullOrEmpty(txtKode.Text))
            {
                MessageBox.Show("Mata kuliah belum dipilih, silahkan klik mata kuliah di tabel yang tersedia");
                return;
            }

            if (txtNamaKelas.Text.Length > 14)
            {
                MessageBox.Show("Panjang nama kelas maksismal 14 karakter");
                return;
            }

            Loading(true);
            var data = new
            {
                PrefiksNamaKelas = string.Format("{0}_{1}", txtKodeKelas.Text, txtNamaKelas.Text),
                Kode = txtKode.Text.Trim(),
                Kuota = int.Parse(numKuota.Value.ToString()),
                JumlahKelas = int.Parse(numJumlahKelas.Value.ToString()),
                TahunAkademik = LoginAccess.TahunAkademik,
                Semester = LoginAccess.KodeSemester,
                KodeJurusan = KodeProgram,
                SemesterKelas = int.Parse(lblSemesterKelas.Text)
            };

            string jsonData = JsonConvert.SerializeObject(data);
            response = await webApi.Post(URLSaveKelasCampuran, jsonData, true);
            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show(webApi.ReturnMessage(response));

                numKuota.Value = 65;
                numJumlahKelas.Value = 1;
                txtNamaKelas.Text = string.Empty;
                txtKode.Text = string.Empty;
                txtMataKuliah.Text = string.Empty;
                iKelas.loadKelas();
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

        private async void DialogCreateKelasCampuran_Load(object sender, EventArgs e)
        {
            if (ClassModel.MataKuliah.listDataMataKuliahCampuran.Count > 0)
            {
                dgvMKCampuran.Rows.Clear();
                numKuota.Value = 65;
                numJumlahKelas.Value = 1;
                txtNamaKelas.Text = string.Empty;
                txtKode.Text = string.Empty;
                txtMataKuliah.Text = string.Empty;

                listTemp1 = new List<DataMataKuliahCampuran>(ClassModel.MataKuliah.listDataMataKuliahCampuran)
                    //.Where(m => m.KodeSifatMK == "P" || m.KodeSifatMK == "K" ||
                    //            m.MataKuliah.Contains("NON MUSLIM")).OrderBy(mk => mk.Kode).ToList()
                    ;
                int no = 1;
                foreach (DataMataKuliahCampuran mk in listTemp1)
                {
                    dgvMKCampuran.Rows.Add(no, mk.Kode, mk.MataKuliah, mk.JumlahKelas, mk.SingkatanKelas, mk.SemesterDitawarkan);
                    no++;
                }

                response = await webApi.Post(URLGetKodeKelas, string.Empty, true);
                if (!response.IsSuccessStatusCode)
                {
                    MessageBox.Show(webApi.ReturnMessage(response));
                }
                var listKodeKelas = JsonConvert.DeserializeObject<List<KelasProgramProdi>>(response.Content.ReadAsStringAsync().Result);
                var kodeKelas = listKodeKelas.Find(k => k.KodeProgram == KodeProgram).KodeKelas;
                txtKodeKelas.Text = kodeKelas.Substring(kodeKelas.Length - 2, 2); ;
            }
        }

        private void dgvMKCampuran_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1 && e.ColumnIndex != -1)
            {
                txtKode.Text = dgvMKCampuran.Rows[e.RowIndex].Cells["Kode"].Value.ToString();
                txtMataKuliah.Text = dgvMKCampuran.Rows[e.RowIndex].Cells["MataKuliah"].Value.ToString();
                if (dgvMKCampuran.Rows[e.RowIndex].Cells["SemesterKelas"].Value != null)
                {
                    lblSemesterKelas.Text = dgvMKCampuran.Rows[e.RowIndex].Cells["SemesterKelas"].Value.ToString();
                }
                else
                {
                    lblSemesterKelas.Text = "0";
                }
                //lblSemesterKelas.Text = dgvMKCampuran.Rows[e.RowIndex].Cells["SemesterKelas"].Value.ToString();
                if (dgvMKCampuran.Rows[e.RowIndex].Cells["SingkatanKelas"].Value != null)
                {
                    txtNamaKelas.Text = dgvMKCampuran.Rows[e.RowIndex].Cells["SingkatanKelas"].Value.ToString();
                }
                else
                {
                    txtNamaKelas.Text = null;
                }
            }
        }

        private void txtCari_TextChanged(object sender, EventArgs e)
        {
            listTemp2 = listTemp1.Where(m => m.MataKuliah.ToLower().Trim().Contains(txtCari.Text.ToLower().Trim())).ToList();
            int i = 1;
            dgvMKCampuran.Rows.Clear();
            foreach (DataMataKuliahCampuran mk in listTemp2)
            {
                dgvMKCampuran.Rows.Add(i, mk.Kode, mk.MataKuliah, mk.JumlahKelas, mk.SingkatanKelas);
            }
        }

        private void dgvMKCampuran_KeyUp(object sender, KeyEventArgs e)
        {
            DataGridViewSelectedRowCollection dgRow = dgvMKCampuran.SelectedRows;

            txtKode.Text = dgRow[0].Cells["Kode"].Value.ToString();
            txtMataKuliah.Text = dgRow[0].Cells["MataKuliah"].Value.ToString();
            lblSemesterKelas.Text = dgRow[0].Cells["SemesterKelas"].Value.ToString();
            if (dgRow[0].Cells["SingkatanKelas"].Value != null)
            {
                txtNamaKelas.Text = dgRow[0].Cells["SingkatanKelas"].Value.ToString();
            }
            else
            {
                txtNamaKelas.Text = null;
            }
        }
    }
}
