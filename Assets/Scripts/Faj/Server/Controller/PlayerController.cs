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
            actions.Add("save", Save);

            actions.Add("cheat", Cheat);

            actions.Add("upgrade", Upgrade);

            actions.Add("perk", Perk);

        }

        void Upgrade(IContent content)
        {
            var stringContent = content as IStringContent;
            var playerId = stringContent.GetId();
            var upgrade = stringContent.GetContent();

            var playerModel = GetServerPlayersService().GetPlayerInstance(playerId) as Faj.Server.Model.Player.Interface.IPlayerModel;
            playerModel.GetUpgrades().Upgrade(upgrade);

            Save(content);
        }

        void Perk(IContent content)
        {
            var stringContent = content as IStringContent;
            var playerId = stringContent.GetId();
            var upgrade = stringContent.GetContent();

            var playerModel = GetServerPlayersService().GetPlayerInstance(playerId) as Faj.Server.Model.Player.Interface.IPlayerModel;
            playerModel.GetPerks().Buy(upgrade);

            Save(content);
        }

        void Cheat(IContent content)
        {
            var idContent = content as IIdContent;
            var playerId = idContent.GetId();

            var playerModel = GetServerPlayersService().GetPlayerInstance(playerId) as Faj.Server.Model.Player.Interface.IPlayerModel;

            var resource = new System.Collections.Generic.Dictionary<string, int>();
            resource.Add("money", 1);
            resource.Add("skull", 1);
            resource.Add("energy", 4);

            playerModel.GetResources().AwardResources(resource);

            UnityEngine.Debug.Log("Perks");
            foreach (var kvp in playerModel.GetPlayerStructure().perks)
            {
                UnityEngine.Debug.Log("perk name: " + kvp);
            }

            var staticContainerService = ServiceProvider.Instance.GetService<Uddle.Static.Service.Interface.IStaticContainerService>();
            var coll = staticContainerService.GetStaticCollection<Faj.Common.Static.Level.Play.Collection.Interface.ILevelPlayCollection>("levels_play_contract");

            var staticPerk = coll.GetItem("level_4");

            var contract = new Faj.Server.Dynamic.Contract.LevelOpenContract(staticPerk, playerModel);
            UnityEngine.Debug.Log("Q result:" + contract.Start());
            UnityEngine.Debug.Log("Q error:" + contract.GetError());

            //foreach (var kvp in coll.GetItems())
            //{
            //    UnityEngine.Debug.Log("a: " + kvp.Key);
            //    UnityEngine.Debug.Log("b: " + kvp.Value);
            //}

            //var staticContainerService = ServiceProvider.Instance.GetService<Uddle.Static.Service.Interface.IStaticContainerService>();
            //var coll = staticContainerService.GetStaticCollection<Faj.Common.Static.Perk.Buy.Collection.Interface.IPerkBuyCollection>("perks_buy_contract");

            //foreach (var kvp in coll.GetItems())
            //{
            //    UnityEngine.Debug.Log("a: " + kvp.Key);
            //    UnityEngine.Debug.Log("b: " + kvp.Value);
            //}

            //var staticPerk = coll.GetItem("megahit");

            //var contract = new Faj.Server.Dynamic.Contract.PerkBuyContract(staticPerk, playerModel);
            //contract.Start();

            UnityEngine.Debug.Log("Perks");
            foreach (var kvp in playerModel.GetPlayerStructure().perks)
            {
                UnityEngine.Debug.Log("perk name: " + kvp);
            }
            //playerModel.GetUpgrades().Upgrade("power");
            
        }

        void Save(IContent content)
        {
            var idContent = content as IIdContent;
            var playerId = idContent.GetId();

            var playerModel = GetServerPlayersService().GetPlayerInstance(playerId);
            playerModel.Save();

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
