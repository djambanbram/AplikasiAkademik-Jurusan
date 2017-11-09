#region Copyright Syncfusion Inc. 2001 - 2016
// Copyright Syncfusion Inc. 2001 - 2016. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
namespace KonversiAlihJalur.Dialog
{
    partial class FormCopyMKKonversi
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnTutup = new Syncfusion.Windows.Forms.ButtonAdv();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.gradientPanel2 = new Syncfusion.Windows.Forms.Tools.GradientPanel();
            this.btnCopy = new Syncfusion.Windows.Forms.ButtonAdv();
            this.autoLabel2 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.cmbAngkatanTarget = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            this.txtAlihJalur = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            this.autoLabel1 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.cmbAngkatanSumber = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            this.autoLabel15 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dgvAngkatanSumber = new System.Windows.Forms.DataGridView();
            this.dgvAngkatanTarget = new System.Windows.Forms.DataGridView();
            this.KodeD3Target = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MataKuliahD3Target = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KodeS1Target = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MataKuliahS1Target = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KodeD3Sumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MataKuliahD3Sumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KodeS1Sumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MataKuliahS1Sumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gradientPanel2)).BeginInit();
            this.gradientPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbAngkatanTarget)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAlihJalur)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbAngkatanSumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAngkatanSumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAngkatanTarget)).BeginInit();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnTutup);
            this.flowLayoutPanel1.Controls.Add(this.progressBar1);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 424);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(2, 5, 2, 5);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(894, 38);
            this.flowLayoutPanel1.TabIndex = 22;
            // 
            // btnTutup
            // 
            this.btnTutup.BeforeTouchSize = new System.Drawing.Size(126, 28);
            this.btnTutup.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTutup.IsBackStageButton = false;
            this.btnTutup.Location = new System.Drawing.Point(766, 5);
            this.btnTutup.Margin = new System.Windows.Forms.Padding(2, 5, 2, 5);
            this.btnTutup.Name = "btnTutup";
            this.btnTutup.Size = new System.Drawing.Size(126, 28);
            this.btnTutup.TabIndex = 0;
            this.btnTutup.Text = "Tutup";
            this.btnTutup.Click += new System.EventHandler(this.btnTutup_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(508, 3);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(253, 30);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar1.TabIndex = 1;
            this.progressBar1.Visible = false;
            // 
            // gradientPanel2
            // 
            this.gradientPanel2.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat;
            this.gradientPanel2.Controls.Add(this.btnCopy);
            this.gradientPanel2.Controls.Add(this.autoLabel2);
            this.gradientPanel2.Controls.Add(this.cmbAngkatanTarget);
            this.gradientPanel2.Controls.Add(this.txtAlihJalur);
            this.gradientPanel2.Controls.Add(this.autoLabel1);
            this.gradientPanel2.Controls.Add(this.cmbAngkatanSumber);
            this.gradientPanel2.Controls.Add(this.autoLabel15);
            this.gradientPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.gradientPanel2.Location = new System.Drawing.Point(0, 0);
            this.gradientPanel2.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.gradientPanel2.Name = "gradientPanel2";
            this.gradientPanel2.Size = new System.Drawing.Size(894, 74);
            this.gradientPanel2.TabIndex = 23;
            // 
            // btnCopy
            // 
            this.btnCopy.BeforeTouchSize = new System.Drawing.Size(102, 28);
            this.btnCopy.IsBackStageButton = false;
            this.btnCopy.Location = new System.Drawing.Point(429, 35);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(102, 28);
            this.btnCopy.TabIndex = 14;
            this.btnCopy.Text = "Copy";
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // autoLabel2
            // 
            this.autoLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.autoLabel2.Location = new System.Drawing.Point(267, 43);
            this.autoLabel2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.autoLabel2.Name = "autoLabel2";
            this.autoLabel2.Size = new System.Drawing.Size(23, 16);
            this.autoLabel2.TabIndex = 13;
            this.autoLabel2.Text = "ke";
            // 
            // cmbAngkatanTarget
            // 
            this.cmbAngkatanTarget.BeforeTouchSize = new System.Drawing.Size(114, 24);
            this.cmbAngkatanTarget.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAngkatanTarget.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbAngkatanTarget.Location = new System.Drawing.Point(298, 39);
            this.cmbAngkatanTarget.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.cmbAngkatanTarget.Name = "cmbAngkatanTarget";
            this.cmbAngkatanTarget.Size = new System.Drawing.Size(114, 24);
            this.cmbAngkatanTarget.TabIndex = 12;
            this.cmbAngkatanTarget.SelectedIndexChanged += new System.EventHandler(this.cmbAngkatanTarget_SelectedIndexChanged);
            // 
            // txtAlihJalur
            // 
            this.txtAlihJalur.BeforeTouchSize = new System.Drawing.Size(267, 25);
            this.txtAlihJalur.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtAlihJalur.Location = new System.Drawing.Point(145, 7);
            this.txtAlihJalur.Metrocolor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.txtAlihJalur.Name = "txtAlihJalur";
            this.txtAlihJalur.ReadOnly = true;
            this.txtAlihJalur.Size = new System.Drawing.Size(267, 25);
            this.txtAlihJalur.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Default;
            this.txtAlihJalur.TabIndex = 11;
            // 
            // autoLabel1
            // 
            this.autoLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.autoLabel1.Location = new System.Drawing.Point(6, 43);
            this.autoLabel1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.autoLabel1.Name = "autoLabel1";
            this.autoLabel1.Size = new System.Drawing.Size(126, 16);
            this.autoLabel1.TabIndex = 10;
            this.autoLabel1.Text = "Copy dari Angkatan";
            // 
            // cmbAngkatanSumber
            // 
            this.cmbAngkatanSumber.BeforeTouchSize = new System.Drawing.Size(114, 24);
            this.cmbAngkatanSumber.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAngkatanSumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbAngkatanSumber.Location = new System.Drawing.Point(145, 39);
            this.cmbAngkatanSumber.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.cmbAngkatanSumber.Name = "cmbAngkatanSumber";
            this.cmbAngkatanSumber.Size = new System.Drawing.Size(114, 24);
            this.cmbAngkatanSumber.TabIndex = 9;
            this.cmbAngkatanSumber.SelectedIndexChanged += new System.EventHandler(this.cmbAngkatanSumber_SelectedIndexChanged);
            // 
            // autoLabel15
            // 
            this.autoLabel15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.autoLabel15.Location = new System.Drawing.Point(6, 10);
            this.autoLabel15.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.autoLabel15.Name = "autoLabel15";
            this.autoLabel15.Size = new System.Drawing.Size(117, 16);
            this.autoLabel15.TabIndex = 8;
            this.autoLabel15.Text = "Program Alih Jalur";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 74);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dgvAngkatanSumber);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgvAngkatanTarget);
            this.splitContainer1.Size = new System.Drawing.Size(894, 350);
            this.splitContainer1.SplitterDistance = 437;
            this.splitContainer1.TabIndex = 24;
            // 
            // dgvAngkatanSumber
            // 
            this.dgvAngkatanSumber.AllowUserToAddRows = false;
            this.dgvAngkatanSumber.AllowUserToDeleteRows = false;
            this.dgvAngkatanSumber.AllowUserToResizeRows = false;
            this.dgvAngkatanSumber.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgvAngkatanSumber.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAngkatanSumber.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.KodeD3Sumber,
            this.MataKuliahD3Sumber,
            this.KodeS1Sumber,
            this.MataKuliahS1Sumber});
            this.dgvAngkatanSumber.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAngkatanSumber.Location = new System.Drawing.Point(0, 0);
            this.dgvAngkatanSumber.Name = "dgvAngkatanSumber";
            this.dgvAngkatanSumber.ReadOnly = true;
            this.dgvAngkatanSumber.RowHeadersVisible = false;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvAngkatanSumber.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvAngkatanSumber.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAngkatanSumber.Size = new System.Drawing.Size(437, 350);
            this.dgvAngkatanSumber.TabIndex = 0;
            // 
            // dgvAngkatanTarget
            // 
            this.dgvAngkatanTarget.AllowUserToAddRows = false;
            this.dgvAngkatanTarget.AllowUserToDeleteRows = false;
            this.dgvAngkatanTarget.AllowUserToResizeRows = false;
            this.dgvAngkatanTarget.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgvAngkatanTarget.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAngkatanTarget.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.KodeD3Target,
            this.MataKuliahD3Target,
            this.KodeS1Target,
            this.MataKuliahS1Target});
            this.dgvAngkatanTarget.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAngkatanTarget.Location = new System.Drawing.Point(0, 0);
            this.dgvAngkatanTarget.Name = "dgvAngkatanTarget";
            this.dgvAngkatanTarget.ReadOnly = true;
            this.dgvAngkatanTarget.RowHeadersVisible = false;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvAngkatanTarget.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvAngkatanTarget.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAngkatanTarget.Size = new System.Drawing.Size(453, 350);
            this.dgvAngkatanTarget.TabIndex = 1;
            // 
            // KodeD3Target
            // 
            this.KodeD3Target.HeaderText = "Kode D3";
            this.KodeD3Target.Name = "KodeD3Target";
            this.KodeD3Target.ReadOnly = true;
            this.KodeD3Target.Width = 80;
            // 
            // MataKuliahD3Target
            // 
            this.MataKuliahD3Target.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.MataKuliahD3Target.HeaderText = "Mata Kuliah D3";
            this.MataKuliahD3Target.Name = "MataKuliahD3Target";
            this.MataKuliahD3Target.ReadOnly = true;
            // 
            // KodeS1Target
            // 
            this.KodeS1Target.HeaderText = "Kode S1";
            this.KodeS1Target.Name = "KodeS1Target";
            this.KodeS1Target.ReadOnly = true;
            this.KodeS1Target.Width = 80;
            // 
            // MataKuliahS1Target
            // 
            this.MataKuliahS1Target.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.MataKuliahS1Target.HeaderText = "Mata Kuliah S1";
            this.MataKuliahS1Target.Name = "MataKuliahS1Target";
            this.MataKuliahS1Target.ReadOnly = true;
            // 
            // KodeD3Sumber
            // 
            this.KodeD3Sumber.HeaderText = "Kode D3";
            this.KodeD3Sumber.Name = "KodeD3Sumber";
            this.KodeD3Sumber.ReadOnly = true;
            this.KodeD3Sumber.Width = 80;
            // 
            // MataKuliahD3Sumber
            // 
            this.MataKuliahD3Sumber.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.MataKuliahD3Sumber.HeaderText = "Mata Kuliah D3";
            this.MataKuliahD3Sumber.Name = "MataKuliahD3Sumber";
            this.MataKuliahD3Sumber.ReadOnly = true;
            // 
            // KodeS1Sumber
            // 
            this.KodeS1Sumber.HeaderText = "Kode S1";
            this.KodeS1Sumber.Name = "KodeS1Sumber";
            this.KodeS1Sumber.ReadOnly = true;
            this.KodeS1Sumber.Width = 80;
            // 
            // MataKuliahS1Sumber
            // 
            this.MataKuliahS1Sumber.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.MataKuliahS1Sumber.HeaderText = "Mata Kuliah S1";
            this.MataKuliahS1Sumber.Name = "MataKuliahS1Sumber";
            this.MataKuliahS1Sumber.ReadOnly = true;
            // 
            // FormCopyMKKonversi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CaptionFont = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClientSize = new System.Drawing.Size(894, 462);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.gradientPanel2);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormCopyMKKonversi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Copy Konversi MK";
            this.Load += new System.EventHandler(this.FormCopyMKKonversi_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gradientPanel2)).EndInit();
            this.gradientPanel2.ResumeLayout(false);
            this.gradientPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbAngkatanTarget)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAlihJalur)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbAngkatanSumber)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAngkatanSumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAngkatanTarget)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private Syncfusion.Windows.Forms.ButtonAdv btnTutup;
        private System.Windows.Forms.ProgressBar progressBar1;
        private Syncfusion.Windows.Forms.Tools.GradientPanel gradientPanel2;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel1;
        private Syncfusion.Windows.Forms.Tools.ComboBoxAdv cmbAngkatanSumber;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel15;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtAlihJalur;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel2;
        private Syncfusion.Windows.Forms.Tools.ComboBoxAdv cmbAngkatanTarget;
        private Syncfusion.Windows.Forms.ButtonAdv btnCopy;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dgvAngkatanSumber;
        private System.Windows.Forms.DataGridView dgvAngkatanTarget;
        private System.Windows.Forms.DataGridViewTextBoxColumn KodeD3Sumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn MataKuliahD3Sumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn KodeS1Sumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn MataKuliahS1Sumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn KodeD3Target;
        private System.Windows.Forms.DataGridViewTextBoxColumn MataKuliahD3Target;
        private System.Windows.Forms.DataGridViewTextBoxColumn KodeS1Target;
        private System.Windows.Forms.DataGridViewTextBoxColumn MataKuliahS1Target;
    }
}