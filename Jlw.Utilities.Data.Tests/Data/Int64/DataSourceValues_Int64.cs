using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Jlw.Utilities.Data.DbUtility;

namespace Jlw.Utilities.Data.Tests
{
    public partial class DataSourceValues
    {
        
        protected static void InitInt64()
        {
            NullableInt64Data.Add(new TestDataItem((decimal)1, (System.Int64)1));
            NullableInt64Data.Add(new TestDataItem((decimal)0, (System.Int64)0));
            NullableInt64Data.Add(new TestDataItem((decimal)8, (System.Int64)8));
            NullableInt64Data.Add(new TestDataItem((decimal)9, (System.Int64)9));
            NullableInt64Data.Add(new TestDataItem(decimal.One, (System.Int64)1, "(Decimal).One"));
            NullableInt64Data.Add(new TestDataItem(decimal.Zero, (System.Int64)0, "(Decimal).Zero"));
            NullableInt64Data.Add(new TestDataItem(decimal.MinusOne, -1L, "(Decimal).MinusOne"));
            NullableInt64Data.Add(new TestDataItem(decimal.MinValue, System.Int64.MinValue, "(Decimal).MinValue"));
            NullableInt64Data.Add(new TestDataItem(decimal.MaxValue, System.Int64.MaxValue, "(Decimal).MaxValue"));
            NullableInt64Data.Add(new TestDataItem((decimal)123, (System.Int64)123));
            NullableInt64Data.Add(new TestDataItem((decimal)1234567890, (System.Int64)1234567890));
            NullableInt64Data.Add(new TestDataItem((decimal)123.4567890, (System.Int64)123));
            NullableInt64Data.Add(new TestDataItem((decimal)0.123456789, (System.Int64)0));
            NullableInt64Data.Add(new TestDataItem((decimal)-0.123456789, (System.Int64)0));
            NullableInt64Data.Add(new TestDataItem((decimal)-123.4567890, -123L));
            NullableInt64Data.Add(new TestDataItem((decimal)-1234567890, -1234567890L));
            NullableInt64Data.Add(new TestDataItem((decimal)-123, -123L));

            NullableInt64Data.Add(new TestDataItem(DateTime.MinValue, DateTime.MinValue.ToBinary(), "(DateTime).MinValue"));
            NullableInt64Data.Add(new TestDataItem(DateTime.MaxValue, DateTime.MaxValue.ToBinary(), "(DateTime).MaxValue"));
            NullableInt64Data.Add(new TestDataItem(DateTime.Today, DateTime.Today.ToBinary(), "(DateTime).Today"));
//            NullableInt64Data.Add(new TestDataItem(DateTime.UnixEpoch, DateTime.UnixEpoch.ToBinary(), "(DateTime).UnixEpoch"));
            var dt = new DateTime(2003, 1, 2, 4, 5, 6, 7, DateTimeKind.Utc);
            NullableInt64Data.Add(new TestDataItem(dt, dt.ToBinary()));

            NullableInt64Data.Add(new TestDataItem(DateTimeOffset.MinValue, null, "(DateTimeOffset).MinValue"));
            NullableInt64Data.Add(new TestDataItem(DateTimeOffset.MaxValue, null, "(DateTimeOffset).MaxValue"));
//            NullableInt64Data.Add(new TestDataItem(DateTimeOffset.UnixEpoch, null, "(DateTimeOffset).UnixEpoch"));
            NullableInt64Data.Add(new TestDataItem(new DateTimeOffset(dt, TimeSpan.Zero), null));


            foreach (var tuple in NullableInt64Data.ToList())
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
                            NullableInt64Data.Add(new TestDataItem(cUpper, (System.Int64)cUpper, desc));
                        desc = "(Char)" + tuple.Description?.Replace("(Char)", "").ToLower();
                        if (c != cLower)
                            NullableInt64Data.Add(new TestDataItem(cLower, (System.Int64)cLower, desc));
                        break;
                    case TypeCode.Byte:
                        c = Convert.ToChar(tuple.Value);
                        cUpper = (c.ToString().ToUpper()[0]);
                        cLower = (c.ToString().ToLower()[0]);
                        
                        desc = "(Byte)" + tuple.Description?.Replace("(Byte)", "").ToUpper();
                        if (!desc.Contains('.') && !NullableInt64Data.Exists(o=>o.TypeCode == TypeCode.Byte && (byte)o.Value == (byte)cUpper))
                            NullableInt64Data.Add(new TestDataItem((byte)cUpper, (System.Int64)cUpper, desc));
                        
                        desc = "(Byte)" + tuple.Description?.Replace("(Byte)", "").ToLower();
                        if (!desc.Contains('.') && !NullableInt64Data.Exists(o=>o.TypeCode == TypeCode.Byte && (byte)o.Value == (byte)cLower))
                            NullableInt64Data.Add(new TestDataItem((byte)cLower, (System.Int64)cLower, desc));
                        break;
                    case TypeCode.String:
                        string s = tuple.Value.ToString();
                        string sUpper = s.ToString().ToUpper();
                        string sLower = s.ToString().ToLower();
                        desc = "(String)" + tuple.Description?.Replace("(String)", "").ToUpper();
                        if (!desc.Contains('.') && !NullableInt64Data.Exists(o=>o.TypeCode == TypeCode.String && o.Value.ToString() == sUpper))
                            NullableInt64Data.Add(new TestDataItem(sUpper, tuple.ExpectedValue, desc));
                        desc = "(String)" + tuple.Description?.Replace("(String)", "").ToLower();
                        if (!desc.Contains('.') && !NullableInt64Data.Exists(o=>o.TypeCode == TypeCode.String && o.Value.ToString() == sLower))
                            NullableInt64Data.Add(new TestDataItem(sLower, tuple.ExpectedValue, desc));

                        break;
                }
            }

            foreach (var tuple in DataSourceValues.NullableInt64Data)
            {
                NullableInt64Dictionary[tuple.Key] = tuple.Value;
                
                if (NullableInt64DataRecord.GetOrdinal(tuple.Key) < 0)
                    ((DataRecordMock) NullableInt64DataRecord).Add(tuple.Key, tuple.Value);
                
                if (!NullableInt64KvpList.Exists(kvp=>kvp.Key == tuple.Key))
                    NullableInt64KvpList.Add(new KeyValuePair<string, object>(tuple.Key, tuple.Value));
            }

        }
        
        public static readonly Dictionary<string, object> NullableInt64Dictionary = new Dictionary<string, object>();
        public static readonly IDataRecord NullableInt64DataRecord = new DataRecordMock();
        public static readonly List<KeyValuePair<string, object>> NullableInt64KvpList = new List<KeyValuePair<string, object>>();

        public static List<TestDataItem> NullableInt64Data = new List<TestDataItem>
        {
            // Null
            new TestDataItem(null, null, "NULL"),
            new TestDataItem(DBNull.Value, null, "(DBNull).Value"),

            // Boolean values
            new TestDataItem(true, (System.Int64)1),
            new TestDataItem(false, (System.Int64)0),

            // Byte Values
            new TestDataItem((byte)1, (System.Int64)1),
            new TestDataItem((byte)0, (System.Int64)0),
            new TestDataItem((byte)8, (System.Int64)8),
            new TestDataItem((byte)9, (System.Int64)9),
            new TestDataItem((byte)'1', (System.Int64)'1', "(Byte)'1'"),
            new TestDataItem((byte)'0', (System.Int64)'0', "(Byte)'0'"),
            new TestDataItem((byte)'y', (System.Int64)'y', "(Byte)'y'"),
            new TestDataItem((byte)'n', (System.Int64)'n', "(Byte)'n'"),
            new TestDataItem((byte)'t', (System.Int64)'t', "(Byte)'t'"),
            new TestDataItem((byte)'f', (System.Int64)'f', "(Byte)'f'"),
            new TestDataItem(byte.MinValue, (System.Int64)byte.MinValue, "(Byte).MinValue"),
            new TestDataItem(byte.MaxValue, (System.Int64)byte.MaxValue, "(Byte).MaxValue"),

            // SByte Values
            new TestDataItem((sbyte)1, (System.Int64)1),
            new TestDataItem((sbyte)0, (System.Int64)0),
            new TestDataItem((sbyte)8, (System.Int64)8),
            new TestDataItem((sbyte)9, (System.Int64)9),
            new TestDataItem(sbyte.MinValue, (System.Int64)sbyte.MinValue, "(SByte).MinValue"),
            new TestDataItem(sbyte.MaxValue, (System.Int64)sbyte.MaxValue, "(SByte).MaxValue"),

            // Char Values
            new TestDataItem((char)1, (System.Int64)1, "(Char)1"),
            new TestDataItem((char)0, (System.Int64)0, "(Char)0"),
            new TestDataItem((char)8, (System.Int64)8, "(Char)8"),
            new TestDataItem((char)9, (System.Int64)9, "(Char)9 <'\\t'>"),
            new TestDataItem((char)'1', (System.Int64)'1', "(Char)'1'"),
            new TestDataItem((char)'0', (System.Int64)'0', "(Char)'0'"),
            new TestDataItem((char)'t', (System.Int64)'t', "(Char)'t'"),
            new TestDataItem((char)'y', (System.Int64)'y', "(Char)'y'"),
            new TestDataItem(char.MinValue, (System.Int64)char.MinValue, "(Char).MinValue"),
            new TestDataItem(char.MaxValue, (System.Int64)char.MaxValue, "(Char).MaxValue"),
            
            // Double Values
            new TestDataItem((double)1, (System.Int64)1),
            new TestDataItem((double)0, (System.Int64)0),
            new TestDataItem((double)8, (System.Int64)8),
            new TestDataItem((double)9, (System.Int64)9),
            new TestDataItem((double)1.0, (System.Int64)1, "(Double)1.0"),
            new TestDataItem((double)1.5, (System.Int64)1),
            new TestDataItem((double)1.9999, (System.Int64)1),
            new TestDataItem((double)0.5, (System.Int64)0),
            new TestDataItem(double.Epsilon, (System.Int64)0, "(Double).Epsilon"),
            new TestDataItem(double.NaN, null, "(Double).NaN"),
            new TestDataItem(double.MinValue, System.Int64.MinValue, "(Double).MinValue"),
            new TestDataItem(double.MaxValue, System.Int64.MaxValue, "(Double).MaxValue"),
            new TestDataItem(double.NegativeInfinity, System.Int64.MinValue, "(Double).NegativeInfinity"),
            new TestDataItem(double.PositiveInfinity, System.Int64.MaxValue, "(Double).PositiveInfinity"),
            new TestDataItem((double)123, (System.Int64)123),
            new TestDataItem((double)1234567890, (System.Int64)1234567890),
            new TestDataItem((double)123.4567890, (System.Int64)123),
            new TestDataItem((double)0.123456789, (System.Int64)0),
            new TestDataItem((double)-0.123456789, 0L),
            new TestDataItem((double)-123.4567890, -123L),
            new TestDataItem((double)-1234567890, (System.Int64)(-1234567890)),
            new TestDataItem((double)-123, -123L),

            // Single Values
            new TestDataItem((float)1, (System.Int64)1),
            new TestDataItem((float)0, (System.Int64)0),
            new TestDataItem((float)8, (System.Int64)8),
            new TestDataItem((float)9, (System.Int64)9),
            new TestDataItem((float)1.0, (System.Int64)1, "(Single)1.0"),
            new TestDataItem((float)1.5, (System.Int64)1),
            new TestDataItem((float)1.9999, (System.Int64)1),
            new TestDataItem((float)0.5, (System.Int64)0),
            new TestDataItem(float.Epsilon, (System.Int64)0, "(Single).Epsilon"),
            new TestDataItem(float.NaN, null, "(Single).NaN"),
            new TestDataItem(float.MinValue, System.Int64.MinValue, "(Single).MinValue"),
            new TestDataItem(float.MaxValue, System.Int64.MaxValue, "(Single).MaxValue"),
            new TestDataItem(float.NegativeInfinity, System.Int64.MinValue, "(Single).NegativeInfinity"),
            new TestDataItem(float.PositiveInfinity, System.Int64.MaxValue, "(Single).PositiveInfinity"),
            new TestDataItem((float)123, (System.Int64)123),
            new TestDataItem((float)1234567890, (System.Int64)((float)1234567890), "(Single)1234567890"),
            new TestDataItem((float)123.4567890, (System.Int64)123),
            new TestDataItem((float)0.123456789, (System.Int64)0),
            new TestDataItem((float)-0.123456789, (System.Int64)0),
            new TestDataItem((float)-123.4567890, -123L),
            new TestDataItem((float)-1234567890, (System.Int64)((float)-1234567890), "(Single)-1234567890"),
            new TestDataItem((float)-123, -123L),

            // Int16 Values
            new TestDataItem((short)1, (System.Int64)1),
            new TestDataItem((short)0, (System.Int64)0),
            new TestDataItem((short)8, (System.Int64)8),
            new TestDataItem((short)9, (System.Int64)9),
            new TestDataItem(short.MinValue, (System.Int64)short.MinValue, "(Int16).MinValue"),
            new TestDataItem(short.MaxValue, (System.Int64)short.MaxValue, "(Int16).MaxValue"),

            // UInt16 Values
            new TestDataItem((ushort)1, (System.Int64)1),
            new TestDataItem((ushort)0, (System.Int64)0),
            new TestDataItem((ushort)8, (System.Int64)8),
            new TestDataItem((ushort)9, (System.Int64)9),
            new TestDataItem(ushort.MinValue, (System.Int64)ushort.MinValue, "(UInt16).MinValue"),
            new TestDataItem(ushort.MaxValue, (System.Int64)ushort.MaxValue, "(UInt16).MaxValue"),

            // Int32 Values
            new TestDataItem((int)1, (System.Int64)1),
            new TestDataItem((int)0, (System.Int64)0),
            new TestDataItem((int)8, (System.Int64)8),
            new TestDataItem((int)9, (System.Int64)9),
            new TestDataItem(int.MinValue, (System.Int64)Int32.MinValue, "(Int32).MinValue"),
            new TestDataItem(int.MaxValue, (System.Int64)Int32.MaxValue, "(Int32).MaxValue"),

            // UInt32 Values
            new TestDataItem((uint)1, (System.Int64)1),
            new TestDataItem((uint)0, (System.Int64)0),
            new TestDataItem((uint)8, (System.Int64)8),
            new TestDataItem((uint)9, (System.Int64)9),
            new TestDataItem(uint.MinValue, (System.Int64)uint.MinValue, "(UInt32).MinValue"),
            new TestDataItem(uint.MaxValue, (System.Int64)uint.MaxValue, "(UInt32).MaxValue"),

            // Int64 Values
            new TestDataItem((long)1, (System.Int64)1),
            new TestDataItem((long)0, (System.Int64)0),
            new TestDataItem((long)8, (System.Int64)8),
            new TestDataItem((long)9, (System.Int64)9),
            new TestDataItem(long.MinValue, System.Int64.MinValue, "(Int64).MinValue"),
            new TestDataItem(long.MaxValue, System.Int64.MaxValue, "(Int64).MaxValue"),

            // UInt64 Values
            new TestDataItem((ulong)1, (System.Int64)1),
            new TestDataItem((ulong)0, (System.Int64)0),
            new TestDataItem((ulong)8, (System.Int64)8),
            new TestDataItem((ulong)9, (System.Int64)9),
            new TestDataItem(ulong.MinValue, (System.Int64)ulong.MinValue, "(UInt64).MinValue"),
            new TestDataItem(ulong.MaxValue, System.Int64.MaxValue, "(UInt64).MaxValue"),

            // Object Values
            new TestDataItem(new object(), null),

            // Strings
            new TestDataItem("", null, "(String)\"\"", "String_Empty"),
            new TestDataItem(" \t\r\n", null, "(String)\" \\t\\r\\n\"", "String_Whitespace"),
            new TestDataItem("1", (System.Int64)1),
            new TestDataItem("0", (System.Int64)0),
            new TestDataItem("8", (System.Int64)8),
            new TestDataItem("9", (System.Int64)9),
            new TestDataItem("y", null),
            new TestDataItem("n", null),
            new TestDataItem("t", null),
            new TestDataItem("f", null),
            new TestDataItem("Yes", null),
            new TestDataItem("No", null),
            new TestDataItem("True", null),
            new TestDataItem("False", null),
            new TestDataItem("123", (System.Int64)123),
            new TestDataItem("1234567890", (System.Int64)1234567890),
            new TestDataItem("0.123456789", (System.Int64)0),
            new TestDataItem("-0.123456789", (System.Int64)0),
            new TestDataItem("-123.4567890", -123L),
            new TestDataItem("-1234567890", -1234567890L),
            new TestDataItem("-123", -123L),
            new TestDataItem("123456789012345678901234567890", System.Int64.MaxValue),
            new TestDataItem("-123456789012345678901234567890", System.Int64.MinValue),
            new TestDataItem("123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890", System.Int64.MaxValue),
            new TestDataItem("-123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890", System.Int64.MinValue),
            new TestDataItem("9123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890.123456789012345678901234567890123456789012345678901234567890", System.Int64.MaxValue),
            new TestDataItem("-9123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890.123456789012345678901234567890123456789012345678901234567890", System.Int64.MinValue),
            new TestDataItem("one", null),
            new TestDataItem("0w", (System.Int64)0),
            new TestDataItem("1Y", (System.Int64)1),
            new TestDataItem("12K", (System.Int64)12),
            new TestDataItem("123Z", (System.Int64)123),
            new TestDataItem(".0", (System.Int64)0),
            new TestDataItem(".1", (System.Int64)0),
            new TestDataItem(".2", (System.Int64)0),
            new TestDataItem(".3", (System.Int64)0),
            new TestDataItem(".4", (System.Int64)0),
            new TestDataItem(".5", (System.Int64)0),
            new TestDataItem(".6", (System.Int64)0),
            new TestDataItem(".7", (System.Int64)0),
            new TestDataItem(".8", (System.Int64)0),
            new TestDataItem(".9", (System.Int64)0),
            new TestDataItem("-.0", (System.Int64)0),
            new TestDataItem("-.1", (System.Int64)0),
            new TestDataItem("-.2", (System.Int64)0),
            new TestDataItem("-.3", (System.Int64)0),
            new TestDataItem("-.4", (System.Int64)0),
            new TestDataItem("-.5", (System.Int64)0),
            new TestDataItem("-.6", (System.Int64)0),
            new TestDataItem("-.7", (System.Int64)0),
            new TestDataItem("-.8", (System.Int64)0),
            new TestDataItem("-.9", (System.Int64)0),
            new TestDataItem(".0255", (System.Int64)0),
            new TestDataItem(".1255", (System.Int64)0),
            new TestDataItem(".2255", (System.Int64)0),
            new TestDataItem(".3255", (System.Int64)0),
            new TestDataItem(".4255", (System.Int64)0),
            new TestDataItem(".5255", (System.Int64)0),
            new TestDataItem(".6255", (System.Int64)0),
            new TestDataItem(".7255", (System.Int64)0),
            new TestDataItem(".8255", (System.Int64)0),
            new TestDataItem(".9255", (System.Int64)0),
            new TestDataItem("-.0255", (System.Int64)0),
            new TestDataItem("-.1255", (System.Int64)0),
            new TestDataItem("-.2255", (System.Int64)0),
            new TestDataItem("-.3255", (System.Int64)0),
            new TestDataItem("-.4255", (System.Int64)0),
            new TestDataItem("-.5255", (System.Int64)0),
            new TestDataItem("-.6255", (System.Int64)0),
            new TestDataItem("-.7255", (System.Int64)0),
            new TestDataItem("-.8255", (System.Int64)0),
            new TestDataItem("-.9255", (System.Int64)0),
            new TestDataItem("-", null),
            new TestDataItem(".", null),
            new TestDataItem("-.", null),
        };
        
    }
}