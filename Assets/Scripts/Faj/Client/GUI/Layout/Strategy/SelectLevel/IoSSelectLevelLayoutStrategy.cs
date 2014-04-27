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

namespace Faj.Client.GUI.Layout.Strategy.SelectLevel
{
    class IoSSelectLevelLayoutStrategy : ILayoutStrategy
    {
        readonly IPackageService packageService;
        ISelectLevelLayout selectLevelLayout;
        MouseCollidableStaticImage selectMenu;
        ResourceTextElement text;
        List<TextElement> levelsText;

        public IoSSelectLevelLayoutStrategy(ISelectLevelLayout selectLevelLayout)
        {
            this.selectLevelLayout = selectLevelLayout;
            packageService = ServiceProvider.Instance.GetService<IPackageService>();
            
        }

        public void DoInitializeStrategy()
        {
            var package = packageService.GetPackage("prefab_ui");
            var selectMenuSprite = package.Get<Sprite>("intro_atlas_1");
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
            text.SetPosition(200, 100);
        }

        public void DoStrategy()
        {
            selectMenu.GetMouseCollider().OnMouseUpEvent += new System.Action(OnUP);
            selectLevelLayout.AddElement(selectMenu);
            selectLevelLayout.AddElement(text);

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
            UnityEngine.Debug.Log("ddd");
            var playerService = ServiceProvider.Instance.GetService<IPlayerService>();
            var playerModel = playerService.GetPlayerModel();
            var resources = playerModel.GetResources().GetResources();
            var res = new System.Collections.Generic.Dictionary<string, int>();
            res.Add("money", 5);
            playerModel.ChangeLocation(LocationEnum.Upgrade);
            playerModel.GetResources().AwardResources(res);
        }
    }
}