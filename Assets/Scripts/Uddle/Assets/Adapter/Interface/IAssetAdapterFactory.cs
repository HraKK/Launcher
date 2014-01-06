namespace Uddle.Assets.Adapter.Interface
{
	interface IAssetAdapterFactory
	{
        ILoadAndCacheAdapter GetLoadAndCacheAdapter();
	}
}
