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
            this.gradientPanel1 = new Syncfusion.Windows.Forms.Tools.GradientPanel();
            this.autoLabel4 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.autoLabel3 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.cmbProgram = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            this.cmbProgramStudi = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            this.autoLabel2 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.cmbFakultas = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            this.buttonAdv1 = new Syncfusion.Windows.Forms.ButtonAdv();
            this.gradientPanel2 = new Syncfusion.Windows.Forms.Tools.GradientPanel();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gradientPanel1)).BeginInit();
            this.gradientPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbProgram)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbProgramStudi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbFakultas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gradientPanel2)).BeginInit();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnTutup);
            this.flowLayoutPanel1.Controls.Add(this.progressBar1);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 436);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(864, 38);
            this.flowLayoutPanel1.TabIndex = 3;
            // 
            // btnTutup
            // 
            this.btnTutup.BeforeTouchSize = new System.Drawing.Size(122, 30);
            this.btnTutup.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTutup.IsBackStageButton = false;
            this.btnTutup.Location = new System.Drawing.Point(739, 4);
            this.btnTutup.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnTutup.Name = "btnTutup";
            this.btnTutup.Size = new System.Drawing.Size(122, 30);
            this.btnTutup.TabIndex = 2;
            this.btnTutup.Text = "Tutup";
            this.btnTutup.Click += new System.EventHandler(this.btnTutup_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(532, 3);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(201, 30);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar1.TabIndex = 3;
            // 
            // gradientPanel1
            // 
            this.gradientPanel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.gradientPanel1.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat;
            this.gradientPanel1.Controls.Add(this.buttonAdv1);
            this.gradientPanel1.Controls.Add(this.autoLabel4);
            this.gradientPanel1.Controls.Add(this.autoLabel3);
            this.gradientPanel1.Controls.Add(this.cmbProgram);
            this.gradientPanel1.Controls.Add(this.cmbProgramStudi);
            this.gradientPanel1.Controls.Add(this.autoLabel2);
            this.gradientPanel1.Controls.Add(this.cmbFakultas);
            this.gradientPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.gradientPanel1.Location = new System.Drawing.Point(0, 0);
            this.gradientPanel1.Name = "gradientPanel1";
            this.gradientPanel1.Size = new System.Drawing.Size(864, 138);
            this.gradientPanel1.TabIndex = 4;
            // 
            // autoLabel4
            // 
            this.autoLabel4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.autoLabel4.Location = new System.Drawing.Point(7, 74);
            this.autoLabel4.Name = "autoLabel4";
            this.autoLabel4.Size = new System.Drawing.Size(60, 16);
            this.autoLabel4.TabIndex = 7;
            this.autoLabel4.Text = "Program";
            // 
            // autoLabel3
            // 
            this.autoLabel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.autoLabel3.Location = new System.Drawing.Point(7, 44);
            this.autoLabel3.Name = "autoLabel3";
            this.autoLabel3.Size = new System.Drawing.Size(93, 16);
            this.autoLabel3.TabIndex = 6;
            this.autoLabel3.Text = "Program Studi";
            // 
            // cmbProgram
            // 
            this.cmbProgram.BeforeTouchSize = new System.Drawing.Size(361, 24);
            this.cmbProgram.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProgram.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbProgram.Location = new System.Drawing.Point(123, 69);
            this.cmbProgram.Name = "cmbProgram";
            this.cmbProgram.Size = new System.Drawing.Size(361, 24);
            this.cmbProgram.TabIndex = 5;
            // 
            // cmbProgramStudi
            // 
            this.cmbProgramStudi.BeforeTouchSize = new System.Drawing.Size(361, 24);
            this.cmbProgramStudi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProgramStudi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbProgramStudi.Location = new System.Drawing.Point(123, 39);
            this.cmbProgramStudi.Name = "cmbProgramStudi";
            this.cmbProgramStudi.Size = new System.Drawing.Size(361, 24);
            this.cmbProgramStudi.TabIndex = 4;
            this.cmbProgramStudi.SelectedIndexChanged += new System.EventHandler(this.cmbProgramStudi_SelectedIndexChanged);
            // 
            // autoLabel2
            // 
            this.autoLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.autoLabel2.Location = new System.Drawing.Point(7, 14);
            this.autoLabel2.Name = "autoLabel2";
            this.autoLabel2.Size = new System.Drawing.Size(59, 16);
            this.autoLabel2.TabIndex = 3;
            this.autoLabel2.Text = "Fakultas";
            // 
            // cmbFakultas
            // 
            this.cmbFakultas.BeforeTouchSize = new System.Drawing.Size(361, 24);
            this.cmbFakultas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFakultas.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbFakultas.Location = new System.Drawing.Point(123, 9);
            this.cmbFakultas.Name = "cmbFakultas";
            this.cmbFakultas.Size = new System.Drawing.Size(361, 24);
            this.cmbFakultas.TabIndex = 2;
            this.cmbFakultas.SelectedIndexChanged += new System.EventHandler(this.cmbFakultas_SelectedIndexChanged);
            // 
            // buttonAdv1
            // 
            this.buttonAdv1.BeforeTouchSize = new System.Drawing.Size(104, 28);
            this.buttonAdv1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAdv1.IsBackStageButton = false;
            this.buttonAdv1.Location = new System.Drawing.Point(123, 99);
            this.buttonAdv1.Name = "buttonAdv1";
            this.buttonAdv1.Size = new System.Drawing.Size(104, 28);
            this.buttonAdv1.TabIndex = 9;
            this.buttonAdv1.Text = "Lihat Kelas";
            // 
            // gradientPanel2
            // 
            this.gradientPanel2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.gradientPanel2.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat;
            this.gradientPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gradientPanel2.Location = new System.Drawing.Point(0, 138);
            this.gradientPanel2.Name = "gradientPanel2";
            this.gradientPanel2.Size = new System.Drawing.Size(864, 298);
            this.gradientPanel2.TabIndex = 5;
            // 
            // FormKelasCampuran
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CaptionFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClientSize = new System.Drawing.Size(864, 474);
            this.Controls.Add(this.gradientPanel2);
            this.Controls.Add(this.gradientPanel1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "FormKelasCampuran";
            this.Text = "Kelas Campuran";
            this.Load += new System.EventHandler(this.FormKelasCampuran_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gradientPanel1)).EndInit();
            this.gradientPanel1.ResumeLayout(false);
            this.gradientPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbProgram)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbProgramStudi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbFakultas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gradientPanel2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private Syncfusion.Windows.Forms.ButtonAdv btnTutup;
        private System.Windows.Forms.ProgressBar progressBar1;
        private Syncfusion.Windows.Forms.Tools.GradientPanel gradientPanel1;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel4;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel3;
        private Syncfusion.Windows.Forms.Tools.ComboBoxAdv cmbProgram;
        private Syncfusion.Windows.Forms.Tools.ComboBoxAdv cmbProgramStudi;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel2;
        private Syncfusion.Windows.Forms.Tools.ComboBoxAdv cmbFakultas;
        private Syncfusion.Windows.Forms.ButtonAdv buttonAdv1;
        private Syncfusion.Windows.Forms.Tools.GradientPanel gradientPanel2;
    }
}