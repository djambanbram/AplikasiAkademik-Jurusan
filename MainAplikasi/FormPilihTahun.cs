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
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Net.Http;
using System.Text;
using System.Windows.Forms;

namespace MainAplikasi
{
    public partial class FormPilihTahun : Syncfusion.Windows.Forms.MetroForm
    {
        private IListenerByPass il;
        private HttpResponseMessage response;
        private WebApi webApi;

        public static string baseAddress = ConfigurationManager.AppSettings["baseAddress"];
        public static string baseLogin = ConfigurationManager.AppSettings["baseLogin"];
        private string URLLogin = baseLogin + "/account_api/verify";
        private string URLInitTahun = baseAddress + "/jurusan_api/api/data_support/init_tahun_aktif";
        private string URLInitSemester = baseAddress + "/jurusan_api/api/data_support/init_data_semester";

        public FormPilihTahun(IListenerByPass il)
        {
            InitializeComponent();
            webApi = new WebApi();
            this.il = il;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            string username = "190302038";
            string password = "FW7u@Mv!";

            List<KeyValuePair<string, string>> listValue = new List<KeyValuePair<string, string>>();
            listValue.Add(new KeyValuePair<string, string>("grant_type", "password"));
            listValue.Add(new KeyValuePair<string, string>("username", username));
            listValue.Add(new KeyValuePair<string, string>("password", password));

            Enabled = false;
            response = await webApi.Post(URLLogin, listValue);
            if (response.IsSuccessStatusCode)
            {
                LoginAccess.username = JObject.Parse(response.Content.ReadAsStringAsync().Result)["userName"].ToString();
                LoginAccess.token_type = JObject.Parse(response.Content.ReadAsStringAsync().Result)["token_type"].ToString();
                LoginAccess.access_token = JObject.Parse(response.Content.ReadAsStringAsync().Result)["access_token"].ToString();
                LoginAccess.expires_in = JObject.Parse(response.Content.ReadAsStringAsync().Result)["expires_in"].ToString();

                response = await webApi.Post(URLInitTahun, string.Empty, false);
                if (response.IsSuccessStatusCode)
                {
#if !DEBUG
                    var kodeSemester = int.Parse(JObject.Parse(response.Content.ReadAsStringAsync().Result)["Semester"]["Kode"].ToString());
                    //if (kodeSemester == 7 || kodeSemester == 8)
                    //{
                    //    MessageBox.Show("Aplikasi belum support untuk semester remidial");
                    //    Enabled = true;
                    //    return;
                    //}

                    LoginAccess.TahunAkademik = JObject.Parse(response.Content.ReadAsStringAsync().Result)["TahunAkademik"].ToString();
                    LoginAccess.Semester = JObject.Parse(response.Content.ReadAsStringAsync().Result)["Semester"]["Nama"].ToString();
                    LoginAccess.IdTahun = int.Parse(JObject.Parse(response.Content.ReadAsStringAsync().Result)["IdTahun"].ToString());
                    LoginAccess.KodeSemester = kodeSemester;
#else
                    //LoginAccess.TahunAkademik = "2017/2018";
                    //LoginAccess.Semester = "Ganjil";
                    //LoginAccess.IdTahun = 51;
                    //LoginAccess.KodeSemester = 1;

                    //var kodeSemester = int.Parse(JObject.Parse(response.Content.ReadAsStringAsync().Result)["Semester"]["Kode"].ToString());
                    //LoginAccess.TahunAkademik = JObject.Parse(response.Content.ReadAsStringAsync().Result)["TahunAkademik"].ToString();
                    //LoginAccess.Semester = JObject.Parse(response.Content.ReadAsStringAsync().Result)["Semester"]["Nama"].ToString();
                    //LoginAccess.IdTahun = int.Parse(JObject.Parse(response.Content.ReadAsStringAsync().Result)["IdTahun"].ToString());
                    //LoginAccess.KodeSemester = kodeSemester;

                    LoginAccess.TahunAkademik = "2017/2018";
                    LoginAccess.Semester = "Genap";
                    LoginAccess.IdTahun = 53;
                    LoginAccess.KodeSemester = 2;
#endif

                    Hide();
                    new FormMainAplikasi().Show();
                }
                else
                {
                    MessageBox.Show(webApi.ReturnMessage(response));
                    Enabled = true;
                    return;
                }

                response = await webApi.Post(URLInitSemester, string.Empty, false);
                if (response.IsSuccessStatusCode)
                {
                    List<DataSemester> listSemester = JsonConvert.DeserializeObject<List<DataSemester>>(response.Content.ReadAsStringAsync().Result);
                    Akademik.listDataSemester = listSemester;
                }
                else
                {
                    MessageBox.Show(webApi.ReturnMessage(response));
                }
            }
            else
            {
                Error error = JsonConvert.DeserializeObject<Error>(response.Content.ReadAsStringAsync().Result);
                if (error.error == null)
                {
                    MessageBox.Show(webApi.ReturnMessage(response));
                }
                else
                {
                    MessageBox.Show(error.error_description);
                }
            }

            LoginAccess.TahunAkademik = txtTahunAkademik.Text;
            LoginAccess.Semester = txtNamaSemester.Text;
            LoginAccess.IdTahun = int.Parse(txtIdTahun.Text);
            LoginAccess.KodeSemester = int.Parse(txtKodeSemester.Text);
            il.ByPass();
        }
    }

    class Error
    {
        public string error { get; set; }

        public string error_description { get; set; }
    }
}
