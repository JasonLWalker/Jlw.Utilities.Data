using System.Collections.Generic;

namespace Jlw.Utilities.Data.DbUtility
{
    public interface IModularDataRepositoryBase<TInterface, TModel>
    {
        TInterface GetRecord(TInterface o);
        IEnumerable<TInterface> GetAllRecords();
        TInterface InsertRecord(TInterface o);
        TInterface SaveRecord(TInterface o);
        TInterface UpdateRecord(TInterface o);
        TInterface DeleteRecord(TInterface o);
        IEnumerable<KeyValuePair<string, string>> GetKvpList();
    }


}