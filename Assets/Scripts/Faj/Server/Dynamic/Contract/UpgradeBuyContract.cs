using Uddle.Dynamic.Contract;
using Uddle.Static.Contract.Interface;
using Faj.Server.Model.Player.Interface;

namespace Faj.Server.Dynamic.Contract
{
	class UpgradeBuyContract : AbstractInstantContract
	{
        public UpgradeBuyContract(IStaticContract contract, IPlayerModel playerModel)
            : base(contract, playerModel)
        {
        }
	}
}
