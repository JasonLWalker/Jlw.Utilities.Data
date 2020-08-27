using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;

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

        public DbConnectionStringBuilder ConnectionStringBuilder => _builder;
        
        public ModularBaseDbUtility() : this(null, null, null) { }

        public ModularBaseDbUtility(string sType) : this(sType, null, null) { }

        public ModularBaseDbUtility(string sType, string connString, TModularDbClient dbClient = null) : base(dbClient ?? new TModularDbClient(), connString)
        {
            _dbType = sType;
            ConnectionStringBuilder.ConnectionString = connString ?? "";
        }

        public virtual IEnumerable<IDatabaseSchema> GetDatabaseList() => GetDatabaseList(_connString);

        public virtual IEnumerable<IDatabaseSchema> GetDatabaseList(string connString) => DbClient.GetRecordList<IDatabaseSchema, DatabaseSchema>(connString, _sGetDatabaseList);

        public virtual IDatabaseSchema GetDatabaseSchema(string dbName) => GetDatabaseSchema(_connString, dbName);

        public virtual IDatabaseSchema GetDatabaseSchema(string connString, string dbName)
        {
            throw new NotImplementedException();
        }


        public virtual IEnumerable<IColumnSchema> GetTableColumns(string dbName, string tableName) => GetTableColumns(_connString, dbName, tableName);


        public virtual IEnumerable<IColumnSchema> GetTableColumns(string connString, string dbName, string tableName) => DbClient.GetRecordList<IColumnSchema, ColumnSchema>(connString, _sGetTableColumns, new []{new KeyValuePair<string, object>("dbName", dbName), new KeyValuePair<string, object>("tableName", tableName)});

        public virtual IEnumerable<ITableSchema> GetTableList(string dbName) => GetTableList(_connString, dbName);

        public virtual IEnumerable<ITableSchema> GetTableList(string connString, string dbName) => DbClient.GetRecordList<ITableSchema, TableSchema>(connString, _sGetTableList, new []{new KeyValuePair<string, object>("dbName", dbName)});

        public virtual string GetConnectionString(string serverName, string dbName = null)
        {
            var builder = new DbConnectionStringBuilder();
            builder.ConnectionString = _builder.ConnectionString;
            builder.Add("Data Source", serverName);
            builder.Add("Initial Catalog", dbName);

            return ConnectionStringBuilder.ConnectionString;
        }


    }


    public class ModularBaseDbUtility : ModularBaseDbUtility<ModularDbClient<NullDbConnection, NullDbCommand, NullDbParameter>, object, object>
    {
        public ModularBaseDbUtility() : this("null") { }

        public ModularBaseDbUtility(string sType) : this(sType, null) { }

        public ModularBaseDbUtility(string sType, string connString) : base(sType, connString, null)
        {
        }

    }
}
