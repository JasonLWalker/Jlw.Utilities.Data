using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
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

            if (data != null && type.IsInstanceOfType(data))
                return data;

            Type underlyingType = Nullable.GetUnderlyingType(type) ?? type;

            if (type.IsPrimitive || underlyingType == typeof(string) || underlyingType == typeof(DateTime) || underlyingType == typeof(DateTimeOffset) || underlyingType == typeof(Decimal))
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
                        return ParseNullableString(data);
                }

                if (type == typeof(DateTimeOffset?))
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

            if (type == typeof(DateTimeOffset))
                return ParseDateTimeOffset(data);

            return Activator.CreateInstance(type);
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

        public static object GenerateRandom(Type t, int? minLength = null, int? maxLength = null, string validChars = null)
        {
            return GenerateRandom(t, (object)minLength, (object)maxLength, validChars);
        }

        public static T GenerateRandom<T>(int? minLength = null, int? maxLength = null, string validChars = null)
        {
            return Parse<T>(GenerateRandom(typeof(T), (object)minLength, (object)maxLength, validChars)) ?? default(T);
        }

        public static T GenerateRandom<T>(object minLength, object maxLength = null, string validChars = null, Random rand=null)
        {
            return Parse<T>(GenerateRandom(typeof(T), minLength, maxLength, validChars, rand)) ?? default(T);
        }

        public static object GenerateRandom(Type t, object minLength, object maxLength = null, string validChars = null, Random rand=null)
        {
            // Initialize Random number Generator with default if not specified.
            var rng = rand ?? Rand;

            double minDbl;
            double maxDbl;
            double dbl;

            int minInt;
            int maxInt;
            int val;

            long minLong;
            long maxLong;
            long lng;


            switch (Type.GetTypeCode(t))
            {
                case TypeCode.Boolean:
                    minInt = ParseNullableInt(minLength) ?? int.MinValue;
                    maxInt = ParseNullableInt(maxLength) ?? int.MaxValue;
                    return ParseAs(t, rng.Next(Math.Min(minInt, maxInt), Math.Max(minInt, maxInt)) > 0);
                case TypeCode.Byte:
                    minInt = ParseNullableByte(minLength) ?? byte.MinValue;
                    maxInt = ParseNullableByte(maxLength) ?? byte.MaxValue;
                    val = Math.Max(minInt, maxInt);
                    minInt = Math.Min(minInt, maxInt);
                    maxInt = val;
                    return ParseAs(t, rng.Next(minInt, maxInt));
                case TypeCode.DateTime:
                    return DateTime.Now - new TimeSpan(GenerateRandom<int>(minLength, maxLength, validChars, rand) * 3600000);
                case TypeCode.Int16:
                    minInt = ParseNullableInt16(minLength) ?? Int16.MinValue;
                    maxInt = ParseNullableInt16(maxLength) ?? Int16.MaxValue;
                    return ParseAs(t, rng.Next(Math.Min(minInt, maxInt), Math.Max(minInt, maxInt)));
                case TypeCode.Int32:
                case TypeCode.Int64:
                    minInt = ParseNullableInt(minLength) ?? int.MinValue;
                    maxInt = ParseNullableInt(maxLength) ?? int.MaxValue;
                    return ParseAs(t, rng.Next(Math.Min(minInt, maxInt), Math.Max(minInt, maxInt)));
                case TypeCode.SByte:
                    minInt = ParseNullableSByte(minLength) ?? sbyte.MinValue;
                    maxInt = ParseNullableSByte(maxLength) ?? sbyte.MaxValue;
                    val = Math.Max(minInt, maxInt);
                    minInt = Math.Min(minInt, maxInt);
                    maxInt = val;
                    return ParseAs(t, rng.Next(minInt, maxInt));
                case TypeCode.Double:
                    // Set the minimum value
                    minDbl = ParseNullableDouble(minLength) ?? Double.MinValue;
                    // Set the maximum value
                    maxDbl = ParseNullableDouble(maxLength) ?? Double.MaxValue;
                    // ensure min/max is valid
                    dbl = Math.Max(minDbl, maxDbl);
                    minDbl = Math.Min(minDbl, maxDbl);
                    maxDbl = dbl;
                    // Retrieve random number
                    if (minLength == null && maxLength == null)
                        return ParseAs(t, rng.NextDouble());
                    else
                        return ParseAs(t, rng.NextDouble() * (maxDbl - minDbl) + minDbl);
                    
                case TypeCode.Single:
                    // Set the minimum value
                    minDbl = ParseNullableDouble(minLength) ?? Single.MinValue;
                    // Set the maximum value
                    maxDbl = ParseNullableDouble(maxLength) ?? Single.MaxValue;
                    // ensure min/max is valid
                    dbl = Math.Max(minDbl, maxDbl);
                    minDbl = Math.Max(Single.MinValue, Math.Min(minDbl, maxDbl));
                    maxDbl = Math.Min(Single.MaxValue, dbl);
                    return ParseAs(t, ParseSingle(rng.NextDouble() * (maxDbl - minDbl) + minDbl));
                case TypeCode.Decimal:
                    Decimal minDec = ParseNullableDecimal(minLength) ?? Decimal.MinValue;
                    Decimal maxDec = ParseNullableDecimal(maxLength) ?? Decimal.MaxValue;
                    Decimal dec = Math.Max(minDec, maxDec);
                    minDec = Math.Min(minDec, maxDec);
                    maxDec = dec;
                    minDec = Math.Max(minDec, Decimal.MinValue);
                    dec = ParseDecimal(rng.NextDouble());
                    try
                    {
                        return ParseAs(t, dec * (maxDec - minDec) + minDec);
                    }
                    catch (Exception ex)
                    {
                        //
                    }
                    return dec;
            }

            if (t == typeof(string))
            {
                return ParseAs(t, GetRandomString(ParseNullableInt(minLength), ParseNullableInt(maxLength), validChars, rng));
            }

            if (t.IsValueType)
                return Activator.CreateInstance(t);

            return null;
        }



        protected static string GetRandomString(int? minLength = null, int? maxLength = null, string validChars = null, Random rand = null)
        {
            Random rng = rand ?? Rand;
            int min = Math.Max(minLength ?? maxLength ?? 10, 0);
            int max = Math.Min(maxLength ?? minLength ?? 10, UInt16.MaxValue);
            int swap = Math.Min(min, max);
            max = Math.Max(min, max) + 1;
            min = swap;

            int len = rng.Next(min, max);
            var s = new StringBuilder("", max);
            string chars = validChars ?? "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopsrstuvwxyz1234567890";
            while (s.Length < len)
            {
                s.Append(chars[rng.Next(0, chars.Length)]);
            }

            return s.ToString();
        }

        
    }
}
