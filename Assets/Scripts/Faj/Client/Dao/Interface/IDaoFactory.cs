using Uddle.Service.Interface;
using Faj.Client.Model.Player.Dao.Interface;
using Faj.Server.Model.Player.Dao.Interface;

namespace Faj.Client.Dao.Interface
{
	interface IDaoFactory : IService
	{
        IPlayerDao GetPlayerDao();
        IServerPlayerDao GetServerPlayerDao();
	}
}
