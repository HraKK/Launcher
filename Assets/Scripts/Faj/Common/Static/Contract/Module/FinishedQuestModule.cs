using Faj.Common.Static.Contract.Condition.Interface;
using Uddle.Static.Contract.Module.Condition.Interface;
using Uddle.Static.Contract.Module;

namespace Faj.Common.Static.Contract.Module
{
	class FinishedQuestModule : AbstractContractModule
	{
        protected const string moduleName = "finishedquest";

        public FinishedQuestModule(IIdCondition condition)
        {
            this.condition = condition;
        }

        public override string GetName()
        {
            return moduleName;
        }
	}
}
