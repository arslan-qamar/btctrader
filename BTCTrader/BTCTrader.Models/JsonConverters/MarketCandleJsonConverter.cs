using BTCTrader.Models.Market;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace BTCTrader.Models.JsonConverters
{
    public class MarketCandleJsonConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(MarketCandleModel);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JArray array = JArray.Load(reader);
            
            return new MarketCandleModel
                {
                    Timestamp = new DateTimeOffset(Convert.ToDateTime(array[0])),
                    Open = Convert.ToDecimal(array[1]),
                    High = Convert.ToDecimal(array[2]),
                    Low = Convert.ToDecimal(array[3]),
                    Close = Convert.ToDecimal(array[4]),
                    Volume = Convert.ToDecimal(array[5])
                };
            
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value);
        }
    }
}
