using BOS.Demographics.Client.ClientModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BOS.Demographics.Client.Utilities
{
    public class OdataEnumJsonConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(RelationshipStatus);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.Value != null && reader.ValueType == typeof(string))
            {
                return (RelationshipStatus)Enum.Parse(typeof(RelationshipStatus), reader.Value.ToString());
            }
            else if (reader.TokenType == JsonToken.StartObject)
            {
                existingValue = existingValue ?? serializer.ContractResolver.ResolveContract(objectType).DefaultCreator();
                serializer.Populate(reader, existingValue);
                return existingValue;
            }
            else if (reader.TokenType == JsonToken.Null)
            {
                return null;
            }
            else
            {
                throw new JsonSerializationException();
            }
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteValue(value.ToString());
        }
    }
}
