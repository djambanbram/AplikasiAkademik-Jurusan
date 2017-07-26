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
            this.tabbedMDIManager1 = new Syncfusion.Windows.Forms.Tools.TabbedMDIManager(this.components);
            this.autoLabel1 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.boxPenawaranMK = new Syncfusion.Windows.Forms.Tools.XPTaskBarBox();
            ((System.ComponentModel.ISupportInitialize)(this.xpTaskBar1)).BeginInit();
            this.xpTaskBar1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.boxKelas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.boxMataKuliah)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.boxPenawaranMK)).BeginInit();
            this.SuspendLayout();
            // 
            // xpTaskBar1
            // 
            this.xpTaskBar1.AutoScroll = true;
            this.xpTaskBar1.BackColor = System.Drawing.Color.Violet;
            this.xpTaskBar1.BeforeTouchSize = new System.Drawing.Size(285, 406);
            this.xpTaskBar1.BorderColor = System.Drawing.Color.Black;
            this.xpTaskBar1.Controls.Add(this.boxKelas);
            this.xpTaskBar1.Controls.Add(this.boxMataKuliah);
            this.xpTaskBar1.Controls.Add(this.boxPenawaranMK);
            this.xpTaskBar1.Dock = System.Windows.Forms.DockStyle.Left;
            this.xpTaskBar1.Location = new System.Drawing.Point(0, 0);
            this.xpTaskBar1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.xpTaskBar1.MetroColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.xpTaskBar1.MinimumSize = new System.Drawing.Size(0, 0);
            this.xpTaskBar1.Name = "xpTaskBar1";
            this.xpTaskBar1.Size = new System.Drawing.Size(285, 406);
            this.xpTaskBar1.TabIndex = 1;
            // 
            // boxKelas
            // 
            this.boxKelas.AnimationDelay = 10;
            this.boxKelas.BackColor = System.Drawing.Color.MediumPurple;
            this.boxKelas.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.boxKelas.HeaderBackColor = System.Drawing.Color.MediumPurple;
            this.boxKelas.HeaderForeColor = System.Drawing.Color.White;
            this.boxKelas.HeaderImageIndex = 0;
            this.boxKelas.HitTaskBoxArea = false;
            this.boxKelas.HotTrackColor = System.Drawing.Color.Empty;
            this.boxKelas.ItemBackColor = System.Drawing.Color.WhiteSmoke;
            this.boxKelas.Items.AddRange(new Syncfusion.Windows.Forms.Tools.XPTaskBarItem[] {
            new Syncfusion.Windows.Forms.Tools.XPTaskBarItem("Reguler", System.Drawing.Color.Empty, -1, null, "", true, true, "itemKelasReguler", new System.Drawing.Font("Segoe UI", 9.75F), 0),
            new Syncfusion.Windows.Forms.Tools.XPTaskBarItem("Campuran", System.Drawing.Color.Empty, -1, null, "", true, true, "itemKelasCampuran", new System.Drawing.Font("Segoe UI", 9.75F), 0)});
            this.boxKelas.Location = new System.Drawing.Point(0, 0);
            this.boxKelas.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.boxKelas.Name = "boxKelas";
            this.boxKelas.Size = new System.Drawing.Size(285, 76);
            this.boxKelas.TabIndex = 0;
            this.boxKelas.Text = "Kelas";
            this.boxKelas.ItemClick += new Syncfusion.Windows.Forms.Tools.XPTaskBarItemClickHandler(this.boxKelas_ItemClick);
            // 
            // boxMataKuliah
            // 
            this.boxMataKuliah.AnimationDelay = 10;
            this.boxMataKuliah.BackColor = System.Drawing.Color.MediumPurple;
            this.boxMataKuliah.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.boxMataKuliah.HeaderBackColor = System.Drawing.Color.MediumPurple;
            this.boxMataKuliah.HeaderForeColor = System.Drawing.Color.White;
            this.boxMataKuliah.HeaderImageIndex = 0;
            this.boxMataKuliah.HitTaskBoxArea = false;
            this.boxMataKuliah.HotTrackColor = System.Drawing.Color.Empty;
            this.boxMataKuliah.ItemBackColor = System.Drawing.Color.WhiteSmoke;
            this.boxMataKuliah.Items.AddRange(new Syncfusion.Windows.Forms.Tools.XPTaskBarItem[] {
            new Syncfusion.Windows.Forms.Tools.XPTaskBarItem("Data Mata Kuliah", System.Drawing.Color.Empty, -1, null, "", true, true, "itemMataKuliah", new System.Drawing.Font("Segoe UI", 9.75F), 0),
            new Syncfusion.Windows.Forms.Tools.XPTaskBarItem("Mata Kuliah Prasyarat", System.Drawing.Color.Empty, -1, null, "", true, true, "itemMKPrasyarat", new System.Drawing.Font("Segoe UI", 9.75F), 0),
            new Syncfusion.Windows.Forms.Tools.XPTaskBarItem("Mata Kuliah Konsentrasi", System.Drawing.Color.Empty, -1, null, "", true, true, "itemMKKonsentrasi", new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))), 0)});
            this.boxMataKuliah.Location = new System.Drawing.Point(0, 76);
            this.boxMataKuliah.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.boxMataKuliah.Name = "boxMataKuliah";
            this.boxMataKuliah.Size = new System.Drawing.Size(285, 98);
            this.boxMataKuliah.TabIndex = 1;
            this.boxMataKuliah.Text = "Mata Kuliah";
            this.boxMataKuliah.ItemClick += new Syncfusion.Windows.Forms.Tools.XPTaskBarItemClickHandler(this.boxKelas_ItemClick);
            // 
            // tabbedMDIManager1
            // 
            this.tabbedMDIManager1.AttachedTo = this;
            this.tabbedMDIManager1.CloseButtonBackColor = System.Drawing.Color.White;
            this.tabbedMDIManager1.ImageSize = new System.Drawing.Size(16, 16);
            this.tabbedMDIManager1.NeedUpdateHostedForm = false;
            // 
            // autoLabel1
            // 
            this.autoLabel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.autoLabel1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.autoLabel1.Location = new System.Drawing.Point(285, 0);
            this.autoLabel1.Name = "autoLabel1";
            this.autoLabel1.Size = new System.Drawing.Size(64, 17);
            this.autoLabel1.TabIndex = 2;
            this.autoLabel1.Text = "Loading...";
            // 
            // boxPenawaranMK
            // 
            this.boxPenawaranMK.AnimationDelay = 10;
            this.boxPenawaranMK.BackColor = System.Drawing.Color.MediumPurple;
            this.boxPenawaranMK.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.boxPenawaranMK.HeaderBackColor = System.Drawing.Color.MediumPurple;
            this.boxPenawaranMK.HeaderForeColor = System.Drawing.Color.White;
            this.boxPenawaranMK.HeaderImageIndex = 0;
            this.boxPenawaranMK.HitTaskBoxArea = false;
            this.boxPenawaranMK.HotTrackColor = System.Drawing.Color.Empty;
            this.boxPenawaranMK.ItemBackColor = System.Drawing.Color.WhiteSmoke;
            this.boxPenawaranMK.Items.AddRange(new Syncfusion.Windows.Forms.Tools.XPTaskBarItem[] {
            new Syncfusion.Windows.Forms.Tools.XPTaskBarItem("Alokasi Mata Kuliah", System.Drawing.Color.Empty, -1, null, "", true, true, "itemAlokasiMK", new System.Drawing.Font("Segoe UI", 9.75F), 0),
            new Syncfusion.Windows.Forms.Tools.XPTaskBarItem("Alokasi Dosen", System.Drawing.Color.Empty, -1, null, "", true, true, "itemAlokasiDosen", new System.Drawing.Font("Segoe UI", 9.75F), 0)});
            this.boxPenawaranMK.Location = new System.Drawing.Point(0, 174);
            this.boxPenawaranMK.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.boxPenawaranMK.Name = "boxPenawaranMK";
            this.boxPenawaranMK.Size = new System.Drawing.Size(285, 76);
            this.boxPenawaranMK.TabIndex = 2;
            this.boxPenawaranMK.Text = "Penawaran MK";
            this.boxPenawaranMK.ItemClick += new Syncfusion.Windows.Forms.Tools.XPTaskBarItemClickHandler(this.boxKelas_ItemClick);
            // 
            // FormMainAplikasi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CaptionFont = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClientSize = new System.Drawing.Size(822, 406);
            this.Controls.Add(this.autoLabel1);
            this.Controls.Add(this.xpTaskBar1);
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
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Syncfusion.Windows.Forms.Tools.XPTaskBar xpTaskBar1;
        private Syncfusion.Windows.Forms.Tools.XPTaskBarBox boxKelas;
        private Syncfusion.Windows.Forms.Tools.TabbedMDIManager tabbedMDIManager1;
        private Syncfusion.Windows.Forms.Tools.XPTaskBarBox boxMataKuliah;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel1;
        private Syncfusion.Windows.Forms.Tools.XPTaskBarBox boxPenawaranMK;
    }
}