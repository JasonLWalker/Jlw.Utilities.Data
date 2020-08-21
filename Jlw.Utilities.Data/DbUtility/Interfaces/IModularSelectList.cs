using System.Collections.Generic;

namespace Jlw.Utilities.Data.DbUtility
{
    public interface IModularSelectList<TSelectListItem, TInterface, TModel>
        where TModel : class, TInterface
    {
        IEnumerable<TSelectListItem> Items { get; }

        void Refresh();
    }
}
