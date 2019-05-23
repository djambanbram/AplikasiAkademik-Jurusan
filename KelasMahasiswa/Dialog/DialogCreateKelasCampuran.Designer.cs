#region Copyright Syncfusion Inc. 2001 - 2016
// Copyright Syncfusion Inc. 2001 - 2016. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
namespace KelasMahasiswa.Dialog
{
    partial class DialogCreateKelasCampuran
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
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.autoLabel1 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.txtCari = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            this.splitContainerAdv1 = new Syncfusion.Windows.Forms.Tools.SplitContainerAdv();
            this.dgvMKCampuran = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.txtMataKuliah = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            this.txtKode = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            this.autoLabel6 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.autoLabel3 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.autoLabel4 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.autoLabel2 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.numJumlahKelas = new System.Windows.Forms.NumericUpDown();
            this.btnCreate = new Syncfusion.Windows.Forms.ButtonAdv();
            this.numKuota = new System.Windows.Forms.NumericUpDown();
            this.autoLabel5 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.lblSemesterKelas = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.txtNamaKelas = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            this.txtKodeKelas = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            this.No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Kode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MataKuliah = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Jumlah = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SingkatanKelas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SemesterKelas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Jenis = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCari)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerAdv1)).BeginInit();
            this.splitContainerAdv1.Panel1.SuspendLayout();
            this.splitContainerAdv1.Panel2.SuspendLayout();
            this.splitContainerAdv1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMKCampuran)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMataKuliah)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numJumlahKelas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numKuota)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNamaKelas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKodeKelas)).BeginInit();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnTutup);
            this.flowLayoutPanel1.Controls.Add(this.progressBar1);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 358);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(903, 38);
            this.flowLayoutPanel1.TabIndex = 12;
            // 
            // btnTutup
            // 
            this.btnTutup.BeforeTouchSize = new System.Drawing.Size(113, 30);
            this.btnTutup.IsBackStageButton = false;
            this.btnTutup.Location = new System.Drawing.Point(787, 4);
            this.btnTutup.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnTutup.Name = "btnTutup";
            this.btnTutup.Size = new System.Drawing.Size(113, 30);
            this.btnTutup.TabIndex = 0;
            this.btnTutup.Text = "Tutup";
            this.btnTutup.Click += new System.EventHandler(this.btnTutup_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(567, 3);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(214, 30);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar1.TabIndex = 2;
            this.progressBar1.Visible = false;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.autoLabel1);
            this.flowLayoutPanel2.Controls.Add(this.txtCari);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(431, 31);
            this.flowLayoutPanel2.TabIndex = 13;
            // 
            // autoLabel1
            // 
            this.autoLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.autoLabel1.Location = new System.Drawing.Point(3, 0);
            this.autoLabel1.Name = "autoLabel1";
            this.autoLabel1.Size = new System.Drawing.Size(119, 31);
            this.autoLabel1.TabIndex = 0;
            this.autoLabel1.Text = "Cari MK Campuran";
            this.autoLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtCari
            // 
            this.txtCari.BeforeTouchSize = new System.Drawing.Size(59, 25);
            this.txtCari.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtCari.Location = new System.Drawing.Point(128, 3);
            this.txtCari.Metrocolor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.txtCari.Name = "txtCari";
            this.txtCari.Size = new System.Drawing.Size(232, 25);
            this.txtCari.TabIndex = 1;
            this.txtCari.TextChanged += new System.EventHandler(this.txtCari_TextChanged);
            // 
            // splitContainerAdv1
            // 
            this.splitContainerAdv1.BeforeTouchSize = 7;
            this.splitContainerAdv1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainerAdv1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerAdv1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerAdv1.Name = "splitContainerAdv1";
            // 
            // splitContainerAdv1.Panel1
            // 
            this.splitContainerAdv1.Panel1.Controls.Add(this.dgvMKCampuran);
            this.splitContainerAdv1.Panel1.Controls.Add(this.flowLayoutPanel2);
            // 
            // splitContainerAdv1.Panel2
            // 
            this.splitContainerAdv1.Panel2.Controls.Add(this.tableLayoutPanel1);
            this.splitContainerAdv1.Size = new System.Drawing.Size(903, 358);
            this.splitContainerAdv1.SplitterDistance = 433;
            this.splitContainerAdv1.TabIndex = 14;
            this.splitContainerAdv1.Text = "splitContainerAdv1";
            // 
            // dgvMKCampuran
            // 
            this.dgvMKCampuran.AllowUserToAddRows = false;
            this.dgvMKCampuran.AllowUserToDeleteRows = false;
            this.dgvMKCampuran.AllowUserToResizeRows = false;
            this.dgvMKCampuran.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgvMKCampuran.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMKCampuran.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.No,
            this.Kode,
            this.MataKuliah,
            this.Jumlah,
            this.SingkatanKelas,
            this.SemesterKelas,
            this.Jenis});
            this.dgvMKCampuran.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMKCampuran.Location = new System.Drawing.Point(0, 31);
            this.dgvMKCampuran.MultiSelect = false;
            this.dgvMKCampuran.Name = "dgvMKCampuran";
            this.dgvMKCampuran.ReadOnly = true;
            this.dgvMKCampuran.RowHeadersVisible = false;
            this.dgvMKCampuran.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMKCampuran.Size = new System.Drawing.Size(431, 325);
            this.dgvMKCampuran.TabIndex = 14;
            this.dgvMKCampuran.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMKCampuran_CellClick);
            this.dgvMKCampuran.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dgvMKCampuran_KeyUp);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 105F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 65F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 291F));
            this.tableLayoutPanel1.Controls.Add(this.txtMataKuliah, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtKode, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.autoLabel6, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.autoLabel3, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.autoLabel4, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.autoLabel2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.numJumlahKelas, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.btnCreate, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.numKuota, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.autoLabel5, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblSemesterKelas, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.txtNamaKelas, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtKodeKelas, 0, 6);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(461, 356);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // txtMataKuliah
            // 
            this.txtMataKuliah.BeforeTouchSize = new System.Drawing.Size(350, 25);
            this.tableLayoutPanel1.SetColumnSpan(this.txtMataKuliah, 2);
            this.txtMataKuliah.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtMataKuliah.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMataKuliah.Enabled = false;
            this.txtMataKuliah.Location = new System.Drawing.Point(108, 33);
            this.txtMataKuliah.Metrocolor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.txtMataKuliah.Name = "txtMataKuliah";
            this.txtMataKuliah.Size = new System.Drawing.Size(350, 25);
            this.txtMataKuliah.TabIndex = 11;
            // 
            // txtKode
            // 
            this.txtKode.BeforeTouchSize = new System.Drawing.Size(350, 25);
            this.tableLayoutPanel1.SetColumnSpan(this.txtKode, 2);
            this.txtKode.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtKode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtKode.Enabled = false;
            this.txtKode.Location = new System.Drawing.Point(108, 3);
            this.txtKode.Metrocolor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.txtKode.Name = "txtKode";
            this.txtKode.Size = new System.Drawing.Size(350, 25);
            this.txtKode.TabIndex = 10;
            // 
            // autoLabel6
            // 
            this.autoLabel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.autoLabel6.Location = new System.Drawing.Point(3, 0);
            this.autoLabel6.Name = "autoLabel6";
            this.autoLabel6.Size = new System.Drawing.Size(99, 30);
            this.autoLabel6.TabIndex = 9;
            this.autoLabel6.Text = "Kode";
            this.autoLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // autoLabel3
            // 
            this.autoLabel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.autoLabel3.Location = new System.Drawing.Point(3, 120);
            this.autoLabel3.Name = "autoLabel3";
            this.autoLabel3.Size = new System.Drawing.Size(99, 30);
            this.autoLabel3.TabIndex = 6;
            this.autoLabel3.Text = "Kuota";
            this.autoLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // autoLabel4
            // 
            this.autoLabel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.autoLabel4.Location = new System.Drawing.Point(3, 90);
            this.autoLabel4.Name = "autoLabel4";
            this.autoLabel4.Size = new System.Drawing.Size(99, 30);
            this.autoLabel4.TabIndex = 2;
            this.autoLabel4.Text = "Jumlah Kelas";
            this.autoLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // autoLabel2
            // 
            this.autoLabel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.autoLabel2.Location = new System.Drawing.Point(3, 60);
            this.autoLabel2.Name = "autoLabel2";
            this.autoLabel2.Size = new System.Drawing.Size(99, 30);
            this.autoLabel2.TabIndex = 0;
            this.autoLabel2.Text = "Nama Kelas";
            this.autoLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numJumlahKelas
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.numJumlahKelas, 2);
            this.numJumlahKelas.Location = new System.Drawing.Point(108, 93);
            this.numJumlahKelas.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numJumlahKelas.Name = "numJumlahKelas";
            this.numJumlahKelas.Size = new System.Drawing.Size(120, 25);
            this.numJumlahKelas.TabIndex = 4;
            this.numJumlahKelas.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnCreate
            // 
            this.btnCreate.BeforeTouchSize = new System.Drawing.Size(59, 29);
            this.btnCreate.IsBackStageButton = false;
            this.btnCreate.Location = new System.Drawing.Point(108, 153);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(59, 29);
            this.btnCreate.TabIndex = 5;
            this.btnCreate.Text = "Create";
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // numKuota
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.numKuota, 2);
            this.numKuota.Location = new System.Drawing.Point(108, 123);
            this.numKuota.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numKuota.Name = "numKuota";
            this.numKuota.Size = new System.Drawing.Size(120, 25);
            this.numKuota.TabIndex = 7;
            this.numKuota.Value = new decimal(new int[] {
            65,
            0,
            0,
            0});
            // 
            // autoLabel5
            // 
            this.autoLabel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.autoLabel5.Location = new System.Drawing.Point(3, 30);
            this.autoLabel5.Name = "autoLabel5";
            this.autoLabel5.Size = new System.Drawing.Size(99, 30);
            this.autoLabel5.TabIndex = 8;
            this.autoLabel5.Text = "Mata Kuliah";
            this.autoLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSemesterKelas
            // 
            this.lblSemesterKelas.Location = new System.Drawing.Point(3, 150);
            this.lblSemesterKelas.Name = "lblSemesterKelas";
            this.lblSemesterKelas.Size = new System.Drawing.Size(72, 17);
            this.lblSemesterKelas.TabIndex = 12;
            this.lblSemesterKelas.Text = "autoLabel7";
            this.lblSemesterKelas.Visible = false;
            // 
            // txtNamaKelas
            // 
            this.txtNamaKelas.BeforeTouchSize = new System.Drawing.Size(350, 25);
            this.tableLayoutPanel1.SetColumnSpan(this.txtNamaKelas, 2);
            this.txtNamaKelas.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtNamaKelas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtNamaKelas.Location = new System.Drawing.Point(108, 63);
            this.txtNamaKelas.Metrocolor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.txtNamaKelas.Name = "txtNamaKelas";
            this.txtNamaKelas.Size = new System.Drawing.Size(350, 25);
            this.txtNamaKelas.TabIndex = 3;
            // 
            // txtKodeKelas
            // 
            this.txtKodeKelas.BeforeTouchSize = new System.Drawing.Size(350, 25);
            this.txtKodeKelas.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtKodeKelas.Location = new System.Drawing.Point(3, 188);
            this.txtKodeKelas.Metrocolor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.txtKodeKelas.Name = "txtKodeKelas";
            this.txtKodeKelas.ReadOnly = true;
            this.txtKodeKelas.Size = new System.Drawing.Size(59, 25);
            this.txtKodeKelas.TabIndex = 13;
            this.txtKodeKelas.Visible = false;
            // 
            // No
            // 
            this.No.HeaderText = "No";
            this.No.Name = "No";
            this.No.ReadOnly = true;
            this.No.Width = 60;
            // 
            // Kode
            // 
            this.Kode.HeaderText = "Kode";
            this.Kode.Name = "Kode";
            this.Kode.ReadOnly = true;
            this.Kode.Width = 80;
            // 
            // MataKuliah
            // 
            this.MataKuliah.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.MataKuliah.HeaderText = "Mata Kuliah";
            this.MataKuliah.Name = "MataKuliah";
            this.MataKuliah.ReadOnly = true;
            // 
            // Jumlah
            // 
            this.Jumlah.HeaderText = "Jumlah";
            this.Jumlah.Name = "Jumlah";
            this.Jumlah.ReadOnly = true;
            this.Jumlah.Visible = false;
            this.Jumlah.Width = 70;
            // 
            // SingkatanKelas
            // 
            this.SingkatanKelas.HeaderText = "Singkatan Kelas";
            this.SingkatanKelas.Name = "SingkatanKelas";
            this.SingkatanKelas.ReadOnly = true;
            this.SingkatanKelas.Visible = false;
            // 
            // SemesterKelas
            // 
            this.SemesterKelas.HeaderText = "SemesterKelas";
            this.SemesterKelas.Name = "SemesterKelas";
            this.SemesterKelas.ReadOnly = true;
            this.SemesterKelas.Visible = false;
            this.SemesterKelas.Width = 40;
            // 
            // Jenis
            // 
            this.Jenis.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Jenis.HeaderText = "Jenis";
            this.Jenis.Name = "Jenis";
            this.Jenis.ReadOnly = true;
            this.Jenis.Width = 61;
            // 
            // DialogCreateKelasCampuran
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CaptionFont = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClientSize = new System.Drawing.Size(903, 396);
            this.Controls.Add(this.splitContainerAdv1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DialogCreateKelasCampuran";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Create Kelas Campuran";
            this.Load += new System.EventHandler(this.DialogCreateKelasCampuran_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCari)).EndInit();
            this.splitContainerAdv1.Panel1.ResumeLayout(false);
            this.splitContainerAdv1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerAdv1)).EndInit();
            this.splitContainerAdv1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMKCampuran)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMataKuliah)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numJumlahKelas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numKuota)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNamaKelas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKodeKelas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private Syncfusion.Windows.Forms.ButtonAdv btnTutup;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel1;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtCari;
        private Syncfusion.Windows.Forms.Tools.SplitContainerAdv splitContainerAdv1;
        private System.Windows.Forms.DataGridView dgvMKCampuran;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel4;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel2;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtNamaKelas;
        private System.Windows.Forms.NumericUpDown numJumlahKelas;
        private Syncfusion.Windows.Forms.ButtonAdv btnCreate;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel3;
        private System.Windows.Forms.NumericUpDown numKuota;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtMataKuliah;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtKode;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel6;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel5;
        private System.Windows.Forms.ProgressBar progressBar1;
        private Syncfusion.Windows.Forms.Tools.AutoLabel lblSemesterKelas;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtKodeKelas;
        private System.Windows.Forms.DataGridViewTextBoxColumn No;
        private System.Windows.Forms.DataGridViewTextBoxColumn Kode;
        private System.Windows.Forms.DataGridViewTextBoxColumn MataKuliah;
        private System.Windows.Forms.DataGridViewTextBoxColumn Jumlah;
        private System.Windows.Forms.DataGridViewTextBoxColumn SingkatanKelas;
        private System.Windows.Forms.DataGridViewTextBoxColumn SemesterKelas;
        private System.Windows.Forms.DataGridViewTextBoxColumn Jenis;
    }
}