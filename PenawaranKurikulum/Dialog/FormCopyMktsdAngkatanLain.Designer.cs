#region Copyright Syncfusion Inc. 2001 - 2016
// Copyright Syncfusion Inc. 2001 - 2016. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
namespace PenawaranKurikulum.Dialog
{
    partial class FormCopyMktsdAngkatanLain
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
            this.autoLabel1 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.cmbAngkatan = new System.Windows.Forms.ComboBox();
            this.txtKode = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            this.txtMataKuliah = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            this.autoLabel2 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.autoLabel3 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.btnSimpan = new Syncfusion.Windows.Forms.ButtonAdv();
            this.btnTutup = new Syncfusion.Windows.Forms.ButtonAdv();
            this.cbDaftarkelas = new System.Windows.Forms.CheckBox();
            this.autoLabel4 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.txtJenisMK = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            ((System.ComponentModel.ISupportInitialize)(this.txtKode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMataKuliah)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtJenisMK)).BeginInit();
            this.SuspendLayout();
            // 
            // autoLabel1
            // 
            this.autoLabel1.Location = new System.Drawing.Point(12, 48);
            this.autoLabel1.Name = "autoLabel1";
            this.autoLabel1.Size = new System.Drawing.Size(77, 17);
            this.autoLabel1.TabIndex = 0;
            this.autoLabel1.Text = "Mata Kuliah";
            // 
            // cmbAngkatan
            // 
            this.cmbAngkatan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAngkatan.FormattingEnabled = true;
            this.cmbAngkatan.Location = new System.Drawing.Point(102, 105);
            this.cmbAngkatan.Name = "cmbAngkatan";
            this.cmbAngkatan.Size = new System.Drawing.Size(100, 25);
            this.cmbAngkatan.TabIndex = 1;
            // 
            // txtKode
            // 
            this.txtKode.BeforeTouchSize = new System.Drawing.Size(100, 25);
            this.txtKode.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtKode.Location = new System.Drawing.Point(102, 12);
            this.txtKode.Metrocolor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.txtKode.Name = "txtKode";
            this.txtKode.ReadOnly = true;
            this.txtKode.Size = new System.Drawing.Size(100, 25);
            this.txtKode.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Default;
            this.txtKode.TabIndex = 2;
            // 
            // txtMataKuliah
            // 
            this.txtMataKuliah.BeforeTouchSize = new System.Drawing.Size(100, 25);
            this.txtMataKuliah.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtMataKuliah.Location = new System.Drawing.Point(102, 43);
            this.txtMataKuliah.Metrocolor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.txtMataKuliah.Name = "txtMataKuliah";
            this.txtMataKuliah.ReadOnly = true;
            this.txtMataKuliah.Size = new System.Drawing.Size(305, 25);
            this.txtMataKuliah.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Default;
            this.txtMataKuliah.TabIndex = 3;
            // 
            // autoLabel2
            // 
            this.autoLabel2.Location = new System.Drawing.Point(12, 17);
            this.autoLabel2.Name = "autoLabel2";
            this.autoLabel2.Size = new System.Drawing.Size(39, 17);
            this.autoLabel2.TabIndex = 4;
            this.autoLabel2.Text = "Kode";
            // 
            // autoLabel3
            // 
            this.autoLabel3.Location = new System.Drawing.Point(12, 110);
            this.autoLabel3.Name = "autoLabel3";
            this.autoLabel3.Size = new System.Drawing.Size(62, 17);
            this.autoLabel3.TabIndex = 5;
            this.autoLabel3.Text = "Angkatan";
            // 
            // btnSimpan
            // 
            this.btnSimpan.BeforeTouchSize = new System.Drawing.Size(75, 28);
            this.btnSimpan.IsBackStageButton = false;
            this.btnSimpan.Location = new System.Drawing.Point(102, 144);
            this.btnSimpan.Name = "btnSimpan";
            this.btnSimpan.Size = new System.Drawing.Size(75, 28);
            this.btnSimpan.TabIndex = 6;
            this.btnSimpan.Text = "Simpan";
            this.btnSimpan.Click += new System.EventHandler(this.btnSimpan_Click);
            // 
            // btnTutup
            // 
            this.btnTutup.BeforeTouchSize = new System.Drawing.Size(75, 28);
            this.btnTutup.IsBackStageButton = false;
            this.btnTutup.Location = new System.Drawing.Point(183, 144);
            this.btnTutup.Name = "btnTutup";
            this.btnTutup.Size = new System.Drawing.Size(75, 28);
            this.btnTutup.TabIndex = 7;
            this.btnTutup.Text = "Tutup";
            this.btnTutup.Click += new System.EventHandler(this.btnTutup_Click);
            // 
            // cbDaftarkelas
            // 
            this.cbDaftarkelas.AutoSize = true;
            this.cbDaftarkelas.Enabled = false;
            this.cbDaftarkelas.Location = new System.Drawing.Point(208, 16);
            this.cbDaftarkelas.Name = "cbDaftarkelas";
            this.cbDaftarkelas.Size = new System.Drawing.Size(98, 21);
            this.cbDaftarkelas.TabIndex = 8;
            this.cbDaftarkelas.Text = "Daftar Kelas";
            this.cbDaftarkelas.UseVisualStyleBackColor = true;
            // 
            // autoLabel4
            // 
            this.autoLabel4.Location = new System.Drawing.Point(12, 79);
            this.autoLabel4.Name = "autoLabel4";
            this.autoLabel4.Size = new System.Drawing.Size(60, 17);
            this.autoLabel4.TabIndex = 9;
            this.autoLabel4.Text = "Jenis MK";
            // 
            // txtJenisMK
            // 
            this.txtJenisMK.BeforeTouchSize = new System.Drawing.Size(100, 25);
            this.txtJenisMK.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtJenisMK.Location = new System.Drawing.Point(102, 74);
            this.txtJenisMK.Metrocolor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.txtJenisMK.Name = "txtJenisMK";
            this.txtJenisMK.ReadOnly = true;
            this.txtJenisMK.Size = new System.Drawing.Size(100, 25);
            this.txtJenisMK.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Default;
            this.txtJenisMK.TabIndex = 10;
            // 
            // FormCopyMktsdAngkatanLain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CaptionFont = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClientSize = new System.Drawing.Size(420, 178);
            this.Controls.Add(this.txtJenisMK);
            this.Controls.Add(this.autoLabel4);
            this.Controls.Add(this.cbDaftarkelas);
            this.Controls.Add(this.btnTutup);
            this.Controls.Add(this.btnSimpan);
            this.Controls.Add(this.autoLabel3);
            this.Controls.Add(this.autoLabel2);
            this.Controls.Add(this.txtMataKuliah);
            this.Controls.Add(this.txtKode);
            this.Controls.Add(this.cmbAngkatan);
            this.Controls.Add(this.autoLabel1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormCopyMktsdAngkatanLain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Penawaran untuk Angkatan Lain";
            this.Load += new System.EventHandler(this.FormCopyMktsdAngkatanLain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtKode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMataKuliah)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtJenisMK)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel1;
        private System.Windows.Forms.ComboBox cmbAngkatan;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtKode;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtMataKuliah;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel2;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel3;
        private Syncfusion.Windows.Forms.ButtonAdv btnSimpan;
        private Syncfusion.Windows.Forms.ButtonAdv btnTutup;
        private System.Windows.Forms.CheckBox cbDaftarkelas;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel4;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtJenisMK;
    }
}