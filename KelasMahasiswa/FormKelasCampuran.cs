#region Copyright Syncfusion Inc. 2001 - 2016
// Copyright Syncfusion Inc. 2001 - 2016. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using ApiService;
using KelasMahasiswa.Lib;
using KelasMahasiswa.Models;
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

namespace KelasMahasiswa
{
    public partial class FormKelasCampuran : Syncfusion.Windows.Forms.MetroForm
    {
        public static string baseAddress = ConfigurationManager.AppSettings["baseAddress"];

        private WebApi webApi;
        private string UrlGetFakultas = baseAddress + "/jurusan_api/api/organisasi/get_fakultas";
        private string UrlGetProdiByFakultas = baseAddress + "/jurusan_api/api/organisasi/get_prodi_by_fakultas";
        private string UrlGetProgramByProdi = baseAddress + "/jurusan_api/api/organisasi/get_program_by_prodi";

        public FormKelasCampuran()
        {
            InitializeComponent();
            webApi = new WebApi();
        }

        private void btnTutup_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void cmbFakultas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbFakultas.SelectedIndex <= 0)
            {
                return;
            }
            CommonFunction.FormLoading(this, progressBar1, true);

            var kodeFakultas = cmbFakultas.SelectedValue.ToString();
            HttpResponseMessage responseProdi = await webApi.Post(UrlGetProdiByFakultas, JsonConvert.SerializeObject(kodeFakultas));

            if (!responseProdi.IsSuccessStatusCode)
            {
                MessageBox.Show(responseProdi.ReasonPhrase);
            }

            List<ProgramStudi> listProdi = JsonConvert.DeserializeObject<List<ProgramStudi>>(responseProdi.Content.ReadAsStringAsync().Result);
            listProdi.ForEach(delegate (ProgramStudi ps)
            {
                ps.NamaProdi = string.Format("{0}-{1}", ps.Jenjang, ps.NamaProdi.Split(';')[0]);
            });
            listProdi = listProdi.OrderBy(ps => ps.Jenjang).ToList();
            listProdi.Insert(0, new ProgramStudi() { Id = Guid.Empty, IdProdi = "0", NamaProdi = "Pilih", Jenjang = "0" });
            cmbProgramStudi.DataSource = listProdi;
            cmbProgramStudi.DisplayMember = "NamaProdi";
            cmbProgramStudi.ValueMember = "Id";
            cmbProgramStudi.SelectedIndex = 0;

            CommonFunction.FormLoading(this, progressBar1, false);
        }

        private async void cmbProgramStudi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbProgramStudi.SelectedIndex <= 0)
            {
                return;
            }
            CommonFunction.FormLoading(this, progressBar1, true);

            var idProdi = Guid.Parse(cmbProgramStudi.SelectedValue.ToString());
            HttpResponseMessage responseProgram = await webApi.Post(UrlGetProgramByProdi, JsonConvert.SerializeObject(idProdi));
            if (!responseProgram.IsSuccessStatusCode)
            {
                MessageBox.Show(responseProgram.ReasonPhrase);
            }

            List<ProgramProdi> listProgram = JsonConvert.DeserializeObject<List<ProgramProdi>>(responseProgram.Content.ReadAsStringAsync().Result);
            listProgram.Insert(0, new ProgramProdi() { IdProdi = Guid.Empty, KodeProgram = "0", NamaProdi = "0", NamaProgram = "Pilih" });
            cmbProgram.DataSource = listProgram;
            cmbProgram.DisplayMember = "NamaProgram";
            cmbProgram.ValueMember = "KodeProgram";
            cmbProgram.SelectedIndex = 0;

            CommonFunction.FormLoading(this, progressBar1, false);
        }

        private async void FormKelasCampuran_Load(object sender, EventArgs e)
        {
            CommonFunction.FormLoading(this, progressBar1, true);

            HttpResponseMessage responseFakultas = await webApi.Get(UrlGetFakultas);

            if (!responseFakultas.IsSuccessStatusCode)
            {
                MessageBox.Show(responseFakultas.ReasonPhrase);
            }

            List<Fakultas> listFakultas = JsonConvert.DeserializeObject<List<Fakultas>>(responseFakultas.Content.ReadAsStringAsync().Result);
            listFakultas.Insert(0, new Fakultas() { NamaFakultas = "Pilih", KodeFakultas = "0" });
            cmbFakultas.DataSource = listFakultas;
            cmbFakultas.DisplayMember = "NamaFakultas";
            cmbFakultas.ValueMember = "KodeFakultas";
            cmbFakultas.SelectedIndex = 0;

            CommonFunction.FormLoading(this, progressBar1, false);
        }
    }
}
