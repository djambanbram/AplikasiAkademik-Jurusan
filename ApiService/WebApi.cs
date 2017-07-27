using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace ApiService
{
    public class WebApi
    {
        //public async Task<HttpResponseMessage> Post(string path, string jsonData = "")
        //{
        //    using (var client = new HttpClient())
        //    {
        //        HttpContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
        //        Task<HttpResponseMessage> response = client.PostAsync(path, content);
        //        HttpResponseMessage message = await response;
        //        return message;
        //    }
        //}

        public async Task<HttpResponseMessage> Post(string path, List<KeyValuePair<string, string>> listValue)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    HttpContent content = new FormUrlEncodedContent(listValue);
                    Task<HttpResponseMessage> response = client.PostAsync(path, content);
                    HttpResponseMessage message = await response;
                    return message;
                }
                catch (HttpRequestException ex)
                {
                    HttpResponseMessage messageResponse = new HttpResponseMessage();
                    var message = new { Message = "Koneksi bermasalah. Periksa kembali koneksi internet anda" };
                    StringContent stringContent = new StringContent(JsonConvert.SerializeObject(message));
                    messageResponse.Content = stringContent;
                    messageResponse.StatusCode = System.Net.HttpStatusCode.ExpectationFailed;
                    return messageResponse;
                }
            }
        }

        public async Task<HttpResponseMessage> Post(string path, string jsonData, bool isUseOAuth)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    if (isUseOAuth)
                    {
                        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(LoginAccess.token_type, LoginAccess.access_token);
                    }
                    HttpContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                    Task<HttpResponseMessage> response = client.PostAsync(path, content);
                    HttpResponseMessage message = await response;
                    return message;
                }
                catch (HttpRequestException ex)
                {
                    HttpResponseMessage messageResponse = new HttpResponseMessage();
                    var message = new { Message = "Tidak dapat terkoneksi ke server. Periksa kembali koneksi internet anda." };
                    StringContent stringContent = new StringContent(JsonConvert.SerializeObject(message));
                    messageResponse.Content = stringContent;
                    messageResponse.StatusCode = System.Net.HttpStatusCode.ExpectationFailed;
                    return messageResponse;
                }
            }
        }

        public async Task<HttpResponseMessage> Get(string path)
        {
            using (var client = new HttpClient())
            {
                Task<HttpResponseMessage> response = client.GetAsync(path);
                HttpResponseMessage message = await response;
                return message;
            }
        }

        public string ReturnMessage(HttpResponseMessage response)
        {
            return JObject.Parse(response.Content.ReadAsStringAsync().Result)["Message"].ToString();
        }
    }
}
