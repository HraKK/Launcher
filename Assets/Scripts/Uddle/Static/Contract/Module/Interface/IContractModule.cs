using Uddle.Static.Contract.Module.Condition.Interface;

namespace Uddle.Static.Contract.Module.Interface
{
	interface IContractModule
	{
        string GetName();
        ICondition GetCondition();
	}
}
