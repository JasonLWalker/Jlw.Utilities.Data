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
    public class CreateConnection : BaseModelFixture<ModularDbClient<SqlConnection, SqlCommand, SqlParameter, SqlConnectionStringBuilder>, NullTestSchema<ModularDbClient<SqlConnection, SqlCommand, SqlParameter, SqlConnectionStringBuilder>>>
    {
        [TestMethod]
        public void Test()
        {
            Assert.IsFalse(typeof(SqlCommand) == typeof(IDbCommand));
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
        public void Should_Accept_ConnectionString_ForMockConnection(string connString)
        {
            var sut1 = new ModularDbClient<MockDbConnection, NullDbCommand, MockDbParameter>();
            var sut2 = new ModularDbClient<MockDbConnection, NullDbCommand, MockDbParameter, DbConnectionStringBuilder>();
            sut1.CreateConnection();
            sut1.CreateConnection(connString);
            sut2.CreateConnection();
            sut2.CreateConnection(connString);
        }

        [TestMethod]
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
        public void Should_Accept_ConnectionString_ForSqliteConnection(string connString)
        {
            var sut1 = new ModularDbClient<SQLiteConnection, SQLiteCommand, SQLiteParameter>();
            var sut2 = new ModularDbClient<SQLiteConnection, SQLiteCommand, SQLiteParameter, SQLiteConnectionStringBuilder>();
            sut1.CreateConnection();
            sut1.CreateConnection(connString);
            sut2.CreateConnection();
            sut2.CreateConnection(connString);
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
            sut1.CreateConnection();
            sut1.CreateConnection(connString);
            sut2.CreateConnection();
            sut2.CreateConnection(connString);
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
            sut1.CreateConnection();
            sut1.CreateConnection(connString);
            sut2.CreateConnection();
            sut2.CreateConnection(connString);
        }


        [TestMethod]
        [DataRow(null)]
        public void Should_ThrowArgumentNullException_ForSQLiteConnection(string connString)
        {
            var sut1 = new ModularDbClient<SQLiteConnection, SQLiteCommand, SQLiteParameter>();
            var sut2 = new ModularDbClient<SQLiteConnection, SQLiteCommand, SQLiteParameter, SQLiteConnectionStringBuilder>();
            Assert.ThrowsException<ArgumentNullException>(() => sut1.CreateConnection(connString));
            Assert.ThrowsException<ArgumentNullException>(() => sut2.CreateConnection(connString));
        }

        [TestMethod]
        [DataRow("=")]
        [DataRow("\n=\t=\r= ")]
        [DataRow("test=123")]
        [DataRow("123")]
        [DataRow("test")]
        public void Should_Reject_ConnectionString_ForSqlServer(string connString)
        {
            var sut1 = new ModularDbClient<SqlConnection, SqlCommand, SqlParameter>();
            var sut2 = new ModularDbClient<SqlConnection, SqlCommand, SqlParameter, SqlConnectionStringBuilder>();
            Assert.ThrowsException<ArgumentException>(() => sut1.CreateConnection(connString));
            Assert.ThrowsException<ArgumentException>(() => sut2.CreateConnection(connString));
        }

        [TestMethod]
        [DataRow("=")]
        [DataRow("\n=\t=\r= ")]
        [DataRow("test=123")]
        [DataRow("123")]
        [DataRow("test")]
        public void Should_Reject_ConnectionString_ForMySqlConnection(string connString)
        {
            var sut1 = new ModularDbClient<MySqlConnection, MySqlCommand, MySqlParameter>();
            var sut2 = new ModularDbClient<MySqlConnection, MySqlCommand, MySqlParameter, MySqlConnectionStringBuilder>();
            Assert.ThrowsException<ArgumentException>(() => sut1.CreateConnection(connString));
            Assert.ThrowsException<ArgumentException>(() => sut2.CreateConnection(connString));
        }


        [TestMethod]
        [DataRow(typeof(IDbConnection))]
        [DataRow(typeof(SqlConnection))]
        public void Should_Return_InstanceOf(Type t)
        {
            var sut1 = new ModularDbClient<SqlConnection, SqlCommand, SqlParameter>();
            var sut2 = new ModularDbClient<SqlConnection, SqlCommand, SqlParameter, SqlConnectionStringBuilder>();
            AssertTypeMatches(sut1.CreateConnection(), t);
            AssertTypeMatches(sut1.CreateConnection(""), t);
            AssertTypeMatches(sut2.CreateConnection(), t);
            AssertTypeMatches(sut2.CreateConnection(""), t);
        }

        [TestMethod]
        public void Should_ReturnNewInstance_ForSubsequentCalls()
        {
            var sut1 = new ModularDbClient<SqlConnection, SqlCommand, SqlParameter>();
            var sut2 = new ModularDbClient<SqlConnection, SqlCommand, SqlParameter, SqlConnectionStringBuilder>();
            var notExpected = sut1.CreateConnection();
            var actual = sut1.CreateConnection();
            Assert.AreNotEqual(notExpected, actual);
            Assert.AreNotSame(notExpected, actual);
            notExpected = sut1.CreateConnection("");
            actual = sut1.CreateConnection("");
            Assert.AreNotEqual(notExpected, actual);
            Assert.AreNotSame(notExpected, actual);
            notExpected = sut2.CreateConnection();
            actual = sut2.CreateConnection();
            Assert.AreNotEqual(notExpected, actual);
            Assert.AreNotSame(notExpected, actual);
            notExpected = sut2.CreateConnection("");
            actual = sut2.CreateConnection("");
            Assert.AreNotEqual(notExpected, actual);
            Assert.AreNotSame(notExpected, actual);
        }

    }
}