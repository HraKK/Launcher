using Uddle.Dynamic.Contract.Module.Interface;
using Uddle.Model.Player.Interface;
using Uddle.Static.Contract.Module.Condition.Interface;
using Faj.Common.Static.Contract.Condition.Interface;
using Uddle.Static.Contract.Interface;
using Faj.Common.Static.Quest.Collection.Item.Interface;

namespace Faj.Server.Dynamic.Contract.Module
{
	class FinishedQuestModule : IContractModule
	{
        public bool Check(IStaticContract contract, IPlayerModel playerModel, ICondition condition)
        {
            var questContract = contract as IQuestItem;
            var serverPlayerModel = playerModel as Faj.Server.Model.Player.Interface.IPlayerModel;
            var finishQuestCondition = condition as ICountCondition;
            var questCount = finishQuestCondition.GetCount();
            var finishedQuests = serverPlayerModel.GetQuests().GetFinishedQuestCountByLevel(questContract.GetLevel());

            return finishedQuests >= questCount;
        }

        public void Pay(IStaticContract contract, IPlayerModel playerModel, ICondition condition)
        {

        }

        public void Award(IStaticContract contract, IPlayerModel playerModel, ICondition condition)
        {
            var serverPlayerModel = playerModel as Faj.Server.Model.Player.Interface.IPlayerModel;
            var finishLevelCondition = condition as IIdCondition;
            var levelId = finishLevelCondition.GetId();

            serverPlayerModel.GetLevels().SetLevelLastTime(levelId, 0);
        }
	}
}
