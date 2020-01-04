using BTCTrader.Models.Market;
using Newtonsoft.Json;
using System;

namespace BTCTrader.Models.Feed.Event
{
    public class OrderBookEventModel : MarketOrderBookModel
    {

        [JsonProperty("timestamp")]
        public DateTimeOffset Timestamp { get; set; }
    }
}
