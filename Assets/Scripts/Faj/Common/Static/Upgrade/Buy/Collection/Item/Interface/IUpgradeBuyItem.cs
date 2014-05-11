using Uddle.Static.Contract.Interface;

namespace Faj.Common.Static.Upgrade.Buy.Collection.Item.Interface
{
    interface IUpgradeBuyItem : IStaticContract
    {
        string GetType();
        int GetLevel();
    }
}
