using Application.GamePackages;
using Application.Manager.Service.Interface;

namespace Application.GamePackages.Interface
{
    public interface IPackageFactory : IService
    {
        void AddPackage(DynamicPackage package);
        bool PackageExist(string packageName);
        DynamicPackage GetPackage(string packageName);
    }
}
