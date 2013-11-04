using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Application.GamePackages;
using Application.Manager.Assets;
using Application.Manager.Assets.Interface;
using Application.Manager.Service;
using UnityEngine;

using System.Collections;

namespace Application.Bootstrap
{
    public class PackagesBootstraper
    {
        public Action OnComplete;
        public Action OnDownloadPackage;
        public Action<int> OnDownloadPackagesStart;

        private string xmlPath = "file:///C://packages.xml";
        private Downloader downloader;
        private StaticPackages packages;
        private readonly IAssetsManagerService assetsManager;

        public PackagesBootstraper()
        {
            assetsManager = ServiceProvider.Instance.GetService<IAssetsManagerService>();
        }

        public void StartDownload()
        {
            downloader = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Downloader>();
            downloader.StartCoroutine(DownloadXML());
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
                StartDownloadingBundles();
            }
        }

        private void StartDownloadingBundles()
        {
            var requiredPackages = packages.GetPackagesByType(PackageType.Require);

            foreach (var requiredPackage in requiredPackages)
            {
                assetsManager.GetLoadAndCacheAdapter().LoadPackage(requiredPackage, OnLoad);
            }
        }

        void OnLoad(bool result, string name)
        {
            if (OnDownloadPackage != null)
            {
                OnDownloadPackage();
            }

            Debug.Log("RESULT: " + result + "| Name: " + name);
        }
    }
}
