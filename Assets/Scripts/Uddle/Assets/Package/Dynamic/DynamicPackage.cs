using System;
using UnityEngine;
using Object = UnityEngine.Object;
using Uddle.Assets.Package.Dynamic.Interface;
using Uddle.Assets.Package.Static.Interface;
using Uddle.Dependency.Interface;


namespace Uddle.Assets.Package.Dynamic
{
    class DynamicPackage : IDynamicPackage, IDependency
    {
        public event Action<IDependency> OnReleaseEvent;

        private readonly IStaticPackage package;
        private AssetBundle assetBundle;

        public DynamicPackage(IStaticPackage package)
        {
            this.package = package;
        }

        public void Loaded()
        {
            if (OnReleaseEvent == null)
            {
                return;
            }

            OnReleaseEvent(this);
        }

        public void FreeMemory()
        {
            assetBundle.Unload(false);
        }

        public void Unload()
        {
            assetBundle.Unload(true);
        }

        public Object GetObject(string objectName)
        {
            if (assetBundle == null || !assetBundle.Contains(objectName))
            {
                return null;
            }

            return assetBundle.Load(objectName);
        }

        public AssetBundle GetBundle()
        {
            return assetBundle;
        }

        public void SetBundle(AssetBundle bundle)
        {
            assetBundle = bundle;
        }

        public IStaticPackage GetStaticPackage()
        {
            return package;
        }
    }   
}