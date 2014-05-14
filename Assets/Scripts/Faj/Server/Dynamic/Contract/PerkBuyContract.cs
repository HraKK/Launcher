using Uddle.Static.Contract.Interface;
using Uddle.Model.Player.Interface;
using Uddle.Dynamic.Contract;

namespace Faj.Server.Dynamic.Contract
{
    class PerkBuyContract : AbstractInstantContract
	{
        public PerkBuyContract(IStaticContract contract, IPlayerModel playerModel)
            : base(contract, playerModel)
        {
        }
	}
}
