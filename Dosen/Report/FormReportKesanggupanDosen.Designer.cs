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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource3 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnTutup = new Syncfusion.Windows.Forms.ButtonAdv();
            this.gradientPanel1 = new Syncfusion.Windows.Forms.Tools.GradientPanel();
            this.dgvDataDosen = new System.Windows.Forms.DataGridView();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.cetakSemuaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cetakDipilihToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.dsDosen = new Dosen.Data.DsDosen();
            this.kesanggupanDosenMengajarBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NIK = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NamaDosen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pilih = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.KodeFakultas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NamaFakultas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Jenjang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KodeKelas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gradientPanel1)).BeginInit();
            this.gradientPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDataDosen)).BeginInit();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dsDosen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kesanggupanDosenMengajarBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnTutup);
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
            // 
            // gradientPanel1
            // 
            this.gradientPanel1.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat;
            this.gradientPanel1.Controls.Add(this.dgvDataDosen);
            this.gradientPanel1.Controls.Add(this.toolStrip1);
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
            this.KodeKelas});
            this.dgvDataDosen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDataDosen.Location = new System.Drawing.Point(0, 25);
            this.dgvDataDosen.MultiSelect = false;
            this.dgvDataDosen.Name = "dgvDataDosen";
            this.dgvDataDosen.RowHeadersVisible = false;
            this.dgvDataDosen.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDataDosen.Size = new System.Drawing.Size(367, 379);
            this.dgvDataDosen.TabIndex = 14;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
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
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource3.Name = "DsKesanggupanMengajar";
            reportDataSource3.Value = this.kesanggupanDosenMengajarBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource3);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Dosen.ReportView.ReportKesanggupanDosen.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(371, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(444, 408);
            this.reportViewer1.TabIndex = 13;
            // 
            // dsDosen
            // 
            this.dsDosen.DataSetName = "DsDosen";
            this.dsDosen.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // kesanggupanDosenMengajarBindingSource
            // 
            this.kesanggupanDosenMengajarBindingSource.DataMember = "KesanggupanDosenMengajar";
            this.kesanggupanDosenMengajarBindingSource.DataSource = this.dsDosen;
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
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gradientPanel1)).EndInit();
            this.gradientPanel1.ResumeLayout(false);
            this.gradientPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDataDosen)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dsDosen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kesanggupanDosenMengajarBindingSource)).EndInit();
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
        private System.Windows.Forms.DataGridViewTextBoxColumn No;
        private System.Windows.Forms.DataGridViewTextBoxColumn NIK;
        private System.Windows.Forms.DataGridViewTextBoxColumn NamaDosen;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Pilih;
        private System.Windows.Forms.DataGridViewTextBoxColumn KodeFakultas;
        private System.Windows.Forms.DataGridViewTextBoxColumn NamaFakultas;
        private System.Windows.Forms.DataGridViewTextBoxColumn Jenjang;
        private System.Windows.Forms.DataGridViewTextBoxColumn KodeKelas;
    }
}