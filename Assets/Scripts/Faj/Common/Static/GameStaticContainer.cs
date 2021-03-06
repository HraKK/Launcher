﻿using Uddle.Static;
using Faj.Common.Model.Static.Parser;
using Faj.Common.Static.Parser;

namespace Faj.Common.Model.Static
{
	class GameStaticContainer : StaticContainer
	{
        protected override void InitializeCollections()
        {
            AddCollection("configuration", new ConfigurationParser());
            AddCollection("player_initialize", new PlayerInitializeParser());
            AddCollection("levels", new LevelParser());
            AddCollection("levels_monsters", new LevelMonsterParser());
            AddCollection("levels_play_contract", new LevelPlayParser());
            AddCollection("levels_open_contract", new LevelOpenParser());
            AddCollection("upgrades", new UpgradeParser());
            AddCollection("upgrades_type", new UpgradeTypeParser());
            AddCollection("upgrades_buy_contract", new UpgradeBuyParser());
            AddCollection("perks_buy_contract", new PerkBuyParser());
            AddCollection("perks", new PerkParser());
            AddCollection("quests", new QuestParser());
            AddCollection("achievements", new AchievementParser());
            AddCollection("monsters", new MonsterParser());
        }        
	}
}