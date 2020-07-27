using System;
using System.Collections.Generic;
using System.Text;

namespace Jlw.Standard.Utilities.Data.DbUtility.Models
{
    public interface IModularSelectListItem<TSelectListItem, TInterface, TModel>
        where TModel : class, TInterface
    {
        IEnumerable<TSelectListItem> Items { get; }

        void Refresh();
    }

    class ModularSelectListItem<TSelectListItem, TInterface, TModel> : IModularSelectListItem<TSelectListItem, TInterface, TModel>
        where TModel : class, TInterface
    {
        protected readonly List<TSelectListItem> _items = new List<TSelectListItem>();
        protected readonly IModularDataRepositoryBase<TInterface, TModel> _repo;

        public IEnumerable<TSelectListItem> Items => _items;

        public ModularSelectListItem(IModularDataRepositoryBase<TInterface, TModel> repo)
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
                _items.Add((TSelectListItem) Activator.CreateInstance(typeof(TSelectListItem), new object[] {o.Key, o.Value}));
            }
        }

        public void Refresh()
        {
            Initialize();
        }
    }
}
