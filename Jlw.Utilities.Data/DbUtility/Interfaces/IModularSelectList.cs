using System.Collections.Generic;

namespace Jlw.Utilities.Data.DbUtility
{
    /// <summary>
    /// Interface IModularSelectList
    /// </summary>
    /// <typeparam name="TSelectListItem">The type of the t select list item.</typeparam>
    /// <typeparam name="TInterface">The type of the t interface.</typeparam>
    /// <typeparam name="TModel">The type of the t model.</typeparam>
    /// TODO Edit XML Comment Template for IModularSelectList`3
    public interface IModularSelectList<TSelectListItem, TInterface, TModel>
        where TModel : class, TInterface
    {
        IEnumerable<TSelectListItem> Items { get; }

        void Refresh();
    }
}
