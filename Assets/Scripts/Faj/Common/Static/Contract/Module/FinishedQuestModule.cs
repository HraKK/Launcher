using Faj.Common.Static.Contract.Condition.Interface;
using Uddle.Static.Contract.Module.Condition.Interface;
using Uddle.Static.Contract.Module;

namespace Faj.Common.Static.Contract.Module
{
	class FinishedQuestModule: AbstractContractModule
	{
        protected const string moduleName = "finishedquest";
        IIdCondition idCondition;

        public FinishedQuestModule(IIdCondition idCondition)
        {
            this.idCondition = idCondition;
        }

        public ICondition GetCondition()
        {
            return idCondition;
        }

        public override string GetName()
        {
            return moduleName;
        }
	}
}
