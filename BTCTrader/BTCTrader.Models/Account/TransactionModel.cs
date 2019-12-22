using Newtonsoft.Json;
using System;

namespace BTCTrader.Models.Account
{
    public class TransactionModel
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("creationTime")]
        public DateTimeOffset CreationTime { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("assetName")]
        public string AssetName { get; set; }

        [JsonProperty("amount")]
        public decimal Amount { get; set; }

        [JsonProperty("balance")]
        public decimal Balance { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("recordType")]
        public string RecordType { get; set; }

        [JsonProperty("referenceId")]        
        public string ReferenceId { get; set; }
    }

}
