#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using ApiService;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Net.Http;
using System.Text;
using System.Windows.Forms;

namespace PenawaranKurikulum.Dialog
{
    public partial class DialogAlokasiKelasCampuran : Syncfusion.Windows.Forms.MetroForm
    {
        public static string baseAddress = ConfigurationManager.AppSettings["baseAddress"];
        private string URLSaveKelasCampuran = baseAddress + "/jurusan_api/api/kelas/save_kelas_campuran";

        private string Kode;
        private string KodeProgram;
        private string MataKuliah;

        private WebApi webApi;
        private HttpResponseMessage response;

        public DialogAlokasiKelasCampuran(string kodeProgram, string kode, string mataKuliah)
        {
            InitializeComponent();
            webApi = new WebApi();
            this.Kode = kode;
            this.KodeProgram = kodeProgram;
            this.MataKuliah = mataKuliah;
        }

        private void btnTutup_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void DialogAlokasiKelasCampuran_Load(object sender, EventArgs e)
        {
            txtKode.Text = Kode;
            txtMataKuliah.Text = MataKuliah;
        }

        private async void btnSImpan_Click(object sender, EventArgs e)
        {
            if (txtNamaKelas.Text.Length > 14)
            {
                MessageBox.Show("Panjang nama kelas maksismal 14 karakter");
                return;
            }

            var data = new
            {
                PrefiksNamaKelas = string.Format("{0}", txtNamaKelas.Text),
                Kode = txtKode.Text.Trim(),
                Kuota = int.Parse(numKuota.Value.ToString()),
                JumlahKelas = int.Parse(numJumlahKelas.Value.ToString()),
                TahunAkademik = LoginAccess.TahunAkademik,
                Semester = LoginAccess.KodeSemester,
                KodeJurusan = KodeProgram,
                SemesterKelas = 0
            };

            string jsonData = JsonConvert.SerializeObject(data);
            response = await webApi.Post(URLSaveKelasCampuran, jsonData, true);
            if (!response.IsSuccessStatusCode)
            {
                MessageBox.Show(webApi.ReturnMessage(response));
                return;
            }

            MessageBox.Show("Kelas berhasil di tambahkan");
            Close();
        }
    }
}
