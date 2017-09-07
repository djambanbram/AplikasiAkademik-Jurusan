#region Copyright Syncfusion Inc. 2001 - 2016
// Copyright Syncfusion Inc. 2001 - 2016. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
namespace Dosen.Report
{
    partial class FormReportKesediaanDosen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormReportKesediaanDosen));
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.kesediaanDosenMengajarBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsDosen = new Data.DsDosen();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnTutup = new Syncfusion.Windows.Forms.ButtonAdv();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.gradientPanel1 = new Syncfusion.Windows.Forms.Tools.GradientPanel();
            this.dgvDataDosen = new System.Windows.Forms.DataGridView();
            this.No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NIK = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NamaDosen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MataKuliah = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pilih = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Jenjang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Kode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.JumlahKelas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.JenisKuliah = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.cetakSemuaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cetakDipilihToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gradientPanel2 = new Syncfusion.Windows.Forms.Tools.GradientPanel();
            this.cmbProgram = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            this.autoLabel3 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.cmbProdi = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            this.autoLabel2 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.cmbFakultas = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            this.autoLabel1 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.kesediaanDosenMengajarBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsDosen)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gradientPanel1)).BeginInit();
            this.gradientPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDataDosen)).BeginInit();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gradientPanel2)).BeginInit();
            this.gradientPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbProgram)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbProdi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbFakultas)).BeginInit();
            this.SuspendLayout();
            // 
            // kesediaanDosenMengajarBindingSource
            // 
            this.kesediaanDosenMengajarBindingSource.DataMember = "KesediaanDosenMengajar";
            this.kesediaanDosenMengajarBindingSource.DataSource = this.dsDosen;
            // 
            // dsDosen
            // 
            this.dsDosen.DataSetName = "DsDosen";
            this.dsDosen.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnTutup);
            this.flowLayoutPanel1.Controls.Add(this.progressBar1);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 343);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(859, 38);
            this.flowLayoutPanel1.TabIndex = 12;
            // 
            // btnTutup
            // 
            this.btnTutup.BeforeTouchSize = new System.Drawing.Size(113, 30);
            this.btnTutup.IsBackStageButton = false;
            this.btnTutup.Location = new System.Drawing.Point(743, 4);
            this.btnTutup.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnTutup.Name = "btnTutup";
            this.btnTutup.Size = new System.Drawing.Size(113, 30);
            this.btnTutup.TabIndex = 0;
            this.btnTutup.Text = "Tutup";
            this.btnTutup.Click += new System.EventHandler(this.btnTutup_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(469, 3);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(268, 23);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar1.TabIndex = 2;
            this.progressBar1.Visible = false;
            // 
            // gradientPanel1
            // 
            this.gradientPanel1.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat;
            this.gradientPanel1.Controls.Add(this.dgvDataDosen);
            this.gradientPanel1.Controls.Add(this.toolStrip1);
            this.gradientPanel1.Controls.Add(this.gradientPanel2);
            this.gradientPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.gradientPanel1.Location = new System.Drawing.Point(0, 0);
            this.gradientPanel1.Name = "gradientPanel1";
            this.gradientPanel1.Size = new System.Drawing.Size(506, 343);
            this.gradientPanel1.TabIndex = 13;
            // 
            // dgvDataDosen
            // 
            this.dgvDataDosen.AllowUserToAddRows = false;
            this.dgvDataDosen.AllowUserToDeleteRows = false;
            this.dgvDataDosen.AllowUserToResizeRows = false;
            this.dgvDataDosen.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgvDataDosen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDataDosen.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.No,
            this.NIK,
            this.NamaDosen,
            this.MataKuliah,
            this.Pilih,
            this.Jenjang,
            this.Kode,
            this.Sks,
            this.JumlahKelas,
            this.JenisKuliah});
            this.dgvDataDosen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDataDosen.Location = new System.Drawing.Point(0, 127);
            this.dgvDataDosen.MultiSelect = false;
            this.dgvDataDosen.Name = "dgvDataDosen";
            this.dgvDataDosen.RowHeadersVisible = false;
            this.dgvDataDosen.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDataDosen.Size = new System.Drawing.Size(502, 212);
            this.dgvDataDosen.TabIndex = 14;
            this.dgvDataDosen.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDataDosen_CellContentClick);
            // 
            // No
            // 
            this.No.HeaderText = "No";
            this.No.Name = "No";
            this.No.Width = 40;
            // 
            // NIK
            // 
            this.NIK.HeaderText = "NIK";
            this.NIK.Name = "NIK";
            this.NIK.Width = 85;
            // 
            // NamaDosen
            // 
            this.NamaDosen.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.NamaDosen.HeaderText = "Nama Dosen";
            this.NamaDosen.Name = "NamaDosen";
            // 
            // MataKuliah
            // 
            this.MataKuliah.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.MataKuliah.HeaderText = "MataKuliah";
            this.MataKuliah.Name = "MataKuliah";
            // 
            // Pilih
            // 
            this.Pilih.HeaderText = "Pilih";
            this.Pilih.Name = "Pilih";
            this.Pilih.Width = 50;
            // 
            // Jenjang
            // 
            this.Jenjang.HeaderText = "Jenjang";
            this.Jenjang.Name = "Jenjang";
            this.Jenjang.Visible = false;
            // 
            // Kode
            // 
            this.Kode.HeaderText = "Kode";
            this.Kode.Name = "Kode";
            this.Kode.Visible = false;
            // 
            // Sks
            // 
            this.Sks.HeaderText = "Sks";
            this.Sks.Name = "Sks";
            this.Sks.Visible = false;
            // 
            // JumlahKelas
            // 
            this.JumlahKelas.HeaderText = "Jumlah Kelas";
            this.JumlahKelas.Name = "JumlahKelas";
            this.JumlahKelas.Visible = false;
            this.JumlahKelas.Width = 50;
            // 
            // JenisKuliah
            // 
            this.JenisKuliah.HeaderText = "JenisKuliah";
            this.JenisKuliah.Name = "JenisKuliah";
            this.JenisKuliah.Visible = false;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 102);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(502, 25);
            this.toolStrip1.TabIndex = 15;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cetakSemuaToolStripMenuItem,
            this.cetakDipilihToolStripMenuItem});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(81, 22);
            this.toolStripDropDownButton1.Text = "Cetak Form";
            // 
            // cetakSemuaToolStripMenuItem
            // 
            this.cetakSemuaToolStripMenuItem.Name = "cetakSemuaToolStripMenuItem";
            this.cetakSemuaToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.cetakSemuaToolStripMenuItem.Text = "Cetak Semua";
            this.cetakSemuaToolStripMenuItem.Click += new System.EventHandler(this.cetakSemuaToolStripMenuItem_Click);
            // 
            // cetakDipilihToolStripMenuItem
            // 
            this.cetakDipilihToolStripMenuItem.Name = "cetakDipilihToolStripMenuItem";
            this.cetakDipilihToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.cetakDipilihToolStripMenuItem.Text = "Cetak Dipilih";
            this.cetakDipilihToolStripMenuItem.Click += new System.EventHandler(this.cetakDipilihToolStripMenuItem_Click);
            // 
            // gradientPanel2
            // 
            this.gradientPanel2.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat;
            this.gradientPanel2.Controls.Add(this.cmbProgram);
            this.gradientPanel2.Controls.Add(this.autoLabel3);
            this.gradientPanel2.Controls.Add(this.cmbProdi);
            this.gradientPanel2.Controls.Add(this.autoLabel2);
            this.gradientPanel2.Controls.Add(this.cmbFakultas);
            this.gradientPanel2.Controls.Add(this.autoLabel1);
            this.gradientPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.gradientPanel2.Location = new System.Drawing.Point(0, 0);
            this.gradientPanel2.Name = "gradientPanel2";
            this.gradientPanel2.Size = new System.Drawing.Size(502, 102);
            this.gradientPanel2.TabIndex = 16;
            // 
            // cmbProgram
            // 
            this.cmbProgram.BeforeTouchSize = new System.Drawing.Size(256, 25);
            this.cmbProgram.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProgram.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbProgram.Location = new System.Drawing.Point(86, 64);
            this.cmbProgram.Name = "cmbProgram";
            this.cmbProgram.Size = new System.Drawing.Size(256, 25);
            this.cmbProgram.TabIndex = 5;
            this.cmbProgram.SelectedIndexChanged += new System.EventHandler(this.cmbProgram_SelectedIndexChanged);
            // 
            // autoLabel3
            // 
            this.autoLabel3.Location = new System.Drawing.Point(8, 67);
            this.autoLabel3.Name = "autoLabel3";
            this.autoLabel3.Size = new System.Drawing.Size(59, 17);
            this.autoLabel3.TabIndex = 4;
            this.autoLabel3.Text = "Program";
            // 
            // cmbProdi
            // 
            this.cmbProdi.BeforeTouchSize = new System.Drawing.Size(256, 25);
            this.cmbProdi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProdi.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbProdi.Location = new System.Drawing.Point(86, 33);
            this.cmbProdi.Name = "cmbProdi";
            this.cmbProdi.Size = new System.Drawing.Size(256, 25);
            this.cmbProdi.TabIndex = 3;
            this.cmbProdi.SelectedIndexChanged += new System.EventHandler(this.cmbProdi_SelectedIndexChanged);
            // 
            // autoLabel2
            // 
            this.autoLabel2.Location = new System.Drawing.Point(8, 36);
            this.autoLabel2.Name = "autoLabel2";
            this.autoLabel2.Size = new System.Drawing.Size(39, 17);
            this.autoLabel2.TabIndex = 2;
            this.autoLabel2.Text = "Prodi";
            // 
            // cmbFakultas
            // 
            this.cmbFakultas.BeforeTouchSize = new System.Drawing.Size(256, 25);
            this.cmbFakultas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFakultas.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbFakultas.Location = new System.Drawing.Point(86, 2);
            this.cmbFakultas.Name = "cmbFakultas";
            this.cmbFakultas.Size = new System.Drawing.Size(256, 25);
            this.cmbFakultas.TabIndex = 1;
            this.cmbFakultas.SelectedIndexChanged += new System.EventHandler(this.cmbFakultas_SelectedIndexChanged);
            // 
            // autoLabel1
            // 
            this.autoLabel1.Location = new System.Drawing.Point(8, 5);
            this.autoLabel1.Name = "autoLabel1";
            this.autoLabel1.Size = new System.Drawing.Size(54, 17);
            this.autoLabel1.TabIndex = 0;
            this.autoLabel1.Text = "Fakultas";
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DsKesediaanDosen";
            reportDataSource1.Value = this.kesediaanDosenMengajarBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Dosen.ReportView.ReportKesediaanDosen.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(506, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(353, 343);
            this.reportViewer1.TabIndex = 14;
            // 
            // FormReportKesediaanDosen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CaptionFont = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClientSize = new System.Drawing.Size(859, 381);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.gradientPanel1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FormReportKesediaanDosen";
            this.Text = "Kesediaan Dosen Mengajar";
            this.Load += new System.EventHandler(this.FormReportKesediaanDosen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kesediaanDosenMengajarBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsDosen)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gradientPanel1)).EndInit();
            this.gradientPanel1.ResumeLayout(false);
            this.gradientPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDataDosen)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gradientPanel2)).EndInit();
            this.gradientPanel2.ResumeLayout(false);
            this.gradientPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbProgram)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbProdi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbFakultas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private Syncfusion.Windows.Forms.ButtonAdv btnTutup;
        private Syncfusion.Windows.Forms.Tools.GradientPanel gradientPanel1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem cetakSemuaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cetakDipilihToolStripMenuItem;
        private System.Windows.Forms.DataGridView dgvDataDosen;
        private Syncfusion.Windows.Forms.Tools.GradientPanel gradientPanel2;
        private Syncfusion.Windows.Forms.Tools.ComboBoxAdv cmbProgram;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel3;
        private Syncfusion.Windows.Forms.Tools.ComboBoxAdv cmbProdi;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel2;
        private Syncfusion.Windows.Forms.Tools.ComboBoxAdv cmbFakultas;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel1;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource kesediaanDosenMengajarBindingSource;
        private Data.DsDosen dsDosen;
        private System.Windows.Forms.DataGridViewTextBoxColumn No;
        private System.Windows.Forms.DataGridViewTextBoxColumn NIK;
        private System.Windows.Forms.DataGridViewTextBoxColumn NamaDosen;
        private System.Windows.Forms.DataGridViewTextBoxColumn MataKuliah;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Pilih;
        private System.Windows.Forms.DataGridViewTextBoxColumn Jenjang;
        private System.Windows.Forms.DataGridViewTextBoxColumn Kode;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sks;
        private System.Windows.Forms.DataGridViewTextBoxColumn JumlahKelas;
        private System.Windows.Forms.DataGridViewTextBoxColumn JenisKuliah;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}