using ApiService;
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

        private HttpResponseMessage response;
        private WebApi webApi;

        public FormLogin()
        {
            InitializeComponent();
            webApi = new WebApi();
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
            if(response.IsSuccessStatusCode)
            {
                LoginAccess.username = JObject.Parse(response.Content.ReadAsStringAsync().Result)["userName"].ToString();
                LoginAccess.token_type= JObject.Parse(response.Content.ReadAsStringAsync().Result)["token_type"].ToString();
                LoginAccess.access_token = JObject.Parse(response.Content.ReadAsStringAsync().Result)["access_token"].ToString();
                LoginAccess.expires_in = JObject.Parse(response.Content.ReadAsStringAsync().Result)["expires_in"].ToString();

                Hide();
                new FormMainAplikasi().Show();
            }
            else
            {
                Error error = JsonConvert.DeserializeObject<Error>(response.Content.ReadAsStringAsync().Result);
                MessageBox.Show(error.error_description);
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
