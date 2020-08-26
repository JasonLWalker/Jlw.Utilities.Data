using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Jlw.Utilities.Data.DbUtility;

namespace Jlw.Utilities.Data.Tests
{
    public partial class DataSourceValues
    {
        
        protected static void InitInt16()
        {
            NullableInt16Data.Add(new TestDataItem((decimal)1, (Int16)1));
            NullableInt16Data.Add(new TestDataItem((decimal)0, (Int16)0));
            NullableInt16Data.Add(new TestDataItem((decimal)8, (Int16)8));
            NullableInt16Data.Add(new TestDataItem((decimal)9, (Int16)9));
            NullableInt16Data.Add(new TestDataItem(decimal.One, (Int16)1, "(Decimal).One"));
            NullableInt16Data.Add(new TestDataItem(decimal.Zero, (Int16)0, "(Decimal).Zero"));
            NullableInt16Data.Add(new TestDataItem(decimal.MinusOne, (short)-1, "(Decimal).MinusOne"));
            NullableInt16Data.Add(new TestDataItem(decimal.MinValue, Int16.MinValue, "(Decimal).MinValue"));
            NullableInt16Data.Add(new TestDataItem(decimal.MaxValue, Int16.MaxValue, "(Decimal).MaxValue"));
            NullableInt16Data.Add(new TestDataItem((decimal)123, (Int16)123));
            NullableInt16Data.Add(new TestDataItem((decimal)1234567890, Int16.MaxValue));
            NullableInt16Data.Add(new TestDataItem((decimal)123.4567890, (Int16)123));
            NullableInt16Data.Add(new TestDataItem((decimal)0.123456789, (Int16)0));
            NullableInt16Data.Add(new TestDataItem((decimal)-0.123456789, (Int16)0));
            NullableInt16Data.Add(new TestDataItem((decimal)-123.4567890, (short)-123));
            NullableInt16Data.Add(new TestDataItem((decimal)-1234567890, Int16.MinValue));
            NullableInt16Data.Add(new TestDataItem((decimal)-123, (short)-123));

            NullableInt16Data.Add(new TestDataItem(DateTime.MinValue, null, "(DateTime).MinValue"));
            NullableInt16Data.Add(new TestDataItem(DateTime.MaxValue, null, "(DateTime).MaxValue"));
            NullableInt16Data.Add(new TestDataItem(DateTime.Today, null, "(DateTime).Today"));
//            NullableInt16Data.Add(new TestDataItem(DateTime.UnixEpoch, null, "(DateTime).UnixEpoch"));
            var dt = new DateTime(2003, 1, 2, 4, 5, 6, 7, DateTimeKind.Utc);
            NullableInt16Data.Add(new TestDataItem(dt, null));

            NullableInt16Data.Add(new TestDataItem(DateTimeOffset.MinValue, null, "(DateTimeOffset).MinValue"));
            NullableInt16Data.Add(new TestDataItem(DateTimeOffset.MaxValue, null, "(DateTimeOffset).MaxValue"));
//            NullableInt16Data.Add(new TestDataItem(DateTimeOffset.UnixEpoch, null, "(DateTimeOffset).UnixEpoch"));
            NullableInt16Data.Add(new TestDataItem(new DateTimeOffset(dt, TimeSpan.Zero), null));


            foreach (var tuple in NullableInt16Data.ToList())
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
                            NullableInt16Data.Add(new TestDataItem(cUpper, (Int16)cUpper, desc));
                        desc = "(Char)" + tuple.Description?.Replace("(Char)", "").ToLower();
                        if (c != cLower)
                            NullableInt16Data.Add(new TestDataItem(cLower, (Int16)cLower, desc));
                        break;
                    case TypeCode.Byte:
                        c = Convert.ToChar(tuple.Value);
                        cUpper = (c.ToString().ToUpper()[0]);
                        cLower = (c.ToString().ToLower()[0]);
                        
                        desc = "(Byte)" + tuple.Description?.Replace("(Byte)", "").ToUpper();
                        if (!desc.Contains('.') && !NullableInt16Data.Exists(o=>o.TypeCode == TypeCode.Byte && (byte)o.Value == (byte)cUpper))
                            NullableInt16Data.Add(new TestDataItem((byte)cUpper, (Int16)cUpper, desc));
                        
                        desc = "(Byte)" + tuple.Description?.Replace("(Byte)", "").ToLower();
                        if (!desc.Contains('.') && !NullableInt16Data.Exists(o=>o.TypeCode == TypeCode.Byte && (byte)o.Value == (byte)cLower))
                            NullableInt16Data.Add(new TestDataItem((byte)cLower, (Int16)cLower, desc));
                        break;
                    case TypeCode.String:
                        string s = tuple.Value.ToString();
                        string sUpper = s.ToString().ToUpper();
                        string sLower = s.ToString().ToLower();
                        desc = "(String)" + tuple.Description?.Replace("(String)", "").ToUpper();
                        if (!desc.Contains('.') && !NullableInt16Data.Exists(o=>o.TypeCode == TypeCode.String && o.Value.ToString() == sUpper))
                            NullableInt16Data.Add(new TestDataItem(sUpper, tuple.ExpectedValue, desc));
                        desc = "(String)" + tuple.Description?.Replace("(String)", "").ToLower();
                        if (!desc.Contains('.') && !NullableInt16Data.Exists(o=>o.TypeCode == TypeCode.String && o.Value.ToString() == sLower))
                            NullableInt16Data.Add(new TestDataItem(sLower, tuple.ExpectedValue, desc));

                        break;
                }
            }

            foreach (var tuple in DataSourceValues.NullableInt16Data)
            {
                NullableInt16Dictionary[tuple.Key] = tuple.Value;
                
                if (NullableInt16DataRecord.GetOrdinal(tuple.Key) < 0)
                    ((DataRecordMock) NullableInt16DataRecord).Add(tuple.Key, tuple.Value);
                
                if (!NullableInt16KvpList.Exists(kvp=>kvp.Key == tuple.Key))
                    NullableInt16KvpList.Add(new KeyValuePair<string, object>(tuple.Key, tuple.Value));
            }

        }
        
        public static readonly Dictionary<string, object> NullableInt16Dictionary = new Dictionary<string, object>();
        public static readonly IDataRecord NullableInt16DataRecord = new DataRecordMock();
        public static readonly List<KeyValuePair<string, object>> NullableInt16KvpList = new List<KeyValuePair<string, object>>();

        public static List<TestDataItem> NullableInt16Data = new List<TestDataItem>
        {
            // Null
            new TestDataItem(null, null, "NULL"),
            new TestDataItem(DBNull.Value, null, "(DBNull).Value"),

            // Boolean values
            new TestDataItem(true, (Int16)1),
            new TestDataItem(false, (Int16)0),

            // Byte Values
            new TestDataItem((byte)1, (Int16)1),
            new TestDataItem((byte)0, (Int16)0),
            new TestDataItem((byte)8, (Int16)8),
            new TestDataItem((byte)9, (Int16)9),
            new TestDataItem((byte)'1', (Int16)'1', "(Byte)'1'"),
            new TestDataItem((byte)'0', (Int16)'0', "(Byte)'0'"),
            new TestDataItem((byte)'y', (Int16)'y', "(Byte)'y'"),
            new TestDataItem((byte)'n', (Int16)'n', "(Byte)'n'"),
            new TestDataItem((byte)'t', (Int16)'t', "(Byte)'t'"),
            new TestDataItem((byte)'f', (Int16)'f', "(Byte)'f'"),
            new TestDataItem(byte.MinValue, (Int16)byte.MinValue, "(Byte).MinValue"),
            new TestDataItem(byte.MaxValue, (Int16)byte.MaxValue, "(Byte).MaxValue"),

            // SByte Values
            new TestDataItem((sbyte)1, (Int16)1),
            new TestDataItem((sbyte)0, (Int16)0),
            new TestDataItem((sbyte)8, (Int16)8),
            new TestDataItem((sbyte)9, (Int16)9),
            new TestDataItem(sbyte.MinValue, (Int16)sbyte.MinValue, "(SByte).MinValue"),
            new TestDataItem(sbyte.MaxValue, (Int16)sbyte.MaxValue, "(SByte).MaxValue"),

            // Char Values
            new TestDataItem((char)1, (Int16)1, "(Char)1"),
            new TestDataItem((char)0, (Int16)0, "(Char)0"),
            new TestDataItem((char)8, (Int16)8, "(Char)8"),
            new TestDataItem((char)9, (Int16)9, "(Char)9 <'\\t'>"),
            new TestDataItem((char)'1', (Int16)'1', "(Char)'1'"),
            new TestDataItem((char)'0', (Int16)'0', "(Char)'0'"),
            new TestDataItem((char)'t', (Int16)'t', "(Char)'t'"),
            new TestDataItem((char)'y', (Int16)'y', "(Char)'y'"),
            new TestDataItem(char.MinValue, (short)char.MinValue, "(Char).MinValue"),
            new TestDataItem(char.MaxValue, (short)-1, "(Char).MaxValue"),
            
            // Double Values
            new TestDataItem((double)1, (Int16)1),
            new TestDataItem((double)0, (Int16)0),
            new TestDataItem((double)8, (Int16)8),
            new TestDataItem((double)9, (Int16)9),
            new TestDataItem((double)1.0, (Int16)1, "(Double)1.0"),
            new TestDataItem((double)1.5, (Int16)1),
            new TestDataItem((double)1.9999, (Int16)1),
            new TestDataItem((double)0.5, (Int16)0),
            new TestDataItem(double.Epsilon, (Int16)0, "(Double).Epsilon"),
            new TestDataItem(double.NaN, null, "(Double).NaN"),
            new TestDataItem(double.MinValue, Int16.MinValue, "(Double).MinValue"),
            new TestDataItem(double.MaxValue, Int16.MaxValue, "(Double).MaxValue"),
            new TestDataItem(double.NegativeInfinity, Int16.MinValue, "(Double).NegativeInfinity"),
            new TestDataItem(double.PositiveInfinity, Int16.MaxValue, "(Double).PositiveInfinity"),
            new TestDataItem((double)123, (Int16)123),
            new TestDataItem((double)1234567890, Int16.MaxValue),
            new TestDataItem((double)123.4567890, (Int16)123),
            new TestDataItem((double)0.123456789, (Int16)0),
            new TestDataItem((double)-0.123456789, (Int16)0),
            new TestDataItem((double)-123.4567890, ((short)-123)),
            new TestDataItem((double)-1234567890, Int16.MinValue),
            new TestDataItem((double)-123, (short)-123),

            // Single Values
            new TestDataItem((float)1, (Int16)1),
            new TestDataItem((float)0, (Int16)0),
            new TestDataItem((float)8, (Int16)8),
            new TestDataItem((float)9, (Int16)9),
            new TestDataItem((float)1.0, (Int16)1, "(Single)1.0"),
            new TestDataItem((float)1.5, (Int16)1),
            new TestDataItem((float)1.9999, (Int16)1),
            new TestDataItem((float)0.5, (Int16)0),
            new TestDataItem(float.Epsilon, (Int16)0, "(Single).Epsilon"),
            new TestDataItem(float.NaN, null, "(Single).NaN"),
            new TestDataItem(float.MinValue, Int16.MinValue, "(Single).MinValue"),
            new TestDataItem(float.MaxValue, Int16.MaxValue, "(Single).MaxValue"),
            new TestDataItem(float.NegativeInfinity, Int16.MinValue, "(Single).NegativeInfinity"),
            new TestDataItem(float.PositiveInfinity, Int16.MaxValue, "(Single).PositiveInfinity"),
            new TestDataItem((float)123, (Int16)123),
            new TestDataItem((float)1234567890, Int16.MaxValue, "(Single)1234567890"),
            new TestDataItem((float)123.4567890, (Int16)123),
            new TestDataItem((float)0.123456789, (Int16)0),
            new TestDataItem((float)-0.123456789, (Int16)0),
            new TestDataItem((float)-123.4567890, (short)-123),
            new TestDataItem((float)-1234567890, Int16.MinValue, "(Single)-1234567890"),
            new TestDataItem((float)-123, (short)-123),

            // Int16 Values
            new TestDataItem((short)1, (Int16)1),
            new TestDataItem((short)0, (Int16)0),
            new TestDataItem((short)8, (Int16)8),
            new TestDataItem((short)9, (Int16)9),
            new TestDataItem(short.MinValue, (Int16)short.MinValue, "(Int16).MinValue"),
            new TestDataItem(short.MaxValue, (Int16)short.MaxValue, "(Int16).MaxValue"),

            // UInt16 Values
            new TestDataItem((ushort)1, (Int16)1),
            new TestDataItem((ushort)0, (Int16)0),
            new TestDataItem((ushort)8, (Int16)8),
            new TestDataItem((ushort)9, (Int16)9),
            new TestDataItem(ushort.MinValue, (Int16)ushort.MinValue, "(UInt16).MinValue"),
            new TestDataItem(ushort.MaxValue, (Int16)short.MaxValue, "(UInt16).MaxValue"),

            // Int32 Values
            new TestDataItem((int)1, (Int16)1),
            new TestDataItem((int)0, (Int16)0),
            new TestDataItem((int)8, (Int16)8),
            new TestDataItem((int)9, (Int16)9),
            new TestDataItem(int.MinValue, (Int16)Int16.MinValue, "(Int32).MinValue"),
            new TestDataItem(int.MaxValue, (Int16)Int16.MaxValue, "(Int32).MaxValue"),

            // UInt32 Values
            new TestDataItem((uint)1, (Int16)1),
            new TestDataItem((uint)0, (Int16)0),
            new TestDataItem((uint)8, (Int16)8),
            new TestDataItem((uint)9, (Int16)9),
            new TestDataItem(uint.MinValue, (Int16)uint.MinValue, "(UInt32).MinValue"),
            new TestDataItem(uint.MaxValue, short.MaxValue, "(UInt32).MaxValue"),

            // Int64 Values
            new TestDataItem((long)1, (Int16)1),
            new TestDataItem((long)0, (Int16)0),
            new TestDataItem((long)8, (Int16)8),
            new TestDataItem((long)9, (Int16)9),
            new TestDataItem(long.MinValue, Int16.MinValue, "(Int64).MinValue"),
            new TestDataItem(long.MaxValue, Int16.MaxValue, "(Int64).MaxValue"),

            // UInt64 Values
            new TestDataItem((ulong)1, (Int16)1),
            new TestDataItem((ulong)0, (Int16)0),
            new TestDataItem((ulong)8, (Int16)8),
            new TestDataItem((ulong)9, (Int16)9),
            new TestDataItem(ulong.MinValue, (Int16)ulong.MinValue, "(UInt64).MinValue"),
            new TestDataItem(ulong.MaxValue, Int16.MaxValue, "(UInt64).MaxValue"),

            // Object Values
            new TestDataItem(new object(), null),

            // Strings
            new TestDataItem("", null, "(String)\"\"", "String_Empty"),
            new TestDataItem(" \t\r\n", null, "(String)\" \\t\\r\\n\"", "String_Whitespace"),
            new TestDataItem("1", (Int16)1),
            new TestDataItem("0", (Int16)0),
            new TestDataItem("8", (Int16)8),
            new TestDataItem("9", (Int16)9),
            new TestDataItem("y", null),
            new TestDataItem("n", null),
            new TestDataItem("t", null),
            new TestDataItem("f", null),
            new TestDataItem("Yes", null),
            new TestDataItem("No", null),
            new TestDataItem("True", null),
            new TestDataItem("False", null),
            new TestDataItem("123", (Int16)123),
            new TestDataItem("1234567890", Int16.MaxValue),
            new TestDataItem("0.123456789", (Int16)0),
            new TestDataItem("-0.123456789", (Int16)0),
            new TestDataItem("-123.4567890", (short)-123),
            new TestDataItem("-1234567890", Int16.MinValue),
            new TestDataItem("-123", (short)-123),
            new TestDataItem("123456789012345678901234567890", Int16.MaxValue),
            new TestDataItem("-123456789012345678901234567890", Int16.MinValue),
            new TestDataItem("123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890", Int16.MaxValue),
            new TestDataItem("-123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890", Int16.MinValue),
            new TestDataItem("9123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890.123456789012345678901234567890123456789012345678901234567890", Int16.MaxValue),
            new TestDataItem("-9123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890.123456789012345678901234567890123456789012345678901234567890", Int16.MinValue),
            new TestDataItem("one", null),
            new TestDataItem("0w", (Int16)0),
            new TestDataItem("1Y", (Int16)1),
            new TestDataItem("12K", (Int16)12),
            new TestDataItem("123Z", (Int16)123),
            new TestDataItem(".0", (Int16)0),
            new TestDataItem(".1", (Int16)0),
            new TestDataItem(".2", (Int16)0),
            new TestDataItem(".3", (Int16)0),
            new TestDataItem(".4", (Int16)0),
            new TestDataItem(".5", (Int16)0),
            new TestDataItem(".6", (Int16)0),
            new TestDataItem(".7", (Int16)0),
            new TestDataItem(".8", (Int16)0),
            new TestDataItem(".9", (Int16)0),
            new TestDataItem("-.0", (Int16)0),
            new TestDataItem("-.1", (Int16)0),
            new TestDataItem("-.2", (Int16)0),
            new TestDataItem("-.3", (Int16)0),
            new TestDataItem("-.4", (Int16)0),
            new TestDataItem("-.5", (Int16)0),
            new TestDataItem("-.6", (Int16)0),
            new TestDataItem("-.7", (Int16)0),
            new TestDataItem("-.8", (Int16)0),
            new TestDataItem("-.9", (Int16)0),
            new TestDataItem(".0255", (Int16)0),
            new TestDataItem(".1255", (Int16)0),
            new TestDataItem(".2255", (Int16)0),
            new TestDataItem(".3255", (Int16)0),
            new TestDataItem(".4255", (Int16)0),
            new TestDataItem(".5255", (Int16)0),
            new TestDataItem(".6255", (Int16)0),
            new TestDataItem(".7255", (Int16)0),
            new TestDataItem(".8255", (Int16)0),
            new TestDataItem(".9255", (Int16)0),
            new TestDataItem("-.0255", (Int16)0),
            new TestDataItem("-.1255", (Int16)0),
            new TestDataItem("-.2255", (Int16)0),
            new TestDataItem("-.3255", (Int16)0),
            new TestDataItem("-.4255", (Int16)0),
            new TestDataItem("-.5255", (Int16)0),
            new TestDataItem("-.6255", (Int16)0),
            new TestDataItem("-.7255", (Int16)0),
            new TestDataItem("-.8255", (Int16)0),
            new TestDataItem("-.9255", (Int16)0),
            new TestDataItem("-", null),
            new TestDataItem(".", null),
            new TestDataItem("-.", null),
        };
        
    }
}