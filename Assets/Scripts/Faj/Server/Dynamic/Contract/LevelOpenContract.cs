using Uddle.Dynamic.Contract;
using Uddle.Static.Contract.Interface;
using Uddle.Model.Player.Interface;

namespace Faj.Server.Dynamic.Contract
{
    class LevelOpenContract : AbstractInstantContract
	{
        public LevelOpenContract(IStaticContract contract, IPlayerModel playerModel)
            : base(contract, playerModel)
        {
        }
	}
}
