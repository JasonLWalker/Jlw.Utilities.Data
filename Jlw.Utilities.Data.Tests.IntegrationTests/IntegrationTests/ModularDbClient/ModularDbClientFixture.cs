using System;
using Jlw.Utilities.Data.DbUtility;
using Jlw.Utilities.Testing;
using Microsoft.Data.SqlClient;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Jlw.Utilities.Data.Tests.IntegrationTests.ModularDbClient
{
    [TestClass]
    public class ModularDbClientFixture : BaseModelFixture<ModularDbClient<SqlConnection, SqlCommand, SqlParameter, SqlConnectionStringBuilder>>
    {
        protected string SqlInitFilename = $"{AppDomain.CurrentDomain.BaseDirectory}Data\\Sql\\TSql\\InitializeDb.sql";

        [TestMethod]
        [DataRow(typeof (IModularDbClient))]
        [DataRow(typeof(ModularDbClient<SqlConnection, SqlCommand, SqlParameter, SqlConnectionStringBuilder>))]
        public override void Should_BeInstanceOf(Type t)
        {
            base.Should_BeInstanceOf(t);
        }

    }
}
