#region Copyright Syncfusion Inc. 2001 - 2016
// Copyright Syncfusion Inc. 2001 - 2016. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
namespace KonversiAlihJalur.Report
{
    partial class FormReportHasilMatrikulasiPemutihan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormReportHasilMatrikulasiPemutihan));
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.hasilMatrikulasiBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSetAlihJalur = new KonversiAlihJalur.Data.DataSetAlihJalur();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnTutup = new Syncfusion.Windows.Forms.ButtonAdv();
            this.gradientPanel2 = new Syncfusion.Windows.Forms.Tools.GradientPanel();
            this.autoLabel1 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.cmbAngkatan = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            this.autoLabel15 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.cmbProgramAlihJalur = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            this.gradientPanel1 = new Syncfusion.Windows.Forms.Tools.GradientPanel();
            this.dgvMhs = new System.Windows.Forms.DataGridView();
            this.No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nodaf = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Npm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nama = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pilih = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.SksTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.printSemuaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printDipilihToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.autoLabel4 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.cmbProdi = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            this.autoLabel3 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.cmbFakultas = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            ((System.ComponentModel.ISupportInitialize)(this.hasilMatrikulasiBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetAlihJalur)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gradientPanel2)).BeginInit();
            this.gradientPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbAngkatan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbProgramAlihJalur)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gradientPanel1)).BeginInit();
            this.gradientPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMhs)).BeginInit();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbProdi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbFakultas)).BeginInit();
            this.SuspendLayout();
            // 
            // hasilMatrikulasiBindingSource
            // 
            this.hasilMatrikulasiBindingSource.DataMember = "HasilMatrikulasi";
            this.hasilMatrikulasiBindingSource.DataSource = this.dataSetAlihJalur;
            // 
            // dataSetAlihJalur
            // 
            this.dataSetAlihJalur.DataSetName = "DataSetAlihJalur";
            this.dataSetAlihJalur.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnTutup);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 368);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(813, 38);
            this.flowLayoutPanel1.TabIndex = 17;
            // 
            // btnTutup
            // 
            this.btnTutup.BeforeTouchSize = new System.Drawing.Size(113, 30);
            this.btnTutup.IsBackStageButton = false;
            this.btnTutup.Location = new System.Drawing.Point(697, 4);
            this.btnTutup.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnTutup.Name = "btnTutup";
            this.btnTutup.Size = new System.Drawing.Size(113, 30);
            this.btnTutup.TabIndex = 0;
            this.btnTutup.Text = "Tutup";
            this.btnTutup.Click += new System.EventHandler(this.btnTutup_Click);
            // 
            // gradientPanel2
            // 
            this.gradientPanel2.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat;
            this.gradientPanel2.Controls.Add(this.autoLabel4);
            this.gradientPanel2.Controls.Add(this.cmbProdi);
            this.gradientPanel2.Controls.Add(this.autoLabel3);
            this.gradientPanel2.Controls.Add(this.cmbFakultas);
            this.gradientPanel2.Controls.Add(this.autoLabel1);
            this.gradientPanel2.Controls.Add(this.cmbAngkatan);
            this.gradientPanel2.Controls.Add(this.autoLabel15);
            this.gradientPanel2.Controls.Add(this.cmbProgramAlihJalur);
            this.gradientPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.gradientPanel2.Location = new System.Drawing.Point(0, 0);
            this.gradientPanel2.Name = "gradientPanel2";
            this.gradientPanel2.Size = new System.Drawing.Size(813, 143);
            this.gradientPanel2.TabIndex = 18;
            // 
            // autoLabel1
            // 
            this.autoLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.autoLabel1.Location = new System.Drawing.Point(10, 108);
            this.autoLabel1.Name = "autoLabel1";
            this.autoLabel1.Size = new System.Drawing.Size(65, 16);
            this.autoLabel1.TabIndex = 10;
            this.autoLabel1.Text = "Angkatan";
            // 
            // cmbAngkatan
            // 
            this.cmbAngkatan.BeforeTouchSize = new System.Drawing.Size(137, 24);
            this.cmbAngkatan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAngkatan.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbAngkatan.Location = new System.Drawing.Point(142, 104);
            this.cmbAngkatan.Name = "cmbAngkatan";
            this.cmbAngkatan.Size = new System.Drawing.Size(137, 24);
            this.cmbAngkatan.TabIndex = 9;
            this.cmbAngkatan.SelectedIndexChanged += new System.EventHandler(this.cmbAngkatan_SelectedIndexChanged);
            // 
            // autoLabel15
            // 
            this.autoLabel15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.autoLabel15.Location = new System.Drawing.Point(10, 78);
            this.autoLabel15.Name = "autoLabel15";
            this.autoLabel15.Size = new System.Drawing.Size(126, 16);
            this.autoLabel15.TabIndex = 8;
            this.autoLabel15.Text = "Program Pemutihan";
            // 
            // cmbProgramAlihJalur
            // 
            this.cmbProgramAlihJalur.BeforeTouchSize = new System.Drawing.Size(282, 24);
            this.cmbProgramAlihJalur.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProgramAlihJalur.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbProgramAlihJalur.Location = new System.Drawing.Point(142, 74);
            this.cmbProgramAlihJalur.Name = "cmbProgramAlihJalur";
            this.cmbProgramAlihJalur.Size = new System.Drawing.Size(282, 24);
            this.cmbProgramAlihJalur.TabIndex = 2;
            // 
            // gradientPanel1
            // 
            this.gradientPanel1.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat;
            this.gradientPanel1.Controls.Add(this.dgvMhs);
            this.gradientPanel1.Controls.Add(this.toolStrip1);
            this.gradientPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.gradientPanel1.Location = new System.Drawing.Point(0, 143);
            this.gradientPanel1.Name = "gradientPanel1";
            this.gradientPanel1.Size = new System.Drawing.Size(402, 225);
            this.gradientPanel1.TabIndex = 19;
            // 
            // dgvMhs
            // 
            this.dgvMhs.AllowUserToAddRows = false;
            this.dgvMhs.AllowUserToDeleteRows = false;
            this.dgvMhs.AllowUserToResizeRows = false;
            this.dgvMhs.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgvMhs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMhs.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.No,
            this.Nodaf,
            this.Npm,
            this.Nama,
            this.Pilih,
            this.SksTotal});
            this.dgvMhs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMhs.Location = new System.Drawing.Point(0, 25);
            this.dgvMhs.MultiSelect = false;
            this.dgvMhs.Name = "dgvMhs";
            this.dgvMhs.RowHeadersVisible = false;
            this.dgvMhs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMhs.Size = new System.Drawing.Size(398, 196);
            this.dgvMhs.TabIndex = 20;
            this.dgvMhs.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMhs_CellContentClick);
            this.dgvMhs.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvMhs_ColumnHeaderMouseClick);
            // 
            // No
            // 
            this.No.HeaderText = "No";
            this.No.Name = "No";
            this.No.Width = 40;
            // 
            // Nodaf
            // 
            this.Nodaf.HeaderText = "Nodaf";
            this.Nodaf.Name = "Nodaf";
            // 
            // Npm
            // 
            this.Npm.HeaderText = "NPM";
            this.Npm.Name = "Npm";
            this.Npm.Visible = false;
            this.Npm.Width = 90;
            // 
            // Nama
            // 
            this.Nama.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Nama.HeaderText = "Nama";
            this.Nama.Name = "Nama";
            // 
            // Pilih
            // 
            this.Pilih.HeaderText = "Pilih";
            this.Pilih.Name = "Pilih";
            this.Pilih.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Pilih.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Pilih.Width = 50;
            // 
            // SksTotal
            // 
            this.SksTotal.HeaderText = "SksTotal";
            this.SksTotal.Name = "SksTotal";
            this.SksTotal.Visible = false;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(398, 25);
            this.toolStrip1.TabIndex = 21;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.printSemuaToolStripMenuItem,
            this.printDipilihToolStripMenuItem});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(45, 22);
            this.toolStripDropDownButton1.Text = "Print";
            // 
            // printSemuaToolStripMenuItem
            // 
            this.printSemuaToolStripMenuItem.Name = "printSemuaToolStripMenuItem";
            this.printSemuaToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.printSemuaToolStripMenuItem.Text = "Print Semua";
            this.printSemuaToolStripMenuItem.Click += new System.EventHandler(this.printSemuaToolStripMenuItem_Click);
            // 
            // printDipilihToolStripMenuItem
            // 
            this.printDipilihToolStripMenuItem.Name = "printDipilihToolStripMenuItem";
            this.printDipilihToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.printDipilihToolStripMenuItem.Text = "Print Dipilih";
            this.printDipilihToolStripMenuItem.Click += new System.EventHandler(this.printDipilihToolStripMenuItem_Click);
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DsHasilMatrikulasi";
            reportDataSource1.Value = this.hasilMatrikulasiBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "KonversiAlihJalur.ReportView.ReportKonversiPerMhsPemutihan.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(402, 143);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(411, 225);
            this.reportViewer1.TabIndex = 20;
            // 
            // autoLabel4
            // 
            this.autoLabel4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.autoLabel4.Location = new System.Drawing.Point(10, 51);
            this.autoLabel4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.autoLabel4.Name = "autoLabel4";
            this.autoLabel4.Size = new System.Drawing.Size(93, 16);
            this.autoLabel4.TabIndex = 19;
            this.autoLabel4.Text = "Program Studi";
            // 
            // cmbProdi
            // 
            this.cmbProdi.BeforeTouchSize = new System.Drawing.Size(282, 24);
            this.cmbProdi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProdi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbProdi.Location = new System.Drawing.Point(142, 43);
            this.cmbProdi.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.cmbProdi.Name = "cmbProdi";
            this.cmbProdi.Size = new System.Drawing.Size(282, 24);
            this.cmbProdi.TabIndex = 18;
            this.cmbProdi.SelectedIndexChanged += new System.EventHandler(this.cmbProdi_SelectedIndexChanged);
            // 
            // autoLabel3
            // 
            this.autoLabel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.autoLabel3.Location = new System.Drawing.Point(10, 19);
            this.autoLabel3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.autoLabel3.Name = "autoLabel3";
            this.autoLabel3.Size = new System.Drawing.Size(59, 16);
            this.autoLabel3.TabIndex = 17;
            this.autoLabel3.Text = "Fakultas";
            // 
            // cmbFakultas
            // 
            this.cmbFakultas.BeforeTouchSize = new System.Drawing.Size(282, 24);
            this.cmbFakultas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFakultas.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbFakultas.Location = new System.Drawing.Point(142, 11);
            this.cmbFakultas.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.cmbFakultas.Name = "cmbFakultas";
            this.cmbFakultas.Size = new System.Drawing.Size(282, 24);
            this.cmbFakultas.TabIndex = 16;
            this.cmbFakultas.SelectedIndexChanged += new System.EventHandler(this.cmbFakultas_SelectedIndexChanged);
            // 
            // FormReportHasilMatrikulasiPemutihan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CaptionFont = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClientSize = new System.Drawing.Size(813, 406);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.gradientPanel1);
            this.Controls.Add(this.gradientPanel2);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FormReportHasilMatrikulasiPemutihan";
            this.Text = "Laporan Hasil Matrikulasi";
            this.Load += new System.EventHandler(this.FormReportHasilMatrikulasi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.hasilMatrikulasiBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetAlihJalur)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gradientPanel2)).EndInit();
            this.gradientPanel2.ResumeLayout(false);
            this.gradientPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbAngkatan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbProgramAlihJalur)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gradientPanel1)).EndInit();
            this.gradientPanel1.ResumeLayout(false);
            this.gradientPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMhs)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbProdi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbFakultas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private Syncfusion.Windows.Forms.ButtonAdv btnTutup;
        private Syncfusion.Windows.Forms.Tools.GradientPanel gradientPanel2;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel15;
        private Syncfusion.Windows.Forms.Tools.ComboBoxAdv cmbProgramAlihJalur;
        private Syncfusion.Windows.Forms.Tools.GradientPanel gradientPanel1;
        private System.Windows.Forms.DataGridView dgvMhs;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.BindingSource hasilMatrikulasiBindingSource;
        private Data.DataSetAlihJalur dataSetAlihJalur;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel1;
        private Syncfusion.Windows.Forms.Tools.ComboBoxAdv cmbAngkatan;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem printSemuaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem printDipilihToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn No;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nodaf;
        private System.Windows.Forms.DataGridViewTextBoxColumn Npm;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nama;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Pilih;
        private System.Windows.Forms.DataGridViewTextBoxColumn SksTotal;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel4;
        private Syncfusion.Windows.Forms.Tools.ComboBoxAdv cmbProdi;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel3;
        private Syncfusion.Windows.Forms.Tools.ComboBoxAdv cmbFakultas;
    }
}