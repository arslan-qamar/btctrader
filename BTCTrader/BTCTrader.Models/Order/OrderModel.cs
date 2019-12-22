using Newtonsoft.Json;
using System;

namespace BTCTrader.Models.Order
{
    public class OrderModel
    {
        [JsonProperty("orderId")]
        public string OrderId { get; set; }

        [JsonProperty("marketId")]
        public string MarketId { get; set; }

        [JsonProperty("price")]
        public decimal Price { get; set; }

        [JsonProperty("amount")]
        public decimal Amount { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("side")]
        public string Side { get; set; }

        [JsonProperty("triggerPrice")]
        public decimal? TriggerPrice { get; set; }

        [JsonProperty("targetAmount")]
        public decimal? TargetAmount { get; set; }

        [JsonProperty("timeInForce")]
        public string TimeInForce { get; set; }

        [JsonProperty("postOnly")]
        public string PostOnly { get; set; }

        [JsonProperty("selfTrade")]
        public string SelfTrade { get; set; }

        [JsonProperty("clientOrderId")]
        public string ClientOrderId { get; set; }

        [JsonProperty("creationTime")]
        public DateTimeOffset CreationTime { get; set; }

        [JsonProperty("openAmount")]
        public decimal? OpenAmount { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

    }
}
