using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SQLite;
using Jlw.Utilities.Data.DbUtility;
using Jlw.Utilities.Testing;
using Microsoft.Data.SqlClient;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MySql.Data.MySqlClient;

namespace Jlw.Utilities.Data.Tests.IntegrationTests.ModularDbClient.TInstance_TModel
{
    [TestClass]
    public class GetRecordObject_definition_nocallback : SqlLocalDbInstanceFixtureBase<ModularDataRepository<ITestDataModel, TestDataModel>>
    {
        ModularDbClient<SqlConnection, SqlCommand, SqlParameter, SqlConnectionStringBuilder> SqlClient = new ModularDbClient<SqlConnection, SqlCommand, SqlParameter, SqlConnectionStringBuilder>();

        protected string SqlInitFilename = $"{AppDomain.CurrentDomain.BaseDirectory}Data\\Sql\\TSql\\InitializeDb.sql";
        [TestMethod]
        public void Should_Succeed_ForSqlQuery_StringArray()
        {
            // Arrange
            base.InitializeInstanceData(SqlInitFilename);
            var definition = new RepositoryMethodDefinition<ITestDataModel, TestDataModel>("SELECT TOP 1 * FROM TestTable WHERE Id = @id", new string[] { "Id" });

            var expected = new TestDataModel() { Id = 1, Name = "Test User", Description = "This is a test user", LastUpdated = DateTime.Now };

            // Act
            var response = SqlClient.GetRecordObject<ITestDataModel, TestDataModel>(new TestDataModel(){Id=1}, ConnectionString, definition);

            // Assert
            Assert.AreEqual(expected.Id, response.Id);
            Assert.AreEqual(expected.Name, response.Name);
            Assert.AreEqual(expected.Description, response.Description);

        }

        [TestMethod]
        public void Should_Succeed_ForSqlQuery_Kvp()
        {
            // Arrange
            base.InitializeInstanceData(SqlInitFilename);
            var definition = new RepositoryMethodDefinition<ITestDataModel, TestDataModel>("SELECT TOP 1 * FROM TestTable WHERE Name = @name AND Id=@id", new [] { new KeyValuePair<string, object>("Id", 1),  new KeyValuePair<string, object>("Name", "Test User") });

            var expected = new TestDataModel() { Id = 1, Name = "Test User", Description = "This is a test user", LastUpdated = DateTime.Now };

            // Act
            var response = SqlClient.GetRecordObject<ITestDataModel, TestDataModel>(null, ConnectionString, definition);

            // Assert
            Assert.AreEqual(expected.Id, response.Id);
            Assert.AreEqual(expected.Name, response.Name);
            Assert.AreEqual(expected.Description, response.Description);

        }

        [TestMethod]
        public void Should_Succeed_ForStoredProcedure_StringArray()
        {
            // Arrange
            base.InitializeInstanceData(SqlInitFilename);
            var definition = new RepositoryMethodDefinition<ITestDataModel, TestDataModel>("sp_GetRecordData", CommandType.StoredProcedure, new string[] { "Id" });
            var expected = new TestDataModel() { Id = 2, Name = "Test User 2", Description = "This is another test user", LastUpdated = DateTime.Now };

            // Act
            var response = SqlClient.GetRecordObject<ITestDataModel, TestDataModel>(new TestDataModel(){Id = 2}, ConnectionString, definition);

            // Assert
            Assert.AreEqual(expected.Id, response.Id);
            Assert.AreEqual(expected.Name, response.Name);
            Assert.AreEqual(expected.Description, response.Description);
        }

        [TestMethod]
        public void Should_ThrowArgumentException_ForEmptySqlQuery()
        {
            // Arrange
            var definition = new RepositoryMethodDefinition<ITestDataModel, TestDataModel>("", new string[] { "Id" });

            // Act / Assert
            var ex = Assert.ThrowsException<ArgumentException>(() =>
            {
                var response = SqlClient.GetRecordObject<ITestDataModel, TestDataModel>(new TestDataModel() { Id = 3 }, ConnectionString, definition);
            });

            // Assert
            StringAssert.Contains(ex.Message, "Sql Query not provided");
            Assert.AreEqual(ex.ParamName, "SqlQuery");
        }

        [TestMethod]
        public void Should_ThrowArgumentException_ForEmptyStoredProcedure()
        {
            // Arrange
            var definition = new RepositoryMethodDefinition<ITestDataModel, TestDataModel>("", CommandType.StoredProcedure, new string[] { "Id" });

            // Act / Assert
            var ex = Assert.ThrowsException<ArgumentException>(() =>
            {
                var response = SqlClient.GetRecordObject<ITestDataModel, TestDataModel>(new TestDataModel() { Id = 3 }, ConnectionString, definition);
            });

            // Assert
            StringAssert.Contains(ex.Message, "Stored Procedure not provided");
            Assert.AreEqual(ex.ParamName, "SqlQuery");
        }

        [TestMethod]
        public void Should_ThrowArgumentNullException_ForNullObject()
        {
            // Arrange
            var definition = new RepositoryMethodDefinition<ITestDataModel, TestDataModel>("sp_GetRecord", CommandType.StoredProcedure, new string[] { "Id" });

            // Act / Assert
            var ex = Assert.ThrowsException<ArgumentNullException>(() =>
            {
                var response = SqlClient.GetRecordObject<ITestDataModel, TestDataModel>(null, ConnectionString, definition);
            });

            // Assert
            StringAssert.Contains(ex.Message, "cannot be null");
            Assert.AreEqual("o", ex.ParamName);
        }

    }
}