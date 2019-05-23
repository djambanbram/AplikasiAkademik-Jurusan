#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
namespace MainAplikasi
{
    partial class FormPilihTahun
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
            this.txtTahunAkademik = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNamaSemester = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtIdTahun = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtKodeSemester = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtTahunAkademik
            // 
            this.txtTahunAkademik.Location = new System.Drawing.Point(130, 13);
            this.txtTahunAkademik.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtTahunAkademik.Name = "txtTahunAkademik";
            this.txtTahunAkademik.Size = new System.Drawing.Size(144, 25);
            this.txtTahunAkademik.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tahun Akademik";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Semester";
            // 
            // txtNamaSemester
            // 
            this.txtNamaSemester.Location = new System.Drawing.Point(130, 46);
            this.txtNamaSemester.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtNamaSemester.Name = "txtNamaSemester";
            this.txtNamaSemester.Size = new System.Drawing.Size(144, 25);
            this.txtNamaSemester.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 17);
            this.label2.TabIndex = 7;
            this.label2.Text = "Id Tahun";
            // 
            // txtIdTahun
            // 
            this.txtIdTahun.Location = new System.Drawing.Point(130, 79);
            this.txtIdTahun.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtIdTahun.Name = "txtIdTahun";
            this.txtIdTahun.Size = new System.Drawing.Size(144, 25);
            this.txtIdTahun.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 116);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 17);
            this.label4.TabIndex = 9;
            this.label4.Text = "Kode Semester";
            // 
            // txtKodeSemester
            // 
            this.txtKodeSemester.Location = new System.Drawing.Point(130, 112);
            this.txtKodeSemester.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtKodeSemester.Name = "txtKodeSemester";
            this.txtKodeSemester.Size = new System.Drawing.Size(144, 25);
            this.txtKodeSemester.TabIndex = 8;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(130, 144);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(84, 28);
            this.button1.TabIndex = 10;
            this.button1.Text = "Proses";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FormPilihTahun
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CaptionFont = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClientSize = new System.Drawing.Size(287, 175);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtKodeSemester);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtIdTahun);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtNamaSemester);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTahunAkademik);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FormPilihTahun";
            this.Text = "By Pass Tahun Aktif";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtTahunAkademik;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNamaSemester;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtIdTahun;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtKodeSemester;
        private System.Windows.Forms.Button button1;
    }
}