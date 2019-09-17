using System.Data;
using System.Data.SqlClient;

namespace Jlw.Standard.Utilities.Data.DbUtility
{
    public class ModularSqlClient : IModularDbClient
    {
        public IDbConnection GetConnection(string connString)
        {
            return new SqlConnection(connString);
        }
        public IDbCommand GetCommand(string cmd, IDbConnection conn)
        {
            return new SqlCommand(cmd, (SqlConnection)conn);
        }

        public IDbDataParameter AddParameterWithValue(string paramName, object value, IDbCommand cmd)
        {
            return ((SqlCommand) cmd).Parameters.AddWithValue(paramName, value);
        }

    }
}