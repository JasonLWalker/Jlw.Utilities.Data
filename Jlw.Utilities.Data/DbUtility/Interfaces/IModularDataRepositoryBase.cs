using System.Collections.Generic;

namespace Jlw.Utilities.Data.DbUtility
{
    /// <summary>
    /// Interface IModularDataRepositoryBase
    /// </summary>
    /// <typeparam name="TInterface">The type of the t interface.</typeparam>
    /// <typeparam name="TModel">The type of the t model.</typeparam>
    public interface IModularDataRepositoryBase<TInterface, TModel>
    {
        TInterface GetRecord(TInterface o);
        IEnumerable<TInterface> GetAllRecords();
        TInterface InsertRecord(TInterface o);
        TInterface SaveRecord(TInterface o);
        TInterface UpdateRecord(TInterface o);
        TInterface DeleteRecord(TInterface o);

        IEnumerable<KeyValuePair<string, string>> GetKvpList(string keyMember = null, string descMember = null);
    }


}