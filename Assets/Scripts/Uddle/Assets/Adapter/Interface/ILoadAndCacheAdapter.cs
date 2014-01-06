using Uddle.Assets.Package.Dynamic.Interface;

namespace Uddle.Assets.Adapter.Interface
{
    delegate void PackageDonwloadDelegate(bool result, IDynamicPackage dynamicPackage);

	interface ILoadAndCacheAdapter
	{
        void LoadPackage(IDynamicPackage dynamicPackage, PackageDonwloadDelegate OnLoaded);
        void LoadPackageInstantly(IDynamicPackage dynamicPackage, PackageDonwloadDelegate OnLoaded);
	}
}
