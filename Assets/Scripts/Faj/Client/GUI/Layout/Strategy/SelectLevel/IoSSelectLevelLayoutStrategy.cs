using Uddle.GUI.Layout.Strategy.Interface;
using Faj.Client.GUI.Layout.Interface;
using UnityEngine;
using Uddle.GUI.Layout.Element.SpriteElement;
using Faj.Client.GUI.Layout.Element.Text;
using Uddle.Service;
using Uddle.Assets.Package.Service.Interface;
using Faj.Client.Model.Player.Service.Interface;
using Faj.Client.Model.Player;
using Faj.Common.Model.Static.Level.Collection.Item.Interface;
using Uddle.GUI.Layout.Element.TextElement;
using System.Collections.Generic;
using Faj.Client.Model.Player.Interface;

namespace Faj.Client.GUI.Layout.Strategy.SelectLevel
{
    class IoSSelectLevelLayoutStrategy : ILayoutStrategy
    {
        readonly IPackageService packageService;
        ISelectLevelLayout selectLevelLayout;
        MouseCollidableStaticImage selectMenu;
        ResourceTextElement text;
        List<TextElement> levelsText;
        MouseCollidableStaticImage startButton;
        IPlayerModel playerModel;

        public IoSSelectLevelLayoutStrategy(ISelectLevelLayout selectLevelLayout)
        {
            this.selectLevelLayout = selectLevelLayout;
            packageService = ServiceProvider.Instance.GetService<IPackageService>();
            var playerService = ServiceProvider.Instance.GetService<IPlayerService>();
            playerModel = playerService.GetPlayerModel();
        }

        public void DoInitializeStrategy()
        {
            var uiPackage = packageService.GetPackage("ui");
            var selectMenuSprite = uiPackage.Get<Sprite>("intro_atlas_1");
            selectMenu = new MouseCollidableStaticImage(selectMenuSprite);
            selectMenu.SetPosition(300, 0);

            var openedLevels = selectLevelLayout.GetOpenedLevels();
            levelsText = new List<TextElement>();
            var levels = selectLevelLayout.GetLevels();
            int positionX = 200;
            foreach (var levelKVP in levels.GetItems())
            {
                var levelItem = levelKVP.Value;

                
                
                var levelText = new TextElement(levelItem.GetId());
                if (!openedLevels.ContainsKey(levelItem.GetId()))
                {
                    levelText.SetColor(Color.gray);
                }
                else
                {
                    levelText.SetColor(Color.blue);
                }
                
                levelText.SetFont("comic");
                levelText.SetSize(40);
                levelText.SetPosition(positionX, 300);
                levelsText.Add(levelText);
                positionX += 200;
            }


            text = new ResourceTextElement("money");
            text.SetColor(Color.red);
            text.SetFont("comic");
            text.SetSize(40);
            text.SetPosition(400, 300);

            var startButtonSprite = uiPackage.Get<Sprite>("start_button");
            startButton = new MouseCollidableStaticImage(startButtonSprite, 2);
            startButton.SetPosition(742, 36);
            startButton.GetMouseCollider().OnMouseUpEvent += new System.Action(OnUP);
        }

        public void DoStrategy()
        {
            selectLevelLayout.AddElement(selectMenu);
            selectLevelLayout.AddElement(startButton);

            foreach (var levelText in levelsText)
            {
                selectLevelLayout.AddElement(levelText);
            }

            
           
        }

        public void DoDisappearStrategy()
        {
            selectMenu.GetMouseCollider().OnMouseUpEvent -= new System.Action(OnUP);
        }

        void OnUP()
        {
            //var routerService = ServiceProvider.Instance.GetService<Faj.Server.Router.Service.Interface.IServerRouterService>();
            


            


            //var idContent = new Faj.Common.Message.Content.IdContent(playerModel.GetId());
            //var message = new Uddle.Message.SimpleMessage("player", "cheat", idContent);
            //routerService.Route(message);

            playerModel.ChangeLocation(LocationEnum.Upgrade);
        }
    }
}