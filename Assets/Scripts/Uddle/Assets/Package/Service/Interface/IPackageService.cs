using Uddle.Assets.Package.Dynamic.Interface;
using Uddle.Service.Interface;

namespace Uddle.Assets.Package.Service.Interface
{
    interface IPackageService : IService
    {
        void AddPackage(IDynamicPackage package);
        bool PackageExist(string packageName);
        IDynamicPackage GetPackage(string packageName);
    }
}
