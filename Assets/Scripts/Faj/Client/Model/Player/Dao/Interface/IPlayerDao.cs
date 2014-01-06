using Faj.Common.Model.Player.Structure;

namespace Faj.Client.Model.Player.Dao.Interface
{
	interface IPlayerDao
	{
        void Load(string playerId);
        void Save(string playerId, PlayerStructure playerStructure);
	}
}
