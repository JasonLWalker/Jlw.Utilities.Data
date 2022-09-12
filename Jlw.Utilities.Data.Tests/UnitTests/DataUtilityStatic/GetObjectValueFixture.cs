using System;
using System.Collections.Generic;
using System.Text;
using Jlw.Utilities.Testing.DataSources;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;

namespace Jlw.Utilities.Data.Tests.UnitTests.DataUtilityStatic
{
    [TestClass]
    public class GetObjectValueFixture
    {
        private const string JsonIntValues = "{" +
            "\"one\":1," +
            "\"val123\":123," +
            "\"intMin\":-2147483648," +
            "\"intMax\":2147483647," +
            "\"longMin\":-9223372036854775808," +
            "\"longMax\":9223372036854775807," +
        "}";

        private const string JsonStringValues = "{" +
            "\"one\":\"1\"," +
            "\"test\":\"This is a test\"," +
        "}";

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

        [TestMethod]
        [DataRow("one", 1, JsonIntValues)]
        [DataRow("intMin", int.MinValue, JsonIntValues)]
        [DataRow("intMax", int.MaxValue, JsonIntValues)]
        [DataRow("longMin", long.MinValue, JsonIntValues)]
        [DataRow("longMax", long.MaxValue, JsonIntValues)]
        [DataRow("val123", 123, JsonIntValues)]
        public void Should_MatchLongFor_JToken(string key, long expected, string json)
        {
            var jt = JToken.Parse(json);
            var actual = DataUtility.GetObjectValue(jt, key);

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        [DataRow("one", "1", JsonStringValues)]
        [DataRow("test", "This is a test", JsonStringValues)]
        public void Should_MatchStringFor_JToken(string key, string expected, string json)
        {
            var jt = JToken.Parse(json);
            var actual = DataUtility.GetObjectValue(jt, key);

            Assert.AreEqual(expected, actual);
        }
    }
}
