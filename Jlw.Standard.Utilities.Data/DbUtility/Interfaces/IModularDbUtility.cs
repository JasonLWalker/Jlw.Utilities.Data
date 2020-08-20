using System.Collections.Generic;

namespace Jlw.Standard.Utilities.Data.DbUtility
{
    public interface IModularDbUtility
    {
        string DbType { get; }

        IEnumerable<IDatabaseSchema> GetDatabaseList();

        IEnumerable<IDatabaseSchema> GetDatabaseList(string connString);

        IDatabaseSchema GetDatabaseSchema(string dbName);

        IDatabaseSchema GetDatabaseSchema(string connString, string dbName);

        IEnumerable<IColumnSchema> GetTableColumns(string dbName, string tableName);
        IEnumerable<IColumnSchema> GetTableColumns(string connString, string dbName, string tableName);

        IEnumerable<ITableSchema> GetTableList(string dbName);
        IEnumerable<ITableSchema> GetTableList(string connString, string dbName);
        
        string GetConnectionString(string serverName, string dbName = null);

        void SetUsername(string username);
        
        void SetPassword(string password);
        
    }
}