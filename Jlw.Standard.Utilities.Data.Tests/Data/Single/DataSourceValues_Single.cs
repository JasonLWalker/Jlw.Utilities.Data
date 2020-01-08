using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Jlw.Standard.Utilities.Data.DbUtility;

namespace Jlw.Standard.Utilities.Data.Tests
{
    public partial class DataSourceValues
    {
        
        protected static void InitSingle()
        {
            NullableSingleData.Add(new TestDataItem((decimal)1, (Single)1));
            NullableSingleData.Add(new TestDataItem((decimal)0, (Single)0));
            NullableSingleData.Add(new TestDataItem((decimal)8, (Single)8));
            NullableSingleData.Add(new TestDataItem((decimal)9, (Single)9));
            NullableSingleData.Add(new TestDataItem(decimal.One, (Single)1, "(Decimal).One"));
            NullableSingleData.Add(new TestDataItem(decimal.Zero, (Single)0, "(Decimal).Zero"));
            NullableSingleData.Add(new TestDataItem(decimal.MinusOne, -1.0f, "(Decimal).MinusOne"));
            NullableSingleData.Add(new TestDataItem(decimal.MinValue, (Single)Decimal.MinValue, "(Decimal).MinValue"));
            NullableSingleData.Add(new TestDataItem(decimal.MaxValue, (Single)Decimal.MaxValue, "(Decimal).MaxValue"));
            NullableSingleData.Add(new TestDataItem((decimal)123, (Single)123));
            NullableSingleData.Add(new TestDataItem((decimal)1234567890, (Single)1234567890));
            NullableSingleData.Add(new TestDataItem((decimal)123.4567890, (Single)123.4567890));
            NullableSingleData.Add(new TestDataItem((decimal)0.123456789, (Single)0.123456789));
            NullableSingleData.Add(new TestDataItem((decimal)-0.123456789, -0.123456789f));
            NullableSingleData.Add(new TestDataItem((decimal)-123.4567890, -123.4567890f));
            NullableSingleData.Add(new TestDataItem((decimal)-1234567890, -1234567890f));
            NullableSingleData.Add(new TestDataItem((decimal)-123, -123.0f));

            NullableSingleData.Add(new TestDataItem(DateTime.MinValue, null, "(DateTime).MinValue"));
            NullableSingleData.Add(new TestDataItem(DateTime.MaxValue, null, "(DateTime).MaxValue"));
            NullableSingleData.Add(new TestDataItem(DateTime.Today, null, "(DateTime).Today"));
            NullableSingleData.Add(new TestDataItem(DateTime.UnixEpoch, null, "(DateTime).UnixEpoch"));
            var dt = new DateTime(2003, 1, 2, 4, 5, 6, 7, DateTimeKind.Utc);
            NullableSingleData.Add(new TestDataItem(dt, null));

            NullableSingleData.Add(new TestDataItem(DateTimeOffset.MinValue, null, "(DateTimeOffset).MinValue"));
            NullableSingleData.Add(new TestDataItem(DateTimeOffset.MaxValue, null, "(DateTimeOffset).MaxValue"));
            NullableSingleData.Add(new TestDataItem(DateTimeOffset.UnixEpoch, null, "(DateTimeOffset).UnixEpoch"));
            NullableSingleData.Add(new TestDataItem(new DateTimeOffset(dt, TimeSpan.Zero), null));


            foreach (var tuple in NullableSingleData.ToList())
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
                            NullableSingleData.Add(new TestDataItem(cUpper, (Single)cUpper, desc));
                        desc = "(Char)" + tuple.Description?.Replace("(Char)", "").ToLower();
                        if (c != cLower)
                            NullableSingleData.Add(new TestDataItem(cLower, (Single)cLower, desc));
                        break;
                    case TypeCode.Byte:
                        c = Convert.ToChar(tuple.Value);
                        cUpper = (c.ToString().ToUpper()[0]);
                        cLower = (c.ToString().ToLower()[0]);
                        
                        desc = "(Byte)" + tuple.Description?.Replace("(Byte)", "").ToUpper();
                        if (!desc.Contains('.') && !NullableSingleData.Exists(o=>o.TypeCode == TypeCode.Byte && (byte)o.Value == (byte)cUpper))
                            NullableSingleData.Add(new TestDataItem((byte)cUpper, (Single)cUpper, desc));
                        
                        desc = "(Byte)" + tuple.Description?.Replace("(Byte)", "").ToLower();
                        if (!desc.Contains('.') && !NullableSingleData.Exists(o=>o.TypeCode == TypeCode.Byte && (byte)o.Value == (byte)cLower))
                            NullableSingleData.Add(new TestDataItem((byte)cLower, (Single)cLower, desc));
                        break;
                    case TypeCode.String:
                        string s = tuple.Value.ToString();
                        string sUpper = s.ToString().ToUpper();
                        string sLower = s.ToString().ToLower();
                        desc = "(String)" + tuple.Description?.Replace("(String)", "").ToUpper();
                        if (!desc.Contains('.') && !NullableSingleData.Exists(o=>o.TypeCode == TypeCode.String && o.Value.ToString() == sUpper))
                            NullableSingleData.Add(new TestDataItem(sUpper, tuple.ExpectedValue, desc));
                        desc = "(String)" + tuple.Description?.Replace("(String)", "").ToLower();
                        if (!desc.Contains('.') && !NullableSingleData.Exists(o=>o.TypeCode == TypeCode.String && o.Value.ToString() == sLower))
                            NullableSingleData.Add(new TestDataItem(sLower, tuple.ExpectedValue, desc));

                        break;
                }
            }

            foreach (var tuple in Jlw.Standard.Utilities.Data.Tests.DataSourceValues.NullableSingleData)
            {
                NullableSingleDictionary[tuple.Key] = tuple.Value;
                
                if (NullableSingleDataRecord.GetOrdinal(tuple.Key) < 0)
                    ((DataRecordMock) NullableSingleDataRecord).Add(tuple.Key, tuple.Value);
                
                if (!NullableSingleKvpList.Exists(kvp=>kvp.Key == tuple.Key))
                    NullableSingleKvpList.Add(new KeyValuePair<string, object>(tuple.Key, tuple.Value));
            }

        }
        
        public static readonly Dictionary<string, object> NullableSingleDictionary = new Dictionary<string, object>();
        public static readonly IDataRecord NullableSingleDataRecord = new DataRecordMock();
        public static readonly List<KeyValuePair<string, object>> NullableSingleKvpList = new List<KeyValuePair<string, object>>();

        public static List<TestDataItem> NullableSingleData = new List<TestDataItem>
        {
            // Null
            new TestDataItem(null, null, "NULL"),
            new TestDataItem(DBNull.Value, null, "(DBNull).Value"),

            // Boolean values
            new TestDataItem(true, (Single)1),
            new TestDataItem(false, (Single)0),

            // Byte Values
            new TestDataItem((byte)1, (Single)1),
            new TestDataItem((byte)0, (Single)0),
            new TestDataItem((byte)8, (Single)8),
            new TestDataItem((byte)9, (Single)9),
            new TestDataItem((byte)'1', (Single)'1', "(Byte)'1'"),
            new TestDataItem((byte)'0', (Single)'0', "(Byte)'0'"),
            new TestDataItem((byte)'y', (Single)'y', "(Byte)'y'"),
            new TestDataItem((byte)'n', (Single)'n', "(Byte)'n'"),
            new TestDataItem((byte)'t', (Single)'t', "(Byte)'t'"),
            new TestDataItem((byte)'f', (Single)'f', "(Byte)'f'"),
            new TestDataItem(byte.MinValue, (Single)byte.MinValue, "(Byte).MinValue"),
            new TestDataItem(byte.MaxValue, (Single)byte.MaxValue, "(Byte).MaxValue"),

            // SByte Values
            new TestDataItem((sbyte)1, (Single)1),
            new TestDataItem((sbyte)0, (Single)0),
            new TestDataItem((sbyte)8, (Single)8),
            new TestDataItem((sbyte)9, (Single)9),
            new TestDataItem(sbyte.MinValue, (Single)sbyte.MinValue, "(SByte).MinValue"),
            new TestDataItem(sbyte.MaxValue, (Single)sbyte.MaxValue, "(SByte).MaxValue"),

            // Char Values
            new TestDataItem((char)1, (Single)1, "(Char)1"),
            new TestDataItem((char)0, (Single)0, "(Char)0"),
            new TestDataItem((char)8, (Single)8, "(Char)8"),
            new TestDataItem((char)9, (Single)9, "(Char)9 <'\\t'>"),
            new TestDataItem((char)'1', (Single)'1', "(Char)'1'"),
            new TestDataItem((char)'0', (Single)'0', "(Char)'0'"),
            new TestDataItem((char)'t', (Single)'t', "(Char)'t'"),
            new TestDataItem((char)'y', (Single)'y', "(Char)'y'"),
            new TestDataItem(char.MinValue, (Single)char.MinValue, "(Char).MinValue"),
            new TestDataItem(char.MaxValue, (Single)char.MaxValue, "(Char).MaxValue"),
            
            // Double Values
            new TestDataItem((double)1, (Single)1),
            new TestDataItem((double)0, (Single)0),
            new TestDataItem((double)8, (Single)8),
            new TestDataItem((double)9, (Single)9),
            new TestDataItem((double)1.0, (Single)1, "(Double)1.0"),
            new TestDataItem((double)1.5, (Single)1.5),
            new TestDataItem((double)1.9999, (Single)1.9999),
            new TestDataItem((double)0.5, (Single)0.5),
            new TestDataItem(double.Epsilon, (Single)double.Epsilon, "(Double).Epsilon"),
            new TestDataItem(double.NaN, Single.NaN, "(Double).NaN"),
            new TestDataItem(float.MinValue - 1.0f, Single.MinValue, "(Single).MinValue - 1.0"),
            new TestDataItem(float.MaxValue + 1.0f, Single.MaxValue, "(Single).MaxValue + 1.0"),
            new TestDataItem(double.MinValue, Single.NegativeInfinity, "(Double).MinValue"),
            new TestDataItem(double.MaxValue, Single.PositiveInfinity, "(Double).MaxValue"),
            new TestDataItem(double.NegativeInfinity, Single.NegativeInfinity, "(Double).NegativeInfinity"),
            new TestDataItem(double.PositiveInfinity, Single.PositiveInfinity, "(Double).PositiveInfinity"),
            new TestDataItem((double)123, (Single)123),
            new TestDataItem((double)1234567890, (Single)1234567890),
            new TestDataItem((double)123.4567890, (Single)123.4567890),
            new TestDataItem((double)0.123456789, (Single)0.123456789),
            new TestDataItem((double)-0.123456789, -0.123456789f),
            new TestDataItem((double)-123.4567890, (-123.4567890f)),
            new TestDataItem((double)-1234567890, -1234567890f),
            new TestDataItem((double)-123, -123.0f),

            // Single Values
            new TestDataItem((float)1, (Single)1),
            new TestDataItem((float)0, (Single)0),
            new TestDataItem((float)8, (Single)8),
            new TestDataItem((float)9, (Single)9),
            new TestDataItem((float)1.0, (Single)1, "(Single)1.0"),
            new TestDataItem((float)1.5, (Single)1.5),
            new TestDataItem((float)1.9999, (Single)(float)1.9999),
            new TestDataItem((float)0.5, (Single)0.5),
            new TestDataItem(float.Epsilon, (Single)float.Epsilon, "(Single).Epsilon"),
            new TestDataItem(float.NaN, Single.NaN, "(Single).NaN"),
            new TestDataItem(float.MinValue, (Single)float.MinValue, "(Single).MinValue"),
            new TestDataItem(float.MaxValue, (Single)float.MaxValue, "(Single).MaxValue"),
            new TestDataItem(float.NegativeInfinity, Single.NegativeInfinity, "(Single).NegativeInfinity"),
            new TestDataItem(float.PositiveInfinity, Single.PositiveInfinity, "(Single).PositiveInfinity"),
            new TestDataItem((float)123, (Single)123),
            new TestDataItem((float)1234567890, (Single)(float)1234567890, "(Single)1234567890"),
            new TestDataItem((float)123.4567890, (Single)(float)123.4567890),
            new TestDataItem((float)0.123456789, (Single)(float)0.123456789),
            new TestDataItem((float)-0.123456789, (Single)(float)-0.123456789),
            new TestDataItem((float)-123.4567890, (Single)(float)-123.4567890),
            new TestDataItem((float)-1234567890, (Single)(float)-1234567890, "(Single)-1234567890"),
            new TestDataItem((float)-123, -123.0f),

            // Int16 Values
            new TestDataItem((short)1, (Single)1),
            new TestDataItem((short)0, (Single)0),
            new TestDataItem((short)8, (Single)8),
            new TestDataItem((short)9, (Single)9),
            new TestDataItem(short.MinValue, (Single)short.MinValue, "(Int16).MinValue"),
            new TestDataItem(short.MaxValue, (Single)short.MaxValue, "(Int16).MaxValue"),

            // UInt16 Values
            new TestDataItem((ushort)1, (Single)1),
            new TestDataItem((ushort)0, (Single)0),
            new TestDataItem((ushort)8, (Single)8),
            new TestDataItem((ushort)9, (Single)9),
            new TestDataItem(ushort.MinValue, (Single)ushort.MinValue, "(UInt16).MinValue"),
            new TestDataItem(ushort.MaxValue, (Single)ushort.MaxValue, "(UInt16).MaxValue"),

            // Int32 Values
            new TestDataItem((int)1, (Single)1),
            new TestDataItem((int)0, (Single)0),
            new TestDataItem((int)8, (Single)8),
            new TestDataItem((int)9, (Single)9),
            new TestDataItem(int.MinValue, (Single)int.MinValue, "(Int32).MinValue"),
            new TestDataItem(int.MaxValue, (Single)int.MaxValue, "(Int32).MaxValue"),

            // UInt32 Values
            new TestDataItem((uint)1, (Single)1),
            new TestDataItem((uint)0, (Single)0),
            new TestDataItem((uint)8, (Single)8),
            new TestDataItem((uint)9, (Single)9),
            new TestDataItem(uint.MinValue, (Single)uint.MinValue, "(UInt32).MinValue"),
            new TestDataItem(uint.MaxValue, (Single)uint.MaxValue, "(UInt32).MaxValue"),

            // Int64 Values
            new TestDataItem((long)1, (Single)1),
            new TestDataItem((long)0, (Single)0),
            new TestDataItem((long)8, (Single)8),
            new TestDataItem((long)9, (Single)9),
            new TestDataItem(long.MinValue, (Single)long.MinValue, "(Int64).MinValue"),
            new TestDataItem(long.MaxValue, (Single)long.MaxValue, "(Int64).MaxValue"),

            // UInt64 Values
            new TestDataItem((ulong)1, (Single)1),
            new TestDataItem((ulong)0, (Single)0),
            new TestDataItem((ulong)8, (Single)8),
            new TestDataItem((ulong)9, (Single)9),
            new TestDataItem(ulong.MinValue, (Single)ulong.MinValue, "(UInt64).MinValue"),
            new TestDataItem(ulong.MaxValue, (Single)ulong.MaxValue, "(UInt64).MaxValue"),

            // Object Values
            new TestDataItem(new object(), null),

            // Strings
            new TestDataItem("", null, "(String)\"\"", "String_Empty"),
            new TestDataItem(" \t\r\n", null, "(String)\" \\t\\r\\n\"", "String_Whitespace"),
            new TestDataItem("1", (Single)1),
            new TestDataItem("0", (Single)0),
            new TestDataItem("8", (Single)8),
            new TestDataItem("9", (Single)9),
            new TestDataItem("y", null),
            new TestDataItem("n", null),
            new TestDataItem("t", null),
            new TestDataItem("f", null),
            new TestDataItem("Yes", null),
            new TestDataItem("No", null),
            new TestDataItem("True", null),
            new TestDataItem("False", null),
            new TestDataItem("123", (Single)123),
            new TestDataItem("1234567890", (Single)1234567890),
            new TestDataItem("0.123456789", (Single)0.123456789),
            new TestDataItem("-0.123456789", -0.123456789f),
            new TestDataItem("-123.4567890", -123.4567890f),
            new TestDataItem("-1234567890", -1234567890f),
            new TestDataItem("-123", -123.0f),
            new TestDataItem("123456789012345678901234567890", 123456789012345678901234567890f),
            new TestDataItem("-123456789012345678901234567890", -123456789012345678901234567890f),
            new TestDataItem("123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890", Single.MaxValue),
            new TestDataItem("-123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890", Single.MinValue),
            new TestDataItem("9123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890.123456789012345678901234567890123456789012345678901234567890", Single.MaxValue),
            new TestDataItem("-9123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890.123456789012345678901234567890123456789012345678901234567890", Single.MinValue),
            new TestDataItem("one", null),
            new TestDataItem("0w", (Single)0),
            new TestDataItem("1Y", (Single)1),
            new TestDataItem("12K", (Single)12),
            new TestDataItem("123Z", (Single)123),
            new TestDataItem(".0", (Single)0),
            new TestDataItem(".1", (Single)0.1),
            new TestDataItem(".2", (Single)0.2),
            new TestDataItem(".3", (Single)0.3),
            new TestDataItem(".4", (Single)0.4),
            new TestDataItem(".5", (Single)0.5),
            new TestDataItem(".6", (Single)0.6),
            new TestDataItem(".7", (Single)0.7),
            new TestDataItem(".8", (Single)0.8),
            new TestDataItem(".9", (Single)0.9),
            new TestDataItem("-.0", (Single)0),
            new TestDataItem("-.1", -0.1f),
            new TestDataItem("-.2", -0.2f),
            new TestDataItem("-.3", -0.3f),
            new TestDataItem("-.4", -0.4f),
            new TestDataItem("-.5", -0.5f),
            new TestDataItem("-.6", -0.6f),
            new TestDataItem("-.7", -0.7f),
            new TestDataItem("-.8", -0.8f),
            new TestDataItem("-.9", -0.9f),
            new TestDataItem(".0255", (Single)0.0255),
            new TestDataItem(".1255", (Single)0.1255),
            new TestDataItem(".2255", (Single)0.2255),
            new TestDataItem(".3255", (Single)0.3255),
            new TestDataItem(".4255", (Single)0.4255),
            new TestDataItem(".5255", (Single)0.5255),
            new TestDataItem(".6255", (Single)0.6255),
            new TestDataItem(".7255", (Single)0.7255),
            new TestDataItem(".8255", (Single)0.8255),
            new TestDataItem(".9255", (Single)0.9255),
            new TestDataItem("-.0255", -0.0255f),
            new TestDataItem("-.1255", -0.1255f),
            new TestDataItem("-.2255", -0.2255f),
            new TestDataItem("-.3255", -0.3255f),
            new TestDataItem("-.4255", -0.4255f),
            new TestDataItem("-.5255", -0.5255f),
            new TestDataItem("-.6255", -0.6255f),
            new TestDataItem("-.7255", -0.7255f),
            new TestDataItem("-.8255", -0.8255f),
            new TestDataItem("-.9255", -0.9255f),
            new TestDataItem("-", null),
            new TestDataItem(".", null),
            new TestDataItem("-.", null),
        };
        
    }
}