using System.Collections.Generic;

namespace Faj.Client.Model.Player.Upgrade.Interface
{
	interface IPlayerUpgrades
    {
        Dictionary<string, int> GetUpgrades();
    }
}
