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
    public class GetConnectionBuilder : BaseModelFixture<ModularDbClient<SqlConnection>>
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
            var sut1 = new ModularDbClient<MockDbConnection>();
            var sut2 = new ModularDbClient<MockDbConnection, SqlCommand, SqlParameter>();
            var sut3 = new ModularDbClient<MockDbConnection, SqlCommand, SqlParameter, DbConnectionStringBuilder>();
            sut1.GetConnectionBuilder();
            sut1.GetConnectionBuilder(connString);
            sut2.GetConnectionBuilder();
            sut2.GetConnectionBuilder(connString);
            sut3.GetConnectionBuilder();
            sut3.GetConnectionBuilder(connString);
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
            var sut1 = new ModularDbClient<SQLiteConnection>();
            var sut2 = new ModularDbClient<SQLiteConnection, SQLiteCommand, SQLiteParameter>();
            var sut3 = new ModularDbClient<SQLiteConnection, SQLiteCommand, SQLiteParameter, SQLiteConnectionStringBuilder>();
            sut1.GetConnectionBuilder();
            sut1.GetConnectionBuilder(connString);
            sut2.GetConnectionBuilder();
            sut2.GetConnectionBuilder(connString);
            sut3.GetConnectionBuilder();
            sut3.GetConnectionBuilder(connString);
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
            sut1.GetConnectionBuilder();
            sut1.GetConnectionBuilder(connString);
            sut2.GetConnectionBuilder();
            sut2.GetConnectionBuilder(connString);
            sut3.GetConnectionBuilder();
            sut3.GetConnectionBuilder(connString);
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
            sut1.GetConnectionBuilder();
            sut1.GetConnectionBuilder(connString);
            sut2.GetConnectionBuilder();
            sut2.GetConnectionBuilder(connString);
            sut3.GetConnectionBuilder();
            sut3.GetConnectionBuilder(connString);
        }

        [TestMethod]
        [DataRow("=")]
        [DataRow("\n=\t=\r= ")]
        [DataRow("123")]
        [DataRow("test")]
        public void Should_Reject_ConnectionString_ForSQLiteConnection(string connString)
        {
            var sut1 = new ModularDbClient<SQLiteConnection>();
            var sut2 = new ModularDbClient<SQLiteConnection, SQLiteCommand, SQLiteParameter>();
            var sut3 = new ModularDbClient<SQLiteConnection, SQLiteCommand, SQLiteParameter, SQLiteConnectionStringBuilder>();
            Assert.ThrowsException<ArgumentException>(() => sut1.GetConnectionBuilder(connString));
            Assert.ThrowsException<ArgumentException>(() => sut2.GetConnectionBuilder(connString));
            Assert.ThrowsException<ArgumentException>(() => sut3.GetConnectionBuilder(connString));
        }

        [TestMethod]
        [DataRow("=")]
        [DataRow("\n=\t=\r= ")]
        //[DataRow("test=123")]
        [DataRow("123")]
        [DataRow("test")]
        public void Should_Reject_ConnectionString_ForSqlServer(string connString)
        {
            var sut1 = new ModularDbClient<SqlConnection>();
            var sut2 = new ModularDbClient<SqlConnection, SqlCommand, SqlParameter>();
            var sut3 = new ModularDbClient<SqlConnection, SqlCommand, SqlParameter, SqlConnectionStringBuilder>();
            Assert.ThrowsException<ArgumentException>(() => sut1.GetConnectionBuilder(connString));
            Assert.ThrowsException<ArgumentException>(() => sut2.GetConnectionBuilder(connString));
            Assert.ThrowsException<ArgumentException>(() => sut3.GetConnectionBuilder(connString));
        }

        [TestMethod]
        [DataRow("=")]
        [DataRow("\n=\t=\r= ")]
        //[DataRow("test=123")]
        [DataRow("123")]
        [DataRow("test")]
        public void Should_Reject_ConnectionString_ForMySqlConnection(string connString)
        {
            var sut1 = new ModularDbClient<MySqlConnection>();
            var sut2 = new ModularDbClient<MySqlConnection, MySqlCommand, MySqlParameter>();
            var sut3 = new ModularDbClient<MySqlConnection, MySqlCommand, MySqlParameter, MySqlConnectionStringBuilder>(); 
            Assert.ThrowsException<ArgumentException>(() => sut1.GetConnectionBuilder(connString));
            Assert.ThrowsException<ArgumentException>(() => sut2.GetConnectionBuilder(connString));
            Assert.ThrowsException<ArgumentException>(() => sut3.GetConnectionBuilder(connString));
        }


        [TestMethod]
        [DataRow(typeof(SqlConnectionStringBuilder))]
        public void Should_Return_InstanceOf_ForSqlConnection(Type t)
        {
            var sut1 = new ModularDbClient<SqlConnection>();
            AssertTypeMatches(sut1.GetConnectionBuilder(), typeof(DbConnectionStringBuilder));
            AssertTypeMatches(sut1.GetConnectionBuilder(""), typeof(DbConnectionStringBuilder));
            var sut2 = new ModularDbClient<SqlConnection, SqlCommand, SqlParameter>();
            AssertTypeMatches(sut2.GetConnectionBuilder(), typeof(DbConnectionStringBuilder));
            AssertTypeMatches(sut2.GetConnectionBuilder(""), typeof(DbConnectionStringBuilder));
            var sut3 = new ModularDbClient<SqlConnection, SqlCommand, SqlParameter,SqlConnectionStringBuilder>();
            AssertTypeMatches(sut3.GetConnectionBuilder(), t);
            AssertTypeMatches(sut3.GetConnectionBuilder(""), t);
        }

        [TestMethod]
        public void Should_ReturnNewInstance_ForSubsequentCalls()
        {
            var sut1 = new ModularDbClient<SqlConnection>();
            var sut2 = new ModularDbClient<SqlConnection, SqlCommand, SqlParameter>();
            var sut3 = new ModularDbClient<SqlConnection, SqlCommand, SqlParameter, SqlConnectionStringBuilder>();

            var notExpected = sut1.GetConnectionBuilder();
            var actual = sut1.GetConnectionBuilder();
            Assert.AreNotEqual(notExpected, actual);
            Assert.AreNotSame(notExpected, actual);

            notExpected = sut1.GetConnectionBuilder("");
            actual = sut1.GetConnectionBuilder("");
            Assert.AreNotEqual(notExpected, actual);
            Assert.AreNotSame(notExpected, actual);

            notExpected = sut2.GetConnectionBuilder();
            actual = sut2.GetConnectionBuilder();
            Assert.AreNotEqual(notExpected, actual);
            Assert.AreNotSame(notExpected, actual);

            notExpected = sut2.GetConnectionBuilder("");
            actual = sut2.GetConnectionBuilder("");
            Assert.AreNotEqual(notExpected, actual);
            Assert.AreNotSame(notExpected, actual);

            notExpected = sut3.GetConnectionBuilder();
            actual = sut3.GetConnectionBuilder();
            Assert.AreNotEqual(notExpected, actual);
            Assert.AreNotSame(notExpected, actual);

            notExpected = sut3.GetConnectionBuilder("");
            actual = sut3.GetConnectionBuilder("");
            Assert.AreNotEqual(notExpected, actual);
            Assert.AreNotSame(notExpected, actual);
        }

    }
}