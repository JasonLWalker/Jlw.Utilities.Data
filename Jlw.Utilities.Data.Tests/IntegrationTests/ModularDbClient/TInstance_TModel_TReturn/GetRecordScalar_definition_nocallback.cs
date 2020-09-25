using System;
using System.Data;
using Jlw.Utilities.Data.DbUtility;
using Jlw.Utilities.Testing;
using Microsoft.Data.SqlClient;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Jlw.Utilities.Data.Tests.IntegrationTests.ModularDbClient.TInstance_TModel_TReturn
{
    [TestClass]
    public class GetRecordScalar_definition_nocallback : SqlLocalDbInstanceFixtureBase<ModularDataRepository<ITestDataModel, TestDataModel>>
    {
        ModularDbClient<SqlConnection, SqlCommand, SqlParameter, SqlConnectionStringBuilder> SqlClient = new ModularDbClient<SqlConnection, SqlCommand, SqlParameter, SqlConnectionStringBuilder>();

        protected string SqlInitFilename = $"{AppDomain.CurrentDomain.BaseDirectory}Data\\Sql\\TSql\\InitializeDb.sql";

        [TestMethod]
        public void Should_Succeed_ForSqlQuery_StringArray()
        {
            // Arrange
            base.InitializeInstanceData(SqlInitFilename);
            var definition = DbClient.BuildRepositoryMethodDefinition<ITestDataModel, TestDataModel>("SELECT * FROM TestTable WHERE Name = @name AND Id=@id", new[] { "Id", "Name" }, false);
            var expected = new TestDataModel() { Id = 1, Name = "Test User", Description = "This is a test user", LastUpdated = DateTime.Now };

            // Act
            var response = SqlClient.GetRecordScalar<ITestDataModel, TestDataModel, int>(new TestDataModel() { Id = expected.Id, Name=expected.Name }, ConnectionString, definition);

            // Assert
            Assert.AreEqual(expected.Id, response);
        }

        [TestMethod]
        public void Should_Succeed_ForStoredProcedure_StringArray()
        {
            // Arrange
            base.InitializeInstanceData(SqlInitFilename);
            var definition = DbClient.BuildRepositoryMethodDefinition<ITestDataModel, TestDataModel>("sp_GetRecordData", new []{"Id"}, true);
            var expected = new TestDataModel() { Id = 2, Name = "Test User 2", Description = "This is another test user", LastUpdated = DateTime.Now };

            // Act
            var response = SqlClient.GetRecordScalar<ITestDataModel, TestDataModel, string>(new TestDataModel(){Id = expected.Id}, ConnectionString, definition);

            // Assert
            Assert.AreEqual(expected.Id.ToString(), response);
            //Assert.AreEqual(expected.Id, response.Id);
            //Assert.AreEqual(expected.Name, response.Name);
            //Assert.AreEqual(expected.Description, response.Description);
        }

        [TestMethod]
        public void Should_ThrowArgumentNullException_ForNullDefinition()
        {
            // Arrange
            base.InitializeInstanceData(SqlInitFilename);
            var expected = new TestDataModel() { Id = 1, Name = "Test User 2", Description = "This is another test user", LastUpdated = DateTime.Now };

            // Act / Assert
            var ex = Assert.ThrowsException<ArgumentNullException>(() =>
            {
                var response = SqlClient.GetRecordScalar<ITestDataModel, TestDataModel, string>(new TestDataModel() { Id = expected.Id }, ConnectionString, default);
            });

            // Assert
            StringAssert.Contains(ex.Message, "No definition provided");
            Assert.AreEqual(ex.ParamName, "definition");
        }

        [TestMethod]
        public void Should_ThrowArgumentException_ForEmptySqlQuery()
        {
            // Arrange
            var definition = new RepositoryMethodDefinition<ITestDataModel, TestDataModel>("", new string[] { "Id" });

            // Act / Assert
            var ex = Assert.ThrowsException<ArgumentException>(() =>
            {
                var response = SqlClient.GetRecordScalar<ITestDataModel, TestDataModel, string>(new TestDataModel() { Id = 3 }, ConnectionString, definition);
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
                var response = SqlClient.GetRecordScalar<ITestDataModel, TestDataModel, long>(new TestDataModel() { Id = 3 }, ConnectionString, definition);
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
                var response = SqlClient.GetRecordScalar<ITestDataModel, TestDataModel, decimal>(null, ConnectionString, definition);
            });

            // Assert
            StringAssert.Contains(ex.Message, "cannot be null");
            Assert.AreEqual("o", ex.ParamName);
        }
    }
}