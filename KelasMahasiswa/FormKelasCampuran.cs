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
using ApiService;
using System.Configuration;
using System.Net.Http;
using Newtonsoft.Json;

namespace KelasMahasiswa
{
    public partial class FormKelasCampuran : Syncfusion.Windows.Forms.MetroForm
    {
        private List<Fakultas> listFakultas;
        private List<Prodi> listProdi;
        private List<Program> listProgram;

        private WebApi webApi;
        private string UrlGetFakultas = baseAddress + "/jurusan_api/api/organisasi/get_fakultas";
        private string UrlGetProdiByFakultas = baseAddress + "/jurusan_api/api/organisasi/get_prodi_by_fakultas";
        private string UrlGetProgramByProdi = baseAddress + "/jurusan_api/api/organisasi/get_program_by_prodi";

        public FromKelasReguler()
        {
            InitializeComponent();
        }
        private void Loading(bool isLoading)
        {
            gradientPanel1.Enabled = !isLoading;
            gradientPanel2.Enabled = !isLoading;
            flowLayoutPanel1.Enabled = !isLoading;

            progressBar1.Visible = isLoading;
        }

        private void btnTutup_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void FromKelasReguler_Load(object sender, EventArgs e)
        {
            HttpResponseMessage response = await webApi.Get(UrlGetFakultas);
            if (response.IsSuccessStatusCode)
            {
                List<dynamic> listFakultas = JsonConvert.DeserializeObject<List<dynamic>>(response.Content.ReadAsStringAsync().Result);
                foreach (var item in listFakultas)
                {
                    cmbFakultas.Items.Add(Convert.ToString(item.KodeFakultas));
                }
                //cmbFakultas.DisplayMember = "NamaFakultas";
                //cmbFakultas.ValueMember = "KodeFakultas";

                //listFakultas.Insert(0, new { NamaFakultas = "Pilih" });
                //var material = new BindingList<dynamic>(listFakultas);
                //cmbFakultas.DataSource = material;
                //cmbFakultas.DisplayMember = "NamaFakultas";
                //cmbFakultas.ValueMember = "KodeFakultas";


                //List<dynamic> listProdi = JsonConvert.DeserializeObject<List<dynamic>>(response.Content.ReadAsStringAsync().Result);
                //List<dynamic> listProgram = JsonConvert.DeserializeObject<List<dynamic>>(response.Content.ReadAsStringAsync().Result);
                //List<dynamic> listJenajng;
            }
            else
            {
                MessageBox.Show(response.ReasonPhrase);
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
