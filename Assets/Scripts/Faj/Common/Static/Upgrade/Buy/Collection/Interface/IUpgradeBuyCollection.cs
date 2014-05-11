using Uddle.Static.Collection.Interface;
using Faj.Common.Static.Upgrade.Buy.Collection.Item.Interface;

namespace Faj.Common.Static.Upgrade.Buy.Collection.Interface
{
	interface IUpgradeBuyCollection : IStaticGenericCollection<IUpgradeBuyItem>
    {
        IUpgradeBuyItem GetUpgradeBuyItem(string type, int level);
    }
}
