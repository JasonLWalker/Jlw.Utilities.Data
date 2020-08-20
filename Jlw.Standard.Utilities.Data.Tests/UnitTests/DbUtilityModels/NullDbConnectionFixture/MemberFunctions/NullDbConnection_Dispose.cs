using Jlw.Standard.Utilities.Data.DbUtility;
using Jlw.Standard.Utilities.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Jlw.Standard.Utilities.Data.Tests.UnitTests.DbUtilityModels.NullDbConnectionFixture
{
    [TestClass]
    public class NullDbConnection_Dispose : BaseModelFixture<NullDbConnection>
    {
        [TestMethod]
        public void Should_NotThrowException()
        {
            using (var sut = new NullDbConnection())
            {
                // do nothing;
            } // Dispose is called here

            Assert.IsTrue(true);
        }

    }
}