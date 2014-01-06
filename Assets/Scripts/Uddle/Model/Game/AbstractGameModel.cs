using System;
using Uddle.Model.Game.Interface;
using Uddle.Model.Preloader.Interface;
using Uddle.Bootstrap.Interface;
using Uddle.Model.Downloader.Interface;
using Uddle.Model.Downloader;
using Uddle.Assets.Package.Static;
using Uddle.Dependency.Interface;

namespace Uddle.Model.Game
{
    abstract class AbstractGameModel : IGameModel
    {
        public event Action OnInitializeCompleteEvent;

        readonly protected ICoreBootstraper coreBootstraper;

        protected IPreloaderModel preloaderModel;
        protected IDownloaderModel downloaderModel;

        public AbstractGameModel(ICoreBootstraper coreBootstraper)
        {
            this.coreBootstraper = coreBootstraper;
            
            InitializePreloaderModel();
            InitializeDownloaderModel();
            InitializePackageHandlers();
        }

        protected void InitializeDownloaderModel()
        {
            var packageBootstraper = coreBootstraper.GetPackageBootstraper();
            downloaderModel = new DownloaderModel(packageBootstraper);
            downloaderModel.OnInitializeCompleteEvent += new Action(OnInitializeComplete);
        }

        protected virtual void OnInitializeComplete()
        {
            var staticPackages = coreBootstraper.GetPackageBootstraper().GetStaticPackages();
            var requiredPackages = staticPackages.GetPackagesByType(PackageType.Require);
            downloaderModel.AddDependencyAwaiter(preloaderModel as IDependencyAwaiter);
            downloaderModel.Download(requiredPackages);

            if (OnInitializeCompleteEvent == null)
            {
                return;
            }

            OnInitializeCompleteEvent();
        }

        protected abstract void InitializePackageHandlers();
        protected abstract void InitializePreloaderModel();
        protected abstract void InitializeServer();
        protected abstract void InitializePlayerModel(string playerId);

        protected IDownloaderModel GetDownloaderModel()
        {
            return downloaderModel;
        }

        public virtual void Initialize(string playerId)
        {
            coreBootstraper.Bootstrap();
            InitializeServer();
            InitializePlayerModel(playerId);
        }

        public abstract void Run();
    }
}
