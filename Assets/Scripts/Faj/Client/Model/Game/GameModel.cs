using Uddle.Static;
using Faj.Client.Model.Preloader;
using Faj.Common.Model.Static;
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
using Faj.Client.GUI.Layout;
using Faj.Client.GUI.Layout.Interface;
using Uddle.Dynamic.Contract.Module;
using Uddle.Dynamic.Contract.Module.Interface;

namespace Faj.Client.Model.Game
{
	class GameModel : AbstractGameModel
	{
        IPlayerModel playerModel;
        IPreloaderLayout preloaderLayout;
        IIntroLayout introLayout;
        IPlayerLayout playerLayout;
        ISelectLevelLayout selectLevelLayout;

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
            var dependecyAwaiter = preloaderModel as IDependencyAwaiter;
            dependecyAwaiter.OnDependenciesReleaseEvent += new Action(OnPreloaderRelease);
            
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
            preloaderLayout = new PreloaderLayout(preloaderModel, coreBootstraper.GetApplicationConfig().GetPlatform());
            preloaderLayout.Draw();            
        }

        void OnPreloaderRelease()
        {
            preloaderLayout.Disappear();
            introLayout = new IntroLayout(coreBootstraper.GetApplicationConfig().GetPlatform());

            var introDependency = introLayout as IDependency;
            introDependency.OnReleaseEvent += new Action<IDependency>(OnReleaseIntro);

            introLayout.Draw();
        }

        void OnReleaseIntro(IDependency dependency)
        {
            var introDependency = introLayout as IDependency;
            introDependency.OnReleaseEvent -= new Action<IDependency>(OnReleaseIntro);
            introLayout.Disappear();


            var platform = coreBootstraper.GetApplicationConfig().GetPlatform();
            playerLayout = new PlayerLayout(platform);
            selectLevelLayout = new SelectLevelLayout(platform);
            playerLayout.Draw();
            selectLevelLayout.Draw();
            selectLevelLayout.Hide();
            playerModel.OnChangeLocation += new Action<LocationEnum>(OnChangeLocation);
            playerModel.ChangeLocation(LocationEnum.Upgrade);
        }

        void OnChangeLocation(LocationEnum location)
        {
            switch (location)
            {
                case LocationEnum.Upgrade:
                    UnityEngine.Debug.Log("To Upgrade");
                    selectLevelLayout.Hide();
                    playerLayout.Display();
                    break;
                case LocationEnum.SelectLevel:
                    UnityEngine.Debug.Log("To Select Level");
                    selectLevelLayout.Display();
                    playerLayout.Hide();
                    break;

            }

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
