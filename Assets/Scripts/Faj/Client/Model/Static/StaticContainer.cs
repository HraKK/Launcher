using Uddle.Static;
using Faj.Client.Model.Static.Parser;

namespace Faj.Client.Model.Static
{
	class GameStaticContainer : StaticContainer
	{
        protected override void InitializeCollections()
        {
            var playerInitializeDocument = GetStaticDocument("player_initialize");
            var playerInitializeParse = new PlayerInitializeParser();
            var playerInitializeCollection = playerInitializeParse.Parse(playerInitializeDocument);
            staticCollections.Add("player_initialize", playerInitializeCollection);
        }
	}
}
