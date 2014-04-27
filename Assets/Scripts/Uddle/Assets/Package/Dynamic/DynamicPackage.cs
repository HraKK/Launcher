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
        private bool isLoaded = false;
        private Object[] container;

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
            this.container = null;            
            assetBundle.Unload(true);
        }

        protected void Load()
        {
            this.container = assetBundle.LoadAll();
        }

        public T Get<T>(string key)
        {
            if (false == isLoaded)
            {
                this.Load();
            }

            T result = default(T);

            foreach (var item in container)
            {
                if (item.name != key)
                {
                    continue;
                }

                result = (T)Convert.ChangeType(item, typeof(T));
            }

            return result;

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