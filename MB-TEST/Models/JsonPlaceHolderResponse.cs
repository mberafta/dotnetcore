using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MB_TEST
{
    public class JsonPlaceHolderResponse
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
