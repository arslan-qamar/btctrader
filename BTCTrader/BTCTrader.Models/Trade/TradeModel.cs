using Newtonsoft.Json;
using System;

namespace BTCTrader.Models.Trade
{
    public class TradeModel
    {

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("marketId")]
        public string MarketId { get; set; }

        [JsonProperty("timestamp")]
        public DateTimeOffset Timestamp { get; set; }

        [JsonProperty("price")]
        public decimal Price { get; set; }

        [JsonProperty("amount")]
        public decimal Amount { get; set; }

        [JsonProperty("side")]
        public string Side { get; set; }

        [JsonProperty("fee")]
        public decimal Fee { get; set; }

        [JsonProperty("orderId")]
        public string OrderId { get; set; }

        [JsonProperty("liquidityType")]
        public string LiquidityType { get; set; }

        [JsonProperty("clientOrderId")]
        public long ClientOrderId { get; set; }

    }
}
