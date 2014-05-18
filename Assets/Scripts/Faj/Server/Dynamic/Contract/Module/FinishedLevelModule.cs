using Uddle.Dynamic.Contract.Module.Interface;
using Uddle.Model.Player.Interface;
using Uddle.Static.Contract.Module.Condition.Interface;
using Faj.Common.Static.Contract.Condition.Interface;
using Uddle.Static.Contract.Interface;

namespace Faj.Server.Dynamic.Contract.Module
{
	class FinishedLevelModule : IContractModule
	{
        public bool Check(IStaticContract contract, IPlayerModel playerModel, ICondition condition)
        {
            var serverPlayerModel = playerModel as Faj.Server.Model.Player.Interface.IPlayerModel;
            var finishLevelCondition = condition as IIdCondition;
            var levelId = finishLevelCondition.GetId();
            
            return serverPlayerModel.GetLevels().IsLevelOpen(levelId);
        }

        public void Pay(IStaticContract contract, IPlayerModel playerModel, ICondition condition)
        {

        }

        public void Award(IStaticContract contract, IPlayerModel playerModel, ICondition condition)
        {
            var serverPlayerModel = playerModel as Faj.Server.Model.Player.Interface.IPlayerModel;
            var finishLevelCondition = condition as IIdCondition;
            var levelId = finishLevelCondition.GetId();
            UnityEngine.Debug.Log("Set time ti play for level: " + levelId);
            serverPlayerModel.GetLevels().SetLevelLastTime(levelId, 0);
        }
	}
}