using Newtonsoft.Json;
using System;

namespace BTCTrader.Models.Market
{
    public class MarketTickerModel
    {
        [JsonProperty("marketId")]
        public string MarketId { get; set; }

        [JsonProperty("bestBid")]
        public decimal BestBid { get; set; }

        [JsonProperty("bestAsk")]
        public decimal BestAsk { get; set; }

        [JsonProperty("lastPrice")]
        public decimal LastPrice { get; set; }

        [JsonProperty("volume24h")]
        public decimal Volume24H { get; set; }

        [JsonProperty("price24h")]
        public decimal Price24H { get; set; }

        [JsonProperty("low24h")]
        public decimal Low24H { get; set; }

        [JsonProperty("high24h")]
        public decimal High24H { get; set; }

        [JsonProperty("timestamp")]
        public DateTimeOffset Timestamp { get; set; }
    }
}
