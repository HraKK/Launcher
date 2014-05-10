using Faj.Server.Model.Player.Quest.Interface;
using Faj.Common.Model.Player.Interface;
using Faj.Common.Static.Quest.Collection.Interface;
using Uddle.Service;
using Uddle.Static.Service.Interface;
using Faj.Common.Model.Player.Structure;
using Faj.Common.Static.Quest.Collection.Item.Interface;
using Faj.Server.Dynamic.Contract;

namespace Faj.Server.Model.Player.Quest
{
	class PlayerQuests : IPlayerQuests
	{        
        readonly IPlayerModel playerModel;
        readonly IQuestCollection questsStaticCollection;

        public PlayerQuests(IPlayerModel playerModel)
        {
            this.playerModel = playerModel;
            var staticContainerService = ServiceProvider.Instance.GetService<IStaticContainerService>();
            questsStaticCollection = staticContainerService.GetStaticCollection<IQuestCollection>("quests");
        }

        public void Notify(string action, string target, int value)
        {
            var questsStatic = questsStaticCollection.GetItemsByActionAndTarget(action, target);

            foreach (var questStatic in questsStatic)
            {
                var questId = questStatic.GetId();
                var quest = GetQuestByTemplateId(questId);
                
                if (quest.GetStatus() == Status.FINISHED)
                {
                    continue;
                }

                if (quest.GetStatus() == Status.CREATED)
                {
                    if (false == quest.Start())
                    {
                        continue;
                    }
                }

                quest.Increment(value);
            }
        }

        protected QuestContract GetQuestByTemplateId(string questId)
        {
            var questStatic = questsStaticCollection.GetItem(questId);
            var questContract = new QuestContract(questStatic, playerModel);

            return questContract;
        }
	}
}