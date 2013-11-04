using Application.Manager.Assets.Interface;
using UnityEngine;

namespace Application.Manager.Assets
{
	public class AssetManagerModel
	{
		ILoadAndCacheAdapter loadAndCacheAdapter;

		public ILoadAndCacheAdapter GetLoadAndCacheAdapter()
		{
			if(loadAndCacheAdapter == null)
			{
				#if UNITY_IPHONE
				loadAndCacheAdapter = new iOSLoadAndCacheAdapter();
				#endif

				#if UNITY_WEBPLAYER
				loadAndCacheAdapter = new WebLoadAndCacheAdapter();
				#endif
			}

			return loadAndCacheAdapter;
		}
	}
}