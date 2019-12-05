using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BTCTrader.Entities
{
    public class AppSettings
    {
        [JsonProperty("baseUrl")]
        public string BaseUrl { get; set; }

        [JsonProperty("apiKey")]
        public string ApiKey { get; set; }

        [JsonProperty("privateKey")]
        public string PrivateKey { get; set; }
      
    }
}
