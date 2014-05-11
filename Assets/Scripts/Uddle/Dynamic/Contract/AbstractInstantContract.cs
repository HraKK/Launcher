using Uddle.Static.Contract.Interface;
using Uddle.Model.Player.Interface;
namespace Uddle.Dynamic.Contract
{
    class AbstractInstantContract : AbstractContract
	{
        public AbstractInstantContract(IStaticContract contract, IPlayerModel playerModel)
            : base(contract, playerModel)
        {
        }

        public override bool Start()
        {
            if (false == base.Start())
            {
                return false;
            }

            return Finish();
        }
	}
}
