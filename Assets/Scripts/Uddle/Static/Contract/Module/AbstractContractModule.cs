using Uddle.Static.Contract.Module.Interface;
using Uddle.Static.Contract.Module.Condition.Interface;

namespace Uddle.Static.Contract.Module
{
	abstract class AbstractContractModule : IContractModule
	{
        protected ICondition condition;

        public ICondition GetCondition()
        {
            return condition;
        }

        public abstract string GetName();
	}
}
