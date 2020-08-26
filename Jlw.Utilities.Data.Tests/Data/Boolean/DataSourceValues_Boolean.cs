using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Jlw.Utilities.Data.DbUtility;

namespace Jlw.Utilities.Data.Tests
{
    public partial class DataSourceValues
    {
        private static void InitBoolean()
        {
            NullableBoolData.Add(new TestDataItem((decimal)1, true));
            NullableBoolData.Add(new TestDataItem((decimal)0, false));
            NullableBoolData.Add(new TestDataItem((decimal)8, false));
            NullableBoolData.Add(new TestDataItem((decimal)9, false));
            NullableBoolData.Add(new TestDataItem(decimal.One, true, "(Decimal).One"));
            NullableBoolData.Add(new TestDataItem(decimal.Zero, false, "(Decimal).Zero"));
            NullableBoolData.Add(new TestDataItem(decimal.MinusOne, false, "(Decimal).MinusOne"));
            NullableBoolData.Add(new TestDataItem(decimal.MinValue, false, "(Decimal).MinValue"));
            NullableBoolData.Add(new TestDataItem(decimal.MaxValue, false, "(Decimal).MaxValue"));
            NullableBoolData.Add(new TestDataItem((decimal)123, false));
            NullableBoolData.Add(new TestDataItem((decimal)1234567890, false));
            NullableBoolData.Add(new TestDataItem((decimal)123.4567890, false));
            NullableBoolData.Add(new TestDataItem((decimal)0.123456789, false));
            NullableBoolData.Add(new TestDataItem((decimal)-0.123456789, false));
            NullableBoolData.Add(new TestDataItem((decimal)-123.4567890, false));
            NullableBoolData.Add(new TestDataItem((decimal)-1234567890, false));
            NullableBoolData.Add(new TestDataItem((decimal)-123, false));

            NullableBoolData.Add(new TestDataItem(DateTime.MinValue, null, "(DateTime).MinValue"));
            NullableBoolData.Add(new TestDataItem(DateTime.MaxValue, null, "(DateTime).MaxValue"));
            NullableBoolData.Add(new TestDataItem(DateTime.Today, null, "(DateTime).Today"));
//            NullableBoolData.Add(new TestDataItem(DateTime.UnixEpoch, null, "(DateTime).UnixEpoch"));
            NullableBoolData.Add(new TestDataItem(new DateTime(2003, 1, 2, 4, 5, 6, 7, DateTimeKind.Utc), null));

            NullableBoolData.Add(new TestDataItem(DateTimeOffset.MinValue, null, "(DateTimeOffset).MinValue"));
            NullableBoolData.Add(new TestDataItem(DateTimeOffset.MaxValue, null, "(DateTimeOffset).MaxValue"));
//            NullableBoolData.Add(new TestDataItem(DateTimeOffset.UnixEpoch, null, "(DateTimeOffset).UnixEpoch"));
            NullableBoolData.Add(new TestDataItem(new DateTimeOffset(new DateTime(2003, 1, 2, 4, 5, 6, 7), TimeSpan.Zero), null));

            foreach (var tuple in NullableBoolData.ToList())
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
                            NullableBoolData.Add(new TestDataItem(cUpper, tuple.ExpectedValue, desc));
                        desc = "(Char)" + tuple.Description?.Replace("(Char)", "").ToLower();
                        if (c != cLower)
                            NullableBoolData.Add(new TestDataItem(cLower, tuple.ExpectedValue, desc));
                        break;
                    case TypeCode.Byte:
                        c = Convert.ToChar(tuple.Value);
                        cUpper = (c.ToString().ToUpper()[0]);
                        cLower = (c.ToString().ToLower()[0]);
                        
                        desc = "(Byte)" + tuple.Description?.Replace("(Byte)", "").ToUpper();
                        if (!desc.Contains('.') && !NullableBoolData.Exists(o=>o.TypeCode == TypeCode.Byte && (byte)o.Value == (byte)cUpper))
                            NullableBoolData.Add(new TestDataItem((byte)cUpper, tuple.ExpectedValue, desc));
                        
                        desc = "(Byte)" + tuple.Description?.Replace("(Byte)", "").ToLower();
                        if (!desc.Contains('.') && !NullableBoolData.Exists(o=>o.TypeCode == TypeCode.Byte && (byte)o.Value == (byte)cLower))
                            NullableBoolData.Add(new TestDataItem((byte)cLower, tuple.ExpectedValue, desc));
                        break;
                    case TypeCode.String:
                        string s = tuple.Value.ToString();
                        string sUpper = s.ToString().ToUpper();
                        string sLower = s.ToString().ToLower();
                        desc = "(String)" + tuple.Description?.Replace("(String)", "").ToUpper();
                        if (!desc.Contains('.') && !NullableBoolData.Exists(o=>o.TypeCode == TypeCode.String && o.Value.ToString() == sUpper))
                            NullableBoolData.Add(new TestDataItem(sUpper, tuple.ExpectedValue, desc));
                        desc = "(String)" + tuple.Description?.Replace("(String)", "").ToLower();
                        if (!desc.Contains('.') && !NullableBoolData.Exists(o=>o.TypeCode == TypeCode.String && o.Value.ToString() == sLower))
                            NullableBoolData.Add(new TestDataItem(sLower, tuple.ExpectedValue, desc));

                        break;
                }
            }

            foreach (var tuple in DataSourceValues.NullableBoolData)
            {
                NullableBooleanDictionary[tuple.Key] = tuple.Value;
                
                if (NullableBooleanDataRecord.GetOrdinal(tuple.Key) < 0)
                    ((DataRecordMock)NullableBooleanDataRecord).Add(tuple.Key, tuple.Value);

                if (!NullableBooleanKvpList.Exists(kvp=>kvp.Key == tuple.Key))
                    NullableBooleanKvpList.Add(new KeyValuePair<string, object>(tuple.Key, tuple.Value));
            }

        }

        public static readonly Dictionary<string, object> NullableBooleanDictionary = new Dictionary<string, object>();
        public static readonly IDataRecord NullableBooleanDataRecord = new DataRecordMock();
        public static readonly List<KeyValuePair<string, object>> NullableBooleanKvpList = new List<KeyValuePair<string, object>>();

        public static readonly List<TestDataItem> NullableBoolData = new List<TestDataItem>
        {
            // Null
            new TestDataItem(null, null, "NULL"),
            new TestDataItem(DBNull.Value, null, "(DBNull).Value"),

            // Boolean values
            new TestDataItem(true, true),
            new TestDataItem(false, false),

            // Byte Values
            new TestDataItem((byte)1, true),
            new TestDataItem((byte)0, false),
            new TestDataItem((byte)8, false),
            new TestDataItem((byte)9, false),
            new TestDataItem((byte)'1', true, "(Byte)'1'"),
            new TestDataItem((byte)'0', false, "(Byte)'0'"),
            new TestDataItem((byte)'y', true, "(Byte)'y'"),
            new TestDataItem((byte)'n', false, "(Byte)'n'"),
            new TestDataItem((byte)'t', true, "(Byte)'t'"),
            new TestDataItem((byte)'f', false, "(Byte)'f'"),
            new TestDataItem(byte.MinValue, false, "(Byte).MinValue"),
            new TestDataItem(byte.MaxValue, false, "(Byte).MaxValue"),

            // SByte Values
            new TestDataItem((sbyte)1, true),
            new TestDataItem((sbyte)0, false),
            new TestDataItem((sbyte)8, false),
            new TestDataItem((sbyte)9, false),
            new TestDataItem(sbyte.MinValue, false, "(SByte).MinValue"),
            new TestDataItem(sbyte.MaxValue, false, "(SByte).MaxValue"),

            // Char Values
            new TestDataItem((char)1, true, "(Char)1"),
            new TestDataItem((char)0, false, "(Char)0"),
            new TestDataItem((char)8, false, "(Char)8"),
            new TestDataItem((char)9, null, "(Char)9 <'\\t'>"),
            new TestDataItem((char)'1', true, "(Char)'1'"),
            new TestDataItem((char)'0', false, "(Char)'0'"),
            new TestDataItem((char)'t', true, "(Char)'t'"),
            new TestDataItem((char)'y', true, "(Char)'y'"),
            new TestDataItem(char.MinValue, false, "(Char).MinValue"),
            new TestDataItem(char.MaxValue, false, "(Char).MaxValue"),
            
            // Double Values
            new TestDataItem((double)1, true),
            new TestDataItem((double)0, false),
            new TestDataItem((double)8, false),
            new TestDataItem((double)9, false),
            new TestDataItem((double)1.0, true, "(Double)1.0"),
            new TestDataItem((double)1.5, false),
            new TestDataItem((double)1.9999, false),
            new TestDataItem((double)0.5, false),
            new TestDataItem(double.Epsilon, false, "(Double).Epsilon"),
            new TestDataItem(double.NaN, false, "(Double).NaN"),
            new TestDataItem(double.MinValue, false, "(Double).MinValue"),
            new TestDataItem(double.MaxValue, false, "(Double).MaxValue"),
            new TestDataItem(double.NegativeInfinity, false, "(Double).NegativeInfinity"),
            new TestDataItem(double.PositiveInfinity, false, "(Double).PositiveInfinity"),
            new TestDataItem((double)123, false),
            new TestDataItem((double)1234567890, false),
            new TestDataItem((double)123.4567890, false),
            new TestDataItem((double)0.123456789, false),
            new TestDataItem((double)-0.123456789, false),
            new TestDataItem((double)-123.4567890, false),
            new TestDataItem((double)-1234567890, false),
            new TestDataItem((double)-123, false),

            // Single Values
            new TestDataItem((float)1, true),
            new TestDataItem((float)0, false),
            new TestDataItem((float)8, false),
            new TestDataItem((float)9, false),
            new TestDataItem((float)1.0, true, "(Single)1.0"),
            new TestDataItem((float)1.5, false),
            new TestDataItem((float)1.9999, false),
            new TestDataItem((float)0.5, false),
            new TestDataItem(float.Epsilon, false, "(Single).Epsilon"),
            new TestDataItem(float.NaN, false, "(Single).NaN"),
            new TestDataItem(float.MinValue, false, "(Single).MinValue"),
            new TestDataItem(float.MaxValue, false, "(Single).MaxValue"),
            new TestDataItem(float.NegativeInfinity, false, "(Single).NegativeInfinity"),
            new TestDataItem(float.PositiveInfinity, false, "(Single).PositiveInfinity"),
            new TestDataItem((float)123, false),
            new TestDataItem((float)1234567890, false),
            new TestDataItem((float)123.4567890, false),
            new TestDataItem((float)0.123456789, false),
            new TestDataItem((float)-0.123456789, false),
            new TestDataItem((float)-123.4567890, false),
            new TestDataItem((float)-1234567890, false),
            new TestDataItem((float)-123, false),

            // Int16 Values
            new TestDataItem((short)1, true),
            new TestDataItem((short)0, false),
            new TestDataItem((short)8, false),
            new TestDataItem((short)9, false),
            new TestDataItem(short.MinValue, false, "(Int16).MinValue"),
            new TestDataItem(short.MaxValue, false, "(Int16).MaxValue"),

            // UInt16 Values
            new TestDataItem((ushort)1, true),
            new TestDataItem((ushort)0, false),
            new TestDataItem((ushort)8, false),
            new TestDataItem((ushort)9, false),
            new TestDataItem(ushort.MinValue, false, "(UInt16).MinValue"),
            new TestDataItem(ushort.MaxValue, false, "(UInt16).MaxValue"),

            // Int32 Values
            new TestDataItem((int)1, true),
            new TestDataItem((int)0, false),
            new TestDataItem((int)8, false),
            new TestDataItem((int)9, false),
            new TestDataItem(int.MinValue, false, "(Int32).MinValue"),
            new TestDataItem(int.MaxValue, false, "(Int32).MaxValue"),

            // UInt32 Values
            new TestDataItem((uint)1, true),
            new TestDataItem((uint)0, false),
            new TestDataItem((uint)8, false),
            new TestDataItem((uint)9, false),
            new TestDataItem(uint.MinValue, false, "(UInt32).MinValue"),
            new TestDataItem(uint.MaxValue, false, "(UInt32).MaxValue"),

            // Int64 Values
            new TestDataItem((long)1, true),
            new TestDataItem((long)0, false),
            new TestDataItem((long)8, false),
            new TestDataItem((long)9, false),
            new TestDataItem(long.MinValue, false, "(Int64).MinValue"),
            new TestDataItem(long.MaxValue, false, "(Int64).MaxValue"),

            // UInt64 Values
            new TestDataItem((ulong)1, true),
            new TestDataItem((ulong)0, false),
            new TestDataItem((ulong)8, false),
            new TestDataItem((ulong)9, false),
            new TestDataItem(ulong.MinValue, false, "(UInt64).MinValue"),
            new TestDataItem(ulong.MaxValue, false, "(UInt64).MaxValue"),

            // Object Values
            new TestDataItem(new object(), false),

            // Strings
            new TestDataItem("", null, "(String)\"\"", "String_Empty"),
            new TestDataItem(" \t\r\n", null, "(String)\" \\t\\r\\n\"", "String_Whitespace"),
            new TestDataItem("1", true),
            new TestDataItem("0", false),
            new TestDataItem("8", false),
            new TestDataItem("9", false),
            new TestDataItem("y", true),
            new TestDataItem("n", false),
            new TestDataItem("t", true),
            new TestDataItem("f", false),
            new TestDataItem("Yes", true),
            new TestDataItem("No", false),
            new TestDataItem("True", true),
            new TestDataItem("False", false),
            new TestDataItem("123", false),
            new TestDataItem("1234567890", false),
            new TestDataItem("0.123456789", false),
            new TestDataItem("-0.123456789", false),
            new TestDataItem("-123.4567890", false),
            new TestDataItem("-1234567890", false),
            new TestDataItem("-123", false),
            new TestDataItem("123456789012345678901234567890", false),
            new TestDataItem("-123456789012345678901234567890", false),
            new TestDataItem("123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890", false),
            new TestDataItem("-123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890", false),
            new TestDataItem("9123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890.123456789012345678901234567890123456789012345678901234567890", false),
            new TestDataItem("-9123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890.123456789012345678901234567890123456789012345678901234567890", false),
            new TestDataItem("one", false),
            new TestDataItem("0w", false),
            new TestDataItem("1Y", false),
            new TestDataItem("12K", false),
            new TestDataItem("123Z", false),
            new TestDataItem(".0", false),
            new TestDataItem(".1", false),
            new TestDataItem(".2", false),
            new TestDataItem(".3", false),
            new TestDataItem(".4", false),
            new TestDataItem(".5", false),
            new TestDataItem(".6", false),
            new TestDataItem(".7", false),
            new TestDataItem(".8", false),
            new TestDataItem(".9", false),
            new TestDataItem("-.0", false),
            new TestDataItem("-.1", false),
            new TestDataItem("-.2", false),
            new TestDataItem("-.3", false),
            new TestDataItem("-.4", false),
            new TestDataItem("-.5", false),
            new TestDataItem("-.6", false),
            new TestDataItem("-.7", false),
            new TestDataItem("-.8", false),
            new TestDataItem("-.9", false),
            new TestDataItem(".0255", false),
            new TestDataItem(".1255", false),
            new TestDataItem(".2255", false),
            new TestDataItem(".3255", false),
            new TestDataItem(".4255", false),
            new TestDataItem(".5255", false),
            new TestDataItem(".6255", false),
            new TestDataItem(".7255", false),
            new TestDataItem(".8255", false),
            new TestDataItem(".9255", false),
            new TestDataItem("-.0255", false),
            new TestDataItem("-.1255", false),
            new TestDataItem("-.2255", false),
            new TestDataItem("-.3255", false),
            new TestDataItem("-.4255", false),
            new TestDataItem("-.5255", false),
            new TestDataItem("-.6255", false),
            new TestDataItem("-.7255", false),
            new TestDataItem("-.8255", false),
            new TestDataItem("-.9255", false),
            new TestDataItem("-", false),
            new TestDataItem(".", false),
            new TestDataItem("-.", false),
        };
    }
}