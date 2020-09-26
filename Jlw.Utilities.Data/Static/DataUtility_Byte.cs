
// ReSharper disable once CheckNamespace

using System;

namespace Jlw.Utilities.Data
{
    public partial class DataUtility
    {
        public static byte ParseByte(object data, string key = null) => ParseNullableByte(data, key) ?? default;


        public static byte? ParseNullableByte(object obj, string key=null)
        {
            var data = GetObjectValue(obj, key);

            if(data == null || data is DBNull || data == DBNull.Value || data is DateTime || data is DateTimeOffset)
                return null;

            string s = ExtractNumericString(data?.ToString());
            try
            {
                if (data is char)
                {
                    var asc = (int)(data.ToString()[0]);
                    if (asc > byte.MaxValue)
                        return byte.MaxValue;
                    /*
                    if (asc < byte.MinValue)
                        return byte.MinValue;
                    */
                    return (byte) asc;
                }

                var d = byte.Parse(s);
                return (byte) d;
            }
            catch (OverflowException)
            {
                if (IsNumeric(data))
                {
                    var dc = (decimal) Convert.ChangeType(data, typeof(decimal));
                    
                    if (dc < 0)
                    {
                        return byte.MinValue;
                    }

                    return byte.MaxValue;
                }

                try
                {
                    long l = long.Parse(s.Trim());
                    if (l < 0)
                        return byte.MinValue;

                    return byte.MaxValue;
                }
                catch(OverflowException)
                {
                    double.TryParse(s.Trim(), out var d);

                    if (d < 0)
                        return byte.MinValue;

                    return byte.MaxValue;
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

                        if (d > byte.MaxValue)
                            return byte.MaxValue;

                        if (d < byte.MinValue)
                            return byte.MinValue;
                        return (byte)d;
                    */
                    case TypeCode.Single:
                    case TypeCode.Double:
                    case TypeCode.Decimal:
                        d = (double)Convert.ChangeType(data, typeof(double));
                        if (double.IsNaN(d))
                            return null;

                        if (d > byte.MaxValue)
                            return byte.MaxValue;

                        if (d < byte.MinValue)
                            return byte.MinValue;
                        return (byte)d;
                    case TypeCode.String:
                        if (IsNullOrWhitespace(s))
                            return null;

                        var l = s.Length;
                        char? c0 = (l >= 1) ? (char?)s[0] : null;
                        char? c1 = (l >= 2) ? (char?)s[1] : null;

                        if (c0 >= '0' && c0 <= '9')
                        {
                            double.TryParse(s, out d);
                            return ParseNullableByte(d);
                        }

                        if (c0 == '.' && c1 >= '0' && c1 <= '9')
                        {
                            double.TryParse(s, out d);
                            return ParseNullableByte(d);
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
                                return ParseNullableByte(d);
                            }
                        }

                        break;
                }
                    
            }

            return null;

        }

    }
}
