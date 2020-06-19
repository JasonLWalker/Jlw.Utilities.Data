using Microsoft.Data.Sqlite;

namespace Jlw.Standard.Utilities.Data.DbUtility
{
    public class ModularMsSqliteClient : ModularDbClient<SqliteConnection, SqliteCommand, SqliteParameter>, IModularDbClient
    {
        /*
        public virtual System.Data.IDbConnection GetConnection(string connString)
        {
            return new SqliteConnection(connString);
        }

        public virtual System.Data.IDbCommand GetCommand(string cmd, System.Data.IDbConnection conn)
        {
            return new SqliteCommand(cmd, (SqliteConnection)conn);
        }

        public virtual System.Data.IDbDataParameter AddParameterWithValue(string paramName, object value, System.Data.IDbCommand cmd)
        {
            return ((SqliteCommand) cmd).Parameters.AddWithValue(paramName, value);
        }

        public virtual System.Data.IDbDataParameter GetNewParameter()
        {
            return new SqliteParameter();
        }
        */
    }
}