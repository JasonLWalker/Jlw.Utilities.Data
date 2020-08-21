using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Jlw.Utilities.Data.DbUtility;

namespace Jlw.Utilities.Data.Tests
{
    public partial class DataSourceValues
    {
        protected static void Init()
        {
            NullableData.Add(new TestDataItem((decimal)1, null));
            NullableData.Add(new TestDataItem((decimal)0, null));
            NullableData.Add(new TestDataItem((decimal)8, null));
            NullableData.Add(new TestDataItem((decimal)9, null));
            NullableData.Add(new TestDataItem(decimal.One, null, "(Decimal).One"));
            NullableData.Add(new TestDataItem(decimal.Zero, null, "(Decimal).Zero"));
            NullableData.Add(new TestDataItem(decimal.MinusOne, null, "(Decimal).MinusOne"));
            NullableData.Add(new TestDataItem(decimal.MinValue, null, "(Decimal).MinValue"));
            NullableData.Add(new TestDataItem(decimal.MaxValue, null, "(Decimal).MaxValue"));
            NullableData.Add(new TestDataItem((decimal)123, null));
            NullableData.Add(new TestDataItem((decimal)1234567890, null));
            NullableData.Add(new TestDataItem((decimal)123.4567890, null));
            NullableData.Add(new TestDataItem((decimal)0.123456789, null));
            NullableData.Add(new TestDataItem((decimal)-0.123456789, null));
            NullableData.Add(new TestDataItem((decimal)-123.4567890, null));
            NullableData.Add(new TestDataItem((decimal)-1234567890, null));
            NullableData.Add(new TestDataItem((decimal)-123, null));

            NullableData.Add(new TestDataItem(DateTime.MinValue, null, "(DateTime).MinValue"));
            NullableData.Add(new TestDataItem(DateTime.MaxValue, null, "(DateTime).MaxValue"));
            NullableData.Add(new TestDataItem(DateTime.Today, null, "(DateTime).Today"));
            NullableData.Add(new TestDataItem(DateTime.UnixEpoch, null, "(DateTime).UnixEpoch"));
            NullableData.Add(new TestDataItem(new DateTime(2003, 1, 2, 4, 5, 6, 7, DateTimeKind.Utc), null));

            NullableData.Add(new TestDataItem(DateTimeOffset.MinValue, null, "(DateTimeOffset).MinValue"));
            NullableData.Add(new TestDataItem(DateTimeOffset.MaxValue, null, "(DateTimeOffset).MaxValue"));
            NullableData.Add(new TestDataItem(DateTimeOffset.UnixEpoch, null, "(DateTimeOffset).UnixEpoch"));
            NullableData.Add(new TestDataItem(new DateTimeOffset(new DateTime(2003, 1, 2, 4, 5, 6, 7), TimeSpan.Zero), null));

            foreach (var tuple in NullableData.ToList())
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
                            NullableData.Add(new TestDataItem(cUpper, tuple.ExpectedValue, desc));
                        desc = "(Char)" + tuple.Description?.Replace("(Char)", "").ToLower();
                        if (c != cLower)
                            NullableData.Add(new TestDataItem(cLower, tuple.ExpectedValue, desc));
                        break;
                    case TypeCode.Byte:
                        c = Convert.ToChar(tuple.Value);
                        cUpper = (c.ToString().ToUpper()[0]);
                        cLower = (c.ToString().ToLower()[0]);
                        
                        desc = "(Byte)" + tuple.Description?.Replace("(Byte)", "").ToUpper();
                        if (!desc.Contains('.') && !NullableData.Exists(o=>o.TypeCode == TypeCode.Byte && (byte)o.Value == (byte)cUpper))
                            NullableData.Add(new TestDataItem((byte)cUpper, tuple.ExpectedValue, desc));
                        
                        desc = "(Byte)" + tuple.Description?.Replace("(Byte)", "").ToLower();
                        if (!desc.Contains('.') && !NullableData.Exists(o=>o.TypeCode == TypeCode.Byte && (byte)o.Value == (byte)cLower))
                            NullableData.Add(new TestDataItem((byte)cLower, tuple.ExpectedValue, desc));
                        break;
                    case TypeCode.String:
                        string s = tuple.Value.ToString();
                        string sUpper = s.ToString().ToUpper();
                        string sLower = s.ToString().ToLower();
                        desc = "(String)" + tuple.Description?.Replace("(String)", "").ToUpper();
                        if (!desc.Contains('.') && !NullableData.Exists(o=>o.TypeCode == TypeCode.String && o.Value.ToString() == sUpper))
                            NullableData.Add(new TestDataItem(sUpper, tuple.ExpectedValue, desc));
                        desc = "(String)" + tuple.Description?.Replace("(String)", "").ToLower();
                        if (!desc.Contains('.') && !NullableData.Exists(o=>o.TypeCode == TypeCode.String && o.Value.ToString() == sLower))
                            NullableData.Add(new TestDataItem(sLower, tuple.ExpectedValue, desc));
                        break;
                }
            }

            foreach (var tuple in DataSourceValues.NullableBoolData)
            {
                NullableDictionary[tuple.Key] = tuple.Value;
                ((DataRecordMock)NullableDataRecord).Add(tuple.Key, tuple.Value);
                NullableKvpList.Add(new KeyValuePair<string, object>(tuple.Key, tuple.Value));
            }

        }

        public static readonly Dictionary<string, object> NullableDictionary = new Dictionary<string, object>();
        public static readonly IDataRecord NullableDataRecord = new DataRecordMock();
        public static readonly List<KeyValuePair<string, object>> NullableKvpList = new List<KeyValuePair<string, object>>();

        public static List<TestDataItem> NullableData = new List<TestDataItem>
        {
            // Null
            new TestDataItem(null, null, "NULL"),
            new TestDataItem(DBNull.Value, null, "(DBNull).Value"),

            // Boolean values
            new TestDataItem(true, null),
            new TestDataItem(false, null),

            // Byte Values
            new TestDataItem((byte)1, null),
            new TestDataItem((byte)0, null),
            new TestDataItem((byte)8, null),
            new TestDataItem((byte)9, null),
            new TestDataItem((byte)'1', null, "(Byte)'1'"),
            new TestDataItem((byte)'0', null, "(Byte)'0'"),
            new TestDataItem((byte)'y', null, "(Byte)'y'"),
            new TestDataItem((byte)'n', null, "(Byte)'n'"),
            new TestDataItem((byte)'t', null, "(Byte)'t'"),
            new TestDataItem((byte)'f', null, "(Byte)'f'"),
            new TestDataItem(byte.MinValue, null, "(Byte).MinValue"),
            new TestDataItem(byte.MaxValue, null, "(Byte).MaxValue"),

            // SByte Values
            new TestDataItem((sbyte)1, null),
            new TestDataItem((sbyte)0, null),
            new TestDataItem((sbyte)8, null),
            new TestDataItem((sbyte)9, null),
            new TestDataItem(sbyte.MinValue, null, "(SByte).MinValue"),
            new TestDataItem(sbyte.MaxValue, null, "(SByte).MaxValue"),

            // Char Values
            new TestDataItem((char)1, null, "(Char)1"),
            new TestDataItem((char)0, null, "(Char)0"),
            new TestDataItem((char)8, null, "(Char)8"),
            new TestDataItem((char)9, null, "(Char)9 <'\\t'>"),
            new TestDataItem((char)'1', null, "(Char)'1'"),
            new TestDataItem((char)'0', null, "(Char)'0'"),
            new TestDataItem((char)'t', null, "(Char)'t'"),
            new TestDataItem((char)'y', null, "(Char)'y'"),
            new TestDataItem(char.MinValue, null, "(Char).MinValue"),
            new TestDataItem(char.MaxValue, null, "(Char).MaxValue"),
            
            // Double Values
            new TestDataItem((double)1, null),
            new TestDataItem((double)0, null),
            new TestDataItem((double)8, null),
            new TestDataItem((double)9, null),
            new TestDataItem((double)1.0, null, "(Double)1.0"),
            new TestDataItem((double)1.5, null),
            new TestDataItem((double)1.9999, null),
            new TestDataItem((double)0.5, null),
            new TestDataItem(double.Epsilon, null, "(Double).Epsilon"),
            new TestDataItem(double.NaN, null, "(Double).NaN"),
            new TestDataItem(double.MinValue, null, "(Double).MinValue"),
            new TestDataItem(double.MaxValue, null, "(Double).MaxValue"),
            new TestDataItem(double.NegativeInfinity, null, "(Double).NegativeInfinity"),
            new TestDataItem(double.PositiveInfinity, null, "(Double).PositiveInfinity"),
            new TestDataItem((double)123, null),
            new TestDataItem((double)1234567890, null),
            new TestDataItem((double)123.4567890, null),
            new TestDataItem((double)0.123456789, null),
            new TestDataItem((double)-0.123456789, null),
            new TestDataItem((double)-123.4567890, null),
            new TestDataItem((double)-123, null),

            // Single Values
            new TestDataItem((float)1, null),
            new TestDataItem((float)0, null),
            new TestDataItem((float)8, null),
            new TestDataItem((float)9, null),
            new TestDataItem((float)1.0, null, "(Single)1.0"),
            new TestDataItem((float)1.5, null),
            new TestDataItem((float)1.9999, null),
            new TestDataItem((float)0.5, null),
            new TestDataItem(float.Epsilon, null, "(Single).Epsilon"),
            new TestDataItem(float.NaN, null, "(Single).NaN"),
            new TestDataItem(float.MinValue, null, "(Single).MinValue"),
            new TestDataItem(float.MaxValue, null, "(Single).MaxValue"),
            new TestDataItem(float.NegativeInfinity, null, "(Single).NegativeInfinity"),
            new TestDataItem(float.PositiveInfinity, null, "(Single).PositiveInfinity"),
            new TestDataItem((float)123, null),
            new TestDataItem((float)1234567890, null),
            new TestDataItem((float)123.4567890, null),
            new TestDataItem((float)0.123456789, null),
            new TestDataItem((float)-0.123456789, null),
            new TestDataItem((float)-123.4567890, null),
            new TestDataItem((float)-123, null),

            // Int16 Values
            new TestDataItem((short)1, null),
            new TestDataItem((short)0, null),
            new TestDataItem((short)8, null),
            new TestDataItem((short)9, null),
            new TestDataItem(short.MinValue, null, "(Int16).MinValue"),
            new TestDataItem(short.MaxValue, null, "(Int16).MaxValue"),

            // UInt16 Values
            new TestDataItem((ushort)1, null),
            new TestDataItem((ushort)0, null),
            new TestDataItem((ushort)8, null),
            new TestDataItem((ushort)9, null),
            new TestDataItem(ushort.MinValue, null, "(UInt16).MinValue"),
            new TestDataItem(ushort.MaxValue, null, "(UInt16).MaxValue"),

            // Int32 Values
            new TestDataItem((int)1, null),
            new TestDataItem((int)0, null),
            new TestDataItem((int)8, null),
            new TestDataItem((int)9, null),
            new TestDataItem(int.MinValue, null, "(Int32).MinValue"),
            new TestDataItem(int.MaxValue, null, "(Int32).MaxValue"),

            // UInt32 Values
            new TestDataItem((uint)1, null),
            new TestDataItem((uint)0, null),
            new TestDataItem((uint)8, null),
            new TestDataItem((uint)9, null),
            new TestDataItem(uint.MinValue, null, "(UInt32).MinValue"),
            new TestDataItem(uint.MaxValue, null, "(UInt32).MaxValue"),

            // Int64 Values
            new TestDataItem((long)1, null),
            new TestDataItem((long)0, null),
            new TestDataItem((uint)8, null),
            new TestDataItem((uint)9, null),
            new TestDataItem(long.MinValue, null, "(Int64).MinValue"),
            new TestDataItem(long.MaxValue, null, "(Int64).MaxValue"),

            // UInt64 Values
            new TestDataItem((ulong)1, null),
            new TestDataItem((ulong)0, null),
            new TestDataItem((ulong)8, null),
            new TestDataItem((ulong)9, null),
            new TestDataItem(ulong.MinValue, null, "(UInt64).MinValue"),
            new TestDataItem(ulong.MaxValue, null, "(UInt64).MaxValue"),

            // Object Values
            new TestDataItem(new object(), null),

            // Strings
            new TestDataItem("", null, "(String)\"\"", "String_Empty"),
            new TestDataItem(" \t\r\n", null, "(String)\" \\t\\r\\n\"", "String_Whitespace"),
            new TestDataItem("1", null),
            new TestDataItem("0", null),
            new TestDataItem("8", null),
            new TestDataItem("9", null),
            new TestDataItem("y", null),
            new TestDataItem("n", null),
            new TestDataItem("t", null),
            new TestDataItem("f", null),
            new TestDataItem("Yes", null),
            new TestDataItem("No", null),
            new TestDataItem("True", null),
            new TestDataItem("False", null),
            new TestDataItem("123", null),
            new TestDataItem("1234567890", null),
            new TestDataItem("0.123456789", null),
            new TestDataItem("-0.123456789", null),
            new TestDataItem("-123.4567890", null),
            new TestDataItem("-1234567890", null),
            new TestDataItem("-123", null),
            new TestDataItem("123456789012345678901234567890", null),
            new TestDataItem("-123456789012345678901234567890", null),
            new TestDataItem("123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890", null),
            new TestDataItem("-123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890", null),
            new TestDataItem("9123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890.123456789012345678901234567890123456789012345678901234567890", null),
            new TestDataItem("-9123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890.123456789012345678901234567890123456789012345678901234567890", null),
            new TestDataItem("one", null),
            new TestDataItem("0w", null),
            new TestDataItem("1Y", null),
            new TestDataItem("12K", null),
            new TestDataItem("123Z", null),
            new TestDataItem(".0", null),
            new TestDataItem(".1", null),
            new TestDataItem(".2", null),
            new TestDataItem(".3", null),
            new TestDataItem(".4", null),
            new TestDataItem(".5", null),
            new TestDataItem(".6", null),
            new TestDataItem(".7", null),
            new TestDataItem(".8", null),
            new TestDataItem(".9", null),
            new TestDataItem("-.0", null),
            new TestDataItem("-.1", null),
            new TestDataItem("-.2", null),
            new TestDataItem("-.3", null),
            new TestDataItem("-.4", null),
            new TestDataItem("-.5", null),
            new TestDataItem("-.6", null),
            new TestDataItem("-.7", null),
            new TestDataItem("-.8", null),
            new TestDataItem("-.9", null),
            new TestDataItem(".0255", null),
            new TestDataItem(".1255", null),
            new TestDataItem(".2255", null),
            new TestDataItem(".3255", null),
            new TestDataItem(".4255", null),
            new TestDataItem(".5255", null),
            new TestDataItem(".6255", null),
            new TestDataItem(".7255", null),
            new TestDataItem(".8255", null),
            new TestDataItem(".9255", null),
            new TestDataItem("-.0255", null),
            new TestDataItem("-.1255", null),
            new TestDataItem("-.2255", null),
            new TestDataItem("-.3255", null),
            new TestDataItem("-.4255", null),
            new TestDataItem("-.5255", null),
            new TestDataItem("-.6255", null),
            new TestDataItem("-.7255", null),
            new TestDataItem("-.8255", null),
            new TestDataItem("-.9255", null),
            new TestDataItem("-", null),
            new TestDataItem(".", null),
            new TestDataItem("-.", null),

        };

    }
}