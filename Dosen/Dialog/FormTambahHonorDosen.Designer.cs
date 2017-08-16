#region Copyright Syncfusion Inc. 2001 - 2016
// Copyright Syncfusion Inc. 2001 - 2016. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
namespace Dosen.Dialog
{
    partial class FormTambahHonorDosen
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
            this.cmbJenjangPendidikan = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            this.cmbGolongan = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            this.autoLabel2 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.autoLabel3 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.txtHonorFix = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            this.txtHonorVar = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            this.autoLabel4 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.autoLabel5 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.txtPajak = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            this.btnTutup = new Syncfusion.Windows.Forms.ButtonAdv();
            this.btnSimpan = new Syncfusion.Windows.Forms.ButtonAdv();
            ((System.ComponentModel.ISupportInitialize)(this.cmbJenjangPendidikan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbGolongan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHonorFix)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHonorVar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPajak)).BeginInit();
            this.SuspendLayout();
            // 
            // autoLabel1
            // 
            this.autoLabel1.Location = new System.Drawing.Point(12, 16);
            this.autoLabel1.Name = "autoLabel1";
            this.autoLabel1.Size = new System.Drawing.Size(52, 17);
            this.autoLabel1.TabIndex = 0;
            this.autoLabel1.Text = "Jenjang";
            // 
            // cmbJenjangPendidikan
            // 
            this.cmbJenjangPendidikan.BeforeTouchSize = new System.Drawing.Size(271, 25);
            this.cmbJenjangPendidikan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbJenjangPendidikan.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbJenjangPendidikan.Location = new System.Drawing.Point(103, 12);
            this.cmbJenjangPendidikan.Name = "cmbJenjangPendidikan";
            this.cmbJenjangPendidikan.Size = new System.Drawing.Size(271, 25);
            this.cmbJenjangPendidikan.TabIndex = 1;
            // 
            // cmbGolongan
            // 
            this.cmbGolongan.BeforeTouchSize = new System.Drawing.Size(271, 25);
            this.cmbGolongan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGolongan.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbGolongan.Location = new System.Drawing.Point(103, 43);
            this.cmbGolongan.Name = "cmbGolongan";
            this.cmbGolongan.Size = new System.Drawing.Size(271, 25);
            this.cmbGolongan.TabIndex = 3;
            // 
            // autoLabel2
            // 
            this.autoLabel2.Location = new System.Drawing.Point(12, 47);
            this.autoLabel2.Name = "autoLabel2";
            this.autoLabel2.Size = new System.Drawing.Size(65, 17);
            this.autoLabel2.TabIndex = 2;
            this.autoLabel2.Text = "Golongan";
            // 
            // autoLabel3
            // 
            this.autoLabel3.Location = new System.Drawing.Point(12, 78);
            this.autoLabel3.Name = "autoLabel3";
            this.autoLabel3.Size = new System.Drawing.Size(64, 17);
            this.autoLabel3.TabIndex = 4;
            this.autoLabel3.Text = "Honor Fix";
            // 
            // txtHonorFix
            // 
            this.txtHonorFix.BeforeTouchSize = new System.Drawing.Size(239, 25);
            this.txtHonorFix.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtHonorFix.Location = new System.Drawing.Point(103, 74);
            this.txtHonorFix.Metrocolor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.txtHonorFix.Name = "txtHonorFix";
            this.txtHonorFix.Size = new System.Drawing.Size(271, 25);
            this.txtHonorFix.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Default;
            this.txtHonorFix.TabIndex = 5;
            this.txtHonorFix.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtHonor_KeyPress);
            // 
            // txtHonorVar
            // 
            this.txtHonorVar.BeforeTouchSize = new System.Drawing.Size(239, 25);
            this.txtHonorVar.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtHonorVar.Location = new System.Drawing.Point(103, 105);
            this.txtHonorVar.Metrocolor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.txtHonorVar.Name = "txtHonorVar";
            this.txtHonorVar.Size = new System.Drawing.Size(271, 25);
            this.txtHonorVar.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Default;
            this.txtHonorVar.TabIndex = 7;
            this.txtHonorVar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtHonor_KeyPress);
            // 
            // autoLabel4
            // 
            this.autoLabel4.Location = new System.Drawing.Point(12, 109);
            this.autoLabel4.Name = "autoLabel4";
            this.autoLabel4.Size = new System.Drawing.Size(68, 17);
            this.autoLabel4.TabIndex = 6;
            this.autoLabel4.Text = "Honor Var";
            // 
            // autoLabel5
            // 
            this.autoLabel5.Location = new System.Drawing.Point(12, 140);
            this.autoLabel5.Name = "autoLabel5";
            this.autoLabel5.Size = new System.Drawing.Size(38, 17);
            this.autoLabel5.TabIndex = 8;
            this.autoLabel5.Text = "Pajak";
            // 
            // txtPajak
            // 
            this.txtPajak.BeforeTouchSize = new System.Drawing.Size(239, 25);
            this.txtPajak.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPajak.Location = new System.Drawing.Point(103, 136);
            this.txtPajak.Metrocolor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.txtPajak.Name = "txtPajak";
            this.txtPajak.Size = new System.Drawing.Size(271, 25);
            this.txtPajak.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Default;
            this.txtPajak.TabIndex = 9;
            this.txtPajak.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtHonor_KeyPress);
            // 
            // btnTutup
            // 
            this.btnTutup.BeforeTouchSize = new System.Drawing.Size(109, 28);
            this.btnTutup.IsBackStageButton = false;
            this.btnTutup.Location = new System.Drawing.Point(265, 167);
            this.btnTutup.Name = "btnTutup";
            this.btnTutup.Size = new System.Drawing.Size(109, 28);
            this.btnTutup.TabIndex = 10;
            this.btnTutup.Text = "Tutup";
            this.btnTutup.Click += new System.EventHandler(this.btnTutup_Click);
            // 
            // btnSimpan
            // 
            this.btnSimpan.BeforeTouchSize = new System.Drawing.Size(109, 28);
            this.btnSimpan.IsBackStageButton = false;
            this.btnSimpan.Location = new System.Drawing.Point(150, 167);
            this.btnSimpan.Name = "btnSimpan";
            this.btnSimpan.Size = new System.Drawing.Size(109, 28);
            this.btnSimpan.TabIndex = 11;
            this.btnSimpan.Text = "Simpan";
            this.btnSimpan.Click += new System.EventHandler(this.btnSimpan_Click);
            // 
            // FormTambahHonorDosen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CaptionFont = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClientSize = new System.Drawing.Size(378, 198);
            this.Controls.Add(this.btnSimpan);
            this.Controls.Add(this.btnTutup);
            this.Controls.Add(this.txtPajak);
            this.Controls.Add(this.autoLabel5);
            this.Controls.Add(this.txtHonorVar);
            this.Controls.Add(this.autoLabel4);
            this.Controls.Add(this.txtHonorFix);
            this.Controls.Add(this.autoLabel3);
            this.Controls.Add(this.cmbGolongan);
            this.Controls.Add(this.autoLabel2);
            this.Controls.Add(this.cmbJenjangPendidikan);
            this.Controls.Add(this.autoLabel1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormTambahHonorDosen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Tambah Honor";
            this.Load += new System.EventHandler(this.FormTambahHonorDosen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cmbJenjangPendidikan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbGolongan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHonorFix)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHonorVar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPajak)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel1;
        private Syncfusion.Windows.Forms.Tools.ComboBoxAdv cmbJenjangPendidikan;
        private Syncfusion.Windows.Forms.Tools.ComboBoxAdv cmbGolongan;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel2;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel3;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtHonorFix;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtHonorVar;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel4;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel5;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtPajak;
        private Syncfusion.Windows.Forms.ButtonAdv btnTutup;
        private Syncfusion.Windows.Forms.ButtonAdv btnSimpan;
    }
}