#region Copyright Syncfusion Inc. 2001 - 2016
// Copyright Syncfusion Inc. 2001 - 2016. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using ApiService;
using Dosen.Listener;
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
using System.Windows.Forms;

namespace Dosen.Dialog
{
    public partial class FormTambahJenjangPendidikan : Syncfusion.Windows.Forms.MetroForm
    {
        public static string baseAddress = ConfigurationManager.AppSettings["baseAddress"];
        private string URLGetKaryawanAktif = baseAddress + "/karyawan_api/api/karyawan/get_karyawan_aktif";
        private string URLGetUniversitas = baseAddress + "/karyawan_api/api/jenjang_pendidikan/get_universitas";
        private string URLGetProdi = baseAddress + "/karyawan_api/api/jenjang_pendidikan/get_program_studi";
        private string URLGetJenjangPenididkan = baseAddress + "/karyawan_api/api/jenjang_pendidikan/get_jenjang_pendidikan_karyawan";
        private string URLSaveDetailJenjangPenididkan = baseAddress + "/karyawan_api/api/jenjang_pendidikan/save_detail_jenjang_pendidikan_karyawan";

        private WebApi webApi;
        private HttpResponseMessage response;
        private List<dynamic> listDetailJPDosen;
        public string NikDosen;
        private IjenjangPendidikan iJenjangPendidikan;
        private bool isChange;

        public FormTambahJenjangPendidikan(IjenjangPendidikan iJenjangPendidikan)
        {
            InitializeComponent();
            webApi = new WebApi();
            this.iJenjangPendidikan = iJenjangPendidikan;
        }

        private void Loading(bool isLoading)
        {
            tableLayoutPanel1.Enabled = !isLoading;
            flowLayoutPanel1.Enabled = !isLoading;
            gradientPanel1.Enabled = !isLoading;

        }

        private void btnTutup_Click(object sender, EventArgs e)
        {
            if (isChange)
            {
                iJenjangPendidikan.RefreshDetailJenjangPendidikan();
            }
            Close();
        }

        private async void FormTambahJenjangPendidikan_Load(object sender, EventArgs e)
        {
            Loading(true);

            response = await webApi.Post(URLGetUniversitas, string.Empty, true);
            if (!response.IsSuccessStatusCode)
            {
                MessageBox.Show(webApi.ReturnMessage(response));
                Loading(false);
                return;
            }
            List<dynamic> listUniv = JsonConvert.DeserializeObject<List<dynamic>>(response.Content.ReadAsStringAsync().Result);
            cmbUniv.DataSource = listUniv;
            cmbUniv.DisplayMember = "NamaUniversitas";
            cmbUniv.ValueMember = "IdUniversitas";

            response = await webApi.Post(URLGetProdi, string.Empty, true);
            if (!response.IsSuccessStatusCode)
            {
                MessageBox.Show(webApi.ReturnMessage(response));
                Loading(false);
                return;
            }
            List<dynamic> listProdi = JsonConvert.DeserializeObject<List<dynamic>>(response.Content.ReadAsStringAsync().Result);
            cmbProdi.DataSource = listProdi;
            cmbProdi.DisplayMember = "NamaProdi";
            cmbProdi.ValueMember = "IdProdi";

            response = await webApi.Post(URLGetJenjangPenididkan, string.Empty, true);
            if (!response.IsSuccessStatusCode)
            {
                MessageBox.Show(webApi.ReturnMessage(response));
                Loading(false);
                return;
            }
            List<dynamic> listJenjangPendidikan = JsonConvert.DeserializeObject<List<dynamic>>(response.Content.ReadAsStringAsync().Result);
            cmbJenjang.DataSource = listJenjangPendidikan;
            cmbJenjang.DisplayMember = "NamaJenjang";
            cmbJenjang.ValueMember = "IdJenjang";


            response = await webApi.Post(URLGetKaryawanAktif, string.Empty, true);
            if (!response.IsSuccessStatusCode)
            {
                MessageBox.Show(webApi.ReturnMessage(response));
                Loading(false);
                return;
            }
            listDetailJPDosen = JsonConvert.DeserializeObject<List<dynamic>>(response.Content.ReadAsStringAsync().Result);
            dgvKaryawan.Rows.Clear();
            if (!string.IsNullOrWhiteSpace(NikDosen))
            {
                txtCari.Text = NikDosen;
                dgvKaryawan.Rows[0].Selected = true;
                txtNIK.Text = NikDosen;
                txtNama.Text = dgvKaryawan.Rows[0].Cells["Nama"].Value.ToString();
            }
            else
            {
                var listDistinctKaryawan = listDetailJPDosen.Where(d => d.IsAktif == true).Select(jp => new { jp.Nik, jp.NamaKaryawan }).ToList().Distinct();

                int no = 1;
                foreach (var item in listDistinctKaryawan)
                {
                    dgvKaryawan.Rows.Add(no, item.Nik, item.NamaKaryawan);
                    no++;
                }
                dgvKaryawan.ClearSelection();
            }

            Loading(false);
        }

        private void txtCari_TextChanged(object sender, EventArgs e)
        {
            List<dynamic> listTemp = listDetailJPDosen.Where(jp => (jp.NamaKaryawan.ToString() as string).ToLower().Contains(txtCari.Text.ToLower()) ||
            (jp.Nik.ToString() as string).ToLower().Contains(txtCari.Text.ToLower())).ToList();

            var listDetailJPDosenDistinct = listTemp.Select(jp => new { jp.Nik, jp.NamaKaryawan }).ToList().Distinct();
            dgvKaryawan.Rows.Clear();
            int no = 1;
            foreach (var item in listDetailJPDosenDistinct)
            {
                dgvKaryawan.Rows.Add(no, item.Nik, item.NamaKaryawan);
                no++;
            }
            if (dgvKaryawan.Rows.Count == 0)
            {
                return;
            }
            dgvKaryawan.Rows[0].Selected = true;
            txtNIK.Text = dgvKaryawan.Rows[0].Cells["Nik"].Value.ToString();
            txtNama.Text = dgvKaryawan.Rows[0].Cells["Nama"].Value.ToString();
        }

        private async void btnSimpan_Click(object sender, EventArgs e)
        {
            if (cmbUniv.SelectedValue == null || cmbProdi.SelectedValue == null)
            {
                MessageBox.Show(this, "Kesalahan pada universitas atau program studi");
                return;
            }

            int idUniversitas = int.Parse(cmbUniv.SelectedValue.ToString());
            int idProdi = int.Parse(cmbProdi.SelectedValue.ToString());
            int idJenjang = int.Parse(cmbJenjang.SelectedValue.ToString());

            var dataSave = new
            {
                Nik = txtNIK.Text,
                idJenjangPendidikan = idJenjang,
                IdUniversitas = idUniversitas,
                IdProdi = idProdi,
                DateStart = dateMulai.Value.ToString("yyyy-MM-dd"),
                DateEnd = dateLulus.Value.ToString("yyyy-MM-dd"),
                NoIjazah = txtNoIjazah.Text
            };

            var jsonData = JsonConvert.SerializeObject(dataSave);
            response = await webApi.Post(URLSaveDetailJenjangPenididkan, jsonData, true);
            if (!response.IsSuccessStatusCode)
            {
                MessageBox.Show(webApi.ReturnMessage(response));
                return;
            }
            MessageBox.Show("Jenjang pendidikan berhasil disimpan");
            dgvKaryawan.ClearSelection();
            txtNIK.Text = string.Empty;
            txtNama.Text = string.Empty;
            cmbUniv.SelectedIndex = 0;
            cmbProdi.SelectedIndex = 0;
            cmbJenjang.SelectedIndex = 0;
            txtNoIjazah.Text = string.Empty;
            dateMulai.Value = DateTime.Now;
            dateLulus.Value = DateTime.Now;
            isChange = true;
        }

        private void dgvKaryawan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvKaryawan.Rows.Count == 0)
            {
                return;
            }
            if (e.RowIndex < 0)
            {
                return;
            }
            txtNIK.Text = dgvKaryawan.Rows[e.RowIndex].Cells["Nik"].Value.ToString();
            txtNama.Text = dgvKaryawan.Rows[e.RowIndex].Cells["Nama"].Value.ToString();
        }

        private void dgvKaryawan_KeyUp(object sender, KeyEventArgs e)
        {
            if (listDetailJPDosen == null)
            {
                return;
            }

            if (listDetailJPDosen.Count == 0)
            {
                return;
            }

            if (dgvKaryawan.Rows.Count == 0)
            {
                return;
            }
            int row = dgvKaryawan.SelectedRows[0].Index;

            txtNIK.Text = dgvKaryawan.Rows[row].Cells["Nik"].Value.ToString();
            txtNama.Text = dgvKaryawan.Rows[row].Cells["Nama"].Value.ToString();
        }

        private void FormTambahJenjangPendidikan_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (isChange)
            {
                iJenjangPendidikan.RefreshDetailJenjangPendidikan();
            }
        }
    }
}
