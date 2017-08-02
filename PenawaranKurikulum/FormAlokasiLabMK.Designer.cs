#region Copyright Syncfusion Inc. 2001 - 2016
// Copyright Syncfusion Inc. 2001 - 2016. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
namespace PenawaranKurikulum
{
    partial class FormAlokasiLabMK
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnTutup = new Syncfusion.Windows.Forms.ButtonAdv();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.gradientPanel2 = new Syncfusion.Windows.Forms.Tools.GradientPanel();
            this.autoLabel2 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.cmbProgram = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            this.autoLabel15 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.cmbProdi = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            this.cmbFakultas = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            this.autoLabel1 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.splitContainerAdv1 = new Syncfusion.Windows.Forms.Tools.SplitContainerAdv();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvDaftarLab = new AdvancedDataGridView.TreeGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvMKPraktikum = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Kode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MataKuliah = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SksT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SksPraktikum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.JumlahKelas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ubahJumlahKelasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Node = new AdvancedDataGridView.TreeGridColumn();
            this.Ruang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tKode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tMataKuliah = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tJumlahKelas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalKelas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KodeProgram = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NamaProgram = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Parent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gradientPanel2)).BeginInit();
            this.gradientPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbProgram)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbProdi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbFakultas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerAdv1)).BeginInit();
            this.splitContainerAdv1.Panel1.SuspendLayout();
            this.splitContainerAdv1.Panel2.SuspendLayout();
            this.splitContainerAdv1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDaftarLab)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMKPraktikum)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnTutup);
            this.flowLayoutPanel1.Controls.Add(this.progressBar1);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 415);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1037, 38);
            this.flowLayoutPanel1.TabIndex = 12;
            // 
            // btnTutup
            // 
            this.btnTutup.BeforeTouchSize = new System.Drawing.Size(113, 30);
            this.btnTutup.IsBackStageButton = false;
            this.btnTutup.Location = new System.Drawing.Point(921, 4);
            this.btnTutup.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnTutup.Name = "btnTutup";
            this.btnTutup.Size = new System.Drawing.Size(113, 30);
            this.btnTutup.TabIndex = 0;
            this.btnTutup.Text = "Tutup";
            this.btnTutup.Click += new System.EventHandler(this.btnTutup_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(632, 3);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(283, 30);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar1.TabIndex = 1;
            this.progressBar1.Visible = false;
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
            this.gradientPanel2.Size = new System.Drawing.Size(1037, 103);
            this.gradientPanel2.TabIndex = 11;
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
            // splitContainerAdv1
            // 
            this.splitContainerAdv1.BeforeTouchSize = 7;
            this.splitContainerAdv1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerAdv1.Location = new System.Drawing.Point(0, 103);
            this.splitContainerAdv1.Name = "splitContainerAdv1";
            // 
            // splitContainerAdv1.Panel1
            // 
            this.splitContainerAdv1.Panel1.Controls.Add(this.groupBox2);
            // 
            // splitContainerAdv1.Panel2
            // 
            this.splitContainerAdv1.Panel2.Controls.Add(this.groupBox1);
            this.splitContainerAdv1.Size = new System.Drawing.Size(1037, 312);
            this.splitContainerAdv1.SplitterDistance = 517;
            this.splitContainerAdv1.TabIndex = 13;
            this.splitContainerAdv1.Text = "splitContainerAdv1";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvDaftarLab);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(517, 312);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Daftar Lab";
            // 
            // dgvDaftarLab
            // 
            this.dgvDaftarLab.AllowDrop = true;
            this.dgvDaftarLab.AllowUserToAddRows = false;
            this.dgvDaftarLab.AllowUserToDeleteRows = false;
            this.dgvDaftarLab.AllowUserToResizeRows = false;
            this.dgvDaftarLab.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgvDaftarLab.ColumnHeadersHeight = 50;
            this.dgvDaftarLab.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Node,
            this.Ruang,
            this.tKode,
            this.tMataKuliah,
            this.tJumlahKelas,
            this.TotalKelas,
            this.KodeProgram,
            this.NamaProgram,
            this.Parent});
            this.dgvDaftarLab.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvDaftarLab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDaftarLab.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvDaftarLab.ImageList = null;
            this.dgvDaftarLab.Location = new System.Drawing.Point(3, 21);
            this.dgvDaftarLab.MultiSelect = false;
            this.dgvDaftarLab.Name = "dgvDaftarLab";
            this.dgvDaftarLab.RowHeadersVisible = false;
            this.dgvDaftarLab.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDaftarLab.Size = new System.Drawing.Size(511, 288);
            this.dgvDaftarLab.TabIndex = 0;
            this.dgvDaftarLab.DragDrop += new System.Windows.Forms.DragEventHandler(this.dgvDaftarLab_DragDrop);
            this.dgvDaftarLab.DragEnter += new System.Windows.Forms.DragEventHandler(this.dgvDaftarLab_DragEnter);
            this.dgvDaftarLab.DragOver += new System.Windows.Forms.DragEventHandler(this.dgvDaftarLab_DragOver);
            this.dgvDaftarLab.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dgvDaftarLab_MouseDown);
            this.dgvDaftarLab.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dgvDaftarLab_MouseMove);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvMKPraktikum);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(513, 312);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Mata Kuliah Praktikum";
            // 
            // dgvMKPraktikum
            // 
            this.dgvMKPraktikum.AllowDrop = true;
            this.dgvMKPraktikum.AllowUserToAddRows = false;
            this.dgvMKPraktikum.AllowUserToDeleteRows = false;
            this.dgvMKPraktikum.AllowUserToResizeRows = false;
            this.dgvMKPraktikum.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgvMKPraktikum.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMKPraktikum.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.Kode,
            this.MataKuliah,
            this.SksT,
            this.SksPraktikum,
            this.JumlahKelas});
            this.dgvMKPraktikum.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMKPraktikum.Location = new System.Drawing.Point(3, 21);
            this.dgvMKPraktikum.MultiSelect = false;
            this.dgvMKPraktikum.Name = "dgvMKPraktikum";
            this.dgvMKPraktikum.ReadOnly = true;
            this.dgvMKPraktikum.RowHeadersVisible = false;
            this.dgvMKPraktikum.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMKPraktikum.Size = new System.Drawing.Size(507, 288);
            this.dgvMKPraktikum.TabIndex = 11;
            this.dgvMKPraktikum.DragDrop += new System.Windows.Forms.DragEventHandler(this.dgvMKPraktikum_DragDrop);
            this.dgvMKPraktikum.DragEnter += new System.Windows.Forms.DragEventHandler(this.dgvMKPraktikum_DragEnter);
            this.dgvMKPraktikum.DragOver += new System.Windows.Forms.DragEventHandler(this.dgvMKPraktikum_DragOver);
            this.dgvMKPraktikum.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dgvMKPraktikum_MouseDown);
            this.dgvMKPraktikum.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dgvMKPraktikum_MouseMove);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "No";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 40;
            // 
            // Kode
            // 
            this.Kode.HeaderText = "Kode";
            this.Kode.Name = "Kode";
            this.Kode.ReadOnly = true;
            this.Kode.Width = 75;
            // 
            // MataKuliah
            // 
            this.MataKuliah.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.MataKuliah.HeaderText = "Mata Kuliah";
            this.MataKuliah.Name = "MataKuliah";
            this.MataKuliah.ReadOnly = true;
            this.MataKuliah.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // SksT
            // 
            this.SksT.HeaderText = "Sks T";
            this.SksT.Name = "SksT";
            this.SksT.ReadOnly = true;
            this.SksT.Width = 40;
            // 
            // SksPraktikum
            // 
            this.SksPraktikum.HeaderText = "Sks P";
            this.SksPraktikum.Name = "SksPraktikum";
            this.SksPraktikum.ReadOnly = true;
            this.SksPraktikum.Width = 40;
            // 
            // JumlahKelas
            // 
            this.JumlahKelas.HeaderText = "Jumlah Kelas";
            this.JumlahKelas.Name = "JumlahKelas";
            this.JumlahKelas.ReadOnly = true;
            this.JumlahKelas.Width = 50;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ubahJumlahKelasToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(174, 26);
            // 
            // ubahJumlahKelasToolStripMenuItem
            // 
            this.ubahJumlahKelasToolStripMenuItem.Name = "ubahJumlahKelasToolStripMenuItem";
            this.ubahJumlahKelasToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.ubahJumlahKelasToolStripMenuItem.Text = "Ubah Jumlah Kelas";
            this.ubahJumlahKelasToolStripMenuItem.Click += new System.EventHandler(this.ubahJumlahKelasToolStripMenuItem_Click);
            // 
            // Node
            // 
            this.Node.DefaultNodeImage = null;
            this.Node.HeaderText = "";
            this.Node.Name = "Node";
            this.Node.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Node.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Node.Width = 25;
            // 
            // Ruang
            // 
            this.Ruang.HeaderText = "Ruang";
            this.Ruang.Name = "Ruang";
            this.Ruang.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Ruang.Width = 60;
            // 
            // tKode
            // 
            this.tKode.HeaderText = "Kode";
            this.tKode.Name = "tKode";
            this.tKode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.tKode.Width = 70;
            // 
            // tMataKuliah
            // 
            this.tMataKuliah.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.tMataKuliah.HeaderText = "Mata Kuliah";
            this.tMataKuliah.Name = "tMataKuliah";
            this.tMataKuliah.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // tJumlahKelas
            // 
            this.tJumlahKelas.HeaderText = "Jumlah Kelas";
            this.tJumlahKelas.Name = "tJumlahKelas";
            this.tJumlahKelas.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.tJumlahKelas.Width = 60;
            // 
            // TotalKelas
            // 
            this.TotalKelas.HeaderText = "Total Kelas";
            this.TotalKelas.Name = "TotalKelas";
            this.TotalKelas.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.TotalKelas.Visible = false;
            // 
            // KodeProgram
            // 
            this.KodeProgram.HeaderText = "Kode Program";
            this.KodeProgram.Name = "KodeProgram";
            this.KodeProgram.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.KodeProgram.Visible = false;
            // 
            // NamaProgram
            // 
            this.NamaProgram.HeaderText = "Nama Program";
            this.NamaProgram.Name = "NamaProgram";
            this.NamaProgram.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.NamaProgram.Width = 150;
            // 
            // Parent
            // 
            this.Parent.HeaderText = "Parent";
            this.Parent.Name = "Parent";
            this.Parent.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Parent.Visible = false;
            // 
            // FormAlokasiLabMK
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CaptionFont = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClientSize = new System.Drawing.Size(1037, 453);
            this.Controls.Add(this.splitContainerAdv1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.gradientPanel2);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FormAlokasiLabMK";
            this.Text = "Alokasi Lab. dan Mata Kuliah";
            this.Load += new System.EventHandler(this.FormAlokasiLabMK_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gradientPanel2)).EndInit();
            this.gradientPanel2.ResumeLayout(false);
            this.gradientPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbProgram)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbProdi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbFakultas)).EndInit();
            this.splitContainerAdv1.Panel1.ResumeLayout(false);
            this.splitContainerAdv1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerAdv1)).EndInit();
            this.splitContainerAdv1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDaftarLab)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMKPraktikum)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private Syncfusion.Windows.Forms.ButtonAdv btnTutup;
        private System.Windows.Forms.ProgressBar progressBar1;
        private Syncfusion.Windows.Forms.Tools.GradientPanel gradientPanel2;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel2;
        private Syncfusion.Windows.Forms.Tools.ComboBoxAdv cmbProgram;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel15;
        private Syncfusion.Windows.Forms.Tools.ComboBoxAdv cmbProdi;
        private Syncfusion.Windows.Forms.Tools.ComboBoxAdv cmbFakultas;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel1;
        private Syncfusion.Windows.Forms.Tools.SplitContainerAdv splitContainerAdv1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvMKPraktikum;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Kode;
        private System.Windows.Forms.DataGridViewTextBoxColumn MataKuliah;
        private System.Windows.Forms.DataGridViewTextBoxColumn SksT;
        private System.Windows.Forms.DataGridViewTextBoxColumn SksPraktikum;
        private System.Windows.Forms.DataGridViewTextBoxColumn JumlahKelas;
        private AdvancedDataGridView.TreeGridView dgvDaftarLab;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ubahJumlahKelasToolStripMenuItem;
        private AdvancedDataGridView.TreeGridColumn Node;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ruang;
        private System.Windows.Forms.DataGridViewTextBoxColumn tKode;
        private System.Windows.Forms.DataGridViewTextBoxColumn tMataKuliah;
        private System.Windows.Forms.DataGridViewTextBoxColumn tJumlahKelas;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalKelas;
        private System.Windows.Forms.DataGridViewTextBoxColumn KodeProgram;
        private System.Windows.Forms.DataGridViewTextBoxColumn NamaProgram;
        private System.Windows.Forms.DataGridViewTextBoxColumn Parent;
    }
}