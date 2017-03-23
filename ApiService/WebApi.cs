using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

namespace ApiService
{
    public class WebApi
    {
        public async Task<HttpResponseMessage> Post(string path, string jsonData = "")
        {
            using (var client = new HttpClient())
            {
                HttpContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                Task<HttpResponseMessage> response = client.PostAsync(path, content);
                HttpResponseMessage message = await response;
                return message;
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
    }
}
