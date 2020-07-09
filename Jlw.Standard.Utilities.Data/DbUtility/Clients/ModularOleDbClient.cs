namespace Jlw.Standard.Utilities.Data.DbUtility
{
    public class ModularOleDbClient : IModularDbClient
    {
        public System.Data.IDbConnection GetConnection(string connString)
        {
            return new System.Data.OleDb.OleDbConnection();
        }
        public System.Data.IDbCommand GetCommand(string cmd, System.Data.IDbConnection conn)
        {
            return new System.Data.OleDb.OleDbCommand(cmd, (System.Data.OleDb.OleDbConnection)conn);
        }

        public System.Data.IDbDataParameter AddParameterWithValue(string paramName, object value, System.Data.IDbCommand cmd)
        {
            return ((System.Data.OleDb.OleDbCommand) cmd).Parameters.AddWithValue(paramName, value);
        }

        public System.Data.IDbDataParameter GetNewParameter()
        {
            return new System.Data.OleDb.OleDbParameter();
        }
    }
}