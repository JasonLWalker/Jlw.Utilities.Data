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

        [TestMethod]
        [DataRow(DefaultEnumeration.Default, 0, "DefaultEnumeration.Default")]
        [DataRow(DefaultEnumeration.First, 1, "DefaultEnumeration.First")]
        [DataRow(DefaultEnumeration.Second, 2, "DefaultEnumeration.Second")]
        [DataRow(DefaultEnumeration.Third, 3, "DefaultEnumeration.Third")]
        public void ShouldMatchForDefaultEnumeration(DefaultEnumeration sut, object expectedValue, string displayName)
        {
            Assert.AreEqual(expectedValue, DataUtility.ParseInt32(sut));
            Assert.AreEqual(expectedValue, DataUtility.ParseInt(sut));
        }

        [TestMethod]
        [DataRow(SpecificEnumeration.Default, 0, "SpecificEnumeration.Default")]
        [DataRow(SpecificEnumeration.First, 1, "SpecificEnumeration.First")]
        [DataRow(SpecificEnumeration.Second, 2, "SpecificEnumeration.Second")]
        [DataRow(SpecificEnumeration.Third, 3, "SpecificEnumeration.Third")]
        [DataRow(SpecificEnumeration.Ninth, 9, "SpecificEnumeration.Ninth")]
        public void ShouldMatchForSpecificEnumeration(SpecificEnumeration sut, object expectedValue, string displayName)
        {
            Assert.AreEqual(expectedValue, DataUtility.ParseInt32(sut));
            Assert.AreEqual(expectedValue, DataUtility.ParseInt(sut));
        }

        [TestMethod]
        [DataRow(FlaggedEnumeration.Default, 0, "FlaggedEnumeration.Default")]
        [DataRow(FlaggedEnumeration.Unknown, 0, "FlaggedEnumeration.Unknown")]
        [DataRow(FlaggedEnumeration.Bit1, 1, "FlaggedEnumeration.Bit1")]
        [DataRow(FlaggedEnumeration.Bit2, 2, "FlaggedEnumeration.Bit2")]
        [DataRow(FlaggedEnumeration.Bit3, 4, "FlaggedEnumeration.Bit3")]
        [DataRow(FlaggedEnumeration.Bit1 | FlaggedEnumeration.Bit3, 5, "FlaggedEnumeration.Bit1 | FlaggedEnumeration.Bit3")]
        public void ShouldMatchForFlaggedEnumeration(FlaggedEnumeration sut, object expectedValue, string displayName)
        {
            Assert.AreEqual(expectedValue, DataUtility.ParseInt32(sut));
            Assert.AreEqual(expectedValue, DataUtility.ParseInt(sut));
        }

    }
}
