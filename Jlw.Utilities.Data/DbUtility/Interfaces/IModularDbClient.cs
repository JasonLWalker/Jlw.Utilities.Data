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

        TReturn GetRecordScalar<TReturn>(object o, string connString, IRepositoryMethodDefinition definition);

        TReturn GetRecordObject<TReturn>(object o, string connString, IRepositoryMethodDefinition definition);

        IEnumerable<TReturn> GetRecordList<TReturn>(object o, string connString, IRepositoryMethodDefinition definition);
    }

    public interface IModularDbClient<TConnection, TCommand, TParameter, TConnectionStringBuilder> : IModularDbClient
    {
        TConnectionStringBuilder CreateConnectionBuilder(string connString = "");

        TConnection CreateConnection();
        TConnection CreateConnection(string connString);

        TCommand CreateCommand(string cmd, TConnection conn);
        TParameter CreateNewParameter(TParameter param, TCommand cmd = default);
        System.Data.IDbDataParameter CreateNewParameter(System.Data.IDbDataParameter param, IDbCommand cmd = default);

        TParameter AddParameter(TParameter param, TCommand cmd);

    }
}
