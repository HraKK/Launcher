using Uddle.GUI.Layout.Strategy.Interface;
using Faj.Client.GUI.Layout.Interface;
using UnityEngine;
using Uddle.GUI.Layout.Element.SpriteElement;
using Faj.Client.GUI.Layout.Element.Progress;

namespace Faj.Client.GUI.Layout.Strategy.Preloader
{
	class IoSPreloaderLayoutStrategy : ILayoutStrategy
	{
        IPreloaderLayout preloaderLayout;
        Sprite[] atlas;

        public IoSPreloaderLayoutStrategy(IPreloaderLayout preloaderLayout)
        {
            this.preloaderLayout = preloaderLayout;
        }

        public void DoInitializeStrategy()
        {
            atlas = Resources.LoadAll<Sprite>("Textures/Preloader/preloader_atlas");
        }

        public void DoStrategy()
        {

            var logoElement1 = new StaticImageElement(atlas[0]);
            logoElement1.SetPosition(100, 0);
            preloaderLayout.AddElement(logoElement1);

            var porgress = new PreloaderProgressElement(atlas[1], preloaderLayout.GetPreloaderModel());
            preloaderLayout.AddElement(porgress);
        }

        public void DoDisappearStrategy()
        {
            for (var i = 0; i < atlas.Length; i++)
            {
                Resources.UnloadAsset(atlas[i]);
            }

            atlas = null;
        }
	}
}