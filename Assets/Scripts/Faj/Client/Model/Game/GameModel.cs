using Uddle.Static;
using Faj.Client.Model.Preloader;
using Faj.Client.Model.Static;
using Uddle.Static.Service;
using Uddle.Service;
using Uddle.Static.Service.Interface;
using Faj.Client.Model.Player;
using Faj.Client.Model.Player.Interface;
using Uddle.Bootstrap.Interface;
using Uddle.Model.Game;
using Uddle.Dependency.Interface;
using System;
using Faj.Client.Model.Game.Strategy.Server;
using Faj.Client.Model.Player.Service;
using Faj.Client.Model.Player.Service.Interface;

namespace Faj.Client.Model.Game
{
	class GameModel : AbstractGameModel
	{
        IPlayerModel playerModel;

        public GameModel(ICoreBootstraper coreBootstraper)
            : base(coreBootstraper)
        {
        }

        protected override void InitializePackageHandlers()
        {
            Action onStaticDownload = OnStaticDownload;
            GetDownloaderModel().AddPackageHandler(StaticContainer.STATIC_PACKAGE, onStaticDownload);
        }

        protected override void InitializePreloaderModel()
        {
            preloaderModel = new PreloaderModel();
        }

        protected override void InitializeServer()
        {
            var applicationPlatform = coreBootstraper.GetApplicationConfig().GetPlatform();
            var serverInitializeStrategyFactory = new ServerInitializeStrategyFactory(applicationPlatform);
            var serverInitializeStrategy = serverInitializeStrategyFactory.GetConcreteStrategy();
            serverInitializeStrategy.DoStrategy();
        }

        protected override void InitializePlayerModel(string playerId)
        {            
            playerModel = new PlayerModel(playerId);
            var playerService = new PlayerService(playerModel);
            ServiceProvider.Instance.SetService<IPlayerService>(playerService);

            var dependencyAwaiter = preloaderModel as IDependencyAwaiter;
            dependencyAwaiter.AddDependency(playerModel as IDependency);            
        }
        
        public override void Initialize(string playerId)
        {
            base.Initialize(playerId);
            preloaderModel.Initialize();
        }

        void OnStaticDownload()
        {
            var staticContainer = new GameStaticContainer();
            staticContainer.Initialize();

            var staticContainerService = new StaticContainerService(staticContainer);
            ServiceProvider.Instance.SetService<IStaticContainerService>(staticContainerService);
            playerModel.Load();
        }    

        public override void Run()
        {
            
        }
	}
}
