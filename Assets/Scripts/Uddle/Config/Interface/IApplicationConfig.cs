namespace Uddle.Config.Interface
{
    enum ApplicationPlatform
    {
        WEB,
        IOS
    }

	interface IApplicationConfig
	{
        ApplicationPlatform GetPlatform();
        string GetPackagesXmlPath();
	}
}
