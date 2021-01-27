#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
namespace PenawaranKurikulum
{
    partial class FormKoordinatorMataKuliah
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnTutup = new Syncfusion.Windows.Forms.ButtonAdv();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.autoLabel15 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.cmbProdi = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            this.cmbFakultas = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            this.autoLabel1 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnProses = new Syncfusion.Windows.Forms.ButtonAdv();
            this.dgvMataKuliah = new AdvancedDataGridView.TreeGridView();
            this.Tree = new AdvancedDataGridView.TreeGridColumn();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Kode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MataKuliah = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.JumlahKelas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalSks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Koordinator = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Dosen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbProdi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbFakultas)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMataKuliah)).BeginInit();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnTutup);
            this.flowLayoutPanel1.Controls.Add(this.progressBar1);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 424);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(840, 38);
            this.flowLayoutPanel1.TabIndex = 14;
            // 
            // btnTutup
            // 
            this.btnTutup.BeforeTouchSize = new System.Drawing.Size(113, 30);
            this.btnTutup.IsBackStageButton = false;
            this.btnTutup.Location = new System.Drawing.Point(724, 4);
            this.btnTutup.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnTutup.Name = "btnTutup";
            this.btnTutup.Size = new System.Drawing.Size(113, 30);
            this.btnTutup.TabIndex = 0;
            this.btnTutup.Text = "Tutup";
            this.btnTutup.Click += new System.EventHandler(this.btnTutup_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(435, 3);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(283, 30);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar1.TabIndex = 1;
            this.progressBar1.Visible = false;
            // 
            // autoLabel15
            // 
            this.autoLabel15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.autoLabel15.Location = new System.Drawing.Point(20, 45);
            this.autoLabel15.Name = "autoLabel15";
            this.autoLabel15.Size = new System.Drawing.Size(93, 16);
            this.autoLabel15.TabIndex = 12;
            this.autoLabel15.Text = "Program Studi";
            // 
            // cmbProdi
            // 
            this.cmbProdi.BeforeTouchSize = new System.Drawing.Size(329, 24);
            this.cmbProdi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProdi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbProdi.Location = new System.Drawing.Point(144, 43);
            this.cmbProdi.Name = "cmbProdi";
            this.cmbProdi.Size = new System.Drawing.Size(329, 24);
            this.cmbProdi.TabIndex = 11;
            this.cmbProdi.SelectedIndexChanged += new System.EventHandler(this.cmbProdi_SelectedIndexChanged);
            // 
            // cmbFakultas
            // 
            this.cmbFakultas.BeforeTouchSize = new System.Drawing.Size(329, 25);
            this.cmbFakultas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFakultas.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbFakultas.Location = new System.Drawing.Point(144, 12);
            this.cmbFakultas.Name = "cmbFakultas";
            this.cmbFakultas.Size = new System.Drawing.Size(329, 25);
            this.cmbFakultas.TabIndex = 9;
            this.cmbFakultas.SelectedIndexChanged += new System.EventHandler(this.cmbFakultas_SelectedIndexChanged);
            // 
            // autoLabel1
            // 
            this.autoLabel1.Location = new System.Drawing.Point(21, 14);
            this.autoLabel1.Name = "autoLabel1";
            this.autoLabel1.Size = new System.Drawing.Size(54, 17);
            this.autoLabel1.TabIndex = 10;
            this.autoLabel1.Text = "Fakultas";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnProses);
            this.panel2.Controls.Add(this.autoLabel15);
            this.panel2.Controls.Add(this.cmbFakultas);
            this.panel2.Controls.Add(this.cmbProdi);
            this.panel2.Controls.Add(this.autoLabel1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(840, 111);
            this.panel2.TabIndex = 16;
            // 
            // btnProses
            // 
            this.btnProses.BeforeTouchSize = new System.Drawing.Size(113, 30);
            this.btnProses.IsBackStageButton = false;
            this.btnProses.Location = new System.Drawing.Point(144, 74);
            this.btnProses.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnProses.Name = "btnProses";
            this.btnProses.Size = new System.Drawing.Size(113, 30);
            this.btnProses.TabIndex = 13;
            this.btnProses.Text = "Proses";
            this.btnProses.Click += new System.EventHandler(this.btnProses_Click);
            // 
            // dgvMataKuliah
            // 
            this.dgvMataKuliah.AllowUserToAddRows = false;
            this.dgvMataKuliah.AllowUserToDeleteRows = false;
            this.dgvMataKuliah.AllowUserToResizeColumns = false;
            this.dgvMataKuliah.AllowUserToResizeRows = false;
            this.dgvMataKuliah.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMataKuliah.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvMataKuliah.ColumnHeadersHeight = 40;
            this.dgvMataKuliah.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Tree,
            this.Id,
            this.No,
            this.Kode,
            this.MataKuliah,
            this.JumlahKelas,
            this.TotalSks,
            this.Koordinator,
            this.Dosen});
            this.dgvMataKuliah.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMataKuliah.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvMataKuliah.ImageList = null;
            this.dgvMataKuliah.Location = new System.Drawing.Point(0, 111);
            this.dgvMataKuliah.Name = "dgvMataKuliah";
            this.dgvMataKuliah.RowHeadersVisible = false;
            this.dgvMataKuliah.Size = new System.Drawing.Size(840, 313);
            this.dgvMataKuliah.TabIndex = 17;
            this.dgvMataKuliah.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMataKuliah_CellContentClick);
            this.dgvMataKuliah.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvMataKuliah_CellPainting);
            this.dgvMataKuliah.ColumnWidthChanged += new System.Windows.Forms.DataGridViewColumnEventHandler(this.dgvMataKuliah_ColumnWidthChanged);
            this.dgvMataKuliah.Scroll += new System.Windows.Forms.ScrollEventHandler(this.dgvMataKuliah_Scroll);
            this.dgvMataKuliah.Paint += new System.Windows.Forms.PaintEventHandler(this.dgvMataKuliah_Paint);
            // 
            // Tree
            // 
            this.Tree.DefaultNodeImage = null;
            this.Tree.Frozen = true;
            this.Tree.HeaderText = "";
            this.Tree.Name = "Tree";
            this.Tree.ReadOnly = true;
            this.Tree.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Tree.Width = 30;
            // 
            // Id
            // 
            this.Id.Frozen = true;
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Id.Visible = false;
            // 
            // No
            // 
            this.No.Frozen = true;
            this.No.HeaderText = "No";
            this.No.Name = "No";
            this.No.ReadOnly = true;
            this.No.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.No.Width = 45;
            // 
            // Kode
            // 
            this.Kode.Frozen = true;
            this.Kode.HeaderText = "Kode";
            this.Kode.Name = "Kode";
            this.Kode.ReadOnly = true;
            this.Kode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Kode.Width = 80;
            // 
            // MataKuliah
            // 
            this.MataKuliah.Frozen = true;
            this.MataKuliah.HeaderText = "Mata Kuliah";
            this.MataKuliah.Name = "MataKuliah";
            this.MataKuliah.ReadOnly = true;
            this.MataKuliah.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.MataKuliah.Width = 300;
            // 
            // JumlahKelas
            // 
            this.JumlahKelas.HeaderText = "Jumlah Kelas";
            this.JumlahKelas.Name = "JumlahKelas";
            this.JumlahKelas.ReadOnly = true;
            this.JumlahKelas.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.JumlahKelas.Width = 75;
            // 
            // TotalSks
            // 
            this.TotalSks.HeaderText = "Total Sks";
            this.TotalSks.Name = "TotalSks";
            this.TotalSks.ReadOnly = true;
            this.TotalSks.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.TotalSks.Width = 75;
            // 
            // Koordinator
            // 
            this.Koordinator.HeaderText = "Pilih";
            this.Koordinator.Name = "Koordinator";
            this.Koordinator.Width = 75;
            // 
            // Dosen
            // 
            this.Dosen.HeaderText = "Dosen";
            this.Dosen.Name = "Dosen";
            this.Dosen.ReadOnly = true;
            this.Dosen.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Dosen.Width = 300;
            // 
            // FormKoordinatorMataKuliah
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CaptionFont = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClientSize = new System.Drawing.Size(840, 462);
            this.Controls.Add(this.dgvMataKuliah);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FormKoordinatorMataKuliah";
            this.Text = "Koordinator Mata Kuliah";
            this.Load += new System.EventHandler(this.FormKoordinatorMataKuliah_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cmbProdi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbFakultas)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMataKuliah)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private Syncfusion.Windows.Forms.ButtonAdv btnTutup;
        private System.Windows.Forms.ProgressBar progressBar1;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel15;
        private Syncfusion.Windows.Forms.Tools.ComboBoxAdv cmbProdi;
        private Syncfusion.Windows.Forms.Tools.ComboBoxAdv cmbFakultas;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel1;
        private System.Windows.Forms.Panel panel2;
        private AdvancedDataGridView.TreeGridView dgvMataKuliah;
        private Syncfusion.Windows.Forms.ButtonAdv btnProses;
        private AdvancedDataGridView.TreeGridColumn Tree;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn No;
        private System.Windows.Forms.DataGridViewTextBoxColumn Kode;
        private System.Windows.Forms.DataGridViewTextBoxColumn MataKuliah;
        private System.Windows.Forms.DataGridViewTextBoxColumn JumlahKelas;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalSks;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Koordinator;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dosen;
    }
}