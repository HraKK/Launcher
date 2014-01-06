using Faj.Server.Model.Player.Service.Interface;
using System.Collections.Generic;
using Faj.Server.Model.Player.Interface;

namespace Faj.Server.Model.Player.Service
{
    class ServerPlayersService : IServerPlayersService
	{
        Dictionary<string, IPlayerModel> playerModels = new Dictionary<string, IPlayerModel>();

        public IPlayerModel GetPlayerInstance(string playerId)
        {
            IPlayerModel playerModel;

            if (!playerModels.TryGetValue(playerId, out playerModel))
            {
                playerModel = new PlayerModel(playerId);
                playerModels.Add(playerId, playerModel);
            }

            return playerModel;
        }
	}
}
