using Uddle.Model.Player.Interface;
using Uddle.Static.Contract.Module.Condition.Interface;

namespace Uddle.Dynamic.Contract.Module.Interface
{
	interface IContractModule
	{
        bool Check(IPlayerModel playerModel, ICondition condition);
        void Pay(IPlayerModel playerModel, ICondition condition);
        void Award(IPlayerModel playerModel, ICondition condition);
	}
}
