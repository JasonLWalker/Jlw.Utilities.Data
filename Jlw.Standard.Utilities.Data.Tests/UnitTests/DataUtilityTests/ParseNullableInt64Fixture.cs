using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Jlw.Standard.Utilities.Data.Tests.UnitTests
{
    [TestClass]
    public class ParseNullableInt64Fixture
    {
        [TestMethod]
        [NullableInt64DataSource]
        public void ShouldMatchForObject(object value, object expectedValue, string displayName)
        {
            Assert.AreEqual(expectedValue, DataUtility.ParseNullableLong(value));
            Assert.AreEqual(expectedValue, DataUtility.ParseNullableInt64(value));
        }

        [TestMethod]
        [DataRow("KeyDoesNotExist", null, null, DisplayName = "kvpList[\"KeyDoesNotExist\"] should be null")]
        [NullableInt64KvpListDataSource]
        public void ShouldMatchForKvpList(string key, object expectedValue, string displayName)
        {
            Assert.AreEqual(expectedValue, DataUtility.ParseNullableLong(DataSourceValues.NullableInt64KvpList, key));
            Assert.AreEqual(expectedValue, DataUtility.ParseNullableInt64(DataSourceValues.NullableInt64KvpList, key));
        }

        [TestMethod]
        [DataRow("KeyDoesNotExist", null, null, DisplayName = "dict[\"KeyDoesNotExist\"] should be null")]
        [NullableInt64DictionaryDataSource]
        public void ShouldMatchForDictionary(string key, object expectedValue, string displayName)
        {
            Assert.AreEqual(expectedValue, DataUtility.ParseNullableLong(DataSourceValues.NullableInt64Dictionary, key));
            Assert.AreEqual(expectedValue, DataUtility.ParseNullableInt64(DataSourceValues.NullableInt64Dictionary, key));
        }

        [TestMethod]
        [DataRow("KeyDoesNotExist", null, null, DisplayName = "data[\"KeyDoesNotExist\"] should be null")]
        [NullableInt64IDataRecordDataSource]
        public void ShouldMatchForDataRecord(string key, object expectedValue, string displayName)
        {
            Assert.AreEqual(expectedValue, DataUtility.ParseNullableLong(DataSourceValues.NullableInt64DataRecord, key));
            Assert.AreEqual(expectedValue, DataUtility.ParseNullableInt64(DataSourceValues.NullableInt64DataRecord, key));
        }

    }
}
