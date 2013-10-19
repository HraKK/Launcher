using Application.Manager.Assets.Interface;

namespace Application.Manager.Assets
{
	public class AssetManagerModel
	{
		ILoadAndCacheAdapter iOSAdapter;
		ILoadAndCacheAdapter webAdapter;

		public ILoadAndCacheAdapter GetLoadAndCacheAdapter()
		{
			//if iOS
			if(iOSAdapter == null)
			{
				iOSAdapter = new iOSLoadAndCacheAdapter();
			}

			return iOSAdapter;

			//if web
			if(webAdapter == null)
			{
				webAdapter = new WebLoadAndCacheAdapter();
			}

			return webAdapter;
		}
	}
}