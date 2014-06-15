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
            UnityEngine.Debug.Log("<color=red>CONTRACT</color>");
            var questContract = contract as IQuestItem;
            var serverPlayerModel = playerModel as Faj.Server.Model.Player.Interface.IPlayerModel;
            var finishQuestCondition = condition as IIdCondition;
            if (null == finishQuestCondition)
            {
                return true;
            }
            var questId = finishQuestCondition.GetId();
            UnityEngine.Debug.Log("<color=red>"+questId+"</color>");
            if (serverPlayerModel.GetQuests() == null)
            {
                return false;
            }
            var isFinishedQuest = serverPlayerModel.GetQuests().IsFinishedQuest(questId);
            UnityEngine.Debug.Log("<color=red>" + isFinishedQuest + "</color>");

            return isFinishedQuest;
        }

        public void Pay(IStaticContract contract, IPlayerModel playerModel, ICondition condition)
        {

        }

        public void Award(IStaticContract contract, IPlayerModel playerModel, ICondition condition)
        {
        }
	}
}
