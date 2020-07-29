using System;
using System.Collections.Generic;

namespace Jlw.Standard.Utilities.Data.DbUtility.Models
{
    public class ModularSelectList<TSelectListItem, TInterface, TModel> : IModularSelectList<TSelectListItem, TInterface, TModel>
        where TModel : class, TInterface
    {
        protected readonly List<TSelectListItem> _items = new List<TSelectListItem>();
        protected readonly IModularDataRepositoryBase<TInterface, TModel> _repo;

        public IEnumerable<TSelectListItem> Items => _items;

        public ModularSelectList(IModularDataRepositoryBase<TInterface, TModel> repo)
        {
            _repo = repo;
            Initialize();
        }

        protected void Initialize()
        {
            _items.Clear();
            IEnumerable<KeyValuePair<string, string>> aList = _repo.GetKvpList();
            foreach (var o in aList)
            {
                TSelectListItem item = (TSelectListItem) Activator.CreateInstance(typeof(TSelectListItem));
                typeof(TSelectListItem).GetProperty("Value")?.SetMethod?.Invoke(item, new object[] {o.Key});
                typeof(TSelectListItem).GetProperty("Text")?.SetMethod?.Invoke(item, new object[] {o.Value});
                //, new object[] {o.Key, o.Value}
                _items.Add(item);
            }
        }

        public void Refresh()
        {
            Initialize();
        }
    }
}