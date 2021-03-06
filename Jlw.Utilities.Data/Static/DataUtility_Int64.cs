﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;

// ReSharper disable once CheckNamespace
namespace Jlw.Utilities.Data
{
    public partial class DataUtility
    {
        public static Int64 ParseInt64(object o, string key = null) => ParseNullableLong(o, key) ?? default;
        public static Int64? ParseNullableInt64(object o, string key = null) => ParseNullableLong(o, key);

        /// <summary>
        /// Parses a 64-bit integer value from an input object of any type.
        /// </summary>
        /// <param name="obj">The object containing the data to parse.</param>
        /// <param name="key">The key to parse.</param>
        /// <returns>Returns the value, or <c>0</c> if the data cannot be parsed.</returns>
        public static long ParseLong(object obj, string key = null) => ParseNullableLong(obj, key) ?? default;

        /// <summary>
        /// Parses a 64-bit integer value from an input object of any type.
        /// </summary>
        /// <param name="obj">The object containing the data to parse.</param>
        /// <param name="key">The key to parse.</param>
        /// <returns>Returns an int containing the value, or <c>null</c> if the data cannot be parsed.</returns>
        public static long? ParseNullableLong(object obj, string key=null)
        {
            var data = GetObjectValue(obj, key);

            if(data == null || data is DBNull || data == DBNull.Value || data is DateTimeOffset)
                return null;

            if (!(data is char) && string.IsNullOrWhiteSpace(data.ToString()))
                return null;

            string s = ExtractNumericString(data?.ToString());
            try
            {
                switch (Type.GetTypeCode(data.GetType()))
                {
                    case TypeCode.Char:
                        long asc = (long)(data.ToString()[0]);
                        return asc;
                    case TypeCode.DateTime:
                        return ((DateTime) data).ToBinary();
                }

                var d = long.Parse(s.Trim());
                return (long) d;
            }
            catch (OverflowException)
            {
                if (IsNumeric(data))
                {
                    var dc = (decimal) Convert.ChangeType(data, typeof(decimal));
                    
                    if (dc < 0)
                    {
                        return long.MinValue;
                    }

                    return long.MaxValue;
                }

                /*
                try
                {
                    long l = long.Parse(s.Trim());
                    
                    if (l < 0)
                        return long.MinValue;

                    return long.MaxValue;
                    
                }
                catch(OverflowException)
                */
                {
                    double.TryParse(s.Trim(), out var d);

                    if (d < 0)
                        return long.MinValue;

                    return long.MaxValue;
                }
            }
            catch (System.FormatException)
            {
                TypeCode tc = Type.GetTypeCode(data.GetType());
                double d;
                switch (tc)
                {
                    case TypeCode.Boolean:
                        if((bool)data)
                            return 1;
                        return 0;
                    /*
                    case TypeCode.Char:
                        d = (ulong)Convert.ChangeType(data, typeof(ulong));

                        if (d > long.MaxValue)
                            return long.MaxValue;

                        if (d < long.MinValue)
                            return long.MinValue;
                        return (long)d;
                    */
                    case TypeCode.Single:
                    case TypeCode.Double:
                    case TypeCode.Decimal:
                        d = (double)Convert.ChangeType(data, typeof(double));
                        if (double.IsNaN(d))
                            return null;

                        if (d > long.MaxValue)
                            return long.MaxValue;

                        if (d < long.MinValue)
                            return long.MinValue;
                        return (long)d;
                    case TypeCode.String:
                        if (IsNullOrWhitespace(s))
                            return null;

                        var l = s.Length;
                        char? c0 = (l >= 1) ? (char?)s[0] : null;
                        char? c1 = (l >= 2) ? (char?)s[1] : null;

                        if (c0 >= '0' && c0 <= '9')
                        {
                            double.TryParse(s, out d);
                            return ParseNullableLong(d);
                        }

                        if (c0 == '.' && c1 >= '0' && c1 <= '9')
                        {
                            double.TryParse(s, out d);
                            return ParseNullableLong(d);
                        }

                        if (c0 == '-')
                        {
                            char? c2 = (l >= 3) ? (char?)s[2] : null;
                            if (
                                (c1 >= '0' && c1 <= '9') ||
                                (c1 == '.' && c2 >= '0' && c2 <= '9') 
                                )
                            {
                                double.TryParse(s, out d);
                                return ParseNullableLong(d);
                            }
                        }

                        break;
                }
            }

            return null;
        }

    }
}
