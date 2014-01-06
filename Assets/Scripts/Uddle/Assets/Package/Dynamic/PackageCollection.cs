using System;
using System.Collections.Generic;
using Uddle.Assets.Package.Dynamic.Interface;

namespace Uddle.Assets.Package.Dynamic
{
    class PackageCollection : IPackageCollection
    {
        private Dictionary<string, IDynamicPackage> packages = new Dictionary<string, IDynamicPackage>();

        public void AddPackage(IDynamicPackage package)
        {
            var packageName = package.GetStaticPackage().name;
            if (packages.ContainsKey(packageName))
            {
                return;
            }

            packages.Add(packageName, package);
        }

        public bool PackageExist(string packageName)
        {
            return packages.ContainsKey(packageName);
        }

        public IDynamicPackage GetPackage(string packageName)
        {
            IDynamicPackage package;

            packages.TryGetValue(packageName, out package);

            return package;
        }
    }
}