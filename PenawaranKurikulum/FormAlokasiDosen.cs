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

namespace PenawaranKurikulum
{
    public partial class FormAlokasiDosen : Syncfusion.Windows.Forms.MetroForm
    {
        private WebApi webApi;
        private HttpResponseMessage response;

        private List<Fakultas> listFakultas;
        private List<Prodi> listProdi;
        private List<Program> listProgram;

        private int[] ganjil = { 1, 3, 5, 7 };
        private int[] genap = { 2, 4, 6, 8 };

        public FormAlokasiDosen()
        {
            InitializeComponent();
            webApi = new WebApi();
        }

        private void btnTutup_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FormAlokasiDosen_Load(object sender, EventArgs e)
        {
            listFakultas = new List<Fakultas>(Organisasi.listFakultas);
            listFakultas.Insert(0, new Fakultas() { KodeFakultas = "-", NamaFakultas = "Pilih" });
            cmbFakultas.DataSource = listFakultas;
            cmbFakultas.DisplayMember = "NamaFakultas";
            cmbFakultas.ValueMember = "KodeFakultas";
            cmbFakultas.SelectedIndex = 0;

            if (LoginAccess.KodeSemester % 2 == 1)
            {
                rad1.Text = "1";
                rad2.Text = "3";
                rad3.Text = "5";
                rad4.Text = "7";
            }
            else
            {
                rad1.Text = "2";
                rad2.Text = "4";
                rad3.Text = "6";
                rad4.Text = "8";
            }
        }

        private void cmbFakultas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbFakultas.SelectedIndex > 0)
            {
                string kodeFakultas = cmbFakultas.SelectedValue.ToString();
                listProdi = Organisasi.listProdi.Where(pr => pr.Fakultas.KodeFakultas == kodeFakultas).ToList();
                listProdi.Insert(0, new Prodi() { IdProdi = "-", NamaProdi = "Pilih" });
                cmbProdi.DataSource = listProdi;
                cmbProdi.DisplayMember = "NamaProdi";
                cmbProdi.ValueMember = "Uid";
                cmbProdi.SelectedIndex = 0;
            }
        }

        private void cmbProdi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbFakultas.SelectedIndex > 0 && cmbProdi.SelectedIndex > 0)
            {
                string idProdi = cmbProdi.SelectedValue.ToString();
                listProgram = Organisasi.listProgram.Where(program => program.Prodi.Uid == idProdi).ToList();
                listProgram.Insert(0, new Program() { KodeProgram = "-", NamaProgram = "Pilih" });
                cmbProgram.DataSource = listProgram;
                cmbProgram.DisplayMember = "NamaProgram";
                cmbProgram.ValueMember = "KodeProgram";
                cmbProgram.SelectedIndex = 0;
            }
        }

        private void cmbProgram_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbProgram.SelectedIndex > 0)
            {
                int sem = 0;
                if (rad1.Checked)
                {
                    sem = int.Parse(rad1.Text);
                }
                else if (rad2.Checked)
                {
                    sem = int.Parse(rad2.Text);
                }
                else if (rad3.Checked)
                {
                    sem = int.Parse(rad3.Text);
                }
                else if (rad4.Checked)
                {
                    sem = int.Parse(rad4.Text);
                }
                LoadAlokasiDosen(sem, cmbProgram.SelectedValue.ToString());
            }
        }

        private void radioChecked(object sender, EventArgs e)
        {
            if (cmbProgram.SelectedIndex > 0)
            {
                LoadAlokasiDosen(int.Parse(((RadioButton)sender).Text), cmbProgram.SelectedValue.ToString());
            }
        }

        private void LoadAlokasiDosen(int semester, string kodeProgram)
        {
            MessageBox.Show(semester.ToString() + " " + kodeProgram);
        }
    }
}
