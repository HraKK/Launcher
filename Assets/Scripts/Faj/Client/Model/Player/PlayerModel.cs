using Faj.Client.Model.Player.Interface;
using Faj.Client.Model.Player.Dao.Interface;
using Uddle.Service;
using Faj.Client.Dao.Interface;
using Faj.Common.Model.Player.Structure;
using Uddle.Dependency.Interface;
using System;
using Faj.Common.Model.Player.Resource;
using Faj.Common.Model.Player.Resource.Interface;

namespace Faj.Client.Model.Player
{
	class PlayerModel : IPlayerModel, IDependency
	{
        public event Action<IDependency> OnReleaseEvent;

        readonly IPlayerDao playerDao;
        readonly string playerId;

        PlayerStructure playerStructure;
        readonly IPlayerResources playerResources;

        public PlayerModel(string playerId)
        {
            this.playerId = playerId;
            var daoFactory = ServiceProvider.Instance.GetService<IDaoFactory>();
            playerDao = daoFactory.GetPlayerDao();
            playerResources = new PlayerResources(playerStructure);
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

        public void Initialize(PlayerStructure playerStructure)
        {
            this.playerStructure = playerStructure;

            if (OnReleaseEvent != null)
            {
                OnReleaseEvent(this);
            }
        }
	}
}
