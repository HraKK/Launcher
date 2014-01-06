using Faj.Client.Model.Player.Dao.Interface;
using Uddle.Config.Interface;
using Faj.Client.Model.Player.Dao.Web;
using Faj.Client.Model.Player.Dao.IoS;
using Faj.Client.Dao.Interface;
using Faj.Server.Model.Player.Dao.Interface;
using Faj.Server.Model.Player.Dao;

namespace Faj.Client.Dao
{
	class DaoFactory : IDaoFactory
	{
        IPlayerDao playerDao;
        IServerPlayerDao serverPlayerDao;
        ApplicationPlatform platform;

        public DaoFactory(ApplicationPlatform platform)
        {
            this.platform = ApplicationPlatform.IOS; // platform;
        }

        public IPlayerDao GetPlayerDao()
        {
            if (playerDao != null)
            {
                return playerDao;
            }

            switch(platform)
            {
                case ApplicationPlatform.WEB :
                    playerDao = new WebPlayerDao();
                    break;

                default :
                    playerDao = new IoSPlayerDao();
                    break;
            }

            return playerDao;
        }

        public IServerPlayerDao GetServerPlayerDao()
        {
            if (serverPlayerDao != null)
            {
                return serverPlayerDao;
            }

            switch (platform)
            {
                default:
                    serverPlayerDao = new FilePlayerDao();
                    break;
            }

            return serverPlayerDao;
        }
	}
}
