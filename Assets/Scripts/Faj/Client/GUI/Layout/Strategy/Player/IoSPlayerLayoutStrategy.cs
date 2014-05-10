using Faj.Client.GUI.Layout.Interface;
using Uddle.Assets.Package.Service.Interface;
using Uddle.Service;
using Uddle.GUI.Layout.Strategy.Interface;
using UnityEngine;
using Uddle.GUI.Layout.Element.SpriteElement;
using Faj.Client.Model.Player.Service.Interface;
using Faj.Client.GUI.Layout.Element.Text;
using Faj.Client.Model.Player;

namespace Faj.Client.GUI.Layout.Strategy.Intro
{
    class IoSPlayerLayoutStrategy : ILayoutStrategy
    {
        readonly IPackageService packageService;
        IPlayerLayout playerLayout;
        MouseCollidableStaticImage selectMenu;
        ResourceTextElement text;

        public IoSPlayerLayoutStrategy(IPlayerLayout playerLayout)
        {
            this.playerLayout = playerLayout;
            packageService = ServiceProvider.Instance.GetService<IPackageService>();
        }

        public void DoInitializeStrategy()
        {
            
            
            var package = packageService.GetPackage("prefab_ui");
            var selectMenuSprite = package.Get<Sprite>("intro_atlas_0");
            selectMenu = new MouseCollidableStaticImage(selectMenuSprite);
            selectMenu.SetPosition(100, 0);
            


            text = new ResourceTextElement("skull");
            text.SetColor(Color.red);
            text.SetFont("comic");
            text.SetSize(40);
            
            
            
        
        }

        void OnUP()
        {
            var playerService = ServiceProvider.Instance.GetService<IPlayerService>();
            var playerModel = playerService.GetPlayerModel();

            playerModel.ChangeLocation(LocationEnum.SelectLevel);
            playerModel.Save();            
        }

        public void DoStrategy()
        {
            playerLayout.AddElement(selectMenu);
            playerLayout.AddElement(text);
            selectMenu.GetMouseCollider().OnMouseUpEvent += new System.Action(OnUP);
        }

        public void DoDisappearStrategy()
        {
        }
    }
}