using System.Collections.Generic;
using System.Data.Common;

namespace Jlw.Utilities.Data.DbUtility
{
    public interface IModularDbUtility
    {
        string DbType { get; }
        DbConnectionStringBuilder ConnectionStringBuilder { get; }

        IEnumerable<IDatabaseSchema> GetDatabaseList();

        IEnumerable<IDatabaseSchema> GetDatabaseList(string connString);

        IDatabaseSchema GetDatabaseSchema(string dbName);

        IDatabaseSchema GetDatabaseSchema(string connString, string dbName);

        IEnumerable<IColumnSchema> GetTableColumns(string dbName, string tableName);
        IEnumerable<IColumnSchema> GetTableColumns(string connString, string dbName, string tableName);

        IEnumerable<ITableSchema> GetTableList(string dbName);
        IEnumerable<ITableSchema> GetTableList(string connString, string dbName);
        
        string GetConnectionString(string serverName, string dbName = null);
    }
}