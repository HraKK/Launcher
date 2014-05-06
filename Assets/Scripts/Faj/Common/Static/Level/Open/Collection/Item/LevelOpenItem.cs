using Uddle.Static.Contract;
using System.Collections.Generic;
using Uddle.Static.Contract.Module.Interface;
using Faj.Common.Static.Level.Open.Collection.Item.Interface;

namespace Faj.Common.Static.Level.Open.Collection.Item
{
	class LevelOpenItem : AbstractContract, ILevelOpenItem
    {
        public LevelOpenItem(string id,
            List<IContractModule> checkStart,
            List<IContractModule> checkFinish,
            List<IContractModule> pay,
            List<IContractModule> award) :
            base(id, checkStart, checkFinish, pay, award)
        {
        }
    }
}
