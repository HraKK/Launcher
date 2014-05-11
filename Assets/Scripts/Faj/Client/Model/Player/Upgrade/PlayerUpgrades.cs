using Faj.Client.Model.Player.Upgrade.Interface;
using Faj.Client.Model.Player.Interface;
using System.Runtime.CompilerServices;
using System.Collections.Generic;

namespace Faj.Client.Model.Player.Upgrade
{
    class PlayerUpgrades : IPlayerUpgrades
    {
        readonly IPlayerModel playerModel;

        public PlayerUpgrades(IPlayerModel playerModel)
        {
            this.playerModel = playerModel;
        }

        public Dictionary<string, int> GetUpgrades()
        {
            return playerModel.GetPlayerStructure().upgrades;
        }
    }
}