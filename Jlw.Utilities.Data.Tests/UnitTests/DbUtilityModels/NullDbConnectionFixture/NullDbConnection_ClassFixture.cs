using System;
using System.Data;
using Jlw.Utilities.Data.DbUtility;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Jlw.Utilities.Data.Tests.UnitTests.DbUtilityModels.NullDbConnectionFixture
{
    [TestClass]
    public class NullDbConnection_ClassFixture : BaseNullDbConnectionFixture
    {
        [TestMethod]
        public void Should_Implement_IDbConnection()
        {
            var sut = new NullDbConnection();
            Type expectedType = typeof(IDbConnection);
            Assert.IsInstanceOfType(sut, expectedType, $"<{sut.GetType().Name}> does not implement <{expectedType.Name}> interface.");
        }

    }
}