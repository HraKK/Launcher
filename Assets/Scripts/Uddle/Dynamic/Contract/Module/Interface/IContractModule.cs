using Uddle.Model.Player.Interface;
using Uddle.Static.Contract.Module.Condition.Interface;
using Uddle.Static.Contract.Interface;

namespace Uddle.Dynamic.Contract.Module.Interface
{
	interface IContractModule
	{
        bool Check(IStaticContract contract, IPlayerModel playerModel, ICondition condition);
        void Pay(IStaticContract contract, IPlayerModel playerModel, ICondition condition);
        void Award(IStaticContract contract, IPlayerModel playerModel, ICondition condition);
	}
}
