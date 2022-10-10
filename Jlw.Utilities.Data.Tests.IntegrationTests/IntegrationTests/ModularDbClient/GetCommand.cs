using System;
using System.Data;
using System.Data.Common;
using System.Data.SQLite;
using Jlw.Utilities.Data.DbUtility;
using Jlw.Utilities.Testing;
using Microsoft.Data.SqlClient;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MySql.Data.MySqlClient;

namespace Jlw.Utilities.Data.Tests.IntegrationTests.ModularDbClient
{
    [TestClass]
    public class GetCommand : BaseModelFixture<ModularDbClient<SqlConnection>, NullTestSchema<ModularDbClient<SqlConnection>>>
    {
        [TestMethod]
        [DataRow(null)]
        [DataRow("")]
        [DataRow("\n\t\r ")]
        [DataRow("\n;\t;\r; ;;")]
        [DataRow("=")]
        [DataRow("\n=\t=\r= ")]
        [DataRow("test=123")]
        [DataRow("Server=123;")]
        [DataRow("Server=MyServer123;User Id=test;Initial Catalog=TestDb")]
        [DataRow("123")]
        [DataRow("test")]
        public void Should_Accept_Command_ForNullCommand(string cmdString)
        {
            var sut1 = new ModularDbClient<MockDbConnection>();
            var sut2 = new ModularDbClient<MockDbConnection, NullDbCommand, MockDbParameter>();
            var sut3 = new ModularDbClient<MockDbConnection, NullDbCommand, MockDbParameter, DbConnectionStringBuilder>();
            sut1.GetCommand(cmdString);
            sut1.GetCommand(cmdString, sut1.GetConnection());
            sut2.GetCommand(cmdString);
            sut2.GetCommand(cmdString, sut2.GetConnection());
            sut3.GetCommand(cmdString);
            sut3.GetCommand(cmdString, sut3.GetConnection());
        }

        [TestMethod]
        [DataRow(null)]
        [DataRow("")]
        [DataRow("\n\t\r ")]
        [DataRow("\n;\t;\r; ;;")]
        [DataRow("=")]
        [DataRow("\n=\t=\r= ")]
        [DataRow("test=123")]
        [DataRow("Server=123;")]
        [DataRow("Server=MyServer123;User Id=test;Initial Catalog=TestDb")]
        [DataRow("123")]
        [DataRow("test")]
        public void Should_Accept_Command_ForSQLiteConnection(string cmdString)
        {
            var sut1 = new ModularDbClient<SQLiteConnection>();
            var sut2 = new ModularDbClient<SQLiteConnection, SQLiteCommand, SQLiteParameter>();
            var sut3 = new ModularDbClient<SQLiteConnection, SQLiteCommand, SQLiteParameter, SQLiteConnectionStringBuilder>();
            sut1.GetCommand(cmdString);
            sut1.GetCommand(cmdString, sut1.GetConnection());
            sut2.GetCommand(cmdString);
            sut2.GetCommand(cmdString, sut2.GetConnection());
            sut3.GetCommand(cmdString);
            sut3.GetCommand(cmdString, sut3.GetConnection());
        }

        [TestMethod]
        [DataRow(null)]
        [DataRow("")]
        [DataRow("\n\t\r ")]
        [DataRow("\n;\t;\r; ;;")]
        [DataRow("=")]
        [DataRow("\n=\t=\r= ")]
        [DataRow("test=123")]
        [DataRow("Server=123;")]
        [DataRow("Server=MyServer123;User Id=test;Initial Catalog=TestDb")]
        [DataRow("123")]
        [DataRow("test")]
        public void Should_Accept_Command_ForSqlServer(string cmdString)
        {
            var sut1 = new ModularDbClient<SqlConnection>();
            var sut2 = new ModularDbClient<SqlConnection, SqlCommand, SqlParameter>();
            var sut3 = new ModularDbClient<SqlConnection, SqlCommand, SqlParameter, SqlConnectionStringBuilder>();
            sut1.GetCommand(cmdString);
            sut1.GetCommand(cmdString, sut1.GetConnection());
            sut2.GetCommand(cmdString);
            sut2.GetCommand(cmdString, sut2.GetConnection());
            sut3.GetCommand(cmdString);
            sut3.GetCommand(cmdString, sut3.GetConnection());
        }

        [TestMethod]
        [DataRow(null)]
        [DataRow("")]
        [DataRow("\n\t\r ")]
        [DataRow("\n;\t;\r; ;;")]
        [DataRow("=")]
        [DataRow("\n=\t=\r= ")]
        [DataRow("test=123")]
        [DataRow("Server=123;")]
        [DataRow("Server=MyServer123;User Id=test;Initial Catalog=TestDb")]
        [DataRow("123")]
        [DataRow("test")]
        public void Should_Accept_Command_ForMySqlConnection(string cmdString)
        {
            var sut1 = new ModularDbClient<MySqlConnection>();
            var sut2 = new ModularDbClient<MySqlConnection, MySqlCommand, MySqlParameter>();
            var sut3 = new ModularDbClient<MySqlConnection, MySqlCommand, MySqlParameter, MySqlConnectionStringBuilder>();
            sut1.GetCommand(cmdString);
            sut1.GetCommand(cmdString, sut1.GetConnection());
            sut2.GetCommand(cmdString);
            sut2.GetCommand(cmdString, sut2.GetConnection());
            sut3.GetCommand(cmdString);
            sut3.GetCommand(cmdString, sut3.GetConnection());
        }


        [TestMethod]
        [DataRow(typeof(IDbCommand))]
        [DataRow(typeof(SqlCommand))]
        public void Should_Return_InstanceOf_ForSqlCommand(Type t)
        {
            var sut1 = new ModularDbClient<SqlConnection>();
            AssertTypeMatches(sut1.GetCommand(""), t);
            AssertTypeMatches(sut1.GetCommand("", sut1.GetConnection()), t);
            var sut2 = new ModularDbClient<SqlConnection, SqlCommand, SqlParameter>();
            AssertTypeMatches(sut2.GetCommand(""), t);
            AssertTypeMatches(sut2.GetCommand("", sut2.GetConnection()), t);
            var sut3 = new ModularDbClient<SqlConnection, SqlCommand, SqlParameter, SqlConnectionStringBuilder>();
            AssertTypeMatches(sut3.GetCommand(""), t);
            AssertTypeMatches(sut3.GetCommand("", sut3.GetConnection()), t);
        }

        [TestMethod]
        public void Should_ReturnNewInstance_ForSubsequentCalls()
        {
            var sut1 = new ModularDbClient<SqlConnection>();
            var sut2 = new ModularDbClient<SqlConnection, SqlCommand, SqlParameter>();
            var sut3 = new ModularDbClient<SqlConnection, SqlCommand, SqlParameter, SqlConnectionStringBuilder>();

            var notExpected = sut1.GetCommand("");
            var actual = sut1.GetCommand("");
            Assert.AreNotEqual(notExpected, actual);
            Assert.AreNotSame(notExpected, actual);

            notExpected = sut1.GetCommand("", sut1.GetConnection());
            actual = sut1.GetCommand("", sut1.GetConnection());
            Assert.AreNotEqual(notExpected, actual);
            Assert.AreNotSame(notExpected, actual);

            notExpected = sut2.GetCommand("");
            actual = sut2.GetCommand("");
            Assert.AreNotEqual(notExpected, actual);
            Assert.AreNotSame(notExpected, actual);

            notExpected = sut2.GetCommand("", sut2.GetConnection());
            actual = sut2.GetCommand("", sut2.GetConnection());
            Assert.AreNotEqual(notExpected, actual);
            Assert.AreNotSame(notExpected, actual);

            notExpected = sut3.GetCommand("");
            actual = sut3.GetCommand("");
            Assert.AreNotEqual(notExpected, actual);
            Assert.AreNotSame(notExpected, actual);

            notExpected = sut3.GetCommand("", sut3.GetConnection());
            actual = sut3.GetCommand("", sut3.GetConnection());
            Assert.AreNotEqual(notExpected, actual);
            Assert.AreNotSame(notExpected, actual);

        }

    }
}