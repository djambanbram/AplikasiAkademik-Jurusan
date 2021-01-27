#region Copyright Syncfusion Inc. 2001 - 2016
// Copyright Syncfusion Inc. 2001 - 2016. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
namespace KonversiAlihJalur
{
    partial class FormMatrikulasiCalonPemutihan
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.gradientPanel2 = new Syncfusion.Windows.Forms.Tools.GradientPanel();
            this.autoLabel2 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.autoLabel1 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.cmbAngkatan = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            this.autoLabel15 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.cmbProgram = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnTutup = new Syncfusion.Windows.Forms.ButtonAdv();
            this.btnKonversiOtomatis = new Syncfusion.Windows.Forms.ButtonAdv();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.dgvPendaftar = new System.Windows.Forms.DataGridView();
            this.No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nodaf = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Npm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nama = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Approve = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.lihatNilaiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.autoLabel3 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.cmbProdi = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            this.autoLabel4 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.cmbFakultas = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            ((System.ComponentModel.ISupportInitialize)(this.gradientPanel2)).BeginInit();
            this.gradientPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbAngkatan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbProgram)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPendaftar)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbProdi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbFakultas)).BeginInit();
            this.SuspendLayout();
            // 
            // gradientPanel2
            // 
            this.gradientPanel2.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat;
            this.gradientPanel2.Controls.Add(this.autoLabel4);
            this.gradientPanel2.Controls.Add(this.cmbFakultas);
            this.gradientPanel2.Controls.Add(this.autoLabel3);
            this.gradientPanel2.Controls.Add(this.cmbProdi);
            this.gradientPanel2.Controls.Add(this.autoLabel2);
            this.gradientPanel2.Controls.Add(this.autoLabel1);
            this.gradientPanel2.Controls.Add(this.cmbAngkatan);
            this.gradientPanel2.Controls.Add(this.autoLabel15);
            this.gradientPanel2.Controls.Add(this.cmbProgram);
            this.gradientPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.gradientPanel2.Location = new System.Drawing.Point(0, 0);
            this.gradientPanel2.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.gradientPanel2.Name = "gradientPanel2";
            this.gradientPanel2.Size = new System.Drawing.Size(840, 168);
            this.gradientPanel2.TabIndex = 19;
            // 
            // autoLabel2
            // 
            this.autoLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.autoLabel2.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.autoLabel2.Location = new System.Drawing.Point(136, 147);
            this.autoLabel2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.autoLabel2.Name = "autoLabel2";
            this.autoLabel2.Size = new System.Drawing.Size(439, 16);
            this.autoLabel2.TabIndex = 11;
            this.autoLabel2.Text = "Klik kanan pada baris => \"Lihat Nilai\" untuk melihat detail nilai mahasiswa";
            // 
            // autoLabel1
            // 
            this.autoLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.autoLabel1.Location = new System.Drawing.Point(6, 113);
            this.autoLabel1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.autoLabel1.Name = "autoLabel1";
            this.autoLabel1.Size = new System.Drawing.Size(65, 16);
            this.autoLabel1.TabIndex = 10;
            this.autoLabel1.Text = "Angkatan";
            // 
            // cmbAngkatan
            // 
            this.cmbAngkatan.BeforeTouchSize = new System.Drawing.Size(114, 24);
            this.cmbAngkatan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAngkatan.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbAngkatan.Location = new System.Drawing.Point(136, 110);
            this.cmbAngkatan.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.cmbAngkatan.Name = "cmbAngkatan";
            this.cmbAngkatan.Size = new System.Drawing.Size(114, 24);
            this.cmbAngkatan.TabIndex = 9;
            this.cmbAngkatan.SelectedIndexChanged += new System.EventHandler(this.cmbAngkatan_SelectedIndexChanged);
            // 
            // autoLabel15
            // 
            this.autoLabel15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.autoLabel15.Location = new System.Drawing.Point(6, 81);
            this.autoLabel15.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.autoLabel15.Name = "autoLabel15";
            this.autoLabel15.Size = new System.Drawing.Size(60, 16);
            this.autoLabel15.TabIndex = 8;
            this.autoLabel15.Text = "Program";
            // 
            // cmbProgram
            // 
            this.cmbProgram.BeforeTouchSize = new System.Drawing.Size(282, 24);
            this.cmbProgram.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProgram.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbProgram.Location = new System.Drawing.Point(136, 78);
            this.cmbProgram.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.cmbProgram.Name = "cmbProgram";
            this.cmbProgram.Size = new System.Drawing.Size(282, 24);
            this.cmbProgram.TabIndex = 2;
            this.cmbProgram.SelectedIndexChanged += new System.EventHandler(this.cmbProgramAlihJalur_SelectedIndexChanged);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnTutup);
            this.flowLayoutPanel1.Controls.Add(this.btnKonversiOtomatis);
            this.flowLayoutPanel1.Controls.Add(this.progressBar1);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 437);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(2, 5, 2, 5);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(840, 38);
            this.flowLayoutPanel1.TabIndex = 20;
            // 
            // btnTutup
            // 
            this.btnTutup.BeforeTouchSize = new System.Drawing.Size(126, 28);
            this.btnTutup.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTutup.IsBackStageButton = false;
            this.btnTutup.Location = new System.Drawing.Point(712, 5);
            this.btnTutup.Margin = new System.Windows.Forms.Padding(2, 5, 2, 5);
            this.btnTutup.Name = "btnTutup";
            this.btnTutup.Size = new System.Drawing.Size(126, 28);
            this.btnTutup.TabIndex = 0;
            this.btnTutup.Text = "Tutup";
            this.btnTutup.Click += new System.EventHandler(this.btnTutup_Click);
            // 
            // btnKonversiOtomatis
            // 
            this.btnKonversiOtomatis.BeforeTouchSize = new System.Drawing.Size(166, 28);
            this.btnKonversiOtomatis.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKonversiOtomatis.IsBackStageButton = false;
            this.btnKonversiOtomatis.Location = new System.Drawing.Point(542, 5);
            this.btnKonversiOtomatis.Margin = new System.Windows.Forms.Padding(2, 5, 2, 5);
            this.btnKonversiOtomatis.Name = "btnKonversiOtomatis";
            this.btnKonversiOtomatis.Size = new System.Drawing.Size(166, 28);
            this.btnKonversiOtomatis.TabIndex = 3;
            this.btnKonversiOtomatis.Text = "Konversi Nilai Otomatis";
            this.btnKonversiOtomatis.Click += new System.EventHandler(this.btnKonversiOtomatis_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(284, 3);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(253, 30);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar1.TabIndex = 2;
            this.progressBar1.Visible = false;
            // 
            // dgvPendaftar
            // 
            this.dgvPendaftar.AllowUserToAddRows = false;
            this.dgvPendaftar.AllowUserToDeleteRows = false;
            this.dgvPendaftar.AllowUserToResizeRows = false;
            this.dgvPendaftar.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgvPendaftar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPendaftar.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.No,
            this.Nodaf,
            this.Npm,
            this.Nama,
            this.Approve});
            this.dgvPendaftar.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvPendaftar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPendaftar.Location = new System.Drawing.Point(0, 168);
            this.dgvPendaftar.Name = "dgvPendaftar";
            this.dgvPendaftar.ReadOnly = true;
            this.dgvPendaftar.RowHeadersVisible = false;
            this.dgvPendaftar.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPendaftar.Size = new System.Drawing.Size(840, 269);
            this.dgvPendaftar.TabIndex = 21;
            this.dgvPendaftar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dgvPendaftar_MouseDown);
            // 
            // No
            // 
            this.No.HeaderText = "No";
            this.No.Name = "No";
            this.No.ReadOnly = true;
            this.No.Width = 50;
            // 
            // Nodaf
            // 
            this.Nodaf.HeaderText = "Nodaf";
            this.Nodaf.Name = "Nodaf";
            this.Nodaf.ReadOnly = true;
            this.Nodaf.Width = 80;
            // 
            // Npm
            // 
            this.Npm.HeaderText = "NPM";
            this.Npm.Name = "Npm";
            this.Npm.ReadOnly = true;
            this.Npm.Width = 80;
            // 
            // Nama
            // 
            this.Nama.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Nama.HeaderText = "Nama";
            this.Nama.Name = "Nama";
            this.Nama.ReadOnly = true;
            // 
            // Approve
            // 
            this.Approve.HeaderText = "Approve";
            this.Approve.Name = "Approve";
            this.Approve.ReadOnly = true;
            this.Approve.Width = 70;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lihatNilaiToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(128, 26);
            // 
            // lihatNilaiToolStripMenuItem
            // 
            this.lihatNilaiToolStripMenuItem.Name = "lihatNilaiToolStripMenuItem";
            this.lihatNilaiToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.lihatNilaiToolStripMenuItem.Text = "Lihat Nilai";
            this.lihatNilaiToolStripMenuItem.Click += new System.EventHandler(this.lihatNilaiToolStripMenuItem_Click);
            // 
            // autoLabel3
            // 
            this.autoLabel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.autoLabel3.Location = new System.Drawing.Point(6, 49);
            this.autoLabel3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.autoLabel3.Name = "autoLabel3";
            this.autoLabel3.Size = new System.Drawing.Size(93, 16);
            this.autoLabel3.TabIndex = 13;
            this.autoLabel3.Text = "Program Studi";
            // 
            // cmbProdi
            // 
            this.cmbProdi.BeforeTouchSize = new System.Drawing.Size(282, 24);
            this.cmbProdi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProdi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbProdi.Location = new System.Drawing.Point(136, 46);
            this.cmbProdi.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.cmbProdi.Name = "cmbProdi";
            this.cmbProdi.Size = new System.Drawing.Size(282, 24);
            this.cmbProdi.TabIndex = 12;
            // 
            // autoLabel4
            // 
            this.autoLabel4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.autoLabel4.Location = new System.Drawing.Point(6, 17);
            this.autoLabel4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.autoLabel4.Name = "autoLabel4";
            this.autoLabel4.Size = new System.Drawing.Size(59, 16);
            this.autoLabel4.TabIndex = 15;
            this.autoLabel4.Text = "Fakultas";
            // 
            // cmbFakultas
            // 
            this.cmbFakultas.BeforeTouchSize = new System.Drawing.Size(282, 24);
            this.cmbFakultas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFakultas.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbFakultas.Location = new System.Drawing.Point(136, 14);
            this.cmbFakultas.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.cmbFakultas.Name = "cmbFakultas";
            this.cmbFakultas.Size = new System.Drawing.Size(282, 24);
            this.cmbFakultas.TabIndex = 14;
            // 
            // FormMatrikulasiCalonPemutihan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CaptionFont = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClientSize = new System.Drawing.Size(840, 475);
            this.Controls.Add(this.dgvPendaftar);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.gradientPanel2);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FormMatrikulasiCalonPemutihan";
            this.Text = "Data Mahasiswa Alih Jalur AMIKOM";
            this.Load += new System.EventHandler(this.FormMatrikulasiCalonAlihJalur_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gradientPanel2)).EndInit();
            this.gradientPanel2.ResumeLayout(false);
            this.gradientPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbAngkatan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbProgram)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPendaftar)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cmbProdi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbFakultas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Syncfusion.Windows.Forms.Tools.GradientPanel gradientPanel2;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel1;
        private Syncfusion.Windows.Forms.Tools.ComboBoxAdv cmbAngkatan;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel15;
        private Syncfusion.Windows.Forms.Tools.ComboBoxAdv cmbProgram;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private Syncfusion.Windows.Forms.ButtonAdv btnTutup;
        private System.Windows.Forms.DataGridView dgvPendaftar;
        private System.Windows.Forms.ProgressBar progressBar1;
        private Syncfusion.Windows.Forms.ButtonAdv btnKonversiOtomatis;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem lihatNilaiToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn No;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nodaf;
        private System.Windows.Forms.DataGridViewTextBoxColumn Npm;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nama;
        private System.Windows.Forms.DataGridViewTextBoxColumn Approve;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel4;
        private Syncfusion.Windows.Forms.Tools.ComboBoxAdv cmbFakultas;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel3;
        private Syncfusion.Windows.Forms.Tools.ComboBoxAdv cmbProdi;
    }
}