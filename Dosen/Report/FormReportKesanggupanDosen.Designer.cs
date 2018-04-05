#region Copyright Syncfusion Inc. 2001 - 2016
// Copyright Syncfusion Inc. 2001 - 2016. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
namespace Dosen.Report
{
    partial class FormReportKesanggupanDosen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormReportKesanggupanDosen));
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.kesanggupanDosenMengajarBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsDosen = new Dosen.Data.DsDosen();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnTutup = new Syncfusion.Windows.Forms.ButtonAdv();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.gradientPanel1 = new Syncfusion.Windows.Forms.Tools.GradientPanel();
            this.dgvDataDosen = new System.Windows.Forms.DataGridView();
            this.No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NIK = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NamaDosen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pilih = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.KodeFakultas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NamaFakultas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Jenjang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KodeKelas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdKuliah = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.cetakSemuaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cetakDipilihToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripDropDownButton2 = new System.Windows.Forms.ToolStripDropDownButton();
            this.saveToWordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToPDFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gradientPanel2 = new Syncfusion.Windows.Forms.Tools.GradientPanel();
            this.cmbFakultas = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            this.autoLabel1 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            ((System.ComponentModel.ISupportInitialize)(this.kesanggupanDosenMengajarBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsDosen)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gradientPanel1)).BeginInit();
            this.gradientPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDataDosen)).BeginInit();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gradientPanel2)).BeginInit();
            this.gradientPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbFakultas)).BeginInit();
            this.SuspendLayout();
            // 
            // kesanggupanDosenMengajarBindingSource
            // 
            this.kesanggupanDosenMengajarBindingSource.DataMember = "KesanggupanDosenMengajar";
            this.kesanggupanDosenMengajarBindingSource.DataSource = this.dsDosen;
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
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 408);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(815, 38);
            this.flowLayoutPanel1.TabIndex = 11;
            // 
            // btnTutup
            // 
            this.btnTutup.BeforeTouchSize = new System.Drawing.Size(113, 30);
            this.btnTutup.IsBackStageButton = false;
            this.btnTutup.Location = new System.Drawing.Point(699, 4);
            this.btnTutup.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnTutup.Name = "btnTutup";
            this.btnTutup.Size = new System.Drawing.Size(113, 30);
            this.btnTutup.TabIndex = 0;
            this.btnTutup.Text = "Tutup";
            this.btnTutup.Click += new System.EventHandler(this.btnTutup_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(425, 3);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(268, 23);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar1.TabIndex = 1;
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
            this.gradientPanel1.Size = new System.Drawing.Size(371, 408);
            this.gradientPanel1.TabIndex = 12;
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
            this.Pilih,
            this.KodeFakultas,
            this.NamaFakultas,
            this.Jenjang,
            this.KodeKelas,
            this.IdKuliah});
            this.dgvDataDosen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDataDosen.Location = new System.Drawing.Point(0, 59);
            this.dgvDataDosen.MultiSelect = false;
            this.dgvDataDosen.Name = "dgvDataDosen";
            this.dgvDataDosen.RowHeadersVisible = false;
            this.dgvDataDosen.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDataDosen.Size = new System.Drawing.Size(367, 345);
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
            // Pilih
            // 
            this.Pilih.HeaderText = "Pilih";
            this.Pilih.Name = "Pilih";
            this.Pilih.Width = 50;
            // 
            // KodeFakultas
            // 
            this.KodeFakultas.HeaderText = "Kode Fakultas";
            this.KodeFakultas.Name = "KodeFakultas";
            this.KodeFakultas.Visible = false;
            // 
            // NamaFakultas
            // 
            this.NamaFakultas.HeaderText = "NamaFakultas";
            this.NamaFakultas.Name = "NamaFakultas";
            this.NamaFakultas.Visible = false;
            // 
            // Jenjang
            // 
            this.Jenjang.HeaderText = "Jenjang";
            this.Jenjang.Name = "Jenjang";
            this.Jenjang.Visible = false;
            // 
            // KodeKelas
            // 
            this.KodeKelas.HeaderText = "KodeKelas";
            this.KodeKelas.Name = "KodeKelas";
            this.KodeKelas.Visible = false;
            // 
            // IdKuliah
            // 
            this.IdKuliah.HeaderText = "IdKuliah";
            this.IdKuliah.Name = "IdKuliah";
            this.IdKuliah.Visible = false;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton1,
            this.toolStripDropDownButton2});
            this.toolStrip1.Location = new System.Drawing.Point(0, 34);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(367, 25);
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
            // toolStripDropDownButton2
            // 
            this.toolStripDropDownButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToWordToolStripMenuItem,
            this.saveToPDFToolStripMenuItem});
            this.toolStripDropDownButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton2.Image")));
            this.toolStripDropDownButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton2.Name = "toolStripDropDownButton2";
            this.toolStripDropDownButton2.Size = new System.Drawing.Size(44, 22);
            this.toolStripDropDownButton2.Text = "Save";
            // 
            // saveToWordToolStripMenuItem
            // 
            this.saveToWordToolStripMenuItem.Name = "saveToWordToolStripMenuItem";
            this.saveToWordToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.saveToWordToolStripMenuItem.Text = "Save to Word";
            this.saveToWordToolStripMenuItem.Visible = false;
            this.saveToWordToolStripMenuItem.Click += new System.EventHandler(this.saveToWordToolStripMenuItem_Click);
            // 
            // saveToPDFToolStripMenuItem
            // 
            this.saveToPDFToolStripMenuItem.Name = "saveToPDFToolStripMenuItem";
            this.saveToPDFToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.saveToPDFToolStripMenuItem.Text = "Save to PDF";
            this.saveToPDFToolStripMenuItem.Click += new System.EventHandler(this.saveToPDFToolStripMenuItem_Click);
            // 
            // gradientPanel2
            // 
            this.gradientPanel2.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat;
            this.gradientPanel2.Controls.Add(this.cmbFakultas);
            this.gradientPanel2.Controls.Add(this.autoLabel1);
            this.gradientPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.gradientPanel2.Location = new System.Drawing.Point(0, 0);
            this.gradientPanel2.Name = "gradientPanel2";
            this.gradientPanel2.Size = new System.Drawing.Size(367, 34);
            this.gradientPanel2.TabIndex = 16;
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
            reportDataSource1.Name = "DsKesanggupanMengajar";
            reportDataSource1.Value = this.kesanggupanDosenMengajarBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Dosen.ReportView.ReportKesanggupanDosen_v2.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(371, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(444, 408);
            this.reportViewer1.TabIndex = 13;
            // 
            // FormReportKesanggupanDosen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CaptionFont = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClientSize = new System.Drawing.Size(815, 446);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.gradientPanel1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FormReportKesanggupanDosen";
            this.Text = "Kesanggupan Dosen Mengajar";
            this.Load += new System.EventHandler(this.FormReportKesanggupanDosen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kesanggupanDosenMengajarBindingSource)).EndInit();
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
            ((System.ComponentModel.ISupportInitialize)(this.cmbFakultas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private Syncfusion.Windows.Forms.ButtonAdv btnTutup;
        private Syncfusion.Windows.Forms.Tools.GradientPanel gradientPanel1;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.DataGridView dgvDataDosen;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem cetakSemuaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cetakDipilihToolStripMenuItem;
        private System.Windows.Forms.BindingSource kesanggupanDosenMengajarBindingSource;
        private Data.DsDosen dsDosen;
        private Syncfusion.Windows.Forms.Tools.GradientPanel gradientPanel2;
        private Syncfusion.Windows.Forms.Tools.ComboBoxAdv cmbFakultas;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton2;
        private System.Windows.Forms.ToolStripMenuItem saveToWordToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToPDFToolStripMenuItem;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.DataGridViewTextBoxColumn No;
        private System.Windows.Forms.DataGridViewTextBoxColumn NIK;
        private System.Windows.Forms.DataGridViewTextBoxColumn NamaDosen;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Pilih;
        private System.Windows.Forms.DataGridViewTextBoxColumn KodeFakultas;
        private System.Windows.Forms.DataGridViewTextBoxColumn NamaFakultas;
        private System.Windows.Forms.DataGridViewTextBoxColumn Jenjang;
        private System.Windows.Forms.DataGridViewTextBoxColumn KodeKelas;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdKuliah;
    }
}