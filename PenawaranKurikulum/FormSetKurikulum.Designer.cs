#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
namespace PenawaranKurikulum
{
    partial class FormSetKurikulum
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.autoLabel3 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.cmbProgram = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            this.autoLabel2 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.cmbAngkatan = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            this.autoLabel15 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.cmbProdi = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            this.cmbFakultas = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            this.autoLabel1 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnTutup = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnExportExcel = new System.Windows.Forms.Button();
            this.btnSetKurikulum = new System.Windows.Forms.Button();
            this.dgvKurikulum = new System.Windows.Forms.DataGridView();
            this.IdKurikulum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Angkatan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Kode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MataKuliah = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NilaiMinimal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SifatMk = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.hapusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gbKurikulum = new System.Windows.Forms.GroupBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblTotalSks = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblTotalMk = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblSksKonsentrasi = new System.Windows.Forms.Label();
            this.lblSksPilihan = new System.Windows.Forms.Label();
            this.lblSksWajib = new System.Windows.Forms.Label();
            this.lblMkPilihan = new System.Windows.Forms.Label();
            this.lblMkKonsentrasi = new System.Windows.Forms.Label();
            this.lblMkWajib = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbProgram)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbAngkatan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbProdi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbFakultas)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKurikulum)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.gbKurikulum.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.autoLabel3);
            this.panel1.Controls.Add(this.cmbProgram);
            this.panel1.Controls.Add(this.autoLabel2);
            this.panel1.Controls.Add(this.cmbAngkatan);
            this.panel1.Controls.Add(this.autoLabel15);
            this.panel1.Controls.Add(this.cmbProdi);
            this.panel1.Controls.Add(this.cmbFakultas);
            this.panel1.Controls.Add(this.autoLabel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(842, 139);
            this.panel1.TabIndex = 0;
            // 
            // autoLabel3
            // 
            this.autoLabel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.autoLabel3.Location = new System.Drawing.Point(10, 75);
            this.autoLabel3.Name = "autoLabel3";
            this.autoLabel3.Size = new System.Drawing.Size(60, 16);
            this.autoLabel3.TabIndex = 16;
            this.autoLabel3.Text = "Program";
            // 
            // cmbProgram
            // 
            this.cmbProgram.BeforeTouchSize = new System.Drawing.Size(361, 24);
            this.cmbProgram.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProgram.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbProgram.Location = new System.Drawing.Point(118, 73);
            this.cmbProgram.Name = "cmbProgram";
            this.cmbProgram.Size = new System.Drawing.Size(361, 24);
            this.cmbProgram.TabIndex = 15;
            this.cmbProgram.SelectedIndexChanged += new System.EventHandler(this.cmbProgram_SelectedIndexChanged);
            // 
            // autoLabel2
            // 
            this.autoLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.autoLabel2.Location = new System.Drawing.Point(10, 105);
            this.autoLabel2.Name = "autoLabel2";
            this.autoLabel2.Size = new System.Drawing.Size(65, 16);
            this.autoLabel2.TabIndex = 14;
            this.autoLabel2.Text = "Angkatan";
            // 
            // cmbAngkatan
            // 
            this.cmbAngkatan.BeforeTouchSize = new System.Drawing.Size(162, 24);
            this.cmbAngkatan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAngkatan.DropDownWidth = 180;
            this.cmbAngkatan.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbAngkatan.Location = new System.Drawing.Point(118, 103);
            this.cmbAngkatan.Name = "cmbAngkatan";
            this.cmbAngkatan.Size = new System.Drawing.Size(162, 24);
            this.cmbAngkatan.TabIndex = 13;
            this.cmbAngkatan.SelectedIndexChanged += new System.EventHandler(this.cmbAngkatan_SelectedIndexChanged);
            // 
            // autoLabel15
            // 
            this.autoLabel15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.autoLabel15.Location = new System.Drawing.Point(10, 45);
            this.autoLabel15.Name = "autoLabel15";
            this.autoLabel15.Size = new System.Drawing.Size(93, 16);
            this.autoLabel15.TabIndex = 12;
            this.autoLabel15.Text = "Program Studi";
            // 
            // cmbProdi
            // 
            this.cmbProdi.BeforeTouchSize = new System.Drawing.Size(361, 24);
            this.cmbProdi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProdi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbProdi.Location = new System.Drawing.Point(118, 43);
            this.cmbProdi.Name = "cmbProdi";
            this.cmbProdi.Size = new System.Drawing.Size(361, 24);
            this.cmbProdi.TabIndex = 11;
            this.cmbProdi.SelectedIndexChanged += new System.EventHandler(this.cmbProdi_SelectedIndexChanged);
            // 
            // cmbFakultas
            // 
            this.cmbFakultas.BeforeTouchSize = new System.Drawing.Size(361, 25);
            this.cmbFakultas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFakultas.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbFakultas.Location = new System.Drawing.Point(118, 12);
            this.cmbFakultas.Name = "cmbFakultas";
            this.cmbFakultas.Size = new System.Drawing.Size(361, 25);
            this.cmbFakultas.TabIndex = 9;
            this.cmbFakultas.SelectedIndexChanged += new System.EventHandler(this.cmbFakultas_SelectedIndexChanged);
            // 
            // autoLabel1
            // 
            this.autoLabel1.Location = new System.Drawing.Point(11, 14);
            this.autoLabel1.Name = "autoLabel1";
            this.autoLabel1.Size = new System.Drawing.Size(54, 17);
            this.autoLabel1.TabIndex = 10;
            this.autoLabel1.Text = "Fakultas";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanel1.Controls.Add(this.btnTutup);
            this.flowLayoutPanel1.Controls.Add(this.progressBar1);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 425);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(842, 38);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // btnTutup
            // 
            this.btnTutup.Location = new System.Drawing.Point(740, 3);
            this.btnTutup.Name = "btnTutup";
            this.btnTutup.Size = new System.Drawing.Size(97, 28);
            this.btnTutup.TabIndex = 0;
            this.btnTutup.Text = "Tutup";
            this.btnTutup.UseVisualStyleBackColor = true;
            this.btnTutup.Click += new System.EventHandler(this.btnTutup_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(520, 3);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(214, 28);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar1.TabIndex = 2;
            this.progressBar1.Visible = false;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.btnExportExcel);
            this.flowLayoutPanel2.Controls.Add(this.btnSetKurikulum);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(0, 387);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(842, 38);
            this.flowLayoutPanel2.TabIndex = 2;
            // 
            // btnExportExcel
            // 
            this.btnExportExcel.Location = new System.Drawing.Point(3, 3);
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.Size = new System.Drawing.Size(112, 28);
            this.btnExportExcel.TabIndex = 2;
            this.btnExportExcel.Text = "Export Excel...";
            this.btnExportExcel.UseVisualStyleBackColor = true;
            // 
            // btnSetKurikulum
            // 
            this.btnSetKurikulum.Location = new System.Drawing.Point(121, 3);
            this.btnSetKurikulum.Name = "btnSetKurikulum";
            this.btnSetKurikulum.Size = new System.Drawing.Size(112, 28);
            this.btnSetKurikulum.TabIndex = 1;
            this.btnSetKurikulum.Text = "Set Kurikulum...";
            this.btnSetKurikulum.UseVisualStyleBackColor = true;
            this.btnSetKurikulum.Click += new System.EventHandler(this.btnSetKurikulum_Click);
            // 
            // dgvKurikulum
            // 
            this.dgvKurikulum.AllowUserToAddRows = false;
            this.dgvKurikulum.AllowUserToDeleteRows = false;
            this.dgvKurikulum.AllowUserToResizeRows = false;
            this.dgvKurikulum.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvKurikulum.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgvKurikulum.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKurikulum.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdKurikulum,
            this.No,
            this.Angkatan,
            this.Kode,
            this.MataKuliah,
            this.NilaiMinimal,
            this.Sks,
            this.SifatMk});
            this.dgvKurikulum.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvKurikulum.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvKurikulum.Location = new System.Drawing.Point(0, 55);
            this.dgvKurikulum.MultiSelect = false;
            this.dgvKurikulum.Name = "dgvKurikulum";
            this.dgvKurikulum.RowHeadersVisible = false;
            this.dgvKurikulum.Size = new System.Drawing.Size(600, 169);
            this.dgvKurikulum.TabIndex = 3;
            this.dgvKurikulum.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvKurikulum_CellValueChanged);
            this.dgvKurikulum.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dgvKurikulum_MouseDown);
            // 
            // IdKurikulum
            // 
            this.IdKurikulum.HeaderText = "IdKurikulum";
            this.IdKurikulum.Name = "IdKurikulum";
            this.IdKurikulum.Visible = false;
            this.IdKurikulum.Width = 82;
            // 
            // No
            // 
            this.No.HeaderText = "No";
            this.No.Name = "No";
            this.No.ReadOnly = true;
            this.No.Width = 51;
            // 
            // Angkatan
            // 
            this.Angkatan.HeaderText = "Angkatan";
            this.Angkatan.Name = "Angkatan";
            this.Angkatan.ReadOnly = true;
            this.Angkatan.Width = 87;
            // 
            // Kode
            // 
            this.Kode.HeaderText = "Kode";
            this.Kode.Name = "Kode";
            this.Kode.ReadOnly = true;
            this.Kode.Width = 64;
            // 
            // MataKuliah
            // 
            this.MataKuliah.HeaderText = "Mata Kuliah";
            this.MataKuliah.Name = "MataKuliah";
            this.MataKuliah.ReadOnly = true;
            this.MataKuliah.Width = 102;
            // 
            // NilaiMinimal
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.NilaiMinimal.DefaultCellStyle = dataGridViewCellStyle1;
            this.NilaiMinimal.HeaderText = "Nilai Minimal*";
            this.NilaiMinimal.Name = "NilaiMinimal";
            this.NilaiMinimal.Width = 114;
            // 
            // Sks
            // 
            this.Sks.HeaderText = "Sks";
            this.Sks.Name = "Sks";
            this.Sks.ReadOnly = true;
            this.Sks.Width = 52;
            // 
            // SifatMk
            // 
            this.SifatMk.HeaderText = "Sifat MK";
            this.SifatMk.Name = "SifatMk";
            this.SifatMk.ReadOnly = true;
            this.SifatMk.Width = 82;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hapusToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(153, 48);
            // 
            // hapusToolStripMenuItem
            // 
            this.hapusToolStripMenuItem.Name = "hapusToolStripMenuItem";
            this.hapusToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.hapusToolStripMenuItem.Text = "Hapus";
            this.hapusToolStripMenuItem.Click += new System.EventHandler(this.hapusToolStripMenuItem_Click);
            // 
            // gbKurikulum
            // 
            this.gbKurikulum.Controls.Add(this.splitContainer1);
            this.gbKurikulum.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbKurikulum.Location = new System.Drawing.Point(0, 139);
            this.gbKurikulum.Name = "gbKurikulum";
            this.gbKurikulum.Size = new System.Drawing.Size(842, 248);
            this.gbKurikulum.TabIndex = 4;
            this.gbKurikulum.TabStop = false;
            this.gbKurikulum.Text = "Data Kurikulum";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Location = new System.Drawing.Point(3, 21);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dgvKurikulum);
            this.splitContainer1.Panel1.Controls.Add(this.panel2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.lblTotalSks);
            this.splitContainer1.Panel2.Controls.Add(this.label10);
            this.splitContainer1.Panel2.Controls.Add(this.lblTotalMk);
            this.splitContainer1.Panel2.Controls.Add(this.label8);
            this.splitContainer1.Panel2.Controls.Add(this.lblSksKonsentrasi);
            this.splitContainer1.Panel2.Controls.Add(this.lblSksPilihan);
            this.splitContainer1.Panel2.Controls.Add(this.lblSksWajib);
            this.splitContainer1.Panel2.Controls.Add(this.lblMkPilihan);
            this.splitContainer1.Panel2.Controls.Add(this.lblMkKonsentrasi);
            this.splitContainer1.Panel2.Controls.Add(this.lblMkWajib);
            this.splitContainer1.Panel2.Controls.Add(this.label4);
            this.splitContainer1.Panel2.Controls.Add(this.label5);
            this.splitContainer1.Panel2.Controls.Add(this.label6);
            this.splitContainer1.Panel2.Controls.Add(this.label3);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Size = new System.Drawing.Size(836, 224);
            this.splitContainer1.SplitterDistance = 600;
            this.splitContainer1.TabIndex = 4;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(600, 55);
            this.panel2.TabIndex = 4;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(9, 28);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(467, 17);
            this.label9.TabIndex = 1;
            this.label9.Text = "- Untuk menghapus salah satu kode MK, klik kanan pada baris, dan pilih hapus";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 8);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(401, 17);
            this.label7.TabIndex = 0;
            this.label7.Text = "- Untuk mengisi nilai minimal, isi langsung pada kolom nilai minimal";
            // 
            // lblTotalSks
            // 
            this.lblTotalSks.AutoSize = true;
            this.lblTotalSks.Location = new System.Drawing.Point(170, 200);
            this.lblTotalSks.Name = "lblTotalSks";
            this.lblTotalSks.Size = new System.Drawing.Size(22, 17);
            this.lblTotalSks.TabIndex = 15;
            this.lblTotalSks.Text = ": 0";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(13, 200);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(59, 17);
            this.label10.TabIndex = 14;
            this.label10.Text = "Total Sks";
            // 
            // lblTotalMk
            // 
            this.lblTotalMk.AutoSize = true;
            this.lblTotalMk.Location = new System.Drawing.Point(170, 173);
            this.lblTotalMk.Name = "lblTotalMk";
            this.lblTotalMk.Size = new System.Drawing.Size(22, 17);
            this.lblTotalMk.TabIndex = 13;
            this.lblTotalMk.Text = ": 0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(13, 173);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(109, 17);
            this.label8.TabIndex = 12;
            this.label8.Text = "Total Mata Kuliah";
            // 
            // lblSksKonsentrasi
            // 
            this.lblSksKonsentrasi.AutoSize = true;
            this.lblSksKonsentrasi.Location = new System.Drawing.Point(170, 146);
            this.lblSksKonsentrasi.Name = "lblSksKonsentrasi";
            this.lblSksKonsentrasi.Size = new System.Drawing.Size(22, 17);
            this.lblSksKonsentrasi.TabIndex = 11;
            this.lblSksKonsentrasi.Text = ": 0";
            // 
            // lblSksPilihan
            // 
            this.lblSksPilihan.AutoSize = true;
            this.lblSksPilihan.Location = new System.Drawing.Point(170, 119);
            this.lblSksPilihan.Name = "lblSksPilihan";
            this.lblSksPilihan.Size = new System.Drawing.Size(22, 17);
            this.lblSksPilihan.TabIndex = 10;
            this.lblSksPilihan.Text = ": 0";
            // 
            // lblSksWajib
            // 
            this.lblSksWajib.AutoSize = true;
            this.lblSksWajib.Location = new System.Drawing.Point(170, 92);
            this.lblSksWajib.Name = "lblSksWajib";
            this.lblSksWajib.Size = new System.Drawing.Size(22, 17);
            this.lblSksWajib.TabIndex = 9;
            this.lblSksWajib.Text = ": 0";
            // 
            // lblMkPilihan
            // 
            this.lblMkPilihan.AutoSize = true;
            this.lblMkPilihan.Location = new System.Drawing.Point(170, 65);
            this.lblMkPilihan.Name = "lblMkPilihan";
            this.lblMkPilihan.Size = new System.Drawing.Size(22, 17);
            this.lblMkPilihan.TabIndex = 8;
            this.lblMkPilihan.Text = ": 0";
            // 
            // lblMkKonsentrasi
            // 
            this.lblMkKonsentrasi.AutoSize = true;
            this.lblMkKonsentrasi.Location = new System.Drawing.Point(170, 38);
            this.lblMkKonsentrasi.Name = "lblMkKonsentrasi";
            this.lblMkKonsentrasi.Size = new System.Drawing.Size(22, 17);
            this.lblMkKonsentrasi.TabIndex = 7;
            this.lblMkKonsentrasi.Text = ": 0";
            // 
            // lblMkWajib
            // 
            this.lblMkWajib.AutoSize = true;
            this.lblMkWajib.Location = new System.Drawing.Point(170, 11);
            this.lblMkWajib.Name = "lblMkWajib";
            this.lblMkWajib.Size = new System.Drawing.Size(22, 17);
            this.lblMkWajib.TabIndex = 6;
            this.lblMkWajib.Text = ": 0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 146);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(115, 17);
            this.label4.TabIndex = 5;
            this.label4.Text = "Jumlah SKS Pilihan";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 119);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(146, 17);
            this.label5.TabIndex = 4;
            this.label5.Text = "Jumlah SKS Konsentrasi";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 92);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(110, 17);
            this.label6.TabIndex = 3;
            this.label6.Text = "Jumlah SKS Wajib";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Jumlah MK Pilihan";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(144, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Jumlah MK Konsentrasi";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Jumlah MK Wajib";
            // 
            // FormSetKurikulum
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CaptionFont = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClientSize = new System.Drawing.Size(842, 463);
            this.Controls.Add(this.gbKurikulum);
            this.Controls.Add(this.flowLayoutPanel2);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FormSetKurikulum";
            this.Text = "Set Kurikulum";
            this.Load += new System.EventHandler(this.FormSetKurikulum_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbProgram)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbAngkatan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbProdi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbFakultas)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvKurikulum)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.gbKurikulum.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnTutup;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.DataGridView dgvKurikulum;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel15;
        private Syncfusion.Windows.Forms.Tools.ComboBoxAdv cmbProdi;
        private Syncfusion.Windows.Forms.Tools.ComboBoxAdv cmbFakultas;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel1;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel2;
        private Syncfusion.Windows.Forms.Tools.ComboBoxAdv cmbAngkatan;
        private System.Windows.Forms.Button btnSetKurikulum;
        private System.Windows.Forms.Button btnExportExcel;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel3;
        private Syncfusion.Windows.Forms.Tools.ComboBoxAdv cmbProgram;
        private System.Windows.Forms.GroupBox gbKurikulum;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblSksKonsentrasi;
        private System.Windows.Forms.Label lblSksPilihan;
        private System.Windows.Forms.Label lblSksWajib;
        private System.Windows.Forms.Label lblMkPilihan;
        private System.Windows.Forms.Label lblMkKonsentrasi;
        private System.Windows.Forms.Label lblMkWajib;
        private System.Windows.Forms.Label lblTotalMk;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblTotalSks;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdKurikulum;
        private System.Windows.Forms.DataGridViewTextBoxColumn No;
        private System.Windows.Forms.DataGridViewTextBoxColumn Angkatan;
        private System.Windows.Forms.DataGridViewTextBoxColumn Kode;
        private System.Windows.Forms.DataGridViewTextBoxColumn MataKuliah;
        private System.Windows.Forms.DataGridViewTextBoxColumn NilaiMinimal;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sks;
        private System.Windows.Forms.DataGridViewTextBoxColumn SifatMk;
        private System.Windows.Forms.ToolStripMenuItem hapusToolStripMenuItem;
    }
}