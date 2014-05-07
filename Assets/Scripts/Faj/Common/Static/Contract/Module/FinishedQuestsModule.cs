using Faj.Common.Static.Contract.Condition.Interface;
using Uddle.Static.Contract.Module.Condition.Interface;
using Uddle.Static.Contract.Module;

namespace Faj.Common.Static.Contract.Module
{
    class FinishedQuestsModule : AbstractContractModule
    {
        protected const string moduleName = "finishedquests";

        public FinishedQuestsModule(ICountCondition condition)
        {
            this.condition = condition as ICondition;
        }

        public override string GetName()
        {
            return moduleName;
        }
    }
}
