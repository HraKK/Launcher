using System;
using Application.GUISysytem.Interface;
using Application.GamePackages;
using Application.GamePackages.Interface;
using Application.Manager.Assets;
using Application.Manager.Assets.Interface;
using Application.Manager.Service;
using Application.UI;
using UnityEngine;

namespace Application.Bootstrap
{
    public class CoreBootstraper
    {
        public Action OnComplete;

        public CoreBootstraper()
        {
            var assetManagerModel = new AssetManagerModel();
            var assetManager = new AssetsManager(assetManagerModel);
            ServiceProvider.Instance.SetService<IAssetsManagerService>(assetManager);

            var packageFactoryModel = new PackageFactoryModel();
            var packageFactory = new PackageFactory(packageFactoryModel);
            ServiceProvider.Instance.SetService<IPackageFactory>(packageFactory);

            var guiSystem = new GUISystem();
            ServiceProvider.Instance.SetService<IGUISystem>(guiSystem);
        }

        public void Init()
        {
            var mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
            mainCamera.AddComponent<Downloader>();

            if (OnComplete != null)
            {
                OnComplete();   
            }
        }
    }
}
