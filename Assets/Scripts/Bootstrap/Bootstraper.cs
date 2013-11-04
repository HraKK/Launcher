using System;
using System.Collections;
using Application.Bootstrap.Interface;
using Application.GUISysytem.Interface;
using Application.Manager.Service;
using Application.UI;
using UnityEngine;

namespace Application.Bootstrap
{
    public class Bootstraper : IBootstraper
    {
        public event Action<int> OnDownloadPackagesStartEvent;
        public event Action OnInitializeCompleteEvent;
        public event Action OnDownloadedPackageEvent;
        public event Action OnDownloadPackagesFinishEvent;

        private CoreBootstraper coreBootstraper;
        private PackagesBootstraper packagesBootstraper;

        void InitComponents()
        {
            var preloader = new PreLoader(this);

            coreBootstraper.Init();
        }

        public void Init()
        {
            coreBootstraper = new CoreBootstraper();
            coreBootstraper.OnComplete += OnCoreBootstraperComplete;
            packagesBootstraper = new PackagesBootstraper();
            packagesBootstraper.OnDownloadPackage += OnDownloadPackage;
            packagesBootstraper.OnComplete += OnPackagesBootstraperComplete;

            InitComponents();
        }

        private void OnDownloadPackage()
        {
            if (OnDownloadedPackageEvent != null)
            {
                OnDownloadedPackageEvent();   
            }
        }

        private void OnCoreBootstraperComplete()
        {
            if (OnInitializeCompleteEvent != null)
            {
                OnInitializeCompleteEvent();   
            }

            packagesBootstraper.StartDownload();
        }

        private void OnPackagesBootstraperComplete()
        {
            if (OnDownloadPackagesFinishEvent != null)
            {
                OnDownloadPackagesFinishEvent();   
            }
        }
    }    
}
