#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using ApiService;
using ClassModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Linq;

namespace KonversiAlihJalur.Dialog
{
    public partial class FormMataKuliah : Syncfusion.Windows.Forms.MetroForm
    {
        public static string baseAddress = ConfigurationManager.AppSettings["baseAddress"];
        private string URLGetMK = baseAddress + "/jurusan_api/api/kurikulum/get_mk";

        private WebApi webApi;
        private HttpResponseMessage response;
        private string idProdi;
        private List<DataMataKuliah> oListMK;
        private IMataKuliah im;
        private int rowIndex;

        public FormMataKuliah(string idProdi, string kodeLama, string mataKuliahlama, int sksLama, int rowIndex, IMataKuliah im)
        {
            InitializeComponent();
            webApi = new WebApi();
            txtKodeLama.Text = kodeLama;
            txtMataKuliahLama.Text = mataKuliahlama;
            txtSksLama.Text = sksLama.ToString();
            this.idProdi = idProdi;
            this.rowIndex = rowIndex;
            this.im = im;
        }

        private void btnTutup_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void FormMataKuliah_Load(object sender, EventArgs e)
        {
            await LoadMK();
        }

        private async Task LoadMK()
        {
            var data = new { IdProdi = idProdi };
            string jsonData = JsonConvert.SerializeObject(data);

            response = await webApi.Post(URLGetMK, jsonData, true);
            if (response.IsSuccessStatusCode)
            {
                oListMK = JsonConvert.DeserializeObject<List<DataMataKuliah>>(response.Content.ReadAsStringAsync().Result);

                dgvMataKuliah.Rows.Clear();
                int nomor = 1;
                foreach (DataMataKuliah dataMK in oListMK)
                {
                    dgvMataKuliah.Rows.Add(nomor, dataMK.Kode, dataMK.MataKuliah, dataMK.Sks, "Pilih");
                    nomor++;
                }
                dgvMataKuliah.ClearSelection();
            }
            else
            {
                MessageBox.Show(webApi.ReturnMessage(response));
            }
            dgvMataKuliah.PerformLayout();
        }

        private void btnPilih_Click(object sender, EventArgs e)
        {
            var kode = dgvMataKuliah.SelectedRows[0].Cells["Kode"].Value.ToString();
            var mataKuliah = dgvMataKuliah.SelectedRows[0].Cells["MataKuliah"].Value.ToString();
            var sks = int.Parse(dgvMataKuliah.SelectedRows[0].Cells["Sks"].Value.ToString());
            var nilai = dgvMataKuliah.SelectedRows[0].Cells["Nilai"].Value.ToString();
            if(nilai.Length > 1)
            {
                MessageBox.Show("Nilai belum dipilih");
                return;
            }
            im.TambahMataKuliah(kode, mataKuliah, sks, nilai, rowIndex);
            Close();
        }

        private void dgvMataKuliah_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //var kode = dgvMataKuliah.SelectedRows[0].Cells["Kode"].Value.ToString();
            //var mataKuliah = dgvMataKuliah.SelectedRows[0].Cells["MataKuliah"].Value.ToString();
            //var sks = int.Parse(dgvMataKuliah.SelectedRows[0].Cells["Sks"].Value.ToString());
            //var nilai = dgvMataKuliah.SelectedRows[0].Cells["Nilai"].Value.ToString();
            //im.TambahMataKuliah(kode, mataKuliah, sks, nilai, rowIndex);
            //Close();
        }

        private void txtCari_TextChanged(object sender, EventArgs e)
        {
            var tempList = oListMK.Where(mk => mk.Kode.ToLower().Contains(txtCari.Text.ToLower()) || mk.MataKuliah.ToLower().Contains(txtCari.Text.ToLower()));
            dgvMataKuliah.Rows.Clear();
            var no = 1;
            foreach(var item in tempList)
            {
                dgvMataKuliah.Rows.Add(no, item.Kode, item.MataKuliah, item.Sks);
                no++;
            }
        }

        private void dgvMataKuliah_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex != 4)
            {
                return;
            }
            dgvMataKuliah.BeginEdit(true);
            var cb = (ComboBox)dgvMataKuliah.EditingControl;
            cb.Focus();
            cb.DroppedDown = true;
        }
    }
}
