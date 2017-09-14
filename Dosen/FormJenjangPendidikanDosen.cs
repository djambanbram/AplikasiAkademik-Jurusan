#region Copyright Syncfusion Inc. 2001 - 2016
// Copyright Syncfusion Inc. 2001 - 2016. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using AdvancedDataGridView;
using ApiService;
using Dosen.Dialog;
using Dosen.Listener;
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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dosen
{
    public partial class FormJenjangPendidikanDosen : Syncfusion.Windows.Forms.MetroForm, IjenjangPendidikan
    {
        public static string baseAddress = ConfigurationManager.AppSettings["baseAddress"];
        private string URLGetDetailJenjangPendidikanDosen = baseAddress + "/karyawan_api/api/jenjang_pendidikan/get_detail_jenjang_pendidikan_karyawan";
        private string URLSaveDetailJenjangPendidikanDosen = baseAddress + "/karyawan_api/api/jenjang_pendidikan/save_detail_jenjang_pendidikan_karyawan";
        private string URLDeleteDetailJenjangPendidikanDosen = baseAddress + "/karyawan_api/api/jenjang_pendidikan/delete_detail_jenjang_pendidikan_karyawan";

        private WebApi webApi;
        private HttpResponseMessage response;

        private List<dynamic> listDetailJPDosen;
        private int rowSelect;

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
            await LoadDetailJenjangPendidikan();
        }

        private void txtCari_TextChanged(object sender, EventArgs e)
        {
            List<dynamic> listTemp = listDetailJPDosen.Where(jp => (jp.NamaKaryawan.ToString() as string).ToLower().Contains(txtCari.Text.ToLower()) ||
            (jp.Nik.ToString() as string).ToLower().Contains(txtCari.Text.ToLower())).ToList();

            var listDetailJPDosenDistinct = listTemp.Select(jp => new { jp.Nik, jp.NamaKaryawan }).ToList().Distinct();

            dgvJenjangDosen.Nodes.Clear();
            foreach (var item in listDetailJPDosenDistinct)
            {
                dgvJenjangDosen.Nodes.Add(null, null, item.Nik, item.NamaKaryawan);
            }

            foreach (var tree in dgvJenjangDosen.Nodes)
            {
                foreach (var item in listTemp)
                {
                    if (tree.Cells["Nik"].Value.ToString().Trim() == item.Nik.ToString().Trim() as string)
                    {
                        var tgn = tree.Nodes.Add(null, item.IdTransJenjang, null, null, item.NamaJenjang, item.NamaProgramStudi, item.NamaUniversitas, item.TanggalMulai, item.TanggalSelesai) as TreeGridNode;
                        tgn.DefaultCellStyle.BackColor = Color.LightGray;
                    }
                }
                tree.Expand();
            }
        }

        private async Task LoadDetailJenjangPendidikan()
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
            var listDetailJPDosenDistinct = listDetailJPDosen.Where(d => d.IsAktif == true).Select(jp => new { jp.Nik, jp.NamaKaryawan }).ToList().Distinct();

            foreach (var item in listDetailJPDosenDistinct)
            {
                dgvJenjangDosen.Nodes.Add(null, null, item.Nik, item.NamaKaryawan);
            }

            foreach (var tree in dgvJenjangDosen.Nodes)
            {
                foreach (var item in listDetailJPDosen)
                {
                    if (tree.Cells["Nik"].Value.ToString().Trim() == item.Nik.ToString().Trim() as string)
                    {
                        var tgn = tree.Nodes.Add(null, item.IdTransJenjang, null, null, item.NamaJenjang, item.NamaProgramStudi, item.NamaUniversitas, item.TanggalMulai, item.TanggalSelesai) as TreeGridNode;
                        tgn.DefaultCellStyle.BackColor = Color.LightGray;
                    }
                }
                tree.Expand();
            }

            Loading(false);
        }

        private void btntambah_Click(object sender, EventArgs e)
        {
            using (var form = new FormTambahJenjangPendidikan(this))
            {
                form.ShowDialog();
            }
        }

        private void tambahJenjangPendidikanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var nikDosen = dgvJenjangDosen.Rows[rowSelect].Cells["Nik"].Value.ToString();
            var form = new FormTambahJenjangPendidikan(this);
            form.NikDosen = nikDosen;
            form.ShowDialog();

        }

        private void dgvJenjangDosen_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            //var hittest = dgvJenjangDosen.HitTest(e.X, e.Y);
            dgvJenjangDosen.Rows[e.RowIndex].Selected = true;
            if (dgvJenjangDosen.Rows[e.RowIndex].Cells["IdTransJenjang"].Value != null)
            {
                var namaDosen = dgvJenjangDosen.Nodes[dgvJenjangDosen.GetNodeForRow(e.RowIndex).Parent.Index].Cells["NamaDosen"].Value.ToString();
                var jenjang = dgvJenjangDosen.Rows[e.RowIndex].Cells["JenjangPendidikan"].Value.ToString();
                var univ = dgvJenjangDosen.Rows[e.RowIndex].Cells["Universitas"].Value.ToString();
                var idTransJenjang = dgvJenjangDosen.Rows[e.RowIndex].Cells["IdTransJenjang"].Value.ToString();
                contextMenuStrip1.Items[0].Text = string.Format("Hapus a.n. {0} | jenjang {1} | {2}", namaDosen, jenjang, univ);
                contextMenuStrip1.Items[0].Enabled = true;
                contextMenuStrip1.Items[1].Enabled = false;
                contextMenuStrip1.Items[0].Tag = idTransJenjang;
            }
            else
            {
                contextMenuStrip1.Items[0].Text = "Hapus Jenjang Pendidikan";
                contextMenuStrip1.Items[0].Enabled = false;
                contextMenuStrip1.Items[1].Enabled = true;
            }
            rowSelect = e.RowIndex;
        }

        private async void hapusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Hapus Data", "Apakah akan menghapus data?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.No)
            {
                return;
            }

            int idTransJenjang = int.Parse(contextMenuStrip1.Items[0].Tag.ToString());

            var dataDel = new { Id = idTransJenjang };
            var jsonData = JsonConvert.SerializeObject(dataDel);
            response = await webApi.Post(URLDeleteDetailJenjangPendidikanDosen, jsonData, true);
            if (!response.IsSuccessStatusCode)
            {
                MessageBox.Show(this, webApi.ReturnMessage(response));
                return;
            }
            MessageBox.Show(this, "Data berhasil dihapus");
            dgvJenjangDosen.Rows.RemoveAt(rowSelect);
        }

        public async void RefreshDetailJenjangPendidikan()
        {
            await LoadDetailJenjangPendidikan();
        }
    }
}
