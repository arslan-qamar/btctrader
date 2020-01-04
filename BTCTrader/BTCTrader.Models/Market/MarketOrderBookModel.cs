using Newtonsoft.Json;
using System.Collections.Generic;

namespace BTCTrader.Models.Market
{
    public class MarketOrderBookModel
    {
        [JsonProperty("marketId")]
        public string MarketId { get; set; }

        [JsonProperty("snapshotId")]
        public string SnapshotId { get; set; }

        [JsonProperty("asks")]
        public List<OrderBookEntry> Asks { get; set; }

        [JsonProperty("bids")]
        public List<OrderBookEntry> Bids { get; set; }

    }



}
