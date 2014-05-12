using Faj.Client.Model.Player.Interface;
using Faj.Client.Model.Player.Dao.Interface;
using Uddle.Service;
using Faj.Client.Dao.Interface;
using Faj.Common.Model.Player.Structure;
using Uddle.Dependency.Interface;
using System;
using Faj.Client.Model.Player.Resource;
using Faj.Client.Model.Player.Resource.Interface;
using Faj.Client.Model.Player.Level.Interface;
using Faj.Client.Model.Player.Level;
using Faj.Client.Model.Player.Upgrade.Interface;
using Faj.Client.Model.Player.Upgrade;
using Faj.Client.Model.Player.Quest.Interface;
using Faj.Client.Model.Player.Quest;
using Faj.Client.Model.Player.Achievement.Interface;
using Faj.Client.Model.Player.Achievement;

namespace Faj.Client.Model.Player
{


	class PlayerModel : IPlayerModel, IDependency
	{
        public event Action<IDependency> OnReleaseEvent;
        public event Action<LocationEnum> OnChangeLocation;

        LocationEnum location;
        readonly IPlayerDao playerDao;
        readonly string playerId;

        PlayerStructure playerStructure;
        readonly IPlayerResources playerResources;
        readonly IPlayerUpgrades playerUpgrades;
        readonly IPlayerLevels playerLevels;
        readonly IPlayerQuests playerQuests;
        readonly IPlayerAchievements playerAchievements;

        public PlayerModel(string playerId)
        {
            this.playerId = playerId;
            var daoFactory = ServiceProvider.Instance.GetService<IDaoFactory>();
            playerDao = daoFactory.GetPlayerDao();
            playerResources = new PlayerResources(this);
            playerLevels = new PlayerLevels(this);
            playerUpgrades = new PlayerUpgrades(this);
            playerQuests = new PlayerQuests(this);
            playerAchievements = new PlayerAchievements(this);
        }

        public IPlayerUpgrades GetUpgrades()
        {
            return playerUpgrades;
        }

        public IPlayerQuests GetQuests()
        {
            return playerQuests;
        }

        public IPlayerAchievements GetAchievements()
        {
            return playerAchievements;
        }

        public IPlayerLevels GetLevels()
        {
            return playerLevels;
        }

        public string GetId()
        {
            return playerId;
        }

        public IPlayerResources GetResources()
        {
            return playerResources;
        }

        public void Load()
        {
            playerDao.Load(playerId);
        }

        public void Save()
        {
            playerDao.Save(playerId, playerStructure);
        }

        public PlayerStructure GetPlayerStructure()
        {
            return playerStructure;
        }

        public void ChangeLocation(LocationEnum location)
        {
            if (this.location == location)
            {
                return;
            }

            this.location = location;

            if (OnChangeLocation != null)
            {
                OnChangeLocation(location);
            }
        }

        public LocationEnum GetLocation()
        {
            return location;
        }

        public void SetStructure(PlayerStructure playerStructure)
        {            
            this.playerStructure = playerStructure;

            if (OnReleaseEvent != null)
            {
                OnReleaseEvent(this);
            }
        }
	}
}
