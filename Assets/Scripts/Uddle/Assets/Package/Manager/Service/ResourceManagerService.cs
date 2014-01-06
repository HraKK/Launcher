using UnityEngine;
using Uddle.Assets.Package.Manager.Service.Interface;
using Uddle.Assets.Package.Manager.Interface;

namespace Uddle.Assets.Package.Manager.Service
{
    class ResourceManagerService : IResourceManagerService
	{
        readonly IPackageResourceManager packageResourceManager;

        public ResourceManagerService(IPackageResourceManager packageResourceManager)
        {
            this.packageResourceManager = packageResourceManager;
        }

        public void LoadResource(string packageName, string resourceName)
        {
            packageResourceManager.LoadResource(packageName, resourceName);
        }

        public Object GetResource(string packageName, string resourceName)
        {
            return packageResourceManager.GetResource(packageName, resourceName);
        }

        public void UnloadResources(string packageName)
        {
            packageResourceManager.UnloadResources(packageName);
        }
	}
}
