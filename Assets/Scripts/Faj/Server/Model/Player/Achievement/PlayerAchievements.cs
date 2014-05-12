using Faj.Server.Model.Player.Achievement.Interface;
using Faj.Server.Model.Player.Interface;
using Faj.Common.Static.Achievement.Collection.Interface;
using System.Collections.Generic;
using Faj.Server.Dynamic.Contract.Interface;
using Uddle.Service;
using Uddle.Static.Service.Interface;
using Faj.Common.Model.Player.Structure;
using Faj.Server.Dynamic.Contract;

namespace Faj.Server.Model.Player.Achievement
{
	class PlayerAchievements : IPlayerAchievements
	{        
        readonly IPlayerModel playerModel;
        readonly IAchievementCollection achievementsStaticCollection;

        Dictionary<string, IAchievementContract> achievements = new Dictionary<string, IAchievementContract>();

        public PlayerAchievements(IPlayerModel playerModel)
        {
            this.playerModel = playerModel;
            var staticContainerService = ServiceProvider.Instance.GetService<IStaticContainerService>();
            achievementsStaticCollection = staticContainerService.GetStaticCollection<IAchievementCollection>("achievements");
        }

        public void Notify(string action, string target, int value)
        {
            var achievementsStatic = achievementsStaticCollection.GetItemsByActionAndTarget(action, target);

            foreach (var achievementStatic in achievementsStatic)
            {
                var achievementId = achievementStatic.GetId();
                var achievement = GetQuestByTemplateId(achievementId);

                if (achievement.IsLocked() == true)
                {
                    continue;
                }

                if (achievement.GetStatus() == Status.FINISHED)
                {
                    continue;
                }

                if (achievement.GetStatus() == Status.CREATED)
                {
                    if (false == achievement.Start())
                    {
                        continue;
                    }
                }

                achievement.Increment(value);
            }
        }

        protected IQuestContract GetQuestByTemplateId(string achievementId)
        {
            IAchievementContract achievement;
            if (false == achievements.TryGetValue(achievementId, out achievement))
            {
                var achievementStatic = achievementsStaticCollection.GetItem(achievementId);
                achievement = new AchievementContract(achievementStatic, playerModel);

                achievements.Add(achievementId, achievement);
            }

            return achievement;
        }
	}
}
