using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace Jlw.Standard.Utilities.Data.DbUtility
{
    public class ModularMySqlDbUtility : ModularBaseDbUtility
    {
        public override string DbType => "MySQL";

        protected override IModularDbClient DbClient { get; } = new ModularMySqlClient();


        public override IEnumerable<IDatabaseSchema> GetDatabaseList(string connString)
        {
            var aReturn = new List<DatabaseSchema>();

            const string sSql = "SELECT SCHEMA_NAME as `Name`, null as CreationDate, DEFAULT_COLLATION_NAME as CollationName FROM INFORMATION_SCHEMA.SCHEMATA WHERE SCHEMA_NAME NOT IN ('information_schema')";

            using (var mySqlConnection = new MySqlConnection(connString))
            {
                mySqlConnection.Open();
                using (var mySqlCommand = new MySqlCommand(sSql, mySqlConnection))
                {

                    using (var mySqlResult = mySqlCommand.ExecuteReader())
                    {
                        while (mySqlResult.Read())
                        {
                            aReturn.Add(new DatabaseSchema(mySqlResult));

                        }
                        mySqlResult.Close();
                    }
                }
                mySqlConnection.Close();
            }

            return aReturn;
        }

        public override IDatabaseSchema GetDatabaseSchema(string connString, string dbName)
        {
            throw new System.NotImplementedException();
        }

        public override IEnumerable<IColumnSchema> GetTableColumns(string connString, string dbName, string tableName)
        {
            var aReturn = new List<ColumnSchema>();

            const string sSql = "SELECT '' as `Schema`, c.`TABLE_SCHEMA` as `Database`, c.`TABLE_NAME` as `Table`, c.`COLUMN_NAME` as `Column`, c.`ORDINAL_POSITION` as `ColumnOrder`, c.`DATA_TYPE` as `DataType`, c.`COLUMN_DEFAULT` as `DefaultValue`, c.`IS_NULLABLE` as `IsNullable`, c.`CHARACTER_MAXIMUM_LENGTH` as `MaxLength`, c.`NUMERIC_PRECISION` as `NumericPrecision`, c.`NUMERIC_SCALE` as `NumericScale`, c.`COLLATION_NAME` as `Collation`, c.EXTRA = 'auto_increment' as `IsIdentity` FROM INFORMATION_SCHEMA.COLUMNS as c WHERE TABLE_NAME = @tableName AND TABLE_SCHEMA=@dbName ORDER BY c.`ORDINAL_POSITION` ";

            using (var sqlConnection = new MySqlConnection(connString))
            {
                sqlConnection.Open();
                using (var sqlCommand = new MySqlCommand(sSql, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("dbName", dbName);
                    sqlCommand.Parameters.AddWithValue("tableName", tableName);

                    using (MySqlDataReader sqlResult = sqlCommand.ExecuteReader())
                    {
                        while (sqlResult.Read())
                        {
                            aReturn.Add(new ColumnSchema(sqlResult));
                        }
                    }
                }
            }

            return aReturn;
        }

        public override IEnumerable<ITableSchema> GetTableList(string connString, string dbName)
        {
            var aReturn = new List<ITableSchema>();

            const string sSql = "SELECT TABLE_SCHEMA as `Database`, '' as `Schema`, TABLE_NAME as `Name`, TABLE_TYPE as `Type` FROM information_schema.tables WHERE TABLE_SCHEMA=@dbName ORDER BY TABLE_NAME;";

            using (var sqlConnection = new MySqlConnection(connString))
            {
                sqlConnection.Open();
                using (var sqlCommand = new MySqlCommand(sSql, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("dbName", dbName);
                    using (var sqlResult = sqlCommand.ExecuteReader())
                    {
                        while (sqlResult.Read())
                        {
                            aReturn.Add(new TableSchema(sqlResult));
                        }
                    }
                }
            }

            return aReturn;
        }

        public override string GetConnectionString(string serverName, string dbName = null)
        {
            string s = $"server={serverName};";
            s += string.IsNullOrWhiteSpace(UserName) ? "" : $"user={UserName};";
            s += string.IsNullOrWhiteSpace(Password) ? "" : $"password={Password};";
            s += string.IsNullOrWhiteSpace(dbName) ? "" : $"database={dbName};";
            s += "SslMode=none";
            return s;
        }

        public override void SetUsername(string username)
        {
            UserName = username;
        }

        public override void SetPassword(string password)
        {
            Password = password;
        }

    }
}