using Application.GamePackages;

namespace Application.Manager.Assets.Interface
{
    public delegate void PackageDonwloadDelegate(bool result, string packageName);

	public interface ILoadAndCacheAdapter
	{
        void LoadPackage(StaticPackage package, PackageDonwloadDelegate OnLoaded);
        void LoadPackageInstantly(StaticPackage package, PackageDonwloadDelegate OnLoaded);
	}
}
