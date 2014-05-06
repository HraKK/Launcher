using Uddle.Static.Contract.Module.Condition.Interface;
using Faj.Common.Static.Contract.Condition.Interface;
using Uddle.Static.Contract.Module;

namespace Faj.Common.Static.Contract.Module
{
	class FinishedLevelModule : AbstractContractModule
	{
        protected const string moduleName = "finishedlevel";

        public FinishedLevelModule(IIdCondition idCondition)
        {
            this.condition = idCondition as ICondition;
        }

        public override string GetName()
        {
            return moduleName;
        }
	}
}