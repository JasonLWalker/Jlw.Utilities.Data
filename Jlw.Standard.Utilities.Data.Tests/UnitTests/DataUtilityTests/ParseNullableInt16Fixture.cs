using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Jlw.Standard.Utilities.Data.Tests.UnitTests
{
    [TestClass]
    public class ParseNullableInt16Fixture
    {
        [TestMethod]
        [NullableInt16DataSource]
        public void ShouldMatchForObject(object value, object expectedValue, string displayName)
        {
            Assert.AreEqual(expectedValue, DataUtility.ParseNullableShort(value));
            Assert.AreEqual(expectedValue, DataUtility.ParseNullableInt16(value));
        }

        [TestMethod]
        [DataRow("KeyDoesNotExist", null, null, DisplayName = "kvpList[\"KeyDoesNotExist\"] should be null")]
        [NullableInt16KvpListDataSource]
        public void ShouldMatchForKvpList(string key, object expectedValue, string displayName)
        {
            Assert.AreEqual(expectedValue, DataUtility.ParseNullableShort(DataSourceValues.NullableInt16KvpList, key));
            Assert.AreEqual(expectedValue, DataUtility.ParseNullableInt16(DataSourceValues.NullableInt16KvpList, key));
        }

        [TestMethod]
        [DataRow("KeyDoesNotExist", null, null, DisplayName = "dict[\"KeyDoesNotExist\"] should be null")]
        [NullableInt16DictionaryDataSource]
        public void ShouldMatchForDictionary(string key, object expectedValue, string displayName)
        {
            Assert.AreEqual(expectedValue, DataUtility.ParseNullableShort(DataSourceValues.NullableInt16Dictionary, key));
            Assert.AreEqual(expectedValue, DataUtility.ParseNullableInt16(DataSourceValues.NullableInt16Dictionary, key));
        }

        [TestMethod]
        [DataRow("KeyDoesNotExist", null, null, DisplayName = "data[\"KeyDoesNotExist\"] should be null")]
        [NullableInt16IDataRecordDataSource]
        public void ShouldMatchForDataRecord(string key, object expectedValue, string displayName)
        {
            Assert.AreEqual(expectedValue, DataUtility.ParseNullableShort(DataSourceValues.NullableInt16DataRecord, key));
            Assert.AreEqual(expectedValue, DataUtility.ParseNullableInt16(DataSourceValues.NullableInt16DataRecord, key));
        }

    }
}
