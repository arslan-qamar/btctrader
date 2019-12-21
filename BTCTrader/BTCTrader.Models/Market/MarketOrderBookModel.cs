using Newtonsoft.Json;
using System.Collections.Generic;

namespace BTCTrader.Models.Market
{
    public class MarketOrderBookModel
    {
        [JsonProperty("marketId")]
        public string MarketId { get; set; }

        [JsonProperty("snapshotId")]
        public long SnapshotId { get; set; }

        [JsonProperty("asks")]
        public List<AskOrBid> Asks { get; set; }

        [JsonProperty("bids")]
        protected List<AskOrBid> Bids { get; set; }
       
    }
 


}
