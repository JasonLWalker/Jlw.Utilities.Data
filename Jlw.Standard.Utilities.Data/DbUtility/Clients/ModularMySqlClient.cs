namespace Jlw.Standard.Utilities.Data.DbUtility
{
    public class ModularMySqlClient : IModularDbClient
    {
        public System.Data.IDbConnection GetConnection(string connString)
        {
            return new MySql.Data.MySqlClient.MySqlConnection(connString);
        }
        public System.Data.IDbCommand GetCommand(string cmd, System.Data.IDbConnection conn)
        {
            return new MySql.Data.MySqlClient.MySqlCommand(cmd, (MySql.Data.MySqlClient.MySqlConnection)conn);
        }

        public System.Data.IDbDataParameter AddParameterWithValue(string paramName, object value, System.Data.IDbCommand cmd)
        {
            return ((MySql.Data.MySqlClient.MySqlCommand) cmd).Parameters.AddWithValue(paramName, value);
        }

        public System.Data.IDbDataParameter GetNewParameter()
        {
            return new MySql.Data.MySqlClient.MySqlParameter();
        }
    }
}