﻿using BTCTrader.Models.Order;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace BTCTrader.Models.Feed.Event
{
    public class OrderChangeEventModel : OrderModel
    {

        [JsonProperty("openVolume")]
        public decimal OpenVolume { get; set; }

        [JsonProperty("triggerStatus")]
        public string TriggerStatus { get; set; }

        [JsonProperty("trades")]
        public List<object> Trades { get; set; }

        [JsonProperty("timestamp")]
        public DateTimeOffset Timestamp { get; set; }

    }
}
