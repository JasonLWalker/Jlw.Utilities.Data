using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;

namespace Jlw.Utilities.Data.DbUtility
{
    public interface IModularDbClient
    {
        DbConnectionStringBuilder GetConnectionBuilder(string connString = default);

        IDbConnection GetConnection(string connString = default);

        System.Data.IDbCommand GetCommand(string cmd, System.Data.IDbConnection conn = default);

        IDbDataParameter AddParameter(IDbDataParameter param, System.Data.IDbCommand cmd);
        System.Data.IDbDataParameter AddParameterWithValue(string paramName, object value, System.Data.IDbCommand cmd);
        System.Data.IDbDataParameter GetNewParameter(System.Data.IDbDataParameter param = default, IDbCommand cmd = null);

        RepositoryMethodDefinition<TInterface, TModel> BuildRepositoryMethodDefinition<TInterface, TModel>(string sSql, IEnumerable<KeyValuePair<string, object>> aParams = null, bool isStoredProc = false) where TModel : TInterface;

        RepositoryMethodDefinition<TInterface, TModel> BuildRepositoryMethodDefinition<TInterface, TModel>(string sSql, IEnumerable<string> aParams = null, bool isStoredProc = false) where TModel : TInterface;


        object GetRecordScalar(string connString, string sSql, IEnumerable<KeyValuePair<string, object>> oParams = null, bool isStoredProc = false);
        TReturn GetRecordScalar<TInterface, TModel, TReturn>(TInterface o, string connString, RepositoryMethodDefinition<TInterface, TModel> definition) where TModel : TInterface;



        #region GetRecordObject
        object GetRecordObject(object o, string connString, RepositoryMethodDefinition<object, object> definition);
        TModel GetRecordObject<TModel>(TModel o, string connString, RepositoryMethodDefinition<TModel, TModel> definition);
        TInterface GetRecordObject<TInterface, TModel>(TInterface o, string connString, RepositoryMethodDefinition<TInterface, TModel> definition) where TModel : TInterface;
        TReturn GetRecordObject<TInterface, TModel, TReturn>(TInterface o, string connString, RepositoryMethodDefinition<TInterface, TModel> definition) where TModel : TInterface;


        object GetRecordObject(object o, string connString, string sSql, IEnumerable<string> oParams = null, bool isStoredProc = false);
        TModel GetRecordObject<TModel>(TModel o, string connString, string sSql, IEnumerable<string> oParams = null, bool isStoredProc = false);
        TInterface GetRecordObject<TInterface, TModel>(TInterface o, string connString, string sSql, IEnumerable<string> oParams = null, bool isStoredProc = false) where TModel : TInterface;
        TReturn GetRecordObject<TInterface, TModel, TReturn>(TInterface o, string connString, string sSql, IEnumerable<string> oParams = null, bool isStoredProc = false) where TModel : TInterface;


        object GetRecordObject(string connString, string sSql, IEnumerable<KeyValuePair<string, object>> oParams = null, bool isStoredProc = false);
        TModel GetRecordObject<TModel>(string connString, string sSql, IEnumerable<KeyValuePair<string, object>> oParams = null, bool isStoredProc = false);
        TInterface GetRecordObject<TInterface, TModel>(string connString, string sSql, IEnumerable<KeyValuePair<string, object>> oParams = null, bool isStoredProc = false) where TModel : TInterface;
        TReturn GetRecordObject<TInterface, TModel, TReturn>(string connString, string sSql, IEnumerable<KeyValuePair<string, object>> oParams = null, bool isStoredProc = false) where TModel : TInterface;


        object GetRecordObject(object o, string connString, string sSql, IEnumerable<KeyValuePair<string, object>> oParams = null, bool isStoredProc = false);
        TModel GetRecordObject<TModel>(TModel o, string connString, string sSql, IEnumerable<KeyValuePair<string, object>> oParams = null, bool isStoredProc = false);
        TInterface GetRecordObject<TInterface, TModel>(TInterface o, string connString, string sSql, IEnumerable<KeyValuePair<string, object>> oParams = null, bool isStoredProc = false) where TModel : TInterface;
        TReturn GetRecordObject<TInterface, TModel, TReturn>(TInterface o, string connString, string sSql, IEnumerable<KeyValuePair<string, object>> oParams = null, bool isStoredProc = false) where TModel : TInterface;
        #endregion

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

        TCommand CreateCommand(string cmd, TConnection conn);

        //TParameter CreateNewParameter();
        TParameter CreateNewParameter(TParameter param, TCommand cmd = default);
        System.Data.IDbDataParameter CreateNewParameter(System.Data.IDbDataParameter param, IDbCommand cmd = default);

        TParameter AddParameter(TParameter param, TCommand cmd);

    }
}
