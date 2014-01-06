using Faj.Server.Model.Player.Interface;
using Faj.Common.Model.Player.Structure;
using Faj.Server.Model.Player.Dao.Interface;
using Faj.Server.Model.Player.Dao;
using Uddle.Service;
using Faj.Client.Dao.Interface;
using Faj.Server.Model.Player.Exception;
using Faj.Server.Model.Player.Registration;
using Faj.Common.Model.Player.Resource.Interface;
using Faj.Common.Model.Player.Resource;

namespace Faj.Server.Model.Player
{
	class PlayerModel : IPlayerModel
	{
        readonly string playerId;
        readonly IServerPlayerDao playerDao;

        bool isLoaded = false;

        PlayerStructure playerStructure;
        readonly IPlayerResources playerResources;

        public PlayerModel(string playerId)
        {
            this.playerId = playerId;

            var daoFactory = ServiceProvider.Instance.GetService<IDaoFactory>();
            playerDao = daoFactory.GetServerPlayerDao();
            playerStructure = new PlayerStructure();
            playerResources = new PlayerResources(playerStructure);
        }

        public IPlayerResources GetResources()
        {
            return playerResources;
        }

        void Load()
        {
            try
            {
                playerStructure = playerDao.Load(playerId);
            }
            catch (NotExistPlayerException)
            {
                var playerRegistrationModel = new PlayerRegistrationModel(this);
                playerRegistrationModel.Initialize();
            }

            isLoaded = true;
        }

        public void Save()
        {
        }

        public PlayerStructure GetPlayerStructure()
        {
            if (!isLoaded)
            {
                Load();
            }

            return playerStructure;
        }
	}
}
