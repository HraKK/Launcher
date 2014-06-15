using Uddle.Service;
using Uddle.Assets.Package.Service.Interface;
using Uddle.GUI.Layout.Strategy.Interface;
using UnityEngine;
using Uddle.GUI.Layout.Element.SpriteElement;
using System.Collections.Generic;
using Uddle.GUI.Layout.Element.AnimationElement;
using Uddle.Dependency.Interface;
using Faj.Client.GUI.Layout.Interface;

namespace Faj.Client.GUI.Layout.Strategy.Intro
{
    class IoSIntroLayoutStrategy : ILayoutStrategy
    {
        readonly IPackageService packageService;
        IIntroLayout introLayout;
        AnimationElement introLogo;

        public IoSIntroLayoutStrategy(IIntroLayout introLayout)
        {
            this.introLayout = introLayout;
            packageService = ServiceProvider.Instance.GetService<IPackageService>();
        }

        public void DoInitializeStrategy()
        {
            var package = packageService.GetPackage("prefab_ui");
            Sprite[] intro = new Sprite[2];
            intro[0] = package.Get<Sprite>("intro_atlas_0");
            intro[1] = package.Get<Sprite>("intro_atlas_1");
            introLogo = new AnimationElement(intro);
            introLogo.SetLoop(false);
            introLogo.OnReleaseEvent += new System.Action<IDependency>(OnRelease);
        }

        protected void OnRelease(IDependency dependency)
        {
            introLayout.Release();
        }


        public void DoStrategy()
        {
            introLayout.AddElement(introLogo);
            introLogo.Play();
            UnityEngine.Debug.Log("WOOOOT");
        }

        public void DoDisappearStrategy()
        {
        }
    }
}