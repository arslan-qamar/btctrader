using Newtonsoft.Json;
using System.Collections.Generic;

namespace BTCTrader.Models.Feed.Event
{
    public class HeartBeatEventModel
    {
        [JsonProperty("channels")]
        public List<Channel> Channels { get; set; }
        public class Channel
        {
            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("marketIds")]
            public List<string> MarketIds { get; set; }
        }
    }


}
