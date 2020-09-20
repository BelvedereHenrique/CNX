using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CNX.Utils
{
    public static class HttpUtil
    {
        public static HttpClient Client { get; }

        static HttpUtil()
        {
            Client = new HttpClient();
        }

        public static async Task<T> PostAsync<T>(string url, object data)
        {
            var content = new StringContent(
                JsonConvert.SerializeObject(data),
                Encoding.UTF8,
                "application/json");

            var result = await Client.PostAsync(url, content);

            ValidateHttpResult(result);

            return JsonConvert.DeserializeObject<T>(result.Content.ToString());
        }

        public static async Task<T> GetAsync<T>(string url)
        {
            var result = await Client.GetAsync(url);
            ValidateHttpResult(result);

            return JsonConvert.DeserializeObject<T>(result.Content.ToString());
        }

        public static T Get<T>(string url)
        {
            return GetAsync<T>(url).Result;
        }

        public static T Post<T>(string url, object data)
        {
            return PostAsync<T>(url, data).Result;
        }

        private static void ValidateHttpResult(HttpResponseMessage httpResponseMessage)
        {
            if (httpResponseMessage.StatusCode != HttpStatusCode.OK)
                throw new HttpRequestException();
        }

    }
}
