#region Copyright Syncfusion Inc. 2001 - 2016
// Copyright Syncfusion Inc. 2001 - 2016. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using ClassModel;
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
    public partial class FormMKPengganti : Syncfusion.Windows.Forms.MetroForm
    {
        private IMataKuliah iMataKuliah;

        public FormMKPengganti(IMataKuliah iMataKuliah) 
        {
            InitializeComponent();
            this.iMataKuliah = iMataKuliah;
        }

        private void btnTutup_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnPilih_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection row = dgvMataKuliah.SelectedRows;
            iMataKuliah.loadMK (row[0].Cells["Kode"].Value.ToString(), row[0].Cells["MataKuliah"].Value.ToString());
            Close();
        }

        private void FormMKPengganti_Load(object sender, EventArgs e)
        {
            int nomor = 1;
            dgvMataKuliah.Rows.Clear();
            foreach (DataMataKuliah dataMK in ClassModel.MataKuliah.listDataMataKuliah)
            {
                dgvMataKuliah.Rows.Add(nomor, dataMK.Kode, dataMK.MataKuliah, dataMK.Sks, dataMK.SksPraktikum, dataMK.SemesterDitawarkan, dataMK.SifatMK, dataMK.TahunMulai);
                nomor++;
            }
        }

        private void dgvMataKuliah_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewSelectedRowCollection row = dgvMataKuliah.SelectedRows;
            iMataKuliah.loadMK(row[0].Cells["Kode"].Value.ToString(), row[0].Cells["MataKuliah"].Value.ToString());
            Close();
        }
    }
}
