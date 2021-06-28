using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Jlw.Utilities.Data.Tests.UnitTests.DataUtilityStatic
{
    [TestClass]
    public class ParseStringFixture
    {
        [TestMethod]
        [Int64IDataRecordDataSource]
        public void Should_Match_ForName_WhenInitialized(string key, object expectedValue, string displayName)
        {
            var actual = new TestDataModel() { Name = expectedValue.ToString() };

            Assert.AreEqual(expectedValue.ToString(), DataUtility.ParseString(actual, "Name"));
        }

        [TestMethod]
        [Int64IDataRecordDataSource]
        public void Should_BeEmpty_ForUnknown_WhenInitialized(string key, object expectedValue, string displayName)
        {
            var actual = new TestDataModel() { Name = expectedValue.ToString() };

            Assert.AreEqual(String.Empty, DataUtility.ParseString(actual, "Unknown"));
        }

        [TestMethod]
        [Int64IDataRecordDataSource]
        public void Should_BeEmpty_ForObject_WhenInitialized(string key, object expectedValue, string displayName)
        {
            var actual = new TestDataModel() { Name = expectedValue.ToString() };

            Assert.AreEqual(String.Empty, DataUtility.ParseString(actual));
        }

        [TestMethod]
        [Int64IDataRecordDataSource]
        public void Should_Match_ForId_WhenInitialized(string key, object expectedValue, string displayName)
        {
            var actual = new TestDataModel() { Id = (long)expectedValue };

            Assert.AreEqual(expectedValue.ToString(), DataUtility.ParseString(actual, "Id"));
        }


    }
}