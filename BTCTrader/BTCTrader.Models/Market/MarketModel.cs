using Newtonsoft.Json;

namespace BTCTrader.Models.Market
{
    public class MarketModel
    {
        [JsonProperty("marketId")]
        public string MarketId { get; set; }

        [JsonProperty("baseAssetName")]
        public string BaseAssetName { get; set; }

        [JsonProperty("quoteAssetName")]
        public string QuoteAssetName { get; set; }

        [JsonProperty("minOrderAmount")]
        public string MinOrderAmount { get; set; }

        [JsonProperty("maxOrderAmount")]
        public long MaxOrderAmount { get; set; }

        [JsonProperty("amountDecimals")]
        public long AmountDecimals { get; set; }

        [JsonProperty("priceDecimals")]        
        public long PriceDecimals { get; set; }
    }
}
