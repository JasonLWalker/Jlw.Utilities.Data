using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Jlw.Utilities.Data.Tests")]
namespace Jlw.Utilities.Data.DbUtility
{
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

        protected internal RepositoryMethodDefinition<TInterface, TModel> GetDefinition(string key)
        {
            return _definitions.FirstOrDefault(o => o.Key.Equals(key, StringComparison.InvariantCultureIgnoreCase)).Value;            
        }

        protected internal RepositoryMethodDefinition<TInterface, TModel> AddDefinition(string name, RepositoryMethodDefinition<TInterface, TModel> definition)
        {
            _definitions.Add(name, definition);
            return _definitions[name];
        }

        protected internal RepositoryMethodDefinition<TInterface, TModel> AddNewDefinition(string name, string query, IEnumerable<string> paramList, CommandType cmdType = CommandType.Text, RepositoryRecordCallback callback = null)
        {
                var def = new RepositoryMethodDefinition<TInterface, TModel>(query, cmdType, paramList, callback);
                return AddDefinition(name, def);
        }
        protected internal RepositoryMethodDefinition<TInterface, TModel> AddNewDefinition(string name, string query, IEnumerable<KeyValuePair<string, object>> paramList, CommandType cmdType = CommandType.Text, RepositoryRecordCallback callback = null)
        {
            var def = new RepositoryMethodDefinition<TInterface, TModel>(query, cmdType, paramList, callback);
            return AddDefinition(name, def);
        }

        protected internal RepositoryMethodDefinition<TInterface, TModel> AddNewDefinition(string name, string query, IEnumerable<IDbDataParameter> paramList = null, CommandType cmdType = CommandType.Text, RepositoryRecordCallback callback = null)
        {
            var def = new RepositoryMethodDefinition<TInterface, TModel>(query, cmdType, paramList, callback);
            return AddDefinition(name, def);
        }

        protected internal virtual TInterface GetRecordObject(TInterface objSearch, string definitionName) => GetRecordObject<TInterface>(objSearch, definitionName);
        /*
        {
            RepositoryMethodDefinition<TInterface, TModel> def = GetDefinition(definitionName);
            if (def == null)
            {
                throw new ArgumentException($"No repository definition found named \"{definitionName}\"", nameof(definitionName));
            }

            return _dbClient.GetRecordObject(objSearch, ConnectionString, def);
        }
        */

        protected internal TReturn GetRecordObject<TReturn>(TInterface objSearch, string definitionName)
        {
            var def = GetDefinition(definitionName);
            if (def == null)
            {
                throw new ArgumentException($"No repository definition found named \"{definitionName}\"", nameof(definitionName));
            }



            return _dbClient.GetRecordObject<TInterface, TModel, TReturn>(objSearch, ConnectionString, def);

        }

        protected internal object GetRecordScalar(TInterface objSearch, string definitionName) => GetRecordScalar<object>(objSearch, definitionName);

        protected internal TReturn GetRecordScalar<TReturn>(TInterface objSearch, string definitionName)
        {
            var def = GetDefinition(definitionName);
            if (def == null)
            {
                throw new ArgumentException($"No repository definition found named \"{definitionName}\"", nameof(definitionName));
            }



            return _dbClient.GetRecordScalar<TInterface, TModel, TReturn>(objSearch, ConnectionString, def);

        }




        protected internal virtual TInterface GetRecord(TInterface o) => GetRecordObject(o, nameof(GetRecord));
        protected internal virtual TInterface InsertRecord(TInterface o) => GetRecordObject(o, nameof(InsertRecord));
        protected internal virtual TInterface SaveRecord(TInterface o) => GetRecordObject(o, nameof(SaveRecord));
        protected internal virtual TInterface UpdateRecord(TInterface o) => GetRecordObject(o, nameof(UpdateRecord));
        protected internal virtual TInterface DeleteRecord(TInterface o) => GetRecordObject(o, nameof(DeleteRecord));

    }
}
