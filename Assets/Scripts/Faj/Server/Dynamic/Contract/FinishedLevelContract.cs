using Uddle.Dynamic.Contract;
using Uddle.Static.Contract.Interface;
using Uddle.Model.Player.Interface;

namespace Faj.Server.Dynamic.Contract
{
	class FinishedLevelContract : AbstractContract
	{
        public FinishedLevelContract(IStaticContract contract, IPlayerModel playerModel)
            : base(contract, playerModel)
        {
        }
	}
}
