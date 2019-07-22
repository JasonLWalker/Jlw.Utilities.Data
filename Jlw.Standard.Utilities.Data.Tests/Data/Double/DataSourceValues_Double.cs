using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Jlw.Standard.Utilities.Data.DbUtility;

namespace Jlw.Standard.Utilities.Data.Tests
{
    public partial class DataSourceValues
    {
        
        protected static void InitDouble()
        {
            NullableDoubleData.Add(new TestDataItem((decimal)1, (System.Double)1));
            NullableDoubleData.Add(new TestDataItem((decimal)0, (System.Double)0));
            NullableDoubleData.Add(new TestDataItem((decimal)8, (System.Double)8));
            NullableDoubleData.Add(new TestDataItem((decimal)9, (System.Double)9));
            NullableDoubleData.Add(new TestDataItem(decimal.One, (System.Double)1, "(Decimal).One"));
            NullableDoubleData.Add(new TestDataItem(decimal.Zero, (System.Double)0, "(Decimal).Zero"));
            NullableDoubleData.Add(new TestDataItem(decimal.MinusOne, -1.0D, "(Decimal).MinusOne"));
            NullableDoubleData.Add(new TestDataItem(decimal.MinValue, (System.Double)Decimal.MinValue, "(Decimal).MinValue"));
            NullableDoubleData.Add(new TestDataItem(decimal.MaxValue, (System.Double)Decimal.MaxValue, "(Decimal).MaxValue"));
            NullableDoubleData.Add(new TestDataItem((decimal)123, (System.Double)123));
            NullableDoubleData.Add(new TestDataItem((decimal)1234567890, (System.Double)1234567890));
            NullableDoubleData.Add(new TestDataItem((decimal)123.4567890, (System.Double)123.4567890));
            NullableDoubleData.Add(new TestDataItem((decimal)0.123456789, (System.Double)0.123456789));
            NullableDoubleData.Add(new TestDataItem((decimal)-0.123456789, -0.123456789D));
            NullableDoubleData.Add(new TestDataItem((decimal)-123.4567890, -123.4567890D));
            NullableDoubleData.Add(new TestDataItem((decimal)-1234567890, -1234567890D));
            NullableDoubleData.Add(new TestDataItem((decimal)-123, -123.0D));

            NullableDoubleData.Add(new TestDataItem(DateTime.MinValue, null, "(DateTime).MinValue"));
            NullableDoubleData.Add(new TestDataItem(DateTime.MaxValue, null, "(DateTime).MaxValue"));
            NullableDoubleData.Add(new TestDataItem(DateTime.Today, null, "(DateTime).Today"));
            NullableDoubleData.Add(new TestDataItem(DateTime.UnixEpoch, null, "(DateTime).UnixEpoch"));
            var dt = new DateTime(2003, 1, 2, 4, 5, 6, 7, DateTimeKind.Utc);
            NullableDoubleData.Add(new TestDataItem(dt, null));

            NullableDoubleData.Add(new TestDataItem(DateTimeOffset.MinValue, null, "(DateTimeOffset).MinValue"));
            NullableDoubleData.Add(new TestDataItem(DateTimeOffset.MaxValue, null, "(DateTimeOffset).MaxValue"));
            NullableDoubleData.Add(new TestDataItem(DateTimeOffset.UnixEpoch, null, "(DateTimeOffset).UnixEpoch"));
            NullableDoubleData.Add(new TestDataItem(new DateTimeOffset(dt, TimeSpan.Zero), null));


            foreach (var tuple in NullableDoubleData.ToList())
            {
                string desc;
                switch (tuple.TypeCode)
                {
                    case TypeCode.Char:
                        char c = (char)tuple.Value;
                        char cUpper = c.ToString().ToUpper()[0];
                        char cLower = c.ToString().ToLower()[0];
                        desc = "(Char)" + tuple.Description?.Replace("(Char)", "").ToUpper();
                        if (c != cUpper)
                            NullableDoubleData.Add(new TestDataItem(cUpper, (System.Double)cUpper, desc));
                        desc = "(Char)" + tuple.Description?.Replace("(Char)", "").ToLower();
                        if (c != cLower)
                            NullableDoubleData.Add(new TestDataItem(cLower, (System.Double)cLower, desc));
                        break;
                    case TypeCode.Byte:
                        c = Convert.ToChar(tuple.Value);
                        cUpper = (c.ToString().ToUpper()[0]);
                        cLower = (c.ToString().ToLower()[0]);
                        
                        desc = "(Byte)" + tuple.Description?.Replace("(Byte)", "").ToUpper();
                        if (!desc.Contains('.') && !NullableDoubleData.Exists(o=>o.TypeCode == TypeCode.Byte && (byte)o.Value == (byte)cUpper))
                            NullableDoubleData.Add(new TestDataItem((byte)cUpper, (System.Double)cUpper, desc));
                        
                        desc = "(Byte)" + tuple.Description?.Replace("(Byte)", "").ToLower();
                        if (!desc.Contains('.') && !NullableDoubleData.Exists(o=>o.TypeCode == TypeCode.Byte && (byte)o.Value == (byte)cLower))
                            NullableDoubleData.Add(new TestDataItem((byte)cLower, (System.Double)cLower, desc));
                        break;
                    case TypeCode.String:
                        string s = tuple.Value.ToString();
                        string sUpper = s.ToString().ToUpper();
                        string sLower = s.ToString().ToLower();
                        desc = "(String)" + tuple.Description?.Replace("(String)", "").ToUpper();
                        if (!desc.Contains('.') && !NullableDoubleData.Exists(o=>o.TypeCode == TypeCode.String && o.Value.ToString() == sUpper))
                            NullableDoubleData.Add(new TestDataItem(sUpper, tuple.ExpectedValue, desc));
                        desc = "(String)" + tuple.Description?.Replace("(String)", "").ToLower();
                        if (!desc.Contains('.') && !NullableDoubleData.Exists(o=>o.TypeCode == TypeCode.String && o.Value.ToString() == sLower))
                            NullableDoubleData.Add(new TestDataItem(sLower, tuple.ExpectedValue, desc));

                        break;
                }
            }

            foreach (var tuple in DataSourceValues.NullableDoubleData)
            {
                NullableDoubleDictionary[tuple.Key] = tuple.Value;
                
                if (NullableDoubleDataRecord.GetOrdinal(tuple.Key) < 0)
                    ((DataRecordMock) NullableDoubleDataRecord).Add(tuple.Key, tuple.Value);
                
                if (!NullableDoubleKvpList.Exists(kvp=>kvp.Key == tuple.Key))
                    NullableDoubleKvpList.Add(new KeyValuePair<string, object>(tuple.Key, tuple.Value));
            }

        }
        
        public static readonly Dictionary<string, object> NullableDoubleDictionary = new Dictionary<string, object>();
        public static readonly IDataRecord NullableDoubleDataRecord = new DataRecordMock();
        public static readonly List<KeyValuePair<string, object>> NullableDoubleKvpList = new List<KeyValuePair<string, object>>();

        public static List<TestDataItem> NullableDoubleData = new List<TestDataItem>
        {
            // Null
            new TestDataItem(null, null, "NULL"),
            new TestDataItem(DBNull.Value, null, "(DBNull).Value"),

            // Boolean values
            new TestDataItem(true, (System.Double)1),
            new TestDataItem(false, (System.Double)0),

            // Byte Values
            new TestDataItem((byte)1, (System.Double)1),
            new TestDataItem((byte)0, (System.Double)0),
            new TestDataItem((byte)8, (System.Double)8),
            new TestDataItem((byte)9, (System.Double)9),
            new TestDataItem((byte)'1', (System.Double)'1', "(Byte)'1'"),
            new TestDataItem((byte)'0', (System.Double)'0', "(Byte)'0'"),
            new TestDataItem((byte)'y', (System.Double)'y', "(Byte)'y'"),
            new TestDataItem((byte)'n', (System.Double)'n', "(Byte)'n'"),
            new TestDataItem((byte)'t', (System.Double)'t', "(Byte)'t'"),
            new TestDataItem((byte)'f', (System.Double)'f', "(Byte)'f'"),
            new TestDataItem(byte.MinValue, (System.Double)byte.MinValue, "(Byte).MinValue"),
            new TestDataItem(byte.MaxValue, (System.Double)byte.MaxValue, "(Byte).MaxValue"),

            // SByte Values
            new TestDataItem((sbyte)1, (System.Double)1),
            new TestDataItem((sbyte)0, (System.Double)0),
            new TestDataItem((sbyte)8, (System.Double)8),
            new TestDataItem((sbyte)9, (System.Double)9),
            new TestDataItem(sbyte.MinValue, (System.Double)sbyte.MinValue, "(SByte).MinValue"),
            new TestDataItem(sbyte.MaxValue, (System.Double)sbyte.MaxValue, "(SByte).MaxValue"),

            // Char Values
            new TestDataItem((char)1, (System.Double)1, "(Char)1"),
            new TestDataItem((char)0, (System.Double)0, "(Char)0"),
            new TestDataItem((char)8, (System.Double)8, "(Char)8"),
            new TestDataItem((char)9, (System.Double)9, "(Char)9 <'\\t'>"),
            new TestDataItem((char)'1', (System.Double)'1', "(Char)'1'"),
            new TestDataItem((char)'0', (System.Double)'0', "(Char)'0'"),
            new TestDataItem((char)'t', (System.Double)'t', "(Char)'t'"),
            new TestDataItem((char)'y', (System.Double)'y', "(Char)'y'"),
            new TestDataItem(char.MinValue, (System.Double)char.MinValue, "(Char).MinValue"),
            new TestDataItem(char.MaxValue, (System.Double)char.MaxValue, "(Char).MaxValue"),
            
            // Double Values
            new TestDataItem((double)1, (System.Double)1),
            new TestDataItem((double)0, (System.Double)0),
            new TestDataItem((double)8, (System.Double)8),
            new TestDataItem((double)9, (System.Double)9),
            new TestDataItem((double)1.0, (System.Double)1, "(Double)1.0"),
            new TestDataItem((double)1.5, (System.Double)1.5),
            new TestDataItem((double)1.9999, (System.Double)1.9999),
            new TestDataItem((double)0.5, (System.Double)0.5),
            new TestDataItem(double.Epsilon, (System.Double)double.Epsilon, "(Double).Epsilon"),
            new TestDataItem(double.NaN, double.NaN, "(Double).NaN"),
            new TestDataItem(double.MinValue, double.MinValue, "(Double).MinValue"),
            new TestDataItem(double.MaxValue, double.MaxValue, "(Double).MaxValue"),
            new TestDataItem(double.NegativeInfinity, System.Double.NegativeInfinity, "(Double).NegativeInfinity"),
            new TestDataItem(double.PositiveInfinity, System.Double.PositiveInfinity, "(Double).PositiveInfinity"),
            new TestDataItem((double)123, (System.Double)123),
            new TestDataItem((double)1234567890, (System.Double)1234567890),
            new TestDataItem((double)123.4567890, (System.Double)123.4567890),
            new TestDataItem((double)0.123456789, (System.Double)0.123456789),
            new TestDataItem((double)-0.123456789, -0.123456789D),
            new TestDataItem((double)-123.4567890, (-123.4567890D)),
            new TestDataItem((double)-1234567890, -1234567890D),
            new TestDataItem((double)-123, -123.0D),

            // Single Values
            new TestDataItem((float)1, (System.Double)1),
            new TestDataItem((float)0, (System.Double)0),
            new TestDataItem((float)8, (System.Double)8),
            new TestDataItem((float)9, (System.Double)9),
            new TestDataItem((float)1.0, (System.Double)1, "(Single)1.0"),
            new TestDataItem((float)1.5, (System.Double)1.5),
            new TestDataItem((float)1.9999, (System.Double)(float)1.9999),
            new TestDataItem((float)0.5, (System.Double)0.5),
            new TestDataItem(float.Epsilon, (System.Double)float.Epsilon, "(Single).Epsilon"),
            new TestDataItem(float.NaN, double.NaN, "(Single).NaN"),
            new TestDataItem(float.MinValue, (System.Double)float.MinValue, "(Single).MinValue"),
            new TestDataItem(float.MaxValue, (System.Double)float.MaxValue, "(Single).MaxValue"),
            new TestDataItem(float.NegativeInfinity, System.Double.NegativeInfinity, "(Single).NegativeInfinity"),
            new TestDataItem(float.PositiveInfinity, System.Double.PositiveInfinity, "(Single).PositiveInfinity"),
            new TestDataItem((float)123, (System.Double)123),
            new TestDataItem((float)1234567890, (System.Double)(float)1234567890, "(Single)1234567890"),
            new TestDataItem((float)123.4567890, (System.Double)(float)123.4567890),
            new TestDataItem((float)0.123456789, (System.Double)(float)0.123456789),
            new TestDataItem((float)-0.123456789, (System.Double)(float)-0.123456789),
            new TestDataItem((float)-123.4567890, (System.Double)(float)-123.4567890),
            new TestDataItem((float)-1234567890, (System.Double)(float)-1234567890, "(Single)-1234567890"),
            new TestDataItem((float)-123, -123.0D),

            // Int16 Values
            new TestDataItem((short)1, (System.Double)1),
            new TestDataItem((short)0, (System.Double)0),
            new TestDataItem((short)8, (System.Double)8),
            new TestDataItem((short)9, (System.Double)9),
            new TestDataItem(short.MinValue, (System.Double)short.MinValue, "(Int16).MinValue"),
            new TestDataItem(short.MaxValue, (System.Double)short.MaxValue, "(Int16).MaxValue"),

            // UInt16 Values
            new TestDataItem((ushort)1, (System.Double)1),
            new TestDataItem((ushort)0, (System.Double)0),
            new TestDataItem((ushort)8, (System.Double)8),
            new TestDataItem((ushort)9, (System.Double)9),
            new TestDataItem(ushort.MinValue, (System.Double)ushort.MinValue, "(UInt16).MinValue"),
            new TestDataItem(ushort.MaxValue, (System.Double)ushort.MaxValue, "(UInt16).MaxValue"),

            // Int32 Values
            new TestDataItem((int)1, (System.Double)1),
            new TestDataItem((int)0, (System.Double)0),
            new TestDataItem((int)8, (System.Double)8),
            new TestDataItem((int)9, (System.Double)9),
            new TestDataItem(int.MinValue, (System.Double)int.MinValue, "(Int32).MinValue"),
            new TestDataItem(int.MaxValue, (System.Double)int.MaxValue, "(Int32).MaxValue"),

            // UInt32 Values
            new TestDataItem((uint)1, (System.Double)1),
            new TestDataItem((uint)0, (System.Double)0),
            new TestDataItem((uint)8, (System.Double)8),
            new TestDataItem((uint)9, (System.Double)9),
            new TestDataItem(uint.MinValue, (System.Double)uint.MinValue, "(UInt32).MinValue"),
            new TestDataItem(uint.MaxValue, (System.Double)uint.MaxValue, "(UInt32).MaxValue"),

            // Int64 Values
            new TestDataItem((long)1, (System.Double)1),
            new TestDataItem((long)0, (System.Double)0),
            new TestDataItem((long)8, (System.Double)8),
            new TestDataItem((long)9, (System.Double)9),
            new TestDataItem(long.MinValue, (System.Double)long.MinValue, "(Int64).MinValue"),
            new TestDataItem(long.MaxValue, (System.Double)long.MaxValue, "(Int64).MaxValue"),

            // UInt64 Values
            new TestDataItem((ulong)1, (System.Double)1),
            new TestDataItem((ulong)0, (System.Double)0),
            new TestDataItem((ulong)8, (System.Double)8),
            new TestDataItem((ulong)9, (System.Double)9),
            new TestDataItem(ulong.MinValue, (System.Double)ulong.MinValue, "(UInt64).MinValue"),
            new TestDataItem(ulong.MaxValue, (System.Double)ulong.MaxValue, "(UInt64).MaxValue"),

            // Object Values
            new TestDataItem(new object(), null),

            // Strings
            new TestDataItem("", null, "(String)\"\"", "String_Empty"),
            new TestDataItem(" \t\r\n", null, "(String)\" \\t\\r\\n\"", "String_Whitespace"),
            new TestDataItem("1", (System.Double)1),
            new TestDataItem("0", (System.Double)0),
            new TestDataItem("8", (System.Double)8),
            new TestDataItem("9", (System.Double)9),
            new TestDataItem("y", null),
            new TestDataItem("n", null),
            new TestDataItem("t", null),
            new TestDataItem("f", null),
            new TestDataItem("Yes", null),
            new TestDataItem("No", null),
            new TestDataItem("True", null),
            new TestDataItem("False", null),
            new TestDataItem("123", (System.Double)123),
            new TestDataItem("1234567890", (System.Double)1234567890),
            new TestDataItem("0.123456789", (System.Double)0.123456789),
            new TestDataItem("-0.123456789", -0.123456789D),
            new TestDataItem("-123.4567890", -123.4567890D),
            new TestDataItem("-1234567890", -1234567890D),
            new TestDataItem("-123", -123.0D),
            new TestDataItem("123456789012345678901234567890", 123456789012345678901234567890D),
            new TestDataItem("-123456789012345678901234567890", -123456789012345678901234567890D),
            new TestDataItem("123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890", 123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890D),
            new TestDataItem("-123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890", -123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890D),
            new TestDataItem("9123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890.123456789012345678901234567890123456789012345678901234567890", 9123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890.123456789012345678901234567890123456789012345678901234567890D),
            new TestDataItem("-9123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890.123456789012345678901234567890123456789012345678901234567890", -9123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890.123456789012345678901234567890123456789012345678901234567890D),
            new TestDataItem("one", null),
            new TestDataItem("0w", (System.Double)0),
            new TestDataItem("1Y", (System.Double)1),
            new TestDataItem("12K", (System.Double)12),
            new TestDataItem("123Z", (System.Double)123),
            new TestDataItem(".0", (System.Double)0),
            new TestDataItem(".1", (System.Double)0.1),
            new TestDataItem(".2", (System.Double)0.2),
            new TestDataItem(".3", (System.Double)0.3),
            new TestDataItem(".4", (System.Double)0.4),
            new TestDataItem(".5", (System.Double)0.5),
            new TestDataItem(".6", (System.Double)0.6),
            new TestDataItem(".7", (System.Double)0.7),
            new TestDataItem(".8", (System.Double)0.8),
            new TestDataItem(".9", (System.Double)0.9),
            new TestDataItem("-.0", (System.Double)0),
            new TestDataItem("-.1", -0.1D),
            new TestDataItem("-.2", -0.2D),
            new TestDataItem("-.3", -0.3D),
            new TestDataItem("-.4", -0.4D),
            new TestDataItem("-.5", -0.5D),
            new TestDataItem("-.6", -0.6D),
            new TestDataItem("-.7", -0.7D),
            new TestDataItem("-.8", -0.8D),
            new TestDataItem("-.9", -0.9D),
            new TestDataItem(".0255", (System.Double)0.0255),
            new TestDataItem(".1255", (System.Double)0.1255),
            new TestDataItem(".2255", (System.Double)0.2255),
            new TestDataItem(".3255", (System.Double)0.3255),
            new TestDataItem(".4255", (System.Double)0.4255),
            new TestDataItem(".5255", (System.Double)0.5255),
            new TestDataItem(".6255", (System.Double)0.6255),
            new TestDataItem(".7255", (System.Double)0.7255),
            new TestDataItem(".8255", (System.Double)0.8255),
            new TestDataItem(".9255", (System.Double)0.9255),
            new TestDataItem("-.0255", -0.0255D),
            new TestDataItem("-.1255", -0.1255D),
            new TestDataItem("-.2255", -0.2255D),
            new TestDataItem("-.3255", -0.3255D),
            new TestDataItem("-.4255", -0.4255),
            new TestDataItem("-.5255", -0.5255),
            new TestDataItem("-.6255", -0.6255),
            new TestDataItem("-.7255", -0.7255),
            new TestDataItem("-.8255", -0.8255),
            new TestDataItem("-.9255", -0.9255),
            new TestDataItem("-", null),
            new TestDataItem(".", null),
            new TestDataItem("-.", null),
        };
        
    }
}