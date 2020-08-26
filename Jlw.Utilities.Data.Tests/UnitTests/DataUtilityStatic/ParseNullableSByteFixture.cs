using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Jlw.Utilities.Data.Tests.UnitTests.DataUtilityStatic
{
    
    [TestClass]
    public class ParseNullableSByteFixture
    {
        [TestMethod]
        [NullableSByteDataSource]
        public void ShouldMatchForObject(object value, object expectedValue, string displayName)
        {
            Assert.AreEqual(expectedValue, DataUtility.ParseNullableSByte(value));
        }

        [TestMethod]
        [DataRow("KeyDoesNotExist", null, null, DisplayName = "kvpList[\"KeyDoesNotExist\"] should be null")]
        [NullableSByteKvpListDataSource]
        public void ShouldMatchForKvpList(string key, object expectedValue, string displayName)
        {
            Assert.AreEqual(expectedValue, DataUtility.ParseNullableSByte(Jlw.Utilities.Data.Tests.DataSourceValues.NullableSByteKvpList, key));
        }

        [TestMethod]
        [DataRow("KeyDoesNotExist", null, null, DisplayName = "dict[\"KeyDoesNotExist\"] should be null")]
        [NullableSByteDictionaryDataSource]
        public void ShouldMatchForDictionary(string key, object expectedValue, string displayName)
        {
            Assert.AreEqual(expectedValue, DataUtility.ParseNullableSByte(Jlw.Utilities.Data.Tests.DataSourceValues.NullableSByteDictionary, key));
        }

        [TestMethod]
        [DataRow("KeyDoesNotExist", null, null, DisplayName = "data[\"KeyDoesNotExist\"] should be null")]
        [NullableSByteIDataRecordDataSource]
        public void ShouldMatchForDataRecord(string key, object expectedValue, string displayName)
        {
            Assert.AreEqual(expectedValue, DataUtility.ParseNullableSByte(Jlw.Utilities.Data.Tests.DataSourceValues.NullableSByteDataRecord, key));
        }

    }
}
