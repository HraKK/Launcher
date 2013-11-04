using System;
using System.Collections.Generic;

namespace Application.GamePackages
{
    public class PackageFactoryModel
    {
        private Dictionary<string, DynamicPackage> packages = new Dictionary<string, DynamicPackage>();

        public void AddPackage(DynamicPackage package)
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

        public DynamicPackage GetPackage(string packageName)
        {
            DynamicPackage package;

            if (!packages.TryGetValue(packageName, out package))
            {
                throw new Exception("Key: " + packageName + " not exist.");
            }

            return package;
        }
    }
}