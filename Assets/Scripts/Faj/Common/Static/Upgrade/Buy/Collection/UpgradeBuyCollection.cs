using Uddle.Static.Collection;
using Faj.Common.Static.Upgrade.Buy.Collection.Item.Interface;
using Faj.Common.Static.Upgrade.Buy.Collection.Interface;

namespace Faj.Common.Static.Upgrade.Buy.Collection
{
	class UpgradeBuyCollection : TypicalStaticCollection<IUpgradeBuyItem>, IUpgradeBuyCollection
	{
        public IUpgradeBuyItem GetUpgradeBuyItem(string type, int level)
        {
            foreach (var item in items)
            {
                var upgradeBuyItem = item.Value;
                var upgradeBuyItemType = upgradeBuyItem.GetType();
                var upgradeBuyItemLevel = upgradeBuyItem.GetLevel();

                if (type != upgradeBuyItemType)
                {
                    continue;
                }

                if (level != upgradeBuyItemLevel)
                {
                    continue;
                }

                return upgradeBuyItem;
            }

            return null;
        }
	}
}
