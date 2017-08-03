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
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MainAplikasi
{
    public partial class FormLogin : Form
    {
        public static string baseAddress = ConfigurationManager.AppSettings["baseAddress"];
        private string URLLogin = baseAddress + "/account_api/verify";
        private string URLInitTahun = baseAddress + "/jurusan_api/api/data_support/init_tahun_aktif";
        private string URLInitSemester = baseAddress + "/jurusan_api/api/data_support/init_data_semester";

        private HttpResponseMessage response;
        private WebApi webApi;

        public FormLogin()
        {
            InitializeComponent();
            webApi = new WebApi();
#if DEBUG
            txtUsername.Text = "bangkit@amikom.ac.id";
            txtPassword.Text = "OpK3u@ngan";
#else
            txtUsername.Text = string.Empty;
            txtPassword.Text = string.Empty;
#endif
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

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
                    if (kodeSemester == 7 || kodeSemester == 8)
                    {
                        MessageBox.Show("Aplikasi belum support untuk semester remidial");
                        Enabled = true;
                        return;
                    }

                    LoginAccess.TahunAkademik = JObject.Parse(response.Content.ReadAsStringAsync().Result)["TahunAkademik"].ToString();
                    LoginAccess.Semester = JObject.Parse(response.Content.ReadAsStringAsync().Result)["Semester"]["Nama"].ToString();
                    LoginAccess.IdTahun = int.Parse(JObject.Parse(response.Content.ReadAsStringAsync().Result)["IdTahun"].ToString());
                    LoginAccess.KodeSemester = kodeSemester;
#else
                    LoginAccess.TahunAkademik = "2017/2018";
                    LoginAccess.Semester = "Ganjil";
                    LoginAccess.IdTahun = 51;
                    LoginAccess.KodeSemester = 1;

                    //LoginAccess.TahunAkademik = "2016/2017";
                    //LoginAccess.Semester = "Ganjil";
                    //LoginAccess.IdTahun = 44;
                    //LoginAccess.KodeSemester = 1;
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

            Enabled = true;
        }

        class Error
        {
            public string error { get; set; }

            public string error_description { get; set; }
        }
    }
}
