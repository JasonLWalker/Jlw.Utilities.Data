using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Jlw.Standard.Utilities.Data.Tests.UnitTests.DataUtilityStatic
{
    [TestClass]
    public class ParseSByteFixture
    {
        [TestMethod]
        [SByteDataSource]
        public void ShouldMatchForObject(object value, object expectedValue, string displayName)
        {
            Assert.AreEqual(expectedValue, DataUtility.ParseSByte(value));
        }

        [TestMethod]
        [DataRow("KeyDoesNotExist", (sbyte)default, null, DisplayName = "kvpList[\"KeyDoesNotExist\"] should be null")]
        [SByteKvpListDataSource]
        public void ShouldMatchForKvpList(string key, object expectedValue, string displayName)
        {
            Assert.AreEqual(expectedValue, DataUtility.ParseSByte(Jlw.Standard.Utilities.Data.Tests.DataSourceValues.NullableSByteKvpList, key));
        }

        [TestMethod]
        [DataRow("KeyDoesNotExist", (sbyte)default, null, DisplayName = "dict[\"KeyDoesNotExist\"] should be null")]
        [SByteDictionaryDataSource]
        public void ShouldMatchForDictionary(string key, object expectedValue, string displayName)
        {
            Assert.AreEqual(expectedValue, DataUtility.ParseSByte(Jlw.Standard.Utilities.Data.Tests.DataSourceValues.NullableSByteDictionary, key));
        }

        [TestMethod]
        [DataRow("KeyDoesNotExist", (sbyte)default, null, DisplayName = "data[\"KeyDoesNotExist\"] should be null")]
        [SByteIDataRecordDataSource]
        public void ShouldMatchForDataRecord(string key, object expectedValue, string displayName)
        {
            Assert.AreEqual(expectedValue, DataUtility.ParseSByte(Jlw.Standard.Utilities.Data.Tests.DataSourceValues.NullableSByteDataRecord, key));
        }

    }
}
