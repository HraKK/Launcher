using System;
using Uddle.Dependency.Interface;
using System.Collections.Generic;
using Uddle.Assets.Package.Static.Interface;

namespace Uddle.Model.Downloader.Interface
{
	interface IDownloaderModel
	{
        event Action OnInitializeCompleteEvent;

        void AddPackageHandler(string handler, Action packageDelegate);
        void AddDependencyAwaiter(IDependencyAwaiter dependencyAwaiter);
        void Download(List<IStaticPackage> staticPackages);
	}
}
