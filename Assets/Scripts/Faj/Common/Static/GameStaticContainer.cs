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
            AddCollection("quests", new QuestParser());
        }        
	}
}