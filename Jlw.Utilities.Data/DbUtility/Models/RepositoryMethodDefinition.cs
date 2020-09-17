using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;

namespace Jlw.Utilities.Data.DbUtility
{
    public delegate TInterface RepositoryRecordCallback<TInterface>(IDataRecord o); // declare a delegate
    public delegate void RepositoryParameterCallback<TInterface>(TInterface o, out IDbDataParameter param);

    public class RepositoryMethodDefinition<TModel> : RepositoryMethodDefinition<TModel, TModel>
    {
        public RepositoryMethodDefinition(string sql, IEnumerable<IDbDataParameter> paramList = null, RepositoryRecordCallback<TModel> callback = null) : base(sql, paramList, callback) { }

        public RepositoryMethodDefinition(string sql, IEnumerable<KeyValuePair<string, object>> paramList, RepositoryRecordCallback<TModel> callback = null) : base(sql, paramList, callback) { }

        public RepositoryMethodDefinition(string sql, CommandType cmdType, IEnumerable<IDbDataParameter> paramList = null, RepositoryRecordCallback<TModel> callback = null) : base(sql, cmdType, paramList, callback) { }

        public RepositoryMethodDefinition(string sql, CommandType cmdType, IEnumerable<KeyValuePair<string, object>> paramList, RepositoryRecordCallback<TModel> callback = null) : base(sql, cmdType, paramList, callback) { }
    }


    public class RepositoryMethodDefinition<TInterface, TModel>
    where TModel : TInterface
    {
        // ReSharper disable InconsistentNaming
        protected IList<IDbDataParameter> _dataParameters = new List<IDbDataParameter>();
        protected RepositoryRecordCallback<TInterface> _callback;
        protected CommandType _commandType;
        protected readonly string _sqlQuery;
        // ReSharper restore InconsistentNaming

        public readonly System.Type InterfaceType = typeof(TInterface);
        public readonly System.Type ModelType = typeof(TModel);

        public IEnumerable<IDbDataParameter> Parameters => _dataParameters;
        public RepositoryRecordCallback<TInterface> Callback => _callback;
        public CommandType CommandType => _commandType;
        public string SqlQuery => _sqlQuery;

        public RepositoryMethodDefinition(string sql, IEnumerable<string> paramList, RepositoryRecordCallback<TInterface> callback = null) : this(sql, CommandType.Text, paramList, callback) { }

        public RepositoryMethodDefinition(string sql, IEnumerable<KeyValuePair<string, object>> paramList, RepositoryRecordCallback<TInterface> callback = null) : this(sql, CommandType.Text, paramList, callback) { }
        
        public RepositoryMethodDefinition(string sql, IEnumerable<IDbDataParameter> paramList = null, RepositoryRecordCallback<TInterface> callback = null) : this(sql, CommandType.Text, paramList, callback) { }

        public RepositoryMethodDefinition(string sql, CommandType cmdType = CommandType.Text, IEnumerable<string> paramList = null, RepositoryRecordCallback<TInterface> callback = null)
        {
            _sqlQuery = sql;
            _callback = callback;
            _commandType = cmdType;

            if (paramList != null)
            {
                foreach (string param in paramList)
                {
                    IDbDataParameter p = new MockDbParameter();
                    p.Direction = ParameterDirection.Input;
                    p.ParameterName = param;
                    p.SourceColumn = param;
                    p.Value = param;
                    _dataParameters.Add(p);
                }
            }
        }

        public RepositoryMethodDefinition(string sql, CommandType cmdType = CommandType.Text, IEnumerable<IDbDataParameter> paramList = null, RepositoryRecordCallback<TInterface> callback =null)
        {
            _sqlQuery = sql;
            _callback = callback;
            _commandType = cmdType;

            if (paramList != null)
            {
                foreach (IDbDataParameter param in paramList)
                {
                    IDbDataParameter p = new MockDbParameter();
                    p.Precision = param.Precision;
                    p.Scale = param.Scale;
                    p.Size = param.Size;
                    p.DbType = param.DbType;
                    p.Direction = param.Direction;
                    p.ParameterName = param.ParameterName;
                    p.SourceColumn = param.SourceColumn;
                    p.SourceVersion = param.SourceVersion;
                    p.Value = param.Value;
                    _dataParameters.Add(p);
                }
            }
        }

        public RepositoryMethodDefinition(string sql, CommandType cmdType, IEnumerable<KeyValuePair<string, object>> paramList, RepositoryRecordCallback<TInterface> callback = null)
        {
            _sqlQuery = sql;
            _callback = callback;
            _commandType = cmdType;

            if (paramList != null)
            {
                foreach (var param in paramList)
                {
                    IDbDataParameter p = new MockDbParameter();
                    p.Direction = ParameterDirection.Input;
                    p.ParameterName = param.Key;
                    p.SourceColumn = param.Value.ToString();
                    p.Value = param.Value;
                    _dataParameters.Add(p);
                }
            }
        }

    }
}
