using UnityEngine;
using Uddle.Service.Interface;

namespace Uddle.Assets.Package.Manager.Service.Interface
{
	interface IResourceManagerService : IService
	{
        void LoadResource(string packageName, string resourceName);
        Object GetResource(string packageName, string resourceName);
        void UnloadResources(string packageName);
	}
}
