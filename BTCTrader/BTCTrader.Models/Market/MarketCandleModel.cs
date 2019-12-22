using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BTCTrader.Models.Market
{
    public class MarketCandleModel
    {
        [JsonProperty("timestamp")]
        public DateTimeOffset Timestamp { get; set; }

        [JsonProperty("open")]
        public Decimal Open { get; set; }

        [JsonProperty("high")]
        public Decimal High { get; set; }

        [JsonProperty("low")]
        public Decimal Low { get; set; }

        [JsonProperty("close")]
        public Decimal Close { get; set; }

        [JsonProperty("volume")]
        public Decimal Volume { get; set; }
    }
}
