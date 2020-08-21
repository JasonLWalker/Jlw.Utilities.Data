using System;
using Jlw.Utilities.Data.DbUtility;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Jlw.Utilities.Data.Tests.UnitTests.DbUtilityModels
{
    [TestClass]
    public class ModularMySqlDbUtilityFixture
    {
        public const string sConnString = "user id=billingclient;password=;server=localhost;sslmode=None;sshhostname=216.69.243.32;sshpassword=;sshusername=root";

        public static readonly IModularDbClient dbClient = new ModularMySqlClient(); 
    

        //[TestMethod]
        public void Should_Retrieve_DatabaseList()
        {
            var util = new ModularMySqlDbUtility(sConnString);
            var list = util.GetDatabaseList();
            foreach (var o in list)
            {
                Console.WriteLine(o.Name);
            }

        }
    }
}