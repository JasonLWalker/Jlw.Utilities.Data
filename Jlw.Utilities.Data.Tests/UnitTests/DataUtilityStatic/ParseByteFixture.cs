using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Jlw.Utilities.Data.Tests.UnitTests.DataUtilityStatic
{
    [TestClass]
    public class ParseByteFixture
    {
        [TestMethod]
        [ByteDataSource]
        public void ShouldMatchForObject(object value, object expectedValue, string displayName)
        {
            Assert.AreEqual(expectedValue, DataUtility.ParseByte(value));
        }

        [TestMethod]
        [DataRow("KeyDoesNotExist", (byte)default, null, DisplayName = "kvpList[\"KeyDoesNotExist\"] should be null")]
        [ByteKvpListDataSource]
        public void ShouldMatchForKvpList(string key, object expectedValue, string displayName)
        {
            Assert.AreEqual(expectedValue, DataUtility.ParseByte(DataSourceValues.NullableByteKvpList, key));
        }

        [TestMethod]
        [DataRow("KeyDoesNotExist", (byte)default, null, DisplayName = "dict[\"KeyDoesNotExist\"] should be null")]
        [ByteDictionaryDataSource]
        public void ShouldMatchForDictionary(string key, object expectedValue, string displayName)
        {
            Assert.AreEqual(expectedValue, DataUtility.ParseByte(DataSourceValues.NullableByteDictionary, key));
        }

        [TestMethod]
        [DataRow("KeyDoesNotExist", (byte)default, null, DisplayName = "data[\"KeyDoesNotExist\"] should be null")]
        [ByteIDataRecordDataSource]
        public void ShouldMatchForDataRecord(string key, object expectedValue, string displayName)
        {
            Assert.AreEqual(expectedValue, DataUtility.ParseByte(DataSourceValues.NullableByteDataRecord, key));
        }

    }
}
