#region Copyright Syncfusion Inc. 2001 - 2016
// Copyright Syncfusion Inc. 2001 - 2016. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using ClassModel;
using PenawaranKurikulum.Listener;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PenawaranKurikulum.Dialog
{
    public partial class DialogSetDosenKelas : Syncfusion.Windows.Forms.MetroForm
    {
        private IRefreshAlokasiDosen iRefreshAlokasi;

        public DialogSetDosenKelas(IRefreshAlokasiDosen iRefreshAlokasi, List<KelasAktif> listKelasAktif, List<KelasCampuranAktif> listKelasCampuranAktif, bool isModeCampuran, dynamic data)
        {
            InitializeComponent();

            txtKode.Text = data.Kode;
            txtNamaDosen.Text = data.NamaDosen;
            txtNik.Text = data.Nik;

            this.iRefreshAlokasi = iRefreshAlokasi;
            if (!isModeCampuran)
            {
                foreach (KelasAktif k in listKelasAktif)
                {
                    dgvKelas.Rows.Add(false, k.IdKelas, k.NamaKelas);
                }
            }
            else
            {
                foreach (KelasCampuranAktif k in listKelasCampuranAktif)
                {
                    dgvKelas.Rows.Add(false, k.IdKelas, k.NamaKelas);
                }
            }
        }

        private void btnTutup_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSetKelas_Click(object sender, EventArgs e)
        {
            List<int> listIdKelas = new List<int>();
            foreach (DataGridViewRow dRow in dgvKelas.Rows)
            {
                if (Convert.ToBoolean(dRow.Cells["Pilih"].Value))
                {
                    listIdKelas.Add(int.Parse(dRow.Cells["IdKelas"].Value.ToString()));
                }
            }

            iRefreshAlokasi.saveMultiKelas(listIdKelas);
            Close();
        }

        private void dgvKelas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewCheckBoxCell dgc = dgvKelas.Rows[e.RowIndex].Cells["Pilih"] as DataGridViewCheckBoxCell;
            dgc.Value = !Convert.ToBoolean(dgc.Value);
        }
    }
}
