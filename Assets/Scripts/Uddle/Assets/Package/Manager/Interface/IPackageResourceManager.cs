using UnityEngine;

namespace Uddle.Assets.Package.Manager.Interface
{
	interface IPackageResourceManager
	{
        void LoadResource(string packageName, string resourceName);
        Object GetResource(string packageName, string resourceName);
        void UnloadResources(string packageName);
	}
}