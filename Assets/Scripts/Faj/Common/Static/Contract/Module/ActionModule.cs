using Faj.Common.Static.Contract.Condition.Interface;
using Uddle.Static.Contract.Module.Condition.Interface;
using Uddle.Static.Contract.Module;

namespace Faj.Common.Static.Contract.Module
{
    class ActionModule : AbstractContractModule
    {
        protected const string moduleName = "action";

        public ActionModule(ICountCondition condition)
        {
            this.condition = condition as ICondition;
        }

        public override string GetName()
        {
            return moduleName;
        }
    }
}
