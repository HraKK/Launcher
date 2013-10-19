using Application.Manager.Assets.Interface;

namespace Application.Manager.Assets
{
	public class iOSLoadAndCacheAdapter : ILoadAndCacheAdapter
	{
		public void LoadPackage(string packageName, System.Action<bool, string> OnLoaded)
		{
			bool result = false;
			string pName = string.Empty;

			// AsyncPackLoading

			OnLoaded(result, pName);
		}

		public void LoadPackageInstantly(string packageName, System.Action<bool, string> OnLoaded)
		{
			bool result = false;
			string pName = string.Empty;
			
			// AsyncPackLoading
			
			OnLoaded(result, pName);
		}
	}
}
