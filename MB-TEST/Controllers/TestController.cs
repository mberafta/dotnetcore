using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore;
using System.Linq;
using System.Collections;
using System.Net.Http;
using System.Net;
using System.Web;
using Newtonsoft.Json;

namespace MB_TEST.Controllers
{
    public class TestController : Controller
    {
        public TestFormModel tfm = new TestFormModel();

        [HttpGet]
        public IActionResult Test()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Test(TestFormModel model)
        {
            var isModelValid = ModelState.IsValid;

            if (isModelValid)
            {
                this.tfm.Friends = new List<string>
                {
                    "Sam",
                    "Scooby",
                    "Katrina",
                    "Skyyart",
                    "Gotaga"
                };

                return View(tfm);
            }
            else
                return View();
        }

        [HttpGet]
        public async Task<IActionResult> UseAsyncMethod()
        {
            long? length = await AsyncMethods.GetPageLength();
            var jsonPlaceholderData = await AsyncMethods.GetPosts();
            ViewBag.pageLength = $"Longueur de la page de demandée : {length}";
            return View("Test");
        }

    }

    public class TestFormModel
    {
        [Required(ErrorMessage = "Veillez entrer un nom")]
        public string Name { get; set; } = "Nom générique";

        public int Age { get; set; } = 25;

        public List<String> Friends { get; set; }

        public TestFormModel()
        {
            this.Friends = new List<String>();
        }

        public TestFormModel(string name, int age)
        {
            this.Name = name;
            this.Age = age;
            this.Friends = new List<string>();
        }
    }

    public static class ExtensionMethods
    {
        public static List<TestFormModel> Filter(this List<TestFormModel> values, Func<TestFormModel, bool> selector)
        {
            var result = new List<TestFormModel>();
            bool valid = values != null && values.Count() > 0;

            if (valid)
            {
                foreach (var val in values)
                {
                    if (selector(val))
                    {
                        result.Add(val);
                    }
                }
            }

            return result;
        }
    }

    public class AsyncMethods
    {
        public async static Task<long?> GetPageLength()
        {
            HttpClient client = new HttpClient();
            var httpMessage = await client.GetAsync("http://apress.com");
            return httpMessage.Content.Headers.ContentLength;
        }

        public async static Task<List<JsonPlaceholderResponse>> GetPosts()
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
            var deserialized = JsonConvert.DeserializeObject<List<JsonPlaceholderResponse>>(httpResponse.Result);
            return deserialized;
        }
    }

    public class JsonPlaceholderResponse
    {
        [JsonProperty("id")]
        int id { get; set; }

        [JsonProperty("userId")]
        int userId { get; set; }

        [JsonProperty("title")]
        string title { get; set; }

        [JsonProperty("body")]
        string body { get; set; }
    }


}