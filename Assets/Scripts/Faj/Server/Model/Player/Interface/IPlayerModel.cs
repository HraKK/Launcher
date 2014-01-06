using Faj.Common.Model.Player.Structure;
using Faj.Common.Model.Player.Resource.Interface;

namespace Faj.Server.Model.Player.Interface
{
	interface IPlayerModel
	{
        IPlayerResources GetResources();
        PlayerStructure GetPlayerStructure();
	}
}
