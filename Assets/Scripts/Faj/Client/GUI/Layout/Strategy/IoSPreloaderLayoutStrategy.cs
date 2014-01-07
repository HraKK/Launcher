using Uddle.GUI.Layout.Strategy.Interface;
using Faj.Client.GUI.Layout.Interface;
using UnityEngine;
using Uddle.GUI.Layout.Element;

namespace Faj.Client.GUI.Layout.Strategy
{
	class IoSPreloaderLayoutStrategy : ILayoutStrategy
	{
        IPreloaderLayout preloaderLayout;
        Texture2D logo;

        public IoSPreloaderLayoutStrategy(IPreloaderLayout preloaderLayout)
        {
            this.preloaderLayout = preloaderLayout;
        }

        public void DoInitializeStrategy()
        {
            logo = Resources.Load("Textures/Preloader/logo") as Texture2D;
        }

        public void DoStrategy()
        {
            var logoElement = new StaticImageElement(logo);
            logoElement.SetPosition(0, 0);
            preloaderLayout.AddElement(logoElement);
        }

        public void DoDisappearStrategy()
        {
        }
	}
}
