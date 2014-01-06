using Uddle.Strategy.Interface;
using Uddle.Service;
using Faj.Server.Model.Player.Service.Interface;
using Faj.Server.Model.Player.Service;

namespace Faj.Client.Model.Game.Strategy.Server
{
    class BaseServerInitializeStrategy : IStrategy
    {
        public void DoStrategy()
        {
            var serverPlayersService = new ServerPlayersService();
            ServiceProvider.Instance.SetService<IServerPlayersService>(serverPlayersService);
        }
    }
}
