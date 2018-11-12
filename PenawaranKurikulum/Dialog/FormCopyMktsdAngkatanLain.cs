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

namespace PenawaranKurikulum.Dialog
{
    public partial class FormCopyMktsdAngkatanLain : Syncfusion.Windows.Forms.MetroForm
    {
        public static string baseAddress = ConfigurationManager.AppSettings["baseAddress"];
        private MataKuliahDitawarkan dataMataKuliah;
        private string URLSaveMKDitawarkan = baseAddress + "/jurusan_api/api/kurikulum/save_penawaran_mk";
        private WebApi webApi;
        private HttpResponseMessage response;
        private string kodeProgram;

        public FormCopyMktsdAngkatanLain(MataKuliahDitawarkan mk, string kodeProgram)
        {
            InitializeComponent();
            dataMataKuliah = mk;
            this.kodeProgram = kodeProgram;
            webApi = new WebApi();
        }

        private void FormCopyMktsdAngkatanLain_Load(object sender, EventArgs e)
        {
            txtKode.Text = dataMataKuliah.Kode;
            txtMataKuliah.Text = dataMataKuliah.MataKuliah;
            txtJenisMK.Text = dataMataKuliah.JenisMK;
            cbDaftarkelas.Checked = dataMataKuliah.DaftarKelasMK;
            for (int i = DateTime.Now.Year; i >= DateTime.Now.Year - 4; i--)
            {
                cmbAngkatan.Items.Add(i);
            }
            cmbAngkatan.SelectedIndex = 0;
        }

        private void btnTutup_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void btnSimpan_Click(object sender, EventArgs e)
        {
            var message = string.Format("Tawarkan {0}({1}) untuk angkatan {2}?", txtMataKuliah.Text, txtKode.Text, cmbAngkatan.Text);
            DialogResult dr = MessageBox.Show(message, "Penawaran MK", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.No)
            {
                return;
            }

            var dataSave = new
            {
                TahunAkademik = LoginAccess.TahunAkademik,
                Semester = LoginAccess.KodeSemester,
                KodeJurusan = kodeProgram,
                Kode = txtKode.Text,
                Angkatan = int.Parse(cmbAngkatan.Text),
                JenisMK = txtJenisMK.Text,
                DaftarKelasMK = cbDaftarkelas.Checked
            };

            string jsonData = JsonConvert.SerializeObject(dataSave);
            response = await webApi.Post(URLSaveMKDitawarkan, jsonData, true);

            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show(string.Format("Alokasi mata kuliah {0}({1}) berhasil di tawarkan untuk angkatan {2}", txtMataKuliah.Text, txtKode.Text, cmbAngkatan.Text));
                Close();
            }
            else
            {
                MessageBox.Show(webApi.ReturnMessage(response));
            }
        }
    }
}
