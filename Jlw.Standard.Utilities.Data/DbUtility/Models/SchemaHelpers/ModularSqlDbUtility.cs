using System.Collections.Generic;
using System.Data.SqlClient;

namespace Jlw.Standard.Utilities.Data.DbUtility
{
    public class ModularSqlDbUtility : ModularBaseDbUtility
    {
        public override string DbType => "TSQL";
        protected override IModularDbClient DbClient { get; } = new ModularDbClient<SqlConnection, SqlCommand, SqlParameter>();

        public ModularSqlDbUtility()
        {
            _sGetDatabaseList = "SELECT [name] as [Name], [create_date] as [CreationDate], [collation_name] as [CollationName] FROM [sys].[databases] WHERE [owner_sid] <> 0x01 AND [state_desc] = 'ONLINE' ORDER BY [name]";
        }
        
        /*
        public override IEnumerable<IDatabaseSchema> GetDatabaseList(string connString)
        {
            const string sSql = "SELECT [name] as [Name], [create_date] as [CreationDate], [collation_name] as [CollationName] FROM [sys].[databases] WHERE [owner_sid] <> 0x01 AND [state_desc] = 'ONLINE' ORDER BY [name]";
            return GetDatabaseList(connString, sSql);
        }
        */

        public override IDatabaseSchema GetDatabaseSchema(string connString, string dbName)
        {
            DatabaseSchema oReturn = null;

            const string sSql = "SELECT [name] as [Name], [create_date] as [CreationDate], [collation_name] as [CollationName] FROM [sys].[databases] WHERE name=@databaseName ORDER BY [name]";

            using (var sqlConnection = new SqlConnection(connString))
            {
                sqlConnection.Open();
                using (var sqlCommand = new SqlCommand(sSql, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("databaseName", dbName);

                    using (SqlDataReader sqlResult = sqlCommand.ExecuteReader())
                    {
                        while (sqlResult.Read())
                        {
                            oReturn = new DatabaseSchema(sqlResult);
                        }
                    }
                }
            }

            return oReturn;
        }

        public override IEnumerable<ITableSchema> GetTableList(string connString, string dbName)
        {
            var aReturn = new List<TableSchema>();

            const string sSql = "SELECT [TABLE_CATALOG] as [Database], [TABLE_SCHEMA] as [Schema], [TABLE_NAME] as [Name], [TABLE_TYPE] as [Type] FROM [INFORMATION_SCHEMA].[TABLES] WHERE TABLE_CATALOG = @dbName ORDER BY [TABLE_NAME]";
            using (var sqlConnection = new SqlConnection(connString))
            {
                sqlConnection.Open();
                using (var sqlCommand = new SqlCommand(sSql, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("dbName", dbName);

                    using (SqlDataReader sqlResult = sqlCommand.ExecuteReader())
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

        public override IEnumerable<IColumnSchema> GetTableColumns(string connString, string dbName, string tableName)
        {
            var aReturn = new List<ColumnSchema>();

            const string sSql = "SELECT c.[TABLE_CATALOG] as [Database], c.[TABLE_SCHEMA] as [Schema], c.[TABLE_NAME] as [Table], c.[COLUMN_NAME] as [Column], c.[ORDINAL_POSITION] as [ColumnOrder], c.[DATA_TYPE] as [DataType], c.[COLUMN_DEFAULT] as [DefaultValue], c.[IS_NULLABLE] as [IsNullable], c.[CHARACTER_MAXIMUM_LENGTH] as [MaxLength], c.[NUMERIC_PRECISION] as [NumericPrecision], c.[NUMERIC_SCALE] as [NumericScale], c.[COLLATION_NAME] as [Collation], col.is_identity as [IsIdentity] FROM INFORMATION_SCHEMA.COLUMNS as c JOIN sys.columns col ON c.COLUMN_NAME = col.name JOIN sys.objects as tbl ON col.object_id = tbl.object_id AND tbl.name = @tableName AND tbl.type in (N'U') WHERE TABLE_NAME = @tableName AND TABLE_CATALOG = @dbName ORDER BY c.[ORDINAL_POSITION] ";

            using (var sqlConnection = new SqlConnection(connString))
            {
                sqlConnection.Open();
                using (var sqlCommand = new SqlCommand(sSql, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("dbName", dbName);
                    sqlCommand.Parameters.AddWithValue("tableName", tableName);

                    using (SqlDataReader sqlResult = sqlCommand.ExecuteReader())
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

        public override string GetConnectionString(string serverName, string dbName = null)
        {
            string s = $"data source={serverName};";
            s += string.IsNullOrWhiteSpace(UserName) ? "" : $"user={UserName};";
            s += string.IsNullOrWhiteSpace(Password) ? "" : $"password={Password};";
            s += string.IsNullOrWhiteSpace(dbName) ? "" : $"Initial Catalog={dbName};";
            s += (string.IsNullOrWhiteSpace(UserName) && string.IsNullOrWhiteSpace(Password)) ? "Integrated Security=SSPI;" : "";
            
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
