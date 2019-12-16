using Newtonsoft.Json;
using System;

namespace BTCTrader.Models.Trade
{
    public class TradeModel
    {
       
        [JsonProperty("id")]        
        public long Id { get; set; }

        [JsonProperty("marketId")]
        public string MarketId { get; set; }

        [JsonProperty("timestamp")]
        public DateTimeOffset Timestamp { get; set; }

        [JsonProperty("price")]
        public string Price { get; set; }

        [JsonProperty("amount")]
        public string Amount { get; set; }

        [JsonProperty("side")]
        public string Side { get; set; }

        [JsonProperty("fee")]
        public string Fee { get; set; }

        [JsonProperty("orderId")]
        public long OrderId { get; set; }

        [JsonProperty("liquidityType",NullValueHandling = NullValueHandling.Ignore)]
        public string LiquidityType { get; set; }

        [JsonProperty("clientOrderId", NullValueHandling = NullValueHandling.Ignore)]
        public long ClientOrderId { get; set; }

    }
}
