#region Copyright Syncfusion Inc. 2001 - 2016
// Copyright Syncfusion Inc. 2001 - 2016. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
namespace Dosen
{
    partial class FormJenjangPendidikanDosen
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
            this.dgvJenjangDosen = new AdvancedDataGridView.TreeGridView();
            this.Tree = new AdvancedDataGridView.TreeGridColumn();
            this.IdTransJenjang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nik = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NamaDosen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.JenjangPendidikan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProgramStudi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Universitas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TglMulai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TglSelesai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.hapusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tambahJenjangPendidikanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnTutup = new Syncfusion.Windows.Forms.ButtonAdv();
            this.btntambah = new Syncfusion.Windows.Forms.ButtonAdv();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.gradientPanel1 = new Syncfusion.Windows.Forms.Tools.GradientPanel();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.autoLabel1 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.txtCari = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            ((System.ComponentModel.ISupportInitialize)(this.dgvJenjangDosen)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gradientPanel1)).BeginInit();
            this.gradientPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCari)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvJenjangDosen
            // 
            this.dgvJenjangDosen.AllowUserToAddRows = false;
            this.dgvJenjangDosen.AllowUserToDeleteRows = false;
            this.dgvJenjangDosen.AllowUserToResizeRows = false;
            this.dgvJenjangDosen.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvJenjangDosen.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvJenjangDosen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvJenjangDosen.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Tree,
            this.IdTransJenjang,
            this.Nik,
            this.NamaDosen,
            this.JenjangPendidikan,
            this.ProgramStudi,
            this.Universitas,
            this.TglMulai,
            this.TglSelesai});
            this.dgvJenjangDosen.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvJenjangDosen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvJenjangDosen.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvJenjangDosen.ImageList = null;
            this.dgvJenjangDosen.Location = new System.Drawing.Point(0, 33);
            this.dgvJenjangDosen.MultiSelect = false;
            this.dgvJenjangDosen.Name = "dgvJenjangDosen";
            this.dgvJenjangDosen.RowHeadersVisible = false;
            this.dgvJenjangDosen.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvJenjangDosen.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvJenjangDosen.Size = new System.Drawing.Size(797, 372);
            this.dgvJenjangDosen.TabIndex = 0;
            this.dgvJenjangDosen.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvJenjangDosen_CellMouseDown);
            // 
            // Tree
            // 
            this.Tree.DefaultNodeImage = null;
            this.Tree.Frozen = true;
            this.Tree.HeaderText = "";
            this.Tree.Name = "Tree";
            this.Tree.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Tree.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Tree.Width = 30;
            // 
            // IdTransJenjang
            // 
            this.IdTransJenjang.HeaderText = "IdTransJenjang";
            this.IdTransJenjang.Name = "IdTransJenjang";
            this.IdTransJenjang.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.IdTransJenjang.Visible = false;
            // 
            // Nik
            // 
            this.Nik.HeaderText = "Nik";
            this.Nik.Name = "Nik";
            this.Nik.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Nik.Width = 90;
            // 
            // NamaDosen
            // 
            this.NamaDosen.HeaderText = "Nama Dosen";
            this.NamaDosen.Name = "NamaDosen";
            this.NamaDosen.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.NamaDosen.Width = 300;
            // 
            // JenjangPendidikan
            // 
            this.JenjangPendidikan.HeaderText = "Jenjang Pendidikan";
            this.JenjangPendidikan.Name = "JenjangPendidikan";
            this.JenjangPendidikan.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.JenjangPendidikan.Width = 70;
            // 
            // ProgramStudi
            // 
            this.ProgramStudi.HeaderText = "Program Studi";
            this.ProgramStudi.Name = "ProgramStudi";
            this.ProgramStudi.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ProgramStudi.Width = 200;
            // 
            // Universitas
            // 
            this.Universitas.HeaderText = "Universitas";
            this.Universitas.Name = "Universitas";
            this.Universitas.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Universitas.Width = 250;
            // 
            // TglMulai
            // 
            this.TglMulai.HeaderText = "Tanggal Mulai Pendidikan";
            this.TglMulai.Name = "TglMulai";
            this.TglMulai.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // TglSelesai
            // 
            this.TglSelesai.HeaderText = "Tanggal Selesai Pendidikan";
            this.TglSelesai.Name = "TglSelesai";
            this.TglSelesai.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hapusToolStripMenuItem,
            this.tambahJenjangPendidikanToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(222, 48);
            // 
            // hapusToolStripMenuItem
            // 
            this.hapusToolStripMenuItem.Name = "hapusToolStripMenuItem";
            this.hapusToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.hapusToolStripMenuItem.Text = "Hapus";
            this.hapusToolStripMenuItem.Click += new System.EventHandler(this.hapusToolStripMenuItem_Click);
            // 
            // tambahJenjangPendidikanToolStripMenuItem
            // 
            this.tambahJenjangPendidikanToolStripMenuItem.Name = "tambahJenjangPendidikanToolStripMenuItem";
            this.tambahJenjangPendidikanToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.tambahJenjangPendidikanToolStripMenuItem.Text = "Tambah Jenjang Pendidikan";
            this.tambahJenjangPendidikanToolStripMenuItem.Click += new System.EventHandler(this.tambahJenjangPendidikanToolStripMenuItem_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnTutup);
            this.flowLayoutPanel1.Controls.Add(this.btntambah);
            this.flowLayoutPanel1.Controls.Add(this.progressBar1);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 409);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(801, 38);
            this.flowLayoutPanel1.TabIndex = 13;
            // 
            // btnTutup
            // 
            this.btnTutup.BeforeTouchSize = new System.Drawing.Size(113, 30);
            this.btnTutup.IsBackStageButton = false;
            this.btnTutup.Location = new System.Drawing.Point(685, 4);
            this.btnTutup.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnTutup.Name = "btnTutup";
            this.btnTutup.Size = new System.Drawing.Size(113, 30);
            this.btnTutup.TabIndex = 0;
            this.btnTutup.Text = "Tutup";
            this.btnTutup.Click += new System.EventHandler(this.btnTutup_Click);
            // 
            // btntambah
            // 
            this.btntambah.BeforeTouchSize = new System.Drawing.Size(113, 30);
            this.btntambah.IsBackStageButton = false;
            this.btntambah.Location = new System.Drawing.Point(566, 4);
            this.btntambah.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btntambah.Name = "btntambah";
            this.btntambah.Size = new System.Drawing.Size(113, 30);
            this.btntambah.TabIndex = 5;
            this.btntambah.Text = "Tambah";
            this.btntambah.Click += new System.EventHandler(this.btntambah_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(346, 3);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(214, 30);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar1.TabIndex = 1;
            this.progressBar1.Visible = false;
            // 
            // gradientPanel1
            // 
            this.gradientPanel1.Controls.Add(this.dgvJenjangDosen);
            this.gradientPanel1.Controls.Add(this.flowLayoutPanel2);
            this.gradientPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gradientPanel1.Location = new System.Drawing.Point(0, 0);
            this.gradientPanel1.Name = "gradientPanel1";
            this.gradientPanel1.Size = new System.Drawing.Size(801, 409);
            this.gradientPanel1.TabIndex = 14;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.autoLabel1);
            this.flowLayoutPanel2.Controls.Add(this.txtCari);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(797, 33);
            this.flowLayoutPanel2.TabIndex = 1;
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
            this.txtCari.BeforeTouchSize = new System.Drawing.Size(250, 25);
            this.txtCari.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtCari.Location = new System.Drawing.Point(40, 3);
            this.txtCari.Metrocolor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.txtCari.Name = "txtCari";
            this.txtCari.Size = new System.Drawing.Size(250, 25);
            this.txtCari.TabIndex = 1;
            this.txtCari.TextChanged += new System.EventHandler(this.txtCari_TextChanged);
            // 
            // FormJenjangPendidikanDosen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CaptionFont = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClientSize = new System.Drawing.Size(801, 447);
            this.Controls.Add(this.gradientPanel1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FormJenjangPendidikanDosen";
            this.Text = "Jenjang Pendidikan Dosen";
            this.Load += new System.EventHandler(this.FormJenjangPendidikanDosen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvJenjangDosen)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gradientPanel1)).EndInit();
            this.gradientPanel1.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCari)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private AdvancedDataGridView.TreeGridView dgvJenjangDosen;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private Syncfusion.Windows.Forms.ButtonAdv btnTutup;
        private System.Windows.Forms.ProgressBar progressBar1;
        private Syncfusion.Windows.Forms.Tools.GradientPanel gradientPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel1;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtCari;
        private Syncfusion.Windows.Forms.ButtonAdv btntambah;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem hapusToolStripMenuItem;
        private AdvancedDataGridView.TreeGridColumn Tree;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdTransJenjang;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nik;
        private System.Windows.Forms.DataGridViewTextBoxColumn NamaDosen;
        private System.Windows.Forms.DataGridViewTextBoxColumn JenjangPendidikan;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProgramStudi;
        private System.Windows.Forms.DataGridViewTextBoxColumn Universitas;
        private System.Windows.Forms.DataGridViewTextBoxColumn TglMulai;
        private System.Windows.Forms.DataGridViewTextBoxColumn TglSelesai;
        private System.Windows.Forms.ToolStripMenuItem tambahJenjangPendidikanToolStripMenuItem;
    }
}