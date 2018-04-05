#region Copyright Syncfusion Inc. 2001 - 2016
// Copyright Syncfusion Inc. 2001 - 2016. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
namespace Dosen
{
    partial class FormHonorDosen
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
            this.btnHapus = new Syncfusion.Windows.Forms.ButtonAdv();
            this.btntambah = new Syncfusion.Windows.Forms.ButtonAdv();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.autoLabel1 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.txtCari = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            this.dgvHonorDosen = new System.Windows.Forms.DataGridView();
            this.IdHonorDosen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Jenjang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Golongan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HonorFix = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HonorVar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HonorRemidial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pajak = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TanggalBerlaku = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Hapus = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.btnRemidial = new Syncfusion.Windows.Forms.ButtonAdv();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCari)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHonorDosen)).BeginInit();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnTutup);
            this.flowLayoutPanel1.Controls.Add(this.btnHapus);
            this.flowLayoutPanel1.Controls.Add(this.btntambah);
            this.flowLayoutPanel1.Controls.Add(this.btnRemidial);
            this.flowLayoutPanel1.Controls.Add(this.progressBar1);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 447);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(867, 38);
            this.flowLayoutPanel1.TabIndex = 12;
            // 
            // btnTutup
            // 
            this.btnTutup.BeforeTouchSize = new System.Drawing.Size(113, 30);
            this.btnTutup.IsBackStageButton = false;
            this.btnTutup.Location = new System.Drawing.Point(751, 4);
            this.btnTutup.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnTutup.Name = "btnTutup";
            this.btnTutup.Size = new System.Drawing.Size(113, 30);
            this.btnTutup.TabIndex = 0;
            this.btnTutup.Text = "Tutup";
            this.btnTutup.Click += new System.EventHandler(this.btnTutup_Click);
            // 
            // btnHapus
            // 
            this.btnHapus.BackColor = System.Drawing.Color.Salmon;
            this.btnHapus.BeforeTouchSize = new System.Drawing.Size(113, 30);
            this.btnHapus.IsBackStageButton = false;
            this.btnHapus.Location = new System.Drawing.Point(632, 4);
            this.btnHapus.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnHapus.Name = "btnHapus";
            this.btnHapus.Size = new System.Drawing.Size(113, 30);
            this.btnHapus.TabIndex = 2;
            this.btnHapus.Text = "Hapus";
            this.btnHapus.Click += new System.EventHandler(this.btnHapus_Click);
            // 
            // btntambah
            // 
            this.btntambah.BeforeTouchSize = new System.Drawing.Size(113, 30);
            this.btntambah.IsBackStageButton = false;
            this.btntambah.Location = new System.Drawing.Point(513, 4);
            this.btntambah.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btntambah.Name = "btntambah";
            this.btntambah.Size = new System.Drawing.Size(113, 30);
            this.btntambah.TabIndex = 3;
            this.btntambah.Text = "Tambah";
            this.btntambah.Click += new System.EventHandler(this.btntambah_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(86, 3);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(214, 30);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar1.TabIndex = 1;
            this.progressBar1.Visible = false;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.autoLabel1);
            this.flowLayoutPanel2.Controls.Add(this.txtCari);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(867, 33);
            this.flowLayoutPanel2.TabIndex = 13;
            // 
            // autoLabel1
            // 
            this.autoLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.autoLabel1.Location = new System.Drawing.Point(3, 0);
            this.autoLabel1.Name = "autoLabel1";
            this.autoLabel1.Size = new System.Drawing.Size(31, 31);
            this.autoLabel1.TabIndex = 0;
            this.autoLabel1.Text = "Cari";
            this.autoLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtCari
            // 
            this.txtCari.BeforeTouchSize = new System.Drawing.Size(271, 25);
            this.txtCari.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtCari.Location = new System.Drawing.Point(40, 3);
            this.txtCari.Metrocolor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.txtCari.Name = "txtCari";
            this.txtCari.Size = new System.Drawing.Size(239, 25);
            this.txtCari.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Default;
            this.txtCari.TabIndex = 1;
            this.txtCari.TextChanged += new System.EventHandler(this.txtCari_TextChanged);
            // 
            // dgvHonorDosen
            // 
            this.dgvHonorDosen.AllowUserToAddRows = false;
            this.dgvHonorDosen.AllowUserToDeleteRows = false;
            this.dgvHonorDosen.AllowUserToResizeRows = false;
            this.dgvHonorDosen.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgvHonorDosen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHonorDosen.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdHonorDosen,
            this.Jenjang,
            this.Golongan,
            this.HonorFix,
            this.HonorVar,
            this.HonorRemidial,
            this.Pajak,
            this.TanggalBerlaku,
            this.Hapus});
            this.dgvHonorDosen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvHonorDosen.Location = new System.Drawing.Point(0, 33);
            this.dgvHonorDosen.MultiSelect = false;
            this.dgvHonorDosen.Name = "dgvHonorDosen";
            this.dgvHonorDosen.RowHeadersVisible = false;
            this.dgvHonorDosen.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHonorDosen.Size = new System.Drawing.Size(867, 414);
            this.dgvHonorDosen.TabIndex = 14;
            this.dgvHonorDosen.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvHonorDosen_CellEndEdit);
            // 
            // IdHonorDosen
            // 
            this.IdHonorDosen.HeaderText = "IdHonorDosen";
            this.IdHonorDosen.Name = "IdHonorDosen";
            this.IdHonorDosen.ReadOnly = true;
            this.IdHonorDosen.Visible = false;
            // 
            // Jenjang
            // 
            this.Jenjang.HeaderText = "Jenjang";
            this.Jenjang.Name = "Jenjang";
            this.Jenjang.ReadOnly = true;
            this.Jenjang.Width = 150;
            // 
            // Golongan
            // 
            this.Golongan.HeaderText = "Golongan";
            this.Golongan.Name = "Golongan";
            this.Golongan.ReadOnly = true;
            // 
            // HonorFix
            // 
            this.HonorFix.HeaderText = "Honor Fix";
            this.HonorFix.Name = "HonorFix";
            this.HonorFix.ReadOnly = true;
            this.HonorFix.Width = 150;
            // 
            // HonorVar
            // 
            this.HonorVar.HeaderText = "Honor Variable";
            this.HonorVar.Name = "HonorVar";
            this.HonorVar.ReadOnly = true;
            this.HonorVar.Width = 150;
            // 
            // HonorRemidial
            // 
            this.HonorRemidial.HeaderText = "Honor Remidial";
            this.HonorRemidial.Name = "HonorRemidial";
            this.HonorRemidial.Width = 150;
            // 
            // Pajak
            // 
            this.Pajak.HeaderText = "Pajak";
            this.Pajak.Name = "Pajak";
            this.Pajak.ReadOnly = true;
            this.Pajak.Visible = false;
            this.Pajak.Width = 60;
            // 
            // TanggalBerlaku
            // 
            this.TanggalBerlaku.HeaderText = "Tanggal Berlaku";
            this.TanggalBerlaku.Name = "TanggalBerlaku";
            this.TanggalBerlaku.ReadOnly = true;
            this.TanggalBerlaku.Width = 200;
            // 
            // Hapus
            // 
            this.Hapus.HeaderText = "Hapus";
            this.Hapus.Name = "Hapus";
            this.Hapus.Width = 55;
            // 
            // btnRemidial
            // 
            this.btnRemidial.BeforeTouchSize = new System.Drawing.Size(201, 30);
            this.btnRemidial.IsBackStageButton = false;
            this.btnRemidial.Location = new System.Drawing.Point(306, 4);
            this.btnRemidial.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnRemidial.Name = "btnRemidial";
            this.btnRemidial.Size = new System.Drawing.Size(201, 30);
            this.btnRemidial.TabIndex = 4;
            this.btnRemidial.Text = "HR Soal dan Koreksi Remidial";
            this.btnRemidial.Click += new System.EventHandler(this.btnRemidial_Click);
            // 
            // FormHonorDosen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CaptionFont = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClientSize = new System.Drawing.Size(867, 485);
            this.Controls.Add(this.dgvHonorDosen);
            this.Controls.Add(this.flowLayoutPanel2);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FormHonorDosen";
            this.Text = "Honor Dosen";
            this.Load += new System.EventHandler(this.FormHonorDosen_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCari)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHonorDosen)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private Syncfusion.Windows.Forms.ButtonAdv btnTutup;
        private System.Windows.Forms.ProgressBar progressBar1;
        private Syncfusion.Windows.Forms.ButtonAdv btnHapus;
        private Syncfusion.Windows.Forms.ButtonAdv btntambah;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel1;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtCari;
        private System.Windows.Forms.DataGridView dgvHonorDosen;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdHonorDosen;
        private System.Windows.Forms.DataGridViewTextBoxColumn Jenjang;
        private System.Windows.Forms.DataGridViewTextBoxColumn Golongan;
        private System.Windows.Forms.DataGridViewTextBoxColumn HonorFix;
        private System.Windows.Forms.DataGridViewTextBoxColumn HonorVar;
        private System.Windows.Forms.DataGridViewTextBoxColumn HonorRemidial;
        private System.Windows.Forms.DataGridViewTextBoxColumn Pajak;
        private System.Windows.Forms.DataGridViewTextBoxColumn TanggalBerlaku;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Hapus;
        private Syncfusion.Windows.Forms.ButtonAdv btnRemidial;
    }
}