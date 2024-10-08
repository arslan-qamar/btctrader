﻿using Newtonsoft.Json;

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

        [JsonProperty("wssBaseUrl")]
        public string WssBaseUrl { get; set; }

        [JsonProperty("wssBufferSize")]
        public int WssBufferSize { get; set; }

    }
}
