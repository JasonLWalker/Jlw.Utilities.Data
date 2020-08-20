using System;
using System.Data;
using Jlw.Standard.Utilities.Data.DbUtility;
using Jlw.Standard.Utilities.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Jlw.Standard.Utilities.Data.Tests.UnitTests.DbUtilityModels
{
    [TestClass]
    public class MockDbConnectionFixture : BaseModelFixture<MockDbConnection>
    {
        [TestMethod]
        public void Should_Implement_IDbConnection()
        {
            var sut = new MockDbConnection();
            Type expectedType = typeof(IDbConnection);
            Assert.IsInstanceOfType(sut, expectedType, $"<{sut.GetType().Name}> does not implement <{expectedType.Name}> interface.");
        }




    }
}