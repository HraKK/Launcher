using Faj.Common.Model.Player.Structure;

namespace Faj.Common.Model.Player.Interface
{
    interface IPlayerModel : Uddle.Model.Player.Interface.IPlayerModel
	{
        PlayerStructure GetPlayerStructure();
	}
}
