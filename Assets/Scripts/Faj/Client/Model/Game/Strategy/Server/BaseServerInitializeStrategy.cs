using Uddle.Strategy.Interface;
using Uddle.Service;
using Faj.Server.Model.Player.Service.Interface;
using Faj.Server.Model.Player.Service;
using Uddle.Dynamic.Contract.Module;
using Uddle.Dynamic.Contract.Module.Interface;
using Faj.Server.Dynamic.Contract.Module;

namespace Faj.Client.Model.Game.Strategy.Server
{
    class BaseServerInitializeStrategy : IStrategy
    {
        IServerPlayersService serverPlayersService;

        public void DoStrategy()
        {
            serverPlayersService = new ServerPlayersService();
            
            ServiceProvider.Instance.SetService<IServerPlayersService>(serverPlayersService);

            InitializeContracts();
            
        }

        protected void InitializeContracts()
        {            
            var moduleFactory = new ModuleFactory();

            moduleFactory.AddModule("finishedlevel", new FinishedLevelModule());
            moduleFactory.AddModule("finishedquests", new FinishedQuestModule());
            moduleFactory.AddModule("resource", new ResourceModule());
            moduleFactory.AddModule("upgrades", new UpgradeModule());
            ServiceProvider.Instance.SetService<IModuleFactory>(moduleFactory);
        }
    }
}
