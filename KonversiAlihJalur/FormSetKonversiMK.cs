#region Copyright Syncfusion Inc. 2001 - 2016
// Copyright Syncfusion Inc. 2001 - 2016. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using ApiService;
using ClassModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Windows.Forms;

namespace KonversiAlihJalur
{
    public partial class FormSetKonversiMK : Syncfusion.Windows.Forms.MetroForm
    {
        private List<Program> listProgram;

        private WebApi webApi;
        private HttpResponseMessage response;
        public FormSetKonversiMK()
        {
            InitializeComponent();
            webApi = new WebApi();
        }

        private void FormSetKonversiMK_Load(object sender, EventArgs e)
        {
            listProgram = Organisasi.listProgram.Where(program => program.KodeProgram == "21" || program.KodeProgram == "22").ToList();
            listProgram.Insert(0, new Program() { KodeProgram = "-", NamaProgram = "Pilih" });
            cmbProgramAlihJalur.DataSource = listProgram;
            cmbProgramAlihJalur.DisplayMember = "NamaProgram";
            cmbProgramAlihJalur.ValueMember = "KodeProgram";
            cmbProgramAlihJalur.SelectedIndex = 0;

            for (int i = DateTime.Now.Year; i > DateTime.Now.Year - 10; i--)
            {
                cmbAngkatan.Items.Add(i.ToString());
            }
            cmbAngkatan.Items.Insert(0, "Pilih");
            cmbAngkatan.SelectedIndex = 0;

        }

        private void btnTutup_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
