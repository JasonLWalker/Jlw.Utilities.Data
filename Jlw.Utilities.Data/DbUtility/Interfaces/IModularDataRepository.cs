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

    }
}