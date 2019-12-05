using Newtonsoft.Json;
namespace BTCTrader.Models
{
    public class AssetModel
    {

        [JsonProperty("assetName")]
        public string AssetName { get; set; }

        [JsonProperty("balance")]
        public string Balance { get; set; }

        [JsonProperty("available")]
        public string Available { get; set; }

        [JsonProperty("locked")]
        public string Locked { get; set; }
    }

}
