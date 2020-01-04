using Newtonsoft.Json;

namespace BTCTrader.Models.Feed.Event
{
    public class ErrorEventModel
    {
        [JsonProperty("code")]
        string Code { get; set; }


        [JsonProperty("message")]
        string Message { get; set; }

    }
}
