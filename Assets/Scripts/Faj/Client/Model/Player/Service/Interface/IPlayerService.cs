using Uddle.Service.Interface;
using Faj.Client.Model.Player.Interface;

namespace Faj.Client.Model.Player.Service.Interface
{
	interface IPlayerService : IService
	{
        IPlayerModel GetPlayerModel();
	}
}
