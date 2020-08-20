using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Jlw.Standard.Utilities.Data.Tests.UnitTests.DataUtilityStatic
{
    [TestClass]
    public class ParseNullableSingleFixture
    {
        [TestMethod]
        [NullableSingleDataSource]
        public void ShouldMatchForObject(object value, object expectedValue, string displayName)
        {
            Assert.AreEqual(expectedValue, DataUtility.ParseNullableSingle(value));
            Assert.AreEqual(expectedValue, DataUtility.ParseNullableFloat(value));
        }

        [TestMethod]
        [DataRow("KeyDoesNotExist", null, null, DisplayName = "kvpList[\"KeyDoesNotExist\"] should be null")]
        [NullableSingleKvpListDataSource]
        public void ShouldMatchForKvpList(string key, object expectedValue, string displayName)
        {
            Assert.AreEqual(expectedValue, DataUtility.ParseNullableSingle(Jlw.Standard.Utilities.Data.Tests.DataSourceValues.NullableSingleKvpList, key));
            Assert.AreEqual(expectedValue, DataUtility.ParseNullableFloat(Jlw.Standard.Utilities.Data.Tests.DataSourceValues.NullableSingleKvpList, key));
        }

        [TestMethod]
        [DataRow("KeyDoesNotExist", null, null, DisplayName = "dict[\"KeyDoesNotExist\"] should be null")]
        [NullableSingleDictionaryDataSource]
        public void ShouldMatchForDictionary(string key, object expectedValue, string displayName)
        {
            Assert.AreEqual(expectedValue, DataUtility.ParseNullableSingle(Jlw.Standard.Utilities.Data.Tests.DataSourceValues.NullableSingleDictionary, key));
            Assert.AreEqual(expectedValue, DataUtility.ParseNullableFloat(Jlw.Standard.Utilities.Data.Tests.DataSourceValues.NullableSingleDictionary, key));
        }

        [TestMethod]
        [DataRow("KeyDoesNotExist", null, null, DisplayName = "data[\"KeyDoesNotExist\"] should be null")]
        [NullableSingleIDataRecordDataSource]
        public void ShouldMatchForDataRecord(string key, object expectedValue, string displayName)
        {
            Assert.AreEqual(expectedValue, DataUtility.ParseNullableSingle(Jlw.Standard.Utilities.Data.Tests.DataSourceValues.NullableSingleDataRecord, key));
            Assert.AreEqual(expectedValue, DataUtility.ParseNullableFloat(Jlw.Standard.Utilities.Data.Tests.DataSourceValues.NullableSingleDataRecord, key));
        }

    }
}
