using UnityEngine;
using Uddle.Config.Interface;

namespace Uddle.Config
{
	class ApplicationConfig : IApplicationConfig
	{
        ApplicationPlatform platform;
        int screenWidth;
        int screenHeight;

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
                screenWidth = 1136;
                screenHeight = 640;
        }

        public string GetPackagesXmlPath()
        {
            return "file:///C://packages.xml";
        }

        public int GetScreenWidth()
        {
            return screenWidth;
        }

        public int GetScreenHeight()
        {
            return screenHeight;
        }

        public int GetRendererCount()
        {
            return 30;
        }
	}
}
