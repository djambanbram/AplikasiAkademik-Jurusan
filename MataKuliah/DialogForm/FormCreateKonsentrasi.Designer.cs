#region Copyright Syncfusion Inc. 2001 - 2016
// Copyright Syncfusion Inc. 2001 - 2016. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
namespace MataKuliah.DialogForm
{
    partial class FormCreateKonsentrasi
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
            this.txtNamaKonsentrasi = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            this.txtNamaEn = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            this.autoLabel2 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.txtSingkatan = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            this.autoLabel3 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.btnTutup = new Syncfusion.Windows.Forms.ButtonAdv();
            this.btnSimpan = new Syncfusion.Windows.Forms.ButtonAdv();
            ((System.ComponentModel.ISupportInitialize)(this.txtNamaKonsentrasi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNamaEn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSingkatan)).BeginInit();
            this.SuspendLayout();
            // 
            // autoLabel1
            // 
            this.autoLabel1.Location = new System.Drawing.Point(12, 13);
            this.autoLabel1.Name = "autoLabel1";
            this.autoLabel1.Size = new System.Drawing.Size(124, 17);
            this.autoLabel1.TabIndex = 0;
            this.autoLabel1.Text = "Nama Konsentrasi *";
            // 
            // txtNamaKonsentrasi
            // 
            this.txtNamaKonsentrasi.BeforeTouchSize = new System.Drawing.Size(304, 25);
            this.txtNamaKonsentrasi.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtNamaKonsentrasi.Location = new System.Drawing.Point(168, 9);
            this.txtNamaKonsentrasi.Metrocolor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.txtNamaKonsentrasi.Name = "txtNamaKonsentrasi";
            this.txtNamaKonsentrasi.Size = new System.Drawing.Size(304, 25);
            this.txtNamaKonsentrasi.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Default;
            this.txtNamaKonsentrasi.TabIndex = 1;
            // 
            // txtNamaEn
            // 
            this.txtNamaEn.BeforeTouchSize = new System.Drawing.Size(304, 25);
            this.txtNamaEn.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtNamaEn.Location = new System.Drawing.Point(168, 40);
            this.txtNamaEn.Metrocolor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.txtNamaEn.Name = "txtNamaEn";
            this.txtNamaEn.Size = new System.Drawing.Size(304, 25);
            this.txtNamaEn.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Default;
            this.txtNamaEn.TabIndex = 3;
            // 
            // autoLabel2
            // 
            this.autoLabel2.Location = new System.Drawing.Point(12, 44);
            this.autoLabel2.Name = "autoLabel2";
            this.autoLabel2.Size = new System.Drawing.Size(150, 17);
            this.autoLabel2.TabIndex = 2;
            this.autoLabel2.Text = "Nama Konsentrasi (en) *";
            // 
            // txtSingkatan
            // 
            this.txtSingkatan.BeforeTouchSize = new System.Drawing.Size(304, 25);
            this.txtSingkatan.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSingkatan.Location = new System.Drawing.Point(168, 71);
            this.txtSingkatan.Metrocolor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.txtSingkatan.Name = "txtSingkatan";
            this.txtSingkatan.Size = new System.Drawing.Size(304, 25);
            this.txtSingkatan.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Default;
            this.txtSingkatan.TabIndex = 5;
            // 
            // autoLabel3
            // 
            this.autoLabel3.Location = new System.Drawing.Point(12, 75);
            this.autoLabel3.Name = "autoLabel3";
            this.autoLabel3.Size = new System.Drawing.Size(73, 17);
            this.autoLabel3.TabIndex = 4;
            this.autoLabel3.Text = "Singkatan *";
            // 
            // btnTutup
            // 
            this.btnTutup.BeforeTouchSize = new System.Drawing.Size(93, 28);
            this.btnTutup.IsBackStageButton = false;
            this.btnTutup.Location = new System.Drawing.Point(379, 102);
            this.btnTutup.Name = "btnTutup";
            this.btnTutup.Size = new System.Drawing.Size(93, 28);
            this.btnTutup.TabIndex = 6;
            this.btnTutup.Text = "Tutup";
            this.btnTutup.Click += new System.EventHandler(this.btnTutup_Click);
            // 
            // btnSimpan
            // 
            this.btnSimpan.BeforeTouchSize = new System.Drawing.Size(93, 28);
            this.btnSimpan.IsBackStageButton = false;
            this.btnSimpan.Location = new System.Drawing.Point(280, 102);
            this.btnSimpan.Name = "btnSimpan";
            this.btnSimpan.Size = new System.Drawing.Size(93, 28);
            this.btnSimpan.TabIndex = 7;
            this.btnSimpan.Text = "Simpan";
            this.btnSimpan.Click += new System.EventHandler(this.btnSimpan_Click);
            // 
            // FormCreateKonsentrasi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CaptionFont = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClientSize = new System.Drawing.Size(484, 137);
            this.Controls.Add(this.btnSimpan);
            this.Controls.Add(this.btnTutup);
            this.Controls.Add(this.txtSingkatan);
            this.Controls.Add(this.autoLabel3);
            this.Controls.Add(this.txtNamaEn);
            this.Controls.Add(this.autoLabel2);
            this.Controls.Add(this.txtNamaKonsentrasi);
            this.Controls.Add(this.autoLabel1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormCreateKonsentrasi";
            this.Text = "Create Konsentrasi Mata Kuliah";
            ((System.ComponentModel.ISupportInitialize)(this.txtNamaKonsentrasi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNamaEn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSingkatan)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel1;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtNamaKonsentrasi;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtNamaEn;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel2;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtSingkatan;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel3;
        private Syncfusion.Windows.Forms.ButtonAdv btnTutup;
        private Syncfusion.Windows.Forms.ButtonAdv btnSimpan;
    }
}