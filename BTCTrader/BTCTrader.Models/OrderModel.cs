using Newtonsoft.Json;

namespace BTCTrader.Models
{
    public class OrderModel
    {
        [JsonProperty("orderId")]
        public string OrderId { get; set; }

        [JsonProperty("marketId")]
        public string MarketId { get; set; }

        [JsonProperty("price")]
        public string Price { get; set; }

        [JsonProperty("amount")]
        public string Amount { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("side")]
        public string Side { get; set; }

        [JsonProperty("triggerPrice")]
        public string TriggerPrice { get; set; }

        [JsonProperty("targetAmount")]
        public string TargetAmount { get; set; }

        [JsonProperty("timeInForce")]
        public string TimeInForce { get; set; }

        [JsonProperty("postOnly")]
        public string PostOnly { get; set; }

        [JsonProperty("selfTrade")]
        public string SelfTrade { get; set; }

        [JsonProperty("clientOrderId")]
        public string ClientOrderId { get; set; }

        [JsonProperty("creationTime")]
        public string CreationTime { get; set; }

        [JsonProperty("openAmount")]
        public string OpenAmount { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

    }
}
