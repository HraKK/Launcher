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
    class PlayerController : AbstractController
    {
        IServerPlayersService serverPlayersService;

        readonly IClientRouterService routerService;

        public PlayerController()
            : base()
        {
            routerService = ServiceProvider.Instance.GetService<IClientRouterService>();
        }

        protected override void InitializeActions()
        {
            ActionDelegate save = Save;
            actions.Add("save", Save);

            ActionDelegate cheat = Cheat;
            actions.Add("cheat", Cheat);

        }

        void Cheat(IContent content)
        {
            var idContent = content as IIdContent;
            var playerId = idContent.GetId();

            var playerModel = GetServerPlayersService().GetPlayerInstance(playerId) as Faj.Server.Model.Player.Interface.IPlayerModel;

            var resource = new System.Collections.Generic.Dictionary<string, int>();
            resource.Add("money", 1);
            resource.Add("skull", 1);

            playerModel.GetResources().AwardResources(resource);

            UnityEngine.Debug.Log("Achievements");
            foreach (var kvp in playerModel.GetPlayerStructure().achievements)
            {
                UnityEngine.Debug.Log("Achiev name: " + kvp.Key);
                UnityEngine.Debug.Log("Achiev value: " + kvp.Value.value);
                UnityEngine.Debug.Log("Achiev status: " + kvp.Value.status);
            }
            //playerModel.GetUpgrades().Upgrade("power");
            
        }

        void Save(IContent content)
        {
            var idContent = content as IIdContent;
            var playerId = idContent.GetId();

            var playerModel = GetServerPlayersService().GetPlayerInstance(playerId);
            playerModel.Save();
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
