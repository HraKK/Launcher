using Faj.Server.Model.Player.Level.Interface;
using Faj.Server.Model.Player.Quest.Interface;
using Faj.Server.Model.Player.Resource.Interface;
using Faj.Server.Model.Player.Upgrade.Interface;

namespace Faj.Server.Model.Player.Interface
{
    interface IPlayerModel : Faj.Common.Model.Player.Interface.IPlayerModel
	{
        IPlayerUpgrades GetUpgrades();
        IPlayerLevels GetLevels();
        IPlayerQuests GetQuests();
        IPlayerResources GetResources();
	}
}
