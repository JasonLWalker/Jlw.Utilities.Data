namespace Jlw.Standard.Utilities.Data.DbUtility
{
    public class ModularOdbcClient : IModularDbClient
    {
        public System.Data.IDbConnection GetConnection(string connString)
        {
            return new System.Data.Odbc.OdbcConnection();
        }
        public System.Data.IDbCommand GetCommand(string cmd, System.Data.IDbConnection conn)
        {
            return new System.Data.Odbc.OdbcCommand(cmd, (System.Data.Odbc.OdbcConnection)conn);
        }

        public System.Data.IDbDataParameter AddParameterWithValue(string paramName, object value, System.Data.IDbCommand cmd)
        {
            return ((System.Data.Odbc.OdbcCommand) cmd).Parameters.AddWithValue(paramName, value);
        }

        public System.Data.IDbDataParameter GetNewParameter()
        {
            return new System.Data.Odbc.OdbcParameter();
        }
    }
}