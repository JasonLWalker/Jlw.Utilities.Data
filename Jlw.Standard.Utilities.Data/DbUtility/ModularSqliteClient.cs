namespace Jlw.Standard.Utilities.Data.DbUtility
{
    public class ModularSqliteClient : IModularDbClient
    {
        public System.Data.IDbConnection GetConnection(string connString)
        {
            return new Microsoft.Data.Sqlite.SqliteConnection();
        }

        public System.Data.IDbCommand GetCommand(string cmd, System.Data.IDbConnection conn)
        {
            return new Microsoft.Data.Sqlite.SqliteCommand(cmd, (Microsoft.Data.Sqlite.SqliteConnection)conn);
        }

        public System.Data.IDbDataParameter AddParameterWithValue(string paramName, object value, System.Data.IDbCommand cmd)
        {
            return ((Microsoft.Data.Sqlite.SqliteCommand) cmd).Parameters.AddWithValue(paramName, value);
        }

        public System.Data.IDbDataParameter GetNewParameter()
        {
            return new Microsoft.Data.Sqlite.SqliteParameter();
        }
    }
}