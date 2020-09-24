using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;

namespace Jlw.Utilities.Data.DbUtility
{
    public interface IModularDataRepository<TInterface, TModel> where TModel : TInterface
    {
        string ConnectionString { get; }
        DbConnectionStringBuilder ConnectionBuilder { get; }

        IModularDbClient DbClient { get; }

        TInterface GetRecordObject(TInterface objSearch, string definitionName);

        RepositoryMethodDefinition<TInterface, TModel> AddNewDefinition(string name, string query, IEnumerable<string> paramList, CommandType cmdType = CommandType.Text, RepositoryRecordCallback<TInterface> callback = null);
        RepositoryMethodDefinition<TInterface, TModel> AddNewDefinition(string name, string query, IEnumerable<KeyValuePair<string, object>> paramList, CommandType cmdType = CommandType.Text, RepositoryRecordCallback<TInterface> callback = null);
        RepositoryMethodDefinition<TInterface, TModel> AddNewDefinition(string name, string query, IEnumerable<IDbDataParameter> paramList = null, CommandType cmdType = CommandType.Text, RepositoryRecordCallback<TInterface> callback = null);
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

        public ModularDataRepository(IModularDbClient dbClient, string connString = "")
        {
            _dbClient = dbClient ?? new ModularDbClient<NullDbConnection, NullDbCommand, NullDbParameter>();
            _builder = _dbClient.GetConnectionBuilder(connString);
        }

        protected RepositoryMethodDefinition<TInterface, TModel> GetDefinition(string key)
        {
            return _definitions.FirstOrDefault(o => o.Key.Equals(key, StringComparison.InvariantCultureIgnoreCase)).Value;            
            /*
            if (_definitions?.ContainsKey(key) ?? false)
            {
                return _definitions[key];
            }

            return null;
            */
        }

        public RepositoryMethodDefinition<TInterface, TModel> AddNewDefinition(string name, string query, IEnumerable<string> paramList, CommandType cmdType = CommandType.Text, RepositoryRecordCallback<TInterface> callback = null)
        {
            var def = new RepositoryMethodDefinition<TInterface, TModel>(query, cmdType, paramList, callback);
            _definitions.Add(name, def);
            return def;
        }

        public RepositoryMethodDefinition<TInterface, TModel> AddNewDefinition(string name, string query, IEnumerable<KeyValuePair<string, object>> paramList, CommandType cmdType = CommandType.Text, RepositoryRecordCallback<TInterface> callback = null)
        {
            var def = new RepositoryMethodDefinition<TInterface, TModel>(query, cmdType, paramList, callback);
            _definitions.Add(name, def);
            return def;
        }

        public RepositoryMethodDefinition<TInterface, TModel> AddNewDefinition(string name, string query, IEnumerable<IDbDataParameter> paramList = null, CommandType cmdType = CommandType.Text, RepositoryRecordCallback<TInterface> callback = null)
        {
            var def = new RepositoryMethodDefinition<TInterface, TModel>(query, cmdType, paramList, callback);
            _definitions.Add(name, def);
            return def;
        }

        public virtual TInterface GetRecordObject(TInterface objSearch, string definitionName)
        {
            RepositoryMethodDefinition<TInterface, TModel> def = GetDefinition(definitionName);
            if (def == null)
            {
                throw new ArgumentException($"No repository definition found named \"{definitionName}\"", nameof(definitionName));
            }

            return _dbClient.GetRecordObject(objSearch, ConnectionString, def);
        }



        public virtual TInterface GetRecord(TInterface o) => GetRecordObject(o, nameof(GetRecord));
        public virtual TInterface InsertRecord(TInterface o) => GetRecordObject(o, nameof(InsertRecord));
        public virtual TInterface SaveRecord(TInterface o) => GetRecordObject(o, nameof(SaveRecord));
        public virtual TInterface UpdateRecord(TInterface o) => GetRecordObject(o, nameof(UpdateRecord));
        public virtual TInterface DeleteRecord(TInterface o) => GetRecordObject(o, nameof(DeleteRecord));

    }
}
