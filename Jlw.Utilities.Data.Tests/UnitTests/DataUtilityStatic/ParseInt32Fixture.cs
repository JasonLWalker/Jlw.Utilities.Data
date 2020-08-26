using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Jlw.Utilities.Data.Tests.UnitTests.DataUtilityStatic
{
    [TestClass]
    public class ParseInt32Fixture
    {
        [TestMethod]
        [Int32DataSource]
        public void ShouldMatchForObject(object value, object expectedValue, string displayName)
        {
            Assert.AreEqual(expectedValue, DataUtility.ParseInt32(value));
            Assert.AreEqual(expectedValue, DataUtility.ParseInt(value));
        }

        [TestMethod]
        [DataRow("KeyDoesNotExist", (Int32)default, null, DisplayName = "kvpList[\"KeyDoesNotExist\"] should be null")]
        [Int32KvpListDataSource]
        public void ShouldMatchForKvpList(string key, object expectedValue, string displayName)
        {
            Assert.AreEqual(expectedValue, DataUtility.ParseInt32(DataSourceValues.NullableInt32KvpList, key));
            Assert.AreEqual(expectedValue, DataUtility.ParseInt(DataSourceValues.NullableInt32KvpList, key));
        }

        [TestMethod]
        [DataRow("KeyDoesNotExist", (Int32)default, null, DisplayName = "dict[\"KeyDoesNotExist\"] should be null")]
        [Int32DictionaryDataSource]
        public void ShouldMatchForDictionary(string key, object expectedValue, string displayName)
        {
            Assert.AreEqual(expectedValue, DataUtility.ParseInt32(DataSourceValues.NullableInt32Dictionary, key));
            Assert.AreEqual(expectedValue, DataUtility.ParseInt(DataSourceValues.NullableInt32Dictionary, key));
        }

        [TestMethod]
        [DataRow("KeyDoesNotExist", (Int32)default, null, DisplayName = "data[\"KeyDoesNotExist\"] should be null")]
        [Int32IDataRecordDataSource]
        public void ShouldMatchForDataRecord(string key, object expectedValue, string displayName)
        {
            Assert.AreEqual(expectedValue, DataUtility.ParseInt32(DataSourceValues.NullableInt32DataRecord, key));
            Assert.AreEqual(expectedValue, DataUtility.ParseInt(DataSourceValues.NullableInt32DataRecord, key));
        }

    }
}
