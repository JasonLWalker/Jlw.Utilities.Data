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
    public class GetConnection : BaseModelFixture<ModularDbClient<SqlConnection>, NullTestSchema<ModularDbClient<SqlConnection>>>
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
        public void Should_Accept_ConnectionString_ForMockConnection(string connString)
        {
            var sut1 = new ModularDbClient<MockDbConnection>();
            var sut2 = new ModularDbClient<MockDbConnection, NullDbCommand, MockDbParameter>();
            var sut3 = new ModularDbClient<MockDbConnection, NullDbCommand, MockDbParameter, DbConnectionStringBuilder>();
            sut1.GetConnection();
            sut1.GetConnection(connString);
            sut2.GetConnection();
            sut2.GetConnection(connString);
            sut3.GetConnection();
            sut3.GetConnection(connString);
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
        public void Should_Accept_ConnectionString_ForSQLiteConnection(string connString)
        {
            var sut1 = new ModularDbClient<SQLiteConnection>();
            var sut2 = new ModularDbClient<SQLiteConnection, SQLiteCommand, SQLiteParameter>();
            var sut3 = new ModularDbClient<SQLiteConnection, SQLiteCommand, SQLiteParameter, SQLiteConnectionStringBuilder>();
            sut1.GetConnection();
            sut1.GetConnection(connString);
            sut2.GetConnection();
            sut2.GetConnection(connString);
            sut3.GetConnection();
            sut3.GetConnection(connString);
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
            var sut1 = new ModularDbClient<SqlConnection>();
            var sut2 = new ModularDbClient<SqlConnection, SqlCommand, SqlParameter>();
            var sut3 = new ModularDbClient<SqlConnection, SqlCommand, SqlParameter, SqlConnectionStringBuilder>();
            sut1.GetConnection();
            sut1.GetConnection(connString);
            sut2.GetConnection();
            sut2.GetConnection(connString);
            sut3.GetConnection();
            sut3.GetConnection(connString);
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
            var sut1 = new ModularDbClient<MySqlConnection>();
            var sut2 = new ModularDbClient<MySqlConnection, MySqlCommand, MySqlParameter>();
            var sut3 = new ModularDbClient<MySqlConnection, MySqlCommand, MySqlParameter, MySqlConnectionStringBuilder>();
            sut1.GetConnection();
            sut1.GetConnection(connString);
            sut2.GetConnection();
            sut2.GetConnection(connString);
            sut3.GetConnection();
            sut3.GetConnection(connString);
        }

        /*
        [TestMethod]
        public void Should_Reject_ConnectionString_ForSQLiteConnection(string connString)
        {
            var sut1 = new ModularDbClient<SQLiteConnection>();
            var sut2 = new ModularDbClient<SQLiteConnection, SQLiteCommand, SQLiteParameter>();
            var sut3 = new ModularDbClient<SQLiteConnection, SQLiteCommand, SQLiteParameter, SQLiteConnectionStringBuilder>();
            Assert.ThrowsException<ArgumentNullException>(() => sut1.GetConnection(connString));
            Assert.ThrowsException<ArgumentNullException>(() => sut2.GetConnection(connString));
            Assert.ThrowsException<ArgumentNullException>(() => sut3.GetConnection(connString));
        }
        */

        [TestMethod]
        [DataRow("=")]
        [DataRow("\n=\t=\r= ")]
        [DataRow("test=123")]
        [DataRow("123")]
        [DataRow("test")]
        public void Should_Reject_ConnectionString_ForSqlServer(string connString)
        {
            var sut1 = new ModularDbClient<SqlConnection>();
            var sut2 = new ModularDbClient<SqlConnection, SqlCommand, SqlParameter>();
            var sut3 = new ModularDbClient<SqlConnection, SqlCommand, SqlParameter, SqlConnectionStringBuilder>();
            Assert.ThrowsException<ArgumentException>(() => sut1.GetConnection(connString));
            Assert.ThrowsException<ArgumentException>(() => sut2.GetConnection(connString));
            Assert.ThrowsException<ArgumentException>(() => sut3.GetConnection(connString));
        }

        [TestMethod]
        [DataRow("=")]
        [DataRow("\n=\t=\r= ")]
        [DataRow("test=123")]
        [DataRow("123")]
        [DataRow("test")]
        public void Should_Reject_ConnectionString_ForMySqlConnection(string connString)
        {
            var sut1 = new ModularDbClient<MySqlConnection>();
            var sut2 = new ModularDbClient<MySqlConnection, MySqlCommand, MySqlParameter>();
            var sut3 = new ModularDbClient<MySqlConnection, MySqlCommand, MySqlParameter, MySqlConnectionStringBuilder>();
            Assert.ThrowsException<ArgumentException>(() => sut1.GetConnection(connString));
            Assert.ThrowsException<ArgumentException>(() => sut2.GetConnection(connString));
            Assert.ThrowsException<ArgumentException>(() => sut3.GetConnection(connString));
        }

        [TestMethod]
        [DataRow(typeof(IDbConnection))]
        [DataRow(typeof(SqlConnection))]
        public void Should_Return_InstanceOf_ForSqlConnection(Type t)
        {
            var sut1 = new ModularDbClient<SqlConnection>();
            AssertTypeMatches(sut1.GetConnection(), t);
            AssertTypeMatches(sut1.GetConnection(""), t);
            var sut2 = new ModularDbClient<SqlConnection, SqlCommand, SqlParameter>();
            AssertTypeMatches(sut2.GetConnection(), t);
            AssertTypeMatches(sut2.GetConnection(""), t);
            var sut3 = new ModularDbClient<SqlConnection, SqlCommand, SqlParameter, SqlConnectionStringBuilder>();
            AssertTypeMatches(sut3.GetConnection(), t);
            AssertTypeMatches(sut3.GetConnection(""), t);
        }

        [TestMethod]
        public void Should_ReturnNewInstance_ForSubsequentCalls()
        {
            var sut1 = new ModularDbClient<SqlConnection>();
            var sut2 = new ModularDbClient<SqlConnection, SqlCommand, SqlParameter>();
            var sut3 = new ModularDbClient<SqlConnection, SqlCommand, SqlParameter, SqlConnectionStringBuilder>();

            var notExpected = sut1.GetConnection();
            var actual = sut1.GetConnection();
            Assert.AreNotEqual(notExpected, actual);
            Assert.AreNotSame(notExpected, actual);

            notExpected = sut1.GetConnection("");
            actual = sut1.GetConnection("");
            Assert.AreNotEqual(notExpected, actual);
            Assert.AreNotSame(notExpected, actual);

            notExpected = sut2.GetConnection();
            actual = sut2.GetConnection();
            Assert.AreNotEqual(notExpected, actual);
            Assert.AreNotSame(notExpected, actual);

            notExpected = sut2.GetConnection("");
            actual = sut2.GetConnection("");
            Assert.AreNotEqual(notExpected, actual);
            Assert.AreNotSame(notExpected, actual);

            notExpected = sut3.GetConnection();
            actual = sut3.GetConnection();
            Assert.AreNotEqual(notExpected, actual);
            Assert.AreNotSame(notExpected, actual);

            notExpected = sut3.GetConnection("");
            actual = sut3.GetConnection("");
            Assert.AreNotEqual(notExpected, actual);
            Assert.AreNotSame(notExpected, actual);
        }

    }
}