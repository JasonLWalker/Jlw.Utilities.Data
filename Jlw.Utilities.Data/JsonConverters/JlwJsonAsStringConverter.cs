using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Jlw.Utilities.Data
{
    // Classes to serialize string values to JSON after parsing the values
    public class JlwJsonAsStringConverter : JsonConverter
    {
        public override bool CanWrite => true;

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value == null)
            {
                writer.WriteValue("");
                return;
            }
            writer.WriteValue(DataUtility.ParseString(value));
            throw new NotImplementedException();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            return DataUtility.ParseAs(objectType, reader.Value);
        }

        public override bool CanConvert(Type objectType)
        {
            return true;
        }
    }


    public class JlwJsonAsStringConverter<T> : JsonConverter
    {
        public override bool CanWrite => true;

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value == null)
            {
                writer.WriteValue("");
                return;
            }
            writer.WriteValue(DataUtility.ParseAs(typeof(T), value).ToString());
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            return DataUtility.ParseAs(typeof(T), reader.Value);
        }

        public override bool CanConvert(Type objectType)
        {
            return true;
        }
    }
}
