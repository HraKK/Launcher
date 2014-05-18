using Uddle.Static.Contract.Module;
using Faj.Common.Static.Contract.Condition.Interface;

namespace Faj.Common.Static.Contract.Module
{
	class LevelTimeModule : AbstractContractModule
	{
        protected const string moduleName = "leveltime";

        public LevelTimeModule(IIntCondition condition)
        {
            this.condition = condition;
        }

        public override string GetName()
        {
            return moduleName;
        }
	}
}
