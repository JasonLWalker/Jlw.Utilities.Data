using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Jlw.Utilities.Data.Tests.UnitTests.DataUtilityStatic
{
    [TestClass]
    public class ParseDoubleFixture
    {
        [TestMethod]
        [DoubleDataSource]
        public void ShouldMatchForObject(object value, object expectedValue, string displayName)
        {
            Assert.AreEqual(expectedValue, DataUtility.ParseDouble(value));
        }

        [TestMethod]
        [DataRow("KeyDoesNotExist", (Double)default, null, DisplayName = "kvpList[\"KeyDoesNotExist\"] should be null")]
        [DoubleKvpListDataSource]
        public void ShouldMatchForKvpList(string key, object expectedValue, string displayName)
        {
            Assert.AreEqual(expectedValue, DataUtility.ParseDouble(DataSourceValues.NullableDoubleKvpList, key));
        }

        [TestMethod]
        [DataRow("KeyDoesNotExist", (Double)default, null, DisplayName = "dict[\"KeyDoesNotExist\"] should be null")]
        [DoubleDictionaryDataSource]
        public void ShouldMatchForDictionary(string key, object expectedValue, string displayName)
        {
            Assert.AreEqual(expectedValue, DataUtility.ParseDouble(DataSourceValues.NullableDoubleDictionary, key));
        }

        [TestMethod]
        [DataRow("KeyDoesNotExist", (Double)default, null, DisplayName = "data[\"KeyDoesNotExist\"] should be null")]
        [DoubleIDataRecordDataSource]
        public void ShouldMatchForDataRecord(string key, object expectedValue, string displayName)
        {
            Assert.AreEqual(expectedValue, DataUtility.ParseDouble(DataSourceValues.NullableDoubleDataRecord, key));
        }

    }
}
