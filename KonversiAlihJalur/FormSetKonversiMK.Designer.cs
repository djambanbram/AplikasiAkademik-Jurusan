#region Copyright Syncfusion Inc. 2001 - 2016
// Copyright Syncfusion Inc. 2001 - 2016. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
namespace KonversiAlihJalur
{
    partial class FormSetKonversiMK
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
            this.gradientPanel2 = new Syncfusion.Windows.Forms.Tools.GradientPanel();
            this.autoLabel1 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.cmbAngkatan = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            this.autoLabel15 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.cmbProgramAlihJalur = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnTutup = new Syncfusion.Windows.Forms.ButtonAdv();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.treeGridView1 = new AdvancedDataGridView.TreeGridView();
            this.Tree = new AdvancedDataGridView.TreeGridColumn();
            this.KodeS1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MataKuliahS1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SksS1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KodeD3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MataKuliahD3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SksD3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gradientPanel2)).BeginInit();
            this.gradientPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbAngkatan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbProgramAlihJalur)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // gradientPanel2
            // 
            this.gradientPanel2.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat;
            this.gradientPanel2.Controls.Add(this.autoLabel1);
            this.gradientPanel2.Controls.Add(this.cmbAngkatan);
            this.gradientPanel2.Controls.Add(this.autoLabel15);
            this.gradientPanel2.Controls.Add(this.cmbProgramAlihJalur);
            this.gradientPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.gradientPanel2.Location = new System.Drawing.Point(0, 0);
            this.gradientPanel2.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.gradientPanel2.Name = "gradientPanel2";
            this.gradientPanel2.Size = new System.Drawing.Size(883, 74);
            this.gradientPanel2.TabIndex = 20;
            // 
            // autoLabel1
            // 
            this.autoLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.autoLabel1.Location = new System.Drawing.Point(6, 46);
            this.autoLabel1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.autoLabel1.Name = "autoLabel1";
            this.autoLabel1.Size = new System.Drawing.Size(65, 16);
            this.autoLabel1.TabIndex = 10;
            this.autoLabel1.Text = "Angkatan";
            // 
            // cmbAngkatan
            // 
            this.cmbAngkatan.BeforeTouchSize = new System.Drawing.Size(114, 24);
            this.cmbAngkatan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAngkatan.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbAngkatan.Location = new System.Drawing.Point(127, 39);
            this.cmbAngkatan.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.cmbAngkatan.Name = "cmbAngkatan";
            this.cmbAngkatan.Size = new System.Drawing.Size(114, 24);
            this.cmbAngkatan.TabIndex = 9;
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
            // cmbProgramAlihJalur
            // 
            this.cmbProgramAlihJalur.BeforeTouchSize = new System.Drawing.Size(282, 24);
            this.cmbProgramAlihJalur.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProgramAlihJalur.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbProgramAlihJalur.Location = new System.Drawing.Point(127, 7);
            this.cmbProgramAlihJalur.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.cmbProgramAlihJalur.Name = "cmbProgramAlihJalur";
            this.cmbProgramAlihJalur.Size = new System.Drawing.Size(282, 24);
            this.cmbProgramAlihJalur.TabIndex = 2;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnTutup);
            this.flowLayoutPanel1.Controls.Add(this.progressBar1);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 371);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(2, 5, 2, 5);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(883, 38);
            this.flowLayoutPanel1.TabIndex = 21;
            // 
            // btnTutup
            // 
            this.btnTutup.BeforeTouchSize = new System.Drawing.Size(126, 28);
            this.btnTutup.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTutup.IsBackStageButton = false;
            this.btnTutup.Location = new System.Drawing.Point(755, 5);
            this.btnTutup.Margin = new System.Windows.Forms.Padding(2, 5, 2, 5);
            this.btnTutup.Name = "btnTutup";
            this.btnTutup.Size = new System.Drawing.Size(126, 28);
            this.btnTutup.TabIndex = 0;
            this.btnTutup.Text = "Tutup";
            this.btnTutup.Click += new System.EventHandler(this.btnTutup_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(497, 3);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(253, 30);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar1.TabIndex = 1;
            this.progressBar1.Visible = false;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 74);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dataGridView1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.treeGridView1);
            this.splitContainer1.Size = new System.Drawing.Size(883, 297);
            this.splitContainer1.SplitterDistance = 356;
            this.splitContainer1.TabIndex = 22;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.KodeD3,
            this.MataKuliahD3,
            this.SksD3});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(356, 297);
            this.dataGridView1.TabIndex = 0;
            // 
            // treeGridView1
            // 
            this.treeGridView1.AllowUserToAddRows = false;
            this.treeGridView1.AllowUserToDeleteRows = false;
            this.treeGridView1.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.treeGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Tree,
            this.KodeS1,
            this.MataKuliahS1,
            this.SksS1});
            this.treeGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.treeGridView1.ImageList = null;
            this.treeGridView1.Location = new System.Drawing.Point(0, 0);
            this.treeGridView1.Name = "treeGridView1";
            this.treeGridView1.RowHeadersVisible = false;
            this.treeGridView1.Size = new System.Drawing.Size(523, 297);
            this.treeGridView1.TabIndex = 0;
            // 
            // Tree
            // 
            this.Tree.DefaultNodeImage = null;
            this.Tree.HeaderText = "";
            this.Tree.Name = "Tree";
            this.Tree.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Tree.Width = 30;
            // 
            // KodeS1
            // 
            this.KodeS1.HeaderText = "Kode S1";
            this.KodeS1.Name = "KodeS1";
            this.KodeS1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // MataKuliahS1
            // 
            this.MataKuliahS1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.MataKuliahS1.HeaderText = "Mata Kuliah S1";
            this.MataKuliahS1.Name = "MataKuliahS1";
            this.MataKuliahS1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // SksS1
            // 
            this.SksS1.HeaderText = "Sks S1";
            this.SksS1.Name = "SksS1";
            this.SksS1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // KodeD3
            // 
            this.KodeD3.HeaderText = "Kode D3";
            this.KodeD3.Name = "KodeD3";
            this.KodeD3.ReadOnly = true;
            // 
            // MataKuliahD3
            // 
            this.MataKuliahD3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.MataKuliahD3.HeaderText = "Mata Kuliah D3";
            this.MataKuliahD3.Name = "MataKuliahD3";
            this.MataKuliahD3.ReadOnly = true;
            // 
            // SksD3
            // 
            this.SksD3.HeaderText = "Sks D3";
            this.SksD3.Name = "SksD3";
            this.SksD3.ReadOnly = true;
            this.SksD3.Width = 50;
            // 
            // FormSetKonversiMK
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CaptionFont = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClientSize = new System.Drawing.Size(883, 409);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.gradientPanel2);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FormSetKonversiMK";
            this.Text = "Form Set Konversi MK";
            this.Load += new System.EventHandler(this.FormSetKonversiMK_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gradientPanel2)).EndInit();
            this.gradientPanel2.ResumeLayout(false);
            this.gradientPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbAngkatan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbProgramAlihJalur)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Syncfusion.Windows.Forms.Tools.GradientPanel gradientPanel2;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel1;
        private Syncfusion.Windows.Forms.Tools.ComboBoxAdv cmbAngkatan;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel15;
        private Syncfusion.Windows.Forms.Tools.ComboBoxAdv cmbProgramAlihJalur;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private Syncfusion.Windows.Forms.ButtonAdv btnTutup;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private AdvancedDataGridView.TreeGridView treeGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn KodeD3;
        private System.Windows.Forms.DataGridViewTextBoxColumn MataKuliahD3;
        private System.Windows.Forms.DataGridViewTextBoxColumn SksD3;
        private AdvancedDataGridView.TreeGridColumn Tree;
        private System.Windows.Forms.DataGridViewTextBoxColumn KodeS1;
        private System.Windows.Forms.DataGridViewTextBoxColumn MataKuliahS1;
        private System.Windows.Forms.DataGridViewTextBoxColumn SksS1;
    }
}