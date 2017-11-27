using System;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace RippleDotNet.Json.Converters
{
    public class RippleDateTimeConverter : DateTimeConverterBase
    {
        private static readonly DateTime RippleStartTime = new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value is DateTime)
            {
                long totalSeconds = (long)((DateTime)value - RippleStartTime).TotalSeconds;
                writer.WriteValue(totalSeconds);
            }
            else
            {
                throw new ArgumentException("value");
            }
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return null;

            if (reader.TokenType == JsonToken.String || reader.TokenType == JsonToken.Integer)
            {
                double totalSeconds;

                try
                {
                    totalSeconds = Convert.ToDouble(reader.Value, CultureInfo.InvariantCulture);
                }
                catch
                {
                    throw new Exception("Invalid double value.");
                }

                return RippleStartTime.AddSeconds(totalSeconds);
            }

            throw new Exception("Invalid token. Expected string");            
        }
    }
}
