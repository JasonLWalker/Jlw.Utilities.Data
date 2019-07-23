using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Jlw.Standard.Utilities.Data.Tests.UnitTests
{
    [TestClass]
    public class ParseNullableInt32Fixture
    {
        [TestMethod]
        [NullableInt32DataSource]
        public void ShouldMatchForObject(object value, object expectedValue, string displayName)
        {
            Assert.AreEqual(expectedValue, DataUtility.ParseNullableInt32(value));
            Assert.AreEqual(expectedValue, DataUtility.ParseNullableInt(value));
        }

        [TestMethod]
        [DataRow("KeyDoesNotExist", null, null, DisplayName = "kvpList[\"KeyDoesNotExist\"] should be null")]
        [NullableInt32KvpListDataSource]
        public void ShouldMatchForKvpList(string key, object expectedValue, string displayName)
        {
            Assert.AreEqual(expectedValue, DataUtility.ParseNullableInt32(DataSourceValues.NullableInt32KvpList, key));
            Assert.AreEqual(expectedValue, DataUtility.ParseNullableInt(DataSourceValues.NullableInt32KvpList, key));
        }

        [TestMethod]
        [DataRow("KeyDoesNotExist", null, null, DisplayName = "dict[\"KeyDoesNotExist\"] should be null")]
        [NullableInt32DictionaryDataSource]
        public void ShouldMatchForDictionary(string key, object expectedValue, string displayName)
        {
            Assert.AreEqual(expectedValue, DataUtility.ParseNullableInt32(DataSourceValues.NullableInt32Dictionary, key));
            Assert.AreEqual(expectedValue, DataUtility.ParseNullableInt(DataSourceValues.NullableInt32Dictionary, key));
        }

        [TestMethod]
        [DataRow("KeyDoesNotExist", null, null, DisplayName = "data[\"KeyDoesNotExist\"] should be null")]
        [NullableInt32IDataRecordDataSource]
        public void ShouldMatchForDataRecord(string key, object expectedValue, string displayName)
        {
            Assert.AreEqual(expectedValue, DataUtility.ParseNullableInt32(DataSourceValues.NullableInt32DataRecord, key));
            Assert.AreEqual(expectedValue, DataUtility.ParseNullableInt(DataSourceValues.NullableInt32DataRecord, key));
        }

    }
}
