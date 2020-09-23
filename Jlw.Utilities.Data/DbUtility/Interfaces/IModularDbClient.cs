using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;

namespace Jlw.Utilities.Data.DbUtility
{
    public interface IModularDbClient
    {
        DbConnectionStringBuilder GetConnectionBuilder(string connString = "");

        IDbConnection GetConnection();
        IDbConnection GetConnection(string connString);

        System.Data.IDbCommand GetCommand(string cmd);
        System.Data.IDbCommand GetCommand(string cmd, System.Data.IDbConnection conn);

        IDbDataParameter AddParameter(IDbDataParameter param, System.Data.IDbCommand cmd);
        System.Data.IDbDataParameter AddParameterWithValue(string paramName, object value, System.Data.IDbCommand cmd);
        System.Data.IDbDataParameter GetNewParameter();
        System.Data.IDbDataParameter GetNewParameter(System.Data.IDbDataParameter param);

        TModel GetRecordObject<TModel>(TModel o, string connString, RepositoryMethodDefinition<TModel, TModel> definition);
        TModel GetRecordObject<TModel>(string connString, string sSql, IEnumerable<KeyValuePair<string, object>> oParams = null, bool isStoredProc = false);
        TInterface GetRecordObject<TInterface, TModel>(TInterface o, string connString, RepositoryMethodDefinition<TInterface, TModel> definition) where TModel : TInterface;
        TInterface GetRecordObject<TInterface, TModel>(string connString, string sSql, IEnumerable<KeyValuePair<string, object>> oParams = null, bool isStoredProc = false);

        IEnumerable<TModel> GetRecordList<TModel>(string connString, RepositoryMethodDefinition<TModel, TModel> definition);
        IEnumerable<TModel> GetRecordList<TModel>(string connString, string sSql, IEnumerable<KeyValuePair<string, object>> oParams = null, bool isStoredProc = false);

        IEnumerable<TModel> GetRecordList<TModel>(TModel o, string connString, RepositoryMethodDefinition<TModel, TModel> definition);
        IEnumerable<TModel> GetRecordList<TModel>(TModel o, string connString, string sSql, IEnumerable<KeyValuePair<string, object>> oParams = null, bool isStoredProc = false);


        IEnumerable<TInterface> GetRecordList<TInterface, TModel>(string connString, RepositoryMethodDefinition<TInterface, TModel> definition) where TModel : TInterface;
        IEnumerable<TInterface> GetRecordList<TInterface, TModel>(string connString, string sSql, IEnumerable<KeyValuePair<string, object>> oParams = null, bool isStoredProc = false);
        
        IEnumerable<TInterface> GetRecordList<TInterface, TModel>(TInterface o, string connString, RepositoryMethodDefinition<TInterface, TModel> definition) where TModel : TInterface;
        IEnumerable<TInterface> GetRecordList<TInterface, TModel>(TInterface o, string connString, string sSql, IEnumerable<KeyValuePair<string, object>> oParams = null, bool isStoredProc = false);

    }

    public interface IModularDbClient<TConnection, TCommand, TParameter, TConnectionStringBuilder> : IModularDbClient
    {
        TConnectionStringBuilder CreateConnectionBuilder(string connString = "");

        TConnection CreateConnection();
        TConnection CreateConnection(string connString);

        TCommand CreateCommand(string cmd);
        TCommand CreateCommand(string cmd, TConnection conn);

        TParameter CreateNewParameter();
        TParameter CreateNewParameter(TParameter param);
        System.Data.IDbDataParameter CreateNewParameter(System.Data.IDbDataParameter param);

        TParameter AddParameter(TParameter param, TCommand cmd);

    }
}
