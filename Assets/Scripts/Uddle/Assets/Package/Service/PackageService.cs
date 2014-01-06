using Uddle.Assets.Package.Service.Interface;
using Uddle.Assets.Package.Dynamic.Interface;

namespace Uddle.Assets.Package.Service
{
    class PackageService : IPackageService
    {
        private IPackageCollection packageCollection;

        public PackageService(IPackageCollection model)
        {
            this.packageCollection = model;
        }

        public void AddPackage(IDynamicPackage package)
        {
            packageCollection.AddPackage(package);
        }

        public bool PackageExist(string packageName)
        {
            return packageCollection.PackageExist(packageName);
        }

        public IDynamicPackage GetPackage(string packageName)
        {
            return packageCollection.GetPackage(packageName);
        }
    }
}
