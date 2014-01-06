using Faj.Client.Model.Player.Service.Interface;
using Faj.Client.Model.Player.Interface;

namespace Faj.Client.Model.Player.Service
{
	class PlayerService : IPlayerService
	{
        readonly IPlayerModel playerModel;

        public PlayerService(IPlayerModel playerModel)
        {
            this.playerModel = playerModel;
        }

        public IPlayerModel GetPlayerModel()
        {
            return playerModel;
        }
	}
}
