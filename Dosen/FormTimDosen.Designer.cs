#region Copyright Syncfusion Inc. 2001 - 2016
// Copyright Syncfusion Inc. 2001 - 2016. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
namespace Dosen
{
    partial class FormTimDosen
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnTutup = new Syncfusion.Windows.Forms.ButtonAdv();
            this.btnHapus = new Syncfusion.Windows.Forms.ButtonAdv();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.gradientPanel2 = new Syncfusion.Windows.Forms.Tools.GradientPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dgvDosen = new System.Windows.Forms.DataGridView();
            this.tNIk = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tDosen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.autoLabel4 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.dgvAddTim = new System.Windows.Forms.DataGridView();
            this.NIk = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NamaDosen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.autoLabel2 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.txtCari = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            this.gradientPanel3 = new Syncfusion.Windows.Forms.Tools.GradientPanel();
            this.btnClear = new Syncfusion.Windows.Forms.ButtonAdv();
            this.btnSimpan = new Syncfusion.Windows.Forms.ButtonAdv();
            this.txtNamaGrup = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            this.autoLabel1 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.gradientPanel1 = new Syncfusion.Windows.Forms.Tools.GradientPanel();
            this.autoLabel3 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.autoLabel15 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.autoLabel5 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.dgvTimDosen = new System.Windows.Forms.DataGridView();
            this.NamaTim = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aNik = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aNamaDosen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Hapus = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.comboBoxAdv1 = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            this.cmbProgram = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            this.cmbProdi = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            this.cmbFakultas = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gradientPanel2)).BeginInit();
            this.gradientPanel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDosen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAddTim)).BeginInit();
            this.flowLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCari)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gradientPanel3)).BeginInit();
            this.gradientPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtNamaGrup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gradientPanel1)).BeginInit();
            this.gradientPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTimDosen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxAdv1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbProgram)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbProdi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbFakultas)).BeginInit();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnTutup);
            this.flowLayoutPanel1.Controls.Add(this.btnHapus);
            this.flowLayoutPanel1.Controls.Add(this.progressBar1);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 445);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(807, 38);
            this.flowLayoutPanel1.TabIndex = 10;
            // 
            // btnTutup
            // 
            this.btnTutup.BeforeTouchSize = new System.Drawing.Size(113, 30);
            this.btnTutup.IsBackStageButton = false;
            this.btnTutup.Location = new System.Drawing.Point(691, 4);
            this.btnTutup.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnTutup.Name = "btnTutup";
            this.btnTutup.Size = new System.Drawing.Size(113, 30);
            this.btnTutup.TabIndex = 0;
            this.btnTutup.Text = "Tutup";
            this.btnTutup.Click += new System.EventHandler(this.btnTutup_Click);
            // 
            // btnHapus
            // 
            this.btnHapus.BeforeTouchSize = new System.Drawing.Size(113, 30);
            this.btnHapus.IsBackStageButton = false;
            this.btnHapus.Location = new System.Drawing.Point(572, 4);
            this.btnHapus.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnHapus.Name = "btnHapus";
            this.btnHapus.Size = new System.Drawing.Size(113, 30);
            this.btnHapus.TabIndex = 2;
            this.btnHapus.Text = "Hapus";
            this.btnHapus.Click += new System.EventHandler(this.btnHapus_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(206, 3);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(360, 30);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar1.TabIndex = 1;
            this.progressBar1.Visible = false;
            // 
            // gradientPanel2
            // 
            this.gradientPanel2.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat;
            this.gradientPanel2.Controls.Add(this.tableLayoutPanel1);
            this.gradientPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.gradientPanel2.Location = new System.Drawing.Point(0, 0);
            this.gradientPanel2.Name = "gradientPanel2";
            this.gradientPanel2.Size = new System.Drawing.Size(807, 316);
            this.gradientPanel2.TabIndex = 18;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 39.72603F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60.27397F));
            this.tableLayoutPanel1.Controls.Add(this.dgvDosen, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.autoLabel4, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.dgvAddTim, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.gradientPanel3, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.gradientPanel1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 12F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(803, 312);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // dgvDosen
            // 
            this.dgvDosen.AllowDrop = true;
            this.dgvDosen.AllowUserToAddRows = false;
            this.dgvDosen.AllowUserToDeleteRows = false;
            this.dgvDosen.AllowUserToResizeRows = false;
            this.dgvDosen.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgvDosen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDosen.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.tNIk,
            this.tDosen});
            this.dgvDosen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDosen.Location = new System.Drawing.Point(3, 139);
            this.dgvDosen.Name = "dgvDosen";
            this.dgvDosen.ReadOnly = true;
            this.dgvDosen.RowHeadersVisible = false;
            this.dgvDosen.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDosen.Size = new System.Drawing.Size(313, 104);
            this.dgvDosen.TabIndex = 19;
            this.dgvDosen.DragDrop += new System.Windows.Forms.DragEventHandler(this.dgvDosen_DragDrop);
            this.dgvDosen.DragEnter += new System.Windows.Forms.DragEventHandler(this.dgvDosen_DragEnter);
            this.dgvDosen.DragOver += new System.Windows.Forms.DragEventHandler(this.dgvDosen_DragOver);
            this.dgvDosen.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dgvDosen_MouseDown);
            this.dgvDosen.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dgvDosen_MouseMove);
            // 
            // tNIk
            // 
            this.tNIk.HeaderText = "Nik";
            this.tNIk.Name = "tNIk";
            this.tNIk.ReadOnly = true;
            // 
            // tDosen
            // 
            this.tDosen.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.tDosen.HeaderText = "Nama Dosen";
            this.tDosen.Name = "tDosen";
            this.tDosen.ReadOnly = true;
            // 
            // autoLabel4
            // 
            this.autoLabel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.autoLabel4.Location = new System.Drawing.Point(322, 100);
            this.autoLabel4.Name = "autoLabel4";
            this.autoLabel4.Size = new System.Drawing.Size(478, 36);
            this.autoLabel4.TabIndex = 16;
            this.autoLabel4.Text = "Tim Dosen";
            this.autoLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dgvAddTim
            // 
            this.dgvAddTim.AllowDrop = true;
            this.dgvAddTim.AllowUserToAddRows = false;
            this.dgvAddTim.AllowUserToDeleteRows = false;
            this.dgvAddTim.AllowUserToResizeRows = false;
            this.dgvAddTim.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgvAddTim.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAddTim.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NIk,
            this.NamaDosen});
            this.dgvAddTim.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAddTim.Location = new System.Drawing.Point(322, 139);
            this.dgvAddTim.Name = "dgvAddTim";
            this.dgvAddTim.ReadOnly = true;
            this.dgvAddTim.RowHeadersVisible = false;
            this.dgvAddTim.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAddTim.Size = new System.Drawing.Size(478, 104);
            this.dgvAddTim.TabIndex = 18;
            this.dgvAddTim.DragDrop += new System.Windows.Forms.DragEventHandler(this.dgvAddTim_DragDrop);
            this.dgvAddTim.DragEnter += new System.Windows.Forms.DragEventHandler(this.dgvAddTim_DragEnter);
            this.dgvAddTim.DragOver += new System.Windows.Forms.DragEventHandler(this.dgvAddTim_DragOver);
            this.dgvAddTim.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dgvAddTim_MouseDown);
            this.dgvAddTim.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dgvAddTim_MouseMove);
            // 
            // NIk
            // 
            this.NIk.HeaderText = "Nik";
            this.NIk.Name = "NIk";
            this.NIk.ReadOnly = true;
            // 
            // NamaDosen
            // 
            this.NamaDosen.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.NamaDosen.HeaderText = "Nama Dosen";
            this.NamaDosen.Name = "NamaDosen";
            this.NamaDosen.ReadOnly = true;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.autoLabel2);
            this.flowLayoutPanel2.Controls.Add(this.txtCari);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(3, 103);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(313, 30);
            this.flowLayoutPanel2.TabIndex = 20;
            // 
            // autoLabel2
            // 
            this.autoLabel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.autoLabel2.Location = new System.Drawing.Point(3, 0);
            this.autoLabel2.Name = "autoLabel2";
            this.autoLabel2.Size = new System.Drawing.Size(31, 31);
            this.autoLabel2.TabIndex = 0;
            this.autoLabel2.Text = "Cari";
            this.autoLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtCari
            // 
            this.txtCari.BeforeTouchSize = new System.Drawing.Size(352, 25);
            this.txtCari.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtCari.Location = new System.Drawing.Point(40, 3);
            this.txtCari.Metrocolor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.txtCari.Name = "txtCari";
            this.txtCari.Size = new System.Drawing.Size(217, 25);
            this.txtCari.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Default;
            this.txtCari.TabIndex = 1;
            this.txtCari.TextChanged += new System.EventHandler(this.txtCari_TextChanged);
            // 
            // gradientPanel3
            // 
            this.gradientPanel3.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat;
            this.gradientPanel3.BorderColor = System.Drawing.Color.Transparent;
            this.gradientPanel3.BorderSingle = System.Windows.Forms.ButtonBorderStyle.None;
            this.gradientPanel3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tableLayoutPanel1.SetColumnSpan(this.gradientPanel3, 2);
            this.gradientPanel3.Controls.Add(this.btnClear);
            this.gradientPanel3.Controls.Add(this.btnSimpan);
            this.gradientPanel3.Controls.Add(this.txtNamaGrup);
            this.gradientPanel3.Controls.Add(this.autoLabel1);
            this.gradientPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gradientPanel3.Location = new System.Drawing.Point(0, 246);
            this.gradientPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.gradientPanel3.Name = "gradientPanel3";
            this.gradientPanel3.Size = new System.Drawing.Size(803, 66);
            this.gradientPanel3.TabIndex = 17;
            // 
            // btnClear
            // 
            this.btnClear.BeforeTouchSize = new System.Drawing.Size(124, 30);
            this.btnClear.IsBackStageButton = false;
            this.btnClear.Location = new System.Drawing.Point(113, 34);
            this.btnClear.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(124, 30);
            this.btnClear.TabIndex = 3;
            this.btnClear.Text = "Clear";
            // 
            // btnSimpan
            // 
            this.btnSimpan.BeforeTouchSize = new System.Drawing.Size(102, 30);
            this.btnSimpan.IsBackStageButton = false;
            this.btnSimpan.Location = new System.Drawing.Point(5, 34);
            this.btnSimpan.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSimpan.Name = "btnSimpan";
            this.btnSimpan.Size = new System.Drawing.Size(102, 30);
            this.btnSimpan.TabIndex = 2;
            this.btnSimpan.Text = "Simpan";
            this.btnSimpan.Click += new System.EventHandler(this.btnSimpan_Click);
            // 
            // txtNamaGrup
            // 
            this.txtNamaGrup.BeforeTouchSize = new System.Drawing.Size(352, 25);
            this.txtNamaGrup.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtNamaGrup.Location = new System.Drawing.Point(113, 3);
            this.txtNamaGrup.Metrocolor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.txtNamaGrup.Name = "txtNamaGrup";
            this.txtNamaGrup.Size = new System.Drawing.Size(352, 25);
            this.txtNamaGrup.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Default;
            this.txtNamaGrup.TabIndex = 1;
            // 
            // autoLabel1
            // 
            this.autoLabel1.Location = new System.Drawing.Point(6, 8);
            this.autoLabel1.Name = "autoLabel1";
            this.autoLabel1.Size = new System.Drawing.Size(77, 17);
            this.autoLabel1.TabIndex = 0;
            this.autoLabel1.Text = "Nama Tim *";
            // 
            // gradientPanel1
            // 
            this.gradientPanel1.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat;
            this.tableLayoutPanel1.SetColumnSpan(this.gradientPanel1, 2);
            this.gradientPanel1.Controls.Add(this.cmbProgram);
            this.gradientPanel1.Controls.Add(this.cmbProdi);
            this.gradientPanel1.Controls.Add(this.cmbFakultas);
            this.gradientPanel1.Controls.Add(this.autoLabel3);
            this.gradientPanel1.Controls.Add(this.autoLabel15);
            this.gradientPanel1.Controls.Add(this.autoLabel5);
            this.gradientPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gradientPanel1.Location = new System.Drawing.Point(3, 3);
            this.gradientPanel1.Name = "gradientPanel1";
            this.gradientPanel1.Size = new System.Drawing.Size(797, 94);
            this.gradientPanel1.TabIndex = 21;
            // 
            // autoLabel3
            // 
            this.autoLabel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.autoLabel3.Location = new System.Drawing.Point(3, 66);
            this.autoLabel3.Name = "autoLabel3";
            this.autoLabel3.Size = new System.Drawing.Size(60, 16);
            this.autoLabel3.TabIndex = 16;
            this.autoLabel3.Text = "Program";
            // 
            // autoLabel15
            // 
            this.autoLabel15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.autoLabel15.Location = new System.Drawing.Point(3, 36);
            this.autoLabel15.Name = "autoLabel15";
            this.autoLabel15.Size = new System.Drawing.Size(93, 16);
            this.autoLabel15.TabIndex = 14;
            this.autoLabel15.Text = "Program Studi";
            // 
            // autoLabel5
            // 
            this.autoLabel5.Location = new System.Drawing.Point(4, 5);
            this.autoLabel5.Name = "autoLabel5";
            this.autoLabel5.Size = new System.Drawing.Size(54, 17);
            this.autoLabel5.TabIndex = 12;
            this.autoLabel5.Text = "Fakultas";
            // 
            // dgvTimDosen
            // 
            this.dgvTimDosen.AllowUserToAddRows = false;
            this.dgvTimDosen.AllowUserToDeleteRows = false;
            this.dgvTimDosen.AllowUserToResizeRows = false;
            this.dgvTimDosen.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTimDosen.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvTimDosen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTimDosen.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NamaTim,
            this.aNik,
            this.aNamaDosen,
            this.Hapus});
            this.dgvTimDosen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTimDosen.Location = new System.Drawing.Point(0, 316);
            this.dgvTimDosen.Name = "dgvTimDosen";
            this.dgvTimDosen.RowHeadersVisible = false;
            this.dgvTimDosen.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTimDosen.Size = new System.Drawing.Size(807, 129);
            this.dgvTimDosen.TabIndex = 19;
            // 
            // NamaTim
            // 
            this.NamaTim.HeaderText = "Nama Tim";
            this.NamaTim.Name = "NamaTim";
            this.NamaTim.Width = 150;
            // 
            // aNik
            // 
            this.aNik.HeaderText = "Nik";
            this.aNik.Name = "aNik";
            // 
            // aNamaDosen
            // 
            this.aNamaDosen.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.aNamaDosen.HeaderText = "Nama Dosen";
            this.aNamaDosen.Name = "aNamaDosen";
            // 
            // Hapus
            // 
            this.Hapus.HeaderText = "Hapus";
            this.Hapus.Name = "Hapus";
            this.Hapus.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Hapus.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Hapus.Width = 60;
            // 
            // comboBoxAdv1
            // 
            this.comboBoxAdv1.BeforeTouchSize = new System.Drawing.Size(341, 21);
            this.comboBoxAdv1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxAdv1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxAdv1.Location = new System.Drawing.Point(128, 71);
            this.comboBoxAdv1.Name = "comboBoxAdv1";
            this.comboBoxAdv1.Size = new System.Drawing.Size(341, 21);
            this.comboBoxAdv1.TabIndex = 13;
            // 
            // cmbProgram
            // 
            this.cmbProgram.BeforeTouchSize = new System.Drawing.Size(361, 24);
            this.cmbProgram.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProgram.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbProgram.Location = new System.Drawing.Point(108, 64);
            this.cmbProgram.Name = "cmbProgram";
            this.cmbProgram.Size = new System.Drawing.Size(361, 24);
            this.cmbProgram.TabIndex = 19;
            this.cmbProgram.SelectedIndexChanged += new System.EventHandler(this.cmbProgram_SelectedIndexChanged);
            // 
            // cmbProdi
            // 
            this.cmbProdi.BeforeTouchSize = new System.Drawing.Size(361, 24);
            this.cmbProdi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProdi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbProdi.Location = new System.Drawing.Point(108, 34);
            this.cmbProdi.Name = "cmbProdi";
            this.cmbProdi.Size = new System.Drawing.Size(361, 24);
            this.cmbProdi.TabIndex = 18;
            this.cmbProdi.SelectedIndexChanged += new System.EventHandler(this.cmbProdi_SelectedIndexChanged);
            // 
            // cmbFakultas
            // 
            this.cmbFakultas.BeforeTouchSize = new System.Drawing.Size(361, 25);
            this.cmbFakultas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFakultas.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbFakultas.Location = new System.Drawing.Point(108, 3);
            this.cmbFakultas.Name = "cmbFakultas";
            this.cmbFakultas.Size = new System.Drawing.Size(361, 25);
            this.cmbFakultas.TabIndex = 17;
            this.cmbFakultas.SelectedIndexChanged += new System.EventHandler(this.cmbFakultas_SelectedIndexChanged);
            // 
            // FormTimDosen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CaptionFont = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClientSize = new System.Drawing.Size(807, 483);
            this.Controls.Add(this.dgvTimDosen);
            this.Controls.Add(this.gradientPanel2);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FormTimDosen";
            this.Text = "Tim Dosen";
            this.Load += new System.EventHandler(this.FormTimDosen_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gradientPanel2)).EndInit();
            this.gradientPanel2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDosen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAddTim)).EndInit();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCari)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gradientPanel3)).EndInit();
            this.gradientPanel3.ResumeLayout(false);
            this.gradientPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtNamaGrup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gradientPanel1)).EndInit();
            this.gradientPanel1.ResumeLayout(false);
            this.gradientPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTimDosen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxAdv1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbProgram)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbProdi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbFakultas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private Syncfusion.Windows.Forms.ButtonAdv btnTutup;
        private Syncfusion.Windows.Forms.ButtonAdv btnHapus;
        private System.Windows.Forms.ProgressBar progressBar1;
        private Syncfusion.Windows.Forms.Tools.GradientPanel gradientPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView dgvDosen;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel4;
        private System.Windows.Forms.DataGridView dgvAddTim;
        private System.Windows.Forms.DataGridView dgvTimDosen;
        private System.Windows.Forms.DataGridViewTextBoxColumn tNIk;
        private System.Windows.Forms.DataGridViewTextBoxColumn tDosen;
        private System.Windows.Forms.DataGridViewTextBoxColumn NIk;
        private System.Windows.Forms.DataGridViewTextBoxColumn NamaDosen;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel2;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtCari;
        private Syncfusion.Windows.Forms.Tools.ComboBoxAdv comboBoxAdv1;
        private System.Windows.Forms.DataGridViewTextBoxColumn NamaTim;
        private System.Windows.Forms.DataGridViewTextBoxColumn aNik;
        private System.Windows.Forms.DataGridViewTextBoxColumn aNamaDosen;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Hapus;
        private Syncfusion.Windows.Forms.Tools.GradientPanel gradientPanel3;
        private Syncfusion.Windows.Forms.ButtonAdv btnClear;
        private Syncfusion.Windows.Forms.ButtonAdv btnSimpan;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtNamaGrup;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel1;
        private Syncfusion.Windows.Forms.Tools.GradientPanel gradientPanel1;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel3;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel15;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel5;
        private Syncfusion.Windows.Forms.Tools.ComboBoxAdv cmbProgram;
        private Syncfusion.Windows.Forms.Tools.ComboBoxAdv cmbProdi;
        private Syncfusion.Windows.Forms.Tools.ComboBoxAdv cmbFakultas;
    }
}