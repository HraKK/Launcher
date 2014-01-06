using Uddle.Controller;
using Uddle.Message.Content.Interface;
using Faj.Common.Message.Content.Interface;
using Faj.Server.Model.Player;
using Uddle.Service.Interface;
using Uddle.Service;
using Faj.Server.Model.Player.Service.Interface;
using Faj.Common.Message.Content;
using Uddle.Message;
using Faj.Client.Router.Service.Interface;

namespace Faj.Server.Controller
{
	class InitializeController : AbstractController
	{
        IServerPlayersService serverPlayersService;

        readonly IClientRouterService routerService;

        public InitializeController()
            : base()
        {
            routerService = ServiceProvider.Instance.GetService<IClientRouterService>();
        }

        protected override void InitializeActions()
        {
            ActionDelegate load = Load;
            actions.Add("load", load);
            
        }

        void Load(IContent content)
        {
            var idContent = content as IIdContent;
            var playerId = idContent.GetId();

            var playerModel = GetServerPlayersService().GetPlayerInstance(playerId);
            var playerStructure = playerModel.GetPlayerStructure();

            var playerContent = new PlayerContent(playerStructure);
            var message = new SimpleMessage("player", "load", playerContent);
            routerService.Route(message);
        }

        public IServerPlayersService GetServerPlayersService()
        {
            if (serverPlayersService == null)
            {
                var serviceProvider = ServiceProvider.Instance;
                serverPlayersService = serviceProvider.GetService<IServerPlayersService>();
            }

            return serverPlayersService;
        }
	}
}
    