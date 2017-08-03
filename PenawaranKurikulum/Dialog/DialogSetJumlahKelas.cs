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
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PenawaranKurikulum.Dialog
{
    public partial class DialogSetJumlahKelas : Syncfusion.Windows.Forms.MetroForm
    {
        //public static string baseAddress = ConfigurationManager.AppSettings["baseAddress"];

        private string Ruang;
        private string Kode;
        private string MataKuliah;
        private int TotalKelas;
        private int KelasTeralokasi;
        private string NamaProgram;
        private IRefreshAlokasiRuang iRefreshAlokasiRuang;

        private bool isEdit;

        public DialogSetJumlahKelas(List<MemberKelas> listMemberKelas, string Ruang, string Kode, string MataKuliah, int TotalKelas, string NamaProgram, IRefreshAlokasiRuang iRefreshAlokasiRuang)
        {
            InitializeComponent();
            this.iRefreshAlokasiRuang = iRefreshAlokasiRuang;
            this.Ruang = Ruang;
            this.Kode = Kode;
            this.MataKuliah = MataKuliah;
            this.TotalKelas = TotalKelas;
            this.NamaProgram = NamaProgram;
            MemberKelas memberKelas = listMemberKelas.Find(m => m.Kode == Kode);
            if (memberKelas != null)
            {
                KelasTeralokasi = memberKelas.JumlahKelas;
            }
            else
            {
                KelasTeralokasi = 0;
            }

            txtRuang.Text = Ruang;
            txtProgram.Text = NamaProgram;
            txtKode.Text = Kode;
            txtMataKuliah.Text = MataKuliah;
            txtTotalKelas.Text = TotalKelas.ToString();
            txtKelasTeralokasi.Text = KelasTeralokasi.ToString();
            numSetJumlahKelas.Maximum = TotalKelas - KelasTeralokasi;

        }

        public DialogSetJumlahKelas(string Ruang, string Kode, string MataKuliah, int TotalKelas, int KelasTeralokasi, string NamaProgram, IRefreshAlokasiRuang iRefreshAlokasiRuang)
        {
            InitializeComponent();

            isEdit = true;
            this.iRefreshAlokasiRuang = iRefreshAlokasiRuang;
            this.Ruang = Ruang;
            this.Kode = Kode;
            this.MataKuliah = MataKuliah;
            this.TotalKelas = TotalKelas;
            this.NamaProgram = NamaProgram;

            txtRuang.Text = Ruang;
            txtKode.Text = Kode;
            txtMataKuliah.Text = MataKuliah;
            txtTotalKelas.Text = TotalKelas.ToString();
            txtKelasTeralokasi.Text = KelasTeralokasi.ToString();
            txtProgram.Text = NamaProgram;
            numSetJumlahKelas.Maximum = TotalKelas - KelasTeralokasi;
        }

        private void btnTutup_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            if (numSetJumlahKelas.Value == 0)
            {
                MessageBox.Show("Jumlah kelas tidak boleh 0");
                return;
            }
            if (!isEdit)
            {
                iRefreshAlokasiRuang.saveJumlahKelas(Ruang, int.Parse(numSetJumlahKelas.Value.ToString()), Kode);
            }
            else
            {
                iRefreshAlokasiRuang.updateJumlahKelas(Ruang, int.Parse(numSetJumlahKelas.Value.ToString()), Kode);
            }
            Close();
        }
    }
}
