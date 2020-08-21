using System.Data.SqlClient;

namespace Jlw.Utilities.Data.DbUtility
{
    public class ModularSqlClient : ModularDbClient<SqlConnection, SqlCommand, SqlParameter>, IModularDbClient
    {

    }
    
    /*
    public class ModularSqlClient : IModularDbClient
    {
        public System.Data.IDbConnection GetConnection(string connString)
        {
            return new System.Data.SqlClient.SqlConnection(connString);
        }
        public System.Data.IDbCommand GetCommand(string cmd, System.Data.IDbConnection conn)
        {
            return new System.Data.SqlClient.SqlCommand(cmd, (System.Data.SqlClient.SqlConnection)conn);
        }

        public System.Data.IDbDataParameter AddParameterWithValue(string paramName, object value, System.Data.IDbCommand cmd)
        {
            return ((System.Data.SqlClient.SqlCommand) cmd).Parameters.AddWithValue(paramName, value);
        }

        public System.Data.IDbDataParameter GetNewParameter()
        {
            return new Microsoft.Data.SqlClient.SqlParameter();
        }
    }
    */
}