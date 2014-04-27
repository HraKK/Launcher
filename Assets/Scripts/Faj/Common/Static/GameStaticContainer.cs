using Uddle.Static;
using Faj.Common.Model.Static.Parser;

namespace Faj.Common.Model.Static
{
	class GameStaticContainer : StaticContainer
	{
        protected override void InitializeCollections()
        {
            addCollection(new PlayerInitializeParser(), "player_initialize");
            addCollection(new LevelParser(), "levels");
        }        
	}
}