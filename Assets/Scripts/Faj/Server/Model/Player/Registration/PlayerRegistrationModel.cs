using Faj.Common.Model.Player.Structure;
using Uddle.Service;
using Uddle.Static.Service.Interface;
using Faj.Client.Model.Static.PlayerInitialize.Collection.Item.Interface;
using Faj.Client.Model.Static.PlayerInitialize.Collection.Interface;
using Faj.Server.Model.Player.Interface;

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
            var initialResources = playerInitializeCollection.GetItem("1").GetResources();
            playerModel.GetResources().AwardResources(initialResources);
        }
	}
}