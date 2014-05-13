using Uddle.Static.Contract.Module;
using Faj.Common.Static.Contract.Condition.Interface;

namespace Faj.Common.Static.Contract.Module
{
	class PerksModule : AbstractContractModule
	{
        protected const string moduleName = "perks";

        public PerksModule(IIdCondition condition)
        {
            this.condition = condition;
        }

        public override string GetName()
        {
            return moduleName;
        }
	}
}
