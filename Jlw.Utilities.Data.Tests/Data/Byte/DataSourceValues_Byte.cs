using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Jlw.Utilities.Data.DbUtility;

namespace Jlw.Utilities.Data.Tests
{
    public partial class DataSourceValues
    {
        
        protected static void InitByte()
        {
            NullableByteData.Add(new TestDataItem((decimal)1, (byte)1));
            NullableByteData.Add(new TestDataItem((decimal)0, (byte)0));
            NullableByteData.Add(new TestDataItem((decimal)8, (byte)8));
            NullableByteData.Add(new TestDataItem((decimal)9, (byte)9));
            NullableByteData.Add(new TestDataItem(decimal.One, (byte)1, "(Decimal).One"));
            NullableByteData.Add(new TestDataItem(decimal.Zero, (byte)0, "(Decimal).Zero"));
            NullableByteData.Add(new TestDataItem(decimal.MinusOne, (byte)0, "(Decimal).MinusOne"));
            NullableByteData.Add(new TestDataItem(decimal.MinValue, byte.MinValue, "(Decimal).MinValue"));
            NullableByteData.Add(new TestDataItem(decimal.MaxValue, byte.MaxValue, "(Decimal).MaxValue"));
            NullableByteData.Add(new TestDataItem((decimal)123, (byte)123));
            NullableByteData.Add(new TestDataItem((decimal)1234567890, byte.MaxValue));
            NullableByteData.Add(new TestDataItem((decimal)123.4567890, (byte)123));
            NullableByteData.Add(new TestDataItem((decimal)0.123456789, (byte)0));
            NullableByteData.Add(new TestDataItem((decimal)-0.123456789, (byte)0));
            NullableByteData.Add(new TestDataItem((decimal)-123.4567890, (byte)0));
            NullableByteData.Add(new TestDataItem((decimal)-1234567890, byte.MinValue));
            NullableByteData.Add(new TestDataItem((decimal)-123, (byte)0));

            NullableByteData.Add(new TestDataItem(DateTime.MinValue, null, "(DateTime).MinValue"));
            NullableByteData.Add(new TestDataItem(DateTime.MaxValue, null, "(DateTime).MaxValue"));
            NullableByteData.Add(new TestDataItem(DateTime.Today, null, "(DateTime).Today"));
//            NullableByteData.Add(new TestDataItem(DateTime.UnixEpoch, null, "(DateTime).UnixEpoch"));
            NullableByteData.Add(new TestDataItem(new DateTime(2003, 1, 2, 4, 5, 6, 7, DateTimeKind.Utc), null));

            NullableByteData.Add(new TestDataItem(DateTimeOffset.MinValue, null, "(DateTimeOffset).MinValue"));
            NullableByteData.Add(new TestDataItem(DateTimeOffset.MaxValue, null, "(DateTimeOffset).MaxValue"));
//            NullableByteData.Add(new TestDataItem(DateTimeOffset.UnixEpoch, null, "(DateTimeOffset).UnixEpoch"));
            NullableByteData.Add(new TestDataItem(new DateTimeOffset(new DateTime(2003, 1, 2, 4, 5, 6, 7), TimeSpan.Zero), null));


            foreach (var tuple in NullableByteData.ToList())
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
                            NullableByteData.Add(new TestDataItem(cUpper, (byte)cUpper, desc));
                        desc = "(Char)" + tuple.Description?.Replace("(Char)", "").ToLower();
                        if (c != cLower)
                            NullableByteData.Add(new TestDataItem(cLower, (byte)cLower, desc));
                        break;
                    case TypeCode.Byte:
                        c = Convert.ToChar(tuple.Value);
                        cUpper = (c.ToString().ToUpper()[0]);
                        cLower = (c.ToString().ToLower()[0]);
                        
                        desc = "(Byte)" + tuple.Description?.Replace("(Byte)", "").ToUpper();
                        if (!desc.Contains('.') && !NullableByteData.Exists(o=>o.TypeCode == TypeCode.Byte && (byte)o.Value == (byte)cUpper))
                            NullableByteData.Add(new TestDataItem((byte)cUpper, (byte)cUpper, desc));
                        
                        desc = "(Byte)" + tuple.Description?.Replace("(Byte)", "").ToLower();
                        if (!desc.Contains('.') && !NullableByteData.Exists(o=>o.TypeCode == TypeCode.Byte && (byte)o.Value == (byte)cLower))
                            NullableByteData.Add(new TestDataItem((byte)cLower, (byte)cLower, desc));
                        break;
                    case TypeCode.String:
                        string s = tuple.Value.ToString();
                        string sUpper = s.ToString().ToUpper();
                        string sLower = s.ToString().ToLower();
                        desc = "(String)" + tuple.Description?.Replace("(String)", "").ToUpper();
                        if (!desc.Contains('.') && !NullableByteData.Exists(o=>o.TypeCode == TypeCode.String && o.Value.ToString() == sUpper))
                            NullableByteData.Add(new TestDataItem(sUpper, tuple.ExpectedValue, desc));
                        desc = "(String)" + tuple.Description?.Replace("(String)", "").ToLower();
                        if (!desc.Contains('.') && !NullableByteData.Exists(o=>o.TypeCode == TypeCode.String && o.Value.ToString() == sLower))
                            NullableByteData.Add(new TestDataItem(sLower, tuple.ExpectedValue, desc));

                        break;
                }
            }

            foreach (var tuple in DataSourceValues.NullableByteData)
            {
                NullableByteDictionary[tuple.Key] = tuple.Value;
                
                if (NullableByteDataRecord.GetOrdinal(tuple.Key) < 0)
                    ((DataRecordMock) NullableByteDataRecord).Add(tuple.Key, tuple.Value);
                
                if (!NullableByteKvpList.Exists(kvp=>kvp.Key == tuple.Key))
                    NullableByteKvpList.Add(new KeyValuePair<string, object>(tuple.Key, tuple.Value));
            }

        }
        
        public static readonly Dictionary<string, object> NullableByteDictionary = new Dictionary<string, object>();
        public static readonly IDataRecord NullableByteDataRecord = new DataRecordMock();
        public static readonly List<KeyValuePair<string, object>> NullableByteKvpList = new List<KeyValuePair<string, object>>();

        public static List<TestDataItem> NullableByteData = new List<TestDataItem>
        {
            // Null
            new TestDataItem(null, null, "NULL"),
            new TestDataItem(DBNull.Value, null, "(DBNull).Value"),

            // Boolean values
            new TestDataItem(true, (byte)1),
            new TestDataItem(false, (byte)0),

            // Byte Values
            new TestDataItem((byte)1, (byte)1),
            new TestDataItem((byte)0, (byte)0),
            new TestDataItem((byte)8, (byte)8),
            new TestDataItem((byte)9, (byte)9),
            new TestDataItem((byte)'1', (byte)'1', "(Byte)'1'"),
            new TestDataItem((byte)'0', (byte)'0', "(Byte)'0'"),
            new TestDataItem((byte)'y', (byte)'y', "(Byte)'y'"),
            new TestDataItem((byte)'n', (byte)'n', "(Byte)'n'"),
            new TestDataItem((byte)'t', (byte)'t', "(Byte)'t'"),
            new TestDataItem((byte)'f', (byte)'f', "(Byte)'f'"),
            new TestDataItem(byte.MinValue, (byte)0, "(Byte).MinValue"),
            new TestDataItem(byte.MaxValue, byte.MaxValue, "(Byte).MaxValue"),

            // SByte Values
            new TestDataItem((sbyte)1, (byte)1),
            new TestDataItem((sbyte)0, (byte)0),
            new TestDataItem((sbyte)8, (byte)8),
            new TestDataItem((sbyte)9, (byte)9),
            new TestDataItem(sbyte.MinValue, byte.MinValue, "(SByte).MinValue"),
            new TestDataItem(sbyte.MaxValue, (byte)127, "(SByte).MaxValue"),

            // Char Values
            new TestDataItem((char)1, (byte)1, "(Char)1"),
            new TestDataItem((char)0, (byte)0, "(Char)0"),
            new TestDataItem((char)8, (byte)8, "(Char)8"),
            new TestDataItem((char)9, (byte)9, "(Char)9 <'\\t'>"),
            new TestDataItem((char)'1', (byte)'1', "(Char)'1'"),
            new TestDataItem((char)'0', (byte)'0', "(Char)'0'"),
            new TestDataItem((char)'t', (byte)'t', "(Char)'t'"),
            new TestDataItem((char)'y', (byte)'y', "(Char)'y'"),
            new TestDataItem(char.MinValue, (byte)0, "(Char).MinValue"),
            new TestDataItem(char.MaxValue, byte.MaxValue, "(Char).MaxValue"),
            
            // Double Values
            new TestDataItem((double)1, (byte)1),
            new TestDataItem((double)0, (byte)0),
            new TestDataItem((double)8, (byte)8),
            new TestDataItem((double)9, (byte)9),
            new TestDataItem((double)1.0, (byte)1, "(Double)1.0"),
            new TestDataItem((double)1.5, (byte)1),
            new TestDataItem((double)1.9999, (byte)1),
            new TestDataItem((double)0.5, (byte)0),
            new TestDataItem(double.Epsilon, (byte)0, "(Double).Epsilon"),
            new TestDataItem(double.NaN, null, "(Double).NaN"),
            new TestDataItem(double.MinValue, byte.MinValue, "(Double).MinValue"),
            new TestDataItem(double.MaxValue, byte.MaxValue, "(Double).MaxValue"),
            new TestDataItem(double.NegativeInfinity, byte.MinValue, "(Double).NegativeInfinity"),
            new TestDataItem(double.PositiveInfinity, byte.MaxValue, "(Double).PositiveInfinity"),
            new TestDataItem((double)123, (byte)123),
            new TestDataItem((double)1234567890, byte.MaxValue),
            new TestDataItem((double)123.4567890, (byte)123),
            new TestDataItem((double)0.123456789, (byte)0),
            new TestDataItem((double)-0.123456789, (byte)0),
            new TestDataItem((double)-123.4567890, (byte)0),
            new TestDataItem((double)-1234567890, byte.MinValue),
            new TestDataItem((double)-123, (byte)0),

            // Single Values
            new TestDataItem((float)1, (byte)1),
            new TestDataItem((float)0, (byte)0),
            new TestDataItem((float)8, (byte)8),
            new TestDataItem((float)9, (byte)9),
            new TestDataItem((float)1.0, (byte)1, "(Single)1.0"),
            new TestDataItem((float)1.5, (byte)1),
            new TestDataItem((float)1.9999, (byte)1),
            new TestDataItem((float)0.5, (byte)0),
            new TestDataItem(float.Epsilon, (byte)0, "(Single).Epsilon"),
            new TestDataItem(float.NaN, null, "(Single).NaN"),
            new TestDataItem(float.MinValue, byte.MinValue, "(Single).MinValue"),
            new TestDataItem(float.MaxValue, byte.MaxValue, "(Single).MaxValue"),
            new TestDataItem(float.NegativeInfinity, byte.MinValue, "(Single).NegativeInfinity"),
            new TestDataItem(float.PositiveInfinity, byte.MaxValue, "(Single).PositiveInfinity"),
            new TestDataItem((float)123, (byte)123),
            new TestDataItem((float)1234567890, byte.MaxValue),
            new TestDataItem((float)123.4567890, (byte)123),
            new TestDataItem((float)0.123456789, (byte)0),
            new TestDataItem((float)-0.123456789, (byte)0),
            new TestDataItem((float)-123.4567890, (byte)0),
            new TestDataItem((float)-1234567890, byte.MinValue),
            new TestDataItem((float)-123, (byte)0),

            // Int16 Values
            new TestDataItem((short)1, (byte)1),
            new TestDataItem((short)0, (byte)0),
            new TestDataItem((short)8, (byte)8),
            new TestDataItem((short)9, (byte)9),
            new TestDataItem(short.MinValue, byte.MinValue, "(Int16).MinValue"),
            new TestDataItem(short.MaxValue, byte.MaxValue, "(Int16).MaxValue"),

            // UInt16 Values
            new TestDataItem((ushort)1, (byte)1),
            new TestDataItem((ushort)0, (byte)0),
            new TestDataItem((ushort)8, (byte)8),
            new TestDataItem((ushort)9, (byte)9),
            new TestDataItem(ushort.MinValue, (byte)0, "(UInt16).MinValue"),
            new TestDataItem(ushort.MaxValue, byte.MaxValue, "(UInt16).MaxValue"),

            // Int32 Values
            new TestDataItem((int)1, (byte)1),
            new TestDataItem((int)0, (byte)0),
            new TestDataItem((int)8, (byte)8),
            new TestDataItem((int)9, (byte)9),
            new TestDataItem(int.MinValue, byte.MinValue, "(Int32).MinValue"),
            new TestDataItem(int.MaxValue, byte.MaxValue, "(Int32).MaxValue"),

            // UInt32 Values
            new TestDataItem((uint)1, (byte)1),
            new TestDataItem((uint)0, (byte)0),
            new TestDataItem((uint)8, (byte)8),
            new TestDataItem((uint)9, (byte)9),
            new TestDataItem(uint.MinValue, (byte)0, "(UInt32).MinValue"),
            new TestDataItem(uint.MaxValue, byte.MaxValue, "(UInt32).MaxValue"),

            // Int64 Values
            new TestDataItem((long)1, (byte)1),
            new TestDataItem((long)0, (byte)0),
            new TestDataItem((long)8, (byte)8),
            new TestDataItem((long)9, (byte)9),
            new TestDataItem(long.MinValue, byte.MinValue, "(Int64).MinValue"),
            new TestDataItem(long.MaxValue, byte.MaxValue, "(Int64).MaxValue"),

            // UInt64 Values
            new TestDataItem((ulong)1, (byte)1),
            new TestDataItem((ulong)0, (byte)0),
            new TestDataItem((ulong)8, (byte)8),
            new TestDataItem((ulong)9, (byte)9),
            new TestDataItem(ulong.MinValue, (byte)0, "(UInt64).MinValue"),
            new TestDataItem(ulong.MaxValue, byte.MaxValue, "(UInt64).MaxValue"),

            // Object Values
            new TestDataItem(new object(), null),

            // Strings
            new TestDataItem("", null, "(String)\"\"", "String_Empty"),
            new TestDataItem(" \t\r\n", null, "(String)\" \\t\\r\\n\"", "String_Whitespace"),
            new TestDataItem("1", (byte)1),
            new TestDataItem("0", (byte)0),
            new TestDataItem("8", (byte)8),
            new TestDataItem("9", (byte)9),
            new TestDataItem("y", null),
            new TestDataItem("n", null),
            new TestDataItem("t", null),
            new TestDataItem("f", null),
            new TestDataItem("Yes", null),
            new TestDataItem("No", null),
            new TestDataItem("True", null),
            new TestDataItem("False", null),
            new TestDataItem("123", (byte)123),
            new TestDataItem("1234567890", byte.MaxValue),
            new TestDataItem("0.123456789", (byte)0),
            new TestDataItem("-0.123456789", (byte)0),
            new TestDataItem("-123.4567890", (byte)0),
            new TestDataItem("-1234567890", byte.MinValue),
            new TestDataItem("-123", (byte)0),
            new TestDataItem("123456789012345678901234567890", byte.MaxValue),
            new TestDataItem("-123456789012345678901234567890", byte.MinValue),
            new TestDataItem("123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890", byte.MaxValue),
            new TestDataItem("-123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890", byte.MinValue),
            new TestDataItem("9123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890.123456789012345678901234567890123456789012345678901234567890", byte.MaxValue),
            new TestDataItem("-9123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890.123456789012345678901234567890123456789012345678901234567890", byte.MinValue),
            new TestDataItem("one", null),
            new TestDataItem("0w", (byte)0),
            new TestDataItem("1Y", (byte)1),
            new TestDataItem("12K", (byte)12),
            new TestDataItem("123Z", (byte)123),
            new TestDataItem(".0", (byte)0),
            new TestDataItem(".1", (byte)0),
            new TestDataItem(".2", (byte)0),
            new TestDataItem(".3", (byte)0),
            new TestDataItem(".4", (byte)0),
            new TestDataItem(".5", (byte)0),
            new TestDataItem(".6", (byte)0),
            new TestDataItem(".7", (byte)0),
            new TestDataItem(".8", (byte)0),
            new TestDataItem(".9", (byte)0),
            new TestDataItem("-.0", (byte)0),
            new TestDataItem("-.1", (byte)0),
            new TestDataItem("-.2", (byte)0),
            new TestDataItem("-.3", (byte)0),
            new TestDataItem("-.4", (byte)0),
            new TestDataItem("-.5", (byte)0),
            new TestDataItem("-.6", (byte)0),
            new TestDataItem("-.7", (byte)0),
            new TestDataItem("-.8", (byte)0),
            new TestDataItem("-.9", (byte)0),
            new TestDataItem(".0255", (byte)0),
            new TestDataItem(".1255", (byte)0),
            new TestDataItem(".2255", (byte)0),
            new TestDataItem(".3255", (byte)0),
            new TestDataItem(".4255", (byte)0),
            new TestDataItem(".5255", (byte)0),
            new TestDataItem(".6255", (byte)0),
            new TestDataItem(".7255", (byte)0),
            new TestDataItem(".8255", (byte)0),
            new TestDataItem(".9255", (byte)0),
            new TestDataItem("-.0255", (byte)0),
            new TestDataItem("-.1255", (byte)0),
            new TestDataItem("-.2255", (byte)0),
            new TestDataItem("-.3255", (byte)0),
            new TestDataItem("-.4255", (byte)0),
            new TestDataItem("-.5255", (byte)0),
            new TestDataItem("-.6255", (byte)0),
            new TestDataItem("-.7255", (byte)0),
            new TestDataItem("-.8255", (byte)0),
            new TestDataItem("-.9255", (byte)0),
            new TestDataItem("-", null),
            new TestDataItem(".", null),
            new TestDataItem("-.", null),
        };
        
    }
}