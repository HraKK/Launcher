using Uddle.Service;
using Uddle.Assets.Package.Service.Interface;
using Uddle.GUI.Layout.Strategy.Interface;
using UnityEngine;

namespace Faj.Client.GUI.Layout.Strategy.Intro
{
    class IoSIntroLayoutStrategy : ILayoutStrategy
    {
        readonly IPackageService packageService;
        Sprite[] atlas;

        public IoSIntroLayoutStrategy()
        {
            packageService = ServiceProvider.Instance.GetService<IPackageService>();
        }

        public void DoInitializeStrategy()
        {
            var package = packageService.GetPackage("prefab_ui");
            var tex2D  = package.GetBundle().Load("intro_atlas", typeof(Texture2D)) as Texture2D;
            var sp = package.GetBundle().Load("intro_atlas_0", typeof(Sprite)) as Sprite;
            UnityEngine.Debug.Log("ROOOOT");
            UnityEngine.Debug.Log(tex2D);
            UnityEngine.Debug.Log(sp);
            

            var d = package.GetBundle().LoadAll();
            for (var i = 0; i < d.Length; i++)
            {
                UnityEngine.Debug.Log(d[i]);
            }
            
        }

        public void DoStrategy()
        {
            UnityEngine.Debug.Log("WOOOOT");
            UnityEngine.Debug.Log(atlas);

        }

        public void DoDisappearStrategy()
        {

            atlas = null;
        }
    }
}