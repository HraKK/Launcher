using Uddle.Static.Collection.Item;

namespace Faj.Common.Static.Upgrade.Type.Collection.Item.Interface
{
    interface IUpgradeTypeItem : IStaticItem
    {
        string GetId();
        string GetCategory();
        string GetDescription();
    }
}
