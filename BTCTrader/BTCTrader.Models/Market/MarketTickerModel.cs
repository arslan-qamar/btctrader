using Newtonsoft.Json;
using System;

namespace BTCTrader.Models.Market
{
    public class MarketTickerModel
    {
        [JsonProperty("marketId")]
        public string MarketId { get; set; }

        [JsonProperty("bestBid")]
        public string BestBid { get; set; }

        [JsonProperty("bestAsk")]
        public string BestAsk { get; set; }

        [JsonProperty("lastPrice")]
        public string LastPrice { get; set; }

        [JsonProperty("volume24h")]
        public string Volume24H { get; set; }

        [JsonProperty("price24h")]
        public string Price24H { get; set; }

        [JsonProperty("low24h")]
        public string Low24H { get; set; }

        [JsonProperty("high24h")]
        public string High24H { get; set; }

        [JsonProperty("timestamp")]
        public DateTimeOffset Timestamp { get; set; }
    }
}
