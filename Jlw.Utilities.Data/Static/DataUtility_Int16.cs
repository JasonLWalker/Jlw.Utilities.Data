using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;

// ReSharper disable once CheckNamespace
namespace Jlw.Utilities.Data
{
    public partial class DataUtility
    {
        public static short ParseShort(object o, string key = null) => ParseNullableInt16(o, key) ?? default;
        public static short? ParseNullableShort(object o, string key = null) => ParseNullableInt16(o, key);

        /// <summary>
        /// Parses a 16-bit integer value from an input object of any type.
        /// </summary>
        /// <param name="obj">The object containing the data to parse.</param>
        /// <param name="key">The key to parse.</param>
        /// <returns>Returns the value, or <c>0</c> if the data cannot be parsed.</returns>
        public static Int16 ParseInt16(object obj, string key = null) => ParseNullableInt16(obj, key) ?? default;

        /// <summary>
        /// Parses a 16-bit integer value from an input object of any type.
        /// </summary>
        /// <param name="obj">The object containing the data to parse.</param>
        /// <param name="key">The key to parse.</param>
        /// <returns>Returns an int containing the value, or <c>null</c> if the data cannot be parsed.</returns>
        public static Int16? ParseNullableInt16(object obj, string key=null)
        {
            var data = GetObjectValue(obj, key);

            if(data == null || data is DBNull || data == DBNull.Value || data is DateTimeOffset || data is DateTime)
                return null;

            string s = ExtractNumericString(data?.ToString());
            try
            {
                if (data is char)
                {
                    Int16 asc = (Int16)(data.ToString()[0]);
                    return asc;
                }

                var d = Int16.Parse(s);
                return (Int16) d;
            }
            catch (OverflowException)
            {
                if (IsNumeric(data))
                {
                    var dc = (decimal) Convert.ChangeType(data, typeof(decimal));
                    
                    if (dc < 0)
                    {
                        return Int16.MinValue;
                    }

                    return Int16.MaxValue;
                }

                try
                {
                    long l = long.Parse(s.Trim());
                    if (l < 0)
                        return Int16.MinValue;

                    return Int16.MaxValue;
                }
                catch(OverflowException)
                {
                    double.TryParse(s.Trim(), out var d);

                    if (d < 0)
                        return Int16.MinValue;

                    return Int16.MaxValue;
                }
            }
            catch (System.FormatException)
            {
                double d;
                switch (data)
                {
                    case bool b when b:
                        return 1;
                    case bool _:
                        return 0;
                    /*
                    case char _:
                    {
                        d = (ulong) Convert.ChangeType(data, typeof(ulong));

                        if (d > Int16.MaxValue)
                            return Int16.MaxValue;

                        if (d < Int16.MinValue)
                            return Int16.MinValue;
                        return (Int16) d;
                    }
                    */
                    case float _:
                    case double _:
                    case decimal _:
                    {
                        d = (double) Convert.ChangeType(data, typeof(double));
                        if (double.IsNaN(d))
                            return null;

                        if (d > short.MaxValue)
                            return Int16.MaxValue;

                        if (d < Int16.MinValue)
                            return Int16.MinValue;
                        return (Int16) d;
                    }
                    case string _ when IsNullOrWhitespace(s):
                        return null;
                    case string _:
                    {
                        var l = s.Length;
                        var c0 = (l >= 1) ? (char?) s[0] : null;
                        var c1 = (l >= 2) ? (char?) s[1] : null;

                        if (c0 >= '0' && c0 <= '9')
                        {
                            double.TryParse(s, out d);
                            return ParseNullableInt16(d);
                        }

                        if (c0 == '.' && c1 >= '0' && c1 <= '9')
                        {
                            double.TryParse(s, out d);
                            return ParseNullableInt16(d);
                        }

                        if (c0 == '-')
                        {
                            char? c2 = (l >= 3) ? (char?) s[2] : null;
                            if (
                                (c1 >= '0' && c1 <= '9') ||
                                (c1 == '.' && c2 >= '0' && c2 <= '9')
                            )
                            {
                                double.TryParse(s, out d);
                                return ParseNullableInt16(d);
                            }
                        }

                        break;
                    }
                }
            }

            return null;
        }

    }
}
