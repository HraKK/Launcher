using Faj.Common.Model.Player.Structure;
using Uddle.Service;
using Uddle.Static.Service.Interface;
using Faj.Common.Model.Static.PlayerInitialize.Collection.Item.Interface;
using Faj.Common.Model.Static.PlayerInitialize.Collection.Interface;
using Faj.Common.Model.Player.Interface;

namespace Faj.Server.Model.Player.Registration
{
	class PlayerRegistrationModel
	{
        readonly IPlayerInitializeCollection playerInitializeCollection;
        readonly IPlayerModel playerModel;

        public PlayerRegistrationModel(IPlayerModel playerModel)
        {
            this.playerModel = playerModel;
            var staticContainerService = ServiceProvider.Instance.GetService<IStaticContainerService>();
            playerInitializeCollection = staticContainerService.GetStaticCollection<IPlayerInitializeCollection>("player_initialize");
        }

        public void Initialize()
        {
            var initializeItem = playerInitializeCollection.GetItem("1");
            var initialResources = initializeItem.GetResources();
            var startLevel = initializeItem.GetStartLevel();
            
            playerModel.GetResources().AwardResources(initialResources);
            playerModel.GetLevels().SetLevelLastTime(startLevel, 0);
        }
	}
}