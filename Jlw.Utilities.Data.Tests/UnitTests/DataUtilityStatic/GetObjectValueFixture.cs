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
        public void Should_ReturnNullFor_NonMember() // This is a change by JLW on 10/4/2021 due to unforeseen bugs being introduced by returning the object value. Will bump version to 4.3 due to potential breaking change.
        {

            var actual = new TestDataModel();

            Assert.AreSame(null, DataUtility.GetObjectValue(actual, "Foo"));
        }

    }
}
