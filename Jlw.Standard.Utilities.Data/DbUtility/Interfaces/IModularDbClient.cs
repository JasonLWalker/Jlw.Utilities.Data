using System.Data;

namespace Jlw.Standard.Utilities.Data.DbUtility
{
    public interface IModularDbClient
    {
        IDbConnection GetConnection(string connString);
        IDbCommand GetCommand(string cmd, IDbConnection conn);

        IDbDataParameter AddParameterWithValue(string paramName, object value, IDbCommand cmd);
    }
}