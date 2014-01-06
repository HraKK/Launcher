using Uddle.Assets.Package.Manager.Interface;
using System.Collections.Generic;
using UnityEngine;
using Uddle.Assets.Package.Service.Interface;
using Uddle.Service;

namespace Uddle.Assets.Package.Manager
{
	class PackageResourceManager : IPackageResourceManager
	{
        readonly IPackageService packageService;

        Dictionary<string, Dictionary<string, Object>> loadedResources = new Dictionary<string, Dictionary<string, Object>>();

        public PackageResourceManager()
        {
            packageService = ServiceProvider.Instance.GetService<IPackageService>();            
        }

        public void LoadResource(string packageName, string resourceName)
        {
            var package = packageService.GetPackage(packageName);

            if (package == null)
            {
                return;
            }

            Dictionary<string, Object> resources;

            if (!loadedResources.TryGetValue(packageName, out resources))
            {
                resources = new Dictionary<string, Object>();
                loadedResources.Add(packageName, resources);
            }

            Object resource;

            if (!resources.TryGetValue(resourceName, out resource))
            {
                return;
            }

            resource = package.GetObject(resourceName);
            resources.Add(resourceName, resource);

            package.FreeMemory();
        }

        public Object GetResource(string packageName, string resourceName)
        {
            Dictionary<string, Object> resources;

            if (!loadedResources.TryGetValue(packageName, out resources))
            {
                return null;
            }

            Object resource;

            resources.TryGetValue(resourceName, out resource);

            return resource;
        }

        public void UnloadResources(string packageName)
        {
            var package = packageService.GetPackage(packageName);

            if (package == null)
            {
                return;
            }

            if (loadedResources.ContainsKey(packageName))
            {
                loadedResources.Remove(packageName);
            }

            package.Unload();
        }
	}
}
