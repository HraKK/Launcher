using System;
using Uddle.Assets;
using Uddle.Assets.Interface;
using Uddle.Assets.Package.Dynamic;
using Uddle.Assets.Package.Service;
using Uddle.Assets.Adapter;
using Uddle.Assets.Service;
using Uddle.Assets.Service.Interface;
using Uddle.Assets.Package.Service.Interface;
using Uddle.Service;
using Uddle.Observer;
using Uddle.GUISysytem.Service;
using Uddle.GUISysytem.Service.Interface;
using Uddle.Service.Interface;
using Uddle.Config.Interface;
using Uddle.Bootstrap.Interface;
using Uddle.Assets.Package.Manager;
using Uddle.Assets.Package.Manager.Service;
using Uddle.Assets.Package.Manager.Service.Interface;

namespace Uddle.Bootstrap
{
    class ServiceBootstraper : IBootstraper
    {
        readonly IApplicationConfig applicationConfig;

        public ServiceBootstraper(IApplicationConfig applicationConfig)
        {
            this.applicationConfig = applicationConfig;
        }

        public void Bootstrap()
        {
            var serviceProvider = ServiceProvider.Instance;

            var GUIObserverCollection = new ObserverCollection();
            var GUIObserverService = new GUIObserverService(GUIObserverCollection);
            serviceProvider.SetService<IGUIObserverService>(GUIObserverService);

            var coroutineService = new CoroutineService();
            serviceProvider.SetService<ICoroutineService>(coroutineService);

            var assetAdapterFactory = new AssetAdapterFactory(applicationConfig.GetPlatform());
            var assetService = new AssetService(assetAdapterFactory);
            serviceProvider.SetService<IAssetService>(assetService);

            var packageCollection = new PackageCollection();
            var packageFactory = new PackageService(packageCollection);
            serviceProvider.SetService<IPackageService>(packageFactory);

            var packageResourceManager = new PackageResourceManager();
            var resourceManagerService = new ResourceManagerService(packageResourceManager);
            serviceProvider.SetService<IResourceManagerService>(resourceManagerService);
        }
    }
}
