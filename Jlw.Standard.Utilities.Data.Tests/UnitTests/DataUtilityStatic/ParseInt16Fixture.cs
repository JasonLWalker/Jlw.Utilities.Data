using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Jlw.Standard.Utilities.Data.Tests.UnitTests.DataUtilityStatic
{
    [TestClass]
    public class ParseInt16Fixture
    {
        [TestMethod]
        [Int16DataSource]
        public void ShouldMatchForObject(object value, object expectedValue, string displayName)
        {
            Assert.AreEqual(expectedValue, DataUtility.ParseShort(value));
            Assert.AreEqual(expectedValue, DataUtility.ParseInt16(value));
        }

        [TestMethod]
        [DataRow("KeyDoesNotExist", (Int16)default, null, DisplayName = "kvpList[\"KeyDoesNotExist\"] should be null")]
        [Int16KvpListDataSource]
        public void ShouldMatchForKvpList(string key, object expectedValue, string displayName)
        {
            Assert.AreEqual(expectedValue, DataUtility.ParseShort(DataSourceValues.NullableInt16KvpList, key));
            Assert.AreEqual(expectedValue, DataUtility.ParseInt16(DataSourceValues.NullableInt16KvpList, key));
        }

        [TestMethod]
        [DataRow("KeyDoesNotExist", (Int16)default, null, DisplayName = "dict[\"KeyDoesNotExist\"] should be null")]
        [Int16DictionaryDataSource]
        public void ShouldMatchForDictionary(string key, object expectedValue, string displayName)
        {
            Assert.AreEqual(expectedValue, DataUtility.ParseShort(DataSourceValues.NullableInt16Dictionary, key));
            Assert.AreEqual(expectedValue, DataUtility.ParseInt16(DataSourceValues.NullableInt16Dictionary, key));
        }

        [TestMethod]
        [DataRow("KeyDoesNotExist", (Int16)default, null, DisplayName = "data[\"KeyDoesNotExist\"] should be null")]
        [Int16IDataRecordDataSource]
        public void ShouldMatchForDataRecord(string key, object expectedValue, string displayName)
        {
            Assert.AreEqual(expectedValue, DataUtility.ParseShort(DataSourceValues.NullableInt16DataRecord, key));
            Assert.AreEqual(expectedValue, DataUtility.ParseInt16(DataSourceValues.NullableInt16DataRecord, key));
        }

    }
}
