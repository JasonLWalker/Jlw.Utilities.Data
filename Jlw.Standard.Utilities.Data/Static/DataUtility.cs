﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;


// ReSharper disable once CheckNamespace
namespace Jlw.Standard.Utilities.Data
{
    public partial class DataUtility
    {
/*
        public static T Parse<T>(object data)
        {
            /*
            object value = data;
            Type t = typeof(T);

            TypeCode tc = Type.GetTypeCode(t);
            try
            {
                switch (tc)
                {
                    case TypeCode.Boolean:
                        return (T) (object) ParseBool(value);
                    case TypeCode.Decimal:
                        return (T) (object) ParseDecimal(value);
                    case TypeCode.Double:
                        return (T) (object) ParseDouble(value);
                    case TypeCode.Int16:
                    case TypeCode.Int32:
                        return (T) (object) ParseInt(value);
                    case TypeCode.String:
                        return (T) (object) ParseString(value);
                    case TypeCode.DateTime:
                        return (T) (object) ParseDateTime(value);
//                    default:
//                        return (T) value;
                }

                if (typeof(IDictionary).IsAssignableFrom(t))
                {
                    return (T)(object) ParseDictionary(value);
                }

                return (T) value;

            }
            catch
            {
                return default(T);
            }
            * /
            return (T) ParseAs(typeof(T), data);
        }

        public static T Parse<T>(IDictionary<string, object> data, string key)
        {
            if (data == null || !data.ContainsKey(key))
                return default(T);

            object value;
            try
            {
                value = data[key];
            }
            catch
            {
                value = default(T);
            }
            
            return (T) ParseAs(typeof(T), value);
        }

        public static T Parse<T>(IDataRecord data, string key)
        {
            if (data == null || !Enumerable.Range(0, data.FieldCount).Any(i => string.Equals(data.GetName(i), key, StringComparison.OrdinalIgnoreCase)))
                return default(T);

            object value;
            try
            {
                value = data[key];
            }
            catch
            {
                value = default(T);
            }
            
            return (T) ParseAs(typeof(T), value);
        }

        public static object ParseAs(Type type, object data)
        {
            if (type == null)
                return null;

            if (type.IsPrimitive || type == typeof(string))
            {
                return ParsePrimitiveAs(type, data);
            }

            return Activator.CreateInstance(type);
        }

        public static object ParsePrimitiveAs(Type type, object data)
        {

            if (Nullable.GetUnderlyingType(type) != null)
            {
                // Type is nullable;
                switch (Type.GetTypeCode(type))
                {
                    case TypeCode.Boolean:
                        return ParseNullableBool(data);
                    case TypeCode.Byte:
                        return ParseNullableByte(data);
                    case TypeCode.SByte:
                        return ParseNullableSByte(data);
                    case TypeCode.Char:
                        //return ParseNullableChar(data);
                        break;
                    case TypeCode.Int16:
                        //return ParseNullableShort(data);
                        break;
                    case TypeCode.UInt16:
                        //return ParseNullableUShort(data);
                        break;
                    case TypeCode.Int32:
                        return ParseNullableInt(data);
                    case TypeCode.UInt32:
                        //return ParseNullableUInt(data);
                        break;
                    case TypeCode.Int64:
                        return ParseNullableLong(data);
                    case TypeCode.UInt64:
                        //return ParseNullableULong(data);
                        break;
                    case TypeCode.Decimal:
                        return ParseNullableDecimal(data);
                    case TypeCode.Double:
                        return ParseNullableDouble(data);
                    case TypeCode.Single:
                        //return ParseNullableFloat(data);
                        break;
                    case TypeCode.DateTime:
                        return ParseNullableDateTime(data);
                    case TypeCode.String:
                        return ParseString(data);
                }

                if (data is DateTimeOffset)
                    return ParseNullableDateTimeOffset(data);

                return null;
            }
            else
            {
                // Type is not nullable
                switch (Type.GetTypeCode(type))
                {
                    case TypeCode.Boolean:
                        return ParseBool(data);
                    case TypeCode.Byte:
                        return ParseByte(data);
                    case TypeCode.SByte:
                        return ParseSByte(data);
                    case TypeCode.Char:
                        //return ParseChar(data);
                        break;
                    case TypeCode.Int16:
                        //return ParseShort(data);
                        break;
                    case TypeCode.UInt16:
                        //return ParseUShort(data);
                        break;
                    case TypeCode.Int32:
                        return ParseInt(data);
                    case TypeCode.UInt32:
                        //return ParseUInt(data);
                        break;
                    case TypeCode.Int64:
                        return ParseLong(data);
                    case TypeCode.UInt64:
                        //return ParseULong(data);
                        break;
                    case TypeCode.Decimal:
                        return ParseDecimal(data);
                    case TypeCode.Double:
                        return ParseDouble(data);
                    case TypeCode.Single:
                        //return ParseFloat(data);
                        break;
                    case TypeCode.DateTime:
                        return ParseDateTime(data);
                    case TypeCode.String:
                        return ParseString(data);
                }
            }

            if (data is DateTimeOffset)
                return ParseDateTimeOffset(data);

            return Activator.CreateInstance(type);
        }


*/
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static object GetObjectValue(object obj, string key=null)
        {
            object o = obj;
            try
            {
                if (!string.IsNullOrWhiteSpace(key))
                {
                    if (obj is IEnumerable<KeyValuePair<string, object>> enumerable)
                        o = enumerable.FirstOrDefault(kvp => kvp.Key == key).Value;
                    else if (obj is IDataRecord record)
                        o = record?[key];
                }
            }
            catch
            {
                // Ignore
                o = null;
            }

            return o;
        }


        protected static bool IsNullOrWhitespace(object data)
        {
            return (string.IsNullOrWhiteSpace(data?.ToString()) || data is DBNull || data == DBNull.Value);
        }

        public static bool IsNumeric(object obj)
        {
            if (obj == null)
                return false;
            if (!obj.GetType().GetTypeInfo().IsPrimitive && !(obj is double) && (!(obj is Decimal) && !(obj is DateTime)))
                return obj is TimeSpan;
            return true;
        }

    }
}
