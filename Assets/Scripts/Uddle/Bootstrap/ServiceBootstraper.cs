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
using Uddle.Service.Interface;
using Uddle.Config.Interface;
using Uddle.Bootstrap.Interface;
using Uddle.Assets.Package.Manager;
using Uddle.Assets.Package.Manager.Service;
using Uddle.Assets.Package.Manager.Service.Interface;
using Uddle.GUI.Render.Service;
using Uddle.GUI.Render.Service.Interface;
using Uddle.GUI.Render.Pool;
using Uddle.GUI.Render.Pool.Service;
using Uddle.GUI.Render.Pool.Service.Interface;

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

            serviceProvider.SetService<IApplicationConfig>(applicationConfig);

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

            var spritePool = new SpritePool(applicationConfig.GetRendererCount());
            var spritePoolService = new SpritePoolService(spritePool);
            serviceProvider.SetService<ISpritePoolService>(spritePoolService);

            var mouseCollidableSpritePool = new MouseCollidableSpritePool(applicationConfig.GetRendererCount());
            var mouseCollidableSpritePoolService = new MouseCollidableSpritePoolService(mouseCollidableSpritePool);
            serviceProvider.SetService<IMouseCollidableSpritePoolService>(mouseCollidableSpritePoolService);
        }
    }
}
