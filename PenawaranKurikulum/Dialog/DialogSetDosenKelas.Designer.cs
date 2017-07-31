#region Copyright Syncfusion Inc. 2001 - 2016
// Copyright Syncfusion Inc. 2001 - 2016. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
namespace PenawaranKurikulum.Dialog
{
    partial class DialogSetDosenKelas
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
            this.dgvKelas = new System.Windows.Forms.DataGridView();
            this.btnSetKelas = new Syncfusion.Windows.Forms.ButtonAdv();
            this.panel1 = new System.Windows.Forms.Panel();
            this.autoLabel1 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.txtKode = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            this.txtNik = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            this.autoLabel3 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.autoLabel4 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.txtNamaDosen = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            this.Pilih = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.IdKelas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NamaKelas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKelas)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtKode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNik)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNamaDosen)).BeginInit();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnTutup);
            this.flowLayoutPanel1.Controls.Add(this.btnSetKelas);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 318);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(365, 34);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // btnTutup
            // 
            this.btnTutup.BeforeTouchSize = new System.Drawing.Size(89, 28);
            this.btnTutup.IsBackStageButton = false;
            this.btnTutup.Location = new System.Drawing.Point(273, 3);
            this.btnTutup.Name = "btnTutup";
            this.btnTutup.Size = new System.Drawing.Size(89, 28);
            this.btnTutup.TabIndex = 0;
            this.btnTutup.Text = "Tutup";
            this.btnTutup.Click += new System.EventHandler(this.btnTutup_Click);
            // 
            // dgvKelas
            // 
            this.dgvKelas.AllowUserToAddRows = false;
            this.dgvKelas.AllowUserToDeleteRows = false;
            this.dgvKelas.AllowUserToResizeColumns = false;
            this.dgvKelas.AllowUserToResizeRows = false;
            this.dgvKelas.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgvKelas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKelas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Pilih,
            this.IdKelas,
            this.NamaKelas});
            this.dgvKelas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvKelas.Location = new System.Drawing.Point(0, 113);
            this.dgvKelas.MultiSelect = false;
            this.dgvKelas.Name = "dgvKelas";
            this.dgvKelas.RowHeadersVisible = false;
            this.dgvKelas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvKelas.Size = new System.Drawing.Size(365, 205);
            this.dgvKelas.TabIndex = 1;
            this.dgvKelas.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvKelas_CellClick);
            // 
            // btnSetKelas
            // 
            this.btnSetKelas.BeforeTouchSize = new System.Drawing.Size(89, 28);
            this.btnSetKelas.IsBackStageButton = false;
            this.btnSetKelas.Location = new System.Drawing.Point(178, 3);
            this.btnSetKelas.Name = "btnSetKelas";
            this.btnSetKelas.Size = new System.Drawing.Size(89, 28);
            this.btnSetKelas.TabIndex = 1;
            this.btnSetKelas.Text = "Set Kelas";
            this.btnSetKelas.Click += new System.EventHandler(this.btnSetKelas_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.autoLabel4);
            this.panel1.Controls.Add(this.txtNamaDosen);
            this.panel1.Controls.Add(this.autoLabel3);
            this.panel1.Controls.Add(this.txtNik);
            this.panel1.Controls.Add(this.txtKode);
            this.panel1.Controls.Add(this.autoLabel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(365, 113);
            this.panel1.TabIndex = 2;
            // 
            // autoLabel1
            // 
            this.autoLabel1.Location = new System.Drawing.Point(12, 13);
            this.autoLabel1.Name = "autoLabel1";
            this.autoLabel1.Size = new System.Drawing.Size(39, 17);
            this.autoLabel1.TabIndex = 0;
            this.autoLabel1.Text = "Kode";
            // 
            // txtKode
            // 
            this.txtKode.BeforeTouchSize = new System.Drawing.Size(244, 25);
            this.txtKode.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtKode.Enabled = false;
            this.txtKode.Location = new System.Drawing.Point(109, 9);
            this.txtKode.Metrocolor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.txtKode.Name = "txtKode";
            this.txtKode.Size = new System.Drawing.Size(126, 25);
            this.txtKode.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Default;
            this.txtKode.TabIndex = 2;
            // 
            // txtNik
            // 
            this.txtNik.BeforeTouchSize = new System.Drawing.Size(244, 25);
            this.txtNik.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtNik.Enabled = false;
            this.txtNik.Location = new System.Drawing.Point(109, 40);
            this.txtNik.Metrocolor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.txtNik.Name = "txtNik";
            this.txtNik.Size = new System.Drawing.Size(244, 25);
            this.txtNik.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Default;
            this.txtNik.TabIndex = 3;
            // 
            // autoLabel3
            // 
            this.autoLabel3.Location = new System.Drawing.Point(12, 44);
            this.autoLabel3.Name = "autoLabel3";
            this.autoLabel3.Size = new System.Drawing.Size(29, 17);
            this.autoLabel3.TabIndex = 4;
            this.autoLabel3.Text = "NIK";
            // 
            // autoLabel4
            // 
            this.autoLabel4.Location = new System.Drawing.Point(12, 75);
            this.autoLabel4.Name = "autoLabel4";
            this.autoLabel4.Size = new System.Drawing.Size(84, 17);
            this.autoLabel4.TabIndex = 6;
            this.autoLabel4.Text = "Nama Dosen";
            // 
            // txtNamaDosen
            // 
            this.txtNamaDosen.BeforeTouchSize = new System.Drawing.Size(244, 25);
            this.txtNamaDosen.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtNamaDosen.Enabled = false;
            this.txtNamaDosen.Location = new System.Drawing.Point(109, 71);
            this.txtNamaDosen.Metrocolor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.txtNamaDosen.Name = "txtNamaDosen";
            this.txtNamaDosen.Size = new System.Drawing.Size(244, 25);
            this.txtNamaDosen.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Default;
            this.txtNamaDosen.TabIndex = 5;
            // 
            // Pilih
            // 
            this.Pilih.HeaderText = "Pilih";
            this.Pilih.Name = "Pilih";
            this.Pilih.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Pilih.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Pilih.Width = 45;
            // 
            // IdKelas
            // 
            this.IdKelas.HeaderText = "IdKelas";
            this.IdKelas.Name = "IdKelas";
            this.IdKelas.Visible = false;
            // 
            // NamaKelas
            // 
            this.NamaKelas.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.NamaKelas.HeaderText = "Nama Kelas";
            this.NamaKelas.Name = "NamaKelas";
            this.NamaKelas.ReadOnly = true;
            // 
            // DialogSetDosenKelas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CaptionFont = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClientSize = new System.Drawing.Size(365, 352);
            this.Controls.Add(this.dgvKelas);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DialogSetDosenKelas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "List Kelas";
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvKelas)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtKode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNik)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNamaDosen)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private Syncfusion.Windows.Forms.ButtonAdv btnTutup;
        private System.Windows.Forms.DataGridView dgvKelas;
        private Syncfusion.Windows.Forms.ButtonAdv btnSetKelas;
        private System.Windows.Forms.Panel panel1;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel3;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtNik;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtKode;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel1;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel4;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtNamaDosen;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Pilih;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdKelas;
        private System.Windows.Forms.DataGridViewTextBoxColumn NamaKelas;
    }
}