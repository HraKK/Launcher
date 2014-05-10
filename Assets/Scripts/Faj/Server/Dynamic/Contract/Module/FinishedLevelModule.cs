using Uddle.Dynamic.Contract.Module.Interface;
using Uddle.Model.Player.Interface;
using Uddle.Static.Contract.Module.Condition.Interface;
using Faj.Common.Static.Contract.Condition.Interface;

namespace Faj.Server.Dynamic.Contract.Module
{
	class FinishedLevelModule : IContractModule
	{
        public bool Check(IPlayerModel playerModel, ICondition condition)
        {
            var serverPlayerModel = playerModel as Faj.Server.Model.Player.Interface.IPlayerModel;
            var finishLevelCondition = condition as IIdCondition;
            var levelId = finishLevelCondition.GetId();

            return serverPlayerModel.GetLevels().IsLevelOpen(levelId);
        }

        public void Pay(IPlayerModel playerModel, ICondition condition)
        {

        }

        public void Award(IPlayerModel playerModel, ICondition condition)
        {
            var serverPlayerModel = playerModel as Faj.Server.Model.Player.Interface.IPlayerModel;
            var finishLevelCondition = condition as IIdCondition;
            var levelId = finishLevelCondition.GetId();

            serverPlayerModel.GetLevels().SetLevelLastTime(levelId, 0);
        }
	}
}