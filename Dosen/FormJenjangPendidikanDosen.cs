#region Copyright Syncfusion Inc. 2001 - 2016
// Copyright Syncfusion Inc. 2001 - 2016. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using AdvancedDataGridView;
using ApiService;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Windows.Forms;

namespace Dosen
{
    public partial class FormJenjangPendidikanDosen : Syncfusion.Windows.Forms.MetroForm
    {
        public static string baseAddress = ConfigurationManager.AppSettings["baseAddress"];
        private string URLGetDetailJenjangPendidikanDosen = baseAddress + "/karyawan_api/api/dosen/get_detail_jenjang_pendidikan_dosen";

        private WebApi webApi;
        private HttpResponseMessage response;

        private List<dynamic> listDetailJPDosen;
        //private List<> listDetailJPDosenDistinct;

        public FormJenjangPendidikanDosen()
        {
            InitializeComponent();
            webApi = new WebApi();
        }

        private void Loading(bool isLoading)
        {
            flowLayoutPanel1.Enabled = !isLoading;
            flowLayoutPanel2.Enabled = !isLoading;
            gradientPanel1.Enabled = !isLoading;
            progressBar1.Visible = isLoading;
        }

        private void btnTutup_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void FormJenjangPendidikanDosen_Load(object sender, EventArgs e)
        {
            Loading(true);

            response = await webApi.Post(URLGetDetailJenjangPendidikanDosen, string.Empty, true);
            if (!response.IsSuccessStatusCode)
            {
                MessageBox.Show(webApi.ReturnMessage(response));
                Loading(false);
                return;
            }

            dgvJenjangDosen.Nodes.Clear();
            listDetailJPDosen = JsonConvert.DeserializeObject<List<dynamic>>(response.Content.ReadAsStringAsync().Result);
            var listDetailJPDosenDistinct = listDetailJPDosen.Select(jp => new { jp.Nik, jp.NamaDosen }).ToList().Distinct();

            foreach (var item in listDetailJPDosenDistinct)
            {
                dgvJenjangDosen.Nodes.Add(null, null, item.Nik, item.NamaDosen);
            }

            foreach (var tree in dgvJenjangDosen.Nodes)
            {
                foreach (var item in listDetailJPDosen)
                {
                    if (tree.Cells["Nik"].Value.ToString().Trim() == item.Nik.ToString().Trim() as string)
                    {
                        var tgn = tree.Nodes.Add(null, item.IdTransJenjang, null, null, item.NamaJenjang, item.NamaProgramStudi, item.NamaUniversitas) as TreeGridNode;
                        tgn.DefaultCellStyle.BackColor = Color.LightGray;
                    }
                }
                tree.Expand();
            }

            Loading(false);
        }

        private void txtCari_TextChanged(object sender, EventArgs e)
        {
            List<dynamic> listTemp = listDetailJPDosen.Where(jp => (jp.NamaDosen.ToString() as string).ToLower().Contains(txtCari.Text.ToLower()) ||
            (jp.Nik.ToString() as string).ToLower().Contains(txtCari.Text.ToLower())).ToList();

            var listDetailJPDosenDistinct = listTemp.Select(jp => new { jp.Nik, jp.NamaDosen }).ToList().Distinct();

            dgvJenjangDosen.Nodes.Clear();
            foreach (var item in listDetailJPDosenDistinct)
            {
                dgvJenjangDosen.Nodes.Add(null, null, item.Nik, item.NamaDosen);
            }

            foreach (var tree in dgvJenjangDosen.Nodes)
            {
                foreach (var item in listTemp)
                {
                    if (tree.Cells["Nik"].Value.ToString().Trim() == item.Nik.ToString().Trim() as string)
                    {
                        var tgn = tree.Nodes.Add(null, item.IdTransJenjang, null, null, item.NamaJenjang, item.NamaProgramStudi, item.NamaUniversitas)as TreeGridNode;
                        tgn.DefaultCellStyle.BackColor = Color.LightGray;
                    }
                }
                tree.Expand();
            }
        }
    }
}
