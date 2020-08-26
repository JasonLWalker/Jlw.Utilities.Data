using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace Jlw.Utilities.Data.DbUtility
{
    public class ModularMySqlDbUtility : ModularBaseDbUtility<ModularMySqlClient, object, object>
    {
        //public override string DbType => "MySQL";
        protected new MySqlConnectionStringBuilder _builder = new MySqlConnectionStringBuilder();

        public new MySqlConnectionStringBuilder ConnectionStringBuilder => _builder;

        public ModularMySqlDbUtility() : this(null) {}

        public ModularMySqlDbUtility(string connString) : base("MySql", connString, new ModularMySqlClient())
        {
            _sGetDatabaseList = "SELECT SCHEMA_NAME as `Name`, null as CreationDate, DEFAULT_COLLATION_NAME as CollationName FROM INFORMATION_SCHEMA.SCHEMATA WHERE SCHEMA_NAME NOT IN ('information_schema')";
            //_sGetDatabaseSchema = 
            _sGetTableColumns = "SELECT '' as `Schema`, c.`TABLE_SCHEMA` as `Database`, c.`TABLE_NAME` as `Table`, c.`COLUMN_NAME` as `Column`, c.`ORDINAL_POSITION` as `ColumnOrder`, c.`DATA_TYPE` as `DataType`, c.`COLUMN_DEFAULT` as `DefaultValue`, c.`IS_NULLABLE` as `IsNullable`, c.`CHARACTER_MAXIMUM_LENGTH` as `MaxLength`, c.`NUMERIC_PRECISION` as `NumericPrecision`, c.`NUMERIC_SCALE` as `NumericScale`, c.`COLLATION_NAME` as `Collation`, c.EXTRA = 'auto_increment' as `IsIdentity` FROM INFORMATION_SCHEMA.COLUMNS as c WHERE TABLE_NAME = @tableName AND TABLE_SCHEMA=@dbName ORDER BY c.`ORDINAL_POSITION` ";
            _sGetTableList = "SELECT TABLE_SCHEMA as `Database`, '' as `Schema`, TABLE_NAME as `Name`, TABLE_TYPE as `Type` FROM information_schema.tables WHERE TABLE_SCHEMA=@dbName ORDER BY TABLE_NAME;";
            //_builder.ConnectionString = connString ?? "";
        }

        public override string GetConnectionString(string serverName, string dbName = null)
        {
            var builder = new MySqlConnectionStringBuilder(_builder.ConnectionString);

            builder.Server = serverName ?? "";
            builder.Database = dbName ?? "";
            return _connString ?? _builder.ConnectionString;
        }

    }
}