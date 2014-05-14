using Faj.Common.Model.Player.Structure;
using Faj.Server.Model.Player.Dao.Interface;
using Faj.Server.Model.Player.Dao;
using Uddle.Service;
using Faj.Client.Dao.Interface;
using Faj.Server.Model.Player.Exception;
using Faj.Server.Model.Player.Registration;
using Faj.Server.Model.Player.Resource.Interface;
using Faj.Server.Model.Player.Resource;
using Faj.Server.Model.Player.Interface;
using Faj.Server.Model.Player.Level.Interface;
using Faj.Server.Model.Player.Level;
using Faj.Server.Model.Player.Quest.Interface;
using Faj.Server.Model.Player.Quest;
using Faj.Server.Model.Player.Upgrade.Interface;
using Faj.Server.Model.Player.Upgrade;
using Faj.Server.Model.Player.Achievement.Interface;
using Faj.Server.Model.Player.Achievement;
using Faj.Server.Model.Player.Perk.Interface;
using Faj.Server.Model.Player.Perk;

namespace Faj.Server.Model.Player
{
	class PlayerModel : IPlayerModel
	{
        readonly string playerId;
        readonly IServerPlayerDao playerDao;

        bool isLoaded = false;

        PlayerStructure playerStructure;
        readonly IPlayerResources playerResources;
        readonly IPlayerLevels playerLevels;
        readonly IPlayerUpgrades playerUpgrades;
        readonly IPlayerPerks playerPerks;
        readonly IPlayerQuests playerQuests;
        readonly IPlayerAchievements playerAchievements;

        public PlayerModel(string playerId)
        {
            this.playerId = playerId;

            var daoFactory = ServiceProvider.Instance.GetService<IDaoFactory>();
            playerDao = daoFactory.GetServerPlayerDao();
            playerStructure = new PlayerStructure();
            playerResources = new PlayerResources(this);
            playerLevels = new PlayerLevels(this);
            playerUpgrades = new PlayerUpgrades(this);
            playerPerks = new PlayerPerks(this);
            playerQuests = new PlayerQuests(this);
            playerAchievements = new PlayerAchievements(this);
        }

        public string GetId()
        {
            return playerId;
        }

        public IPlayerPerks GetPerks()
        {
            return playerPerks;
        }

        public IPlayerUpgrades GetUpgrades()
        {
            return playerUpgrades;
        }

        public IPlayerLevels GetLevels()
        {
            return playerLevels;
        }

        public IPlayerQuests GetQuests()
        {
            return playerQuests;
        }

        public IPlayerAchievements GetAchievements()
        {
            return playerAchievements;
        }

        public IPlayerResources GetResources()
        {
            return playerResources;
        }

        public void Load()
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
            playerDao.Save(playerId, GetPlayerStructure());
        }

        public PlayerStructure GetPlayerStructure()
        {
            return playerStructure;
        }
	}
}
