using Uddle.Static.Collection.Item;

namespace Faj.Common.Static.Level.Monster.Collection.Item.Interface
{
	interface ILevelMonsterItem : IStaticItem
	{
        string GetId();
        string GetLevelId();
        string GetMonsterId();
        int GetCount();
	}
}
