using Uddle.Model.Downloader.Interface;
using Uddle.Bootstrap.Interface;
using System;
using Uddle.Dependency.Interface;
using System.Collections.Generic;
using Uddle.Assets.Package.Static.Interface;
using Uddle.Assets.Package.Dynamic.Interface;
using Uddle.Assets.Package.Dynamic;

namespace Uddle.Model.Downloader
{
	class DownloaderModel : IDownloaderModel
	{
        public event Action OnInitializeCompleteEvent;

        IDependencyAwaiter dependencyAwaiter;
        IPackageBootstraper packageBootstraper;

        protected Dictionary<string, Action> packageHandlers = new Dictionary<string, Action>();
        
        public DownloaderModel(IPackageBootstraper packageBootstraper)
        {
            this.packageBootstraper = packageBootstraper;
            packageBootstraper.OnInitializeCompleteEvent += new Action(OnInitializeComplete);
        }

        public void AddPackageHandler(string handler, Action packageDelegate)
        {
            packageHandlers.Add(handler, packageDelegate);
        }

        void OnInitializeComplete()
        {
            if (OnInitializeCompleteEvent == null)
            {
                return;
            }

            OnInitializeCompleteEvent();
        }

        public void AddDependencyAwaiter(IDependencyAwaiter dependencyAwaiter)
        {
            this.dependencyAwaiter = dependencyAwaiter;
        }

        public void Download(List<IStaticPackage> staticPackages)
        {
            List<IDynamicPackage> dynamicPackages = new List<IDynamicPackage>();

            foreach (var staticPackage in staticPackages)
            {
                var dynamicPackage = new DynamicPackage(staticPackage);
                dynamicPackages.Add(dynamicPackage);

                AddDependency(dynamicPackage as IDependency);
            }

            packageBootstraper.StartDownloadPackages(dynamicPackages);
        }

        void AddDependency(IDependency dependency)
        {
            if (dependencyAwaiter == null)
            {
                return;
            }

            dependencyAwaiter.AddDependency(dependency);
            dependency.OnReleaseEvent += new Action<IDependency>(OnDependencyRelease);
        }

        void OnDependencyRelease(IDependency dependency)
        {
            dependency.OnReleaseEvent -= new Action<IDependency>(OnDependencyRelease);

            if (dependency is IDynamicPackage)
            {
                OnDynamicPackageRelease(dependency as IDynamicPackage);
            }
        }

        void OnDynamicPackageRelease(IDynamicPackage dynamicPackage)
        {
            Action handler;

            if (packageHandlers.TryGetValue(dynamicPackage.GetStaticPackage().name, out handler))
            {
                handler();
            }
        }
	}
}
