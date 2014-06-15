using Uddle.GUI.Layout.Element.ContainerElement;
using Uddle.Service;
using Uddle.Assets.Package.Service.Interface;
using UnityEngine;
using Uddle.GUI.Layout.Element.SpriteElement;
using Faj.Client.GUI.Layout.Element.Text;
using Faj.Client.Model.Player.Service.Interface;
using System.Collections.Generic;
using Uddle.Assets.Package.Dynamic.Interface;
using Faj.Client.Model.Player.Interface;
using Faj.Common.Static.Upgrade.Buy.Collection.Interface;
using Faj.Common.Static.Contract.Condition.Interface;
using Faj.Common.Static.Upgrade.Type.Collection.Interface;
using System;
using Faj.Common.Static.Perk.Collection.Interface;
using Faj.Common.Static.Perk.Collection.Item.Interface;

namespace Faj.Client.GUI.Layout.Element.Upgrade
{
    class UpgradeElement : ContainerElement
	{
        public event Action<string> OnBuyEvent;
        public event Action<string> OnPerkEvent;

        IDynamicPackage uiPackage;
        IUpgradeBuyCollection upgradeBuyCollection;
        IUpgradeTypeCollection upgradeTypeCollection;
        IPerkCollection perkCollection;

        string upgrade;
        PriceTextElement price;
        PriceTextElement priceShadow;
        MouseCollidableStaticImage buyButton;
        StaticImageElement buyInactiveButton;
        StaticImageElement arrow;
        DescriptionTextElement description;

        UpgradeTextElement text;
        UpgradeTextElement textShadow;

        Dictionary<int, StaticImageElement> actives = new Dictionary<int, StaticImageElement>();
        List<StaticImageElement> inactives = new List<StaticImageElement>();
        MouseCollidableStaticImage perk_1;
        MouseCollidableStaticImage perk_2;
        MouseCollidableStaticImage perk_3;

        IPlayerModel playerModel;

        List<StaticImageElement> perks = new List<StaticImageElement>();
        List<IPerkItem> perkItems = new List<IPerkItem>();

        public UpgradeElement(int x, int y)
        {
            var packageService = ServiceProvider.Instance.GetService<IPackageService>();
            uiPackage = packageService.GetPackage("ui");
            var staticContainerService = ServiceProvider.Instance.GetService<Uddle.Static.Service.Interface.IStaticContainerService>();
            upgradeBuyCollection = staticContainerService.GetStaticCollection<IUpgradeBuyCollection>("upgrades_buy_contract");
            upgradeTypeCollection = staticContainerService.GetStaticCollection<IUpgradeTypeCollection>("upgrades_type");
            perkCollection = staticContainerService.GetStaticCollection<IPerkCollection>("perks");

            var playerService = ServiceProvider.Instance.GetService<IPlayerService>();

            playerModel = playerService.GetPlayerModel();
            playerModel.OnUpdateEvent += new Action(OnUpdate);

            var upgradeInactiveSprite = uiPackage.Get<Sprite>("upgrade_inactive");
            var upgradeActiveSprite = uiPackage.Get<Sprite>("upgrade_active");

            for (var i = 1; i <= 10; i++)
            {
                var upgradeInactive = new StaticImageElement(upgradeInactiveSprite, 2);
                upgradeInactive.SetPosition(x + 70 + 26 * i, y - 95);
                elements.Add(upgradeInactive);
                inactives.Add(upgradeInactive);
            }

            textShadow = new UpgradeTextElement(upgrade);
            textShadow.SetColor(Color.black);
            textShadow.SetPosition(x + 66, y - 20);
            elements.Add(textShadow);

            text = new UpgradeTextElement(upgrade);
            text.SetColor(Color.white);
            text.SetPosition(x + 64, y  - 18);
            elements.Add(text);

            

            for (var i = 1; i <= 10; i++)
            {
                var upgradeActive = new StaticImageElement(upgradeActiveSprite, 3);
                upgradeActive.SetPosition(x + 71 + 26 * i, y - 95);
                elements.Add(upgradeActive);
                actives.Add(i, upgradeActive);
            }

            priceShadow = new PriceTextElement("");
            priceShadow.SetColor(Color.black);
            priceShadow.SetPosition(x + 98, y - 125);
            elements.Add(priceShadow);

            price = new PriceTextElement("");
            price.SetColor(Color.white);
            price.SetPosition(x + 94, y - 121);
            elements.Add(price);

            var buyButtonSprite = uiPackage.Get<Sprite>("buyit_active");
            buyButton = new MouseCollidableStaticImage(buyButtonSprite, 4);
            buyButton.GetMouseCollider().OnMouseUpEvent += new System.Action(OnBuy);
            buyButton.SetPosition(x + 214, y - 181);
            elements.Add(buyButton);

            var buyButtonInactiveSprite = uiPackage.Get<Sprite>("buyit_inactive");
            buyInactiveButton = new StaticImageElement(buyButtonInactiveSprite, 3);
            buyInactiveButton.SetPosition(x + 214, y - 181);
            elements.Add(buyInactiveButton);

            var arrowSprite = uiPackage.Get<Sprite>("arrow");
            arrow = new StaticImageElement(arrowSprite, 3);
            arrow.SetPosition(x + 82, y - 181);
            elements.Add(arrow);

            description = new DescriptionTextElement("");
            description.SetColor(Color.white);
            description.SetPosition(x + 74, y - 180);
            elements.Add(description);

            var perkSprite = uiPackage.Get<Sprite>("perk_button");
            perk_1 = new MouseCollidableStaticImage(perkSprite, 4);
            perk_1.GetMouseCollider().OnMouseUpEvent += new System.Action(OnPerk1);
            perk_1.SetPosition(x + 74, y - 400);
            elements.Add(perk_1);

            perk_2 = new MouseCollidableStaticImage(perkSprite, 4);
            perk_2.GetMouseCollider().OnMouseUpEvent += new System.Action(OnPerk2);
            perk_2.SetPosition(x + 74 + 110, y - 400);
            elements.Add(perk_2);

            perk_3 = new MouseCollidableStaticImage(perkSprite, 4);
            perk_3.GetMouseCollider().OnMouseUpEvent += new System.Action(OnPerk3);
            perk_3.SetPosition(x + 74 + 110 * 2, y - 400);
            elements.Add(perk_3);

            var perksCollection = perkCollection.GetPerksByType("power");
            int offsetX = 0;
            foreach (var perk in perksCollection)
            {
                var perkIconSprite = uiPackage.Get<Sprite>("skull_big");
                var perkIcon = new StaticImageElement(perkIconSprite, 5);
                perkIcon.SetPosition(x + 95 + offsetX, y - 384);
                perks.Add(perkIcon);
                elements.Add(perkIcon);

                offsetX = offsetX + 110;
            }
        }

        public void SetCollidable(bool isCollidable)
        {
            buyButton.SetCollidable(isCollidable);
            perk_1.SetCollidable(isCollidable);
            perk_2.SetCollidable(isCollidable);
            perk_3.SetCollidable(isCollidable);
        }

        public void SetHideText(bool isHidden)
        {
            textShadow.SetHidden(isHidden);
            text.SetHidden(isHidden);
            description.SetHidden(isHidden);
            priceShadow.SetHidden(isHidden);
            price.SetHidden(isHidden);
        }

        public void Show(string upgrade)
        {
            this.upgrade = upgrade;
            textShadow.SetHidden(false);
            text.SetHidden(false);
            
            text.SetUpgrade(upgrade);
            textShadow.SetUpgrade(upgrade);

            var upgrades = playerModel.GetUpgrades().GetUpgrades();
            int upgradeLevel = 0;
            if (!upgrades.TryGetValue(upgrade, out upgradeLevel))
            {
                upgradeLevel = 0;
            }

            foreach (var inactive in inactives)
            {
                inactive.SetHidden(false);
            }

            foreach (var activeKVP in actives)
            {
                if (activeKVP.Key > upgradeLevel)
                {
                    activeKVP.Value.SetHidden(true);
                    continue;
                }

                activeKVP.Value.SetHidden(false);
            }

            var upgradeType = upgradeTypeCollection.GetItem(upgrade);
            description.SetDescription(upgradeType.GetDescription());
            description.SetHidden(false);

            perk_1.SetHidden(false);
            perk_2.SetHidden(false);
            perk_3.SetHidden(false);

            var upgradeItem = upgradeBuyCollection.GetUpgradeBuyItem(upgrade, upgradeLevel + 1);
            if (null == upgradeItem)
            {
                arrow.SetHidden(true);
                price.SetHidden(true);
                priceShadow.SetHidden(true);
                buyButton.SetHidden(true);
                buyInactiveButton.SetHidden(true);
                return;
            }

            arrow.SetHidden(false);
            priceShadow.SetHidden(false);
            price.SetHidden(false);
            
            buyInactiveButton.SetHidden(false);

            bool isEnoughResources = false;
            int cost = 0;
            foreach (var pay in upgradeItem.GetPay())
            {
                var resourceCondition = pay.GetCondition() as IDictionaryIntCondition;
                var resources = resourceCondition.GetDictionary();
                resources.TryGetValue("money", out cost);
                isEnoughResources = playerModel.GetResources().IsEnoughResources(resources);
            }

            price.SetPrice(cost.ToString());
            priceShadow.SetPrice(cost.ToString());

            if (true == isEnoughResources)
            {
                buyButton.SetHidden(false);
                buyButton.SetEnabled(true);
            }
            else
            {
                buyButton.SetEnabled(false);
                buyButton.SetHidden(true);
                
            }

            perkItems = perkCollection.GetPerksByType("power");
            int i = 0;
            foreach (var perk in perkItems)
            {
                var perkIconSprite = uiPackage.Get<Sprite>("skull_big");
                var perkIcon = perks[i];
                perkIcon.ChangeSprite(perkIconSprite);
                perkIcon.SetEnabled(true);
                perkIcon.SetHidden(false);
                i++;
            }

        }

        void OnPerk1()
        {
            if (null == OnPerkEvent)
            {
                return;
            }

            OnPerkEvent(perkItems[0].GetId());
        }

        void OnPerk2()
        {
            if (null == OnPerkEvent)
            {
                return;
            }

            OnPerkEvent(perkItems[1].GetId());
        }

        void OnPerk3()
        {
            if (null == OnPerkEvent)
            {
                return;
            }

            OnPerkEvent(perkItems[2].GetId());
        }

        void OnBuy()
        {
            if (null == OnBuyEvent)
            {
                return;
            }

            OnBuyEvent(upgrade);
        }

        void OnUpdate()
        {
            if (null == upgrade)
            {
                return;
            }

            Show(upgrade);
        }

        public override void Disappear()
        {
            playerModel.OnUpdateEvent -= new Action(OnUpdate);

            base.Disappear();
        }
	}
}
