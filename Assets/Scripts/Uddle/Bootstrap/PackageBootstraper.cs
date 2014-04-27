using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using UnityEngine;
using System.Collections;
using Uddle.Assets.Package.Static.Interface;
using Uddle.Assets.Service.Interface;
using Uddle.Service.Interface;
using Uddle.Service;
using Uddle.Assets.Package.Static;
using Uddle.Bootstrap.Interface;
using Uddle.Assets.Package.Dynamic.Interface;

namespace Uddle.Bootstrap
{
    class PackageBootstraper : IPackageBootstraper
    {
        public event Action OnInitializeCompleteEvent;
        public event Action<int> OnDownloadPackagesStartEvent;
        public event Action<string> OnDownloadPackageEvent;
        public event Action OnDownloadPackagesCompleteEvent;

        
        private IStaticPackages packages;
        private IAssetService assetService;
        private ICoroutineService coroutineService;
        private readonly string xmlPath;

        private int packagesDownloadedCount = 0;
        private int packagesTotalCount = 0;

        public PackageBootstraper(string xmlPath)
        {
            this.xmlPath = xmlPath;
        }

        public void Bootstrap()
        {
            GetCoroutineService().StartCoroutine(DownloadXML);
        }

        void OnComplete()
        {
            if (OnInitializeCompleteEvent != null)
            {
                OnInitializeCompleteEvent();
            }
        }

        private IEnumerator DownloadXML()
        {
            using (var www = new WWW(xmlPath))
            {
                yield return www;

                if (www.error != null)
                {
                    throw new System.Exception("WWW download had an error:" + www.error);
                }
                
                packages = new StaticPackages(www.text);
                OnComplete();
            }
        }

        public IStaticPackages GetStaticPackages()
        {
            return packages;
        }

        public void StartDownloadPackages(List<IDynamicPackage> packages)
        {
            packagesDownloadedCount = 0;
            packagesTotalCount = packages.Count;

            if (OnDownloadPackagesStartEvent != null)
            {
                OnDownloadPackagesStartEvent(packagesTotalCount);
            }

            foreach (var package in packages)
            {
                GetAssetService().GetLoadAndCacheAdapter().LoadPackage(package, OnLoad);
            }
        }

        void OnLoad(bool result, IDynamicPackage dynamicPackage)
        {
            var packageName = dynamicPackage.GetStaticPackage().name;
            Debug.Log("RESULT: " + result + "| Name: " + dynamicPackage.GetStaticPackage().name);

            if (result == false)
            {
                return;
            }

            packagesDownloadedCount++;

            if (OnDownloadPackageEvent != null)
            {
                OnDownloadPackageEvent(packageName);
            }

            if (packagesDownloadedCount != packagesTotalCount)
            {
                return;
            }

            if (OnDownloadPackagesCompleteEvent == null)
            {
                return;
            }
            
            OnDownloadPackagesCompleteEvent();
        }

        ICoroutineService GetCoroutineService()
        {
            if (coroutineService == null)
            {
                coroutineService = ServiceProvider.Instance.GetService<ICoroutineService>();
            }

            return coroutineService;
        }

        IAssetService GetAssetService()
        {
            if (assetService == null)
            {
                assetService = ServiceProvider.Instance.GetService<IAssetService>();
            }

            return assetService;
        }
    }
}
