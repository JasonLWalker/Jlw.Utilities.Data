using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SQLite;
using Jlw.Utilities.Data.DbUtility;
using Jlw.Utilities.Data.Tests.Models;
using Jlw.Utilities.Testing;
using Microsoft.Data.SqlClient;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MySql.Data.MySqlClient;

namespace Jlw.Utilities.Data.Tests.IntegrationTests.ModularDbClient.TModel
{
    [TestClass]
    public class GetRecordObject_sSql : SqlLocalDbInstanceFixtureBase<ModularDataRepository<ITestDataModel, TestDataModel>>
    {
        ModularDbClient<SqlConnection, SqlCommand, SqlParameter, SqlConnectionStringBuilder> SqlClient = new ModularDbClient<SqlConnection, SqlCommand, SqlParameter, SqlConnectionStringBuilder>();


        protected string SqlInitFilename = $"{AppDomain.CurrentDomain.BaseDirectory}Data\\Sql\\TSql\\InitializeDb.sql";
        protected RepositoryRecordCallback RecordCallback = (o) => new TestDataModel()
        {
            Description = DataUtility.ParseString(o, "Description"),
            Id = DataUtility.ParseLong(o, "Id"),
            Name = DataUtility.ParseString(o, "Name"),
            LastUpdated = DataUtility.ParseDateTime(o, "LastUpdated")
        };

        [TestMethod]
        public void Should_Succeed_ForSqlQuery()
        {
            // Arrange
            base.InitializeInstanceData(SqlInitFilename);
            var expected = new TestDataModel() { Id = 1, Name = "Test User", Description = "This is a test user", LastUpdated = DateTime.Now };

            // Act
            var response = SqlClient.GetRecordObject<TestDataModel>(ConnectionString, "Select TOP 1 * FROM TestTable WHERE Id = @id;", new[] { new KeyValuePair<string, object>("ID", "1") }, false);

            // Assert
            Assert.AreEqual(expected.Id, response.Id);
            Assert.AreEqual(expected.Name, response.Name);
            Assert.AreEqual(expected.Description, response.Description);

        }

        [TestMethod]
        public void Should_Succeed_ForStoredProcedure()
        {
            // Arrange
            base.InitializeInstanceData(SqlInitFilename);
            var expected = new TestDataModel() { Id = 2, Name = "Test User 2", Description = "This is another test user", LastUpdated = DateTime.Now };

            // Act
            var response = SqlClient.GetRecordObject<TestDataModel>(ConnectionString, "sp_GetRecordData", new[] { new KeyValuePair<string, object>("ID", "2") }, true);
            //DefaultRepo.GetRecord(new TestDataModel() { Id = 2 });

            // Assert
            Assert.AreEqual(expected.Id, response.Id);
            Assert.AreEqual(expected.Name, response.Name);
            Assert.AreEqual(expected.Description, response.Description);
        }

        [TestMethod]
        public void Should_ThrowArgumentException_ForEmptySqlQuery()
        {
            // Act
            var ex = Assert.ThrowsException<ArgumentException>(() =>
            {
                var response = SqlClient.GetRecordObject<TestDataModel>(ConnectionString, "", new[] { new KeyValuePair<string, object>("ID", "3") }, false);
            });

            StringAssert.Contains(ex.Message, "Sql Query not provided");
            StringAssert.Contains(ex.ParamName, "sSql");
        }

        [TestMethod]
        public void Should_ThrowArgumentException_ForEmptyStoredProcedure()
        { 
            // Act
            var ex = Assert.ThrowsException<ArgumentException>(() =>
            {
                var response = SqlClient.GetRecordObject<TestDataModel>(ConnectionString, "", new[] { new KeyValuePair<string, object>("ID", "3") }, true);
            });
            StringAssert.Contains(ex.Message, "Stored Procedure not provided");
            Assert.AreEqual(ex.ParamName, "sSql");
        }

    }
}