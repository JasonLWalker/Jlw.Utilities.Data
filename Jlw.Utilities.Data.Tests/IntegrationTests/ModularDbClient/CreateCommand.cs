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
    public class CreateCommand : BaseModelFixture<ModularDbClient<SqlConnection>>
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
            //var sut1 = new ModularDbClient<MockDbConnection>();
            var sut2 = new ModularDbClient<MockDbConnection, NullDbCommand, MockDbParameter>();
            var sut3 = new ModularDbClient<MockDbConnection, NullDbCommand, MockDbParameter, DbConnectionStringBuilder>();
            //sut1.CreateCommand(cmdString);
            //sut1.CreateCommand(cmdString, sut1.GetConnection());
            sut2.CreateCommand(cmdString);
            sut2.CreateCommand(cmdString, sut2.CreateConnection());
            sut3.CreateCommand(cmdString);
            sut3.CreateCommand(cmdString, sut3.CreateConnection());
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
            //var sut1 = new ModularDbClient<SQLiteConnection>();
            var sut2 = new ModularDbClient<SQLiteConnection, SQLiteCommand, SQLiteParameter>();
            var sut3 = new ModularDbClient<SQLiteConnection, SQLiteCommand, SQLiteParameter, SQLiteConnectionStringBuilder>();
            //sut1.CreateCommand(cmdString);
            //sut1.CreateCommand(cmdString, sut1.GetConnection());
            sut2.CreateCommand(cmdString);
            sut2.CreateCommand(cmdString, sut2.CreateConnection());
            sut3.CreateCommand(cmdString);
            sut3.CreateCommand(cmdString, sut3.CreateConnection());
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
            //var sut1 = new ModularDbClient<SqlConnection>();
            var sut2 = new ModularDbClient<SqlConnection, SqlCommand, SqlParameter>();
            var sut3 = new ModularDbClient<SqlConnection, SqlCommand, SqlParameter, SqlConnectionStringBuilder>();
            //sut1.CreateCommand(cmdString);
            //sut1.CreateCommand(cmdString, sut1.GetConnection());
            sut2.CreateCommand(cmdString);
            sut2.CreateCommand(cmdString, sut2.CreateConnection());
            sut3.CreateCommand(cmdString);
            sut3.CreateCommand(cmdString, sut3.CreateConnection());
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
            //var sut1 = new ModularDbClient<MySqlConnection>();
            var sut2 = new ModularDbClient<MySqlConnection, MySqlCommand, MySqlParameter>();
            var sut3 = new ModularDbClient<MySqlConnection, MySqlCommand, MySqlParameter, MySqlConnectionStringBuilder>();
            //sut1.CreateCommand(cmdString);
            //sut1.CreateCommand(cmdString, sut1.GetConnection());
            sut2.CreateCommand(cmdString);
            sut2.CreateCommand(cmdString, sut2.CreateConnection());
            sut3.CreateCommand(cmdString);
            sut3.CreateCommand(cmdString, sut3.CreateConnection());
        }


        [TestMethod]
        [DataRow(typeof(IDbCommand))]
        [DataRow(typeof(SqlCommand))]
        public void Should_Return_InstanceOf_ForSqlCommand(Type t)
        {
            //var sut1 = new ModularDbClient<SqlConnection>();
            //AssertTypeMatches(sut1.CreateCommand(""), t);
            //AssertTypeMatches(sut1.CreateCommand("", sut1.GetConnection()), t);
            var sut2 = new ModularDbClient<SqlConnection, SqlCommand, SqlParameter>();
            AssertTypeMatches(sut2.CreateCommand(""), t);
            AssertTypeMatches(sut2.CreateCommand("", sut2.CreateConnection()), t);
            var sut3 = new ModularDbClient<SqlConnection, SqlCommand, SqlParameter, SqlConnectionStringBuilder>();
            AssertTypeMatches(sut3.CreateCommand(""), t);
            AssertTypeMatches(sut3.CreateCommand("", sut3.CreateConnection()), t);
        }

        [TestMethod]
        public void Should_ReturnNewInstance_ForSubsequentCalls()
        {
            //var sut1 = new ModularDbClient<SqlConnection>();
            var sut2 = new ModularDbClient<SqlConnection, SqlCommand, SqlParameter>();
            var sut3 = new ModularDbClient<SqlConnection, SqlCommand, SqlParameter, SqlConnectionStringBuilder>();

            //var notExpected = sut1.CreateCommand("");
            //var actual = sut1.CreateCommand("");
            //Assert.AreNotEqual(notExpected, actual);
            //Assert.AreNotSame(notExpected, actual);

            //var notExpected = sut1.CreateCommand("", sut1.GetConnection());
            //var actual = sut1.CreateCommand("", sut1.GetConnection());
            //Assert.AreNotEqual(notExpected, actual);
            //Assert.AreNotSame(notExpected, actual);

            var notExpected = sut2.CreateCommand("");
            var actual = sut2.CreateCommand("");
            Assert.AreNotEqual(notExpected, actual);
            Assert.AreNotSame(notExpected, actual);

            notExpected = sut2.CreateCommand("", sut2.CreateConnection());
            actual = sut2.CreateCommand("", sut2.CreateConnection());
            Assert.AreNotEqual(notExpected, actual);
            Assert.AreNotSame(notExpected, actual);

            notExpected = sut3.CreateCommand("");
            actual = sut3.CreateCommand("");
            Assert.AreNotEqual(notExpected, actual);
            Assert.AreNotSame(notExpected, actual);

            notExpected = sut3.CreateCommand("", sut3.CreateConnection());
            actual = sut3.CreateCommand("", sut3.CreateConnection());
            Assert.AreNotEqual(notExpected, actual);
            Assert.AreNotSame(notExpected, actual);

        }

    }
}