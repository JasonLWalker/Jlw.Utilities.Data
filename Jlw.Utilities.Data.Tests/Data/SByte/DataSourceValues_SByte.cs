using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Jlw.Utilities.Data.DbUtility;

namespace Jlw.Utilities.Data.Tests
{
    public partial class DataSourceValues
    {
        
        protected static void InitSByte()
        {
            NullableSByteData.Add(new TestDataItem((decimal)1, (sbyte)1));
            NullableSByteData.Add(new TestDataItem((decimal)0, (sbyte)0));
            NullableSByteData.Add(new TestDataItem((decimal)8, (sbyte)8));
            NullableSByteData.Add(new TestDataItem((decimal)9, (sbyte)9));
            NullableSByteData.Add(new TestDataItem(decimal.One, (sbyte)1, "(Decimal).One"));
            NullableSByteData.Add(new TestDataItem(decimal.Zero, (sbyte)0, "(Decimal).Zero"));
            NullableSByteData.Add(new TestDataItem(decimal.MinusOne, (sbyte)-1, "(Decimal).MinusOne"));
            NullableSByteData.Add(new TestDataItem(decimal.MinValue, sbyte.MinValue, "(Decimal).MinValue"));
            NullableSByteData.Add(new TestDataItem(decimal.MaxValue, sbyte.MaxValue, "(Decimal).MaxValue"));
            NullableSByteData.Add(new TestDataItem((decimal)123, (sbyte)123));
            NullableSByteData.Add(new TestDataItem((decimal)1234567890, sbyte.MaxValue));
            NullableSByteData.Add(new TestDataItem((decimal)123.4567890, (sbyte)123));
            NullableSByteData.Add(new TestDataItem((decimal)0.123456789, (sbyte)0));
            NullableSByteData.Add(new TestDataItem((decimal)-0.123456789, (sbyte)0));
            NullableSByteData.Add(new TestDataItem((decimal)-123.4567890, (sbyte)-123));
            NullableSByteData.Add(new TestDataItem((decimal)-1234567890, sbyte.MinValue));
            NullableSByteData.Add(new TestDataItem((decimal)-123, (sbyte)-123));

            NullableSByteData.Add(new TestDataItem(DateTime.MinValue, null, "(DateTime).MinValue"));
            NullableSByteData.Add(new TestDataItem(DateTime.MaxValue, null, "(DateTime).MaxValue"));
            NullableSByteData.Add(new TestDataItem(DateTime.Today, null, "(DateTime).Today"));
//            NullableSByteData.Add(new TestDataItem(DateTime.UnixEpoch, null, "(DateTime).UnixEpoch"));
            NullableSByteData.Add(new TestDataItem(new DateTime(2003, 1, 2, 4, 5, 6, 7, DateTimeKind.Utc), null));

            NullableSByteData.Add(new TestDataItem(DateTimeOffset.MinValue, null, "(DateTimeOffset).MinValue"));
            NullableSByteData.Add(new TestDataItem(DateTimeOffset.MaxValue, null, "(DateTimeOffset).MaxValue"));
//            NullableSByteData.Add(new TestDataItem(DateTimeOffset.UnixEpoch, null, "(DateTimeOffset).UnixEpoch"));
            NullableSByteData.Add(new TestDataItem(new DateTimeOffset(new DateTime(2003, 1, 2, 4, 5, 6, 7), TimeSpan.Zero), null));


            foreach (var tuple in NullableSByteData.ToList())
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
                            NullableSByteData.Add(new TestDataItem(cUpper, (sbyte)cUpper, desc));
                        desc = "(Char)" + tuple.Description?.Replace("(Char)", "").ToLower();
                        if (c != cLower)
                            NullableSByteData.Add(new TestDataItem(cLower, (sbyte)cLower, desc));
                        break;
                    case TypeCode.Byte:
                        c = Convert.ToChar(tuple.Value);
                        cUpper = (c.ToString().ToUpper()[0]);
                        cLower = (c.ToString().ToLower()[0]);
                        
                        desc = "(Byte)" + tuple.Description?.Replace("(Byte)", "").ToUpper();
                        if (!desc.Contains('.') && !NullableSByteData.Exists(o=>o.TypeCode == TypeCode.Byte && (byte)o.Value == (byte)cUpper))
                            NullableSByteData.Add(new TestDataItem((byte)cUpper, (sbyte)cUpper, desc));
                        
                        desc = "(Byte)" + tuple.Description?.Replace("(Byte)", "").ToLower();
                        if (!desc.Contains('.') && !NullableSByteData.Exists(o=>o.TypeCode == TypeCode.Byte && (byte)o.Value == (byte)cLower))
                            NullableSByteData.Add(new TestDataItem((byte)cLower, (sbyte)cLower, desc));
                        break;
                    case TypeCode.String:
                        string s = tuple.Value.ToString();
                        string sUpper = s.ToString().ToUpper();
                        string sLower = s.ToString().ToLower();
                        desc = "(String)" + tuple.Description?.Replace("(String)", "").ToUpper();
                        if (!desc.Contains('.') && !NullableSByteData.Exists(o=>o.TypeCode == TypeCode.String && o.Value.ToString() == sUpper))
                            NullableSByteData.Add(new TestDataItem(sUpper, tuple.ExpectedValue, desc));
                        desc = "(String)" + tuple.Description?.Replace("(String)", "").ToLower();
                        if (!desc.Contains('.') && !NullableSByteData.Exists(o=>o.TypeCode == TypeCode.String && o.Value.ToString() == sLower))
                            NullableSByteData.Add(new TestDataItem(sLower, tuple.ExpectedValue, desc));

                        break;
                }
            }

            foreach (var tuple in DataSourceValues.NullableSByteData)
            {
                NullableSByteDictionary[tuple.Key] = tuple.Value;
                
                if (NullableSByteDataRecord.GetOrdinal(tuple.Key) < 0)
                    ((DataRecordMock) NullableSByteDataRecord).Add(tuple.Key, tuple.Value);
                
                if (!NullableSByteKvpList.Exists(kvp=>kvp.Key == tuple.Key))
                    NullableSByteKvpList.Add(new KeyValuePair<string, object>(tuple.Key, tuple.Value));
            }

        }
        
        public static readonly Dictionary<string, object> NullableSByteDictionary = new Dictionary<string, object>();
        public static readonly IDataRecord NullableSByteDataRecord = new DataRecordMock();
        public static readonly List<KeyValuePair<string, object>> NullableSByteKvpList = new List<KeyValuePair<string, object>>();

        public static List<TestDataItem> NullableSByteData = new List<TestDataItem>
        {
            // Null
            new TestDataItem(null, null, "NULL"),
            new TestDataItem(DBNull.Value, null, "(DBNull).Value"),

            // Boolean values
            new TestDataItem(true, (sbyte)1),
            new TestDataItem(false, (sbyte)0),

            // Byte Values
            new TestDataItem((byte)1, (sbyte)1),
            new TestDataItem((byte)0, (sbyte)0),
            new TestDataItem((byte)8, (sbyte)8),
            new TestDataItem((byte)9, (sbyte)9),
            new TestDataItem((byte)'1', (sbyte)'1', "(Byte)'1'"),
            new TestDataItem((byte)'0', (sbyte)'0', "(Byte)'0'"),
            new TestDataItem((byte)'y', (sbyte)'y', "(Byte)'y'"),
            new TestDataItem((byte)'n', (sbyte)'n', "(Byte)'n'"),
            new TestDataItem((byte)'t', (sbyte)'t', "(Byte)'t'"),
            new TestDataItem((byte)'f', (sbyte)'f', "(Byte)'f'"),
            new TestDataItem(byte.MinValue, (sbyte)0, "(Byte).MinValue"),
            new TestDataItem(byte.MaxValue, sbyte.MaxValue, "(Byte).MaxValue"),

            // SByte Values
            new TestDataItem((sbyte)1, (sbyte)1),
            new TestDataItem((sbyte)0, (sbyte)0),
            new TestDataItem((sbyte)8, (sbyte)8),
            new TestDataItem((sbyte)9, (sbyte)9),
            new TestDataItem(sbyte.MinValue, sbyte.MinValue, "(SByte).MinValue"),
            new TestDataItem(sbyte.MaxValue, sbyte.MaxValue, "(SByte).MaxValue"),

            // Char Values
            new TestDataItem((char)1, (sbyte)1, "(Char)1"),
            new TestDataItem((char)0, (sbyte)0, "(Char)0"),
            new TestDataItem((char)8, (sbyte)8, "(Char)8"),
            new TestDataItem((char)9, (sbyte)9, "(Char)9 <'\\t'>"),
            new TestDataItem((char)'1', (sbyte)'1', "(Char)'1'"),
            new TestDataItem((char)'0', (sbyte)'0', "(Char)'0'"),
            new TestDataItem((char)'t', (sbyte)'t', "(Char)'t'"),
            new TestDataItem((char)'y', (sbyte)'y', "(Char)'y'"),
            new TestDataItem(char.MinValue, (sbyte)0, "(Char).MinValue"),
            new TestDataItem(char.MaxValue, sbyte.MaxValue, "(Char).MaxValue"),
            
            // Double Values
            new TestDataItem((double)1, (sbyte)1),
            new TestDataItem((double)0, (sbyte)0),
            new TestDataItem((double)8, (sbyte)8),
            new TestDataItem((double)9, (sbyte)9),
            new TestDataItem((double)1.0, (sbyte)1, "(Double)1.0"),
            new TestDataItem((double)1.5, (sbyte)1),
            new TestDataItem((double)1.9999, (sbyte)1),
            new TestDataItem((double)0.5, (sbyte)0),
            new TestDataItem(double.Epsilon, (sbyte)0, "(Double).Epsilon"),
            new TestDataItem(double.NaN, null, "(Double).NaN"),
            new TestDataItem(double.MinValue, sbyte.MinValue, "(Double).MinValue"),
            new TestDataItem(double.MaxValue, sbyte.MaxValue, "(Double).MaxValue"),
            new TestDataItem(double.NegativeInfinity, sbyte.MinValue, "(Double).NegativeInfinity"),
            new TestDataItem(double.PositiveInfinity, sbyte.MaxValue, "(Double).PositiveInfinity"),
            new TestDataItem((double)123, (sbyte)123),
            new TestDataItem((double)1234567890, sbyte.MaxValue),
            new TestDataItem((double)123.4567890, (sbyte)123),
            new TestDataItem((double)0.123456789, (sbyte)0),
            new TestDataItem((double)-0.123456789, (sbyte)0),
            new TestDataItem((double)-123.4567890, (sbyte)-123),
            new TestDataItem((double)-1234567890, sbyte.MinValue),
            new TestDataItem((double)-123, (sbyte)-123),

            // Single Values
            new TestDataItem((float)1, (sbyte)1),
            new TestDataItem((float)0, (sbyte)0),
            new TestDataItem((float)8, (sbyte)8),
            new TestDataItem((float)9, (sbyte)9),
            new TestDataItem((float)1.0, (sbyte)1, "(Single)1.0"),
            new TestDataItem((float)1.5, (sbyte)1),
            new TestDataItem((float)1.9999, (sbyte)1),
            new TestDataItem((float)0.5, (sbyte)0),
            new TestDataItem(float.Epsilon, (sbyte)0, "(Single).Epsilon"),
            new TestDataItem(float.NaN, null, "(Single).NaN"),
            new TestDataItem(float.MinValue, sbyte.MinValue, "(Single).MinValue"),
            new TestDataItem(float.MaxValue, sbyte.MaxValue, "(Single).MaxValue"),
            new TestDataItem(float.NegativeInfinity, sbyte.MinValue, "(Single).NegativeInfinity"),
            new TestDataItem(float.PositiveInfinity, sbyte.MaxValue, "(Single).PositiveInfinity"),
            new TestDataItem((float)123, (sbyte)123),
            new TestDataItem((float)1234567890, sbyte.MaxValue),
            new TestDataItem((float)123.4567890, (sbyte)123),
            new TestDataItem((float)0.123456789, (sbyte)0),
            new TestDataItem((float)-0.123456789, (sbyte)0),
            new TestDataItem((float)-123.4567890, (sbyte)-123),
            new TestDataItem((float)-1234567890, sbyte.MinValue),
            new TestDataItem((float)-123, (sbyte)-123),

            // Int16 Values
            new TestDataItem((short)1, (sbyte)1),
            new TestDataItem((short)0, (sbyte)0),
            new TestDataItem((short)8, (sbyte)8),
            new TestDataItem((short)9, (sbyte)9),
            new TestDataItem(short.MinValue, sbyte.MinValue, "(Int16).MinValue"),
            new TestDataItem(short.MaxValue, sbyte.MaxValue, "(Int16).MaxValue"),

            // UInt16 Values
            new TestDataItem((ushort)1, (sbyte)1),
            new TestDataItem((ushort)0, (sbyte)0),
            new TestDataItem((ushort)8, (sbyte)8),
            new TestDataItem((ushort)9, (sbyte)9),
            new TestDataItem(ushort.MinValue, (sbyte)0, "(UInt16).MinValue"),
            new TestDataItem(ushort.MaxValue, sbyte.MaxValue, "(UInt16).MaxValue"),

            // Int32 Values
            new TestDataItem((int)1, (sbyte)1),
            new TestDataItem((int)0, (sbyte)0),
            new TestDataItem((int)8, (sbyte)8),
            new TestDataItem((int)9, (sbyte)9),
            new TestDataItem(int.MinValue, sbyte.MinValue, "(Int32).MinValue"),
            new TestDataItem(int.MaxValue, sbyte.MaxValue, "(Int32).MaxValue"),

            // UInt32 Values
            new TestDataItem((uint)1, (sbyte)1),
            new TestDataItem((uint)0, (sbyte)0),
            new TestDataItem((uint)8, (sbyte)8),
            new TestDataItem((uint)9, (sbyte)9),
            new TestDataItem(uint.MinValue, (sbyte)0, "(UInt32).MinValue"),
            new TestDataItem(uint.MaxValue, sbyte.MaxValue, "(UInt32).MaxValue"),

            // Int64 Values
            new TestDataItem((long)1, (sbyte)1),
            new TestDataItem((long)0, (sbyte)0),
            new TestDataItem((long)8, (sbyte)8),
            new TestDataItem((long)9, (sbyte)9),
            new TestDataItem(long.MinValue, sbyte.MinValue, "(Int64).MinValue"),
            new TestDataItem(long.MaxValue, sbyte.MaxValue, "(Int64).MaxValue"),

            // UInt64 Values
            new TestDataItem((ulong)1, (sbyte)1),
            new TestDataItem((ulong)0, (sbyte)0),
            new TestDataItem((ulong)8, (sbyte)8),
            new TestDataItem((ulong)9, (sbyte)9),
            new TestDataItem(ulong.MinValue, (sbyte)0, "(UInt64).MinValue"),
            new TestDataItem(ulong.MaxValue, sbyte.MaxValue, "(UInt64).MaxValue"),

            // Object Values
            new TestDataItem(new object(), null),

            // Strings
            new TestDataItem("", null, "(String)\"\"", "String_Empty"),
            new TestDataItem(" \t\r\n", null, "(String)\" \\t\\r\\n\"", "String_Whitespace"),
            new TestDataItem("1", (sbyte)1),
            new TestDataItem("0", (sbyte)0),
            new TestDataItem("8", (sbyte)8),
            new TestDataItem("9", (sbyte)9),
            new TestDataItem("y", null),
            new TestDataItem("n", null),
            new TestDataItem("t", null),
            new TestDataItem("f", null),
            new TestDataItem("Yes", null),
            new TestDataItem("No", null),
            new TestDataItem("True", null),
            new TestDataItem("False", null),
            new TestDataItem("123", (sbyte)123),
            new TestDataItem("1234567890", sbyte.MaxValue),
            new TestDataItem("0.123456789", (sbyte)0),
            new TestDataItem("-0.123456789", (sbyte)0),
            new TestDataItem("-123.4567890", (sbyte)-123),
            new TestDataItem("-1234567890", sbyte.MinValue),
            new TestDataItem("-123", (sbyte)-123),
            new TestDataItem("123456789012345678901234567890", sbyte.MaxValue),
            new TestDataItem("-123456789012345678901234567890", sbyte.MinValue),
            new TestDataItem("123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890", sbyte.MaxValue),
            new TestDataItem("-123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890", sbyte.MinValue),
            new TestDataItem("9123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890.123456789012345678901234567890123456789012345678901234567890", sbyte.MaxValue),
            new TestDataItem("-9123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890.123456789012345678901234567890123456789012345678901234567890", sbyte.MinValue),
            new TestDataItem("one", null),
            new TestDataItem("0w", (sbyte)0),
            new TestDataItem("1Y", (sbyte)1),
            new TestDataItem("12K", (sbyte)12),
            new TestDataItem("123Z", (sbyte)123),
            new TestDataItem(".0", (sbyte)0),
            new TestDataItem(".1", (sbyte)0),
            new TestDataItem(".2", (sbyte)0),
            new TestDataItem(".3", (sbyte)0),
            new TestDataItem(".4", (sbyte)0),
            new TestDataItem(".5", (sbyte)0),
            new TestDataItem(".6", (sbyte)0),
            new TestDataItem(".7", (sbyte)0),
            new TestDataItem(".8", (sbyte)0),
            new TestDataItem(".9", (sbyte)0),
            new TestDataItem("-.0", (sbyte)0),
            new TestDataItem("-.1", (sbyte)0),
            new TestDataItem("-.2", (sbyte)0),
            new TestDataItem("-.3", (sbyte)0),
            new TestDataItem("-.4", (sbyte)0),
            new TestDataItem("-.5", (sbyte)0),
            new TestDataItem("-.6", (sbyte)0),
            new TestDataItem("-.7", (sbyte)0),
            new TestDataItem("-.8", (sbyte)0),
            new TestDataItem("-.9", (sbyte)0),
            new TestDataItem(".0255", (sbyte)0),
            new TestDataItem(".1255", (sbyte)0),
            new TestDataItem(".2255", (sbyte)0),
            new TestDataItem(".3255", (sbyte)0),
            new TestDataItem(".4255", (sbyte)0),
            new TestDataItem(".5255", (sbyte)0),
            new TestDataItem(".6255", (sbyte)0),
            new TestDataItem(".7255", (sbyte)0),
            new TestDataItem(".8255", (sbyte)0),
            new TestDataItem(".9255", (sbyte)0),
            new TestDataItem("-.0255", (sbyte)0),
            new TestDataItem("-.1255", (sbyte)0),
            new TestDataItem("-.2255", (sbyte)0),
            new TestDataItem("-.3255", (sbyte)0),
            new TestDataItem("-.4255", (sbyte)0),
            new TestDataItem("-.5255", (sbyte)0),
            new TestDataItem("-.6255", (sbyte)0),
            new TestDataItem("-.7255", (sbyte)0),
            new TestDataItem("-.8255", (sbyte)0),
            new TestDataItem("-.9255", (sbyte)0),
            new TestDataItem("-", null),
            new TestDataItem(".", null),
            new TestDataItem("-.", null),
        };
        
    }
}