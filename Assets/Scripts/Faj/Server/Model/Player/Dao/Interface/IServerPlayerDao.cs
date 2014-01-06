using Faj.Common.Model.Player.Structure;

namespace Faj.Server.Model.Player.Dao.Interface
{
	interface IServerPlayerDao
	{
        PlayerStructure Load(string playerId);
        void Save(string playerId, PlayerStructure playerStructure);
	}
}
