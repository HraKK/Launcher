using Faj.Client.Model.Player.Interface;
using Faj.Client.Model.Player.Dao.Interface;
using Uddle.Service;
using Faj.Client.Dao.Interface;
using Faj.Common.Model.Player.Structure;
using Uddle.Dependency.Interface;
using System;
using Faj.Common.Model.Player.Resource;
using Faj.Common.Model.Player.Resource.Interface;
using Faj.Common.Model.Player.Level.Interface;
using Faj.Common.Model.Player.Level;

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
        readonly IPlayerLevels playerLevels;

        public PlayerModel(string playerId)
        {
            this.playerId = playerId;
            var daoFactory = ServiceProvider.Instance.GetService<IDaoFactory>();
            playerDao = daoFactory.GetPlayerDao();
            playerResources = new PlayerResources(this);
            playerLevels = new PlayerLevels(this);
        }

        public IPlayerLevels GetLevels()
        {
            return playerLevels;
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
