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
using Newtonsoft.Json;
using PenawaranKurikulum.DataBinding;
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

namespace PenawaranKurikulum
{
    public partial class FormAlokasiLabMK : Syncfusion.Windows.Forms.MetroForm
    {
        public static string baseAddress = ConfigurationManager.AppSettings["baseAddress"];
        private string URLGetMKSudahDitawarkan = baseAddress + "/jurusan_api/api/kurikulum/get_mk_sudah_ditawarkan";
        private string URLGetRuangan = baseAddress + "/jurusan_api/api/kelas/get_ruangan";
        private string URLGetMemberRuangan = baseAddress + "/jurusan_api/api/kelas/get_member_ruangan";

        private WebApi webApi;
        private HttpResponseMessage response;

        private List<Fakultas> listFakultas;
        private List<Prodi> listProdi;
        private List<Program> listProgram;

        private string kodeProgramDipilih;
        private string idProdiDipilih;

        public FormAlokasiLabMK()
        {
            InitializeComponent();
            webApi = new WebApi();
        }

        private void btnTutup_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Loading(bool isLoading)
        {
            splitContainerAdv1.Enabled = !isLoading;
            gradientPanel2.Enabled = !isLoading;
            flowLayoutPanel1.Enabled = !isLoading;
            progressBar1.Visible = isLoading;
        }

        private void FormAlokasiLabMK_Load(object sender, EventArgs e)
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

        private void cmbProdi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbFakultas.SelectedIndex > 0 && cmbProdi.SelectedIndex > 0)
            {
                idProdiDipilih = cmbProdi.SelectedValue.ToString();
                listProgram = Organisasi.listProgram.Where(program => program.Prodi.Uid == idProdiDipilih).ToList();
                listProgram.Insert(0, new Program() { KodeProgram = "-", NamaProgram = "Pilih" });
                cmbProgram.DataSource = listProgram;
                cmbProgram.DisplayMember = "NamaProgram";
                cmbProgram.ValueMember = "KodeProgram";
                cmbProgram.SelectedIndex = 0;
            }
        }

        private async void cmbProgram_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbProgram.SelectedIndex > 0)
            {
                Loading(true);
                kodeProgramDipilih = cmbProgram.SelectedValue.ToString();
                var data = new
                {
                    TahunAkademik = LoginAccess.TahunAkademik,
                    KodeJurusan = kodeProgramDipilih,
                    Semester = LoginAccess.KodeSemester,
                    IdProdi = cmbProdi.SelectedValue.ToString()
                };

                string jsonData = JsonConvert.SerializeObject(data);

                //Load Mata Kuliah
                response = await webApi.Post(URLGetMKSudahDitawarkan, jsonData, true);
                if (response.IsSuccessStatusCode)
                {
                    List<dynamic> oListMkSudahDitawarkan = JsonConvert.DeserializeObject<List<dynamic>>(response.Content.ReadAsStringAsync().Result);
                    MataKuliahSudahDitawarkanBinding mkBinding = new MataKuliahSudahDitawarkanBinding(oListMkSudahDitawarkan);
                    dgvMKPraktikum.Rows.Clear();
                    List<MataKuliahDitawarkan> tempList = new List<MataKuliahDitawarkan>(ClassModel.MataKuliah.listMataKuliahSudahDitawarkan);
                    int no = 1;
                    foreach (MataKuliahDitawarkan mk in tempList.Where(mktsd => mktsd.SksPraktikum != 0).ToList())
                    {
                        dgvMKPraktikum.Rows.Add(no, mk.Kode, mk.MataKuliah, mk.SksTeori, mk.SksPraktikum, mk.JumlahKelas);
                        no++;
                    }
                }
                else
                {
                    MessageBox.Show(webApi.ReturnMessage(response));
                }

                //Load Ruangan
                response = await webApi.Post(URLGetRuangan, string.Empty, true);
                dgvDaftarLab.Nodes.Clear();
                if (response.IsSuccessStatusCode)
                {
                    List<dynamic> listRuangan = JsonConvert.DeserializeObject<List<dynamic>>(response.Content.ReadAsStringAsync().Result);
                    listRuangan = listRuangan.Where(r => r.IsDipakaiPraktikum == 1).ToList();
                    foreach (var item in listRuangan)
                    {
                        dgvDaftarLab.Nodes.Add(null, item.Ruang);
                    }
                }
                else
                {
                    MessageBox.Show(webApi.ReturnMessage(response));
                }

                //Load member ruangan
                response = await webApi.Post(URLGetMemberRuangan, jsonData, true);
                if (response.IsSuccessStatusCode)
                {
                    List<MemberKelas> listMemberRuangan = JsonConvert.DeserializeObject<List<MemberKelas>>(response.Content.ReadAsStringAsync().Result);
                    foreach (TreeGridNode tgn in dgvDaftarLab.Nodes)
                    {
                        int i = 0;
                        foreach (var item in listMemberRuangan)
                        {
                            if (tgn.Cells["Ruang"].Value.ToString() == item.Ruang)
                            {
                                tgn.Nodes.Add(null, item.Kode, item.Ruang, item.MataKuliah);
                                tgn.Nodes[i].DefaultCellStyle.BackColor = Color.LightGray;
                                i++;
                            }
                        }
                        i = 0;
                    }
                }
                else
                {
                    MessageBox.Show(webApi.ReturnMessage(response)); ;
                }

                Loading(false);
            }
        }
    }
}
