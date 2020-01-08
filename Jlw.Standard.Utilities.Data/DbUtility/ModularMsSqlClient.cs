namespace Jlw.Standard.Utilities.Data.DbUtility
{
    public class ModularMsSqlClient : IModularDbClient
    {
        public System.Data.IDbConnection GetConnection(string connString)
        {
            return new Microsoft.Data.SqlClient.SqlConnection(connString);
        }
        public System.Data.IDbCommand GetCommand(string cmd, System.Data.IDbConnection conn)
        {
            return new Microsoft.Data.SqlClient.SqlCommand(cmd, (Microsoft.Data.SqlClient.SqlConnection)conn);
        }

        public System.Data.IDbDataParameter AddParameterWithValue(string paramName, object value, System.Data.IDbCommand cmd)
        {
            return ((Microsoft.Data.SqlClient.SqlCommand) cmd).Parameters.AddWithValue(paramName, value);
        }

        public System.Data.IDbDataParameter GetNewParameter()
        {
            return new Microsoft.Data.SqlClient.SqlParameter();
        }
    }
}