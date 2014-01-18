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
        Dictionary<string, IDownloadPackage> loadingQueue = new Dictionary<string, IDownloadPackage>();
        List<string> downloadedPackages = new List<string>();
        IDownloadPackage currentDownloading;
	    IPackageService packageService;
	    int order = -1;
        readonly ICoroutineService coroutineService;

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

        void AddToQueue(IDynamicPackage dynamicPackage, PackageDonwloadDelegate OnLoadEvent)
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

        void AddToQueueHead(IDynamicPackage dynamicPackage, PackageDonwloadDelegate OnLoadEvent)
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

        void Add(IDynamicPackage dynamicPackage, PackageDonwloadDelegate OnLoadEvent, int order = 0)
        {
            var packageName = dynamicPackage.GetStaticPackage().name;
            var donwloadPackage = new DownloadPackage(dynamicPackage, OnLoadEvent, order);

            loadingQueue.Add(packageName, donwloadPackage);             
        }

        IDownloadPackage GetLoadingPackage(string name)
        {
            IDownloadPackage package;

            if (!loadingQueue.TryGetValue(name, out package))
            {
                throw new Exception("Package did not added to load queue: " + name);
            }

            return package;
        }

        bool IsDownloaded(string name)
        {
            return downloadedPackages.Contains(name);
        }

        bool IsDownloading(string packageName)
        {
            if (currentDownloading == null)
            {
                return false;
            }

            return currentDownloading.GetPackage().GetStaticPackage().name == packageName;
        }

        bool InQueue(string packageName)
        {
            return loadingQueue.Any(kvp => kvp.Key == packageName);
        }

	    bool IsHandled(string packageName)
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

        bool IsBusy()
        {
            return currentDownloading != null;
        }

        IDownloadPackage GetFirstPackage()
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

		void Download()
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

		IEnumerator LoadPackages()
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