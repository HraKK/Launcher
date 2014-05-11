using Uddle.Static.Collection.Item;

namespace Faj.Common.Static.Upgrade.Collection.Item.Interface
{
	interface IUpgradeItem : IStaticItem
    {
        string GetId();
        int GetLevel();
        int GetValue();
    }
}
