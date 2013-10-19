namespace Application.Manager.Assets.Interface
{
	public interface ILoadAndCacheAdapter
	{
		void LoadPackage(string packageName, System.Action<bool, string> OnLoaded);
		void LoadPackageInstantly(string packageName, System.Action<bool, string> OnLoaded);
	}
}
