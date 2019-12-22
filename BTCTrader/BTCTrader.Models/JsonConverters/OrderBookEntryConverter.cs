using BTCTrader.Models.Market;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;


namespace BTCTrader.Models.JsonConverters
{
    public class OrderBookEntryConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(OrderBookEntry);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JArray array = JArray.Load(reader);
            return new OrderBookEntry
            {
                Price = Convert.ToDecimal(array[0]),
                Volume = Convert.ToDecimal(array[1])
            };
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value);
        }
    }
}
