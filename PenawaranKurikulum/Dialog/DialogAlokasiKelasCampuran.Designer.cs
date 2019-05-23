#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
namespace PenawaranKurikulum.Dialog
{
    partial class DialogAlokasiKelasCampuran
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtKode = new System.Windows.Forms.TextBox();
            this.txtMataKuliah = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNamaKelas = new System.Windows.Forms.TextBox();
            this.numJumlahKelas = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.numKuota = new System.Windows.Forms.NumericUpDown();
            this.btnSImpan = new System.Windows.Forms.Button();
            this.btnTutup = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numJumlahKelas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numKuota)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Kode";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Mata Kuliah";
            // 
            // txtKode
            // 
            this.txtKode.Location = new System.Drawing.Point(105, 6);
            this.txtKode.Name = "txtKode";
            this.txtKode.ReadOnly = true;
            this.txtKode.Size = new System.Drawing.Size(93, 25);
            this.txtKode.TabIndex = 1;
            // 
            // txtMataKuliah
            // 
            this.txtMataKuliah.Location = new System.Drawing.Point(105, 37);
            this.txtMataKuliah.Name = "txtMataKuliah";
            this.txtMataKuliah.ReadOnly = true;
            this.txtMataKuliah.Size = new System.Drawing.Size(368, 25);
            this.txtMataKuliah.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Nama Kelas";
            // 
            // txtNamaKelas
            // 
            this.txtNamaKelas.Location = new System.Drawing.Point(105, 68);
            this.txtNamaKelas.Name = "txtNamaKelas";
            this.txtNamaKelas.Size = new System.Drawing.Size(238, 25);
            this.txtNamaKelas.TabIndex = 4;
            // 
            // numJumlahKelas
            // 
            this.numJumlahKelas.Location = new System.Drawing.Point(105, 99);
            this.numJumlahKelas.Name = "numJumlahKelas";
            this.numJumlahKelas.Size = new System.Drawing.Size(93, 25);
            this.numJumlahKelas.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 101);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "Jumlah Kelas";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 132);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 17);
            this.label5.TabIndex = 9;
            this.label5.Text = "Kuota";
            // 
            // numKuota
            // 
            this.numKuota.Location = new System.Drawing.Point(105, 130);
            this.numKuota.Name = "numKuota";
            this.numKuota.Size = new System.Drawing.Size(93, 25);
            this.numKuota.TabIndex = 6;
            // 
            // btnSImpan
            // 
            this.btnSImpan.Location = new System.Drawing.Point(105, 164);
            this.btnSImpan.Name = "btnSImpan";
            this.btnSImpan.Size = new System.Drawing.Size(75, 30);
            this.btnSImpan.TabIndex = 7;
            this.btnSImpan.Text = "Simpan";
            this.btnSImpan.UseVisualStyleBackColor = true;
            this.btnSImpan.Click += new System.EventHandler(this.btnSImpan_Click);
            // 
            // btnTutup
            // 
            this.btnTutup.Location = new System.Drawing.Point(186, 164);
            this.btnTutup.Name = "btnTutup";
            this.btnTutup.Size = new System.Drawing.Size(75, 30);
            this.btnTutup.TabIndex = 8;
            this.btnTutup.Text = "Tutup";
            this.btnTutup.UseVisualStyleBackColor = true;
            this.btnTutup.Click += new System.EventHandler(this.btnTutup_Click);
            // 
            // DialogAlokasiKelasCampuran
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CaptionFont = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClientSize = new System.Drawing.Size(485, 206);
            this.Controls.Add(this.btnTutup);
            this.Controls.Add(this.btnSImpan);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.numKuota);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.numJumlahKelas);
            this.Controls.Add(this.txtNamaKelas);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtMataKuliah);
            this.Controls.Add(this.txtKode);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DialogAlokasiKelasCampuran";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Create Kelas Pilihan / Konsentrasi";
            this.Load += new System.EventHandler(this.DialogAlokasiKelasCampuran_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numJumlahKelas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numKuota)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtKode;
        private System.Windows.Forms.TextBox txtMataKuliah;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNamaKelas;
        private System.Windows.Forms.NumericUpDown numJumlahKelas;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numKuota;
        private System.Windows.Forms.Button btnSImpan;
        private System.Windows.Forms.Button btnTutup;
    }
}