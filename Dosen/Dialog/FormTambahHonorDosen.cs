#region Copyright Syncfusion Inc. 2001 - 2016
// Copyright Syncfusion Inc. 2001 - 2016. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using ApiService;
using ClassModel;
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
    public partial class FormTambahHonorDosen : Syncfusion.Windows.Forms.MetroForm
    {
        public static string baseAddress = ConfigurationManager.AppSettings["baseAddress"];
        private string URLGetJenjangPendidikanDosen = baseAddress + "/karyawan_api/api/dosen/get_jenjang_pendidikan_dosen";
        private string URLGetGolonganDosen = baseAddress + "/karyawan_api/api/dosen/get_golongan_dosen";

        private WebApi webApi;
        private HttpResponseMessage response;

        private IHonorDosen iHonorDosen;

        public FormTambahHonorDosen(IHonorDosen iHonorDosen)
        {
            InitializeComponent();
            webApi = new WebApi();

            this.iHonorDosen = iHonorDosen;
        }

        private void btnTutup_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void FormTambahHonorDosen_Load(object sender, EventArgs e)
        {
            response = await webApi.Post(URLGetJenjangPendidikanDosen, string.Empty, true);
            if (!response.IsSuccessStatusCode)
            {
                MessageBox.Show("Gagal menampilkan data jenjang pendidikan");
                return;
            }
            List<JenjangPendidikanDosen> listJenjang = JsonConvert.DeserializeObject<List<JenjangPendidikanDosen>>(response.Content.ReadAsStringAsync().Result);
            listJenjang.Insert(0, new JenjangPendidikanDosen() { IdJenjang = 0, Jenjang = "Pilih" });
            cmbJenjangPendidikan.DataSource = listJenjang;
            cmbJenjangPendidikan.DisplayMember = "Jenjang";
            cmbJenjangPendidikan.ValueMember = "IdJenjang";
            cmbJenjangPendidikan.SelectedIndex = 0;

            response = await webApi.Post(URLGetGolonganDosen, string.Empty, true);
            if (!response.IsSuccessStatusCode)
            {
                MessageBox.Show("Gagal menampilkan data golongan");
                return;
            }
            List<GolonganDosen> listGolongan = JsonConvert.DeserializeObject<List<GolonganDosen>>(response.Content.ReadAsStringAsync().Result);
            listGolongan.Insert(0, new GolonganDosen() { IdGolongan = 0, NamaGolongan = "Pilih" });
            cmbGolongan.DataSource = listGolongan;
            cmbGolongan.DisplayMember = "NamaGolongan";
            cmbGolongan.ValueMember = "IdGolongan";
            cmbGolongan.SelectedIndex = 0;

        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {

            HonorJenjangDosen honor = new HonorJenjangDosen();
            honor.IdGolongan = int.Parse(cmbGolongan.SelectedValue.ToString());
            honor.IdJenjangPendidikan = int.Parse(cmbJenjangPendidikan.SelectedValue.ToString());
            honor.HonorFix = decimal.Parse(txtHonorFix.Text);
            honor.HonorVariable = decimal.Parse(txtHonorVar.Text);
            honor.Pajak = decimal.Parse(txtPajak.Text);

            iHonorDosen.SaveHonorDosen(honor);
            Close();
        }

        private void txtHonor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == '.'))
            {
                e.Handled = true;
            }
            TextBox txtDecimal = sender as TextBox;
            if (e.KeyChar == '.' && txtDecimal.Text.Contains("."))
            {
                e.Handled = true;
            }
        }
    }
}
