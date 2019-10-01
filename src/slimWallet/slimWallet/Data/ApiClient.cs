using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace slimWallet.Data
{
    public class ApiClient
    {
        public async Task<T> Command<T>(HttpMethod method, string id = null,
            object data = null, string url = null, Stream stream = null, string filename = null)
        {
            using (var message = new HttpRequestMessage(method, url + id))
            {
                if (stream != null)
                {
                    var form = new MultipartFormDataContent
                    {
                        { new StreamContent(stream), "document", filename }
                    };

                    message.Content = form;
                }
                else
                {
                    if (data != null)
                        message.Content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
                }


                using (var client = new HttpClient())
                {
                    var response = await client.SendAsync(message).ConfigureAwait(false);
                    response.EnsureSuccessStatusCode();

                    var value = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<T>(value);
                }
            }
        }
    }
}
