using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Jlw.Standard.Utilities.Data.Tests.UnitTests.DataUtilityStatic
{
    [TestClass]
    public class ParseBoolFixture
    {
        [TestMethod]
        [BooleanDataSource]
        public void Should_Match_ForObject(object value, object expectedValue, string displayName)
        {
            Assert.AreEqual(expectedValue, DataUtility.ParseBool(value));
        }

        [TestMethod]
        [DataRow("KeyDoesNotExist", (bool)default, null, DisplayName = "kvpList[\"KeyDoesNotExist\"] should be False")]
        [BooleanKvpListDataSource]
        public void Should_Match_ForKvpList(string key, object expectedValue, string displayName)
        {
            Assert.AreEqual(expectedValue, DataUtility.ParseBool(DataSourceValues.NullableBooleanKvpList, key));
        }

        [TestMethod]
        [DataRow("KeyDoesNotExist", (bool)default, null, DisplayName = "dict[\"KeyDoesNotExist\"] should be False")]
        [BooleanDictionaryDataSource]
        public void Should_Match_ForDictionary(string key, object expectedValue, string displayName)
        {
            Assert.AreEqual(expectedValue, DataUtility.ParseBool(DataSourceValues.NullableBooleanDictionary, key));
        }

        [TestMethod]
        [DataRow("KeyDoesNotExist", (bool)default, null, DisplayName = "data[\"KeyDoesNotExist\"] should be False")]
        [BooleanIDataRecordDataSource]
        public void Should_Match_ForDataRecord(string key, object expectedValue, string displayName)
        {
            Assert.AreEqual(expectedValue, DataUtility.ParseBool(DataSourceValues.NullableBooleanDataRecord, key));
        }

    }
}
