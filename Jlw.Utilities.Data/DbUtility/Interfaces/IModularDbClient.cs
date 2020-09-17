using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;

namespace Jlw.Utilities.Data.DbUtility
{
    public interface IModularDbClient
    {
        DbConnectionStringBuilder CreateConnectionBuilder(string connString = "");

        System.Data.IDbConnection GetConnection(string connString);
        System.Data.IDbConnection CreateConnection(string connString);


        System.Data.IDbCommand GetCommand(string cmd, System.Data.IDbConnection conn);
        System.Data.IDbCommand CreateCommand(string cmd, System.Data.IDbConnection conn);

        System.Data.IDbDataParameter AddParameterWithValue(string paramName, object value, System.Data.IDbCommand cmd);
        System.Data.IDbDataParameter CreateNewParameter();
        System.Data.IDbDataParameter CreateNewParameter(IDbDataParameter param);
        System.Data.IDbDataParameter GetNewParameter();

        TInterface GetRecordObject<TInterface, TModel>(TInterface o, string connString, RepositoryMethodDefinition<TInterface, TModel> definition) where TModel : TInterface;
        TInterface GetRecordObject<TInterface, TModel>(string connString, string sSql, IEnumerable<KeyValuePair<string, object>> oParams = null, bool isStoredProc = false);
        
        IEnumerable<TInterface> GetRecordList<TInterface, TModel>(string connString, string sSql, IEnumerable<KeyValuePair<string, object>> oParams = null, bool isStoredProc = false);

    }
}
