using Uddle.Static.Contract;
using System.Collections.Generic;
using Uddle.Static.Contract.Module.Interface;

namespace Faj.Common.Static.Level.Open.Collection.Item
{
	class LevelOpenItem : AbstractContract
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
