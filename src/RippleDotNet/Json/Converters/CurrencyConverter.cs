﻿using System;
using Newtonsoft.Json;
using RippleDotNet.Model;

namespace RippleDotNet.Json.Converters
{
    public class CurrencyConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value is string)
                writer.WriteValue(value);
            else
            {
                
            }            
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue,
            JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return null;

            if (reader.TokenType == JsonToken.String)
            {
                return reader.Value;
            }

            if (reader.TokenType == JsonToken.StartObject)
            {
                return serializer.Deserialize<Currency>(reader);
            }

            throw new Exception("Cannot convert value");
        }

        public override bool CanConvert(Type objectType)
        {
            if (objectType == typeof(string) || objectType == typeof(Currency))
                return true;
            return false;
        }
    }
}
