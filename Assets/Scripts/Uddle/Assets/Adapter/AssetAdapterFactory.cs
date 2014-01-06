using Uddle.Assets.Adapter.Interface;
using Uddle.Config.Interface;

namespace Uddle.Assets.Adapter
{
    class AssetAdapterFactory : IAssetAdapterFactory
	{
		ILoadAndCacheAdapter loadAndCacheAdapter;
        ApplicationPlatform platform;

        public AssetAdapterFactory(ApplicationPlatform platform)
        {
            this.platform = platform;
        }

		public ILoadAndCacheAdapter GetLoadAndCacheAdapter()
		{
			if(loadAndCacheAdapter == null)
			{
				switch(platform)
                {
                    /*case ApplicationPlatform.IOS :
				        loadAndCacheAdapter = new iOSLoadAndCacheAdapter();
                        break;
                    */
                    default :
				        loadAndCacheAdapter = new WebLoadAndCacheAdapter();
                        break;
                }   

			}

			return loadAndCacheAdapter;
		}
	}
}