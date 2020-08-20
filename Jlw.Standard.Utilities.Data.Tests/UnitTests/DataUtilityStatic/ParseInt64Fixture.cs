using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Jlw.Standard.Utilities.Data.Tests.UnitTests.DataUtilityStatic
{
    [TestClass]
    public class ParseInt64Fixture
    {
        [TestMethod]
        [Int64DataSource]
        public void ShouldMatchForObject(object value, object expectedValue, string displayName)
        {
            Assert.AreEqual(expectedValue, DataUtility.ParseInt64(value));
            Assert.AreEqual(expectedValue, DataUtility.ParseLong(value));
        }

        [TestMethod]
        [DataRow("KeyDoesNotExist", (Int64)default, null, DisplayName = "kvpList[\"KeyDoesNotExist\"] should be null")]
        [Int64KvpListDataSource]
        public void ShouldMatchForKvpList(string key, object expectedValue, string displayName)
        {
            Assert.AreEqual(expectedValue, DataUtility.ParseInt64(DataSourceValues.NullableInt64KvpList, key));
            Assert.AreEqual(expectedValue, DataUtility.ParseLong(DataSourceValues.NullableInt64KvpList, key));
        }

        [TestMethod]
        [DataRow("KeyDoesNotExist", (Int64)default, null, DisplayName = "dict[\"KeyDoesNotExist\"] should be null")]
        [Int64DictionaryDataSource]
        public void ShouldMatchForDictionary(string key, object expectedValue, string displayName)
        {
            Assert.AreEqual(expectedValue, DataUtility.ParseInt64(DataSourceValues.NullableInt64Dictionary, key));
            Assert.AreEqual(expectedValue, DataUtility.ParseLong(DataSourceValues.NullableInt64Dictionary, key));
        }

        [TestMethod]
        [DataRow("KeyDoesNotExist", (Int64)default, null, DisplayName = "data[\"KeyDoesNotExist\"] should be null")]
        [Int64IDataRecordDataSource]
        public void ShouldMatchForDataRecord(string key, object expectedValue, string displayName)
        {
            Assert.AreEqual(expectedValue, DataUtility.ParseInt64(DataSourceValues.NullableInt64DataRecord, key));
            Assert.AreEqual(expectedValue, DataUtility.ParseLong(DataSourceValues.NullableInt64DataRecord, key));
        }

    }
}
