using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;

namespace Jlw.Utilities.Data.DbUtility
{
    public class RepositoryMethodDefinition<TInterface, TModel> : IRepositoryMethodDefinition
    {
        // ReSharper disable InconsistentNaming
        protected IList<IDbDataParameter> _dataParameters = new List<IDbDataParameter>();
        protected RepositoryRecordCallback _callback;
        protected CommandType _commandType;
        protected readonly string _sqlQuery;
        // ReSharper restore InconsistentNaming


        public readonly System.Type InterfaceType = typeof(TInterface);
        public readonly System.Type ModelType = typeof(TModel);
        public readonly System.Type ReturnType;

        public IEnumerable<IDbDataParameter> Parameters => _dataParameters;
        public RepositoryRecordCallback Callback => _callback;
        public CommandType CommandType => _commandType;
        public string SqlQuery => _sqlQuery;

        public RepositoryMethodDefinition(string sql, IEnumerable<string> paramList, RepositoryRecordCallback callback = null, Type returnType = default) : this(sql, CommandType.Text, paramList, callback, returnType) { }

        public RepositoryMethodDefinition(string sql, IEnumerable<KeyValuePair<string, object>> paramList, RepositoryRecordCallback callback = null, Type returnType = default) : this(sql, CommandType.Text, paramList, callback, returnType) { }
        
        public RepositoryMethodDefinition(string sql, IEnumerable<IDbDataParameter> paramList = null, RepositoryRecordCallback callback = null, Type returnType = default) : this(sql, CommandType.Text, paramList, callback, returnType) { }

        public RepositoryMethodDefinition(string sql, CommandType cmdType = CommandType.Text, IEnumerable<string> paramList = null, RepositoryRecordCallback callback = null, Type returnType = default)
        {
            _sqlQuery = sql;
            _callback = callback;
            _commandType = cmdType;
            ReturnType = returnType ?? typeof(object);

            if (paramList != null)
            {
                foreach (string param in paramList)
                {
                    DbCallbackParameter p = new DbCallbackParameter
                    {
                        Direction = ParameterDirection.Input, 
                        ParameterName = param, 
                        SourceColumn = param
                    };
                    p.Value = param;
                    _dataParameters.Add(p);
                }
            }
        }

        public RepositoryMethodDefinition(string sql, CommandType cmdType = CommandType.Text, IEnumerable<IDbDataParameter> paramList = null, RepositoryRecordCallback callback=null, Type returnType = default)
        {
            _sqlQuery = sql;
            _callback = callback;
            _commandType = cmdType;
            ReturnType = returnType ?? typeof(object);

            if (paramList != null)
            {
                foreach (IDbDataParameter param in paramList)
                {
                    DbCallbackParameter p = new DbCallbackParameter();
                    if (param.GetType() == typeof(DbCallbackParameter))
                    {
                        ((DbCallbackParameter) p).Callback = ((DbCallbackParameter) param).Callback;
                    }
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

        public RepositoryMethodDefinition(string sql, CommandType cmdType, IEnumerable<KeyValuePair<string, object>> paramList, RepositoryRecordCallback callback = null, Type returnType = default)
        {
            _sqlQuery = sql;
            _callback = callback;
            _commandType = cmdType;
            ReturnType = returnType ?? typeof(object);

            if (paramList != null)
            {
                foreach (var param in paramList)
                {
                    DbCallbackParameter p = new DbCallbackParameter();
                    if (param.Value is RepositoryParameterCallback)
                    {
                        p.Callback = (RepositoryParameterCallback)param.Value;
                    }
                    else
                    {
                        p.Value = param.Value;
                        p.SourceColumn = param.Value.ToString();
                    }
                    p.Direction = ParameterDirection.Input;
                    p.ParameterName = param.Key;
                    _dataParameters.Add(p);
                }
            }
        }

    }
}
