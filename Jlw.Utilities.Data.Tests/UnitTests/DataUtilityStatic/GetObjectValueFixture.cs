using System;
using System.Collections.Generic;
using System.Text;
using Jlw.Utilities.Testing.DataSources;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Jlw.Utilities.Data.Tests.UnitTests.DataUtilityStatic
{
    [TestClass]
    public class GetObjectValueFixture
    {
        [TestMethod]
        [Int64IDataRecordDataSource]
        public void Should_Match_ForId_WhenInitialized(string key, object expectedValue, string displayName)
        {
            var actual = new TestDataModel(){Id = (long)expectedValue};

            Assert.AreEqual(expectedValue, DataUtility.GetObjectValue(actual, "Id"));
        }

        [TestMethod]
        public void Should_BeZero_ForId_WhenUninitialized()
        {
            var actual = new TestDataModel();

            Assert.IsNull(DataUtility.GetObjectValue(actual, "Name"));
        }

        [TestMethod]
        [DataRow(null)]
        [RandomStringSource]
        public void Should_MatchForName_WhenInitialized(object expectedValue)
        {
            var actual = new TestDataModel() { Name = expectedValue?.ToString() };

            Assert.AreEqual(expectedValue, DataUtility.GetObjectValue(actual, "Name"));
        }

        [TestMethod]
        public void Should_BeNull_ForName_WhenUninitialized()
        {
            var actual = new TestDataModel();

            Assert.IsNull(DataUtility.GetObjectValue(actual, "Name"));
        }

        [TestMethod]
        public void Should_ReturnOriginalFor_NonMember()
        {
            var actual = new TestDataModel();

            Assert.AreSame(actual, DataUtility.GetObjectValue(actual, "Foo"));
        }

    }
}
