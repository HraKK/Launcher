using UnityEngine;
using Uddle.Config.Interface;

namespace Uddle.Config
{
	class ApplicationConfig : IApplicationConfig
	{
        ApplicationPlatform platform;

        public ApplicationConfig()
        {
            SetUpPlatform();
        }

        public ApplicationPlatform GetPlatform()
        {
            return platform;
        }

        void SetUpPlatform()
        {
            #if UNITY_IPHONE
				platform = ApplicationPlatform.IOS;
            #endif
            #if UNITY_WEBPLAYER
                platform = ApplicationPlatform.WEB;
            #endif
                platform = ApplicationPlatform.IOS;
        }

        public string GetPackagesXmlPath()
        {
            return "file:///C://packages.xml";
        }

        public int GetRendererCount()
        {
            return 30;
        }
	}
}
