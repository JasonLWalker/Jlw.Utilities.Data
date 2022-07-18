using System.Collections.Generic;
using System.Data;
using System.Data.Common;

namespace Jlw.Utilities.Data.DbUtility
{
    /// <summary>
    /// Interface IModularDataRepository
    /// </summary>
    /// <typeparam name="TInterface">The type of the t interface.</typeparam>
    /// <typeparam name="TModel">The type of the t model.</typeparam>
    /// TODO Edit XML Comment Template for IModularDataRepository`2
    public interface IModularDataRepository<TInterface, TModel> where TModel : TInterface
    {
        string ConnectionString { get; }
        DbConnectionStringBuilder ConnectionBuilder { get; }

        IModularDbClient DbClient { get; }

        //TInterface GetRecordObject(TInterface objSearch, string definitionName);
        //TReturn GetRecordObject<TReturn>(TInterface objSearch, string definitionName);

        //object GetRecordScalar(TInterface objSearch, string definitionName);
        //TReturn GetRecordScalar<TReturn>(TInterface objSearch, string definitionName);


        //RepositoryMethodDefinition<TInterface, TModel> AddDefinition(string name, RepositoryMethodDefinition<TInterface, TModel> definition);

        //RepositoryMethodDefinition<TInterface, TModel> AddNewDefinition(string name, string query, IEnumerable<string> paramList, CommandType cmdType = CommandType.Text, RepositoryRecordCallback callback = null);
        //RepositoryMethodDefinition<TInterface, TModel> AddNewDefinition(string name, string query, IEnumerable<KeyValuePair<string, object>> paramList, CommandType cmdType = CommandType.Text, RepositoryRecordCallback callback = null);
        //RepositoryMethodDefinition<TInterface, TModel> AddNewDefinition(string name, string query, IEnumerable<IDbDataParameter> paramList = null, CommandType cmdType = CommandType.Text, RepositoryRecordCallback callback = null);
    }
}