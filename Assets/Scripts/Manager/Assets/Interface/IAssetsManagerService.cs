using Application.Manager.Service.Interface;

namespace Application.Manager.Assets.Interface
{
	public interface IAssetsManagerService : IService
	{
		ILoadAndCacheAdapter GetLoadAndCacheAdapter();
	}
}
