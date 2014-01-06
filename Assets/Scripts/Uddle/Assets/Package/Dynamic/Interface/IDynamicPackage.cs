using UnityEngine;
using Object = UnityEngine.Object;
using Uddle.Assets.Package.Static.Interface;

namespace Uddle.Assets.Package.Dynamic.Interface
{
	interface IDynamicPackage
	{
        AssetBundle GetBundle();
        void Unload();
        void FreeMemory();
        Object GetObject(string objectName);
        void SetBundle(AssetBundle bundle);
        IStaticPackage GetStaticPackage();
        void Loaded();
	}
}
