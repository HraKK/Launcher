using Application.GamePackages.Interface;

namespace Application.GamePackages
{
    public class PackageFactory : IPackageFactory
    {
        private PackageFactoryModel model;

        public PackageFactory(PackageFactoryModel model)
        {
            this.model = model;
        }

        public void AddPackage(DynamicPackage package)
        {
            model.AddPackage(package);
        }

        public bool PackageExist(string packageName)
        {
            return model.PackageExist(packageName);
        }

        public DynamicPackage GetPackage(string packageName)
        {
            return model.GetPackage(packageName);
        }
    }
}
