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
                Price = (decimal)Convert.ToDouble(array[0], System.Globalization.CultureInfo.InvariantCulture),
                Volume = (decimal)Convert.ToDouble(array[1], System.Globalization.CultureInfo.InvariantCulture)
            };

        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value);
        }
    }
}
