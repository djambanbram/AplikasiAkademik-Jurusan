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
        private FormKelasReguler formKelasReguler;
        private FormKelasCampuran formKelasCampuran;
        private FormKelasRemidial formKelasRemidial;

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
                    formKelasReguler = new FormKelasReguler();
                    formKelasReguler.MdiParent = this;
                }
                formKelasReguler.Show();
                tabbedMDIManager1.UpdateActiveTabHost(formKelasReguler);
            }
            else if (e.XPTaskBarItem.Name == "itemKelasCampuran")
            {
                if (formKelasCampuran == null || formKelasCampuran.IsDisposed)
                {
                    formKelasCampuran = new FormKelasCampuran();
                    formKelasCampuran.MdiParent = this;
                }
                formKelasCampuran.Show();
                tabbedMDIManager1.UpdateActiveTabHost(formKelasCampuran);
            }
            else if (e.XPTaskBarItem.Name == "itemKelasRemidial")
            {
                if (formKelasRemidial == null || formKelasRemidial.IsDisposed)
                {
                    formKelasRemidial = new FormKelasRemidial();
                    formKelasRemidial.MdiParent = this;
                }
                formKelasRemidial.Show();
                tabbedMDIManager1.UpdateActiveTabHost(formKelasRemidial);
            }
        }

        private void FormMainAplikasi_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.ExitThread();
        }
    }
}
