using System;
using Application.Bootstrap.Interface;
using Application.GUISysytem.Interface;
using Application.Manager.Service;
using Application.Preloader;
using Application.Preloader.Interface;
using UnityEngine;

namespace Application.UI
{
    public class PreLoader : IPreloader
    {
        private IGUIView view;
        private IGUISystem guiSystem;
        private int totalPackages;
        private int currentPackagesCount;
        public event Action<int> OnTotalPackagesEvent;
        public event Action<int> OnPackageDonwloadEvent;

        public PreLoader(IBootstraper bootstraper)
        {
            bootstraper.OnInitializeCompleteEvent += OnInitializeComplete;
            bootstraper.OnDownloadPackagesStartEvent += OnDownloadPackagesStart;
            bootstraper.OnDownloadedPackageEvent += OnDownloadedPackage;
            bootstraper.OnDownloadPackagesFinishEvent += OnDownloadPackagesFinish;

            guiSystem = ServiceProvider.Instance.GetService<IGUISystem>();
            view = new PreloaderView(this);
        }

        void OnInitializeComplete()
        {
            guiSystem.AddView(view);
        }

        void OnDownloadPackagesStart(int count)
        {
            totalPackages = count + 1;
            if (OnTotalPackagesEvent != null)
            {
                OnTotalPackagesEvent(totalPackages);   
            }
        }

        void OnDownloadedPackage()
        {
            currentPackagesCount++;
            if (OnPackageDonwloadEvent != null)
            {
                OnPackageDonwloadEvent(currentPackagesCount);
            }
        }

        void OnDownloadPackagesFinish()
        {
            guiSystem.RemoveView(view);
        }
    }
}
