using System;
using System.Data;
using Jlw.Utilities.Data.DbUtility;
using Jlw.Utilities.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Jlw.Utilities.Data.Tests.IntegrationTests.ModularDataRepositoryFixture
{
    [TestClass]
    public class LocalDbTest : SqlLocalDbInstanceFixtureBase<ModularDataRepository<ITestDataModel, TestDataModel>>
    {
        protected string SqlInitFilename = $"{AppDomain.CurrentDomain.BaseDirectory}Data\\Sql\\TSql\\InitializeDb.sql";
        protected RepositoryRecordCallback RecordCallback = (o) => new TestDataModel()
        {
            Description = DataUtility.ParseString(o, "Description"),
            Id = DataUtility.ParseLong(o, "Id"),
            Name = DataUtility.ParseString(o, "Name"),
            LastUpdated = DataUtility.ParseDateTime(o, "LastUpdated")
        };

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            //DefaultRepo.AddNewDefinition("GetRecord", "sp_GetRecordData", new string[] { "Id" }, CommandType.StoredProcedure, RecordCallback);
            //DefaultRepo.AddNewDefinition("SaveRecord", "sp_SaveRecordData", new string[] { "Id", "Name", "Description", "LastUpdated" }, CommandType.StoredProcedure, RecordCallback);
        }

        /*
        [TestMethod]
        public void TestMe1()
        {
            // Arrange
            InitializeInstanceData(SqlInitFilename);
            var expected = new TestDataModel(){ Id=1, Name="Test User", Description = "This is a test user", LastUpdated = DateTime.Now};

            //DefaultRepo.AddNewDefinition("GetRecord", "sp_GetRecordData", new string[] { "Id" }, CommandType.StoredProcedure, RecordCallback);

            // Act
            var response = DefaultRepo.GetRecord(new TestDataModel(){Id=1});

            // Assert
            Assert.AreEqual(expected.Id, response.Id);
            Assert.AreEqual(expected.Name, response.Name);
            Assert.AreEqual(expected.Description, response.Description);

        }

        [TestMethod]
        public void TestMe2()
        {
            // Arrange
            InitializeInstanceData(SqlInitFilename);

            var expected = new TestDataModel() { Id = 2, Name = "Test User 2", Description = "This is another test user", LastUpdated = DateTime.Now };
            //DefaultRepo.AddNewDefinition("GetRecord", "sp_GetRecordData", new []{ new KeyValuePair<string, object>("id", "Id"), }, CommandType.StoredProcedure);

            // Act
            var response = DefaultRepo.GetRecord(new TestDataModel() { Id = 2 });

            // Assert
            Assert.AreEqual(expected.Id, response.Id);
            Assert.AreEqual(expected.Name, response.Name);
            Assert.AreEqual(expected.Description, response.Description);
        }
        */
    }
}
