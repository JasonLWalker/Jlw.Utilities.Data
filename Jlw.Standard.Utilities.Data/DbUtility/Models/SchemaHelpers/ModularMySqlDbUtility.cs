using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace Jlw.Standard.Utilities.Data.DbUtility
{
    public class ModularMySqlDbUtility : ModularBaseDbUtility<ModularMySqlClient, object, object>
    {
        //public override string DbType => "MySQL";
        protected MySqlConnectionStringBuilder _builder = new MySqlConnectionStringBuilder();

        public MySqlConnectionStringBuilder ConnectionStringBuilder => _builder;

        //protected override IModularDbClient DbClient { get; } = new ModularMySqlClient();
        public ModularMySqlDbUtility() : this("MySQL") {}

        public ModularMySqlDbUtility(string sType) : this(sType, null) { }

        public ModularMySqlDbUtility(string sType, string connString) : base(sType, connString, new ModularMySqlClient())
        {

        }

        public ModularMySqlDbUtility(string server, string username = "", string password = "", string port = "", string connString="") : this(connString)
        {
            _sGetDatabaseList = "SELECT SCHEMA_NAME as `Name`, null as CreationDate, DEFAULT_COLLATION_NAME as CollationName FROM INFORMATION_SCHEMA.SCHEMATA WHERE SCHEMA_NAME NOT IN ('information_schema')";
            //_sGetDatabaseSchema = 
            _sGetTableColumns = "SELECT '' as `Schema`, c.`TABLE_SCHEMA` as `Database`, c.`TABLE_NAME` as `Table`, c.`COLUMN_NAME` as `Column`, c.`ORDINAL_POSITION` as `ColumnOrder`, c.`DATA_TYPE` as `DataType`, c.`COLUMN_DEFAULT` as `DefaultValue`, c.`IS_NULLABLE` as `IsNullable`, c.`CHARACTER_MAXIMUM_LENGTH` as `MaxLength`, c.`NUMERIC_PRECISION` as `NumericPrecision`, c.`NUMERIC_SCALE` as `NumericScale`, c.`COLLATION_NAME` as `Collation`, c.EXTRA = 'auto_increment' as `IsIdentity` FROM INFORMATION_SCHEMA.COLUMNS as c WHERE TABLE_NAME = @tableName AND TABLE_SCHEMA=@dbName ORDER BY c.`ORDINAL_POSITION` ";
            _sGetTableList = "SELECT TABLE_SCHEMA as `Database`, '' as `Schema`, TABLE_NAME as `Name`, TABLE_TYPE as `Type` FROM information_schema.tables WHERE TABLE_SCHEMA=@dbName ORDER BY TABLE_NAME;";

            Initialize(server, username, password, port, connString, "MySQL");
        }

        public sealed override void Initialize(string server="", string username="", string password="", string port="", string connString="", string sType="")
        {
            _builder.Server = ServerAddress = server;
            _builder.UserID = UserName = username;
            _builder.Password = Password = password;
            _builder.Port = (uint)DataUtility.ParseLong(ServerPort = port);
            _connString = string.IsNullOrWhiteSpace(connString) ? null : connString;
            //_dbType = "MySQL";
        }

        

        /*
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
        */
        /*
        public override IDatabaseSchema GetDatabaseSchema(string connString, string dbName)
        {
            throw new System.NotImplementedException();
        }
        */
        /*
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
        */
        /*
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
        */

        public override string GetConnectionString(string serverName, string dbName = null)
        {
            /*
            string s = $"server={serverName};";
            s += string.IsNullOrWhiteSpace(UserName) ? "" : $"user={UserName};";
            s += string.IsNullOrWhiteSpace(Password) ? "" : $"password={Password};";
            s += string.IsNullOrWhiteSpace(dbName) ? "" : $"database={dbName};";
            s += "SslMode=none";
            return s;
            */
            /*
            var builder = new MySqlConnectionStringBuilder();
            builder.Server = serverName;
            
            if (string.IsNullOrWhiteSpace(UserName))
                builder.UserID = UserName;

            if (string.IsNullOrWhiteSpace(Password))
                builder.Password = Password;

            if (string.IsNullOrWhiteSpace(dbName))
                builder.Database = dbName;

            builder.SslMode = MySqlSslMode.None;
            */


            return _connString ?? _builder.ConnectionString;
        }

        public override void SetUsername(string username)
        {
            _builder.UserID = UserName = username;
        }

        public override void SetPassword(string password)
        {
            _builder.Password = Password = password;
        }

    }
}