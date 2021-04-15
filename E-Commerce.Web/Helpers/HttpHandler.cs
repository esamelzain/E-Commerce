using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Web.Helpers
{
    public class HttpHandler
    {

        public async Task<string> RequestUrl(object request, string url, string action)
        {
            string baseUrl = "http://localhost:58947/api/";
            var response = "";
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(baseUrl+"/"+url);
                    //HTTP POST                
                    var myContent = JsonConvert.SerializeObject(request);
                    var buffer = Encoding.UTF8.GetBytes(myContent);
                    var byteContent = new ByteArrayContent(buffer);
                    byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                    var postTask = client.PostAsync(action, byteContent).Result;
                    response = await postTask.Content.ReadAsStringAsync();
                }
            }
            catch (Exception ex)
            {
                var exc = ex;
            }
            return response;
        }
    }
}

