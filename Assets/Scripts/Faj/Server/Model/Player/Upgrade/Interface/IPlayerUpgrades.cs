using System.Collections.Generic;

namespace Faj.Server.Model.Player.Upgrade.Interface
{
	interface IPlayerUpgrades
    {
        bool IsUpgradeEnough(string type, int level);
        void SetUpgrade(string type, int level);
        Dictionary<string, int> GetUpgrades();
        bool Upgrade(string type);
    }
}
