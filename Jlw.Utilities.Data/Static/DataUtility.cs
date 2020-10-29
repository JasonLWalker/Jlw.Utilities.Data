using System;
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
namespace Jlw.Utilities.Data
{
    public partial class DataUtility
    {
        private static readonly Random Rand = new Random();

        public static T Parse<T>(object obj, string key = null)
        {
            var data = GetObjectValue(obj, key);

            return (T) ParseAs(typeof(T), data);
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
                        return ParseNullableShort(data);
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
                        return ParseNullableFloat(data);
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
                        return ParseShort(data);
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
                        return ParseFloat(data);
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



        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static object GetObjectValue(object obj, string key=null)
        {
            object o = obj;
            try
            {
                if (!string.IsNullOrWhiteSpace(key))
                {
                    switch (obj)
                    {
                        case IEnumerable<KeyValuePair<string, object>> enumerable:
                            return enumerable.FirstOrDefault(kvp => kvp.Key == key).Value;
                        case IDictionary dict:
                            return dict.Contains(key) ? dict[key] : null;
                        case IDataRecord record:
                            return (Enumerable.Range(0, record.FieldCount).Any(x => record.GetName(x) == "columnName")) ? record[key] : DBNull.Value;
                    }

                    var t = obj?.GetType();
                    var fieldInfo = t?.GetFields().FirstOrDefault(x => x.Name == key);
                    if (fieldInfo != null)
                        return fieldInfo.GetValue(obj);

                    var propInfo = t?.GetProperties().FirstOrDefault(x => x.Name == key && x.CanRead);
                    if (propInfo != null)
                        return propInfo.GetValue(obj);
                }
            }
            catch
            {
                // Ignore
                o = null;
            }

            return o;
        }

        public static string GetCaller([CallerMemberName] string caller = null)
        {
            return caller;
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

        public static T GenerateRandom<T>(int? minLength = null, int? maxLength = null, string validChars = null)
        {
            T val = default;
            var t = typeof(T);

            switch (val)
            {
                case int n:
                case long l:
                    return Parse<T>(Rand.Next(Math.Min(minLength ?? int.MinValue, maxLength ?? minLength ?? int.MaxValue), Math.Max(minLength ?? int.MinValue, maxLength ?? minLength ?? int.MaxValue)));
                case bool b:
                    return Parse<T>( Rand.Next(0, 1));
                case double d:
                case float f:
                case decimal dc:
                    return Parse<T>( (Rand.NextDouble() * Math.Max(minLength ?? int.MinValue, maxLength ?? minLength ?? int.MaxValue)) + Math.Min(minLength ?? int.MinValue, maxLength ?? minLength ?? int.MaxValue));
            }

            if (t == typeof(string))
                return Parse<T>(GetRandomString(minLength ?? 10, maxLength, validChars));

            return val;
        }

        protected static string GetRandomString(int minLength = 10, int? maxLength = null, string validChars = null)
        {
            int min = Math.Min(minLength, maxLength ?? minLength);
            int max = Math.Max(minLength, maxLength ?? minLength);
            int len = Rand.Next(min, max);
            var s = new StringBuilder("", max);
            string chars = validChars ?? "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopsrstuvwxyz1234567890";
            while (s.Length < len)
            {
                s.Append(chars[Rand.Next(0, chars.Length)]);
            }

            return s.ToString();
        }

    }
}
