using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using UnityEngine;
using Uddle.Assets.Interface;
using Uddle.Assets.Package.Service.Interface;
using Uddle.Assets.Package.Dynamic.Interface;
using Uddle.Assets.Package.Dynamic;
using Uddle.Assets.Adapter.Interface;
using Uddle.Service.Interface;
using Uddle.Service;


namespace Uddle.Assets.Adapter
{
	class WebLoadAndCacheAdapter : ILoadAndCacheAdapter
	{
        private Dictionary<string, IDownloadPackage> loadingQueue = new Dictionary<string, IDownloadPackage>();
        private List<string> downloadedPackages = new List<string>();
        private IDownloadPackage currentDownloading;
	    private IPackageService packageService;
	    private int order = -1;
        private readonly ICoroutineService coroutineService;

		public WebLoadAndCacheAdapter()
		{
            coroutineService = ServiceProvider.Instance.GetService<ICoroutineService>();
		    packageService = ServiceProvider.Instance.GetService<IPackageService>(); 
		}

        public void LoadPackage(IDynamicPackage dynamicPackage, PackageDonwloadDelegate OnLoadEvent)
		{
            AddToQueue(dynamicPackage, OnLoadEvent);
			Download();
		}

        public void LoadPackageInstantly(IDynamicPackage dynamicPackage, PackageDonwloadDelegate OnLoadEvent)
		{
            AddToQueueHead(dynamicPackage, OnLoadEvent);
			Download();
		}

        private void AddToQueue(IDynamicPackage dynamicPackage, PackageDonwloadDelegate OnLoadEvent)
		{
            var packageName = dynamicPackage.GetStaticPackage().name;
            if (IsHandled(packageName))
            {
                return;
            }

            if (IsDownloaded(packageName))
            {
                dynamicPackage.Loaded();
                OnLoadEvent(true, dynamicPackage);
            }

            order++;
            Add(dynamicPackage, OnLoadEvent, order);
		}

        private void AddToQueueHead(IDynamicPackage dynamicPackage, PackageDonwloadDelegate OnLoadEvent)
        {
            var packageName = dynamicPackage.GetStaticPackage().name;
            if (IsDownloading(packageName))
            {
                return;
            }

            IncreaseOrder();

            if (InQueue(packageName))
            {
                GetLoadingPackage(packageName).SetMinOrder();
                return;
            }

            Add(dynamicPackage, OnLoadEvent);
        }

        private void Add(IDynamicPackage dynamicPackage, PackageDonwloadDelegate OnLoadEvent, int order = 0)
        {
            var packageName = dynamicPackage.GetStaticPackage().name;
            var donwloadPackage = new DownloadPackage(dynamicPackage, OnLoadEvent, order);

            loadingQueue.Add(packageName, donwloadPackage);             
        }

        private IDownloadPackage GetLoadingPackage(string name)
        {
            IDownloadPackage package;

            if (!loadingQueue.TryGetValue(name, out package))
            {
                throw new Exception("Package did not added to load queue: " + name);
            }

            return package;
        }

        private bool IsDownloaded(string name)
        {
            return downloadedPackages.Contains(name);
        }

        private bool IsDownloading(string packageName)
        {
            if (currentDownloading == null)
            {
                return false;
            }

            return currentDownloading.GetPackage().GetStaticPackage().name == packageName;
        }

        private bool InQueue(string packageName)
        {
            return loadingQueue.Any(kvp => kvp.Key == packageName);
        }

	    private bool IsHandled(string packageName)
        {
	        if (IsDownloading(packageName) || InQueue(packageName))
	        {
	            return true;
	        }

	        return false;
        }

        private void IncreaseOrder()
        {
            foreach (var package in loadingQueue.Values)
            {
                package.IncrementOrder();
            }
        }

        private bool IsBusy()
        {
            return currentDownloading != null;
        }

        private IDownloadPackage GetFirstPackage()
        {
            IDownloadPackage result = null;
            int order = Int32.MaxValue;

            foreach (var package in loadingQueue.Values)
            {
                if (package.GetOrder() >= order)
                {
                    continue;
                }

                result = package;
                order = result.GetOrder();
            }

            return result;
        }

		private void Download()
		{
            if (IsBusy())
            {
                return;
            }

		    currentDownloading = GetFirstPackage();
            
            if (currentDownloading == null)
            {
                return;
            }

            coroutineService.StartCoroutine(LoadPackages);
		}

		private IEnumerator LoadPackages()
		{            
			while(!Caching.ready)
			{
				yield return null;
			}

		    var staticPackage = currentDownloading.GetPackage().GetStaticPackage();

            using (WWW www = WWW.LoadFromCacheOrDownload(staticPackage.url, staticPackage.version))
			{
				yield return www;

				if(www.error != null)
				{
					currentDownloading.Failure();
					throw new Exception("WWW download had an error:" + www.error);
				}
                
				AssetBundle bundle = www.assetBundle;
			    var dynamicPackage = currentDownloading.GetPackage();
                
                dynamicPackage.SetBundle(bundle);
                packageService.AddPackage(dynamicPackage);

                currentDownloading.Complete();
			    loadingQueue.Remove(staticPackage.name);
                dynamicPackage.Loaded();
                downloadedPackages.Add(staticPackage.name);
			    currentDownloading = null;
				Download();
			}
		}

	}
}