using Faj.Server.Model.Player.Level.Interface;
using Faj.Server.Model.Player.Quest.Interface;
using Faj.Server.Model.Player.Resource.Interface;

namespace Faj.Server.Model.Player.Interface
{
    interface IPlayerModel : Faj.Common.Model.Player.Interface.IPlayerModel
	{
        IPlayerLevels GetLevels();
        IPlayerQuests GetQuests();
        IPlayerResources GetResources();
	}
}
