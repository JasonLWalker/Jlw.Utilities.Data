using MySql.Data.MySqlClient;
using System.Data;
using System.Data.SqlClient;

namespace Jlw.Standard.Utilities.Data.DbUtility
{
    public class ModularMySqlClient : IModularDbClient
    {
        public IDbConnection GetConnection(string connString)
        {
            return new MySqlConnection(connString);
        }
        public IDbCommand GetCommand(string cmd, IDbConnection conn)
        {
            return new MySqlCommand(cmd, (MySqlConnection)conn);
        }

        public IDbDataParameter AddParameterWithValue(string paramName, object value, IDbCommand cmd)
        {
            return ((MySqlCommand) cmd).Parameters.AddWithValue(paramName, value);
        }

    }
}