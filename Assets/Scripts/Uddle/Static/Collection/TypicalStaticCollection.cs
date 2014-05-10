using System.Collections.Generic;
using Uddle.Static.Collection.Interface;
using Uddle.Static.Collection.Item;

namespace Uddle.Static.Collection
{
    abstract class TypicalStaticCollection<TStaticItem> : IStaticGenericCollection<TStaticItem> where TStaticItem : IStaticItem
	{
        protected Dictionary<string, TStaticItem> items = new Dictionary<string, TStaticItem>();

        public void AddItem(string id, TStaticItem item)
        {
            items.Add(id, item);
        }

        public Dictionary<string, TStaticItem> GetItems()
        {
            return items;
        }

        public TStaticItem GetItem(string id)
        {
            TStaticItem item;

            items.TryGetValue(id, out item);

            return item;
        }
	}
}