#region Copyright Syncfusion Inc. 2001 - 2016
// Copyright Syncfusion Inc. 2001 - 2016. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
namespace MainAplikasi
{
    partial class FormMainAplikasi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMainAplikasi));
            this.xpTaskBar1 = new Syncfusion.Windows.Forms.Tools.XPTaskBar();
            this.boxKelas = new Syncfusion.Windows.Forms.Tools.XPTaskBarBox();
            this.boxMataKuliah = new Syncfusion.Windows.Forms.Tools.XPTaskBarBox();
            this.boxPenawaranMK = new Syncfusion.Windows.Forms.Tools.XPTaskBarBox();
            this.BoxKeluar = new Syncfusion.Windows.Forms.Tools.XPTaskBarBox();
            this.tabbedMDIManager1 = new Syncfusion.Windows.Forms.Tools.TabbedMDIManager(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.stripLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.BoxLaporan = new Syncfusion.Windows.Forms.Tools.XPTaskBarBox();
            this.menuKelasCampuran = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuItemSatuProgramKelasCampuran = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemLintasProgramKelasCampuran = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAlokasiDosen = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuItemSatuProgramAlokasiDosen = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemLintasProgramAlokasiDosen = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.xpTaskBar1)).BeginInit();
            this.xpTaskBar1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.boxKelas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.boxMataKuliah)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.boxPenawaranMK)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BoxKeluar)).BeginInit();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BoxLaporan)).BeginInit();
            this.menuKelasCampuran.SuspendLayout();
            this.menuAlokasiDosen.SuspendLayout();
            this.SuspendLayout();
            // 
            // xpTaskBar1
            // 
            this.xpTaskBar1.AutoScroll = true;
            this.xpTaskBar1.BackColor = System.Drawing.Color.CornflowerBlue;
            this.xpTaskBar1.BeforeTouchSize = new System.Drawing.Size(285, 380);
            this.xpTaskBar1.BorderColor = System.Drawing.Color.Black;
            this.xpTaskBar1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.xpTaskBar1.Controls.Add(this.boxMataKuliah);
            this.xpTaskBar1.Controls.Add(this.boxKelas);
            this.xpTaskBar1.Controls.Add(this.boxPenawaranMK);
            this.xpTaskBar1.Controls.Add(this.BoxLaporan);
            this.xpTaskBar1.Controls.Add(this.BoxKeluar);
            this.xpTaskBar1.Dock = System.Windows.Forms.DockStyle.Left;
            this.xpTaskBar1.Location = new System.Drawing.Point(0, 26);
            this.xpTaskBar1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.xpTaskBar1.MetroColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.xpTaskBar1.MinimumSize = new System.Drawing.Size(0, 0);
            this.xpTaskBar1.Name = "xpTaskBar1";
            this.xpTaskBar1.Size = new System.Drawing.Size(285, 380);
            this.xpTaskBar1.TabIndex = 1;
            // 
            // boxKelas
            // 
            this.boxKelas.AnimationDelay = 10;
            this.boxKelas.BackColor = System.Drawing.Color.CornflowerBlue;
            this.boxKelas.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.boxKelas.HeaderBackColor = System.Drawing.Color.CornflowerBlue;
            this.boxKelas.HeaderForeColor = System.Drawing.Color.White;
            this.boxKelas.HeaderImageIndex = 0;
            this.boxKelas.HitTaskBoxArea = false;
            this.boxKelas.HotTrackColor = System.Drawing.Color.CornflowerBlue;
            this.boxKelas.ItemBackColor = System.Drawing.Color.WhiteSmoke;
            this.boxKelas.Items.AddRange(new Syncfusion.Windows.Forms.Tools.XPTaskBarItem[] {
            new Syncfusion.Windows.Forms.Tools.XPTaskBarItem("Reguler", System.Drawing.Color.Empty, -1, null, "", true, true, "itemKelasReguler", new System.Drawing.Font("Segoe UI", 9.75F), 0),
            new Syncfusion.Windows.Forms.Tools.XPTaskBarItem("Campuran", System.Drawing.Color.Empty, -1, null, "", true, true, "itemKelasCampuran", new System.Drawing.Font("Segoe UI", 9.75F), 0)});
            this.boxKelas.Location = new System.Drawing.Point(0, 98);
            this.boxKelas.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.boxKelas.Name = "boxKelas";
            this.boxKelas.Size = new System.Drawing.Size(264, 76);
            this.boxKelas.TabIndex = 0;
            this.boxKelas.Text = "Kelas";
            this.boxKelas.ItemClick += new Syncfusion.Windows.Forms.Tools.XPTaskBarItemClickHandler(this.boxKelas_ItemClick);
            // 
            // boxMataKuliah
            // 
            this.boxMataKuliah.AnimationDelay = 10;
            this.boxMataKuliah.BackColor = System.Drawing.Color.CornflowerBlue;
            this.boxMataKuliah.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.boxMataKuliah.HeaderBackColor = System.Drawing.Color.CornflowerBlue;
            this.boxMataKuliah.HeaderForeColor = System.Drawing.Color.White;
            this.boxMataKuliah.HeaderImageIndex = 0;
            this.boxMataKuliah.HitTaskBoxArea = false;
            this.boxMataKuliah.HotTrackColor = System.Drawing.Color.CornflowerBlue;
            this.boxMataKuliah.ItemBackColor = System.Drawing.Color.WhiteSmoke;
            this.boxMataKuliah.Items.AddRange(new Syncfusion.Windows.Forms.Tools.XPTaskBarItem[] {
            new Syncfusion.Windows.Forms.Tools.XPTaskBarItem("Data Mata Kuliah", System.Drawing.Color.Empty, -1, null, "", true, true, "itemMataKuliah", new System.Drawing.Font("Segoe UI", 9.75F), 0),
            new Syncfusion.Windows.Forms.Tools.XPTaskBarItem("Mata Kuliah Prasyarat", System.Drawing.Color.Empty, -1, null, "", true, true, "itemMKPrasyarat", new System.Drawing.Font("Segoe UI", 9.75F), 0),
            new Syncfusion.Windows.Forms.Tools.XPTaskBarItem("Mata Kuliah Konsentrasi", System.Drawing.Color.Empty, -1, null, "", true, true, "itemMKKonsentrasi", new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))), 0)});
            this.boxMataKuliah.Location = new System.Drawing.Point(0, 0);
            this.boxMataKuliah.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.boxMataKuliah.Name = "boxMataKuliah";
            this.boxMataKuliah.Size = new System.Drawing.Size(264, 98);
            this.boxMataKuliah.TabIndex = 1;
            this.boxMataKuliah.Text = "Mata Kuliah";
            this.boxMataKuliah.ItemClick += new Syncfusion.Windows.Forms.Tools.XPTaskBarItemClickHandler(this.boxKelas_ItemClick);
            // 
            // boxPenawaranMK
            // 
            this.boxPenawaranMK.AnimationDelay = 10;
            this.boxPenawaranMK.BackColor = System.Drawing.Color.CornflowerBlue;
            this.boxPenawaranMK.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.boxPenawaranMK.HeaderBackColor = System.Drawing.Color.CornflowerBlue;
            this.boxPenawaranMK.HeaderForeColor = System.Drawing.Color.White;
            this.boxPenawaranMK.HeaderImageIndex = 0;
            this.boxPenawaranMK.HitTaskBoxArea = false;
            this.boxPenawaranMK.HotTrackColor = System.Drawing.Color.CornflowerBlue;
            this.boxPenawaranMK.ItemBackColor = System.Drawing.Color.WhiteSmoke;
            this.boxPenawaranMK.Items.AddRange(new Syncfusion.Windows.Forms.Tools.XPTaskBarItem[] {
            new Syncfusion.Windows.Forms.Tools.XPTaskBarItem("Alokasi Mata Kuliah", System.Drawing.Color.Empty, -1, null, "", true, true, "itemAlokasiMK", new System.Drawing.Font("Segoe UI", 9.75F), 0),
            new Syncfusion.Windows.Forms.Tools.XPTaskBarItem("Alokasi Dosen", System.Drawing.Color.Empty, -1, null, "", true, true, "itemAlokasiDosen", new System.Drawing.Font("Segoe UI", 9.75F), 0),
            new Syncfusion.Windows.Forms.Tools.XPTaskBarItem("Alokasi Lab. dan Mata Kuliah", System.Drawing.Color.Empty, -1, null, "", true, true, "itemAlokasiLabMK", new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))), 0)});
            this.boxPenawaranMK.Location = new System.Drawing.Point(0, 174);
            this.boxPenawaranMK.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.boxPenawaranMK.Name = "boxPenawaranMK";
            this.boxPenawaranMK.Size = new System.Drawing.Size(264, 98);
            this.boxPenawaranMK.TabIndex = 2;
            this.boxPenawaranMK.Text = "Penawaran MK";
            this.boxPenawaranMK.ItemClick += new Syncfusion.Windows.Forms.Tools.XPTaskBarItemClickHandler(this.boxKelas_ItemClick);
            // 
            // BoxKeluar
            // 
            this.BoxKeluar.BackColor = System.Drawing.Color.CornflowerBlue;
            this.BoxKeluar.HeaderBackColor = System.Drawing.Color.CornflowerBlue;
            this.BoxKeluar.HeaderForeColor = System.Drawing.Color.White;
            this.BoxKeluar.HeaderImageIndex = -1;
            this.BoxKeluar.HitTaskBoxArea = false;
            this.BoxKeluar.HotTrackColor = System.Drawing.Color.CornflowerBlue;
            this.BoxKeluar.ItemBackColor = System.Drawing.Color.WhiteSmoke;
            this.BoxKeluar.Items.AddRange(new Syncfusion.Windows.Forms.Tools.XPTaskBarItem[] {
            new Syncfusion.Windows.Forms.Tools.XPTaskBarItem("Keluar", System.Drawing.Color.Empty, -1, null, "", true, true, "itemKeluar", new System.Drawing.Font("Segoe UI", 9.75F), 0)});
            this.BoxKeluar.Location = new System.Drawing.Point(0, 378);
            this.BoxKeluar.Name = "BoxKeluar";
            this.BoxKeluar.Size = new System.Drawing.Size(264, 58);
            this.BoxKeluar.TabIndex = 3;
            this.BoxKeluar.Text = "Keluar";
            this.BoxKeluar.ItemClick += new Syncfusion.Windows.Forms.Tools.XPTaskBarItemClickHandler(this.boxKelas_ItemClick);
            // 
            // tabbedMDIManager1
            // 
            this.tabbedMDIManager1.AttachedTo = this;
            this.tabbedMDIManager1.CloseButtonBackColor = System.Drawing.Color.White;
            this.tabbedMDIManager1.ImageSize = new System.Drawing.Size(16, 16);
            this.tabbedMDIManager1.NeedUpdateHostedForm = false;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Dock = System.Windows.Forms.DockStyle.Top;
            this.statusStrip1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stripLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 0);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(822, 26);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // stripLabel
            // 
            this.stripLabel.Name = "stripLabel";
            this.stripLabel.Size = new System.Drawing.Size(157, 21);
            this.stripLabel.Text = "toolStripStatusLabel1";
            // 
            // BoxLaporan
            // 
            this.BoxLaporan.HeaderBackColor = System.Drawing.Color.CornflowerBlue;
            this.BoxLaporan.HeaderForeColor = System.Drawing.Color.White;
            this.BoxLaporan.HeaderImageIndex = -1;
            this.BoxLaporan.HitTaskBoxArea = false;
            this.BoxLaporan.HotTrackColor = System.Drawing.Color.Empty;
            this.BoxLaporan.ItemBackColor = System.Drawing.Color.WhiteSmoke;
            this.BoxLaporan.Items.AddRange(new Syncfusion.Windows.Forms.Tools.XPTaskBarItem[] {
            new Syncfusion.Windows.Forms.Tools.XPTaskBarItem("Lap. Data Mata Kuliah ", System.Drawing.Color.Empty, -1, null, "", true, true, "itemLaporaDataMK", new System.Drawing.Font("Segoe UI", 9.75F), 0),
            new Syncfusion.Windows.Forms.Tools.XPTaskBarItem("Lap. Mata Kuliah Prasyarat", System.Drawing.Color.Empty, -1, null, "", true, true, "itemLaporanMKPrasyarat", new System.Drawing.Font("Segoe UI", 9.75F), 0),
            new Syncfusion.Windows.Forms.Tools.XPTaskBarItem("Lap. Dosen Mengajar", System.Drawing.Color.Empty, -1, null, "", true, true, "itemLaporanDosen", new System.Drawing.Font("Segoe UI", 9.75F), 0)});
            this.BoxLaporan.Location = new System.Drawing.Point(0, 272);
            this.BoxLaporan.Name = "BoxLaporan";
            this.BoxLaporan.Size = new System.Drawing.Size(264, 106);
            this.BoxLaporan.TabIndex = 4;
            this.BoxLaporan.Text = "Laporan";
            // 
            // menuKelasCampuran
            // 
            this.menuKelasCampuran.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemSatuProgramKelasCampuran,
            this.menuItemLintasProgramKelasCampuran});
            this.menuKelasCampuran.Name = "menuKelasCampuran";
            this.menuKelasCampuran.Size = new System.Drawing.Size(155, 48);
            // 
            // menuItemSatuProgramKelasCampuran
            // 
            this.menuItemSatuProgramKelasCampuran.Name = "menuItemSatuProgramKelasCampuran";
            this.menuItemSatuProgramKelasCampuran.Size = new System.Drawing.Size(154, 22);
            this.menuItemSatuProgramKelasCampuran.Text = "Satu Program";
            this.menuItemSatuProgramKelasCampuran.Click += new System.EventHandler(this.menuItemSatuProgramKelasCampuran_Click);
            // 
            // menuItemLintasProgramKelasCampuran
            // 
            this.menuItemLintasProgramKelasCampuran.Name = "menuItemLintasProgramKelasCampuran";
            this.menuItemLintasProgramKelasCampuran.Size = new System.Drawing.Size(154, 22);
            this.menuItemLintasProgramKelasCampuran.Text = "Lintas Program";
            // 
            // menuAlokasiDosen
            // 
            this.menuAlokasiDosen.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemSatuProgramAlokasiDosen,
            this.menuItemLintasProgramAlokasiDosen});
            this.menuAlokasiDosen.Name = "menuAlokasiDosen";
            this.menuAlokasiDosen.Size = new System.Drawing.Size(155, 70);
            // 
            // menuItemSatuProgramAlokasiDosen
            // 
            this.menuItemSatuProgramAlokasiDosen.Name = "menuItemSatuProgramAlokasiDosen";
            this.menuItemSatuProgramAlokasiDosen.Size = new System.Drawing.Size(154, 22);
            this.menuItemSatuProgramAlokasiDosen.Text = "Satu Program";
            this.menuItemSatuProgramAlokasiDosen.Click += new System.EventHandler(this.menuItemSatuProgramAlokasiDosen_Click);
            // 
            // menuItemLintasProgramAlokasiDosen
            // 
            this.menuItemLintasProgramAlokasiDosen.Name = "menuItemLintasProgramAlokasiDosen";
            this.menuItemLintasProgramAlokasiDosen.Size = new System.Drawing.Size(154, 22);
            this.menuItemLintasProgramAlokasiDosen.Text = "Lintas Program";
            // 
            // FormMainAplikasi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CaptionFont = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClientSize = new System.Drawing.Size(822, 406);
            this.Controls.Add(this.xpTaskBar1);
            this.Controls.Add(this.statusStrip1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IsMdiContainer = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FormMainAplikasi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AppJurusan - Desktop";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormMainAplikasi_FormClosed);
            this.Load += new System.EventHandler(this.FormMainAplikasi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.xpTaskBar1)).EndInit();
            this.xpTaskBar1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.boxKelas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.boxMataKuliah)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.boxPenawaranMK)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BoxKeluar)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BoxLaporan)).EndInit();
            this.menuKelasCampuran.ResumeLayout(false);
            this.menuAlokasiDosen.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Syncfusion.Windows.Forms.Tools.XPTaskBar xpTaskBar1;
        private Syncfusion.Windows.Forms.Tools.XPTaskBarBox boxKelas;
        private Syncfusion.Windows.Forms.Tools.TabbedMDIManager tabbedMDIManager1;
        private Syncfusion.Windows.Forms.Tools.XPTaskBarBox boxMataKuliah;
        private Syncfusion.Windows.Forms.Tools.XPTaskBarBox boxPenawaranMK;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel stripLabel;
        private Syncfusion.Windows.Forms.Tools.XPTaskBarBox BoxKeluar;
        private Syncfusion.Windows.Forms.Tools.XPTaskBarBox BoxLaporan;
        private System.Windows.Forms.ContextMenuStrip menuKelasCampuran;
        private System.Windows.Forms.ToolStripMenuItem menuItemSatuProgramKelasCampuran;
        private System.Windows.Forms.ToolStripMenuItem menuItemLintasProgramKelasCampuran;
        private System.Windows.Forms.ContextMenuStrip menuAlokasiDosen;
        private System.Windows.Forms.ToolStripMenuItem menuItemSatuProgramAlokasiDosen;
        private System.Windows.Forms.ToolStripMenuItem menuItemLintasProgramAlokasiDosen;
    }
}