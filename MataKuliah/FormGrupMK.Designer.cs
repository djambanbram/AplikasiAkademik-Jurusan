#region Copyright Syncfusion Inc. 2001 - 2016
// Copyright Syncfusion Inc. 2001 - 2016. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
namespace MataKuliah
{
    partial class FormGrupMK
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
            this.btnHapus = new Syncfusion.Windows.Forms.ButtonAdv();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.gradientPanel1 = new Syncfusion.Windows.Forms.Tools.GradientPanel();
            this.autoLabel15 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.cmbProdi = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            this.cmbFakultas = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            this.autoLabel3 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.autoLabel1 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.txtNamaGrup = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            this.autoLabel2 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.autoLabel4 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.gradientPanel2 = new Syncfusion.Windows.Forms.Tools.GradientPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dgvMataKuliah = new System.Windows.Forms.DataGridView();
            this.mKode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mMataKuliah = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gradientPanel3 = new Syncfusion.Windows.Forms.Tools.GradientPanel();
            this.btnClear = new Syncfusion.Windows.Forms.ButtonAdv();
            this.btnSimpan = new Syncfusion.Windows.Forms.ButtonAdv();
            this.dgvGrupMK = new System.Windows.Forms.DataGridView();
            this.Kode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MataKuliah = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvDaftarGrup = new System.Windows.Forms.DataGridView();
            this.NamaGrup = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KodeParent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gMataKuliah = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KodeMember = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gMataKuliahMember = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Hapus = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gradientPanel1)).BeginInit();
            this.gradientPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbProdi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbFakultas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNamaGrup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gradientPanel2)).BeginInit();
            this.gradientPanel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMataKuliah)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gradientPanel3)).BeginInit();
            this.gradientPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrupMK)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDaftarGrup)).BeginInit();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnTutup);
            this.flowLayoutPanel1.Controls.Add(this.btnHapus);
            this.flowLayoutPanel1.Controls.Add(this.progressBar1);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 422);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(835, 38);
            this.flowLayoutPanel1.TabIndex = 9;
            // 
            // btnTutup
            // 
            this.btnTutup.BeforeTouchSize = new System.Drawing.Size(113, 30);
            this.btnTutup.IsBackStageButton = false;
            this.btnTutup.Location = new System.Drawing.Point(719, 4);
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
            this.btnHapus.Location = new System.Drawing.Point(600, 4);
            this.btnHapus.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnHapus.Name = "btnHapus";
            this.btnHapus.Size = new System.Drawing.Size(113, 30);
            this.btnHapus.TabIndex = 2;
            this.btnHapus.Text = "Hapus";
            this.btnHapus.Click += new System.EventHandler(this.btnHapus_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(234, 3);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(360, 30);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar1.TabIndex = 1;
            this.progressBar1.Visible = false;
            // 
            // gradientPanel1
            // 
            this.gradientPanel1.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat;
            this.gradientPanel1.Controls.Add(this.autoLabel15);
            this.gradientPanel1.Controls.Add(this.cmbProdi);
            this.gradientPanel1.Controls.Add(this.cmbFakultas);
            this.gradientPanel1.Controls.Add(this.autoLabel3);
            this.gradientPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.gradientPanel1.Location = new System.Drawing.Point(0, 0);
            this.gradientPanel1.Name = "gradientPanel1";
            this.gradientPanel1.Size = new System.Drawing.Size(835, 76);
            this.gradientPanel1.TabIndex = 10;
            // 
            // autoLabel15
            // 
            this.autoLabel15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.autoLabel15.Location = new System.Drawing.Point(9, 44);
            this.autoLabel15.Name = "autoLabel15";
            this.autoLabel15.Size = new System.Drawing.Size(93, 16);
            this.autoLabel15.TabIndex = 12;
            this.autoLabel15.Text = "Program Studi";
            // 
            // cmbProdi
            // 
            this.cmbProdi.BeforeTouchSize = new System.Drawing.Size(341, 24);
            this.cmbProdi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProdi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbProdi.Location = new System.Drawing.Point(128, 41);
            this.cmbProdi.Name = "cmbProdi";
            this.cmbProdi.Size = new System.Drawing.Size(341, 24);
            this.cmbProdi.TabIndex = 11;
            this.cmbProdi.SelectedIndexChanged += new System.EventHandler(this.cmbProdi_SelectedIndexChanged);
            // 
            // cmbFakultas
            // 
            this.cmbFakultas.BeforeTouchSize = new System.Drawing.Size(341, 25);
            this.cmbFakultas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFakultas.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbFakultas.Location = new System.Drawing.Point(128, 10);
            this.cmbFakultas.Name = "cmbFakultas";
            this.cmbFakultas.Size = new System.Drawing.Size(341, 25);
            this.cmbFakultas.TabIndex = 9;
            this.cmbFakultas.SelectedIndexChanged += new System.EventHandler(this.cmbFakultas_SelectedIndexChanged);
            // 
            // autoLabel3
            // 
            this.autoLabel3.Location = new System.Drawing.Point(10, 13);
            this.autoLabel3.Name = "autoLabel3";
            this.autoLabel3.Size = new System.Drawing.Size(54, 17);
            this.autoLabel3.TabIndex = 10;
            this.autoLabel3.Text = "Fakultas";
            // 
            // autoLabel1
            // 
            this.autoLabel1.Location = new System.Drawing.Point(5, 6);
            this.autoLabel1.Name = "autoLabel1";
            this.autoLabel1.Size = new System.Drawing.Size(85, 17);
            this.autoLabel1.TabIndex = 0;
            this.autoLabel1.Text = "Nama Grup *";
            // 
            // txtNamaGrup
            // 
            this.txtNamaGrup.BeforeTouchSize = new System.Drawing.Size(341, 25);
            this.txtNamaGrup.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtNamaGrup.Location = new System.Drawing.Point(123, 1);
            this.txtNamaGrup.Metrocolor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.txtNamaGrup.Name = "txtNamaGrup";
            this.txtNamaGrup.Size = new System.Drawing.Size(341, 25);
            this.txtNamaGrup.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Default;
            this.txtNamaGrup.TabIndex = 1;
            // 
            // autoLabel2
            // 
            this.autoLabel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.autoLabel2.Location = new System.Drawing.Point(3, 0);
            this.autoLabel2.Name = "autoLabel2";
            this.autoLabel2.Size = new System.Drawing.Size(322, 25);
            this.autoLabel2.TabIndex = 15;
            this.autoLabel2.Text = "Mata Kuliah";
            this.autoLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // autoLabel4
            // 
            this.autoLabel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.autoLabel4.Location = new System.Drawing.Point(331, 0);
            this.autoLabel4.Name = "autoLabel4";
            this.autoLabel4.Size = new System.Drawing.Size(497, 25);
            this.autoLabel4.TabIndex = 16;
            this.autoLabel4.Text = "Grup Mata Kuliah (MK urutan pertama menjadi tempat penyelenggaraan kuliah)";
            this.autoLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // gradientPanel2
            // 
            this.gradientPanel2.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat;
            this.gradientPanel2.Controls.Add(this.tableLayoutPanel1);
            this.gradientPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.gradientPanel2.Location = new System.Drawing.Point(0, 76);
            this.gradientPanel2.Name = "gradientPanel2";
            this.gradientPanel2.Size = new System.Drawing.Size(835, 284);
            this.gradientPanel2.TabIndex = 17;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 39.59085F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60.40915F));
            this.tableLayoutPanel1.Controls.Add(this.dgvMataKuliah, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.autoLabel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.autoLabel4, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.gradientPanel3, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.dgvGrupMK, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 159F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(831, 280);
            this.tableLayoutPanel1.TabIndex = 0;
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
            this.mKode,
            this.mMataKuliah});
            this.dgvMataKuliah.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMataKuliah.Location = new System.Drawing.Point(3, 28);
            this.dgvMataKuliah.Name = "dgvMataKuliah";
            this.dgvMataKuliah.ReadOnly = true;
            this.dgvMataKuliah.RowHeadersVisible = false;
            this.tableLayoutPanel1.SetRowSpan(this.dgvMataKuliah, 2);
            this.dgvMataKuliah.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMataKuliah.Size = new System.Drawing.Size(322, 178);
            this.dgvMataKuliah.TabIndex = 19;
            this.dgvMataKuliah.DragDrop += new System.Windows.Forms.DragEventHandler(this.dgvMataKuliah_DragDrop);
            this.dgvMataKuliah.DragEnter += new System.Windows.Forms.DragEventHandler(this.dgvMataKuliah_DragEnter);
            this.dgvMataKuliah.DragOver += new System.Windows.Forms.DragEventHandler(this.dgvMataKuliah_DragOver);
            this.dgvMataKuliah.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dgvMataKuliah_MouseDown);
            this.dgvMataKuliah.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dgvMataKuliah_MouseMove);
            // 
            // mKode
            // 
            this.mKode.HeaderText = "Kode";
            this.mKode.Name = "mKode";
            this.mKode.ReadOnly = true;
            // 
            // mMataKuliah
            // 
            this.mMataKuliah.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.mMataKuliah.HeaderText = "Mata Kuliah";
            this.mMataKuliah.Name = "mMataKuliah";
            this.mMataKuliah.ReadOnly = true;
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
            this.gradientPanel3.Location = new System.Drawing.Point(0, 209);
            this.gradientPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.gradientPanel3.Name = "gradientPanel3";
            this.gradientPanel3.Size = new System.Drawing.Size(831, 71);
            this.gradientPanel3.TabIndex = 17;
            // 
            // btnClear
            // 
            this.btnClear.BeforeTouchSize = new System.Drawing.Size(113, 30);
            this.btnClear.IsBackStageButton = false;
            this.btnClear.Location = new System.Drawing.Point(123, 32);
            this.btnClear.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(113, 30);
            this.btnClear.TabIndex = 3;
            this.btnClear.Text = "Clear";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnSimpan
            // 
            this.btnSimpan.BeforeTouchSize = new System.Drawing.Size(113, 30);
            this.btnSimpan.IsBackStageButton = false;
            this.btnSimpan.Location = new System.Drawing.Point(4, 32);
            this.btnSimpan.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSimpan.Name = "btnSimpan";
            this.btnSimpan.Size = new System.Drawing.Size(113, 30);
            this.btnSimpan.TabIndex = 2;
            this.btnSimpan.Text = "Simpan";
            this.btnSimpan.Click += new System.EventHandler(this.btnSimpan_Click);
            // 
            // dgvGrupMK
            // 
            this.dgvGrupMK.AllowDrop = true;
            this.dgvGrupMK.AllowUserToAddRows = false;
            this.dgvGrupMK.AllowUserToDeleteRows = false;
            this.dgvGrupMK.AllowUserToResizeRows = false;
            this.dgvGrupMK.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgvGrupMK.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGrupMK.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Kode,
            this.MataKuliah});
            this.dgvGrupMK.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvGrupMK.Location = new System.Drawing.Point(331, 28);
            this.dgvGrupMK.Name = "dgvGrupMK";
            this.dgvGrupMK.ReadOnly = true;
            this.dgvGrupMK.RowHeadersVisible = false;
            this.tableLayoutPanel1.SetRowSpan(this.dgvGrupMK, 2);
            this.dgvGrupMK.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvGrupMK.Size = new System.Drawing.Size(497, 178);
            this.dgvGrupMK.TabIndex = 18;
            this.dgvGrupMK.DragDrop += new System.Windows.Forms.DragEventHandler(this.dgvGrupMK_DragDrop);
            this.dgvGrupMK.DragEnter += new System.Windows.Forms.DragEventHandler(this.dgvGrupMK_DragEnter);
            this.dgvGrupMK.DragOver += new System.Windows.Forms.DragEventHandler(this.dgvGrupMK_DragOver);
            this.dgvGrupMK.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dgvGrupMK_MouseDown);
            this.dgvGrupMK.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dgvGrupMK_MouseMove);
            // 
            // Kode
            // 
            this.Kode.HeaderText = "Kode";
            this.Kode.Name = "Kode";
            this.Kode.ReadOnly = true;
            // 
            // MataKuliah
            // 
            this.MataKuliah.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.MataKuliah.HeaderText = "Mata Kuliah";
            this.MataKuliah.Name = "MataKuliah";
            this.MataKuliah.ReadOnly = true;
            // 
            // dgvDaftarGrup
            // 
            this.dgvDaftarGrup.AllowUserToAddRows = false;
            this.dgvDaftarGrup.AllowUserToDeleteRows = false;
            this.dgvDaftarGrup.AllowUserToResizeRows = false;
            this.dgvDaftarGrup.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDaftarGrup.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDaftarGrup.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDaftarGrup.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NamaGrup,
            this.KodeParent,
            this.gMataKuliah,
            this.KodeMember,
            this.gMataKuliahMember,
            this.Hapus});
            this.dgvDaftarGrup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDaftarGrup.Location = new System.Drawing.Point(0, 360);
            this.dgvDaftarGrup.Name = "dgvDaftarGrup";
            this.dgvDaftarGrup.RowHeadersVisible = false;
            this.dgvDaftarGrup.Size = new System.Drawing.Size(835, 62);
            this.dgvDaftarGrup.TabIndex = 18;
            // 
            // NamaGrup
            // 
            this.NamaGrup.HeaderText = "Nama Grup";
            this.NamaGrup.Name = "NamaGrup";
            this.NamaGrup.Width = 150;
            // 
            // KodeParent
            // 
            this.KodeParent.HeaderText = "Kode";
            this.KodeParent.Name = "KodeParent";
            this.KodeParent.Width = 80;
            // 
            // gMataKuliah
            // 
            this.gMataKuliah.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.gMataKuliah.HeaderText = "Mata Kuliah";
            this.gMataKuliah.Name = "gMataKuliah";
            // 
            // KodeMember
            // 
            this.KodeMember.HeaderText = "Kode Member";
            this.KodeMember.Name = "KodeMember";
            this.KodeMember.Width = 80;
            // 
            // gMataKuliahMember
            // 
            this.gMataKuliahMember.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.gMataKuliahMember.HeaderText = "Mata Kuliah Member";
            this.gMataKuliahMember.Name = "gMataKuliahMember";
            // 
            // Hapus
            // 
            this.Hapus.HeaderText = "Hapus";
            this.Hapus.Name = "Hapus";
            this.Hapus.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Hapus.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Hapus.Width = 60;
            // 
            // FormGrupMK
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CaptionFont = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClientSize = new System.Drawing.Size(835, 460);
            this.Controls.Add(this.dgvDaftarGrup);
            this.Controls.Add(this.gradientPanel2);
            this.Controls.Add(this.gradientPanel1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FormGrupMK";
            this.Text = "Grup Mata Kuliah Lintas Prodi";
            this.Load += new System.EventHandler(this.FormMappingMataKuliahLintasProdi_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gradientPanel1)).EndInit();
            this.gradientPanel1.ResumeLayout(false);
            this.gradientPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbProdi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbFakultas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNamaGrup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gradientPanel2)).EndInit();
            this.gradientPanel2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMataKuliah)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gradientPanel3)).EndInit();
            this.gradientPanel3.ResumeLayout(false);
            this.gradientPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrupMK)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDaftarGrup)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private Syncfusion.Windows.Forms.ButtonAdv btnTutup;
        private System.Windows.Forms.ProgressBar progressBar1;
        private Syncfusion.Windows.Forms.Tools.GradientPanel gradientPanel1;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtNamaGrup;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel1;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel15;
        private Syncfusion.Windows.Forms.Tools.ComboBoxAdv cmbProdi;
        private Syncfusion.Windows.Forms.Tools.ComboBoxAdv cmbFakultas;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel3;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel4;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel2;
        private Syncfusion.Windows.Forms.Tools.GradientPanel gradientPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Syncfusion.Windows.Forms.Tools.GradientPanel gradientPanel3;
        private Syncfusion.Windows.Forms.ButtonAdv btnClear;
        private Syncfusion.Windows.Forms.ButtonAdv btnSimpan;
        private System.Windows.Forms.DataGridView dgvDaftarGrup;
        private System.Windows.Forms.DataGridView dgvGrupMK;
        private System.Windows.Forms.DataGridViewTextBoxColumn Kode;
        private System.Windows.Forms.DataGridViewTextBoxColumn MataKuliah;
        private System.Windows.Forms.DataGridView dgvMataKuliah;
        private System.Windows.Forms.DataGridViewTextBoxColumn mKode;
        private System.Windows.Forms.DataGridViewTextBoxColumn mMataKuliah;
        private System.Windows.Forms.DataGridViewTextBoxColumn NamaGrup;
        private System.Windows.Forms.DataGridViewTextBoxColumn KodeParent;
        private System.Windows.Forms.DataGridViewTextBoxColumn gMataKuliah;
        private System.Windows.Forms.DataGridViewTextBoxColumn KodeMember;
        private System.Windows.Forms.DataGridViewTextBoxColumn gMataKuliahMember;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Hapus;
        private Syncfusion.Windows.Forms.ButtonAdv btnHapus;
    }
}