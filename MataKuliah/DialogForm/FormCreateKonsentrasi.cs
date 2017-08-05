#region Copyright Syncfusion Inc. 2001 - 2016
// Copyright Syncfusion Inc. 2001 - 2016. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using MataKuliah.Listener;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MataKuliah.DialogForm
{
    public partial class FormCreateKonsentrasi : Syncfusion.Windows.Forms.MetroForm
    {
        private IMKKonsentrasi iMKKonsentrasi;

        public FormCreateKonsentrasi(IMKKonsentrasi iMKKonsentrasi)
        {
            InitializeComponent();
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(txtNamaKonsentrasi.Text) 
                || string.IsNullOrWhiteSpace(txtNamaEn.Text) 
                || string.IsNullOrWhiteSpace(txtSingkatan.Text))
            {
                MessageBox.Show("Field yang bertanda (*) harus diisi");
                return;
            }

            string namaKonsentrasi = txtNamaKonsentrasi.Text;
            string namaKonsentrasiEn = txtNamaEn.Text;
            string singkatan = txtSingkatan.Text;
            iMKKonsentrasi.saveKonsentrasi(namaKonsentrasi, namaKonsentrasiEn, singkatan);
            Close();
        }

        private void btnTutup_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
