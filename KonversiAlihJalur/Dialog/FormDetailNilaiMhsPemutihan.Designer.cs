#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
namespace KonversiAlihJalur.Dialog
{
    partial class FormDetailNilaiMhsPemutihan
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
            this.hapusApproveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.approveSemuaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.approveKecualiNilaiDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.approveKecualiNIlaiDDanEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.approveKecualiNilaiEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dgvNilai = new System.Windows.Forms.DataGridView();
            this.btnTutup = new Syncfusion.Windows.Forms.ButtonAdv();
            this.btnSimpan = new Syncfusion.Windows.Forms.ButtonAdv();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.autoLabel2 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.txtNama = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            this.txtNpmLama = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            this.autoLabel1 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.autoLabel15 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.gradientPanel2 = new Syncfusion.Windows.Forms.Tools.GradientPanel();
            this.labelForS2 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.txtNodaf = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            this.autoLabel3 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KodeLama = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MataKuliahLama = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SksLama = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GantiMk = new System.Windows.Forms.DataGridViewLinkColumn();
            this.KodeBaru = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MataKuliahBaru = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SksBaru = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nilai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Approve = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNilai)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtNama)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNpmLama)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gradientPanel2)).BeginInit();
            this.gradientPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtNodaf)).BeginInit();
            this.SuspendLayout();
            // 
            // hapusApproveToolStripMenuItem
            // 
            this.hapusApproveToolStripMenuItem.Name = "hapusApproveToolStripMenuItem";
            this.hapusApproveToolStripMenuItem.Size = new System.Drawing.Size(230, 22);
            this.hapusApproveToolStripMenuItem.Text = "Hapus Approve";
            this.hapusApproveToolStripMenuItem.Click += new System.EventHandler(this.hapusApproveToolStripMenuItem_Click);
            // 
            // approveSemuaToolStripMenuItem
            // 
            this.approveSemuaToolStripMenuItem.Name = "approveSemuaToolStripMenuItem";
            this.approveSemuaToolStripMenuItem.Size = new System.Drawing.Size(230, 22);
            this.approveSemuaToolStripMenuItem.Text = "Approve Semua";
            this.approveSemuaToolStripMenuItem.Click += new System.EventHandler(this.approveSemuaToolStripMenuItem_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.approveSemuaToolStripMenuItem,
            this.approveKecualiNilaiDToolStripMenuItem,
            this.approveKecualiNIlaiDDanEToolStripMenuItem,
            this.approveKecualiNilaiEToolStripMenuItem,
            this.hapusApproveToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(231, 114);
            // 
            // approveKecualiNilaiDToolStripMenuItem
            // 
            this.approveKecualiNilaiDToolStripMenuItem.Name = "approveKecualiNilaiDToolStripMenuItem";
            this.approveKecualiNilaiDToolStripMenuItem.Size = new System.Drawing.Size(230, 22);
            this.approveKecualiNilaiDToolStripMenuItem.Text = "Approve Kecuali Nilai D";
            this.approveKecualiNilaiDToolStripMenuItem.Visible = false;
            this.approveKecualiNilaiDToolStripMenuItem.Click += new System.EventHandler(this.approveKecualiNilaiDToolStripMenuItem_Click);
            // 
            // approveKecualiNIlaiDDanEToolStripMenuItem
            // 
            this.approveKecualiNIlaiDDanEToolStripMenuItem.Name = "approveKecualiNIlaiDDanEToolStripMenuItem";
            this.approveKecualiNIlaiDDanEToolStripMenuItem.Size = new System.Drawing.Size(230, 22);
            this.approveKecualiNIlaiDDanEToolStripMenuItem.Text = "Approve Kecuali NIlai D dan E";
            this.approveKecualiNIlaiDDanEToolStripMenuItem.Click += new System.EventHandler(this.approveKecualiNIlaiDDanEToolStripMenuItem_Click);
            // 
            // approveKecualiNilaiEToolStripMenuItem
            // 
            this.approveKecualiNilaiEToolStripMenuItem.Name = "approveKecualiNilaiEToolStripMenuItem";
            this.approveKecualiNilaiEToolStripMenuItem.Size = new System.Drawing.Size(230, 22);
            this.approveKecualiNilaiEToolStripMenuItem.Text = "Approve Kecuali Nilai E";
            this.approveKecualiNilaiEToolStripMenuItem.Click += new System.EventHandler(this.approveKecualiNilaiEToolStripMenuItem_Click);
            // 
            // dgvNilai
            // 
            this.dgvNilai.AllowUserToAddRows = false;
            this.dgvNilai.AllowUserToDeleteRows = false;
            this.dgvNilai.AllowUserToResizeRows = false;
            this.dgvNilai.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvNilai.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgvNilai.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNilai.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.No,
            this.KodeLama,
            this.MataKuliahLama,
            this.SksLama,
            this.GantiMk,
            this.KodeBaru,
            this.MataKuliahBaru,
            this.SksBaru,
            this.Nilai,
            this.Approve});
            this.dgvNilai.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvNilai.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvNilai.Location = new System.Drawing.Point(0, 122);
            this.dgvNilai.Name = "dgvNilai";
            this.dgvNilai.RowHeadersVisible = false;
            this.dgvNilai.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvNilai.Size = new System.Drawing.Size(939, 327);
            this.dgvNilai.TabIndex = 25;
            this.dgvNilai.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvNilai_CellContentClick);
            // 
            // btnTutup
            // 
            this.btnTutup.BeforeTouchSize = new System.Drawing.Size(126, 28);
            this.btnTutup.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTutup.IsBackStageButton = false;
            this.btnTutup.Location = new System.Drawing.Point(811, 5);
            this.btnTutup.Margin = new System.Windows.Forms.Padding(2, 5, 2, 5);
            this.btnTutup.Name = "btnTutup";
            this.btnTutup.Size = new System.Drawing.Size(126, 28);
            this.btnTutup.TabIndex = 0;
            this.btnTutup.Text = "Tutup";
            this.btnTutup.Click += new System.EventHandler(this.btnTutup_Click);
            // 
            // btnSimpan
            // 
            this.btnSimpan.BeforeTouchSize = new System.Drawing.Size(126, 28);
            this.btnSimpan.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSimpan.IsBackStageButton = false;
            this.btnSimpan.Location = new System.Drawing.Point(681, 5);
            this.btnSimpan.Margin = new System.Windows.Forms.Padding(2, 5, 2, 5);
            this.btnSimpan.Name = "btnSimpan";
            this.btnSimpan.Size = new System.Drawing.Size(126, 28);
            this.btnSimpan.TabIndex = 3;
            this.btnSimpan.Text = "Simpan";
            this.btnSimpan.Click += new System.EventHandler(this.btnSimpan_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(423, 3);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(253, 30);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar1.TabIndex = 2;
            this.progressBar1.Visible = false;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnTutup);
            this.flowLayoutPanel1.Controls.Add(this.btnSimpan);
            this.flowLayoutPanel1.Controls.Add(this.progressBar1);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 449);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(2, 5, 2, 5);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(939, 38);
            this.flowLayoutPanel1.TabIndex = 24;
            // 
            // autoLabel2
            // 
            this.autoLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.autoLabel2.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.autoLabel2.Location = new System.Drawing.Point(86, 99);
            this.autoLabel2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.autoLabel2.Name = "autoLabel2";
            this.autoLabel2.Size = new System.Drawing.Size(304, 16);
            this.autoLabel2.TabIndex = 13;
            this.autoLabel2.Text = "Klik kanan pada baris untuk edit approve otomatis";
            // 
            // txtNama
            // 
            this.txtNama.BeforeTouchSize = new System.Drawing.Size(136, 25);
            this.txtNama.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtNama.Location = new System.Drawing.Point(86, 67);
            this.txtNama.Metrocolor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.txtNama.Name = "txtNama";
            this.txtNama.ReadOnly = true;
            this.txtNama.Size = new System.Drawing.Size(393, 25);
            this.txtNama.TabIndex = 12;
            // 
            // txtNpmLama
            // 
            this.txtNpmLama.BeforeTouchSize = new System.Drawing.Size(136, 25);
            this.txtNpmLama.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtNpmLama.Location = new System.Drawing.Point(86, 5);
            this.txtNpmLama.Metrocolor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.txtNpmLama.Name = "txtNpmLama";
            this.txtNpmLama.ReadOnly = true;
            this.txtNpmLama.Size = new System.Drawing.Size(136, 25);
            this.txtNpmLama.TabIndex = 11;
            this.txtNpmLama.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNpmLama_KeyPress);
            // 
            // autoLabel1
            // 
            this.autoLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.autoLabel1.Location = new System.Drawing.Point(6, 73);
            this.autoLabel1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.autoLabel1.Name = "autoLabel1";
            this.autoLabel1.Size = new System.Drawing.Size(45, 16);
            this.autoLabel1.TabIndex = 10;
            this.autoLabel1.Text = "Nama";
            // 
            // autoLabel15
            // 
            this.autoLabel15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.autoLabel15.Location = new System.Drawing.Point(6, 10);
            this.autoLabel15.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.autoLabel15.Name = "autoLabel15";
            this.autoLabel15.Size = new System.Drawing.Size(75, 16);
            this.autoLabel15.TabIndex = 8;
            this.autoLabel15.Text = "NPM Lama";
            // 
            // gradientPanel2
            // 
            this.gradientPanel2.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat;
            this.gradientPanel2.Controls.Add(this.labelForS2);
            this.gradientPanel2.Controls.Add(this.txtNodaf);
            this.gradientPanel2.Controls.Add(this.autoLabel3);
            this.gradientPanel2.Controls.Add(this.autoLabel2);
            this.gradientPanel2.Controls.Add(this.txtNama);
            this.gradientPanel2.Controls.Add(this.txtNpmLama);
            this.gradientPanel2.Controls.Add(this.autoLabel1);
            this.gradientPanel2.Controls.Add(this.autoLabel15);
            this.gradientPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.gradientPanel2.Location = new System.Drawing.Point(0, 0);
            this.gradientPanel2.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.gradientPanel2.Name = "gradientPanel2";
            this.gradientPanel2.Size = new System.Drawing.Size(939, 122);
            this.gradientPanel2.TabIndex = 23;
            // 
            // labelForS2
            // 
            this.labelForS2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelForS2.Location = new System.Drawing.Point(227, 10);
            this.labelForS2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelForS2.Name = "labelForS2";
            this.labelForS2.Size = new System.Drawing.Size(46, 16);
            this.labelForS2.TabIndex = 16;
            this.labelForS2.Text = "(enter)";
            // 
            // txtNodaf
            // 
            this.txtNodaf.BeforeTouchSize = new System.Drawing.Size(136, 25);
            this.txtNodaf.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtNodaf.Location = new System.Drawing.Point(86, 36);
            this.txtNodaf.Metrocolor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.txtNodaf.Name = "txtNodaf";
            this.txtNodaf.ReadOnly = true;
            this.txtNodaf.Size = new System.Drawing.Size(136, 25);
            this.txtNodaf.TabIndex = 15;
            // 
            // autoLabel3
            // 
            this.autoLabel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.autoLabel3.Location = new System.Drawing.Point(6, 41);
            this.autoLabel3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.autoLabel3.Name = "autoLabel3";
            this.autoLabel3.Size = new System.Drawing.Size(45, 16);
            this.autoLabel3.TabIndex = 14;
            this.autoLabel3.Text = "Nodaf";
            // 
            // No
            // 
            this.No.HeaderText = "No";
            this.No.Name = "No";
            this.No.ReadOnly = true;
            this.No.Width = 51;
            // 
            // KodeLama
            // 
            this.KodeLama.HeaderText = "Kode Lama";
            this.KodeLama.Name = "KodeLama";
            this.KodeLama.ReadOnly = true;
            this.KodeLama.Width = 91;
            // 
            // MataKuliahLama
            // 
            this.MataKuliahLama.HeaderText = "Mata Kuliah Lama";
            this.MataKuliahLama.Name = "MataKuliahLama";
            this.MataKuliahLama.ReadOnly = true;
            this.MataKuliahLama.Width = 125;
            // 
            // SksLama
            // 
            this.SksLama.HeaderText = "Sks Lama";
            this.SksLama.Name = "SksLama";
            this.SksLama.ReadOnly = true;
            this.SksLama.Width = 80;
            // 
            // GantiMk
            // 
            this.GantiMk.HeaderText = "";
            this.GantiMk.Name = "GantiMk";
            this.GantiMk.VisitedLinkColor = System.Drawing.Color.Blue;
            this.GantiMk.Width = 5;
            // 
            // KodeBaru
            // 
            this.KodeBaru.HeaderText = "Kode Baru";
            this.KodeBaru.Name = "KodeBaru";
            this.KodeBaru.ReadOnly = true;
            this.KodeBaru.Width = 87;
            // 
            // MataKuliahBaru
            // 
            this.MataKuliahBaru.HeaderText = "Mata Kuliah Baru";
            this.MataKuliahBaru.Name = "MataKuliahBaru";
            this.MataKuliahBaru.ReadOnly = true;
            this.MataKuliahBaru.Width = 121;
            // 
            // SksBaru
            // 
            this.SksBaru.HeaderText = "Sks Baru";
            this.SksBaru.Name = "SksBaru";
            this.SksBaru.ReadOnly = true;
            this.SksBaru.Width = 76;
            // 
            // Nilai
            // 
            this.Nilai.HeaderText = "Nilai";
            this.Nilai.Name = "Nilai";
            this.Nilai.ReadOnly = true;
            this.Nilai.Width = 59;
            // 
            // Approve
            // 
            this.Approve.HeaderText = "Approve";
            this.Approve.Name = "Approve";
            this.Approve.Width = 64;
            // 
            // FormDetailNilaiMhsPemutihan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CaptionFont = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClientSize = new System.Drawing.Size(939, 487);
            this.Controls.Add(this.dgvNilai);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.gradientPanel2);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FormDetailNilaiMhsPemutihan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Detail Nilai Mahasiswa Pemutihan";
            this.Load += new System.EventHandler(this.FormDetailNilaiMhsPemutihan_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNilai)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtNama)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNpmLama)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gradientPanel2)).EndInit();
            this.gradientPanel2.ResumeLayout(false);
            this.gradientPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtNodaf)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripMenuItem hapusApproveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem approveSemuaToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem approveKecualiNilaiDToolStripMenuItem;
        private System.Windows.Forms.DataGridView dgvNilai;
        private Syncfusion.Windows.Forms.ButtonAdv btnTutup;
        private Syncfusion.Windows.Forms.ButtonAdv btnSimpan;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel2;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtNama;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtNpmLama;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel1;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel15;
        private Syncfusion.Windows.Forms.Tools.GradientPanel gradientPanel2;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtNodaf;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel3;
        private System.Windows.Forms.ToolStripMenuItem approveKecualiNIlaiDDanEToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem approveKecualiNilaiEToolStripMenuItem;
        private Syncfusion.Windows.Forms.Tools.AutoLabel labelForS2;
        private System.Windows.Forms.DataGridViewTextBoxColumn No;
        private System.Windows.Forms.DataGridViewTextBoxColumn KodeLama;
        private System.Windows.Forms.DataGridViewTextBoxColumn MataKuliahLama;
        private System.Windows.Forms.DataGridViewTextBoxColumn SksLama;
        private System.Windows.Forms.DataGridViewLinkColumn GantiMk;
        private System.Windows.Forms.DataGridViewTextBoxColumn KodeBaru;
        private System.Windows.Forms.DataGridViewTextBoxColumn MataKuliahBaru;
        private System.Windows.Forms.DataGridViewTextBoxColumn SksBaru;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nilai;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Approve;
    }
}