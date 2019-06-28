#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
namespace KonversiAlihJalur.Dialog
{
    partial class FormMataKuliah
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
            this.btnPilih = new Syncfusion.Windows.Forms.ButtonAdv();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtSksLama = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtMataKuliahLama = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtKodeLama = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvMataKuliah = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCari = new System.Windows.Forms.TextBox();
            this.No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Kode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MataKuliah = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nilai = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMataKuliah)).BeginInit();
            this.panel2.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnTutup);
            this.flowLayoutPanel1.Controls.Add(this.btnPilih);
            this.flowLayoutPanel1.Controls.Add(this.progressBar1);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 325);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(2, 5, 2, 5);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(569, 38);
            this.flowLayoutPanel1.TabIndex = 25;
            // 
            // btnTutup
            // 
            this.btnTutup.BeforeTouchSize = new System.Drawing.Size(126, 28);
            this.btnTutup.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTutup.IsBackStageButton = false;
            this.btnTutup.Location = new System.Drawing.Point(441, 5);
            this.btnTutup.Margin = new System.Windows.Forms.Padding(2, 5, 2, 5);
            this.btnTutup.Name = "btnTutup";
            this.btnTutup.Size = new System.Drawing.Size(126, 28);
            this.btnTutup.TabIndex = 0;
            this.btnTutup.Text = "Tutup";
            this.btnTutup.Click += new System.EventHandler(this.btnTutup_Click);
            // 
            // btnPilih
            // 
            this.btnPilih.BeforeTouchSize = new System.Drawing.Size(126, 28);
            this.btnPilih.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPilih.IsBackStageButton = false;
            this.btnPilih.Location = new System.Drawing.Point(311, 5);
            this.btnPilih.Margin = new System.Windows.Forms.Padding(2, 5, 2, 5);
            this.btnPilih.Name = "btnPilih";
            this.btnPilih.Size = new System.Drawing.Size(126, 28);
            this.btnPilih.TabIndex = 3;
            this.btnPilih.Text = "Pilih";
            this.btnPilih.Click += new System.EventHandler(this.btnPilih_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(53, 3);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(253, 30);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar1.TabIndex = 2;
            this.progressBar1.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtSksLama);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtMataKuliahLama);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtKodeLama);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(569, 102);
            this.panel1.TabIndex = 26;
            // 
            // txtSksLama
            // 
            this.txtSksLama.Location = new System.Drawing.Point(130, 74);
            this.txtSksLama.Name = "txtSksLama";
            this.txtSksLama.ReadOnly = true;
            this.txtSksLama.Size = new System.Drawing.Size(125, 25);
            this.txtSksLama.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 77);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 17);
            this.label4.TabIndex = 4;
            this.label4.Text = "Sks Lama";
            // 
            // txtMataKuliahLama
            // 
            this.txtMataKuliahLama.Location = new System.Drawing.Point(130, 43);
            this.txtMataKuliahLama.Name = "txtMataKuliahLama";
            this.txtMataKuliahLama.ReadOnly = true;
            this.txtMataKuliahLama.Size = new System.Drawing.Size(356, 25);
            this.txtMataKuliahLama.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Mata Kuliah Lama";
            // 
            // txtKodeLama
            // 
            this.txtKodeLama.Location = new System.Drawing.Point(130, 12);
            this.txtKodeLama.Name = "txtKodeLama";
            this.txtKodeLama.ReadOnly = true;
            this.txtKodeLama.Size = new System.Drawing.Size(125, 25);
            this.txtKodeLama.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Kode Lama";
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
            this.Kode,
            this.MataKuliah,
            this.Sks,
            this.Nilai});
            this.dgvMataKuliah.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMataKuliah.Location = new System.Drawing.Point(0, 35);
            this.dgvMataKuliah.MultiSelect = false;
            this.dgvMataKuliah.Name = "dgvMataKuliah";
            this.dgvMataKuliah.RowHeadersVisible = false;
            this.dgvMataKuliah.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMataKuliah.Size = new System.Drawing.Size(569, 188);
            this.dgvMataKuliah.TabIndex = 27;
            this.dgvMataKuliah.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMataKuliah_CellClick);
            this.dgvMataKuliah.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMataKuliah_CellDoubleClick);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgvMataKuliah);
            this.panel2.Controls.Add(this.flowLayoutPanel2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 102);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(569, 223);
            this.panel2.TabIndex = 4;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.label3);
            this.flowLayoutPanel2.Controls.Add(this.txtCari);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(569, 35);
            this.flowLayoutPanel2.TabIndex = 28;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 31);
            this.label3.TabIndex = 1;
            this.label3.Text = "Cari";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtCari
            // 
            this.txtCari.Location = new System.Drawing.Point(40, 3);
            this.txtCari.Name = "txtCari";
            this.txtCari.Size = new System.Drawing.Size(324, 25);
            this.txtCari.TabIndex = 2;
            this.txtCari.TextChanged += new System.EventHandler(this.txtCari_TextChanged);
            // 
            // No
            // 
            this.No.HeaderText = "No";
            this.No.Name = "No";
            this.No.ReadOnly = true;
            this.No.Width = 51;
            // 
            // Kode
            // 
            this.Kode.HeaderText = "Kode";
            this.Kode.Name = "Kode";
            this.Kode.ReadOnly = true;
            this.Kode.Width = 64;
            // 
            // MataKuliah
            // 
            this.MataKuliah.HeaderText = "Mata Kuliah";
            this.MataKuliah.Name = "MataKuliah";
            this.MataKuliah.ReadOnly = true;
            this.MataKuliah.Width = 102;
            // 
            // Sks
            // 
            this.Sks.HeaderText = "Sks";
            this.Sks.Name = "Sks";
            this.Sks.ReadOnly = true;
            this.Sks.Width = 52;
            // 
            // Nilai
            // 
            this.Nilai.HeaderText = "Nilai";
            this.Nilai.Items.AddRange(new object[] {
            "Pilih",
            "A",
            "B",
            "C",
            "D",
            "E"});
            this.Nilai.Name = "Nilai";
            this.Nilai.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Nilai.Width = 40;
            // 
            // FormMataKuliah
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CaptionFont = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClientSize = new System.Drawing.Size(569, 363);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormMataKuliah";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mata Kuliah Baru";
            this.Load += new System.EventHandler(this.FormMataKuliah_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMataKuliah)).EndInit();
            this.panel2.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private Syncfusion.Windows.Forms.ButtonAdv btnTutup;
        private Syncfusion.Windows.Forms.ButtonAdv btnPilih;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvMataKuliah;
        private System.Windows.Forms.TextBox txtMataKuliahLama;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtKodeLama;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCari;
        private System.Windows.Forms.TextBox txtSksLama;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridViewTextBoxColumn No;
        private System.Windows.Forms.DataGridViewTextBoxColumn Kode;
        private System.Windows.Forms.DataGridViewTextBoxColumn MataKuliah;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sks;
        private System.Windows.Forms.DataGridViewComboBoxColumn Nilai;
    }
}