using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Jlw.Utilities.Data.Tests")]
namespace Jlw.Utilities.Data.DbUtility
{
    public class ModularDataRepository : ModularDataRepository<object, object>
    {
        public ModularDataRepository(IModularDbClient dbClient, string connString = "") : base(dbClient, connString)
        {
        }
    }
    
    public class ModularDataRepository<TInterface, TModel> : IModularDataRepository<TInterface, TModel>
    where TModel : TInterface
    {
        // ReSharper disable InconsistentNaming
        protected IModularDbClient _dbClient;
        protected DbConnectionStringBuilder _builder { get; }
        protected IDictionary<string, IRepositoryMethodDefinition> _definitions = new Dictionary<string, IRepositoryMethodDefinition>();
        // ReSharper restore InconsistentNaming


        public DbConnectionStringBuilder ConnectionBuilder => _builder;
        public string ConnectionString => _builder.ConnectionString;
        public IModularDbClient DbClient => _dbClient;

        public ModularDataRepository(IModularDbClient dbClient, string connString = "")
        {
            _dbClient = dbClient ?? new ModularDbClient<NullDbConnection, NullDbCommand, NullDbParameter>();
            _builder = _dbClient.GetConnectionBuilder(connString);
        }

        protected internal IRepositoryMethodDefinition GetDefinition(string key)
        {
            return _definitions.FirstOrDefault(o => o.Key.Equals(key, StringComparison.InvariantCultureIgnoreCase)).Value;            
        }

        protected internal IRepositoryMethodDefinition AddDefinition(string name, IRepositoryMethodDefinition definition)
        {
            _definitions.Add(name, definition);
            return _definitions[name];
        }

        protected internal IRepositoryMethodDefinition AddNewDefinition(string name, string query, IEnumerable<string> paramList, CommandType cmdType = CommandType.Text, RepositoryRecordCallback callback = null)
        {
                var def = new RepositoryMethodDefinition<TInterface, TModel>(query, cmdType, paramList, callback);
                return AddDefinition(name, def);
        }
        protected internal IRepositoryMethodDefinition AddNewDefinition(string name, string query, IEnumerable<KeyValuePair<string, object>> paramList, CommandType cmdType = CommandType.Text, RepositoryRecordCallback callback = null)
        {
            var def = new RepositoryMethodDefinition<TInterface, TModel>(query, cmdType, paramList, callback);
            return AddDefinition(name, def);
        }

        protected internal IRepositoryMethodDefinition AddNewDefinition(string name, string query, IEnumerable<IDbDataParameter> paramList = null, CommandType cmdType = CommandType.Text, RepositoryRecordCallback callback = null)
        {
            var def = new RepositoryMethodDefinition<TInterface, TModel>(query, cmdType, paramList, callback);
            return AddDefinition(name, def);
        }

        protected internal virtual TInterface GetRecordObject(TInterface objSearch, string definitionName) => GetRecordObject<TInterface>(objSearch, definitionName);

        protected internal TReturn GetRecordObject<TReturn>(object objSearch, string definitionName)
        {
            var def = GetDefinition(definitionName);
            if (def == null)
            {
                throw new ArgumentException($"No repository definition found named \"{definitionName}\"", nameof(definitionName));
            }



            return _dbClient.GetRecordObject<TReturn>(objSearch, ConnectionString, def);

        }

        protected internal TInterface GetRecordScalar(TInterface objSearch, string definitionName) => GetRecordScalar<TModel>(objSearch, definitionName);

        protected internal TReturn GetRecordScalar<TReturn>(object objSearch, string definitionName)
        {
            var def = GetDefinition(definitionName);
            if (def == null)
            {
                throw new ArgumentException($"No repository definition found named \"{definitionName}\"", nameof(definitionName));
            }



            return _dbClient.GetRecordScalar<TReturn>(objSearch, ConnectionString, def);

        }

        protected internal IEnumerable<TInterface> GetRecordList(TInterface objSearch, string definitionName) => (IEnumerable<TInterface>)GetRecordList<TModel>(objSearch, definitionName);

        protected internal IEnumerable<TReturn> GetRecordList<TReturn>(object objSearch, string definitionName)
        {
            var def = GetDefinition(definitionName);
            if (def == null)
            {
                throw new ArgumentException($"No repository definition found named \"{definitionName}\"", nameof(definitionName));
            }



            return _dbClient.GetRecordList<TReturn>(objSearch, ConnectionString, def);

        }
        

        protected internal virtual TInterface GetRecord(TInterface o) => GetRecordObject(o, DataUtility.GetCaller());
        protected internal virtual TInterface InsertRecord(TInterface o) => GetRecordObject(o, DataUtility.GetCaller());
        protected internal virtual TInterface SaveRecord(TInterface o) => GetRecordObject(o, DataUtility.GetCaller());
        protected internal virtual TInterface UpdateRecord(TInterface o) => GetRecordObject(o, DataUtility.GetCaller());
        protected internal virtual TInterface DeleteRecord(TInterface o) => GetRecordObject(o, DataUtility.GetCaller());

    }
}
