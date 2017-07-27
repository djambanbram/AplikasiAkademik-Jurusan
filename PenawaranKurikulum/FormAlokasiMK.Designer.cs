#region Copyright Syncfusion Inc. 2001 - 2016
// Copyright Syncfusion Inc. 2001 - 2016. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
namespace PenawaranKurikulum
{
    partial class FormAlokasiMK
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gradientPanel2 = new Syncfusion.Windows.Forms.Tools.GradientPanel();
            this.autoLabel2 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.cmbProgram = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            this.autoLabel15 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.cmbProdi = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            this.cmbFakultas = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            this.autoLabel1 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnTutup = new Syncfusion.Windows.Forms.ButtonAdv();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.splitContainerAdv1 = new Syncfusion.Windows.Forms.Tools.SplitContainerAdv();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvMK = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvMktsd = new System.Windows.Forms.DataGridView();
            this.Pilih = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Semester = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Angkatan = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Kode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MataKuliah = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SifatMK = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SksTeori = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SksPrak = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.T = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.P = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.TP = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.DaftarKelasMK = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AngkatanBerlaku = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pJenis = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gradientPanel2)).BeginInit();
            this.gradientPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbProgram)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbProdi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbFakultas)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerAdv1)).BeginInit();
            this.splitContainerAdv1.Panel1.SuspendLayout();
            this.splitContainerAdv1.Panel2.SuspendLayout();
            this.splitContainerAdv1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMK)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMktsd)).BeginInit();
            this.SuspendLayout();
            // 
            // gradientPanel2
            // 
            this.gradientPanel2.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat;
            this.gradientPanel2.Controls.Add(this.autoLabel2);
            this.gradientPanel2.Controls.Add(this.cmbProgram);
            this.gradientPanel2.Controls.Add(this.autoLabel15);
            this.gradientPanel2.Controls.Add(this.cmbProdi);
            this.gradientPanel2.Controls.Add(this.cmbFakultas);
            this.gradientPanel2.Controls.Add(this.autoLabel1);
            this.gradientPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.gradientPanel2.Location = new System.Drawing.Point(0, 0);
            this.gradientPanel2.Name = "gradientPanel2";
            this.gradientPanel2.Size = new System.Drawing.Size(857, 103);
            this.gradientPanel2.TabIndex = 9;
            // 
            // autoLabel2
            // 
            this.autoLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.autoLabel2.Location = new System.Drawing.Point(7, 69);
            this.autoLabel2.Name = "autoLabel2";
            this.autoLabel2.Size = new System.Drawing.Size(60, 16);
            this.autoLabel2.TabIndex = 10;
            this.autoLabel2.Text = "Program";
            // 
            // cmbProgram
            // 
            this.cmbProgram.BeforeTouchSize = new System.Drawing.Size(361, 24);
            this.cmbProgram.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProgram.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbProgram.Location = new System.Drawing.Point(115, 67);
            this.cmbProgram.Name = "cmbProgram";
            this.cmbProgram.Size = new System.Drawing.Size(361, 24);
            this.cmbProgram.TabIndex = 9;
            this.cmbProgram.SelectedIndexChanged += new System.EventHandler(this.cmbProgram_SelectedIndexChanged);
            // 
            // autoLabel15
            // 
            this.autoLabel15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.autoLabel15.Location = new System.Drawing.Point(7, 39);
            this.autoLabel15.Name = "autoLabel15";
            this.autoLabel15.Size = new System.Drawing.Size(93, 16);
            this.autoLabel15.TabIndex = 8;
            this.autoLabel15.Text = "Program Studi";
            // 
            // cmbProdi
            // 
            this.cmbProdi.BeforeTouchSize = new System.Drawing.Size(361, 24);
            this.cmbProdi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProdi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbProdi.Location = new System.Drawing.Point(115, 37);
            this.cmbProdi.Name = "cmbProdi";
            this.cmbProdi.Size = new System.Drawing.Size(361, 24);
            this.cmbProdi.TabIndex = 2;
            this.cmbProdi.SelectedIndexChanged += new System.EventHandler(this.cmbProdi_SelectedIndexChanged);
            // 
            // cmbFakultas
            // 
            this.cmbFakultas.BeforeTouchSize = new System.Drawing.Size(361, 25);
            this.cmbFakultas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFakultas.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbFakultas.Location = new System.Drawing.Point(115, 6);
            this.cmbFakultas.Name = "cmbFakultas";
            this.cmbFakultas.Size = new System.Drawing.Size(361, 25);
            this.cmbFakultas.TabIndex = 1;
            this.cmbFakultas.SelectedIndexChanged += new System.EventHandler(this.cmbFakultas_SelectedIndexChanged);
            // 
            // autoLabel1
            // 
            this.autoLabel1.Location = new System.Drawing.Point(8, 8);
            this.autoLabel1.Name = "autoLabel1";
            this.autoLabel1.Size = new System.Drawing.Size(54, 17);
            this.autoLabel1.TabIndex = 1;
            this.autoLabel1.Text = "Fakultas";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnTutup);
            this.flowLayoutPanel1.Controls.Add(this.progressBar1);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 443);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(857, 38);
            this.flowLayoutPanel1.TabIndex = 10;
            // 
            // btnTutup
            // 
            this.btnTutup.BeforeTouchSize = new System.Drawing.Size(113, 30);
            this.btnTutup.IsBackStageButton = false;
            this.btnTutup.Location = new System.Drawing.Point(741, 4);
            this.btnTutup.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnTutup.Name = "btnTutup";
            this.btnTutup.Size = new System.Drawing.Size(113, 30);
            this.btnTutup.TabIndex = 0;
            this.btnTutup.Text = "Tutup";
            this.btnTutup.Click += new System.EventHandler(this.btnTutup_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(452, 3);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(283, 30);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar1.TabIndex = 1;
            this.progressBar1.Visible = false;
            // 
            // splitContainerAdv1
            // 
            this.splitContainerAdv1.BeforeTouchSize = 7;
            this.splitContainerAdv1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerAdv1.Location = new System.Drawing.Point(0, 103);
            this.splitContainerAdv1.Name = "splitContainerAdv1";
            this.splitContainerAdv1.Orientation = System.Windows.Forms.Orientation.Vertical;
            // 
            // splitContainerAdv1.Panel1
            // 
            this.splitContainerAdv1.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainerAdv1.Panel2
            // 
            this.splitContainerAdv1.Panel2.Controls.Add(this.groupBox2);
            this.splitContainerAdv1.Size = new System.Drawing.Size(857, 340);
            this.splitContainerAdv1.SplitterDistance = 180;
            this.splitContainerAdv1.TabIndex = 11;
            this.splitContainerAdv1.Text = "splitContainerAdv1";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvMK);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(857, 180);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Mata Kuliah";
            // 
            // dgvMK
            // 
            this.dgvMK.AllowDrop = true;
            this.dgvMK.AllowUserToAddRows = false;
            this.dgvMK.AllowUserToDeleteRows = false;
            this.dgvMK.AllowUserToResizeRows = false;
            this.dgvMK.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMK.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvMK.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMK.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Pilih,
            this.Semester,
            this.Angkatan,
            this.Kode,
            this.MataKuliah,
            this.SifatMK,
            this.SksTeori,
            this.SksPrak,
            this.T,
            this.P,
            this.TP,
            this.DaftarKelasMK});
            this.dgvMK.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMK.Location = new System.Drawing.Point(3, 21);
            this.dgvMK.MultiSelect = false;
            this.dgvMK.Name = "dgvMK";
            this.dgvMK.RowHeadersVisible = false;
            this.dgvMK.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMK.Size = new System.Drawing.Size(851, 156);
            this.dgvMK.TabIndex = 0;
            this.dgvMK.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvMK_DataError);
            this.dgvMK.DragEnter += new System.Windows.Forms.DragEventHandler(this.dgvMK_DragEnter);
            this.dgvMK.DragOver += new System.Windows.Forms.DragEventHandler(this.dgvMK_DragOver);
            this.dgvMK.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dgvMK_MouseDown);
            this.dgvMK.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dgvMK_MouseMove);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvMktsd);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(857, 153);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Mata Kuliah Akan Ditawarkan";
            // 
            // dgvMktsd
            // 
            this.dgvMktsd.AllowDrop = true;
            this.dgvMktsd.AllowUserToAddRows = false;
            this.dgvMktsd.AllowUserToDeleteRows = false;
            this.dgvMktsd.AllowUserToResizeRows = false;
            this.dgvMktsd.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgvMktsd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMktsd.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.AngkatanBerlaku,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.pJenis});
            this.dgvMktsd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMktsd.Location = new System.Drawing.Point(3, 21);
            this.dgvMktsd.MultiSelect = false;
            this.dgvMktsd.Name = "dgvMktsd";
            this.dgvMktsd.ReadOnly = true;
            this.dgvMktsd.RowHeadersVisible = false;
            this.dgvMktsd.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMktsd.Size = new System.Drawing.Size(851, 129);
            this.dgvMktsd.TabIndex = 0;
            this.dgvMktsd.DragOver += new System.Windows.Forms.DragEventHandler(this.dgvMktsd_DragOver);
            this.dgvMktsd.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dgvMktsd_MouseDown);
            this.dgvMktsd.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dgvMktsd_MouseMove);
            // 
            // Pilih
            // 
            this.Pilih.HeaderText = "Pilih";
            this.Pilih.Name = "Pilih";
            this.Pilih.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Pilih.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Pilih.Width = 50;
            // 
            // Semester
            // 
            this.Semester.HeaderText = "Semester";
            this.Semester.Name = "Semester";
            this.Semester.Width = 60;
            // 
            // Angkatan
            // 
            this.Angkatan.HeaderText = "Angkatan";
            this.Angkatan.Name = "Angkatan";
            this.Angkatan.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Angkatan.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Angkatan.Width = 60;
            // 
            // Kode
            // 
            this.Kode.HeaderText = "Kode";
            this.Kode.Name = "Kode";
            this.Kode.ReadOnly = true;
            this.Kode.Width = 70;
            // 
            // MataKuliah
            // 
            this.MataKuliah.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.MataKuliah.HeaderText = "MataKuliah";
            this.MataKuliah.Name = "MataKuliah";
            this.MataKuliah.ReadOnly = true;
            // 
            // SifatMK
            // 
            this.SifatMK.HeaderText = "Sifat MK";
            this.SifatMK.Name = "SifatMK";
            this.SifatMK.ReadOnly = true;
            this.SifatMK.Width = 70;
            // 
            // SksTeori
            // 
            this.SksTeori.HeaderText = "Sks Teori";
            this.SksTeori.Name = "SksTeori";
            this.SksTeori.ReadOnly = true;
            this.SksTeori.Width = 50;
            // 
            // SksPrak
            // 
            this.SksPrak.HeaderText = "Sks Praktikum";
            this.SksPrak.Name = "SksPrak";
            this.SksPrak.Width = 70;
            // 
            // T
            // 
            this.T.HeaderText = "T";
            this.T.Name = "T";
            this.T.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.T.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.T.Width = 30;
            // 
            // P
            // 
            this.P.HeaderText = "P";
            this.P.Name = "P";
            this.P.Width = 30;
            // 
            // TP
            // 
            this.TP.HeaderText = "TP";
            this.TP.Name = "TP";
            this.TP.Width = 30;
            // 
            // DaftarKelasMK
            // 
            this.DaftarKelasMK.HeaderText = "Daftar Kelas";
            this.DaftarKelasMK.Name = "DaftarKelasMK";
            this.DaftarKelasMK.Width = 70;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "No";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 50;
            // 
            // AngkatanBerlaku
            // 
            this.AngkatanBerlaku.HeaderText = "Angkatan";
            this.AngkatanBerlaku.Name = "AngkatanBerlaku";
            this.AngkatanBerlaku.ReadOnly = true;
            this.AngkatanBerlaku.Width = 70;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Kode";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 70;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn3.HeaderText = "MataKuliah";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // pJenis
            // 
            this.pJenis.HeaderText = "Jenis MK";
            this.pJenis.Name = "pJenis";
            this.pJenis.ReadOnly = true;
            // 
            // FormAlokasiMK
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CaptionFont = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClientSize = new System.Drawing.Size(857, 481);
            this.Controls.Add(this.splitContainerAdv1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.gradientPanel2);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FormAlokasiMK";
            this.Text = "Penawaran Mata Kuliah";
            this.Load += new System.EventHandler(this.FormAlokasiMK_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gradientPanel2)).EndInit();
            this.gradientPanel2.ResumeLayout(false);
            this.gradientPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbProgram)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbProdi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbFakultas)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.splitContainerAdv1.Panel1.ResumeLayout(false);
            this.splitContainerAdv1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerAdv1)).EndInit();
            this.splitContainerAdv1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMK)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMktsd)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Syncfusion.Windows.Forms.Tools.GradientPanel gradientPanel2;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel2;
        private Syncfusion.Windows.Forms.Tools.ComboBoxAdv cmbProgram;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel15;
        private Syncfusion.Windows.Forms.Tools.ComboBoxAdv cmbProdi;
        private Syncfusion.Windows.Forms.Tools.ComboBoxAdv cmbFakultas;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private Syncfusion.Windows.Forms.ButtonAdv btnTutup;
        private System.Windows.Forms.ProgressBar progressBar1;
        private Syncfusion.Windows.Forms.Tools.SplitContainerAdv splitContainerAdv1;
        private System.Windows.Forms.DataGridView dgvMK;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvMktsd;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Pilih;
        private System.Windows.Forms.DataGridViewTextBoxColumn Semester;
        private System.Windows.Forms.DataGridViewComboBoxColumn Angkatan;
        private System.Windows.Forms.DataGridViewTextBoxColumn Kode;
        private System.Windows.Forms.DataGridViewTextBoxColumn MataKuliah;
        private System.Windows.Forms.DataGridViewTextBoxColumn SifatMK;
        private System.Windows.Forms.DataGridViewTextBoxColumn SksTeori;
        private System.Windows.Forms.DataGridViewTextBoxColumn SksPrak;
        private System.Windows.Forms.DataGridViewCheckBoxColumn T;
        private System.Windows.Forms.DataGridViewCheckBoxColumn P;
        private System.Windows.Forms.DataGridViewCheckBoxColumn TP;
        private System.Windows.Forms.DataGridViewCheckBoxColumn DaftarKelasMK;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn AngkatanBerlaku;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn pJenis;
    }
}