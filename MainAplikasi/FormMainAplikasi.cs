#region Copyright Syncfusion Inc. 2001 - 2016
// Copyright Syncfusion Inc. 2001 - 2016. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KelasMahasiswa;

namespace MainAplikasi
{
    public partial class FormMainAplikasi : Syncfusion.Windows.Forms.MetroForm
    {
        private FromKelasReguler formKelasReguler;

        public FormMainAplikasi()
        {
            InitializeComponent();
        }

        private void boxKelas_ItemClick(object sender, Syncfusion.Windows.Forms.Tools.XPTaskBarItemClickArgs e)
        {
            if(e.XPTaskBarItem.Name == "itemKelasReguler")
            {
                if(formKelasReguler == null || formKelasReguler.IsDisposed)
                {
                    formKelasReguler = new FromKelasReguler();
                    formKelasReguler.MdiParent = this;
                }
                formKelasReguler.Show();
                tabbedMDIManager1.UpdateActiveTabHost(formKelasReguler);
            }
        }

        private void FormMainAplikasi_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.ExitThread();
        }
    }
}