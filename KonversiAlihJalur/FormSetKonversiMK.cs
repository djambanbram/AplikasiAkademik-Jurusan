#region Copyright Syncfusion Inc. 2001 - 2016
// Copyright Syncfusion Inc. 2001 - 2016. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using AdvancedDataGridView;
using ApiService;
using ClassModel;
using KonversiAlihJalur.Dialog;
using KonversiAlihJalur.Lib;
using KonversiAlihJalur.Models;
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

namespace KonversiAlihJalur
{
    public partial class FormSetKonversiMK : Syncfusion.Windows.Forms.MetroForm
    {
        public static string baseAddress = ConfigurationManager.AppSettings["baseAddress"];
        private string URLGetMKD3 = baseAddress + "/jurusan_api/api/alih_jalur/get_mk_d3";
        private string URLGetMKS1 = baseAddress + "/jurusan_api/api/alih_jalur/get_mk_s1";
        private string URLGetKonversiMK = baseAddress + "/jurusan_api/api/alih_jalur/get_konversi_mk";
        private string URLSaveKonversiMK = baseAddress + "/jurusan_api/api/alih_jalur/save_konversi_mk";
        private string URLDeleteKonversiMK = baseAddress + "/jurusan_api/api/alih_jalur/del_konversi_mk";

        private List<Program> listProgram;
        private List<DataMataKuliah> listMataKuliahD3;
        private List<DataMataKuliah> listMataKuliahS1;
        private List<MataKuliahKonversi> listMataKuliahKonversi;

        private WebApi webApi;
        private HttpResponseMessage response;

        private DragandDrop dragAnDropAdd;
        private DragandDrop dragAnDropDel;

        private dynamic dataAdd;
        private dynamic dataDel;

        public FormSetKonversiMK()
        {
            InitializeComponent();
            webApi = new WebApi();
            dragAnDropAdd = new DragandDrop();
            dragAnDropDel = new DragandDrop();
        }

        private void Loading(bool isLoading)
        {
            flowLayoutPanel1.Enabled = !isLoading;
            splitContainer1.Enabled = !isLoading;
            gradientPanel2.Enabled = !isLoading;
            progressBar1.Visible = isLoading;
        }

        private async Task LoadMkD3()
        {
            Loading(true);
            var data = new { Angkatan = int.Parse(cmbAngkatan.Text), KodeProgram = cmbProgramAlihJalur.SelectedValue.ToString() };
            var jsonData = JsonConvert.SerializeObject(data);

            response = await webApi.Post(URLGetMKD3, jsonData, true);
            if (!response.IsSuccessStatusCode)
            {
                MessageBox.Show(webApi.ReturnMessage(response));
                Loading(false);
                return;
            }

            listMataKuliahD3 = JsonConvert.DeserializeObject<List<DataMataKuliah>>(response.Content.ReadAsStringAsync().Result)
                .Where(mk => !mk.MataKuliah.ToLower().Contains("tak dikenal")
                && !mk.MataKuliah.ToLower().Contains("tidak dikenal")
                && !mk.MataKuliah.ToLower().Contains("tes dts")
                && !mk.Kode.ToLower().Contains("df")
                && !mk.Kode.ToLower().Contains("xx")
                && mk.SemesterDitawarkan != 0).ToList();
            if (listMataKuliahD3.Count == 0)
            {
                MessageBox.Show(webApi.ReturnMessage(response));
                Loading(false);
                return;
            }

            dgvMKD3.Rows.Clear();
            foreach (var mk in listMataKuliahD3)
            {
                dgvMKD3.Rows.Add(mk.Kode, mk.MataKuliah, mk.Sks);
            }
            Loading(false);
        }

        private async Task LoadMkS1()
        {
            Loading(true);
            var data = new { Angkatan = int.Parse(cmbAngkatan.Text), KodeProgram = cmbProgramAlihJalur.SelectedValue.ToString() };
            var jsonData = JsonConvert.SerializeObject(data);

            response = await webApi.Post(URLGetMKS1, jsonData, true);
            if (!response.IsSuccessStatusCode)
            {
                MessageBox.Show(webApi.ReturnMessage(response));
                Loading(false);
                return;
            }

            listMataKuliahS1 = JsonConvert.DeserializeObject<List<DataMataKuliah>>(response.Content.ReadAsStringAsync().Result)
                .Where(mk => mk.Sampai == 0)
                .ToList();
            if (listMataKuliahD3.Count == 0)
            {
                MessageBox.Show(webApi.ReturnMessage(response));
                Loading(false);
                return;
            }

            dgvMKS1.Nodes.Clear();
            foreach (var mk in listMataKuliahS1)
            {
                dgvMKS1.Nodes.Add(null, mk.Kode, mk.MataKuliah, mk.Sks, 1);
            }

            response = await webApi.Post(URLGetKonversiMK, jsonData, true);
            if (!response.IsSuccessStatusCode)
            {
                MessageBox.Show(webApi.ReturnMessage(response));
                Loading(false);
                return;
            }

            listMataKuliahKonversi = JsonConvert.DeserializeObject<List<MataKuliahKonversi>>(response.Content.ReadAsStringAsync().Result);
            if (listMataKuliahKonversi.Count == 0)
            {
                Loading(false);
                return;
            }

            foreach (TreeGridNode node in dgvMKS1.Nodes)
            {
                var tempList = listMataKuliahKonversi.Where(k => k.KodeS1 == node.Cells["KodeS1"].Value.ToString()).ToList();
                if (tempList == null)
                {
                    continue;
                }
                if (tempList.Count == 0)
                {
                    continue;
                }

                foreach (var item in tempList)
                {
                    TreeGridNode childNode = node.Nodes.Add(null, item.KodeD3, item.MataKuliahD3, item.SksD3, 0);
                    childNode.DefaultCellStyle.BackColor = Color.LightGray;
                }
            }

            Loading(false);
        }

        private void FormSetKonversiMK_Load(object sender, EventArgs e)
        {
            listProgram = Organisasi.listProgram.Where(program => program.KodeProgram == "21" || program.KodeProgram == "22").ToList();
            listProgram.Insert(0, new Program() { KodeProgram = "-", NamaProgram = "Pilih" });
            cmbProgramAlihJalur.DataSource = listProgram;
            cmbProgramAlihJalur.DisplayMember = "NamaProgram";
            cmbProgramAlihJalur.ValueMember = "KodeProgram";
            cmbProgramAlihJalur.SelectedIndex = 0;

            for (int i = DateTime.Now.Year; i > DateTime.Now.Year - 10; i--)
            {
                cmbAngkatan.Items.Add(i.ToString());
            }
            cmbAngkatan.Items.Insert(0, "Pilih");
            cmbAngkatan.SelectedIndex = 0;

        }

        private void btnTutup_Click(object sender, EventArgs e)
        {
            Close();
        }


        private async void cmbAngkatan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbAngkatan.SelectedIndex <= 0 || cmbProgramAlihJalur.SelectedIndex <= 0)
            {
                return;
            }
            await LoadMkD3();
            await LoadMkS1();
        }

        private void txtCari_TextChanged(object sender, EventArgs e)
        {
            if (dgvMKD3.Rows.Count <= 0 || listMataKuliahD3.Count <= 0)
            {
                return;
            }

            var tempList = listMataKuliahD3.Where(mk => mk.Kode.ToLower().Contains(txtCari.Text) || mk.MataKuliah.ToLower().Contains(txtCari.Text)).ToList();

            dgvMKD3.Rows.Clear();
            foreach (var mk in tempList)
            {
                dgvMKD3.Rows.Add(mk.Kode, mk.MataKuliah, mk.Sks);
            }
        }

        private async void cmbProgramAlihJalur_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbAngkatan.SelectedIndex <= 0 || cmbProgramAlihJalur.SelectedIndex <= 0)
            {
                return;
            }
            await LoadMkD3();
            await LoadMkS1();
        }

        private void dgvMKD3_MouseDown(object sender, MouseEventArgs e)
        {
            var hit = dragAnDropAdd.DragMouseDownFirst(e, dgvMKD3);
            if (hit == null)
            {
                dataAdd = null;
                return;
            }
            var kode = dgvMKD3.Rows[hit.RowIndex].Cells["KodeD3"].Value.ToString();
            var mataKuliah = dgvMKD3.Rows[hit.RowIndex].Cells["MataKuliahD3"].Value.ToString();
            var sks = dgvMKD3.Rows[hit.RowIndex].Cells["SksD3"].Value.ToString();
            dataAdd = new { KodeD3 = kode, MataKuliahD3 = mataKuliah, SksD3 = sks };
            dragAnDropAdd.DragMouseDownSecond(e, dgvMKS1, hit, dataAdd);
        }

        private void dgvMKD3_MouseMove(object sender, MouseEventArgs e)
        {
            dragAnDropAdd.DragMove(e, dgvMKD3, dataAdd);
        }

        private void dgvMKS1_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void dgvMKS1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private async void dgvMKS1_DragDrop(object sender, DragEventArgs e)
        {
            var hit = dragAnDropAdd.DragDrop(e, dgvMKS1);
            if (hit == null)
            {
                return;
            }

            if (dataAdd == null)
            {
                return;
            }

            if (dgvMKS1.Rows[hit.RowIndex].Cells["isParent"].Value.ToString() != "1")
            {
                return;
            }

            var data = new
            {
                KodeD3 = dataAdd.KodeD3,
                KodeS1 = dgvMKS1.GetNodeForRow(hit.RowIndex).Cells["KodeS1"].Value.ToString(),
                KodeProgram = cmbProgramAlihJalur.SelectedValue.ToString(),
                Angkatan = int.Parse(cmbAngkatan.Text),
                IsCopy = false
            };
            var jsonData = JsonConvert.SerializeObject(data);
            response = await webApi.Post(URLSaveKonversiMK, jsonData, true);
            if (!response.IsSuccessStatusCode)
            {
                MessageBox.Show(webApi.ReturnMessage(response));
                Loading(false);
                return;
            }

            TreeGridNode node = dgvMKS1.Rows[hit.RowIndex] as TreeGridNode;
            TreeGridNode childNode = node.Nodes.Add(null, dataAdd.KodeD3, dataAdd.MataKuliahD3, dataAdd.SksD3, 0);
            childNode.DefaultCellStyle.BackColor = Color.LightGray;

            dataAdd = null;
        }

        private void dgvMKD3_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void dgvMKD3_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private async void dgvMKD3_DragDrop(object sender, DragEventArgs e)
        {
            var hit = dragAnDropDel.DragDrop(e, dgvMKD3);

            if (dataDel == null)
            {
                return;
            }

            var data = new
            {
                KodeD3 = dataDel.KodeD3,
                KodeS1 = dataDel.KodeS1,
                KodeProgram = cmbProgramAlihJalur.SelectedValue.ToString(),
                Angkatan = int.Parse(cmbAngkatan.Text),
                IsCopy = false
            };
            var jsonData = JsonConvert.SerializeObject(data);
            response = await webApi.Post(URLDeleteKonversiMK, jsonData, true);
            if (!response.IsSuccessStatusCode)
            {
                MessageBox.Show(webApi.ReturnMessage(response));
                Loading(false);
                return;
            }

            var kodeD3 = dataDel.KodeD3;
            var kodeS1 = dataDel.KodeS1;
            int rowDel = int.Parse(dataDel.RowChild.ToString());
            int rowCurrent = int.Parse(dataDel.RowCurrent.ToString());

            var nodeParent = dgvMKS1.GetNodeForRow(rowCurrent).Parent;
            if (nodeParent.HasChildren)
            {
                nodeParent.Nodes.RemoveAt(rowDel);
            }

            dataDel = null;
        }

        private void dgvMKS1_MouseDown(object sender, MouseEventArgs e)
        {
            var hit = dragAnDropDel.DragMouseDownFirst(e, dgvMKS1);
            if (hit == null)
            {
                dataDel = null;
                return;
            }

            if (dgvMKS1.Rows[hit.RowIndex].Cells["isParent"].Value.ToString() != "0")
            {
                dataDel = null;
                return;
            }

            var kodeD3 = dgvMKS1.Rows[hit.RowIndex].Cells["KodeS1"].Value.ToString();
            var kodeS1 = dgvMKS1.GetNodeForRow(hit.RowIndex).Parent.Cells["KodeS1"].Value.ToString();
            var rowChild = dgvMKS1.GetNodeForRow(hit.RowIndex).Parent.Nodes.IndexOf(dgvMKS1.Rows[hit.RowIndex] as TreeGridNode);
            var rowCurrent = hit.RowIndex;

            dataDel = new { KodeD3 = kodeD3, KodeS1 = kodeS1, RowChild = rowChild, RowCurrent = rowCurrent };
            dragAnDropDel.DragMouseDownSecond(e, dgvMKD3, hit, dataDel);
        }

        private void dgvMKS1_MouseMove(object sender, MouseEventArgs e)
        {
            dragAnDropDel.DragMove(e, dgvMKS1, dataDel);
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            if (cmbProgramAlihJalur.SelectedIndex <= 0)
            {
                MessageBox.Show("Program harus dipilih dulu");
                return;
            }

            using (var form = new FormCopyMKKonversi(cmbProgramAlihJalur.SelectedValue.ToString(), cmbProgramAlihJalur.Text))
            {
                form.ShowDialog(this);
            }
        }
    }
}
