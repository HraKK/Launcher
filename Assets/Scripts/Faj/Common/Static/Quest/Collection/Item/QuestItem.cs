using Uddle.Static.Contract;
using Faj.Common.Static.Quest.Collection.Item.Interface;
using System.Collections.Generic;
using Uddle.Static.Contract.Module.Interface;

namespace Faj.Common.Static.Quest.Collection.Item
{
	class QuestItem: AbstractContract, IQuestItem
    {
        protected readonly string level;
        protected readonly string action;
        protected readonly string target;
        protected readonly int value;

        public QuestItem(string id,
            List<IContractModule> checkStart,
            List<IContractModule> checkFinish,
            List<IContractModule> pay,
            List<IContractModule> award,
            List<IContractModule> skip,
            string level,
            string action,
            string target,
            int value) :
            base(id, checkStart, checkFinish, pay, award, skip)
        {
            this.level = level;
            this.action = action;
            this.target = target;
            this.value = value;
        }

        public string GetLevel()
        {
            return level;
        }

        public string GetAction()
        {
            return action;
        }

        public string GetTarget()
        {
            return target;
        }

        public int GetValue()
        {
            return value;
        }
    }
}
