using Application.Manager.Assets.Interface;

namespace Application.Manager.Assets
{
	public class AssetsManager : IAssetsManagerService 
	{
		private AssetManagerModel model;

		public AssetsManager(AssetManagerModel model)
		{
			this.model = model;
		}

		public ILoadAndCacheAdapter GetLoadAndCacheAdapter()
		{
			return model.GetLoadAndCacheAdapter();
		}
	}
}
