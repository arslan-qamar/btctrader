using Newtonsoft.Json;

namespace BTCTrader.Models.Feed.Event
{
    public class ErrorEventModel
    {
        [JsonProperty("code")]
        public string Code { get; set; }


        [JsonProperty("message")]
        public string Message { get; set; }

    }
}
