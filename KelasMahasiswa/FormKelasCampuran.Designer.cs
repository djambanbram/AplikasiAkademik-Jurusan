#region Copyright Syncfusion Inc. 2001 - 2016
// Copyright Syncfusion Inc. 2001 - 2016. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
namespace KelasMahasiswa
{
    partial class FormKelasCampuran
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
            this.gradientPanel2 = new Syncfusion.Windows.Forms.Tools.GradientPanel();
            this.autoLabel2 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.cmbProgram = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            this.autoLabel15 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.cmbProdi = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            this.cmbFakultas = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            this.autoLabel1 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.splitContainerAdv1 = new Syncfusion.Windows.Forms.Tools.SplitContainerAdv();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvJumlahKelas = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvKelasAktif = new System.Windows.Forms.DataGridView();
            this.gradientPanel1 = new Syncfusion.Windows.Forms.Tools.GradientPanel();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnCreateKelas = new Syncfusion.Windows.Forms.ButtonAdv();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gradientPanel2)).BeginInit();
            this.gradientPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbProgram)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbProdi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbFakultas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerAdv1)).BeginInit();
            this.splitContainerAdv1.Panel1.SuspendLayout();
            this.splitContainerAdv1.Panel2.SuspendLayout();
            this.splitContainerAdv1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvJumlahKelas)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKelasAktif)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gradientPanel1)).BeginInit();
            this.gradientPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnTutup);
            this.flowLayoutPanel1.Controls.Add(this.progressBar1);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 396);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(823, 38);
            this.flowLayoutPanel1.TabIndex = 11;
            // 
            // btnTutup
            // 
            this.btnTutup.BeforeTouchSize = new System.Drawing.Size(113, 30);
            this.btnTutup.IsBackStageButton = false;
            this.btnTutup.Location = new System.Drawing.Point(707, 4);
            this.btnTutup.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnTutup.Name = "btnTutup";
            this.btnTutup.Size = new System.Drawing.Size(113, 30);
            this.btnTutup.TabIndex = 0;
            this.btnTutup.Text = "Tutup";
            this.btnTutup.Click += new System.EventHandler(this.btnTutup_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(487, 3);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(214, 30);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar1.TabIndex = 1;
            this.progressBar1.Visible = false;
            // 
            // gradientPanel2
            // 
            this.gradientPanel2.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat;
            this.gradientPanel2.Controls.Add(this.autoLabel2);
            this.gradientPanel2.Controls.Add(this.cmbProgram);
            this.gradientPanel2.Controls.Add(this.autoLabel15);
            this.gradientPanel2.Controls.Add(this.cmbProdi);
            this.gradientPanel2.Controls.Add(this.cmbFakultas);
            this.gradientPanel2.Controls.Add(this.autoLabel1);
            this.gradientPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.gradientPanel2.Location = new System.Drawing.Point(0, 0);
            this.gradientPanel2.Name = "gradientPanel2";
            this.gradientPanel2.Size = new System.Drawing.Size(823, 103);
            this.gradientPanel2.TabIndex = 10;
            // 
            // autoLabel2
            // 
            this.autoLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.autoLabel2.Location = new System.Drawing.Point(7, 69);
            this.autoLabel2.Name = "autoLabel2";
            this.autoLabel2.Size = new System.Drawing.Size(60, 16);
            this.autoLabel2.TabIndex = 10;
            this.autoLabel2.Text = "Program";
            // 
            // cmbProgram
            // 
            this.cmbProgram.BeforeTouchSize = new System.Drawing.Size(361, 24);
            this.cmbProgram.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProgram.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbProgram.Location = new System.Drawing.Point(115, 67);
            this.cmbProgram.Name = "cmbProgram";
            this.cmbProgram.Size = new System.Drawing.Size(361, 24);
            this.cmbProgram.TabIndex = 9;
            this.cmbProgram.SelectedIndexChanged += new System.EventHandler(this.cmbProgram_SelectedIndexChanged);
            // 
            // autoLabel15
            // 
            this.autoLabel15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.autoLabel15.Location = new System.Drawing.Point(7, 39);
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
            this.cmbProdi.Location = new System.Drawing.Point(115, 37);
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
            this.cmbFakultas.Location = new System.Drawing.Point(115, 6);
            this.cmbFakultas.Name = "cmbFakultas";
            this.cmbFakultas.Size = new System.Drawing.Size(361, 25);
            this.cmbFakultas.TabIndex = 1;
            this.cmbFakultas.SelectedIndexChanged += new System.EventHandler(this.cmbFakultas_SelectedIndexChanged);
            // 
            // autoLabel1
            // 
            this.autoLabel1.Location = new System.Drawing.Point(8, 8);
            this.autoLabel1.Name = "autoLabel1";
            this.autoLabel1.Size = new System.Drawing.Size(54, 17);
            this.autoLabel1.TabIndex = 1;
            this.autoLabel1.Text = "Fakultas";
            // 
            // splitContainerAdv1
            // 
            this.splitContainerAdv1.BeforeTouchSize = 7;
            this.splitContainerAdv1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerAdv1.Location = new System.Drawing.Point(0, 38);
            this.splitContainerAdv1.Name = "splitContainerAdv1";
            // 
            // splitContainerAdv1.Panel1
            // 
            this.splitContainerAdv1.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainerAdv1.Panel2
            // 
            this.splitContainerAdv1.Panel2.Controls.Add(this.groupBox2);
            this.splitContainerAdv1.Size = new System.Drawing.Size(819, 251);
            this.splitContainerAdv1.SplitterDistance = 409;
            this.splitContainerAdv1.TabIndex = 12;
            this.splitContainerAdv1.Text = "splitContainerAdv1";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvJumlahKelas);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(409, 251);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Daftar MK Campuran";
            // 
            // dgvJumlahKelas
            // 
            this.dgvJumlahKelas.AllowUserToAddRows = false;
            this.dgvJumlahKelas.AllowUserToDeleteRows = false;
            this.dgvJumlahKelas.AllowUserToResizeRows = false;
            this.dgvJumlahKelas.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgvJumlahKelas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvJumlahKelas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvJumlahKelas.Location = new System.Drawing.Point(3, 21);
            this.dgvJumlahKelas.Name = "dgvJumlahKelas";
            this.dgvJumlahKelas.ReadOnly = true;
            this.dgvJumlahKelas.RowHeadersVisible = false;
            this.dgvJumlahKelas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvJumlahKelas.Size = new System.Drawing.Size(403, 227);
            this.dgvJumlahKelas.TabIndex = 11;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvKelasAktif);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(403, 251);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Daftar Kelas Campuran";
            // 
            // dgvKelasAktif
            // 
            this.dgvKelasAktif.AllowUserToAddRows = false;
            this.dgvKelasAktif.AllowUserToDeleteRows = false;
            this.dgvKelasAktif.AllowUserToResizeRows = false;
            this.dgvKelasAktif.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgvKelasAktif.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKelasAktif.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvKelasAktif.Location = new System.Drawing.Point(3, 21);
            this.dgvKelasAktif.Name = "dgvKelasAktif";
            this.dgvKelasAktif.ReadOnly = true;
            this.dgvKelasAktif.RowHeadersVisible = false;
            this.dgvKelasAktif.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvKelasAktif.Size = new System.Drawing.Size(397, 227);
            this.dgvKelasAktif.TabIndex = 10;
            // 
            // gradientPanel1
            // 
            this.gradientPanel1.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat;
            this.gradientPanel1.Controls.Add(this.splitContainerAdv1);
            this.gradientPanel1.Controls.Add(this.flowLayoutPanel2);
            this.gradientPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gradientPanel1.Location = new System.Drawing.Point(0, 103);
            this.gradientPanel1.Name = "gradientPanel1";
            this.gradientPanel1.Size = new System.Drawing.Size(823, 293);
            this.gradientPanel1.TabIndex = 13;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.btnCreateKelas);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(819, 38);
            this.flowLayoutPanel2.TabIndex = 13;
            // 
            // btnCreateKelas
            // 
            this.btnCreateKelas.BeforeTouchSize = new System.Drawing.Size(113, 30);
            this.btnCreateKelas.IsBackStageButton = false;
            this.btnCreateKelas.Location = new System.Drawing.Point(3, 4);
            this.btnCreateKelas.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCreateKelas.Name = "btnCreateKelas";
            this.btnCreateKelas.Size = new System.Drawing.Size(113, 30);
            this.btnCreateKelas.TabIndex = 1;
            this.btnCreateKelas.Text = "Create Kelas";
            this.btnCreateKelas.Click += new System.EventHandler(this.btnCreateKelas_Click);
            // 
            // FormKelasCampuran
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CaptionFont = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClientSize = new System.Drawing.Size(823, 434);
            this.Controls.Add(this.gradientPanel1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.gradientPanel2);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FormKelasCampuran";
            this.Text = "Kelas Campuran";
            this.Load += new System.EventHandler(this.FormKelasCampuran_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gradientPanel2)).EndInit();
            this.gradientPanel2.ResumeLayout(false);
            this.gradientPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbProgram)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbProdi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbFakultas)).EndInit();
            this.splitContainerAdv1.Panel1.ResumeLayout(false);
            this.splitContainerAdv1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerAdv1)).EndInit();
            this.splitContainerAdv1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvJumlahKelas)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvKelasAktif)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gradientPanel1)).EndInit();
            this.gradientPanel1.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private Syncfusion.Windows.Forms.ButtonAdv btnTutup;
        private System.Windows.Forms.ProgressBar progressBar1;
        private Syncfusion.Windows.Forms.Tools.GradientPanel gradientPanel2;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel2;
        private Syncfusion.Windows.Forms.Tools.ComboBoxAdv cmbProgram;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel15;
        private Syncfusion.Windows.Forms.Tools.ComboBoxAdv cmbProdi;
        private Syncfusion.Windows.Forms.Tools.ComboBoxAdv cmbFakultas;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel1;
        private Syncfusion.Windows.Forms.Tools.SplitContainerAdv splitContainerAdv1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvJumlahKelas;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvKelasAktif;
        private Syncfusion.Windows.Forms.Tools.GradientPanel gradientPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private Syncfusion.Windows.Forms.ButtonAdv btnCreateKelas;
    }
}