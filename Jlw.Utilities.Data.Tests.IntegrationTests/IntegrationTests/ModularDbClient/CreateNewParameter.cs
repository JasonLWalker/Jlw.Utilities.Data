﻿using System;
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
    public class CreateNewParameter : BaseModelFixture<ModularDbClient<SqlConnection>, NullTestSchema<ModularDbClient<SqlConnection>>>
    {
        protected IDbDataParameter Param1 = new MockDbParameter()
        {
            DbType = DbType.Int16,
            Direction = ParameterDirection.InputOutput,
            ParameterName = "testParam1",
            SourceColumn = "TestParam1",
            SourceVersion = DataRowVersion.Proposed,
            Value = (Int16)12345,
            Precision = 3,
            Scale = 7,
            Size = 10
        };

        protected IDbDataParameter Param2 = new MockDbParameter()
        {
            DbType = DbType.Decimal,
            Direction = ParameterDirection.Input,
            ParameterName = "testParam2",
            SourceColumn = "TestParam2",
            SourceVersion = DataRowVersion.Current,
            Value = 1234.12,
            Precision = 5,
            Scale = 3,
            Size = 11
        };

        protected IDbDataParameter Param3 = new MockDbParameter()
        {
            DbType = DbType.Boolean,
            Direction = ParameterDirection.Output,
            ParameterName = "testParam3",
            SourceColumn = "TestParam3",
            SourceVersion = DataRowVersion.Default,
            Value = true,
            Precision = 5,
            Scale = 3,
            Size = 1
        };

        protected IDbDataParameter Param4 = new MockDbParameter()
        {
            DbType = DbType.String,
            Direction = ParameterDirection.Output,
            ParameterName = "testParam4",
            SourceColumn = "TestParam4",
            SourceVersion = DataRowVersion.Original,
            Value = "this is a test",
            Precision = 0,
            Scale = 0,
            Size = 14
        };

        protected SQLiteParameter SQLiteParam1 = new SQLiteParameter()
        {
            DbType = DbType.Int16,
            //Direction = ParameterDirection.InputOutput,
            ParameterName = "testParam1",
            SourceColumn = "TestParam1",
            SourceVersion = DataRowVersion.Proposed,
            Value = (Int16?)12345,
            Precision = 3,
            Scale = 7,
            Size = 10
        };

        protected SQLiteParameter SQLiteParam2 = new SQLiteParameter()
        {
            DbType = DbType.Decimal,
            //Direction = ParameterDirection.Input,
            ParameterName = "testParam2",
            SourceColumn = "TestParam2",
            SourceVersion = DataRowVersion.Current,
            Value = 1234.12,
            Precision = 5,
            Scale = 3,
            Size = 11
        };

        protected SQLiteParameter SQLiteParam3 = new SQLiteParameter()
        {
            DbType = DbType.Boolean,
            //Direction = ParameterDirection.Output,
            ParameterName = "testParam3",
            SourceColumn = "TestParam3",
            SourceVersion = DataRowVersion.Default,
            Value = true,
            Precision = 5,
            Scale = 3,
            Size = 1
        };

        protected SQLiteParameter SQLiteParam4 = new SQLiteParameter()
        {
            DbType = DbType.String,
            //Direction = ParameterDirection.Output,
            ParameterName = "testParam4",
            SourceColumn = "TestParam4",
            SourceVersion = DataRowVersion.Original,
            Value = "this is a test",
            Precision = 0,
            Scale = 0,
            Size = 30
        };

        protected SqlParameter SqlParam1 = new SqlParameter()
        {
            DbType = DbType.Int16,
            Direction = ParameterDirection.InputOutput,
            ParameterName = "testParam1",
            SourceColumn = "TestParam1",
            SourceVersion = DataRowVersion.Proposed,
            Value = (Int16?)12345,
            Precision = 3,
            Scale = 7,
            Size = 10
        };

        protected SqlParameter SqlParam2 = new SqlParameter()
        {
            DbType = DbType.Decimal,
            Direction = ParameterDirection.Input,
            ParameterName = "testParam2",
            SourceColumn = "TestParam2",
            SourceVersion = DataRowVersion.Current,
            Value = 1234.12,
            Precision = 5,
            Scale = 3,
            Size = 11
        };

        protected SqlParameter SqlParam3 = new SqlParameter()
        {
            DbType = DbType.Boolean,
            Direction = ParameterDirection.Output,
            ParameterName = "testParam3",
            SourceColumn = "TestParam3",
            SourceVersion = DataRowVersion.Default,
            Value = true,
            Precision = 5,
            Scale = 3,
            Size = 1
        };

        protected SqlParameter SqlParam4 = new SqlParameter()
        {
            DbType = DbType.String,
            Direction = ParameterDirection.Output,
            ParameterName = "testParam4",
            SourceColumn = "TestParam4",
            SourceVersion = DataRowVersion.Original,
            Value = "this is a test",
            Precision = 0,
            Scale = 0,
            Size = 30
        };

        protected MySqlParameter MySqlParam1 = new MySqlParameter()
        {
            DbType = DbType.Int16,
            Direction = ParameterDirection.InputOutput,
            ParameterName = "testParam1",
            SourceColumn = "TestParam1",
            SourceVersion = DataRowVersion.Proposed,
            Value = (Int16?)12345,
            Precision = 3,
            Scale = 7,
            Size = 10
        };

        protected MySqlParameter MySqlParam2 = new MySqlParameter()
        {
            DbType = DbType.Decimal,
            Direction = ParameterDirection.Input,
            ParameterName = "testParam2",
            SourceColumn = "TestParam2",
            SourceVersion = DataRowVersion.Current,
            Value = 1234.12,
            Precision = 5,
            Scale = 3,
            Size = 11
        };

        protected MySqlParameter MySqlParam3 = new MySqlParameter()
        {
            DbType = DbType.Boolean,
            Direction = ParameterDirection.Output,
            ParameterName = "testParam3",
            SourceColumn = "TestParam3",
            SourceVersion = DataRowVersion.Default,
            Value = true,
            Precision = 5,
            Scale = 3,
            Size = 1
        };

        protected MySqlParameter MySqlParam4 = new MySqlParameter()
        {
            DbType = DbType.String,
            Direction = ParameterDirection.Output,
            ParameterName = "testParam4",
            SourceColumn = "TestParam4",
            SourceVersion = DataRowVersion.Original,
            Value = "this is a test",
            Precision = 0,
            Scale = 0,
            Size = 14
        };



        protected void AssertParamsMatch1(IDbDataParameter param1, IDbDataParameter param2)
        {
            Assert.AreEqual(param1.DbType, param2.DbType);
            //Assert.AreEqual(param1.Direction, param2.Direction);
            //Assert.AreEqual(param1.IsNullable, param2.IsNullable);
            Assert.AreEqual(param1.ParameterName, param2.ParameterName);
            Assert.AreEqual(param1.SourceColumn, param2.SourceColumn);
            //Assert.AreEqual(param1.SourceVersion, param2.SourceVersion);
            Assert.AreEqual(param1.Value, param2.Value);
            //Assert.AreEqual(param1.Precision, param2.Precision);
            //Assert.AreEqual(param1.Scale, param2.Scale);
            Assert.AreEqual(param1.Size, param2.Size);
        }

        protected void AssertParamsMatch2(IDbDataParameter param1, IDbDataParameter param2)
        {
            Assert.AreEqual(param1.DbType, param2.DbType);
            Assert.AreEqual(param1.Direction, param2.Direction);
            Assert.AreEqual(param1.IsNullable, param2.IsNullable);
            Assert.AreEqual(param1.ParameterName, param2.ParameterName);
            Assert.AreEqual(param1.SourceColumn, param2.SourceColumn);
            Assert.AreEqual(param1.SourceVersion, param2.SourceVersion);
            Assert.AreEqual(param1.Value, param2.Value);
            Assert.AreEqual(param1.Precision, param2.Precision);
            Assert.AreEqual(param1.Scale, param2.Scale);
            Assert.AreEqual(param1.Size, param2.Size);
        }

        [TestMethod]
        public void Should_Match_ForMockDbConnection()
        {
            var sut1 = new ModularDbClient<MockDbConnection>();
            var sut2 = new ModularDbClient<MockDbConnection, NullDbCommand, MockDbParameter>();
            var sut3 = new ModularDbClient<MockDbConnection, NullDbCommand, MockDbParameter, DbConnectionStringBuilder>();

            var p1 = sut2.CreateNewParameter();
            AssertTypeMatches(p1, typeof(MockDbParameter));
            p1.DbType = DbType.Int16;
            p1.Direction = ParameterDirection.InputOutput;
            p1.ParameterName = "testParam1";
            p1.SourceColumn = "TestParam1";
            p1.SourceVersion = DataRowVersion.Proposed;
            p1.Value = (Int16?)12345;
            p1.Precision = 3;
            p1.Scale = 7;
            p1.Size = 10;
            AssertParamsMatch1(p1, Param1);

            var p2 = sut2.CreateNewParameter();
            AssertTypeMatches(p2, typeof(MockDbParameter));
            p2.DbType = DbType.Decimal;
            p2.Direction = ParameterDirection.InputOutput;
            p2.ParameterName = "testParam2";
            p2.SourceColumn = "TestParam2";
            p2.SourceVersion = DataRowVersion.Current;
            p2.Value = 1234.12;
            p2.Precision = 5;
            p2.Scale = 3;
            p2.Size = 11;
            AssertParamsMatch1(p2, Param2);

            var p3 = sut3.CreateNewParameter();
            AssertTypeMatches(p3, typeof(MockDbParameter));
            p3.DbType = DbType.Boolean;
            p3.Direction = ParameterDirection.InputOutput;
            p3.ParameterName = "testParam3";
            p3.SourceColumn = "TestParam3";
            p3.SourceVersion = DataRowVersion.Default;
            p3.Value = true;
            p3.Precision = 5;
            p3.Scale = 3;
            p3.Size = 1;
            AssertParamsMatch1(p3, Param3);

            var p4 = sut3.CreateNewParameter();
            AssertTypeMatches(p4, typeof(MockDbParameter));
            p4.DbType = DbType.String;
            p4.Direction = ParameterDirection.InputOutput;
            p4.ParameterName = "testParam4";
            p4.SourceColumn = "TestParam4";
            p4.SourceVersion = DataRowVersion.Original;
            p4.Value = "this is a test";
            p4.Precision = 5;
            p4.Scale = 3;
            p4.Size = 14;
            AssertParamsMatch1(p4, Param4);

        }

        [TestMethod]
        public void Should_MatchCopy_ForMockDbConnection()
        {
            var sut1 = new ModularDbClient<MockDbConnection>();
            var sut2 = new ModularDbClient<MockDbConnection, NullDbCommand, MockDbParameter>();
            var sut3 = new ModularDbClient<MockDbConnection, NullDbCommand, MockDbParameter, DbConnectionStringBuilder>();

            var p1 = sut2.CreateNewParameter(Param1);
            AssertTypeMatches(p1, typeof(MockDbParameter));
            AssertParamsMatch1(p1, Param1);

            var p2 = sut2.CreateNewParameter(Param2);
            AssertTypeMatches(p2, typeof(MockDbParameter));
            AssertParamsMatch1(p2, Param2);

            var p3 = sut3.CreateNewParameter(Param3);
            AssertTypeMatches(p3, typeof(MockDbParameter));
            AssertParamsMatch1(p3, Param3);

            var p4 = sut3.CreateNewParameter(Param4);
            AssertTypeMatches(p4, typeof(MockDbParameter));
            AssertParamsMatch1(p4, Param4);

        }

        [TestMethod]
        public void Should_Match_ForSQLiteConnection()
        {
            var sut1 = new ModularDbClient<SQLiteConnection>();
            var sut2 = new ModularDbClient<SQLiteConnection, SQLiteCommand, SQLiteParameter>();
            var sut3 = new ModularDbClient<SQLiteConnection, SQLiteCommand, SQLiteParameter, SQLiteConnectionStringBuilder>();
            
            var p1 = sut2.CreateNewParameter();
            AssertTypeMatches(p1, typeof(SQLiteParameter));
            p1.DbType = DbType.Int16;
            //p1.Direction = ParameterDirection.InputOutput;
            p1.ParameterName = "testParam1";
            p1.SourceColumn = "TestParam1";
            p1.SourceVersion = DataRowVersion.Proposed;
            p1.Value = (Int16?)12345;
            p1.Precision = 3;
            p1.Scale = 7;
            p1.Size = 10;
            AssertParamsMatch1(p1, Param1);

            var p2 = sut2.CreateNewParameter();
            AssertTypeMatches(p2, typeof(SQLiteParameter));
            p2.DbType = DbType.Decimal;
            //p2.Direction = ParameterDirection.InputOutput;
            p2.ParameterName = "testParam2";
            p2.SourceColumn = "TestParam2";
            p2.SourceVersion = DataRowVersion.Current;
            p2.Value = 1234.12;
            p2.Precision = 5;
            p2.Scale = 3;
            p2.Size = 11;
            AssertParamsMatch1(p2, Param2);

            var p3 = sut3.CreateNewParameter();
            AssertTypeMatches(p3, typeof(SQLiteParameter));
            p3.DbType = DbType.Boolean;
            //p3.Direction = ParameterDirection.InputOutput;
            p3.ParameterName = "testParam3";
            p3.SourceColumn = "TestParam3";
            p3.SourceVersion = DataRowVersion.Default;
            p3.Value = true;
            p3.Precision = 5;
            p3.Scale = 3;
            p3.Size = 1;
            AssertParamsMatch1(p3, Param3);

            var p4 = sut3.CreateNewParameter();
            AssertTypeMatches(p4, typeof(SQLiteParameter));
            p4.DbType = DbType.String;
            //p4.Direction = ParameterDirection.InputOutput;
            p4.ParameterName = "testParam4";
            p4.SourceColumn = "TestParam4";
            p4.SourceVersion = DataRowVersion.Original;
            p4.Value = "this is a test";
            p4.Precision = 5;
            p4.Scale = 3;
            p4.Size = 14;
            AssertParamsMatch1(p4, Param4);

        }

        [TestMethod]
        public void Should_MatchCopy_ForSQLiteConnection()
        {
            var sut1 = new ModularDbClient<SQLiteConnection>();
            var sut2 = new ModularDbClient<SQLiteConnection, SQLiteCommand, SQLiteParameter>();
            var sut3 = new ModularDbClient<SQLiteConnection, SQLiteCommand, SQLiteParameter, SQLiteConnectionStringBuilder>();

            var p1 = sut2.CreateNewParameter(SQLiteParam1);
            AssertTypeMatches(p1, typeof(SQLiteParameter));
            AssertParamsMatch1(p1, SQLiteParam1);

            var p2 = sut2.CreateNewParameter(SQLiteParam2);
            AssertTypeMatches(p2, typeof(SQLiteParameter));
            AssertParamsMatch1(p2, SQLiteParam2);

            var p3 = sut3.CreateNewParameter(SQLiteParam3);
            AssertTypeMatches(p3, typeof(SQLiteParameter));
            AssertParamsMatch1(p3, SQLiteParam3);

            var p4 = sut3.CreateNewParameter(SQLiteParam4);
            AssertTypeMatches(p4, typeof(SQLiteParameter));
            AssertParamsMatch1(p4, SQLiteParam4);

        }

        [TestMethod]
        public void Should_MatchMockedCopy_ForSQLiteConnection()
        {
            var sut1 = new ModularDbClient<SQLiteConnection>();
            var sut2 = new ModularDbClient<SQLiteConnection, SQLiteCommand, SQLiteParameter>();
            var sut3 = new ModularDbClient<SQLiteConnection, SQLiteCommand, SQLiteParameter, SQLiteConnectionStringBuilder>();

            var p1 = sut2.CreateNewParameter(Param1);
            AssertTypeMatches(p1, typeof(SQLiteParameter));
            AssertParamsMatch1(p1, Param1);

            var p2 = sut2.CreateNewParameter(Param2);
            AssertTypeMatches(p2, typeof(SQLiteParameter));
            AssertParamsMatch1(p2, Param2);

            var p3 = sut3.CreateNewParameter(Param3);
            AssertTypeMatches(p3, typeof(SQLiteParameter));
            AssertParamsMatch1(p3, Param3);

            var p4 = sut3.CreateNewParameter(Param4);
            AssertTypeMatches(p4, typeof(SQLiteParameter));
            AssertParamsMatch1(p4, Param4);

        }


        [TestMethod]
        public void Should_Match_ForSqlServer()
        {
            var sut1 = new ModularDbClient<SqlConnection>();
            var sut2 = new ModularDbClient<SqlConnection, SqlCommand, SqlParameter>();
            var sut3 = new ModularDbClient<SqlConnection, SqlCommand, SqlParameter, SqlConnectionStringBuilder>();

            var p1 = sut2.CreateNewParameter();
            AssertTypeMatches(p1, typeof(SqlParameter));
            p1.DbType = DbType.Int16;
            p1.Direction = ParameterDirection.InputOutput;
            p1.ParameterName = "testParam1";
            p1.SourceColumn = "TestParam1";
            p1.SourceVersion = DataRowVersion.Proposed;
            p1.Value = (Int16?)12345;
            p1.Precision = 3;
            p1.Scale = 7;
            p1.Size = 10;
            AssertParamsMatch2(p1, Param1);

            var p2 = sut2.CreateNewParameter();
            AssertTypeMatches(p2, typeof(SqlParameter));
            p2.DbType = DbType.Decimal;
            p2.Direction = ParameterDirection.Input;
            p2.ParameterName = "testParam2";
            p2.SourceColumn = "TestParam2";
            p2.SourceVersion = DataRowVersion.Current;
            p2.Value = 1234.12;
            p2.Precision = 5;
            p2.Scale = 3;
            p2.Size = 11;
            AssertParamsMatch2(p2, Param2);

            var p3 = sut3.CreateNewParameter();
            AssertTypeMatches(p3, typeof(SqlParameter));
            p3.DbType = DbType.Boolean;
            p3.Direction = ParameterDirection.Output;
            p3.ParameterName = "testParam3";
            p3.SourceColumn = "TestParam3";
            p3.SourceVersion = DataRowVersion.Default;
            p3.Value = true;
            p3.Precision = 5;
            p3.Scale = 3;
            p3.Size = 1;
            AssertParamsMatch2(p3, Param3);

            var p4 = sut3.CreateNewParameter();
            AssertTypeMatches(p4, typeof(SqlParameter));
            p4.DbType = DbType.String;
            p4.Direction = ParameterDirection.Output;
            p4.ParameterName = "testParam4";
            p4.SourceColumn = "TestParam4";
            p4.SourceVersion = DataRowVersion.Original;
            p4.Value = "this is a test";
            p4.Precision = 0;
            p4.Scale = 0;
            p4.Size = 14;
            AssertParamsMatch2(p4, Param4);

        }
        
        [TestMethod]
        public void Should_MatchCopy_ForSqlConnection()
        {
            var sut1 = new ModularDbClient<SqlConnection>();
            var sut2 = new ModularDbClient<SqlConnection, SqlCommand, SqlParameter>();
            var sut3 = new ModularDbClient<SqlConnection, SqlCommand, SqlParameter, SqlConnectionStringBuilder>();

            var p1 = sut2.CreateNewParameter(SqlParam1);
            AssertTypeMatches(p1, typeof(SqlParameter));
            AssertParamsMatch1(p1, SqlParam1);

            var p2 = sut2.CreateNewParameter(SqlParam2);
            AssertTypeMatches(p2, typeof(SqlParameter));
            AssertParamsMatch1(p2, SqlParam2);

            var p3 = sut3.CreateNewParameter(SqlParam3);
            AssertTypeMatches(p3, typeof(SqlParameter));
            AssertParamsMatch1(p3, SqlParam3);

            var p4 = sut3.CreateNewParameter(SqlParam4);
            AssertTypeMatches(p4, typeof(SqlParameter));
            AssertParamsMatch1(p4, SqlParam4);

        }

        [TestMethod]
        public void Should_MatchMockedCopy_ForSqlConnection()
        {
            var sut1 = new ModularDbClient<SqlConnection>();
            var sut2 = new ModularDbClient<SqlConnection, SqlCommand, SqlParameter>();
            var sut3 = new ModularDbClient<SqlConnection, SqlCommand, SqlParameter, SqlConnectionStringBuilder>();

            var p1 = sut2.CreateNewParameter(Param1);
            AssertTypeMatches(p1, typeof(SqlParameter));
            AssertParamsMatch1(p1, Param1);

            var p2 = sut2.CreateNewParameter(Param2);
            AssertTypeMatches(p2, typeof(SqlParameter));
            AssertParamsMatch1(p2, Param2);

            var p3 = sut3.CreateNewParameter(Param3);
            AssertTypeMatches(p3, typeof(SqlParameter));
            AssertParamsMatch1(p3, Param3);

            var p4 = sut3.CreateNewParameter(Param4);
            AssertTypeMatches(p4, typeof(SqlParameter));
            AssertParamsMatch1(p4, Param4);

        }

        [TestMethod]
        public void Should_Match_ForMySqlConnection()
        {
            var sut1 = new ModularDbClient<MySqlConnection>();
            var sut2 = new ModularDbClient<MySqlConnection, MySqlCommand, MySqlParameter>();
            var sut3 = new ModularDbClient<MySqlConnection, MySqlCommand, MySqlParameter, MySqlConnectionStringBuilder>();

            var p1 = sut2.CreateNewParameter();
            AssertTypeMatches(p1, typeof(MySqlParameter));
            p1.DbType = DbType.Int16;
            p1.Direction = ParameterDirection.InputOutput;
            p1.ParameterName = "testParam1";
            p1.SourceColumn = "TestParam1";
            p1.SourceVersion = DataRowVersion.Proposed;
            p1.Value = (Int16)12345;
            p1.Precision = 3;
            p1.Scale = 7;
            p1.Size = 10;
            AssertParamsMatch2(p1, Param1);

            var p2 = sut2.CreateNewParameter();
            AssertTypeMatches(p2, typeof(MySqlParameter));
            p2.DbType = DbType.Decimal;
            p2.Direction = ParameterDirection.Input;
            p2.ParameterName = "testParam2";
            p2.SourceColumn = "TestParam2";
            p2.SourceVersion = DataRowVersion.Current;
            p2.Value = 1234.12;
            p2.Precision = 5;
            p2.Scale = 3;
            p2.Size = 11;
            AssertParamsMatch2(p2, Param2);

            var p3 = sut3.CreateNewParameter();
            AssertTypeMatches(p3, typeof(MySqlParameter));
            p3.DbType = DbType.Boolean;
            p3.Direction = ParameterDirection.Output;
            p3.ParameterName = "testParam3";
            p3.SourceColumn = "TestParam3";
            p3.SourceVersion = DataRowVersion.Default;
            p3.Value = true;
            p3.Precision = 5;
            p3.Scale = 3;
            p3.Size = 1;
            AssertParamsMatch2(p3, Param3);

            var p4 = sut3.CreateNewParameter();
            AssertTypeMatches(p4, typeof(MySqlParameter));
            p4.DbType = DbType.String;
            p4.Direction = ParameterDirection.Output;
            p4.ParameterName = "testParam4";
            p4.SourceColumn = "TestParam4";
            p4.SourceVersion = DataRowVersion.Original;
            p4.Value = "this is a test";
            p4.Precision = 0;
            p4.Scale = 0;
            p4.Size = 14;
            AssertParamsMatch2(p4, Param4);

        }

        [TestMethod]
        public void Should_MatchCopy_ForMySqlConnection()
        {
            var sut1 = new ModularDbClient<MySqlConnection>();
            var sut2 = new ModularDbClient<MySqlConnection, MySqlCommand, MySqlParameter>();
            var sut3 = new ModularDbClient<MySqlConnection, MySqlCommand, MySqlParameter, MySqlConnectionStringBuilder>();

            var p1 = sut2.CreateNewParameter(MySqlParam1);
            AssertTypeMatches(p1, typeof(MySqlParameter));
            AssertParamsMatch1(p1, MySqlParam1);

            var p2 = sut2.CreateNewParameter(MySqlParam2);
            AssertTypeMatches(p2, typeof(MySqlParameter));
            AssertParamsMatch1(p2, MySqlParam2);

            var p3 = sut3.CreateNewParameter(MySqlParam3);
            AssertTypeMatches(p3, typeof(MySqlParameter));
            AssertParamsMatch1(p3, MySqlParam3);

            var p4 = sut3.CreateNewParameter(MySqlParam4);
            AssertTypeMatches(p4, typeof(MySqlParameter));
            AssertParamsMatch1(p4, MySqlParam4);

        }

        [TestMethod]
        public void Should_MatchMockedCopy_ForMySqlConnection()
        {
            var sut1 = new ModularDbClient<MySqlConnection>();
            var sut2 = new ModularDbClient<MySqlConnection, MySqlCommand, MySqlParameter>();
            var sut3 = new ModularDbClient<MySqlConnection, MySqlCommand, MySqlParameter, MySqlConnectionStringBuilder>();

            var p1 = sut2.CreateNewParameter(Param1);
            AssertTypeMatches(p1, typeof(MySqlParameter));
            AssertParamsMatch1(p1, Param1);

            var p2 = sut2.CreateNewParameter(Param2);
            AssertTypeMatches(p2, typeof(MySqlParameter));
            AssertParamsMatch1(p2, Param2);

            var p3 = sut3.CreateNewParameter(Param3);
            AssertTypeMatches(p3, typeof(MySqlParameter));
            AssertParamsMatch1(p3, Param3);

            var p4 = sut3.CreateNewParameter(Param4);
            AssertTypeMatches(p4, typeof(MySqlParameter));
            AssertParamsMatch1(p4, Param4);

        }

    }
}