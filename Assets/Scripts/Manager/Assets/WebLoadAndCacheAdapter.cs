using System;
using Application.GamePackages;
using Application.GamePackages.Interface;
using Application.Manager.Assets.Interface;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using Application.Manager.Service;
using UnityEngine;

namespace Application.Manager.Assets
{
	public class WebLoadAndCacheAdapter : ILoadAndCacheAdapter
	{
        private Dictionary<string, DownloadPackage> loadingQueue;
        private DownloadPackage currentDownloading;
		private Downloader downloader;
	    private IPackageFactory packageFactory;
	    private int order;

		public WebLoadAndCacheAdapter()
		{
            loadingQueue = new Dictionary<string, DownloadPackage>();
			var go = GameObject.FindGameObjectWithTag("MainCamera");
			downloader = go.GetComponent<Downloader>();
		    packageFactory = ServiceProvider.Instance.GetService<IPackageFactory>(); 
		    order = -1;
		}

        public void LoadPackage(StaticPackage package, PackageDonwloadDelegate OnLoadEvent)
		{
            AddToQueue(package, OnLoadEvent);
			Download();
		}

        public void LoadPackageInstantly(StaticPackage package, PackageDonwloadDelegate OnLoadEvent)
		{
            AddToQueueHead(package, OnLoadEvent);
			Download();
		}

        private void AddToQueue(StaticPackage package, PackageDonwloadDelegate OnLoadEvent)
		{
            if (IsHandled(package.name))
            {
                return;
            }

            if (IsDownloaded(package.name))
            {
               // TODO 
            }

            order++;
            Add(package, OnLoadEvent, order);
		}

        private void AddToQueueHead(StaticPackage package, PackageDonwloadDelegate OnLoadEvent)
        {
            var packageName = package.name;
            if (IsDownloading(packageName))
            {
                return;
            }

            IncreaseOrder();

            if (InQueue(packageName))
            {
                GetPackage(packageName).SetMinOrder();
                return;
            }

            Add(package, OnLoadEvent);
        }

        private void Add(StaticPackage package, PackageDonwloadDelegate OnLoadEvent, int order = 0)
        {
            var dynamicPackage = new DynamicPackage(package);
            var donwloadPackage = new DownloadPackage(dynamicPackage, OnLoadEvent, order);

            loadingQueue.Add(package.name, donwloadPackage);             
        }

        private DownloadPackage GetPackage(string name)
        {
            DownloadPackage package;

            if (!loadingQueue.TryGetValue(name, out package))
            {
                throw new Exception("Get package error");
            }

            return package;
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

        private bool IsDownloaded(string packageName)
        {
            // TODO: Check if downloaded. and throw onLoadEvent
            return false;
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

        private DownloadPackage GetFirstPackage()
        {
            DownloadPackage result = null;
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

			downloader.StartCoroutineDelegate(LoadPackages);
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
					currentDownloading.OnDownloaded(false);
					throw new Exception("WWW download had an error:" + www.error);
				}
                
				AssetBundle bundle = www.assetBundle;
			    var dynamicPackage = currentDownloading.GetPackage();

                dynamicPackage.SetBundle(bundle);
                packageFactory.AddPackage(dynamicPackage);

/*
				if(bundle.Contains("objectsList"))
				{
					StringHolder holder = bundle.Load("objectsList", typeof(StringHolder)) as StringHolder;

					foreach(var c in holder.content)
					{
						Debug.Log (c);
					}
				}*/

                currentDownloading.OnDownloaded(true);
			    loadingQueue.Remove(staticPackage.name);
			    currentDownloading = null;

				Download();
			}
		}

	}
}