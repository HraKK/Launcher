using Faj.Client.Model.Player.Dao.Interface;
using Faj.Common.Model.Player.Structure;
using Uddle.Service;
using Faj.Server.Router.Service.Interface;
using Uddle.Message;
using Faj.Common.Message.Content;


namespace Faj.Client.Model.Player.Dao.IoS
{
	class IoSPlayerDao : IPlayerDao
	{
        readonly IServerRouterService routerService;

        public IoSPlayerDao()
        {
            routerService = ServiceProvider.Instance.GetService<IServerRouterService>();
        }

        public void Load(string playerId)
        {
            var idContent = new IdContent(playerId);
            var message = new SimpleMessage("initialize", "load", idContent);
            routerService.Route(message);
        }

        public void Save(string playerId, PlayerStructure playerStructure)
        {
            var idContent = new IdContent(playerId);
            var message = new SimpleMessage("player", "save", idContent);
            routerService.Route(message);            
        }
	}
}
