using Faj.Common.Model.Player.Structure;
using Faj.Common.Model.Player.Resource.Interface;
using Faj.Common.Model.Player.Level.Interface;

namespace Faj.Common.Model.Player.Interface
{
	interface IPlayerModel
	{
        void Load();
        void Save();
        IPlayerResources GetResources();
        IPlayerLevels GetLevels();
        PlayerStructure GetPlayerStructure();
	}
}
