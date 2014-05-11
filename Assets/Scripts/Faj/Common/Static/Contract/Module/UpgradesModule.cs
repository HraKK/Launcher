using Uddle.Static.Contract.Module;
using Faj.Common.Static.Contract.Condition.Interface;
using Uddle.Static.Contract.Module.Condition.Interface;

namespace Faj.Common.Static.Contract.Module
{
	class UpgradesModule : AbstractContractModule
	{
        protected const string moduleName = "upgrades";

        public UpgradesModule(IIntCondition intCondition)
        {
            this.condition = intCondition as ICondition;
        }

        public override string GetName()
        {
            return moduleName;
        }
	}
}
