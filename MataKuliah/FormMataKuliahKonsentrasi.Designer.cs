#region Copyright Syncfusion Inc. 2001 - 2016
// Copyright Syncfusion Inc. 2001 - 2016. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
namespace MataKuliah
{
    partial class FormMataKuliahKonsentrasi
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
            this.cmbKonsentrasi = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            this.autoLabel15 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.cmbProdi = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            this.cmbFakultas = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            this.autoLabel1 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnTutup = new Syncfusion.Windows.Forms.ButtonAdv();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnCreateKonsenttrasi = new System.Windows.Forms.Button();
            this.splitContainerAdv1 = new Syncfusion.Windows.Forms.Tools.SplitContainerAdv();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvMataKuliah = new System.Windows.Forms.DataGridView();
            this.No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Kode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MataKuliah = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvMKKonsentrasi = new System.Windows.Forms.DataGridView();
            this.IdKonsentrasi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kKode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kMataKuliah = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TahunMulai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gradientPanel2)).BeginInit();
            this.gradientPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbKonsentrasi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbProdi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbFakultas)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerAdv1)).BeginInit();
            this.splitContainerAdv1.Panel1.SuspendLayout();
            this.splitContainerAdv1.Panel2.SuspendLayout();
            this.splitContainerAdv1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMataKuliah)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMKKonsentrasi)).BeginInit();
            this.SuspendLayout();
            // 
            // gradientPanel2
            // 
            this.gradientPanel2.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat;
            this.gradientPanel2.Controls.Add(this.autoLabel2);
            this.gradientPanel2.Controls.Add(this.cmbKonsentrasi);
            this.gradientPanel2.Controls.Add(this.autoLabel15);
            this.gradientPanel2.Controls.Add(this.cmbProdi);
            this.gradientPanel2.Controls.Add(this.cmbFakultas);
            this.gradientPanel2.Controls.Add(this.autoLabel1);
            this.gradientPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.gradientPanel2.Location = new System.Drawing.Point(0, 0);
            this.gradientPanel2.Name = "gradientPanel2";
            this.gradientPanel2.Size = new System.Drawing.Size(810, 107);
            this.gradientPanel2.TabIndex = 9;
            // 
            // autoLabel2
            // 
            this.autoLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.autoLabel2.Location = new System.Drawing.Point(0, 72);
            this.autoLabel2.Name = "autoLabel2";
            this.autoLabel2.Size = new System.Drawing.Size(78, 16);
            this.autoLabel2.TabIndex = 10;
            this.autoLabel2.Text = "Konsentrasi";
            // 
            // cmbKonsentrasi
            // 
            this.cmbKonsentrasi.BeforeTouchSize = new System.Drawing.Size(361, 24);
            this.cmbKonsentrasi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbKonsentrasi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbKonsentrasi.Location = new System.Drawing.Point(108, 70);
            this.cmbKonsentrasi.Name = "cmbKonsentrasi";
            this.cmbKonsentrasi.Size = new System.Drawing.Size(361, 24);
            this.cmbKonsentrasi.TabIndex = 9;
            this.cmbKonsentrasi.SelectedIndexChanged += new System.EventHandler(this.cmbKonsentrasi_SelectedIndexChanged);
            // 
            // autoLabel15
            // 
            this.autoLabel15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.autoLabel15.Location = new System.Drawing.Point(0, 43);
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
            this.cmbProdi.Location = new System.Drawing.Point(108, 41);
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
            this.cmbFakultas.Location = new System.Drawing.Point(108, 10);
            this.cmbFakultas.Name = "cmbFakultas";
            this.cmbFakultas.Size = new System.Drawing.Size(361, 25);
            this.cmbFakultas.TabIndex = 1;
            this.cmbFakultas.SelectedIndexChanged += new System.EventHandler(this.cmbFakultas_SelectedIndexChanged);
            // 
            // autoLabel1
            // 
            this.autoLabel1.Location = new System.Drawing.Point(1, 12);
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
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 422);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(810, 38);
            this.flowLayoutPanel1.TabIndex = 8;
            // 
            // btnTutup
            // 
            this.btnTutup.BeforeTouchSize = new System.Drawing.Size(113, 30);
            this.btnTutup.IsBackStageButton = false;
            this.btnTutup.Location = new System.Drawing.Point(694, 4);
            this.btnTutup.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnTutup.Name = "btnTutup";
            this.btnTutup.Size = new System.Drawing.Size(113, 30);
            this.btnTutup.TabIndex = 0;
            this.btnTutup.Text = "Tutup";
            this.btnTutup.Click += new System.EventHandler(this.btnTutup_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(474, 3);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(214, 30);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar1.TabIndex = 1;
            this.progressBar1.Visible = false;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.btnCreateKonsenttrasi);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(0, 107);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(810, 32);
            this.flowLayoutPanel2.TabIndex = 10;
            // 
            // btnCreateKonsenttrasi
            // 
            this.btnCreateKonsenttrasi.Location = new System.Drawing.Point(3, 3);
            this.btnCreateKonsenttrasi.Name = "btnCreateKonsenttrasi";
            this.btnCreateKonsenttrasi.Size = new System.Drawing.Size(151, 25);
            this.btnCreateKonsenttrasi.TabIndex = 0;
            this.btnCreateKonsenttrasi.Text = "Create Konsentrasi";
            this.btnCreateKonsenttrasi.UseVisualStyleBackColor = true;
            this.btnCreateKonsenttrasi.Click += new System.EventHandler(this.btnCreateKonsenttrasi_Click);
            // 
            // splitContainerAdv1
            // 
            this.splitContainerAdv1.BeforeTouchSize = 7;
            this.splitContainerAdv1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerAdv1.Location = new System.Drawing.Point(0, 139);
            this.splitContainerAdv1.Name = "splitContainerAdv1";
            // 
            // splitContainerAdv1.Panel1
            // 
            this.splitContainerAdv1.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainerAdv1.Panel2
            // 
            this.splitContainerAdv1.Panel2.Controls.Add(this.groupBox2);
            this.splitContainerAdv1.Size = new System.Drawing.Size(810, 283);
            this.splitContainerAdv1.SplitterDistance = 398;
            this.splitContainerAdv1.TabIndex = 11;
            this.splitContainerAdv1.Text = "splitContainerAdv1";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvMataKuliah);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(398, 283);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Mata Kuliah";
            // 
            // dgvMataKuliah
            // 
            this.dgvMataKuliah.AllowDrop = true;
            this.dgvMataKuliah.AllowUserToAddRows = false;
            this.dgvMataKuliah.AllowUserToDeleteRows = false;
            this.dgvMataKuliah.AllowUserToResizeRows = false;
            this.dgvMataKuliah.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgvMataKuliah.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMataKuliah.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.No,
            this.Kode,
            this.MataKuliah});
            this.dgvMataKuliah.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMataKuliah.Location = new System.Drawing.Point(3, 21);
            this.dgvMataKuliah.MultiSelect = false;
            this.dgvMataKuliah.Name = "dgvMataKuliah";
            this.dgvMataKuliah.ReadOnly = true;
            this.dgvMataKuliah.RowHeadersVisible = false;
            this.dgvMataKuliah.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMataKuliah.Size = new System.Drawing.Size(392, 259);
            this.dgvMataKuliah.TabIndex = 0;
            this.dgvMataKuliah.DragDrop += new System.Windows.Forms.DragEventHandler(this.dgvMataKuliah_DragDrop);
            this.dgvMataKuliah.DragEnter += new System.Windows.Forms.DragEventHandler(this.dgvMataKuliah_DragEnter);
            this.dgvMataKuliah.DragOver += new System.Windows.Forms.DragEventHandler(this.dgvMataKuliah_DragOver);
            this.dgvMataKuliah.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dgvMataKuliah_MouseDown);
            this.dgvMataKuliah.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dgvMataKuliah_MouseMove);
            // 
            // No
            // 
            this.No.HeaderText = "No";
            this.No.Name = "No";
            this.No.ReadOnly = true;
            this.No.Width = 50;
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
            this.MataKuliah.HeaderText = "Mata Kuliah";
            this.MataKuliah.Name = "MataKuliah";
            this.MataKuliah.ReadOnly = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvMKKonsentrasi);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(405, 283);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Mata Kuliah Kosentrasi";
            // 
            // dgvMKKonsentrasi
            // 
            this.dgvMKKonsentrasi.AllowDrop = true;
            this.dgvMKKonsentrasi.AllowUserToAddRows = false;
            this.dgvMKKonsentrasi.AllowUserToDeleteRows = false;
            this.dgvMKKonsentrasi.AllowUserToResizeRows = false;
            this.dgvMKKonsentrasi.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgvMKKonsentrasi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMKKonsentrasi.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdKonsentrasi,
            this.kKode,
            this.kMataKuliah,
            this.TahunMulai});
            this.dgvMKKonsentrasi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMKKonsentrasi.Location = new System.Drawing.Point(3, 21);
            this.dgvMKKonsentrasi.MultiSelect = false;
            this.dgvMKKonsentrasi.Name = "dgvMKKonsentrasi";
            this.dgvMKKonsentrasi.ReadOnly = true;
            this.dgvMKKonsentrasi.RowHeadersVisible = false;
            this.dgvMKKonsentrasi.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMKKonsentrasi.Size = new System.Drawing.Size(399, 259);
            this.dgvMKKonsentrasi.TabIndex = 1;
            this.dgvMKKonsentrasi.DragDrop += new System.Windows.Forms.DragEventHandler(this.dgvMKKonsentrasi_DragDrop);
            this.dgvMKKonsentrasi.DragEnter += new System.Windows.Forms.DragEventHandler(this.dgvMKKonsentrasi_DragEnter);
            this.dgvMKKonsentrasi.DragOver += new System.Windows.Forms.DragEventHandler(this.dgvMKKonsentrasi_DragOver);
            this.dgvMKKonsentrasi.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dgvMKKonsentrasi_MouseDown);
            this.dgvMKKonsentrasi.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dgvMKKonsentrasi_MouseMove);
            // 
            // IdKonsentrasi
            // 
            this.IdKonsentrasi.HeaderText = "IdKonsentrasi";
            this.IdKonsentrasi.Name = "IdKonsentrasi";
            this.IdKonsentrasi.ReadOnly = true;
            // 
            // kKode
            // 
            this.kKode.HeaderText = "Kode";
            this.kKode.Name = "kKode";
            this.kKode.ReadOnly = true;
            this.kKode.Width = 70;
            // 
            // kMataKuliah
            // 
            this.kMataKuliah.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.kMataKuliah.HeaderText = "Mata Kuliah";
            this.kMataKuliah.Name = "kMataKuliah";
            this.kMataKuliah.ReadOnly = true;
            // 
            // TahunMulai
            // 
            this.TahunMulai.HeaderText = "Tahun Berlaku";
            this.TahunMulai.Name = "TahunMulai";
            this.TahunMulai.ReadOnly = true;
            this.TahunMulai.Width = 60;
            // 
            // FormMataKuliahKonsentrasi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CaptionFont = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClientSize = new System.Drawing.Size(810, 460);
            this.Controls.Add(this.splitContainerAdv1);
            this.Controls.Add(this.flowLayoutPanel2);
            this.Controls.Add(this.gradientPanel2);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FormMataKuliahKonsentrasi";
            this.Text = "Mata Kuliah Konsentrasi";
            this.Load += new System.EventHandler(this.FormMataKuliahKonsentrasi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gradientPanel2)).EndInit();
            this.gradientPanel2.ResumeLayout(false);
            this.gradientPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbKonsentrasi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbProdi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbFakultas)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.splitContainerAdv1.Panel1.ResumeLayout(false);
            this.splitContainerAdv1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerAdv1)).EndInit();
            this.splitContainerAdv1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMataKuliah)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMKKonsentrasi)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Syncfusion.Windows.Forms.Tools.GradientPanel gradientPanel2;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel15;
        private Syncfusion.Windows.Forms.Tools.ComboBoxAdv cmbProdi;
        private Syncfusion.Windows.Forms.Tools.ComboBoxAdv cmbFakultas;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private Syncfusion.Windows.Forms.ButtonAdv btnTutup;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Button btnCreateKonsenttrasi;
        private Syncfusion.Windows.Forms.Tools.SplitContainerAdv splitContainerAdv1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvMataKuliah;
        private System.Windows.Forms.DataGridViewTextBoxColumn No;
        private System.Windows.Forms.DataGridViewTextBoxColumn Kode;
        private System.Windows.Forms.DataGridViewTextBoxColumn MataKuliah;
        private System.Windows.Forms.DataGridView dgvMKKonsentrasi;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel2;
        private Syncfusion.Windows.Forms.Tools.ComboBoxAdv cmbKonsentrasi;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdKonsentrasi;
        private System.Windows.Forms.DataGridViewTextBoxColumn kKode;
        private System.Windows.Forms.DataGridViewTextBoxColumn kMataKuliah;
        private System.Windows.Forms.DataGridViewTextBoxColumn TahunMulai;
    }
}