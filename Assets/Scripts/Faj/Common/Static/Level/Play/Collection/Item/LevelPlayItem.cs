using Uddle.Static.Contract;
using Faj.Common.Static.Level.Play.Collection.Item.Interface;
using System.Collections.Generic;
using Uddle.Static.Contract.Module.Interface;

namespace Faj.Common.Static.Level.Play.Collection.Item
{
	class LevelPlayItem : AbstractContract, ILevelPlayItem
    {
        protected readonly int rate;
        protected readonly string levelId;

        public LevelPlayItem(string id,
            List<IContractModule> checkStart,
            List<IContractModule> checkFinish,
            List<IContractModule> pay,
            List<IContractModule> award,
            List<IContractModule> skip,
            int rate,
            string levelId) :
            base(id, checkStart, checkFinish, pay, award, skip)
        {
            this.rate = rate;
            this.levelId = levelId;
        }

        public int GetRate()
        {
            return rate;
        }

        public string GetLevelId()
        {
            return levelId;
        }
    }
}
