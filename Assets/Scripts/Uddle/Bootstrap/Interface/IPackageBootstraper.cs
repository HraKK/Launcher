using System;
using System.Collections.Generic;
using Uddle.Assets.Package.Dynamic.Interface;
using Uddle.Assets.Package.Static.Interface;


namespace Uddle.Bootstrap.Interface
{
	interface IPackageBootstraper : IBootstraper
	{
        event Action OnInitializeCompleteEvent;
        event Action<int> OnDownloadPackagesStartEvent;
        event Action<string> OnDownloadPackageEvent;
        event Action OnDownloadPackagesCompleteEvent;

        void StartDownloadPackages(List<IDynamicPackage> packages);
        IStaticPackages GetStaticPackages();
	}
}
