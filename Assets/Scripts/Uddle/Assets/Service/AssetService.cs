using Uddle.Assets.Service.Interface;
using Uddle.Assets.Adapter.Interface;

namespace Uddle.Assets.Service
{
	class AssetService : IAssetService 
	{
        private IAssetAdapterFactory assetAdapterFactory;

        public AssetService(IAssetAdapterFactory assetAdapterFactory)
		{
            this.assetAdapterFactory = assetAdapterFactory;
		}

		public ILoadAndCacheAdapter GetLoadAndCacheAdapter()
		{
            return assetAdapterFactory.GetLoadAndCacheAdapter();
		}
	}
}
