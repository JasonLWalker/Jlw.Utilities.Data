using System;
using System.Collections.Generic;
using System.Data;

namespace Jlw.Utilities.Data.DbUtility
{
    public class ModularBaseDbUtility<TModularDbClient, TInterface, TModel> : ModularDataRepositoryBase<TInterface, TModel>, IModularDataRepositoryBase<TInterface, TModel>, IModularDbUtility
    where TModularDbClient : class, IModularDbClient, new()
    where TModel : class, TInterface
    {
        protected string _sGetDatabaseList = "";
        protected string _sGetDatabaseSchema = "";
        protected string _sGetTableColumns = "";
        protected string _sGetTableList = "";
        private string _dbType;

        public virtual string DbType => _dbType;
        protected virtual IModularDbClient DbClient => new TModularDbClient();

        protected string UserName { get; set; }
        protected string Password { get; set; }
        protected string ServerAddress { get; set; }
        protected string ServerPort { get; set; }

        public ModularBaseDbUtility() : this(null, null, null) { }

        public ModularBaseDbUtility(string sType) : this(sType, null, null) { }

        public ModularBaseDbUtility(string sType, string connString, TModularDbClient dbClient = null) : base(dbClient ?? new TModularDbClient(), connString)
        {
            _dbType = sType;
        }

        public ModularBaseDbUtility(string server, string username = "", string password = "", string port = "", string connString="", string sType = "") : this(connString, sType, null)
        {
            Initialize( server, username, password, port, connString, sType);
        }

        public virtual void Initialize(string server="", string username="", string password="", string port="", string connString="", string sType="")
        {
            ServerAddress = server;
            UserName = username;
            Password = password;
            ServerPort = port;
            _connString = connString;
            _dbType = sType;
        }

        public virtual IEnumerable<IDatabaseSchema> GetDatabaseList() => GetDatabaseList(_connString);

        public virtual IEnumerable<IDatabaseSchema> GetDatabaseList(string connString)
        {
            /*
            var aReturn = new List<DatabaseSchema>();

            using (var dbConn = GetConnection(connString))
            {
                dbConn.Open();
                using (var dbCmd = GetCommand(_sGetDatabaseList, dbConn))
                {
                    using (IDataReader sqlResult = dbCmd.ExecuteReader())
                    {
                        while (sqlResult.Read())
                        {
                            aReturn.Add(new DatabaseSchema(sqlResult));
                        }
                    }
                }
            }

            return aReturn;
            */
            return DbClient.GetRecordList<IDatabaseSchema, DatabaseSchema>(connString, _sGetDatabaseList);
        }

        public virtual IDatabaseSchema GetDatabaseSchema(string dbName) => GetDatabaseSchema(_connString, dbName);

        public virtual IDatabaseSchema GetDatabaseSchema(string connString, string dbName)
        {
            throw new NotImplementedException();
        }


        public virtual IEnumerable<IColumnSchema> GetTableColumns(string dbName, string tableName) => GetTableColumns(_connString, dbName, tableName);


        public virtual IEnumerable<IColumnSchema> GetTableColumns(string connString, string dbName, string tableName)
        {
            throw new NotImplementedException();
        }

        public virtual IEnumerable<ITableSchema> GetTableList(string dbName) => GetTableList(_connString, dbName);

        public virtual IEnumerable<ITableSchema> GetTableList(string connString, string dbName)
        {
            throw new NotImplementedException();
        }

        public virtual string GetConnectionString(string serverName, string dbName = null)
        {
            return _connString;
        }

        public virtual void SetUsername(string username)
        {
            throw new NotImplementedException();
        }

        public virtual void SetPassword(string password)
        {
            throw new NotImplementedException();
        }
    }


    public class ModularBaseDbUtility : ModularBaseDbUtility<ModularDbClient<NullDbConnection, NullDbCommand, NullDbParameter>, object, object>
    {
        public ModularBaseDbUtility() : this("null") { }

        public ModularBaseDbUtility(string sType) : this(sType, null) { }

        public ModularBaseDbUtility(string sType, string connString) : base(sType, connString, null)
        {
        }

        /*
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
        */
        
    }
}
