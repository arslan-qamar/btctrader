using Newtonsoft.Json;
using System;
namespace BTCTrader.Models.Feed.Event
{
    public partial class TradeEventModel
    {
        [JsonProperty("marketId")]
        public string MarketId { get; set; }

        [JsonProperty("timestamp")]
        public DateTimeOffset Timestamp { get; set; }

        [JsonProperty("tradeId")]
        public long TradeId { get; set; }

        [JsonProperty("price")]
        public decimal Price { get; set; }

        [JsonProperty("volume")]
        public decimal Volume { get; set; }
  
        [JsonProperty("side")]
        public string Side { get; set; }
    }
}
