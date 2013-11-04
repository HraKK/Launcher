using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Application.GamePackages
{
    public class DynamicPackage
    {
        private readonly StaticPackage package;
        private AssetBundle assetBundle;

        public DynamicPackage(StaticPackage package)
        {
            this.package = package;
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

        public void SetBundle(AssetBundle bundle)
        {
            assetBundle = bundle;
        }

        public StaticPackage GetStaticPackage()
        {
            return package;
        }
    }   
}
