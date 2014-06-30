using Uddle.Static.Collection.Item;

namespace Faj.Common.Static.Perk.Collection.Item.Interface
{
	interface IPerkItem : IStaticItem
    {
        string GetId();
        string GetType();
        string GetDescription();
    }
}
