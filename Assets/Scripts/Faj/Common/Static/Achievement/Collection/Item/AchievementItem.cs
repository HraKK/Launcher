using Uddle.Static.Contract;
using Faj.Common.Static.Achievement.Collection.Item.Interface;
using System.Collections.Generic;
using Uddle.Static.Contract.Module.Interface;

namespace Faj.Common.Static.Achievement.Collection.Item
{
	class AchievementItem : AbstractContract, IAchievementItem
    {
        protected readonly string action;
        protected readonly string target;
        protected readonly int value;

        public AchievementItem(string id,
            List<IContractModule> checkStart,
            List<IContractModule> checkFinish,
            List<IContractModule> pay,
            List<IContractModule> award,
            List<IContractModule> skip,
            string action,
            string target,
            int value) :
            base(id, checkStart, checkFinish, pay, award, skip)
        {
            this.action = action;
            this.target = target;
            this.value = value;
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
