using System.Collections;
using System.Collections.Generic;
using System.Data;

namespace Jlw.Utilities.Data.DbUtility
{
    public interface IModularDbClient
    {
        System.Data.IDbConnection GetConnection(string connString);
        System.Data.IDbCommand GetCommand(string cmd, System.Data.IDbConnection conn);

        System.Data.IDbDataParameter AddParameterWithValue(string paramName, object value, System.Data.IDbCommand cmd);
        System.Data.IDbDataParameter GetNewParameter();

        TInterface GetRecordObject<TInterface, TModel>(string connString, string sSql, IEnumerable<KeyValuePair<string, object>> oParams = null, bool isStoredProc = false);
        
        IEnumerable<TInterface> GetRecordList<TInterface, TModel>(string connString, string sSql, IEnumerable<KeyValuePair<string, object>> oParams = null, bool isStoredProc = false);

    }
}