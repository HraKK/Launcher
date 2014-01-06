using Uddle.Service.Interface;
using Uddle.Assets.Adapter.Interface;

namespace Uddle.Assets.Service.Interface
{
	interface IAssetService : IService
	{
		ILoadAndCacheAdapter GetLoadAndCacheAdapter();
	}
}
