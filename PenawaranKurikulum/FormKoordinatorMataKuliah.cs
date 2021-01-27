#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using ClassModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;
using System.Linq;
using System.Configuration;
using ApiService;
using System.Net.Http;
using Newtonsoft.Json;
using AdvancedDataGridView;

namespace PenawaranKurikulum
{
    public partial class FormKoordinatorMataKuliah : Syncfusion.Windows.Forms.MetroForm
    {
        public static string baseAddress = ConfigurationManager.AppSettings["baseAddress"];
        private string UrlGetDosenPengajarMk = baseAddress + "/jurusan_api/api/pengajaran/list_dosen_pengajar_mk";
        private string UrlGetDosenKoordinatorMk = baseAddress + "/jurusan_api/api/pengajaran/list_dosen_koordinator_mk";
        private string UrlSaveDosenKoordinatorMk = baseAddress + "/jurusan_api/api/pengajaran/save_dosen_koordinator_mk";

        private List<Fakultas> listFakultas;
        private List<Prodi> listProdi;
        private List<DosenPengajarMk> listDosenPengajarMk;
        private List<DosenKoordinatorMk> listDosenKoordinatorMk;

        private WebApi webApi;
        private HttpResponseMessage response;

        public FormKoordinatorMataKuliah()
        {
            InitializeComponent();
            webApi = new WebApi();
        }

        private void Loading(bool isLoading)
        {
            flowLayoutPanel1.Enabled = !isLoading;
            dgvMataKuliah.Enabled = !isLoading;
            panel2.Enabled = !isLoading;
            progressBar1.Visible = isLoading;
        }

        private void btnTutup_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FormKoordinatorMataKuliah_Load(object sender, EventArgs e)
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
            dgvMataKuliah.Rows.Clear();
            dgvMataKuliah.Nodes.Clear();
            if (cmbFakultas.SelectedIndex > 0)
            {
                string kodeFakultas = cmbFakultas.SelectedValue.ToString();
                listProdi = Organisasi.listProdiPlusStudentExchange.Where(pr => pr.Fakultas.KodeFakultas == kodeFakultas).ToList();
                listProdi.Insert(0, new Prodi() { Uid = "", IdProdi = "-", NamaProdi = "Pilih" });
                cmbProdi.DataSource = listProdi;
                cmbProdi.DisplayMember = "NamaProdi";
                cmbProdi.ValueMember = "Uid";
                cmbProdi.SelectedIndex = 0;
            }
        }

        private void dgvMataKuliah_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            Rectangle rtHeader = this.dgvMataKuliah.DisplayRectangle;
            rtHeader.Height = this.dgvMataKuliah.ColumnHeadersHeight / 2;
            this.dgvMataKuliah.Invalidate(rtHeader);
        }

        private void dgvMataKuliah_Scroll(object sender, ScrollEventArgs e)
        {
            Rectangle rtHeader = this.dgvMataKuliah.DisplayRectangle;
            rtHeader.Height = this.dgvMataKuliah.ColumnHeadersHeight / 2;
            this.dgvMataKuliah.Invalidate(rtHeader);
        }

        private void dgvMataKuliah_Paint(object sender, PaintEventArgs e)
        {
            string[] monthes = { "Dosen" };
            for (int j = 7; j < 8;)
            {
                Rectangle r1 = this.dgvMataKuliah.GetCellDisplayRectangle(j, -1, true);
                int w2 = this.dgvMataKuliah.GetCellDisplayRectangle(j + 1, -1, true).Width;
                r1.X += 1;
                r1.Y += 1;
                r1.Width = r1.Width + w2 - 2;
                r1.Height = dgvMataKuliah.ColumnHeadersHeight;
                e.Graphics.FillRectangle(new SolidBrush(Color.White), r1);
                StringFormat format = new StringFormat();
                format.Alignment = StringAlignment.Center;
                format.LineAlignment = StringAlignment.Center;
                e.Graphics.DrawString(monthes[0],
                this.dgvMataKuliah.ColumnHeadersDefaultCellStyle.Font,
                new SolidBrush(this.dgvMataKuliah.ColumnHeadersDefaultCellStyle.ForeColor),
                r1,
                format);
                j += 2;
            }
        }

        private void dgvMataKuliah_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex == -1 && e.ColumnIndex > -1)
            {
                Rectangle r2 = e.CellBounds;
                r2.Y += e.CellBounds.Height / 2;
                r2.Height = e.CellBounds.Height / 2;
                e.PaintBackground(r2, true);
                e.PaintContent(r2);
                e.Handled = true;
            }
        }

        private void cmbProdi_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvMataKuliah.Rows.Clear();
            dgvMataKuliah.Nodes.Clear();
        }

        private async void btnProses_Click(object sender, EventArgs e)
        {
            if (cmbFakultas.SelectedIndex == 0 || cmbProdi.SelectedIndex == 0)
            {
                MessageBox.Show("Silahkan pilih fakultas dan prodi terlebih dahulu.");
                return;
            }
            var data = new
            {
                TahunAkademik = LoginAccess.TahunAkademik,
                Semester = LoginAccess.KodeSemester,
                IdProdi = cmbProdi.SelectedValue.ToString()
            };

            Loading(true);
            var jsonData = JsonConvert.SerializeObject(data);
            response = await webApi.Post(UrlGetDosenPengajarMk, jsonData, true);
            if (!response.IsSuccessStatusCode)
            {
                MessageBox.Show(webApi.ReturnMessage(response));
                Loading(false);
                return;
            }
            listDosenPengajarMk = JsonConvert.DeserializeObject<List<DosenPengajarMk>>(response.Content.ReadAsStringAsync().Result);

            response = await webApi.Post(UrlGetDosenKoordinatorMk, jsonData, true);
            if (!response.IsSuccessStatusCode)
            {
                MessageBox.Show(webApi.ReturnMessage(response));
                Loading(false);
                return;
            }
            listDosenKoordinatorMk = JsonConvert.DeserializeObject<List<DosenKoordinatorMk>>(response.Content.ReadAsStringAsync().Result);

            dgvMataKuliah.Rows.Clear();
            dgvMataKuliah.Nodes.Clear();
            var no = 1;

            var listMk = listDosenPengajarMk.Select(s => new { s.Kode, s.MataKuliah }).Distinct().ToList();
            listMk.ForEach(f =>
            {
                TreeGridNode nodeParent = dgvMataKuliah.Nodes.Add(null, null, no, f.Kode, f.MataKuliah, null, null, false, null);
                nodeParent.Cells[7].ReadOnly = true;
                nodeParent.DefaultCellStyle.BackColor = Color.LightGray;

                var listDosenByMk = listDosenPengajarMk.Where(w => w.Kode == f.Kode).ToList();
                listDosenByMk.ForEach(fd =>
                {
                    var koordinator = listDosenKoordinatorMk.Find(fi => fi.Kode == f.Kode && fi.Nik == fd.Nik);
                    var nodeChild = nodeParent.Nodes.Add(null, koordinator == null ? null : koordinator.IdKoordinator, null, null, null, fd.JumlahKelas, fd.TotalSks, koordinator == null ? false : true, fd.NamaDosen);
                    nodeChild.Cells[8].Tag = fd.Nik;
                    nodeChild.Cells[8].Style.BackColor = koordinator == null ? Color.White : Color.LightGreen;
                });

                nodeParent.Expand();
                no++;
            });
            Loading(false);
        }

        private async void dgvMataKuliah_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvMataKuliah["Kode", e.RowIndex].Value != null)
            {
                dgvMataKuliah["Koordinator", e.RowIndex].ReadOnly = true;
                dgvMataKuliah.CommitEdit(DataGridViewDataErrorContexts.Commit);
                return;
            }

            dgvMataKuliah.CommitEdit(DataGridViewDataErrorContexts.Commit);
            //MessageBox.Show(dgvMataKuliah["Koordinator", e.RowIndex].Value.ToString());


            var childNodeIndex = dgvMataKuliah.GetNodeForRow(e.RowIndex).Index;
            //MessageBox.Show(nodeChildCheck.ToString());
            var parentNode = dgvMataKuliah.GetNodeForRow(e.RowIndex).Parent;
            //MessageBox.Show(nodeParent.Index.ToString());
            var kodeMk = parentNode.Cells[3].Value.ToString();
            var nikDosen = dgvMataKuliah.GetNodeForRow(e.RowIndex).Cells[8].Tag.ToString();

            var data = new
            {
                TahunAkademik = LoginAccess.TahunAkademik,
                Semester = LoginAccess.KodeSemester,
                Kode = kodeMk,
                Nik = nikDosen
            };

            Loading(true);
            var jSondata = JsonConvert.SerializeObject(data);
            response = await webApi.Post(UrlSaveDosenKoordinatorMk, jSondata, true);

            if (!response.IsSuccessStatusCode)
            {
                MessageBox.Show(webApi.ReturnMessage(response));
                dgvMataKuliah.GetNodeForRow(e.RowIndex).Cells[7].Value = false;
                Loading(false);
                return;
            }

            if (parentNode.Nodes.Count <= 1)
            {
                parentNode.Nodes[0].Cells[7].Value = true;
                parentNode.Nodes[0].Cells[8].Style.BackColor = Color.LightGreen;
            }
            else if(parentNode.Nodes.Count > 1 && !Convert.ToBoolean(dgvMataKuliah.GetNodeForRow(e.RowIndex).Cells[7].Value))
            {
                dgvMataKuliah.GetNodeForRow(e.RowIndex).Cells[7].Value = true;
                dgvMataKuliah.GetNodeForRow(e.RowIndex).Cells[8].Style.BackColor = Color.LightGreen;
            }
            else
            {
                foreach (TreeGridNode tgn in parentNode.Nodes)
                {
                    if (tgn.Index != childNodeIndex)
                    {
                        tgn.Cells[7].Value = false;
                        tgn.Cells[8].Style.BackColor = Color.White;
                    }
                    else
                    {
                        if (Convert.ToBoolean(tgn.Cells[7].Value) == false)
                        {
                            tgn.Cells[8].Style.BackColor = Color.White;
                        }
                        else
                        {
                            tgn.Cells[8].Style.BackColor = Color.LightGreen;
                        }
                    }
                }
            }
            Loading(false);
            //MessageBox.Show(dgvMataKuliah.GetNodeForRow(e.RowIndex).Cells[8].Tag.ToString());
        }
    }
}
