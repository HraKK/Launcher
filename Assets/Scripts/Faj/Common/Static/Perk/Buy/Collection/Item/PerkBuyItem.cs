
using Uddle.Static.Contract;
using Faj.Common.Static.Perk.Buy.Collection.Item.Interface;
using System.Collections.Generic;
using Uddle.Static.Contract.Module.Interface;

namespace Faj.Common.Static.Perk.Buy.Collection.Item
{
	class PerkBuyItem : AbstractContract, IPerkBuyItem
    {
        public PerkBuyItem(string id,
            List<IContractModule> checkStart,
            List<IContractModule> checkFinish,
            List<IContractModule> pay,
            List<IContractModule> award,
            List<IContractModule> skip) : 
            base(id, checkStart, checkFinish, pay, award, skip)
        {
        }
    }
}