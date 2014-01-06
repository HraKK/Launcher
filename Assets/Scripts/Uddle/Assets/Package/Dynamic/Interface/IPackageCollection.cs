namespace Uddle.Assets.Package.Dynamic.Interface
{
	interface IPackageCollection
	{
        void AddPackage(IDynamicPackage package);
        bool PackageExist(string packageName);
        IDynamicPackage GetPackage(string packageName);
	}
}