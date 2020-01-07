#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
namespace PenawaranKurikulum.Dialog
{
    partial class DialogSetKurikulumPerAngkatan
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmbJenisMk = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbAngkatan = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNamaProgramProdi = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnTutup = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnSimpan = new System.Windows.Forms.Button();
            this.dgvMataKuliah = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnPilihSemua = new System.Windows.Forms.Button();
            this.No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pilih = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Kode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MataKuliah = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SifatMk = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NilaiMinimal = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.panel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMataKuliah)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cmbJenisMk);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.cmbAngkatan);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtNamaProgramProdi);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(908, 108);
            this.panel1.TabIndex = 0;
            // 
            // cmbJenisMk
            // 
            this.cmbJenisMk.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbJenisMk.FormattingEnabled = true;
            this.cmbJenisMk.Items.AddRange(new object[] {
            "Pilih",
            "Penawaran Mata Kuliah",
            "Semua Mata Kuliah"});
            this.cmbJenisMk.Location = new System.Drawing.Point(122, 43);
            this.cmbJenisMk.Name = "cmbJenisMk";
            this.cmbJenisMk.Size = new System.Drawing.Size(213, 25);
            this.cmbJenisMk.TabIndex = 5;
            this.cmbJenisMk.SelectedIndexChanged += new System.EventHandler(this.cmbJenisMk_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "MK Berdasarkan";
            // 
            // cmbAngkatan
            // 
            this.cmbAngkatan.DropDownHeight = 150;
            this.cmbAngkatan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAngkatan.FormattingEnabled = true;
            this.cmbAngkatan.IntegralHeight = false;
            this.cmbAngkatan.Location = new System.Drawing.Point(122, 74);
            this.cmbAngkatan.Name = "cmbAngkatan";
            this.cmbAngkatan.Size = new System.Drawing.Size(131, 25);
            this.cmbAngkatan.TabIndex = 3;
            this.cmbAngkatan.SelectedIndexChanged += new System.EventHandler(this.cmbAngkatan_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Angkatan";
            // 
            // txtNamaProgramProdi
            // 
            this.txtNamaProgramProdi.Location = new System.Drawing.Point(122, 12);
            this.txtNamaProgramProdi.Name = "txtNamaProgramProdi";
            this.txtNamaProgramProdi.ReadOnly = true;
            this.txtNamaProgramProdi.Size = new System.Drawing.Size(600, 25);
            this.txtNamaProgramProdi.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Prodi/Program";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanel1.Controls.Add(this.btnTutup);
            this.flowLayoutPanel1.Controls.Add(this.progressBar1);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 504);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(908, 38);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // btnTutup
            // 
            this.btnTutup.Location = new System.Drawing.Point(806, 3);
            this.btnTutup.Name = "btnTutup";
            this.btnTutup.Size = new System.Drawing.Size(97, 28);
            this.btnTutup.TabIndex = 0;
            this.btnTutup.Text = "Tutup";
            this.btnTutup.UseVisualStyleBackColor = true;
            this.btnTutup.Click += new System.EventHandler(this.btnTutup_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(586, 3);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(214, 28);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar1.TabIndex = 2;
            this.progressBar1.Visible = false;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.btnSimpan);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(0, 468);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(908, 36);
            this.flowLayoutPanel2.TabIndex = 3;
            // 
            // btnSimpan
            // 
            this.btnSimpan.Location = new System.Drawing.Point(3, 3);
            this.btnSimpan.Name = "btnSimpan";
            this.btnSimpan.Size = new System.Drawing.Size(97, 28);
            this.btnSimpan.TabIndex = 1;
            this.btnSimpan.Text = "Simpan";
            this.btnSimpan.UseVisualStyleBackColor = true;
            this.btnSimpan.Click += new System.EventHandler(this.btnSimpan_Click);
            // 
            // dgvMataKuliah
            // 
            this.dgvMataKuliah.AllowUserToAddRows = false;
            this.dgvMataKuliah.AllowUserToDeleteRows = false;
            this.dgvMataKuliah.AllowUserToResizeRows = false;
            this.dgvMataKuliah.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvMataKuliah.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgvMataKuliah.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMataKuliah.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.No,
            this.Pilih,
            this.Kode,
            this.MataKuliah,
            this.Sks,
            this.SifatMk,
            this.NilaiMinimal});
            this.dgvMataKuliah.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMataKuliah.Location = new System.Drawing.Point(3, 60);
            this.dgvMataKuliah.Name = "dgvMataKuliah";
            this.dgvMataKuliah.RowHeadersVisible = false;
            this.dgvMataKuliah.Size = new System.Drawing.Size(902, 297);
            this.dgvMataKuliah.TabIndex = 4;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvMataKuliah);
            this.groupBox1.Controls.Add(this.flowLayoutPanel3);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 108);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(908, 360);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Data Mata Kuliah";
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Controls.Add(this.btnPilihSemua);
            this.flowLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel3.Location = new System.Drawing.Point(3, 21);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(902, 39);
            this.flowLayoutPanel3.TabIndex = 5;
            // 
            // btnPilihSemua
            // 
            this.btnPilihSemua.Location = new System.Drawing.Point(3, 3);
            this.btnPilihSemua.Name = "btnPilihSemua";
            this.btnPilihSemua.Size = new System.Drawing.Size(97, 28);
            this.btnPilihSemua.TabIndex = 6;
            this.btnPilihSemua.Text = "Pilih Semua";
            this.btnPilihSemua.UseVisualStyleBackColor = true;
            this.btnPilihSemua.Click += new System.EventHandler(this.btnPilihSemua_Click);
            // 
            // No
            // 
            this.No.HeaderText = "No";
            this.No.Name = "No";
            this.No.Width = 51;
            // 
            // Pilih
            // 
            this.Pilih.HeaderText = "Pilih";
            this.Pilih.Name = "Pilih";
            this.Pilih.Width = 37;
            // 
            // Kode
            // 
            this.Kode.HeaderText = "Kode";
            this.Kode.Name = "Kode";
            this.Kode.Width = 64;
            // 
            // MataKuliah
            // 
            this.MataKuliah.HeaderText = "Mata Kuliah";
            this.MataKuliah.Name = "MataKuliah";
            this.MataKuliah.Width = 102;
            // 
            // Sks
            // 
            this.Sks.HeaderText = "Sks";
            this.Sks.Name = "Sks";
            this.Sks.Width = 52;
            // 
            // SifatMk
            // 
            this.SifatMk.HeaderText = "Sifat MK";
            this.SifatMk.Name = "SifatMk";
            this.SifatMk.Width = 82;
            // 
            // NilaiMinimal
            // 
            this.NilaiMinimal.HeaderText = "Nilai Minimal";
            this.NilaiMinimal.Items.AddRange(new object[] {
            "Pilih",
            "A",
            "B",
            "C",
            "D",
            "E"});
            this.NilaiMinimal.Name = "NilaiMinimal";
            this.NilaiMinimal.Visible = false;
            this.NilaiMinimal.Width = 90;
            // 
            // DialogSetKurikulumPerAngkatan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CaptionFont = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClientSize = new System.Drawing.Size(908, 542);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.flowLayoutPanel2);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DialogSetKurikulumPerAngkatan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Set Kurikulum Per Angkatan";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DialogSetKurikulumPerAngkatan_FormClosing);
            this.Load += new System.EventHandler(this.DialogSetKurikulumPerAngkatan_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMataKuliah)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.flowLayoutPanel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbAngkatan;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNamaProgramProdi;
        private System.Windows.Forms.ComboBox cmbJenisMk;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnTutup;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.DataGridView dgvMataKuliah;
        private System.Windows.Forms.Button btnSimpan;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.Button btnPilihSemua;
        private System.Windows.Forms.DataGridViewTextBoxColumn No;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Pilih;
        private System.Windows.Forms.DataGridViewTextBoxColumn Kode;
        private System.Windows.Forms.DataGridViewTextBoxColumn MataKuliah;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sks;
        private System.Windows.Forms.DataGridViewTextBoxColumn SifatMk;
        private System.Windows.Forms.DataGridViewComboBoxColumn NilaiMinimal;
    }
}