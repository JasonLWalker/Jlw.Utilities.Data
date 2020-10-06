using System;
using System.Data;
using Jlw.Utilities.Data.DbUtility;
using Jlw.Utilities.Testing;
using Microsoft.Data.SqlClient;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Jlw.Utilities.Data.Tests.IntegrationTests.ModularDbClient.TInstance_TModel_TReturn
{
    [TestClass]
    public class GetRecordScalar_definition_withcallback : SqlLocalDbInstanceFixtureBase<ModularDataRepository<ITestDataModel, TestDataModel>>
    {
        ModularDbClient<SqlConnection, SqlCommand, SqlParameter, SqlConnectionStringBuilder> SqlClient = new ModularDbClient<SqlConnection, SqlCommand, SqlParameter, SqlConnectionStringBuilder>();

        protected string SqlInitFilename = $"{AppDomain.CurrentDomain.BaseDirectory}Data\\Sql\\TSql\\InitializeDb.sql";
        protected RepositoryRecordCallback RecordCallback = (o) => (DataUtility.ParseDouble(o) + 0.5);
        protected RepositoryRecordCallback RecordCallback2 = (o) => (DataUtility.ParseDecimal(o) + (decimal)0.2);


        [TestMethod]
        public void Should_Succeed_ForSqlQuery_StringArray()
        {
            // Arrange
            base.InitializeInstanceData(SqlInitFilename);
            var definition = new RepositoryMethodDefinition<ITestDataModel, TestDataModel>("SELECT TOP 1 * FROM TestTable WHERE Id = @id AND Name=@name", new string[] { "Id", "Name" }, RecordCallback);
            var expected = new TestDataModel() { Id = 1, Name = "Test User", Description = "This is a test user", LastUpdated = DateTime.Now };

            // Act
            var response = SqlClient.GetRecordScalar<double>(new TestDataModel() { Id = expected.Id, Name=expected.Name }, ConnectionString, definition);

            // Assert
            Assert.AreEqual((double)expected.Id + 0.5, response);
        }

        [TestMethod]
        public void Should_Succeed_ForStoredProcedure_StringArray()
        {
            // Arrange
            base.InitializeInstanceData(SqlInitFilename);
            var definition = new RepositoryMethodDefinition<ITestDataModel, TestDataModel>("sp_GetRecordData", CommandType.StoredProcedure, new string[] { "Id" }, RecordCallback2);
            var expected = new TestDataModel() { Id = 2, Name = "Test User 2", Description = "This is another test user", LastUpdated = DateTime.Now };

            // Act
            var response = SqlClient.GetRecordScalar<decimal>(new TestDataModel(){Id = expected.Id}, ConnectionString, definition);

            // Assert
            Assert.AreEqual((decimal)(expected.Id + (float)0.2), response);
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
                var response = SqlClient.GetRecordScalar<string>(new TestDataModel() { Id = expected.Id }, ConnectionString, default);
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
                var response = SqlClient.GetRecordScalar<string>(new TestDataModel() { Id = 3 }, ConnectionString, definition);
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
                var response = SqlClient.GetRecordScalar<long>(new TestDataModel() { Id = 3 }, ConnectionString, definition);
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
                var response = SqlClient.GetRecordScalar<decimal>(null, ConnectionString, definition);
            });

            // Assert
            StringAssert.Contains(ex.Message, "cannot be null");
            Assert.AreEqual("o", ex.ParamName);
        }
    }
}