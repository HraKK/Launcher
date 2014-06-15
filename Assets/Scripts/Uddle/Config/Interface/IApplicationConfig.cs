using Uddle.Service.Interface;
namespace Uddle.Config.Interface
{
    enum ApplicationPlatform
    {
        WEB,
        IOS
    }

	interface IApplicationConfig : IService
	{
        ApplicationPlatform GetPlatform();
        string GetPackagesXmlPath();
        int GetRendererCount();
        int GetScreenWidth();
        int GetScreenHeight();
	}
}
