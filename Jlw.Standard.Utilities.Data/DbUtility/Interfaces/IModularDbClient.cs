using System.Data;

namespace Jlw.Standard.Utilities.Data.DbUtility
{
    public interface IModularDbClient
    {
        System.Data.IDbConnection GetConnection(string connString);
        System.Data.IDbCommand GetCommand(string cmd, System.Data.IDbConnection conn);

        System.Data.IDbDataParameter AddParameterWithValue(string paramName, object value, System.Data.IDbCommand cmd);
        System.Data.IDbDataParameter GetNewParameter();

    }
}