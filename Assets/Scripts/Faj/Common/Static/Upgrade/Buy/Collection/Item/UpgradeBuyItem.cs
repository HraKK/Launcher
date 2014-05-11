using Uddle.Static.Contract;
using Faj.Common.Static.Upgrade.Buy.Collection.Item.Interface;
using System.Collections.Generic;
using Uddle.Static.Contract.Module.Interface;

namespace Faj.Common.Static.Upgrade.Buy.Collection.Item
{
	class UpgradeBuyItem : AbstractContract, IUpgradeBuyItem
    {
        protected readonly string type;
        protected readonly int level;

        public UpgradeBuyItem(string id,
            List<IContractModule> checkStart,
            List<IContractModule> checkFinish,
            List<IContractModule> pay,
            List<IContractModule> award,
            List<IContractModule> skip,
            string type,
            int level) :
            base(id, checkStart, checkFinish, pay, award, skip)
        {
            this.type = type;
            this.level = level;
        }

        public string GetType()
        {
            return type;
        }

        public int GetLevel()
        {
            return level;
        }
    }
}
