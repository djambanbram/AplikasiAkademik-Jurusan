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
using static System.Windows.Forms.DataGridView;

namespace MataKuliah
{
    public partial class FormMataKuliahPrasyarat : Syncfusion.Windows.Forms.MetroForm
    {
        private List<Fakultas> listFakultas;
        private List<Prodi> listProdi;

        public static string baseAddress = ConfigurationManager.AppSettings["baseAddress"];
        private string URLGetMK = baseAddress + "/jurusan_api/api/kurikulum/get_mk";
        private string URLGetMKPrasyarat = baseAddress + "/jurusan_api/api/kurikulum/get_mk_prasyarat";
        private string URLSaveMKPrasyarat = baseAddress + "/jurusan_api/api/kurikulum/save_mk_prasyarat";
        private string URLDelMKPrasyarat = baseAddress + "/jurusan_api/api/kurikulum/del_mk_prasyarat";


        private string UidProdiDipilih;
        private DragandDrop dragAndDropAdd;
        private DragandDrop dragAndDropDelete;
        private dynamic valueMKPrasyaratAdd;
        private dynamic valueMKPrasyaratDelete;

        private WebApi webApi;
        private HttpResponseMessage response;

        private List<DataMataKuliahPrasyarat> listDataMKPrasyarat;

        public FormMataKuliahPrasyarat()
        {
            InitializeComponent();
            webApi = new WebApi();
            dragAndDropAdd = new DragandDrop();
            dragAndDropDelete = new DragandDrop();

            dgvMKPrasyarat.Columns.Add(new TreeGridColumn() { Name = "Node", HeaderText = "", Width = 30 });
            dgvMKPrasyarat.Columns.Add(new DataGridViewTextBoxColumn() { Name = "tKode", HeaderText = "Kode", Width = 50 });
            dgvMKPrasyarat.Columns.Add(new DataGridViewTextBoxColumn() { Name = "tMataKuliah", HeaderText = "Mata Kuliah", Width = 350 });
            dgvMKPrasyarat.Columns.Add(new DataGridViewTextBoxColumn() { Name = "tParent", HeaderText = "Parent", Width = 30, Visible = false });

        }

        private void Loading(bool isLoading)
        {
            splitContainerAdv1.Enabled = !isLoading;
            gradientPanel2.Enabled = !isLoading;
            gradientPanel2.Enabled = !isLoading;
            progressBar1.Visible = isLoading;
        }

        private void FormMataKuliahPrasyarat_Load(object sender, EventArgs e)
        {
            listFakultas = new List<Fakultas>(Organisasi.listFakultas);
            listFakultas.Insert(0, new Fakultas() { KodeFakultas = "-", NamaFakultas = "Pilih" });
            cmbFakultas.DataSource = listFakultas;
            cmbFakultas.DisplayMember = "NamaFakultas";
            cmbFakultas.ValueMember = "KodeFakultas";
            cmbFakultas.SelectedIndex = 0;
        }

        private async void cmbProdi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbProdi.SelectedIndex > 0)
            {
                UidProdiDipilih = cmbProdi.SelectedValue.ToString();
                Loading(true);
                await LoadMK();
                await LoadMKPrasyarat();
                Loading(false);
            }
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

        private async Task LoadMKPrasyarat()
        {
            MKByIdProdi m = new MKByIdProdi() { IdProdi = UidProdiDipilih };
            string jsonData = JsonConvert.SerializeObject(m);

            if (ClassModel.MataKuliah.listDataMataKuliah.Count > 0)
            {
                dgvMKPrasyarat.Nodes.Clear();
                foreach (DataMataKuliah dataMK in ClassModel.MataKuliah.listDataMataKuliah)
                {
                    dgvMKPrasyarat.Nodes.Add(null, dataMK.Kode, dataMK.MataKuliah, "1");
                }

                response = await webApi.Post(URLGetMKPrasyarat, jsonData, true);
                if (response.IsSuccessStatusCode)
                {
                    List<dynamic> oListMK = JsonConvert.DeserializeObject<List<dynamic>>(response.Content.ReadAsStringAsync().Result);
                    MataKuliahPrasyaratBinding mkBinding = new MataKuliahPrasyaratBinding(oListMK);
                    listDataMKPrasyarat = new List<DataMataKuliahPrasyarat>((ClassModel.MataKuliah.listDataMataKuliahPrasyarat).Where(p => string.IsNullOrWhiteSpace(p.KodePrasyarat) == false).ToList());

                    foreach (TreeGridNode tree in dgvMKPrasyarat.Nodes)
                    {
                        foreach (DataMataKuliahPrasyarat prasy in listDataMKPrasyarat)
                        {
                            if (tree.Cells["tKode"].Value.ToString().Trim() == prasy.Kode.Trim())
                            {
                                TreeGridNode tgn = tree.Nodes.Add(null, prasy.KodePrasyarat, prasy.MataKuliahPrasyarat, "0");
                                tgn.DefaultCellStyle.BackColor = Color.LightGray;
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show(webApi.ReturnMessage(response));
                }
                dgvMKPrasyarat.PerformLayout();
            }
        }

        private void dgvMataKuliah_MouseMove(object sender, MouseEventArgs e)
        {
            dragAndDropAdd.DragMove(e, dgvMataKuliah, valueMKPrasyaratAdd);
        }

        private void dgvMKPrasyarat_MouseMove(object sender, MouseEventArgs e)
        {
            dragAndDropDelete.DragMove(e, dgvMKPrasyarat, valueMKPrasyaratDelete);
        }

        private void dgvMataKuliah_MouseDown(object sender, MouseEventArgs e)
        {
            var hitTestInfo = dragAndDropAdd.DragMouseDownFirst(e, dgvMataKuliah);
            if (hitTestInfo != null)
            {
                var kodeMK = dgvMataKuliah.Rows[hitTestInfo.RowIndex].Cells["Kode"].Value;
                var namaMK = dgvMataKuliah.Rows[hitTestInfo.RowIndex].Cells["MataKuliah"].Value;
                valueMKPrasyaratAdd = new { kodeMK, namaMK };
                dragAndDropAdd.DragMouseDownSecond(e, dgvMKPrasyarat, hitTestInfo, valueMKPrasyaratAdd);
            }
        }

        private void dgvMKPrasyarat_MouseDown(object sender, MouseEventArgs e)
        {
            var hitTestInfo = dragAndDropDelete.DragMouseDownFirst(e, dgvMKPrasyarat);
            if (hitTestInfo != null)
            {
                if (dgvMKPrasyarat.Rows[hitTestInfo.RowIndex].Cells["tParent"].Value.ToString() == "0")
                {
                    var kodeMKPrasyarat = dgvMKPrasyarat.Rows[hitTestInfo.RowIndex].Cells["tKode"].Value;
                    var kodeMK = dgvMKPrasyarat.GetNodeForRow(hitTestInfo.RowIndex).Parent.Cells["tkode"].Value;
                    var rowChild = dgvMKPrasyarat.GetNodeForRow(hitTestInfo.RowIndex).Parent.Nodes.IndexOf(dgvMKPrasyarat.Rows[hitTestInfo.RowIndex] as TreeGridNode);
                    var rowCurrent = hitTestInfo.RowIndex;
                    valueMKPrasyaratDelete = new { kodeMKPrasyarat, kodeMK, rowChild, rowCurrent };
                    dragAndDropDelete.DragMouseDownSecond(e, dgvMataKuliah, hitTestInfo, valueMKPrasyaratDelete);
                }
                else
                {
                    valueMKPrasyaratDelete = null;
                }
            }
        }

        private void dgvMKPrasyarat_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void dgvMKPrasyarat_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void dgvMataKuliah_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void dgvMataKuliah_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private async void dgvMKPrasyarat_DragDrop(object sender, DragEventArgs e)
        {
            if (valueMKPrasyaratAdd == null)
            {
                return;
            }
            var hitTest = dragAndDropAdd.DragDrop(e, dgvMKPrasyarat);
            if (hitTest != null)
            {
                if (dgvMKPrasyarat["tParent", hitTest.RowIndex].Value.ToString() == "1")
                {
                    //save prasyarat
                    DataMataKuliahPrasyarat mkPrasyarat = new DataMataKuliahPrasyarat();
                    mkPrasyarat.Kode = dgvMKPrasyarat["tKode", hitTest.RowIndex].Value.ToString();
                    mkPrasyarat.KodePrasyarat = valueMKPrasyaratAdd.kodeMK;
                    string jsonData = JsonConvert.SerializeObject(mkPrasyarat);
                    Console.Write(jsonData);
                    response = await webApi.Post(URLSaveMKPrasyarat, jsonData, true);
                    if (response.IsSuccessStatusCode)
                    {
                        TreeGridNode tgnNodes = dgvMKPrasyarat.Rows[hitTest.RowIndex] as TreeGridNode;
                        TreeGridNode tgn = tgnNodes.Nodes.Add(null, valueMKPrasyaratAdd.kodeMK, valueMKPrasyaratAdd.namaMK, "0");
                        tgn.DefaultCellStyle.BackColor = Color.LightGray;
                    }
                    else
                    {
                        MessageBox.Show(webApi.ReturnMessage(response));
                    }
                }
                else
                {
                    MessageBox.Show("Drag di mata kuliah yang perlu prasyarat (baris berwarna putih)");
                }
            }
            valueMKPrasyaratAdd = null;
        }

        private async void dgvMataKuliah_DragDrop(object sender, DragEventArgs e)
        {
            if (valueMKPrasyaratDelete == null)
            {
                return;
            }
            var hitTest = dragAndDropDelete.DragDrop(e, dgvMataKuliah);

            //Delete prasyarat
            DataMataKuliahPrasyarat mkPrasyarat = new DataMataKuliahPrasyarat();
            mkPrasyarat.Kode = valueMKPrasyaratDelete.kodeMK;
            mkPrasyarat.KodePrasyarat = valueMKPrasyaratDelete.kodeMKPrasyarat;
            int rowDel = valueMKPrasyaratDelete.rowChild;
            int rowCurrent = valueMKPrasyaratDelete.rowCurrent;
            string jsonData = JsonConvert.SerializeObject(mkPrasyarat);
            response = await webApi.Post(URLDelMKPrasyarat, jsonData, true);
            if (response.IsSuccessStatusCode)
            {
                var nodeParent = dgvMKPrasyarat.GetNodeForRow(rowCurrent).Parent;
                if (nodeParent.HasChildren)
                {
                    nodeParent.Nodes.RemoveAt(rowDel);
                }
            }
            valueMKPrasyaratDelete = null;

        }

        private void btnTutup_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
