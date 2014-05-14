using Uddle.Dynamic.Contract.Module.Interface;
using Uddle.Static.Contract.Interface;
using Uddle.Model.Player.Interface;
using Uddle.Static.Contract.Module.Condition.Interface;
using Faj.Common.Static.Contract.Condition.Interface;

namespace Faj.Server.Dynamic.Contract.Module
{
	class PerksModule : IContractModule
	{
        public bool Check(IStaticContract contract, IPlayerModel playerModel, ICondition condition)
        {
            var serverPlayerModel = playerModel as Faj.Server.Model.Player.Interface.IPlayerModel;
            var perkCondition = condition as IIdCondition;
            var perk = perkCondition.GetId();

            return serverPlayerModel.GetPerks().IsPerk(perk);
        }

        public void Pay(IStaticContract contract, IPlayerModel playerModel, ICondition condition)
        {

        }

        public void Award(IStaticContract contract, IPlayerModel playerModel, ICondition condition)
        {
            var serverPlayerModel = playerModel as Faj.Server.Model.Player.Interface.IPlayerModel;
            var perkCondition = condition as IIdCondition;
            var perk = perkCondition.GetId();

            serverPlayerModel.GetPerks().AddPerk(perk);
        }
	}
}
