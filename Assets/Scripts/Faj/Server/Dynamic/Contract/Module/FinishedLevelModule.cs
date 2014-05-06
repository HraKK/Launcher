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
            var commonPlayerModel = playerModel as Faj.Common.Model.Player.Interface.IPlayerModel;
            var finishLevelCondition = condition as IIdCondition;
            var levelId = finishLevelCondition.GetId();

            return commonPlayerModel.GetLevels().IsLevelOpen(levelId);
        }

        public void Pay(IPlayerModel playerModel, ICondition condition)
        {

        }

        public void Award(IPlayerModel playerModel, ICondition condition)
        {
            var commonPlayerModel = playerModel as Faj.Common.Model.Player.Interface.IPlayerModel;
            var finishLevelCondition = condition as IIdCondition;
            var levelId = finishLevelCondition.GetId();

            commonPlayerModel.GetLevels().SetLevelLastTime(levelId, 0);
        }
	}
}