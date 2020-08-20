using System.Collections.Generic;

namespace Jlw.Standard.Utilities.Data.DbUtility
{
    public class ModularNullDbUtility : ModularBaseDbUtility
    {
        public override string DbType => "NULL";
        public override IEnumerable<IDatabaseSchema> GetDatabaseList(string connString)
        {
            return new List<IDatabaseSchema>();
        }

        public override IDatabaseSchema GetDatabaseSchema(string connString, string dbName)
        {
            return new DatabaseSchema();
        }

        public override IEnumerable<IColumnSchema> GetTableColumns(string connString, string dbName, string tableName)
        {
            return new List<IColumnSchema>();
        }

        public override IEnumerable<ITableSchema> GetTableList(string connString, string dbName)
        {
            return new List<TableSchema>();
        }

        public override string GetConnectionString(string serverName, string dbName = null)
        {
            return "";
        }

    }
}