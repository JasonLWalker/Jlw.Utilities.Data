using System.Collections.Generic;

namespace Jlw.Standard.Utilities.Data.DbUtility
{
    public interface IModularDataRepositoryBase: IModularDataRepositoryBase<object> { }

    public interface IModularDataRepositoryBase<TModel> : IModularDataRepositoryBase<TModel, TModel> 
        where TModel : class
    { }


    public interface IModularDataRepositoryBase<TInterface, TModel>
        where TModel : class
    {
        TInterface GetRecord(TInterface o);
        IEnumerable<TInterface> GetAllRecords();
        TInterface InsertRecord(TInterface o);
        TInterface SaveRecord(TInterface o);
        TInterface UpdateRecord(TInterface o);
        bool DeleteRecord(TInterface o);
        IEnumerable<KeyValuePair<string, string>> GetKvpList();
    }


}