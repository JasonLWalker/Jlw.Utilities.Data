﻿
// ReSharper disable once CheckNamespace

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Jlw.Utilities.Data
{
    public partial class DataUtility
    {
        /// <summary>
        /// Parses a double value from an input object of any type.
        /// </summary>
        /// <param name="obj">The object containing the data to parse.</param>
        /// <param name="key">The key of the data to parse.</param>
        /// <returns>Returns the value, or <c>0.0D</c> if the data cannot be parsed.</returns>
        public static double ParseDouble(object obj, string key = null) => ParseNullableDouble(obj, key) ?? default;


        /// <summary>
        /// Parses a double value from an input object of any type.
        /// </summary>
        /// <param name="obj">The object containing the data to parse.</param>
        /// <param name="key">The key of the data to parse.</param>
        /// <returns>Returns the value, or <c>null</c> if the data cannot be parsed.</returns>
        public static double? ParseNullableDouble(object obj, string key=null)
        {
            var data = GetObjectValue(obj, key);

            if(data == null || data is DBNull || data == DBNull.Value || data is DateTimeOffset || data is DateTime)
                return null;

            string s = ExtractNumericString(data?.ToString());
            try
            {
                if (data is double.NaN || data is float.NaN)
                    return double.NaN;

                TypeCode tc = Type.GetTypeCode(data.GetType());

                switch (tc)
                {
                    case TypeCode.Double:
                        return (double)(data);
                    case TypeCode.Single:
                        return (double)((float) data);
                    case TypeCode.Char:
                        char asc = (data.ToString()[0]);
                        return (double)asc;
                }

                var d = double.Parse(s);
                return (double) d;
            }
            catch (OverflowException)
            {
                if (IsNumeric(data))
                {
                    var dc = (double) Convert.ChangeType(data, typeof(double));
                    
                    if (dc < 0)
                    {
                        return double.MinValue;
                    }

                    return double.MaxValue;
                }

                try
                {
                    double d = double.Parse(s.Trim());
                    if (d < 0)
                        return double.MinValue;

                    return double.MaxValue;
                }
                catch(OverflowException)
                {
                    double.TryParse(s.Trim(), out var d);

                    if (d < 0)
                        return double.MinValue;

                    return double.MaxValue;
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
                    case TypeCode.Char:
                        d = (double)Convert.ChangeType(data, typeof(double));
                        return d;
                    case TypeCode.Single:
                    case TypeCode.Double:
                    case TypeCode.Decimal:
                        d = (double)Convert.ChangeType(data, typeof(double));
                        if (double.IsNaN(d))
                            return null;

                        return (Double)d;
                    case TypeCode.String:
                        if (IsNullOrWhitespace(s))
                            return null;

                        var l = s.Length;
                        char? c0 = (l >= 1) ? (char?)s[0] : null;
                        char? c1 = (l >= 2) ? (char?)s[1] : null;

                        if (c0 >= '0' && c0 <= '9')
                        {
                            double.TryParse(s, out d);
                            return ParseNullableDouble(d);
                        }

                        if (c0 == '.' && c1 >= '0' && c1 <= '9')
                        {
                            double.TryParse(s, out d);
                            return ParseNullableDouble(d);
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
                                return ParseNullableDouble(d);
                            }
                        }

                        break;
                }
            }

            return null;
        }



    }
}
