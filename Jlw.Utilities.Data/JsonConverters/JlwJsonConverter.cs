﻿using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Jlw.Utilities.Data
{
    public class JlwJsonConverter : JsonConverter
    {
        public override bool CanWrite { get { return false; } }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
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


    public class JlwJsonConverter<T> : JsonConverter
    {
        public override bool CanWrite { get { return false; } }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
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
