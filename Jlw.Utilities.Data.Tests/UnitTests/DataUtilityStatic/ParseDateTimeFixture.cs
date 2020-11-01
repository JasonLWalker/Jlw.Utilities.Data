using System;
using Jlw.Utilities.Testing.DataSources;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Jlw.Utilities.Data.Tests.UnitTests.DataUtilityStatic
{
    [TestClass]
    public class ParseDateTimeFixture
    {
        [TestMethod]
        [DateTimeSource]
        public void Should_Match_ForObject(DateTime value)
        {
            Assert.AreEqual(value, DataUtility.ParseDateTime(value));
        }

        [TestMethod]
        [DateTimeSource]
        public void Should_Match_ForString(DateTime value)
        {
            string sDateTime = value.ToString();
            Assert.AreEqual(sDateTime, DataUtility.ParseDateTime(sDateTime).ToString());
        }

        [TestMethod]
        [DateTimeSource]
        public void Should_Match_ForShortTimeString(DateTime value)
        {
            string sDateTime = value.ToString("t");
            Assert.AreEqual(sDateTime, DataUtility.ParseDateTime(sDateTime).ToString("t"));
        }

        [TestMethod]
        [DateTimeSource]
        public void Should_Match_ForLongTimeString(DateTime value)
        {
            string sDateTime = value.ToString("T");
            Assert.AreEqual(sDateTime, DataUtility.ParseDateTime(sDateTime).ToString("T"));
        }

        [TestMethod]
        [DateTimeSource]
        public void Should_Match_ForShortDateString(DateTime value)
        {
            string sDateTime = value.ToString("d");
            Assert.AreEqual(sDateTime, DataUtility.ParseDateTime(sDateTime).ToString("d"));
        }

        [TestMethod]
        [DateTimeSource]
        public void Should_Match_ForLongDateString(DateTime value)
        {
            string sDateTime = value.ToString("D");
            Assert.AreEqual(sDateTime, DataUtility.ParseDateTime(sDateTime).ToString("D"));
        }

        [TestMethod]
        [DateTimeSource]
        public void Should_Match_ForFullDateString(DateTime value)
        {
            string sDateTime = value.ToString("F");
            Assert.AreEqual(sDateTime, DataUtility.ParseDateTime(sDateTime).ToString("F"));
        }

        /*
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
        */
    }
}
