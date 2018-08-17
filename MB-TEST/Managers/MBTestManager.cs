using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace MB_TEST
{
    public class MBTestManager
    {
        /// <summary>
        /// Appel HTTP avec demande de la longueur de la requête
        /// </summary>
        /// <returns></returns>
        public async Task<long?> GetPageLength()
        {
            HttpClient client = new HttpClient();
            var httpMessage = await client.GetAsync("http://apress.com");
            return httpMessage.Content.Headers.ContentLength;
        }

        /// <summary>
        /// Appel HTTP avec récupération et parsing de la réponse
        /// </summary>
        /// <returns></returns>
        public async Task<List<JsonPlaceHolderResponse>> GetPosts()
        {

            var proxyHost = "http://surf-sccc.pasi.log.intra.laposte.fr";
            var proxyPort = "8080";

            var proxy = new WebProxy()
            {
                Address = new Uri($"{proxyHost}:{proxyPort}"),
                BypassProxyOnLocal = false,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(userName: "XUFJ641", password: "Nilmar69!")
            };

            HttpClientHandler handler = new HttpClientHandler() { Proxy = proxy };

            const string url = "https://jsonplaceholder.typicode.com/posts";
            HttpClient client = new HttpClient(handler);


            var httpMessage = await client.GetAsync(url);
            var httpResponse = httpMessage.Content.ReadAsStringAsync();
            var deserialized = JsonConvert.DeserializeObject<List<JsonPlaceHolderResponse>>(httpResponse.Result);
            return deserialized;
        }
    }
}
