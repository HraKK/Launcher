using Faj.Server.Model.Player.Quest.Interface;
using Faj.Common.Model.Player.Interface;
using Faj.Common.Static.Quest.Collection.Interface;
using Uddle.Service;
using Uddle.Static.Service.Interface;
using Faj.Common.Model.Player.Structure;
using Faj.Common.Static.Quest.Collection.Item.Interface;
using Faj.Server.Dynamic.Contract;
using Uddle.Dynamic.Contract.Interface;
using System.Collections.Generic;
using Faj.Server.Dynamic.Contract.Interface;

namespace Faj.Server.Model.Player.Quest
{
	class PlayerQuests : IPlayerQuests
	{        
        readonly IPlayerModel playerModel;
        readonly IQuestCollection questsStaticCollection;

        Dictionary<string, IQuestContract> quests = new Dictionary<string, IQuestContract>();

        public PlayerQuests(IPlayerModel playerModel)
        {
            this.playerModel = playerModel;
            var staticContainerService = ServiceProvider.Instance.GetService<IStaticContainerService>();
            questsStaticCollection = staticContainerService.GetStaticCollection<IQuestCollection>("quests");
        }

        public int GetFinishedQuestCountByLevel(string level)
        {
            var questsStatic = questsStaticCollection.GetItemsByLevel(level);

            int finishedQuest = 0;

            foreach (var questStatic in questsStatic)
            {
                var questId = questStatic.GetId();
                var quest = GetQuestByTemplateId(questId);

                if (quest.GetStatus() != Status.FINISHED)
                {
                    continue;
                }

                finishedQuest++;
            }

            return finishedQuest;
        }

        public void Notify(string action, string target, int value)
        {
            var questsStatic = questsStaticCollection.GetItemsByActionAndTarget(action, target);

            foreach (var questStatic in questsStatic)
            {
                var questId = questStatic.GetId();
                var quest = GetQuestByTemplateId(questId);

                if (quest.IsLocked() == true)
                {
                    continue;
                }

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

        protected IQuestContract GetQuestByTemplateId(string questId)
        {
            IQuestContract quest;
            if (false == quests.TryGetValue(questId, out quest))
            {
                var questStatic = questsStaticCollection.GetItem(questId);
                quest = new QuestContract(questStatic, playerModel);

                quests.Add(questId, quest);
            }

            return quest;
        }
	}
}