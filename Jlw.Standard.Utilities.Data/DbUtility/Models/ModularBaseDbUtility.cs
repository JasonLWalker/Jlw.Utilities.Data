using System;
using System.Collections.Generic;
using System.Data;

namespace Jlw.Standard.Utilities.Data.DbUtility
{
    public class ModularBaseDbUtility : IModularDbUtility
    {
        protected string UserName { get; set; }
        protected string Password { get; set; }
        protected string ServerAddress { get; set; }
        protected string ServerPort { get; set; }
        protected string ConnString { get; set; }
        protected virtual IModularDbClient DbClient => throw new NotImplementedException();

        public ModularBaseDbUtility()
        {
            Initialize();
        }

        public ModularBaseDbUtility(string server, string username = "", string password = "", string port = "", string conn = "")
        {
            Initialize( server, username, password, port, conn );
        }

        public void Initialize(string server="", string username="", string password="", string port="", string conn="")
        {
            ServerAddress = server;
            UserName = username;
            Password = password;
            ServerPort = port;
            ConnString = conn;
        }


        public virtual string DbType => throw new NotImplementedException();

        public virtual string GetConnectionString()
        {
            return ConnString;
        }

        public virtual string GetConnectionString(string serverName, string dbName = null)
        {
            throw new NotImplementedException();
        }


        protected virtual IEnumerable<IDatabaseSchema> GetDatabaseList(IModularDbClient dbClient, string connString, string sSql)
        {
            var aReturn = new List<DatabaseSchema>();

            using (var sqlConnection = dbClient.GetConnection(connString))
            {
                sqlConnection.Open();
                using (var sqlCommand = dbClient.GetCommand(sSql, sqlConnection))
                {
                    using (IDataReader sqlResult = sqlCommand.ExecuteReader())
                    {
                        while (sqlResult.Read())
                        {
                            aReturn.Add(new DatabaseSchema(sqlResult));
                        }
                    }
                }
            }

            return aReturn;
        }

        public virtual IEnumerable<IDatabaseSchema> GetDatabaseList(string connString)
        {
            throw new NotImplementedException();
        }

        public virtual IDatabaseSchema GetDatabaseSchema(string connString, string dbName)
        {
            throw new NotImplementedException();
        }

        public virtual IEnumerable<IColumnSchema> GetTableColumns(string connString, string dbName, string tableName)
        {
            throw new NotImplementedException();
        }

        public virtual IEnumerable<ITableSchema> GetTableList(string connString, string dbName)
        {
            throw new NotImplementedException();
        }

        public virtual void SetPassword(string password)
        {
            throw new NotImplementedException();
        }

        public virtual void SetUsername(string username)
        {
            throw new NotImplementedException();
        }
    }
}
