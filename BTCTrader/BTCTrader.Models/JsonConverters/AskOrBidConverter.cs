using BTCTrader.Models.Market;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;


namespace BTCTrader.Models.JsonConverters
{
    public class AskOrBidConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(AskOrBid));
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JArray array = JArray.Load(reader);
            return new AskOrBid
            {
                Price = Convert.ToDecimal(array[0]),
                Volume = Convert.ToDecimal(array[1])
            };
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            AskOrBid ask = (AskOrBid)value;
            JArray array = new JArray();
            array.Add(ask.Price);
            array.Add(ask.Volume);
            serializer.Serialize(writer, array);
        }
    }
}
