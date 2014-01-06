using System.Collections.Generic;
using Uddle.Static.Collection.Item;
namespace Uddle.Static.Collection.Interface
{
    interface IStaticGenericCollection<TStaticItem> : IStaticCollection where TStaticItem : IStaticItem
	{
        void AddItem(string id, TStaticItem item);
        Dictionary<string, TStaticItem> GetItems();
        TStaticItem GetItem(string id);
	}
}
