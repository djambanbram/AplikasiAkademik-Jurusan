#region Copyright Syncfusion Inc. 2001 - 2016
// Copyright Syncfusion Inc. 2001 - 2016. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
namespace PenawaranKurikulum.Report
{
    partial class FormReportAlokasiLabMK
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource4 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.gradientPanel2 = new Syncfusion.Windows.Forms.Tools.GradientPanel();
            this.cmbLab = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            this.autoLabel1 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnTutup = new Syncfusion.Windows.Forms.ButtonAdv();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.dataSetAlokasi = new PenawaranKurikulum.Data.DataSetAlokasi();
            this.alokasiLabBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.gradientPanel2)).BeginInit();
            this.gradientPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbLab)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetAlokasi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.alokasiLabBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // gradientPanel2
            // 
            this.gradientPanel2.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat;
            this.gradientPanel2.Controls.Add(this.cmbLab);
            this.gradientPanel2.Controls.Add(this.autoLabel1);
            this.gradientPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.gradientPanel2.Location = new System.Drawing.Point(0, 0);
            this.gradientPanel2.Name = "gradientPanel2";
            this.gradientPanel2.Size = new System.Drawing.Size(833, 45);
            this.gradientPanel2.TabIndex = 17;
            // 
            // cmbLab
            // 
            this.cmbLab.BeforeTouchSize = new System.Drawing.Size(361, 25);
            this.cmbLab.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLab.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbLab.Location = new System.Drawing.Point(115, 6);
            this.cmbLab.Name = "cmbLab";
            this.cmbLab.Size = new System.Drawing.Size(361, 25);
            this.cmbLab.TabIndex = 1;
            this.cmbLab.SelectedIndexChanged += new System.EventHandler(this.cmbLab_SelectedIndexChanged);
            // 
            // autoLabel1
            // 
            this.autoLabel1.Location = new System.Drawing.Point(8, 8);
            this.autoLabel1.Name = "autoLabel1";
            this.autoLabel1.Size = new System.Drawing.Size(87, 17);
            this.autoLabel1.TabIndex = 1;
            this.autoLabel1.Text = "Laboratorium";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnTutup);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 410);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(833, 38);
            this.flowLayoutPanel1.TabIndex = 18;
            // 
            // btnTutup
            // 
            this.btnTutup.BeforeTouchSize = new System.Drawing.Size(113, 30);
            this.btnTutup.IsBackStageButton = false;
            this.btnTutup.Location = new System.Drawing.Point(717, 4);
            this.btnTutup.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnTutup.Name = "btnTutup";
            this.btnTutup.Size = new System.Drawing.Size(113, 30);
            this.btnTutup.TabIndex = 0;
            this.btnTutup.Text = "Tutup";
            this.btnTutup.Click += new System.EventHandler(this.btnTutup_Click);
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource4.Name = "dsAlokasiLab";
            reportDataSource4.Value = this.alokasiLabBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource4);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "PenawaranKurikulum.ReportVieew.ReportLabMK.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 45);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(833, 365);
            this.reportViewer1.TabIndex = 19;
            // 
            // dataSetAlokasi
            // 
            this.dataSetAlokasi.DataSetName = "DataSetAlokasi";
            this.dataSetAlokasi.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // alokasiLabBindingSource
            // 
            this.alokasiLabBindingSource.DataMember = "AlokasiLab";
            this.alokasiLabBindingSource.DataSource = this.dataSetAlokasi;
            // 
            // FormReportAlokasiLabMK
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CaptionFont = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClientSize = new System.Drawing.Size(833, 448);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.gradientPanel2);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FormReportAlokasiLabMK";
            this.Text = "Laporan Alokasi Laboratorium";
            this.Load += new System.EventHandler(this.FormReportAlokasiLabMK_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gradientPanel2)).EndInit();
            this.gradientPanel2.ResumeLayout(false);
            this.gradientPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbLab)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataSetAlokasi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.alokasiLabBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Syncfusion.Windows.Forms.Tools.GradientPanel gradientPanel2;
        private Syncfusion.Windows.Forms.Tools.ComboBoxAdv cmbLab;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private Syncfusion.Windows.Forms.ButtonAdv btnTutup;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource alokasiLabBindingSource;
        private Data.DataSetAlokasi dataSetAlokasi;
    }
}