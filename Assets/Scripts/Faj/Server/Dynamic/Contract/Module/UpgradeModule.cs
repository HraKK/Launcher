using Uddle.Dynamic.Contract.Module.Interface;
using Uddle.Static.Contract.Interface;
using Uddle.Model.Player.Interface;
using Uddle.Static.Contract.Module.Condition.Interface;
using Faj.Common.Static.Contract.Condition.Interface;
using Faj.Common.Static.Upgrade.Buy.Collection.Item.Interface;

namespace Faj.Server.Dynamic.Contract.Module
{
	class UpgradeModule: IContractModule
	{
        public bool Check(IStaticContract contract, IPlayerModel playerModel, ICondition condition)
        {
            var upgradeBuyContract = contract as IUpgradeBuyItem;
            var serverPlayerModel = playerModel as Faj.Server.Model.Player.Interface.IPlayerModel;
            var upgradeCondition = condition as IIntCondition;
            var upgradeLevel = upgradeCondition.GetValue();
            var type = upgradeBuyContract.GetType();
            
            return serverPlayerModel.GetUpgrades().IsUpgradeEnough(type, upgradeLevel);
        }

        public void Pay(IStaticContract contract, IPlayerModel playerModel, ICondition condition)
        {

        }

        public void Award(IStaticContract contract, IPlayerModel playerModel, ICondition condition)
        {
            var upgradeBuyContract = contract as IUpgradeBuyItem;
            var serverPlayerModel = playerModel as Faj.Server.Model.Player.Interface.IPlayerModel;
            var upgradeCondition = condition as IIntCondition;
            var upgradeLevel = upgradeCondition.GetValue();
            var type = upgradeBuyContract.GetType();

            serverPlayerModel.GetUpgrades().SetUpgrade(type, upgradeLevel);
        }
	}
}
