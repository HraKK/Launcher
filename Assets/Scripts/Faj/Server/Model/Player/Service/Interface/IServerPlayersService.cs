using Uddle.Service.Interface;
using Faj.Common.Model.Player.Interface;

namespace Faj.Server.Model.Player.Service.Interface
{
	interface IServerPlayersService : IService
	{
        IPlayerModel GetPlayerInstance(string playerId);
	}
}
