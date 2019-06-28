#region Copyright Syncfusion Inc. 2001 - 2016
// Copyright Syncfusion Inc. 2001 - 2016. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
namespace KonversiAlihJalur.Dialog
{
    partial class FormDetailNilaiMhsAlihJalurNonAmikom
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
            this.txtNama = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            this.txtNpmLama = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            this.autoLabel1 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.autoLabel15 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnTutup = new Syncfusion.Windows.Forms.ButtonAdv();
            this.btnSimpan = new Syncfusion.Windows.Forms.ButtonAdv();
            this.btnImportExcel = new Syncfusion.Windows.Forms.ButtonAdv();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.dgvNilai = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.approveSemuaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.approveKecualiNilaiDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hapusApproveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KodeD3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MataKuliahD3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SksD3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KodeS1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MataKuliahS1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SksS1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nilai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Hapus = new System.Windows.Forms.DataGridViewLinkColumn();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gradientPanel2)).BeginInit();
            this.gradientPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtNama)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNpmLama)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNilai)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gradientPanel2
            // 
            this.gradientPanel2.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat;
            this.gradientPanel2.Controls.Add(this.txtNama);
            this.gradientPanel2.Controls.Add(this.txtNpmLama);
            this.gradientPanel2.Controls.Add(this.autoLabel1);
            this.gradientPanel2.Controls.Add(this.autoLabel15);
            this.gradientPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.gradientPanel2.Location = new System.Drawing.Point(0, 0);
            this.gradientPanel2.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.gradientPanel2.Name = "gradientPanel2";
            this.gradientPanel2.Size = new System.Drawing.Size(870, 74);
            this.gradientPanel2.TabIndex = 20;
            // 
            // txtNama
            // 
            this.txtNama.BeforeTouchSize = new System.Drawing.Size(136, 25);
            this.txtNama.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtNama.Location = new System.Drawing.Point(86, 36);
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
            // 
            // autoLabel1
            // 
            this.autoLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.autoLabel1.Location = new System.Drawing.Point(6, 42);
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
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnTutup);
            this.flowLayoutPanel1.Controls.Add(this.btnSimpan);
            this.flowLayoutPanel1.Controls.Add(this.btnImportExcel);
            this.flowLayoutPanel1.Controls.Add(this.progressBar1);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 443);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(2, 5, 2, 5);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(870, 38);
            this.flowLayoutPanel1.TabIndex = 21;
            // 
            // btnTutup
            // 
            this.btnTutup.BeforeTouchSize = new System.Drawing.Size(126, 28);
            this.btnTutup.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTutup.IsBackStageButton = false;
            this.btnTutup.Location = new System.Drawing.Point(742, 5);
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
            this.btnSimpan.Location = new System.Drawing.Point(612, 5);
            this.btnSimpan.Margin = new System.Windows.Forms.Padding(2, 5, 2, 5);
            this.btnSimpan.Name = "btnSimpan";
            this.btnSimpan.Size = new System.Drawing.Size(126, 28);
            this.btnSimpan.TabIndex = 3;
            this.btnSimpan.Text = "Simpan";
            this.btnSimpan.Click += new System.EventHandler(this.btnSimpan_Click);
            // 
            // btnImportExcel
            // 
            this.btnImportExcel.BeforeTouchSize = new System.Drawing.Size(126, 28);
            this.btnImportExcel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImportExcel.IsBackStageButton = false;
            this.btnImportExcel.Location = new System.Drawing.Point(482, 5);
            this.btnImportExcel.Margin = new System.Windows.Forms.Padding(2, 5, 2, 5);
            this.btnImportExcel.Name = "btnImportExcel";
            this.btnImportExcel.Size = new System.Drawing.Size(126, 28);
            this.btnImportExcel.TabIndex = 4;
            this.btnImportExcel.Text = "Import Excel";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(224, 3);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(253, 30);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar1.TabIndex = 2;
            this.progressBar1.Visible = false;
            // 
            // dgvNilai
            // 
            this.dgvNilai.AllowUserToResizeRows = false;
            this.dgvNilai.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgvNilai.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNilai.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.No,
            this.KodeD3,
            this.MataKuliahD3,
            this.SksD3,
            this.KodeS1,
            this.MataKuliahS1,
            this.SksS1,
            this.Nilai,
            this.Hapus,
            this.Id});
            this.dgvNilai.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvNilai.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvNilai.Location = new System.Drawing.Point(0, 74);
            this.dgvNilai.MultiSelect = false;
            this.dgvNilai.Name = "dgvNilai";
            this.dgvNilai.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvNilai.Size = new System.Drawing.Size(870, 369);
            this.dgvNilai.TabIndex = 22;
            this.dgvNilai.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvNilai_CellClick);
            this.dgvNilai.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dgvNilai_RowsAdded);
            this.dgvNilai.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dgvNilai_RowsRemoved);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.approveSemuaToolStripMenuItem,
            this.approveKecualiNilaiDToolStripMenuItem,
            this.hapusApproveToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(199, 70);
            // 
            // approveSemuaToolStripMenuItem
            // 
            this.approveSemuaToolStripMenuItem.Name = "approveSemuaToolStripMenuItem";
            this.approveSemuaToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.approveSemuaToolStripMenuItem.Text = "Approve Semua";
            this.approveSemuaToolStripMenuItem.Click += new System.EventHandler(this.approveSemuaToolStripMenuItem_Click);
            // 
            // approveKecualiNilaiDToolStripMenuItem
            // 
            this.approveKecualiNilaiDToolStripMenuItem.Name = "approveKecualiNilaiDToolStripMenuItem";
            this.approveKecualiNilaiDToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.approveKecualiNilaiDToolStripMenuItem.Text = "Approve Kecuali Nilai D";
            this.approveKecualiNilaiDToolStripMenuItem.Click += new System.EventHandler(this.approveKecualiNilaiDToolStripMenuItem_Click);
            // 
            // hapusApproveToolStripMenuItem
            // 
            this.hapusApproveToolStripMenuItem.Name = "hapusApproveToolStripMenuItem";
            this.hapusApproveToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.hapusApproveToolStripMenuItem.Text = "Hapus Approve";
            this.hapusApproveToolStripMenuItem.Click += new System.EventHandler(this.hapusApproveToolStripMenuItem_Click);
            // 
            // No
            // 
            this.No.HeaderText = "No";
            this.No.Name = "No";
            this.No.Width = 50;
            // 
            // KodeD3
            // 
            this.KodeD3.HeaderText = "Kode D3";
            this.KodeD3.Name = "KodeD3";
            this.KodeD3.Width = 60;
            // 
            // MataKuliahD3
            // 
            this.MataKuliahD3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.MataKuliahD3.HeaderText = "Mata Kuliah D3";
            this.MataKuliahD3.Name = "MataKuliahD3";
            // 
            // SksD3
            // 
            this.SksD3.HeaderText = "Sks D3";
            this.SksD3.Name = "SksD3";
            this.SksD3.Width = 60;
            // 
            // KodeS1
            // 
            this.KodeS1.HeaderText = "Kode S1";
            this.KodeS1.Name = "KodeS1";
            this.KodeS1.ReadOnly = true;
            this.KodeS1.Width = 60;
            // 
            // MataKuliahS1
            // 
            this.MataKuliahS1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.MataKuliahS1.HeaderText = "Mata Kuliah S1";
            this.MataKuliahS1.Name = "MataKuliahS1";
            this.MataKuliahS1.ReadOnly = true;
            this.MataKuliahS1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // SksS1
            // 
            this.SksS1.HeaderText = "Sks S1";
            this.SksS1.Name = "SksS1";
            this.SksS1.ReadOnly = true;
            this.SksS1.Width = 60;
            // 
            // Nilai
            // 
            this.Nilai.HeaderText = "Nilai";
            this.Nilai.Name = "Nilai";
            this.Nilai.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Nilai.Width = 70;
            // 
            // Hapus
            // 
            this.Hapus.HeaderText = "Hapus";
            this.Hapus.LinkColor = System.Drawing.Color.Blue;
            this.Hapus.Name = "Hapus";
            this.Hapus.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Hapus.Text = "Hapus";
            this.Hapus.VisitedLinkColor = System.Drawing.Color.Blue;
            this.Hapus.Width = 70;
            // 
            // Id
            // 
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.Visible = false;
            // 
            // FormDetailNilaiMhsAlihJalurNonAmikom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CaptionFont = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClientSize = new System.Drawing.Size(870, 481);
            this.Controls.Add(this.dgvNilai);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.gradientPanel2);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormDetailNilaiMhsAlihJalurNonAmikom";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Detail Nilai";
            this.Load += new System.EventHandler(this.FormDetailNilaiMhsAlihJalur_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gradientPanel2)).EndInit();
            this.gradientPanel2.ResumeLayout(false);
            this.gradientPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtNama)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNpmLama)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNilai)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Syncfusion.Windows.Forms.Tools.GradientPanel gradientPanel2;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel1;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel15;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private Syncfusion.Windows.Forms.ButtonAdv btnTutup;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.DataGridView dgvNilai;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtNama;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtNpmLama;
        private Syncfusion.Windows.Forms.ButtonAdv btnSimpan;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem approveSemuaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem approveKecualiNilaiDToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hapusApproveToolStripMenuItem;
        private Syncfusion.Windows.Forms.ButtonAdv btnImportExcel;
        private System.Windows.Forms.DataGridViewTextBoxColumn No;
        private System.Windows.Forms.DataGridViewTextBoxColumn KodeD3;
        private System.Windows.Forms.DataGridViewTextBoxColumn MataKuliahD3;
        private System.Windows.Forms.DataGridViewTextBoxColumn SksD3;
        private System.Windows.Forms.DataGridViewTextBoxColumn KodeS1;
        private System.Windows.Forms.DataGridViewTextBoxColumn MataKuliahS1;
        private System.Windows.Forms.DataGridViewTextBoxColumn SksS1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nilai;
        private System.Windows.Forms.DataGridViewLinkColumn Hapus;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
    }
}