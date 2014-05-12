using Uddle.Static;
using Faj.Common.Model.Static.Parser;
using Faj.Common.Static.Parser;

namespace Faj.Common.Model.Static
{
	class GameStaticContainer : StaticContainer
	{
        protected override void InitializeCollections()
        {
            AddCollection("player_initialize", new PlayerInitializeParser());
            AddCollection("levels", new LevelParser());
            AddCollection("levels_open_contract", new LevelOpenParser());
            AddCollection("upgrades", new UpgradeParser());
            AddCollection("upgrades_buy_contract", new UpgradeBuyParser());
            AddCollection("quests", new QuestParser());
            AddCollection("achievements", new AchievementParser());
        }        
	}
}