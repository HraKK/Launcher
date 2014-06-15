using Faj.Client.GUI.Layout.Interface;
using Uddle.Assets.Package.Service.Interface;
using Uddle.Service;
using Uddle.GUI.Layout.Strategy.Interface;
using UnityEngine;
using Uddle.GUI.Layout.Element.SpriteElement;
using Faj.Client.Model.Player.Service.Interface;
using Faj.Client.GUI.Layout.Element.Text;
using Faj.Client.Model.Player;
using Uddle.Assets.Package.Dynamic.Interface;
using Faj.Client.GUI.Layout.Element.Button;
using Faj.Client.GUI.Layout.Element.UpgradeButton;
using System.Collections.Generic;
using Faj.Client.GUI.Layout.Element.Upgrade;
using Faj.Server.Router.Service.Interface;
using Faj.Client.Model.Player.Interface;
using Faj.Common.Message.Content;
using Faj.Client.GUI.Layout.Element.Perk;

namespace Faj.Client.GUI.Layout.Strategy.Intro
{
    class IoSPlayerLayoutStrategy : ILayoutStrategy
    {
        readonly IPackageService packageService;
        readonly IServerRouterService routerService;
        readonly IPlayerModel playerModel;

        IPlayerLayout playerLayout;
        StaticImageElement background0;
        StaticImageElement background1;
        StaticImageElement selectMenu;

        ResourceTextElement crystallCountTextShadow;
        ResourceTextElement crystallCountText;
        MouseCollidableStaticImage crystallButton;
        StaticImageElement crystallIcon;

        ResourceTextElement moneyCountTextShadow;
        ResourceTextElement moneyCountText;
        StaticImageElement moneyHolder;
        StaticImageElement moneyIcon;

        ResourceTextElement skullCountTextShadow;
        ResourceTextElement skullCountText;
        StaticImageElement skullHolder;
        StaticImageElement skullIcon;

        MouseCollidableStaticImage achievementsButton;

        CategoryButtonElement upgradeCategory;
        CategoryButtonElement mobCategory;
        CategoryButtonElement extraCategory;

        List<UpgradeButtonElement> upgrades = new List<UpgradeButtonElement>();
        List<UpgradeButtonElement> extras = new List<UpgradeButtonElement>();
        List<UpgradeButtonElement> mobs = new List<UpgradeButtonElement>();

        UpgradeButtonElement upgradeButtonActive;
        CategoryButtonElement categoryButtonActive;

        UpgradeElement upgrade;
        PerkElement perk;



        public IoSPlayerLayoutStrategy(IPlayerLayout playerLayout)
        {
            this.playerLayout = playerLayout;
            packageService = ServiceProvider.Instance.GetService<IPackageService>();
            routerService = ServiceProvider.Instance.GetService<IServerRouterService>();
            var playerService = ServiceProvider.Instance.GetService<IPlayerService>();
            playerModel = playerService.GetPlayerModel();
        }

        public void DoInitializeStrategy()
        {
            var uiPackage = packageService.GetPackage("ui");

            var backgound0Sprite = uiPackage.Get<Sprite>("background_0");
            var backgound1Sprite = uiPackage.Get<Sprite>("background_1");

            background0 = new StaticImageElement(backgound0Sprite);
            background0.SetPosition(0, 0);

            background1 = new StaticImageElement(backgound1Sprite, 1);
            background1.SetPosition(0, 70);

            var soundSprite = uiPackage.Get<Sprite>("sound");
            selectMenu = new StaticImageElement(soundSprite, 2);
            selectMenu.SetPosition(175, 532);
            
            //var package = packageService.GetPackage("prefab_ui");
            //var selectMenuSprite = package.Get<Sprite>("intro_atlas_0");
            //selectMenu = new MouseCollidableStaticImage(selectMenuSprite);
            //selectMenu.SetPosition(100, 0);

            var resourceButtonSprite = uiPackage.Get<Sprite>("resource_button");
            crystallButton = new MouseCollidableStaticImage(resourceButtonSprite, 2);
            crystallButton.SetPosition(318, 512);

            crystallCountText = new ResourceTextElement("crystall");            
            crystallCountText.SetColor(Color.white);
            crystallCountText.SetFont("comic");
            crystallCountText.SetSize(36);
            crystallCountText.SetPosition(372, 562);

            crystallCountTextShadow = new ResourceTextElement("crystall");
            crystallCountTextShadow.SetColor(Color.black);
            crystallCountTextShadow.SetFont("comic");
            crystallCountTextShadow.SetSize(36);
            crystallCountTextShadow.SetPosition(374, 560);

            var crystallSmallSprite = uiPackage.Get<Sprite>("skull_small");
            crystallIcon = new StaticImageElement(crystallSmallSprite, 3);
            crystallIcon.SetPosition(334, 536);

            var achievementsButtonSprite = uiPackage.Get<Sprite>("achievement_button");
            achievementsButton = new MouseCollidableStaticImage(achievementsButtonSprite, 2);
            achievementsButton.SetPosition(512, 490);

            
            moneyHolder = new StaticImageElement(resourceButtonSprite, 2);
            moneyHolder.SetPosition(830, 512);

            moneyCountText = new ResourceTextElement("money");
            moneyCountText.SetColor(Color.white);
            moneyCountText.SetFont("comic");
            moneyCountText.SetSize(36);
            moneyCountText.SetPosition(830 + 54, 562);

            moneyCountTextShadow = new ResourceTextElement("money");
            moneyCountTextShadow.SetColor(Color.black);
            moneyCountTextShadow.SetFont("comic");
            moneyCountTextShadow.SetSize(36);
            moneyCountTextShadow.SetPosition(830 + 54+2, 560);


            var moneySmallSprite = uiPackage.Get<Sprite>("skull_small");
            moneyIcon = new StaticImageElement(crystallSmallSprite, 3);
            moneyIcon.SetPosition(830 + 16, 536);

            var resourceHolderSprite = uiPackage.Get<Sprite>("resource_holder");
            skullHolder = new StaticImageElement(resourceHolderSprite, 2);
            skullHolder.SetPosition(636, 512);

            skullCountText = new ResourceTextElement("skull");
            skullCountText.SetColor(Color.white);
            skullCountText.SetFont("comic");
            skullCountText.SetSize(36);
            skullCountText.SetPosition(690 , 562);

            skullCountTextShadow = new ResourceTextElement("skull");
            skullCountTextShadow.SetColor(Color.black);
            skullCountTextShadow.SetFont("comic");
            skullCountTextShadow.SetSize(36);
            skullCountTextShadow.SetPosition(692, 560);

            var skullSmallSprite = uiPackage.Get<Sprite>("skull_small");
            skullIcon = new StaticImageElement(crystallSmallSprite, 3);
            skullIcon.SetPosition(652, 536);

            upgradeCategory = new CategoryButtonElement("upgrade", 142, 370);
            upgradeCategory.SetActive();
            categoryButtonActive = upgradeCategory;
            mobCategory = new CategoryButtonElement("mobs", 142 + 180, 370);
            extraCategory = new CategoryButtonElement("extra", 142 + 180 * 2, 370);
            upgradeCategory.OnCategoryActiveEvent += new System.Action<CategoryButtonElement>(OnCategoryActive);
            
            mobCategory.OnCategoryActiveEvent += new System.Action<CategoryButtonElement>(OnCategoryActive);
            extraCategory.OnCategoryActiveEvent += new System.Action<CategoryButtonElement>(OnCategoryActive);


            AddUpgrade("power", 162, 200);
            AddUpgrade("springs", 162 + 168, 200);
            AddUpgrade("oil", 162 + 168 * 2, 200);
            AddUpgrade("belt", 162, 44);
            AddUpgrade("cloak", 162 + 168, 44);
            AddUpgrade("machine", 162 + 168 * 2, 44);

            AddExtra("coffee", 162, 200);
            AddExtra("battery", 162 + 168, 200);

            AddMob("leprechaun", 162, 200);

            perk = new PerkElement(168, 60);
            perk.SetHidden(true);
            perk.SetEnabled(false);
            perk.OnCancelEvent += new System.Action(OnCancelPerk);
            perk.OnBuyEvent += new System.Action<string>(OnBuyPerk);

            upgrade = new UpgradeElement(600, 512);
            upgrade.OnBuyEvent += new System.Action<string>(OnBuy);
            upgrade.OnPerkEvent += new System.Action<string>(OnPerk);
            upgrade.SetHidden(true);
            upgrade.SetEnabled(false);

          

        }

        protected void AddUpgrade(string upgrade, int x, int y)
        {
            var upgradeElement = new UpgradeButtonElement(upgrade, x, y);
            upgradeElement.OnUpgradeActiveEvent += new System.Action<UpgradeButtonElement>(OnUpgradeActive);
            upgrades.Add(upgradeElement);
        }

        protected void AddExtra(string extra, int x, int y)
        {
            var extraElement = new UpgradeButtonElement(extra, x, y);
            extraElement.OnUpgradeActiveEvent += new System.Action<UpgradeButtonElement>(OnUpgradeActive);
            extraElement.SetHidden(true);
            extraElement.SetEnabled(false);
            extras.Add(extraElement);
        }

        protected void AddMob(string mob, int x, int y)
        {
            var mobElement = new UpgradeButtonElement(mob, x, y);
            mobElement.OnUpgradeActiveEvent += new System.Action<UpgradeButtonElement>(OnUpgradeActive);
            mobElement.SetHidden(true);
            mobElement.SetEnabled(false);
            mobs.Add(mobElement);
        }

        protected void OnUpgradeActive(UpgradeButtonElement upgradeButton)
        {
            if (null != upgradeButtonActive)
            {
                upgradeButtonActive.SetInactive();
            }

            upgradeButtonActive = upgradeButton;
            upgrade.Show(upgradeButton.GetUpgrade());
        }

        protected void OnCategoryActive(CategoryButtonElement categoryButton)
        {
            if (null != categoryButtonActive)
            {
                categoryButtonActive.SetInactive();
            }

            categoryButtonActive = categoryButton;

            switch (categoryButton.GetCategory())
            {
                case "upgrade":
                    foreach (var extra in extras)
                    {
                        extra.SetHidden(true);
                        extra.SetEnabled(false);
                    }
                    foreach (var mob in mobs)
                    {
                        mob.SetHidden(true);
                        mob.SetEnabled(false);
                    }
                    foreach (var upgrade in upgrades)
                    {
                        upgrade.SetHidden(false);
                        upgrade.SetEnabled(true);
                    }
                    break;
                case "mobs":
                    UnityEngine.Debug.Log("hidden");
                    foreach (var extra in extras)
                    {
                        extra.SetHidden(true);
                        extra.SetEnabled(false);
                    }
                    foreach (var mob in mobs)
                    {
                        mob.SetHidden(false);
                        mob.SetEnabled(true);
                    }
                    foreach (var upgrade in upgrades)
                    {
                        upgrade.SetHidden(true);
                        upgrade.SetEnabled(false);
                    }
                    break;
                case "extra":
                    foreach (var extra in extras)
                    {
                        extra.SetHidden(false);
                        extra.SetEnabled(true);
                    }
                    foreach (var mob in mobs)
                    {
                        mob.SetHidden(true);
                        mob.SetEnabled(false);
                    }
                    foreach (var upgrade in upgrades)
                    {
                        upgrade.SetHidden(true);
                        upgrade.SetEnabled(false);
                    }
                    break;
            }
        }

        void OnBuyPerk(string perk)
        {
            var stringContent = new StringContent(playerModel.GetId(), perk);
            var message = new Uddle.Message.SimpleMessage("player", "perk", stringContent);
            routerService.Route(message);
        }

        void SetCollidable(bool isCollidable)
        {
            foreach (var upgrade in upgrades)
            {
                upgrade.SetCollidable(isCollidable);
            }

            upgradeCategory.SetCollidable(isCollidable);
            mobCategory.SetCollidable(isCollidable);
            extraCategory.SetCollidable(isCollidable);

            this.upgrade.SetCollidable(isCollidable);
        }

        void OnBuy(string upgrade)
        {
            var stringContent = new StringContent(playerModel.GetId(), upgrade);
            var message = new Uddle.Message.SimpleMessage("player", "upgrade", stringContent);
            routerService.Route(message);
        }

        void OnPerk(string perkId)
        {
            SetCollidable(false);
            SetHideText(true);
            upgrade.SetHideText(true);            
            perk.Show(perkId);
        }

        void OnCancelPerk()
        {
            SetCollidable(true);
            SetHideText(false);
            upgrade.SetHideText(false);
            perk.SetEnabled(false);
            perk.SetHidden(true);

        }


        void OnUP()
        {


            //playerModel.ChangeLocation(LocationEnum.SelectLevel);
            playerModel.Save();            
        }

        public void SetHideText(bool isHidden)
        {
            crystallCountTextShadow.SetHidden(isHidden);
            crystallCountText.SetHidden(isHidden);

            skullCountTextShadow.SetHidden(isHidden);
            skullCountText.SetHidden(isHidden);

            moneyCountTextShadow.SetHidden(isHidden);
            moneyCountText.SetHidden(isHidden);
            

        }

        public void DoStrategy()
        {
            playerLayout.AddElement(selectMenu);
            playerLayout.AddElement(background0);
            playerLayout.AddElement(background1);
            playerLayout.AddElement(crystallButton);
            playerLayout.AddElement(crystallCountTextShadow);
            playerLayout.AddElement(crystallCountText);
            playerLayout.AddElement(crystallIcon);
            playerLayout.AddElement(achievementsButton);
            playerLayout.AddElement(moneyHolder);
            playerLayout.AddElement(moneyCountTextShadow);
            playerLayout.AddElement(moneyCountText);
            playerLayout.AddElement(moneyIcon);
            playerLayout.AddElement(skullHolder);
            playerLayout.AddElement(skullCountTextShadow);
            playerLayout.AddElement(skullCountText);
            playerLayout.AddElement(skullIcon);
            upgradeCategory.AddToLayout(playerLayout);
            perk.AddToLayout(playerLayout);
            mobCategory.AddToLayout(playerLayout);
            extraCategory.AddToLayout(playerLayout);
            foreach (var upg in upgrades)
            {
                upg.AddToLayout(playerLayout);
            }
            foreach (var mob in mobs)
            {
                mob.AddToLayout(playerLayout);
            }
            foreach (var extra in extras)
            {
                extra.AddToLayout(playerLayout);
            }



            upgrade.AddToLayout(playerLayout);
            //playerLayout.AddElement(text);
            //selectMenu.GetMouseCollider().OnMouseUpEvent += new System.Action(OnUP);
        }

        public void DoDisappearStrategy()
        {
        }
    }
}