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
    public partial class FormMataKuliahPrasyarat : Syncfusion.Windows.Forms.MetroForm
    {
        private List<Fakultas> listFakultas;
        private List<Prodi> listProdi;

        public static string baseAddress = ConfigurationManager.AppSettings["baseAddress"];
        private string URLGetMK = baseAddress + "/jurusan_api/api/kurikulum/get_mk";
        private string URLGetMKPrasyarat = baseAddress + "/jurusan_api/api/kurikulum/get_mk_prasyarat";

        private string UidProdiDipilih;
        private string KodeMKDipilih;

        private WebApi webApi;
        private HttpResponseMessage response;

        private List<DataMataKuliahPrasyarat> listDataMKPrasyarat;

        public FormMataKuliahPrasyarat()
        {
            InitializeComponent();
            webApi = new WebApi();

            dgvMKPrasyarat.Columns.Add(new TreeGridColumn() { Name = "Node", HeaderText = "", Width = 30 });
            dgvMKPrasyarat.Columns.Add(new DataGridViewTextBoxColumn() { Name = "tKode", HeaderText = "Kode", Width = 50 });
            dgvMKPrasyarat.Columns.Add(new DataGridViewTextBoxColumn() { Name = "tMataKuliah", HeaderText = "Mata Kuliah", Width = 350 });

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
            if (cmbProdi.SelectedIndex != 0)
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
            if (cmbFakultas.SelectedIndex != 0)
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
                    dgvMKPrasyarat.Nodes.Add(null, dataMK.Kode, dataMK.MataKuliah);
                }

                response = await webApi.Post(URLGetMKPrasyarat, jsonData, true);
                if (response.IsSuccessStatusCode)
                {
                    List<dynamic> oListMK = JsonConvert.DeserializeObject<List<dynamic>>(response.Content.ReadAsStringAsync().Result);
                    MataKuliahPrasyaratBinding mkBinding = new MataKuliahPrasyaratBinding(oListMK);
                    listDataMKPrasyarat = new List<DataMataKuliahPrasyarat>((ClassModel.MataKuliah.listDataMataKuliahPrasyarat).Where(p => string.IsNullOrWhiteSpace(p.KodePrasyarat) == false).ToList());

                    foreach (TreeGridNode tree in dgvMKPrasyarat.Nodes)
                    {
                        TreeGridNode tgnNodes = tree;
                        foreach (DataMataKuliahPrasyarat prasy in listDataMKPrasyarat)
                        {
                            if (tree.Cells["tKode"].Value.ToString().Trim() == prasy.Kode.Trim())
                            {
                                TreeGridNode tgn = tgnNodes.Nodes.Add(null, prasy.KodePrasyarat, prasy.MataKuliahPrasyarat);
                                tgn.DefaultCellStyle.BackColor = Color.LightGray;
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show(webApi.ReturnMessage(response));
                }
            }
        }

        private void dgvMataKuliah_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private Rectangle dragBoxFromMouseDown;
        private dynamic valueFromMouseDown;

        private void dgvMataKuliah_MouseMove(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                // If the mouse moves outside the rectangle, start the drag.
                if (dragBoxFromMouseDown != Rectangle.Empty && !dragBoxFromMouseDown.Contains(e.X, e.Y))
                {
                    // Proceed with the drag and drop, passing in the list item.                    
                    DragDropEffects dropEffect = dgvMataKuliah.DoDragDrop(valueFromMouseDown, DragDropEffects.Copy);
                }
            }
        }

        private void dgvMataKuliah_MouseDown(object sender, MouseEventArgs e)
        {
            // Get the index of the item the mouse is below.
            var hittestInfo = dgvMataKuliah.HitTest(e.X, e.Y);

            if (hittestInfo.RowIndex != -1 && hittestInfo.ColumnIndex != -1)
            {
                var kodeMK = dgvMataKuliah.Rows[hittestInfo.RowIndex].Cells["Kode"].Value;
                var namaMK = dgvMataKuliah.Rows[hittestInfo.RowIndex].Cells["MataKuliah"].Value;
                valueFromMouseDown = new { kodeMK, namaMK };
                if (valueFromMouseDown != null)
                {
                    // Remember the point where the mouse down occurred. 
                    // The DragSize indicates the size that the mouse can move 
                    // before a drag event should be started.                
                    Size dragSize = SystemInformation.DragSize;

                    // Create a rectangle using the DragSize, with the mouse position being
                    // at the center of the rectangle.
                    dragBoxFromMouseDown = new Rectangle(new Point(e.X - (dragSize.Width / 2), e.Y - (dragSize.Height / 2)), dragSize);
                }
            }
            else
                // Reset the rectangle if the mouse is not over an item in the ListBox.
                dragBoxFromMouseDown = Rectangle.Empty;
        }

        private void dgvMKPrasyarat_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void dgvMKPrasyarat_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void dgvMKPrasyarat_DragDrop(object sender, DragEventArgs e)
        {
            // The mouse locations are relative to the screen, so they must be 
            // converted to client coordinates.
            Point clientPoint = dgvMKPrasyarat.PointToClient(new Point(e.X, e.Y));

            // If the drag operation was a copy then add the row to the other control.
            if (e.Effect == DragDropEffects.Copy)
            {
                string cellvalue = valueFromMouseDown.kodeMK;//e.Data.GetData(typeof(string)) as string;
                var hittest = dgvMKPrasyarat.HitTest(clientPoint.X, clientPoint.Y);
                if (hittest.ColumnIndex != -1
                    && hittest.RowIndex != -1)
                    dgvMKPrasyarat[hittest.ColumnIndex, hittest.RowIndex].Value = cellvalue;
                //MessageBox.Show(cellvalue);
            }
        }

        private void btnTutup_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
