﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;

namespace Jlw.Utilities.Data.DbUtility
{
    public interface IModularDataRepository<TInterface, TModel> where TModel : TInterface
    {
        string ConnectionString { get; }
        DbConnectionStringBuilder ConnectionBuilder { get; }

        IModularDbClient DbClient { get; }
        //IDictionary<string, RepositoryMethodDefinition<TInterface, TModel>> Definitions { get; }

        RepositoryMethodDefinition<TInterface, TModel> AddNewDefinition(string name, string query, IEnumerable<string> paramList, CommandType cmdType = CommandType.Text, RepositoryMethodDefinition<TInterface, TModel>.RecordCallback callback = null);
        RepositoryMethodDefinition<TInterface, TModel> AddNewDefinition(string name, string query, IEnumerable<KeyValuePair<string, object>> paramList, CommandType cmdType = CommandType.Text, RepositoryMethodDefinition<TInterface, TModel>.RecordCallback callback = null);
        RepositoryMethodDefinition<TInterface, TModel> AddNewDefinition(string name, string query, IEnumerable<IDbDataParameter> paramList = null, CommandType cmdType = CommandType.Text, RepositoryMethodDefinition<TInterface, TModel>.RecordCallback callback = null);
    }

    public class ModularDataRepository<TInterface, TModel> : IModularDataRepository<TInterface, TModel>
    where TModel : TInterface
    {
        // ReSharper disable InconsistentNaming
        protected IModularDbClient _dbClient;
        protected DbConnectionStringBuilder _builder { get; }
        protected IDictionary<string, RepositoryMethodDefinition<TInterface, TModel>> _definitions = new Dictionary<string, RepositoryMethodDefinition<TInterface, TModel>>();
        // ReSharper restore InconsistentNaming

        public DbConnectionStringBuilder ConnectionBuilder => _builder;
        public string ConnectionString => _builder.ConnectionString;
        public IModularDbClient DbClient => _dbClient;
        //public IDictionary<string, RepositoryMethodDefinition<TInterface, TModel>> Definitions => _definitions;

        public ModularDataRepository(IModularDbClient dbClient, string connString = "")
        {
            _dbClient = dbClient ?? new ModularDbClient<NullDbConnection, NullDbCommand, NullDbParameter>();
            _builder = _dbClient.CreateConnectionBuilder(connString);
        }

        protected RepositoryMethodDefinition<TInterface, TModel> GetDefinition(string key)
        {
            if (_definitions?.ContainsKey(key) ?? false)
            {
                return _definitions[key];
            }

            return null;
        }

        public RepositoryMethodDefinition<TInterface, TModel> AddNewDefinition(string name, string query, IEnumerable<string> paramList, CommandType cmdType = CommandType.Text, RepositoryMethodDefinition<TInterface, TModel>.RecordCallback callback = null)
        {
            var def = new RepositoryMethodDefinition<TInterface, TModel>(query, cmdType, paramList, callback);
            _definitions.Add(name, def);
            return def;
        }

        public RepositoryMethodDefinition<TInterface, TModel> AddNewDefinition(string name, string query, IEnumerable<KeyValuePair<string, object>> paramList, CommandType cmdType = CommandType.Text, RepositoryMethodDefinition<TInterface, TModel>.RecordCallback callback = null)
        {
            var def = new RepositoryMethodDefinition<TInterface, TModel>(query, cmdType, paramList, callback);
            _definitions.Add(name, def);
            return def;
        }

        public RepositoryMethodDefinition<TInterface, TModel> AddNewDefinition(string name, string query, IEnumerable<IDbDataParameter> paramList = null, CommandType cmdType = CommandType.Text, RepositoryMethodDefinition<TInterface, TModel>.RecordCallback callback = null)
        {
            var def = new RepositoryMethodDefinition<TInterface, TModel>(query, cmdType, paramList, callback);
            _definitions.Add(name, def);
            return def;
        }

        public virtual TInterface GetRecord(TInterface o) => _dbClient.GetRecordObject<TInterface, TModel>(o, ConnectionString, GetDefinition(nameof(GetRecord)));
        public virtual TInterface InsertRecord(TInterface o) => _dbClient.GetRecordObject<TInterface, TModel>(o, ConnectionString, GetDefinition(nameof(InsertRecord)));
        public virtual TInterface SaveRecord(TInterface o) => _dbClient.GetRecordObject<TInterface, TModel>(o, ConnectionString, GetDefinition(nameof(SaveRecord)));
        public virtual TInterface UpdateRecord(TInterface o) => _dbClient.GetRecordObject<TInterface, TModel>(o, ConnectionString, GetDefinition(nameof(UpdateRecord)));
        public virtual TInterface DeleteRecord(TInterface o) => _dbClient.GetRecordObject<TInterface, TModel>(o,ConnectionString, GetDefinition(nameof(DeleteRecord)));

    }
}