using Newtonsoft.Json;
using System.Collections.Generic;

namespace BTCTrader.Models.Account
{
    public partial class TradingFeesModel
    {
        [JsonProperty("volume30Day")]        
        public long Volume30Day { get; set; }

        [JsonProperty("feeByMarkets")]
        public List<MarketFee> FeeByMarkets { get; set; }
    }

    public partial class MarketFee
    {
        [JsonProperty("makerFeeRate")]
        public string MakerFeeRate { get; set; }

        [JsonProperty("takerFeeRate")]
        public string TakerFeeRate { get; set; }

        [JsonProperty("marketId")]
        public string MarketId { get; set; }
    }

}
