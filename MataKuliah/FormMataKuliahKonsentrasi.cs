#region Copyright Syncfusion Inc. 2001 - 2016
// Copyright Syncfusion Inc. 2001 - 2016. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using ApiService;
using ClassModel;
using MataKuliah.DataBinding;
using MataKuliah.DialogForm;
using MataKuliah.Lib;
using MataKuliah.Listener;
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

namespace MataKuliah
{
    public partial class FormMataKuliahKonsentrasi : Syncfusion.Windows.Forms.MetroForm, IMKKonsentrasi
    {
        public static string baseAddress = ConfigurationManager.AppSettings["baseAddress"];
        private string URLGetMK = baseAddress + "/jurusan_api/api/kurikulum/get_mk";
        private string URLGetMasterKonsentrasi = baseAddress + "/jurusan_api/api/kurikulum/get_master_konsentrasi";
        private string URLSaveMasterKonsentrasi = baseAddress + "/jurusan_api/api/kurikulum/save_master_konsentrasi";
        private string URLSaveMKKonsentrasi = baseAddress + "/jurusan_api/api/kurikulum/save_mk_konsentrasi";
        private string URLDeleteMKKonsentrasi = baseAddress + "/jurusan_api/api/kurikulum/del_mk_konsentrasi";
        private string URLGetMKKonsentrasi = baseAddress + "/jurusan_api/api/kurikulum/get_mk_konsentrasi";

        private WebApi webApi;
        private HttpResponseMessage response;

        private List<Fakultas> listFakultas;
        private List<Prodi> listProdi;

        private string UidProdiDipilih;
        private string KodeMKDipilih;

        private DragandDrop dragAndDropAdd;
        private DragandDrop dragAndDropDelete;

        private dynamic valueAdd;
        private dynamic valueDelete;

        public FormMataKuliahKonsentrasi()
        {
            InitializeComponent();
            webApi = new WebApi();
            dragAndDropAdd = new DragandDrop();
            dragAndDropDelete = new DragandDrop();
        }

        private void Loading(bool isLoading)
        {
            splitContainerAdv1.Enabled = !isLoading;
            flowLayoutPanel1.Enabled = !isLoading;
            flowLayoutPanel2.Enabled = !isLoading;
            gradientPanel2.Enabled = !isLoading;

            progressBar1.Visible = isLoading;
        }

        private void FormMataKuliahKonsentrasi_Load(object sender, EventArgs e)
        {
            listFakultas = new List<Fakultas>(Organisasi.listFakultas);
            listFakultas.Insert(0, new Fakultas() { KodeFakultas = "-", NamaFakultas = "Pilih" });
            cmbFakultas.DataSource = listFakultas;
            cmbFakultas.DisplayMember = "NamaFakultas";
            cmbFakultas.ValueMember = "KodeFakultas";
            cmbFakultas.SelectedIndex = 0;
        }

        private void cmbFakultas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbFakultas.SelectedIndex > 0)
            {
                string kodeFakultas = cmbFakultas.SelectedValue.ToString();
                listProdi = Organisasi.listProdi.Where(pr => pr.Fakultas.KodeFakultas == kodeFakultas).ToList();
                listProdi.Insert(0, new Prodi() { IdProdi = "-", NamaProdi = "Pilih" });
                cmbProdi.DataSource = listProdi;
                cmbProdi.DisplayMember = "NamaProdi";
                cmbProdi.ValueMember = "Uid";
                cmbProdi.SelectedIndex = 0;
            }
        }

        private async void cmbProdi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbProdi.SelectedIndex > 0 && cmbFakultas.SelectedIndex > 0)
            {
                UidProdiDipilih = cmbProdi.SelectedValue.ToString();
                Loading(true);
                await LoadMK();
                await LoadKonsentrasi();
                Loading(false);
            }
        }
        private async Task LoadMK()
        {

            MKByIdProdi m = new MKByIdProdi() { IdProdi = UidProdiDipilih };
            string jsonData = JsonConvert.SerializeObject(m);

            response = await webApi.Post(URLGetMK, jsonData, true);
            if (response.IsSuccessStatusCode)
            {
                List<dynamic> oListMK = JsonConvert.DeserializeObject<List<dynamic>>(response.Content.ReadAsStringAsync().Result);
                MataKuliahBinding mkBinding = new MataKuliahBinding(oListMK);

                dgvMataKuliah.Rows.Clear();
                int nomor = 1;
                foreach (DataMataKuliah dataMK in ClassModel.MataKuliah.listDataMataKuliah)
                {
                    dgvMataKuliah.Rows.Add(nomor, dataMK.Kode, dataMK.MataKuliah);
                    nomor++;
                }
            }
            else
            {
                MessageBox.Show(webApi.ReturnMessage(response));
            }
            dgvMataKuliah.PerformLayout();
        }

        private async Task LoadKonsentrasi()
        {
            cmbKonsentrasi.DataSource = null;
            MKByIdProdi m = new MKByIdProdi() { IdProdi = UidProdiDipilih };
            string jsonData = JsonConvert.SerializeObject(m);

            response = await webApi.Post(URLGetMasterKonsentrasi, jsonData, true);
            if (response.IsSuccessStatusCode)
            {
                List<MasterKonsentrasi> oListMK = JsonConvert.DeserializeObject<List<MasterKonsentrasi>>(response.Content.ReadAsStringAsync().Result);
                oListMK.Insert(0, new MasterKonsentrasi() { IdKonsentrasi = 0, NamaKonsentrasi = "Pilih" });
                cmbKonsentrasi.DataSource = oListMK;
                cmbKonsentrasi.DisplayMember = "NamaKonsentrasi";
                cmbKonsentrasi.ValueMember = "IdKonsentrasi";
                cmbKonsentrasi.SelectedIndex = 0;
            }
            else
            {
                MessageBox.Show(webApi.ReturnMessage(response));
            }
        }

        private async Task LoadMKKonsentrasi()
        {
            dgvMKKonsentrasi.Rows.Clear();
            if (cmbKonsentrasi.SelectedIndex > 0 && cmbProdi.SelectedIndex > 0 && cmbFakultas.SelectedIndex > 0)
            {
                int idKonsentrasi = int.Parse(cmbKonsentrasi.SelectedValue.ToString());

                Loading(true);
                string jsonData = JsonConvert.SerializeObject(new { IdKonsentrasi = idKonsentrasi });
                response = await webApi.Post(URLGetMKKonsentrasi, jsonData, true);
                if (!response.IsSuccessStatusCode)
                {
                    MessageBox.Show(webApi.ReturnMessage(response));
                    return;
                }

                List<MataKuliahKonsentrasi> listMKKonsentrasi =
                    JsonConvert.DeserializeObject<List<MataKuliahKonsentrasi>>(response.Content.ReadAsStringAsync().Result);
                foreach (MataKuliahKonsentrasi mk in listMKKonsentrasi)
                {
                    dgvMKKonsentrasi.Rows.Add(mk.IdKonsentrasi, mk.Kode, mk.MataKuliah, mk.TahunMulai);
                }
                Loading(false);
            }
        }

        private async void cmbKonsentrasi_SelectedIndexChanged(object sender, EventArgs e)
        {
            await LoadMKKonsentrasi();
        }

        private void btnTutup_Click(object sender, EventArgs e)
        {
            Close();
        }

        public async void saveKonsentrasi(string namaKonsentrasi, string namaKonsentrasiEn, string singkatanKonsnetrasi)
        {
            //MessageBox.Show(string.Format("{0} {1} {2}", namaKonsentrasi, namaKonsentrasiEn, singkatanKonsnetrasi));
            Loading(true);
            string idProdi = UidProdiDipilih;
            var saveData = new
            {
                IdProdi = idProdi,
                NamaKonsentrasi = namaKonsentrasi,
                NamaKonsentrasiEn = namaKonsentrasiEn,
                SingkatanKonsentrasi = singkatanKonsnetrasi
            };
            string jsonData = JsonConvert.SerializeObject(saveData);
            response = await webApi.Post(URLSaveMasterKonsentrasi, jsonData, true);
            if (!response.IsSuccessStatusCode)
            {
                MessageBox.Show(webApi.ReturnMessage(response));
                return;
            }

            await LoadKonsentrasi();
            Loading(false);

        }

        private void btnCreateKonsenttrasi_Click(object sender, EventArgs e)
        {
            using (var form = new FormCreateKonsentrasi(this))
            {
                form.ShowDialog(this);
            }
        }

        private void dgvMataKuliah_MouseMove(object sender, MouseEventArgs e)
        {
            dragAndDropAdd.DragMove(e, dgvMataKuliah, valueAdd);
        }

        private void dgvMataKuliah_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void dgvMataKuliah_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void dgvMataKuliah_MouseDown(object sender, MouseEventArgs e)
        {
            var hittest = dragAndDropAdd.DragMouseDownFirst(e, dgvMataKuliah);
            if (hittest.RowIndex < 0 || hittest.ColumnIndex < 0)
            {
                return;
            }

            string kode = dgvMataKuliah.Rows[hittest.RowIndex].Cells["Kode"].Value.ToString();
            string mataKuliah = dgvMataKuliah.Rows[hittest.RowIndex].Cells["MataKuliah"].Value.ToString();
            int idKonsentrasi = int.Parse(cmbKonsentrasi.SelectedValue.ToString());
            int tahunBerlaku = DateTime.Now.Year;

            valueAdd = new { Kode = kode, IdKonsentrasi = idKonsentrasi, MataKuliah = mataKuliah, TahunBerlaku = tahunBerlaku };
            dragAndDropAdd.DragMouseDownSecond(e, dgvMKKonsentrasi, hittest, valueAdd);
        }

        private async void dgvMataKuliah_DragDrop(object sender, DragEventArgs e)
        {
            var hittest = dragAndDropDelete.DragDrop(e, dgvMataKuliah);

            if (valueDelete == null)
            {
                return;
            }

            string kode = valueDelete.Kode;
            string idKonsentrasi = valueDelete.IdKonsentrasi;
            int tahunMulai = valueDelete.TahunMulai;

            var delData = new { Kode = kode, IdKonsentrasi = idKonsentrasi, TahunMulai = tahunMulai };

            string jsonData = JsonConvert.SerializeObject(delData);
            response = await webApi.Post(URLDeleteMKKonsentrasi, jsonData, true);
            if (!response.IsSuccessStatusCode)
            {
                MessageBox.Show(webApi.ReturnMessage(response));
                return;
            }

            await LoadMKKonsentrasi();
        }

        private void dgvMKKonsentrasi_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void dgvMKKonsentrasi_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void dgvMKKonsentrasi_MouseMove(object sender, MouseEventArgs e)
        {
            dragAndDropDelete.DragMove(e, dgvMKKonsentrasi, valueDelete);
        }

        private void dgvMKKonsentrasi_MouseDown(object sender, MouseEventArgs e)
        {
            var hittest = dragAndDropDelete.DragMouseDownFirst(e, dgvMKKonsentrasi);
            if (hittest.RowIndex < 0 || hittest.ColumnIndex < 0)
            {
                return;
            }

            int tahunMulai = int.Parse(dgvMKKonsentrasi.Rows[hittest.RowIndex].Cells["TahunMulai"].Value.ToString());
            string kode = dgvMKKonsentrasi.Rows[hittest.RowIndex].Cells["kKode"].Value.ToString();
            string idKonsentrasi = dgvMKKonsentrasi.Rows[hittest.RowIndex].Cells["IdKonsentrasi"].Value.ToString();

            valueDelete = new
            {
                TahunMulai = tahunMulai,
                Kode = kode,
                IdKonsentrasi = idKonsentrasi
            };

            dragAndDropDelete.DragMouseDownSecond(e, dgvMataKuliah, hittest, valueDelete);
        }

        private async void dgvMKKonsentrasi_DragDrop(object sender, DragEventArgs e)
        {
            var hittest = dragAndDropAdd.DragDrop(e, dgvMKKonsentrasi);
            if (valueAdd == null)
            {
                return;
            }
            string jsonData = JsonConvert.SerializeObject(valueAdd);
            response = await webApi.Post(URLSaveMKKonsentrasi, jsonData, true);
            if (!response.IsSuccessStatusCode)
            {
                MessageBox.Show(webApi.ReturnMessage(response));
                return;
            }

            dgvMKKonsentrasi.Rows.Add(valueAdd.IdKonsentrasi, valueAdd.Kode, valueAdd.MataKuliah, valueAdd.TahunBerlaku);
        }
    }
}
