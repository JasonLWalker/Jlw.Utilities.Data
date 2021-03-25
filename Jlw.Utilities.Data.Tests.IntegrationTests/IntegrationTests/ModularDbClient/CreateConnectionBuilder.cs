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
    public class CreateConnectionBuilder : BaseModelFixture<ModularDbClient<SqlConnection>>
    {
        [TestMethod]
        [DataRow(null)]
        [DataRow("")]
        [DataRow("\n\t\r ")]
        [DataRow("\n;\t;\r; ;;")]
        [DataRow("test=123")]
        [DataRow("Server=123;")]
        [DataRow("Server=MyServer123;User Id=test;Initial Catalog=TestDb")]
        public void Should_Accept_ConnectionString_ForMockConnection(string connString)
        {
            var sut1 = new ModularDbClient<MockDbConnection, SqlCommand, SqlParameter>();
            var sut2 = new ModularDbClient<MockDbConnection, SqlCommand, SqlParameter, DbConnectionStringBuilder>();
            sut1.CreateConnectionBuilder(connString);
            sut2.CreateConnectionBuilder(connString);
        }

        [TestMethod]
        [DataRow(null)]
        [DataRow("")]
        [DataRow("\n\t\r ")]
        [DataRow("\n;\t;\r; ;;")]
        [DataRow("test=123")]
        [DataRow("Server=123;")]
        [DataRow("Server=MyServer123;User Id=test;Initial Catalog=TestDb")]
        public void Should_Accept_ConnectionString_ForSQLiteConnection(string connString)
        {
            var sut1 = new ModularDbClient<SQLiteConnection, SQLiteCommand, SQLiteParameter>();
            var sut2 = new ModularDbClient<SQLiteConnection, SQLiteCommand, SQLiteParameter, SQLiteConnectionStringBuilder>();
            sut1.CreateConnectionBuilder(connString);
            sut2.CreateConnectionBuilder(connString);
        }

        [TestMethod]
        [DataRow(null)]
        [DataRow("")]
        [DataRow("\n\t\r ")]
        [DataRow("\n;\t;\r; ;;")]
        [DataRow("Server=123;")]
        [DataRow("Server=MyServer123;User Id=test;Initial Catalog=TestDb")]
        public void Should_Accept_ConnectionString_ForSqlServer(string connString)
        {
            var sut1 = new ModularDbClient<SqlConnection, SqlCommand, SqlParameter>();
            var sut2 = new ModularDbClient<SqlConnection, SqlCommand, SqlParameter, SqlConnectionStringBuilder>();
            sut1.CreateConnectionBuilder(connString);
            sut2.CreateConnectionBuilder(connString);
        }

        [TestMethod]
        [DataRow(null)]
        [DataRow("")]
        [DataRow("\n\t\r ")]
        [DataRow("\n;\t;\r; ;;")]
        [DataRow("Server=123;")]
        [DataRow("Server=MyServer123;User Id=test;Initial Catalog=TestDb")]
        public void Should_Accept_ConnectionString_ForMySqlConnection(string connString)
        {
            var sut1 = new ModularDbClient<MySqlConnection, MySqlCommand, MySqlParameter>();
            var sut2 = new ModularDbClient<MySqlConnection, MySqlCommand, MySqlParameter, MySqlConnectionStringBuilder>();
            sut1.CreateConnectionBuilder(connString);
            sut2.CreateConnectionBuilder(connString);
        }


        [TestMethod]
        [DataRow("=")]
        [DataRow("\n=\t=\r= ")]
        [DataRow("123")]
        [DataRow("test")]
        public void Should_Reject_ConnectionString_ForSQLiteConnection(string connString)
        {
            //var sut1 = new ModularDbClient<SQLiteConnection, SQLiteCommand, SQLiteParameter>();
            var sut2 = new ModularDbClient<SQLiteConnection, SQLiteCommand, SQLiteParameter, SQLiteConnectionStringBuilder>();
            //Assert.ThrowsException<ArgumentNullException>(() => sut1.CreateConnectionBuilder(connString));
            Assert.ThrowsException<ArgumentException>(() => sut2.CreateConnectionBuilder(connString));
        }

        [TestMethod]
        [DataRow("=")]
        [DataRow("\n=\t=\r= ")]
        [DataRow("test=123")]
        [DataRow("123")]
        [DataRow("test")]
        //[ExpectedException(typeof(ArgumentException))]
        public void Should_Reject_ConnectionString_ForSqlServer(string connString)
        {
            //var sut1 = new ModularDbClient<SqlConnection, SqlCommand, SqlParameter>();
            var sut2 = new ModularDbClient<SqlConnection, SqlCommand, SqlParameter, SqlConnectionStringBuilder>();
            //Assert.ThrowsException<ArgumentException>(() => sut1.CreateConnectionBuilder(connString));
            Assert.ThrowsException<ArgumentException>(() => sut2.CreateConnectionBuilder(connString));
        }

        [TestMethod]
        [DataRow("=")]
        [DataRow("\n=\t=\r= ")]
        [DataRow("test=123")]
        [DataRow("123")]
        [DataRow("test")]
        public void Should_Reject_ConnectionString_ForMySqlConnection(string connString)
        {
            //var sut1 = new ModularDbClient<MySqlConnection, MySqlCommand, MySqlParameter>();
            var sut2 = new ModularDbClient<MySqlConnection, MySqlCommand, MySqlParameter, MySqlConnectionStringBuilder>();
            //Assert.ThrowsException<ArgumentException>(() => sut1.CreateConnectionBuilder(connString));
            Assert.ThrowsException<ArgumentException>(() => sut2.CreateConnectionBuilder(connString));
        }


        [TestMethod]
        [DataRow(typeof(SqlConnectionStringBuilder))]
        public void Should_Return_InstanceOf_ForSqlConnection(Type t)
        {
            //var sut1 = new ModularDbClient<SqlConnection, SqlCommand, SqlParameter>();
            //AssertTypeMatches(sut1.CreateConnectionBuilder(), t);
            //AssertTypeMatches(sut1.CreateConnectionBuilder(""), t);
            var sut2 = new ModularDbClient<SqlConnection, SqlCommand, SqlParameter,SqlConnectionStringBuilder>();
            AssertTypeMatches(sut2.CreateConnectionBuilder(), t);
            AssertTypeMatches(sut2.CreateConnectionBuilder(""), t);
        }

        [TestMethod]
        public void Should_ReturnNewInstance_ForSubsequentCalls()
        {
            var sut1 = new ModularDbClient<SqlConnection, SqlCommand, SqlParameter>();
            var sut2 = new ModularDbClient<SqlConnection, SqlCommand, SqlParameter, SqlConnectionStringBuilder>();

            var notExpected = sut1.CreateConnectionBuilder();
            var actual = sut1.CreateConnectionBuilder();
            Assert.AreNotEqual(notExpected, actual);
            Assert.AreNotSame(notExpected, actual);

            notExpected = sut1.CreateConnectionBuilder("");
            actual = sut1.CreateConnectionBuilder("");
            Assert.AreNotEqual(notExpected, actual);
            Assert.AreNotSame(notExpected, actual);

            notExpected = sut2.CreateConnectionBuilder();
            actual = sut2.CreateConnectionBuilder();
            Assert.AreNotEqual(notExpected, actual);
            Assert.AreNotSame(notExpected, actual);

            notExpected = sut2.CreateConnectionBuilder("");
            actual = sut2.CreateConnectionBuilder("");
            Assert.AreNotEqual(notExpected, actual);
            Assert.AreNotSame(notExpected, actual);
        }

    }
}