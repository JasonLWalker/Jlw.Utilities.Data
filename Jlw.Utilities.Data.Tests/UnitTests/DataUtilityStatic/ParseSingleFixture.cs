using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Jlw.Utilities.Data.Tests.UnitTests.DataUtilityStatic
{
    [TestClass]
    public class ParseSingleFixture
    {
        [TestMethod]
        [SingleDataSource]
        public void ShouldMatchForObject(object value, object expectedValue, string displayName)
        {
            Assert.AreEqual(expectedValue, DataUtility.ParseSingle(value));
            Assert.AreEqual(expectedValue, DataUtility.ParseFloat(value));
        }

        [TestMethod]
        [DataRow("KeyDoesNotExist", (Single)default, null, DisplayName = "kvpList[\"KeyDoesNotExist\"] should be null")]
        [SingleKvpListDataSource]
        public void ShouldMatchForKvpList(string key, object expectedValue, string displayName)
        {
            Assert.AreEqual(expectedValue, DataUtility.ParseSingle(Jlw.Utilities.Data.Tests.DataSourceValues.NullableSingleKvpList, key));
            Assert.AreEqual(expectedValue, DataUtility.ParseFloat(Jlw.Utilities.Data.Tests.DataSourceValues.NullableSingleKvpList, key));
        }

        [TestMethod]
        [DataRow("KeyDoesNotExist", (Single)default, null, DisplayName = "dict[\"KeyDoesNotExist\"] should be null")]
        [SingleDictionaryDataSource]
        public void ShouldMatchForDictionary(string key, object expectedValue, string displayName)
        {
            Assert.AreEqual(expectedValue, DataUtility.ParseSingle(Jlw.Utilities.Data.Tests.DataSourceValues.NullableSingleDictionary, key));
            Assert.AreEqual(expectedValue, DataUtility.ParseFloat(Jlw.Utilities.Data.Tests.DataSourceValues.NullableSingleDictionary, key));
        }

        [TestMethod]
        [DataRow("KeyDoesNotExist", (Single)default, null, DisplayName = "data[\"KeyDoesNotExist\"] should be null")]
        [SingleIDataRecordDataSource]
        public void ShouldMatchForDataRecord(string key, object expectedValue, string displayName)
        {
            Assert.AreEqual(expectedValue, DataUtility.ParseSingle(Jlw.Utilities.Data.Tests.DataSourceValues.NullableSingleDataRecord, key));
            Assert.AreEqual(expectedValue, DataUtility.ParseFloat(Jlw.Utilities.Data.Tests.DataSourceValues.NullableSingleDataRecord, key));
        }

    }
}
