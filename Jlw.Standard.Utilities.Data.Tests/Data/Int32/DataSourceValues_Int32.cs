using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Jlw.Standard.Utilities.Data.DbUtility;

namespace Jlw.Standard.Utilities.Data.Tests
{
    public partial class DataSourceValues
    {
        
        protected static void InitInt32()
        {
            NullableInt32Data.Add(new TestDataItem((decimal)1, (int)1));
            NullableInt32Data.Add(new TestDataItem((decimal)0, (int)0));
            NullableInt32Data.Add(new TestDataItem((decimal)8, (int)8));
            NullableInt32Data.Add(new TestDataItem((decimal)9, (int)9));
            NullableInt32Data.Add(new TestDataItem(decimal.One, (int)1, "(Decimal).One"));
            NullableInt32Data.Add(new TestDataItem(decimal.Zero, (int)0, "(Decimal).Zero"));
            NullableInt32Data.Add(new TestDataItem(decimal.MinusOne, (int)-1, "(Decimal).MinusOne"));
            NullableInt32Data.Add(new TestDataItem(decimal.MinValue, int.MinValue, "(Decimal).MinValue"));
            NullableInt32Data.Add(new TestDataItem(decimal.MaxValue, int.MaxValue, "(Decimal).MaxValue"));
            NullableInt32Data.Add(new TestDataItem((decimal)123, (int)123));
            NullableInt32Data.Add(new TestDataItem((decimal)1234567890, (int)1234567890));
            NullableInt32Data.Add(new TestDataItem((decimal)123.4567890, (int)123));
            NullableInt32Data.Add(new TestDataItem((decimal)0.123456789, (int)0));
            NullableInt32Data.Add(new TestDataItem((decimal)-0.123456789, (int)0));
            NullableInt32Data.Add(new TestDataItem((decimal)-123.4567890, (int)-123));
            NullableInt32Data.Add(new TestDataItem((decimal)-1234567890, (int)-1234567890));
            NullableInt32Data.Add(new TestDataItem((decimal)-123, (int)-123));

            NullableInt32Data.Add(new TestDataItem(DateTime.MinValue, null, "(DateTime).MinValue"));
            NullableInt32Data.Add(new TestDataItem(DateTime.MaxValue, null, "(DateTime).MaxValue"));
            NullableInt32Data.Add(new TestDataItem(DateTime.Today, null, "(DateTime).Today"));
            NullableInt32Data.Add(new TestDataItem(DateTime.UnixEpoch, null, "(DateTime).UnixEpoch"));
            NullableInt32Data.Add(new TestDataItem(new DateTime(2003, 1, 2, 4, 5, 6, 7, DateTimeKind.Utc), null));

            NullableInt32Data.Add(new TestDataItem(DateTimeOffset.MinValue, null, "(DateTimeOffset).MinValue"));
            NullableInt32Data.Add(new TestDataItem(DateTimeOffset.MaxValue, null, "(DateTimeOffset).MaxValue"));
            NullableInt32Data.Add(new TestDataItem(DateTimeOffset.UnixEpoch, null, "(DateTimeOffset).UnixEpoch"));
            NullableInt32Data.Add(new TestDataItem(new DateTimeOffset(new DateTime(2003, 1, 2, 4, 5, 6, 7), TimeSpan.Zero), null));


            foreach (var tuple in NullableInt32Data.ToList())
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
                            NullableInt32Data.Add(new TestDataItem(cUpper, (int)cUpper, desc));
                        desc = "(Char)" + tuple.Description?.Replace("(Char)", "").ToLower();
                        if (c != cLower)
                            NullableInt32Data.Add(new TestDataItem(cLower, (int)cLower, desc));
                        break;
                    case TypeCode.Byte:
                        c = Convert.ToChar(tuple.Value);
                        cUpper = (c.ToString().ToUpper()[0]);
                        cLower = (c.ToString().ToLower()[0]);
                        
                        desc = "(Byte)" + tuple.Description?.Replace("(Byte)", "").ToUpper();
                        if (!desc.Contains('.') && !NullableInt32Data.Exists(o=>o.TypeCode == TypeCode.Byte && (byte)o.Value == (byte)cUpper))
                            NullableInt32Data.Add(new TestDataItem((byte)cUpper, (int)cUpper, desc));
                        
                        desc = "(Byte)" + tuple.Description?.Replace("(Byte)", "").ToLower();
                        if (!desc.Contains('.') && !NullableInt32Data.Exists(o=>o.TypeCode == TypeCode.Byte && (byte)o.Value == (byte)cLower))
                            NullableInt32Data.Add(new TestDataItem((byte)cLower, (int)cLower, desc));
                        break;
                    case TypeCode.String:
                        string s = tuple.Value.ToString();
                        string sUpper = s.ToString().ToUpper();
                        string sLower = s.ToString().ToLower();
                        desc = "(String)" + tuple.Description?.Replace("(String)", "").ToUpper();
                        if (!desc.Contains('.') && !NullableInt32Data.Exists(o=>o.TypeCode == TypeCode.String && o.Value.ToString() == sUpper))
                            NullableInt32Data.Add(new TestDataItem(sUpper, tuple.ExpectedValue, desc));
                        desc = "(String)" + tuple.Description?.Replace("(String)", "").ToLower();
                        if (!desc.Contains('.') && !NullableInt32Data.Exists(o=>o.TypeCode == TypeCode.String && o.Value.ToString() == sLower))
                            NullableInt32Data.Add(new TestDataItem(sLower, tuple.ExpectedValue, desc));

                        break;
                }
            }

            foreach (var tuple in DataSourceValues.NullableInt32Data)
            {
                NullableInt32Dictionary[tuple.Key] = tuple.Value;
                
                if (NullableInt32DataRecord.GetOrdinal(tuple.Key) < 0)
                    ((DataRecordMock) NullableInt32DataRecord).Add(tuple.Key, tuple.Value);
                
                if (!NullableInt32KvpList.Exists(kvp=>kvp.Key == tuple.Key))
                    NullableInt32KvpList.Add(new KeyValuePair<string, object>(tuple.Key, tuple.Value));
            }

        }
        
        public static readonly Dictionary<string, object> NullableInt32Dictionary = new Dictionary<string, object>();
        public static readonly IDataRecord NullableInt32DataRecord = new DataRecordMock();
        public static readonly List<KeyValuePair<string, object>> NullableInt32KvpList = new List<KeyValuePair<string, object>>();

        public static List<TestDataItem> NullableInt32Data = new List<TestDataItem>
        {
            // Null
            new TestDataItem(null, null, "NULL"),
            new TestDataItem(DBNull.Value, null, "(DBNull).Value"),

            // Boolean values
            new TestDataItem(true, (int)1),
            new TestDataItem(false, (int)0),

            // Byte Values
            new TestDataItem((byte)1, (int)1),
            new TestDataItem((byte)0, (int)0),
            new TestDataItem((byte)8, (int)8),
            new TestDataItem((byte)9, (int)9),
            new TestDataItem((byte)'1', (int)'1', "(Byte)'1'"),
            new TestDataItem((byte)'0', (int)'0', "(Byte)'0'"),
            new TestDataItem((byte)'y', (int)'y', "(Byte)'y'"),
            new TestDataItem((byte)'n', (int)'n', "(Byte)'n'"),
            new TestDataItem((byte)'t', (int)'t', "(Byte)'t'"),
            new TestDataItem((byte)'f', (int)'f', "(Byte)'f'"),
            new TestDataItem(byte.MinValue, (int)byte.MinValue, "(Byte).MinValue"),
            new TestDataItem(byte.MaxValue, (int)byte.MaxValue, "(Byte).MaxValue"),

            // SByte Values
            new TestDataItem((sbyte)1, (int)1),
            new TestDataItem((sbyte)0, (int)0),
            new TestDataItem((sbyte)8, (int)8),
            new TestDataItem((sbyte)9, (int)9),
            new TestDataItem(sbyte.MinValue, (int)sbyte.MinValue, "(SByte).MinValue"),
            new TestDataItem(sbyte.MaxValue, (int)sbyte.MaxValue, "(SByte).MaxValue"),

            // Char Values
            new TestDataItem((char)1, (int)1, "(Char)1"),
            new TestDataItem((char)0, (int)0, "(Char)0"),
            new TestDataItem((char)8, (int)8, "(Char)8"),
            new TestDataItem((char)9, (int)9, "(Char)9 <'\\t'>"),
            new TestDataItem((char)'1', (int)'1', "(Char)'1'"),
            new TestDataItem((char)'0', (int)'0', "(Char)'0'"),
            new TestDataItem((char)'t', (int)'t', "(Char)'t'"),
            new TestDataItem((char)'y', (int)'y', "(Char)'y'"),
            new TestDataItem(char.MinValue, (int)char.MinValue, "(Char).MinValue"),
            new TestDataItem(char.MaxValue, (int)char.MaxValue, "(Char).MaxValue"),
            
            // Double Values
            new TestDataItem((double)1, (int)1),
            new TestDataItem((double)0, (int)0),
            new TestDataItem((double)8, (int)8),
            new TestDataItem((double)9, (int)9),
            new TestDataItem((double)1.0, (int)1, "(Double)1.0"),
            new TestDataItem((double)1.5, (int)1),
            new TestDataItem((double)1.9999, (int)1),
            new TestDataItem((double)0.5, (int)0),
            new TestDataItem(double.Epsilon, (int)0, "(Double).Epsilon"),
            new TestDataItem(double.NaN, null, "(Double).NaN"),
            new TestDataItem(double.MinValue, int.MinValue, "(Double).MinValue"),
            new TestDataItem(double.MaxValue, int.MaxValue, "(Double).MaxValue"),
            new TestDataItem(double.NegativeInfinity, int.MinValue, "(Double).NegativeInfinity"),
            new TestDataItem(double.PositiveInfinity, int.MaxValue, "(Double).PositiveInfinity"),
            new TestDataItem((double)123, (int)123),
            new TestDataItem((double)1234567890, (int)1234567890),
            new TestDataItem((double)123.4567890, (int)123),
            new TestDataItem((double)0.123456789, (int)0),
            new TestDataItem((double)-0.123456789, (int)0),
            new TestDataItem((double)-123.4567890, (int)-123),
            new TestDataItem((double)-1234567890, (int)-1234567890),
            new TestDataItem((double)-123, (int)-123),

            // Single Values
            new TestDataItem((float)1, (int)1),
            new TestDataItem((float)0, (int)0),
            new TestDataItem((float)8, (int)8),
            new TestDataItem((float)9, (int)9),
            new TestDataItem((float)1.0, (int)1, "(Single)1.0"),
            new TestDataItem((float)1.5, (int)1),
            new TestDataItem((float)1.9999, (int)1),
            new TestDataItem((float)0.5, (int)0),
            new TestDataItem(float.Epsilon, (int)0, "(Single).Epsilon"),
            new TestDataItem(float.NaN, null, "(Single).NaN"),
            new TestDataItem(float.MinValue, int.MinValue, "(Single).MinValue"),
            new TestDataItem(float.MaxValue, int.MaxValue, "(Single).MaxValue"),
            new TestDataItem(float.NegativeInfinity, int.MinValue, "(Single).NegativeInfinity"),
            new TestDataItem(float.PositiveInfinity, int.MaxValue, "(Single).PositiveInfinity"),
            new TestDataItem((float)123, (int)123),
            new TestDataItem((float)1234567890, (int)((float)1234567890), "(Single)1234567890"),
            new TestDataItem((float)123.4567890, (int)123),
            new TestDataItem((float)0.123456789, (int)0),
            new TestDataItem((float)-0.123456789, (int)0),
            new TestDataItem((float)-123.4567890, (int)-123),
            new TestDataItem((float)-1234567890, (int)((float)-1234567890), "(Single)-1234567890"),
            new TestDataItem((float)-123, (int)-123),

            // Int16 Values
            new TestDataItem((short)1, (int)1),
            new TestDataItem((short)0, (int)0),
            new TestDataItem((short)8, (int)8),
            new TestDataItem((short)9, (int)9),
            new TestDataItem(short.MinValue, (int)short.MinValue, "(Int16).MinValue"),
            new TestDataItem(short.MaxValue, (int)short.MaxValue, "(Int16).MaxValue"),

            // UInt16 Values
            new TestDataItem((ushort)1, (int)1),
            new TestDataItem((ushort)0, (int)0),
            new TestDataItem((ushort)8, (int)8),
            new TestDataItem((ushort)9, (int)9),
            new TestDataItem(ushort.MinValue, (int)ushort.MinValue, "(UInt16).MinValue"),
            new TestDataItem(ushort.MaxValue, (int)ushort.MaxValue, "(UInt16).MaxValue"),

            // Int32 Values
            new TestDataItem((int)1, (int)1),
            new TestDataItem((int)0, (int)0),
            new TestDataItem((int)8, (int)8),
            new TestDataItem((int)9, (int)9),
            new TestDataItem(int.MinValue, int.MinValue, "(Int32).MinValue"),
            new TestDataItem(int.MaxValue, int.MaxValue, "(Int32).MaxValue"),

            // UInt32 Values
            new TestDataItem((uint)1, (int)1),
            new TestDataItem((uint)0, (int)0),
            new TestDataItem((uint)8, (int)8),
            new TestDataItem((uint)9, (int)9),
            new TestDataItem(uint.MinValue, (int)uint.MinValue, "(UInt32).MinValue"),
            new TestDataItem(uint.MaxValue, (int)int.MaxValue, "(UInt32).MaxValue"),

            // Int64 Values
            new TestDataItem((long)1, (int)1),
            new TestDataItem((long)0, (int)0),
            new TestDataItem((long)8, (int)8),
            new TestDataItem((long)9, (int)9),
            new TestDataItem(long.MinValue, int.MinValue, "(Int64).MinValue"),
            new TestDataItem(long.MaxValue, int.MaxValue, "(Int64).MaxValue"),

            // UInt64 Values
            new TestDataItem((ulong)1, (int)1),
            new TestDataItem((ulong)0, (int)0),
            new TestDataItem((ulong)8, (int)8),
            new TestDataItem((ulong)9, (int)9),
            new TestDataItem(ulong.MinValue, (int)ulong.MinValue, "(UInt64).MinValue"),
            new TestDataItem(ulong.MaxValue, int.MaxValue, "(UInt64).MaxValue"),

            // Object Values
            new TestDataItem(new object(), null),

            // Strings
            new TestDataItem("", null, "(String)\"\"", "String_Empty"),
            new TestDataItem(" \t\r\n", null, "(String)\" \\t\\r\\n\"", "String_Whitespace"),
            new TestDataItem("1", (int)1),
            new TestDataItem("0", (int)0),
            new TestDataItem("8", (int)8),
            new TestDataItem("9", (int)9),
            new TestDataItem("y", null),
            new TestDataItem("n", null),
            new TestDataItem("t", null),
            new TestDataItem("f", null),
            new TestDataItem("Yes", null),
            new TestDataItem("No", null),
            new TestDataItem("True", null),
            new TestDataItem("False", null),
            new TestDataItem("123", (int)123),
            new TestDataItem("1234567890", (int)1234567890),
            new TestDataItem("0.123456789", (int)0),
            new TestDataItem("-0.123456789", (int)0),
            new TestDataItem("-123.4567890", (int)-123),
            new TestDataItem("-1234567890", (int)-1234567890),
            new TestDataItem("-123", (int)-123),
            new TestDataItem("123456789012345678901234567890", int.MaxValue),
            new TestDataItem("-123456789012345678901234567890", int.MinValue),
            new TestDataItem("123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890", int.MaxValue),
            new TestDataItem("-123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890", int.MinValue),
            new TestDataItem("9123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890.123456789012345678901234567890123456789012345678901234567890", int.MaxValue),
            new TestDataItem("-9123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890.123456789012345678901234567890123456789012345678901234567890", int.MinValue),
            new TestDataItem("one", null),
            new TestDataItem("0w", (int)0),
            new TestDataItem("1Y", (int)1),
            new TestDataItem("12K", (int)12),
            new TestDataItem("123Z", (int)123),
            new TestDataItem(".0", (int)0),
            new TestDataItem(".1", (int)0),
            new TestDataItem(".2", (int)0),
            new TestDataItem(".3", (int)0),
            new TestDataItem(".4", (int)0),
            new TestDataItem(".5", (int)0),
            new TestDataItem(".6", (int)0),
            new TestDataItem(".7", (int)0),
            new TestDataItem(".8", (int)0),
            new TestDataItem(".9", (int)0),
            new TestDataItem("-.0", (int)0),
            new TestDataItem("-.1", (int)0),
            new TestDataItem("-.2", (int)0),
            new TestDataItem("-.3", (int)0),
            new TestDataItem("-.4", (int)0),
            new TestDataItem("-.5", (int)0),
            new TestDataItem("-.6", (int)0),
            new TestDataItem("-.7", (int)0),
            new TestDataItem("-.8", (int)0),
            new TestDataItem("-.9", (int)0),
            new TestDataItem(".0255", (int)0),
            new TestDataItem(".1255", (int)0),
            new TestDataItem(".2255", (int)0),
            new TestDataItem(".3255", (int)0),
            new TestDataItem(".4255", (int)0),
            new TestDataItem(".5255", (int)0),
            new TestDataItem(".6255", (int)0),
            new TestDataItem(".7255", (int)0),
            new TestDataItem(".8255", (int)0),
            new TestDataItem(".9255", (int)0),
            new TestDataItem("-.0255", (int)0),
            new TestDataItem("-.1255", (int)0),
            new TestDataItem("-.2255", (int)0),
            new TestDataItem("-.3255", (int)0),
            new TestDataItem("-.4255", (int)0),
            new TestDataItem("-.5255", (int)0),
            new TestDataItem("-.6255", (int)0),
            new TestDataItem("-.7255", (int)0),
            new TestDataItem("-.8255", (int)0),
            new TestDataItem("-.9255", (int)0),
            new TestDataItem("-", null),
            new TestDataItem(".", null),
            new TestDataItem("-.", null),
        };
        
    }
}