#region Copyright Syncfusion Inc. 2001 - 2016
// Copyright Syncfusion Inc. 2001 - 2016. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
namespace Dosen.Dialog
{
    partial class FormTambahJenjangPendidikan
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
            this.gradientPanel1 = new Syncfusion.Windows.Forms.Tools.GradientPanel();
            this.dgvKaryawan = new System.Windows.Forms.DataGridView();
            this.No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nik = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nama = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCari = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnTutup = new System.Windows.Forms.Button();
            this.btnSimpan = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.cmbJenjang = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            this.cmbProdi = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtNIK = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            this.txtNama = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            this.txtNoIjazah = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            this.dateMulai = new System.Windows.Forms.DateTimePicker();
            this.dateLulus = new System.Windows.Forms.DateTimePicker();
            this.cmbUniv = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            ((System.ComponentModel.ISupportInitialize)(this.gradientPanel1)).BeginInit();
            this.gradientPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKaryawan)).BeginInit();
            this.flowLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCari)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbJenjang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbProdi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNIK)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNama)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNoIjazah)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbUniv)).BeginInit();
            this.SuspendLayout();
            // 
            // gradientPanel1
            // 
            this.gradientPanel1.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat;
            this.gradientPanel1.Controls.Add(this.dgvKaryawan);
            this.gradientPanel1.Controls.Add(this.flowLayoutPanel2);
            this.gradientPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.gradientPanel1.Location = new System.Drawing.Point(0, 0);
            this.gradientPanel1.Name = "gradientPanel1";
            this.gradientPanel1.Size = new System.Drawing.Size(517, 131);
            this.gradientPanel1.TabIndex = 0;
            // 
            // dgvKaryawan
            // 
            this.dgvKaryawan.AllowUserToAddRows = false;
            this.dgvKaryawan.AllowUserToDeleteRows = false;
            this.dgvKaryawan.AllowUserToResizeRows = false;
            this.dgvKaryawan.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgvKaryawan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKaryawan.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.No,
            this.Nik,
            this.Nama});
            this.dgvKaryawan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvKaryawan.Location = new System.Drawing.Point(0, 32);
            this.dgvKaryawan.Name = "dgvKaryawan";
            this.dgvKaryawan.ReadOnly = true;
            this.dgvKaryawan.RowHeadersVisible = false;
            this.dgvKaryawan.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvKaryawan.Size = new System.Drawing.Size(513, 95);
            this.dgvKaryawan.TabIndex = 1;
            this.dgvKaryawan.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvKaryawan_CellClick);
            this.dgvKaryawan.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dgvKaryawan_KeyUp);
            // 
            // No
            // 
            this.No.HeaderText = "No";
            this.No.Name = "No";
            this.No.ReadOnly = true;
            this.No.Width = 45;
            // 
            // Nik
            // 
            this.Nik.HeaderText = "Nik";
            this.Nik.Name = "Nik";
            this.Nik.ReadOnly = true;
            // 
            // Nama
            // 
            this.Nama.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Nama.HeaderText = "Nama";
            this.Nama.Name = "Nama";
            this.Nama.ReadOnly = true;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.label1);
            this.flowLayoutPanel2.Controls.Add(this.txtCari);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(513, 32);
            this.flowLayoutPanel2.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cari";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtCari
            // 
            this.txtCari.BeforeTouchSize = new System.Drawing.Size(236, 25);
            this.txtCari.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtCari.Location = new System.Drawing.Point(40, 3);
            this.txtCari.Metrocolor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.txtCari.Name = "txtCari";
            this.txtCari.Size = new System.Drawing.Size(236, 25);
            this.txtCari.TabIndex = 1;
            this.txtCari.TextChanged += new System.EventHandler(this.txtCari_TextChanged);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnTutup);
            this.flowLayoutPanel1.Controls.Add(this.btnSimpan);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 388);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(517, 35);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // btnTutup
            // 
            this.btnTutup.Location = new System.Drawing.Point(412, 3);
            this.btnTutup.Name = "btnTutup";
            this.btnTutup.Size = new System.Drawing.Size(102, 28);
            this.btnTutup.TabIndex = 0;
            this.btnTutup.Text = "Tutup";
            this.btnTutup.UseVisualStyleBackColor = true;
            this.btnTutup.Click += new System.EventHandler(this.btnTutup_Click);
            // 
            // btnSimpan
            // 
            this.btnSimpan.Location = new System.Drawing.Point(304, 3);
            this.btnSimpan.Name = "btnSimpan";
            this.btnSimpan.Size = new System.Drawing.Size(102, 28);
            this.btnSimpan.TabIndex = 1;
            this.btnSimpan.Text = "Simpan";
            this.btnSimpan.UseVisualStyleBackColor = true;
            this.btnSimpan.Click += new System.EventHandler(this.btnSimpan_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 124F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.cmbJenjang, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.cmbProdi, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label9, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.label8, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label6, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.label7, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.txtNIK, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtNama, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtNoIjazah, 1, 7);
            this.tableLayoutPanel1.Controls.Add(this.dateMulai, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.dateLulus, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.cmbUniv, 1, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 131);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 8;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(517, 257);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // cmbJenjang
            // 
            this.cmbJenjang.BeforeTouchSize = new System.Drawing.Size(200, 25);
            this.cmbJenjang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbJenjang.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbJenjang.Location = new System.Drawing.Point(127, 131);
            this.cmbJenjang.Name = "cmbJenjang";
            this.cmbJenjang.Size = new System.Drawing.Size(200, 25);
            this.cmbJenjang.TabIndex = 18;
            // 
            // cmbProdi
            // 
            this.cmbProdi.BeforeTouchSize = new System.Drawing.Size(296, 25);
            this.cmbProdi.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbProdi.Location = new System.Drawing.Point(127, 99);
            this.cmbProdi.Name = "cmbProdi";
            this.cmbProdi.Size = new System.Drawing.Size(296, 25);
            this.cmbProdi.TabIndex = 17;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 224);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(66, 17);
            this.label9.TabIndex = 8;
            this.label9.Text = "No. Ijazah";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 192);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(61, 17);
            this.label8.TabIndex = 7;
            this.label8.Text = "Tgl. Lulus";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 96);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 17);
            this.label5.TabIndex = 4;
            this.label5.Text = "Program Studi";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "NIK";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Nama";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "Universitas";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 128);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 17);
            this.label6.TabIndex = 5;
            this.label6.Text = "Jenjang";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 160);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 17);
            this.label7.TabIndex = 6;
            this.label7.Text = "Tgl. Mulai";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtNIK
            // 
            this.txtNIK.BeforeTouchSize = new System.Drawing.Size(236, 25);
            this.txtNIK.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtNIK.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtNIK.Location = new System.Drawing.Point(127, 3);
            this.txtNIK.Metrocolor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.txtNIK.Name = "txtNIK";
            this.txtNIK.ReadOnly = true;
            this.txtNIK.Size = new System.Drawing.Size(387, 25);
            this.txtNIK.TabIndex = 9;
            // 
            // txtNama
            // 
            this.txtNama.BeforeTouchSize = new System.Drawing.Size(236, 25);
            this.txtNama.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtNama.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtNama.Location = new System.Drawing.Point(127, 35);
            this.txtNama.Metrocolor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.txtNama.Name = "txtNama";
            this.txtNama.ReadOnly = true;
            this.txtNama.Size = new System.Drawing.Size(387, 25);
            this.txtNama.TabIndex = 10;
            // 
            // txtNoIjazah
            // 
            this.txtNoIjazah.BeforeTouchSize = new System.Drawing.Size(236, 25);
            this.txtNoIjazah.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtNoIjazah.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtNoIjazah.Location = new System.Drawing.Point(127, 227);
            this.txtNoIjazah.Metrocolor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.txtNoIjazah.Name = "txtNoIjazah";
            this.txtNoIjazah.Size = new System.Drawing.Size(387, 25);
            this.txtNoIjazah.TabIndex = 13;
            // 
            // dateMulai
            // 
            this.dateMulai.Location = new System.Drawing.Point(127, 163);
            this.dateMulai.Name = "dateMulai";
            this.dateMulai.Size = new System.Drawing.Size(200, 25);
            this.dateMulai.TabIndex = 14;
            // 
            // dateLulus
            // 
            this.dateLulus.Location = new System.Drawing.Point(127, 195);
            this.dateLulus.Name = "dateLulus";
            this.dateLulus.Size = new System.Drawing.Size(200, 25);
            this.dateLulus.TabIndex = 15;
            // 
            // cmbUniv
            // 
            this.cmbUniv.BeforeTouchSize = new System.Drawing.Size(296, 25);
            this.cmbUniv.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbUniv.Location = new System.Drawing.Point(127, 67);
            this.cmbUniv.Name = "cmbUniv";
            this.cmbUniv.Size = new System.Drawing.Size(296, 25);
            this.cmbUniv.TabIndex = 16;
            // 
            // FormTambahJenjangPendidikan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CaptionFont = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClientSize = new System.Drawing.Size(517, 423);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.gradientPanel1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormTambahJenjangPendidikan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Tambah Jenjang Pendidikan";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormTambahJenjangPendidikan_FormClosed);
            this.Load += new System.EventHandler(this.FormTambahJenjangPendidikan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gradientPanel1)).EndInit();
            this.gradientPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvKaryawan)).EndInit();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCari)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbJenjang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbProdi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNIK)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNama)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNoIjazah)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbUniv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Syncfusion.Windows.Forms.Tools.GradientPanel gradientPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnTutup;
        private System.Windows.Forms.Button btnSimpan;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView dgvKaryawan;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Label label1;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtCari;
        private System.Windows.Forms.DataGridViewTextBoxColumn No;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nik;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nama;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtNIK;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtNama;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtNoIjazah;
        private System.Windows.Forms.DateTimePicker dateMulai;
        private System.Windows.Forms.DateTimePicker dateLulus;
        private Syncfusion.Windows.Forms.Tools.ComboBoxAdv cmbJenjang;
        private Syncfusion.Windows.Forms.Tools.ComboBoxAdv cmbProdi;
        private Syncfusion.Windows.Forms.Tools.ComboBoxAdv cmbUniv;
    }
}