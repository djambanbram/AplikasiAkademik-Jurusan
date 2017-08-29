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
using MataKuliah.Lib;
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
    public partial class FormGrupMK : Syncfusion.Windows.Forms.MetroForm
    {
        public static string baseAddress = ConfigurationManager.AppSettings["baseAddress"];
        private string URLGetMK = baseAddress + "/jurusan_api/api/kurikulum/get_mk";
        private string UrlSaveGrupKuliah = baseAddress + "/jurusan_api/api/kurikulum/save_kuliah_join";
        private string UrlGetGrupKuliah = baseAddress + "/jurusan_api/api/kurikulum/get_kuliah_join";
        private string UrlDelGrupKuliah = baseAddress + "/jurusan_api/api/kurikulum/del_kuliah_join";

        private List<Fakultas> listFakultas;
        private List<Prodi> listProdi;

        private WebApi webApi;
        private HttpResponseMessage response;

        private string UidProdiDipilih;
        private string KodeMKDipilih;

        private DragandDrop dragAndDropAdd;
        private DragandDrop dragAndDropDelete;

        private dynamic valueAdd;
        private dynamic valueDelete;

        public FormGrupMK()
        {
            InitializeComponent();
            webApi = new WebApi();
            dragAndDropAdd = new DragandDrop();
            dragAndDropDelete = new DragandDrop();
        }

        private void Loading(bool isLoading)
        {
            dgvDaftarGrup.Enabled = !isLoading;
            flowLayoutPanel1.Enabled = !isLoading;
            gradientPanel1.Enabled = !isLoading;
            gradientPanel2.Enabled = !isLoading;
            progressBar1.Visible = isLoading;
        }

        private void btnTutup_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void FormMappingMataKuliahLintasProdi_Load(object sender, EventArgs e)
        {
            listFakultas = new List<Fakultas>(Organisasi.listFakultas);
            listFakultas.Insert(0, new Fakultas() { KodeFakultas = "-", NamaFakultas = "Pilih" });
            cmbFakultas.DataSource = listFakultas;
            cmbFakultas.DisplayMember = "NamaFakultas";
            cmbFakultas.ValueMember = "KodeFakultas";
            cmbFakultas.SelectedIndex = 0;

            await LoadGrupKuliah();
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
            if (cmbProdi.SelectedIndex <= 0)
            {
                return;
            }

            UidProdiDipilih = cmbProdi.SelectedValue.ToString();
            await LoadMK();
        }

        private async Task LoadMK()
        {

            MKByIdProdi m = new MKByIdProdi() { IdProdi = UidProdiDipilih };
            string jsonData = JsonConvert.SerializeObject(m);
            Loading(true);
            response = await webApi.Post(URLGetMK, jsonData, true);
            if (response.IsSuccessStatusCode)
            {
                List<dynamic> oListMK = JsonConvert.DeserializeObject<List<dynamic>>(response.Content.ReadAsStringAsync().Result);
                MataKuliahBinding mkBinding = new MataKuliahBinding(oListMK);

                dgvMataKuliah.Rows.Clear();
                foreach (DataMataKuliah dataMK in ClassModel.MataKuliah.listDataMataKuliah)
                {
                    dgvMataKuliah.Rows.Add(dataMK.Kode, dataMK.MataKuliah);
                }
            }
            else
            {
                MessageBox.Show(webApi.ReturnMessage(response));
            }
            dgvMataKuliah.PerformLayout();
            Loading(false);
        }

        private async Task LoadGrupKuliah()
        {
            var dataGet = new { TahunAkademik = LoginAccess.TahunAkademik, Semester = LoginAccess.KodeSemester };
            Loading(true);
            var jsonData = JsonConvert.SerializeObject(dataGet);
            response = await webApi.Post(UrlGetGrupKuliah, jsonData, true);
            if (!response.IsSuccessStatusCode)
            {
                MessageBox.Show(webApi.ReturnMessage(response));
                Loading(false);
                return;
            }

            dgvDaftarGrup.Rows.Clear();
            List<KuliahJoin> listKuliahJoin = JsonConvert.DeserializeObject<List<KuliahJoin>>(response.Content.ReadAsStringAsync().Result);
            foreach (KuliahJoin ks in listKuliahJoin)
            {
                dgvDaftarGrup.Rows.Add(ks.NamaGrup, ks.KodeParent, ks.MataKuliahParent, ks.KodeChild, ks.MataKuliahChild);
            }
            Loading(false);
        }

        private void dgvMataKuliah_MouseMove(object sender, MouseEventArgs e)
        {
            dragAndDropAdd.DragMove(e, dgvMataKuliah, valueAdd);
        }

        private void dgvMataKuliah_MouseDown(object sender, MouseEventArgs e)
        {
            var hittest = dragAndDropAdd.DragMouseDownFirst(e, dgvMataKuliah);
            valueDelete = null;
            if (hittest == null)
            {
                return;
            }
            if (hittest.RowIndex < 0 || hittest.ColumnIndex < 0)
            {
                return;
            }

            valueAdd = new
            {
                Kode = dgvMataKuliah.Rows[hittest.RowIndex].Cells["mKode"].Value.ToString(),
                MataKuliah = dgvMataKuliah.Rows[hittest.RowIndex].Cells["mMataKuliah"].Value.ToString()
            };

            dragAndDropAdd.DragMouseDownSecond(e, dgvGrupMK, hittest, valueAdd);
        }

        private void dgvMataKuliah_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void dgvMataKuliah_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void dgvMataKuliah_DragDrop(object sender, DragEventArgs e)
        {
            if (valueDelete == null)
            {
                return;
            }
            var hittest = dragAndDropDelete.DragDrop(e, dgvMataKuliah);
            int rowDel = int.Parse(valueDelete.RowDel.ToString());
            dgvGrupMK.Rows.RemoveAt(rowDel);

            if (dgvGrupMK.Rows.Count >= 1)
            {
                dgvGrupMK.Rows[0].DefaultCellStyle.BackColor = Color.LightSkyBlue;
            }

            valueDelete = null;
        }

        private void dgvGrupMK_MouseMove(object sender, MouseEventArgs e)
        {
            dragAndDropDelete.DragMove(e, dgvGrupMK, valueDelete);
        }

        private void dgvGrupMK_MouseDown(object sender, MouseEventArgs e)
        {
            var hittest = dragAndDropDelete.DragMouseDownFirst(e, dgvGrupMK);
            valueAdd = null;
            if (hittest == null)
            {
                return;
            }
            if (hittest.RowIndex < 0 || hittest.ColumnIndex < 0)
            {
                return;
            }

            valueDelete = new
            {
                Kode = dgvGrupMK.Rows[hittest.RowIndex].Cells["Kode"].Value.ToString(),
                MataKuliah = dgvGrupMK.Rows[hittest.RowIndex].Cells["MataKuliah"].Value.ToString(),
                RowDel = hittest.RowIndex
            };

            dragAndDropDelete.DragMouseDownSecond(e, dgvMataKuliah, hittest, valueDelete);
        }

        private void dgvGrupMK_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void dgvGrupMK_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void dgvGrupMK_DragDrop(object sender, DragEventArgs e)
        {
            if (valueAdd == null)
            {
                return;
            }

            var hittest = dragAndDropAdd.DragDrop(e, dgvGrupMK);

            var kode = valueAdd.Kode as string;
            var mataKuliah = valueAdd.MataKuliah as string;
            foreach (DataGridViewRow row in dgvGrupMK.Rows)
            {
                if (row.Cells["Kode"].Value.ToString() == kode)
                {
                    MessageBox.Show(string.Format("Mata kuliah {0} ({1}) sudah masuk ke dalam grup ini", mataKuliah, kode));
                    return;
                }
            }

            dgvGrupMK.Rows.Add(valueAdd.Kode, valueAdd.MataKuliah);
            if (dgvGrupMK.Rows.Count >= 1)
            {
                dgvGrupMK.Rows[0].DefaultCellStyle.BackColor = Color.LightSkyBlue;
            }

            dgvGrupMK.ClearSelection();
            valueAdd = null;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            dgvGrupMK.Rows.Clear();
            txtNamaGrup.Text = string.Empty;
        }

        private async void btnSimpan_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNamaGrup.Text))
            {
                MessageBox.Show("nama grup harus diisi");
                return;
            }

            var tahunAkademik = LoginAccess.TahunAkademik;
            var semester = LoginAccess.KodeSemester;
            var namaGrup = txtNamaGrup.Text.Trim(); ;
            string kode = dgvGrupMK.Rows[0].Cells["Kode"].Value.ToString();
            string[] arrKodeJoin = new string[dgvGrupMK.Rows.Count];

            int i = 0;
            foreach (DataGridViewRow row in dgvGrupMK.Rows)
            {
                arrKodeJoin[i] = row.Cells["Kode"].Value.ToString();
                i++;
            }

            var dataSave = new
            {
                TahunAkademik = tahunAkademik,
                Semester = semester,
                NamaGrup = namaGrup,
                Kode = kode,
                KodeJoin = arrKodeJoin
            };

            var jsonData = JsonConvert.SerializeObject(dataSave);
            response = await webApi.Post(UrlSaveGrupKuliah, jsonData, true);
            if (!response.IsSuccessStatusCode)
            {
                MessageBox.Show(webApi.ReturnMessage(response));
                return;
            }
            dgvGrupMK.Rows.Clear();
            txtNamaGrup.Text = string.Empty;
            await LoadGrupKuliah();
        }

        private async void btnHapus_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvDaftarGrup.Rows)
            {
                if (Convert.ToBoolean(row.Cells["Hapus"].Value) == true)
                {
                    var dataDel = new
                    {
                        TahunAkademik = LoginAccess.TahunAkademik,
                        Semester = LoginAccess.KodeSemester,
                        Kode = row.Cells["KodeParent"].Value.ToString(),
                        KodeMember = row.Cells["KodeMember"].Value.ToString(),
                        NamaGrup = row.Cells["NamaGrup"].Value.ToString()
                    };

                    var jsonData = JsonConvert.SerializeObject(dataDel);
                    response = await webApi.Post(UrlDelGrupKuliah, jsonData, true);
                }
            }

            await LoadGrupKuliah();
        }
    }
}
