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
            var actual = new TestDataModel() { Id = (long)expectedValue, Name = expectedValue.ToString(), Description = displayName, LastUpdated = DateTime.Now };

            Assert.AreEqual(String.Empty, DataUtility.ParseString(actual, "Unknown"));
        }

        [TestMethod]
        [Int64IDataRecordDataSource]
        public void Should_BeEmpty_ForObject_WhenInitialized(string key, object expectedValue, string displayName)
        {
            var sut = new TestDataModel() { Id = (long)expectedValue, Name = key, Description = displayName, LastUpdated = DateTime.Now };
            string actual = DataUtility.ParseString(sut);
            Assert.AreEqual(String.Empty, actual);

            actual = DataUtility.Parse<string>(sut);
            Assert.AreEqual(String.Empty, actual);

            actual = DataUtility.Parse<String>(sut);
            Assert.AreEqual(String.Empty, actual);

        }

        [TestMethod]
        [Int64IDataRecordDataSource]
        public void Should_Match_ForId_WhenInitialized(string key, object expectedValue, string displayName)
        {
            // Arrange
            var sut = new TestDataModel() { Id = (long)expectedValue, Name = key, Description = displayName, LastUpdated = DateTime.Now };
            
            // Act
            string actual = DataUtility.ParseString(sut, "Id");
            // Assert
            Assert.AreEqual(expectedValue.ToString(), actual);

            // Act
            actual = DataUtility.Parse<string>(sut, "Id");
            // Assert
            Assert.AreEqual(expectedValue.ToString(), actual);

            // Act
            actual = DataUtility.Parse<String>(sut, "Id");
            // Assert
            Assert.AreEqual(expectedValue.ToString(), actual);

        }



    }
}