using Newtonsoft.Json;

namespace BTCTrader.Models.Feed.Event
{
    public class BaseFeedEventModel
    {
        [JsonProperty("messageType")]
        public string EventType { get; set; }

    }
}
