using Faj.Server.Model.Player.Upgrade.Interface;
using Faj.Server.Model.Player.Interface;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using Faj.Common.Static.Upgrade.Buy.Collection.Interface;
using Uddle.Service;
using Uddle.Static.Service.Interface;
using Faj.Server.Dynamic.Contract;

namespace Faj.Server.Model.Player.Upgrade
{
    class PlayerUpgrades : IPlayerUpgrades
    {
        readonly IPlayerModel playerModel;
        readonly IUpgradeBuyCollection upgradesBuyStaticCollection;

        public PlayerUpgrades(IPlayerModel playerModel)
        {
            this.playerModel = playerModel;
            var staticContainerService = ServiceProvider.Instance.GetService<IStaticContainerService>();
            upgradesBuyStaticCollection = staticContainerService.GetStaticCollection<IUpgradeBuyCollection>("upgrades_buy_contract");
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public Dictionary<string, int> GetUpgrades()
        {
            return playerModel.GetPlayerStructure().upgrades;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public bool IsUpgradeEnough(string type, int level)
        {
            var currentLevel = GetCurrentUpgradeLevel(type);

            return currentLevel >= level;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public void SetUpgrade(string type, int level)
        {
            if (false == playerModel.GetPlayerStructure().upgrades.ContainsKey(type))
            {
                playerModel.GetPlayerStructure().upgrades.Add(type, level);
                return;
            }

            playerModel.GetPlayerStructure().upgrades[type] = level;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public bool Upgrade(string type)
        {
            var currentLevel = GetCurrentUpgradeLevel(type);
            var nextLevel = currentLevel + 1;
            var upgradeContract = upgradesBuyStaticCollection.GetUpgradeBuyItem(type, nextLevel);
            
            if (null == upgradeContract)
            {
                return false;
            }
            
            var contract = new UpgradeBuyContract(upgradeContract, playerModel);
            return contract.Start();
        }

        protected int GetCurrentUpgradeLevel(string type)
        {
            int level;

            if (false == playerModel.GetPlayerStructure().upgrades.TryGetValue(type, out level))
            {
                return 0;
            }

            return level;
        }
    }
}