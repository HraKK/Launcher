using Uddle.GUI.Layout.Element.ContainerElement;
using Uddle.Service;
using Uddle.Assets.Package.Service.Interface;
using Faj.Common.Static.Perk.Buy.Collection.Interface;
using Faj.Common.Static.Perk.Collection.Interface;
using Faj.Client.Model.Player.Service.Interface;
using Faj.Client.Model.Player.Interface;
using System;
using UnityEngine;
using Uddle.GUI.Layout.Element.SpriteElement;
using Faj.Client.GUI.Layout.Element.Text;
using Uddle.Assets.Package.Dynamic.Interface;
using Faj.Common.Static.Contract.Condition.Interface;

namespace Faj.Client.GUI.Layout.Element.Perk
{
    class PerkElement : ContainerElement
	{
        public event System.Action OnCancelEvent;
        public event Action<string> OnBuyEvent;

        IDynamicPackage uiPackage;

        IPlayerModel playerModel;

        IPerkBuyCollection perkBuyCollection;
        IPerkCollection perkCollection;

        string perk;

        StaticImageElement popup;
        StaticImageElement resourceIcon;
        StaticImageElement arrow;

        UpgradeTextElement text;
        UpgradeTextElement textShadow;

        PerkTextElement description;

        PriceTextElement price;
        PriceTextElement priceShadow;

        MouseCollidableStaticImage cancelButton;

        MouseCollidableStaticImage buyButton;
        StaticImageElement buyInactiveButton;

        public PerkElement(int x, int y)
        {
            var packageService = ServiceProvider.Instance.GetService<IPackageService>();
            uiPackage = packageService.GetPackage("ui");
            var staticContainerService = ServiceProvider.Instance.GetService<Uddle.Static.Service.Interface.IStaticContainerService>();
            perkBuyCollection = staticContainerService.GetStaticCollection<IPerkBuyCollection>("perks_buy_contract");
            perkCollection = staticContainerService.GetStaticCollection<IPerkCollection>("perks");

            var playerService = ServiceProvider.Instance.GetService<IPlayerService>();
            playerModel = playerService.GetPlayerModel();
            playerModel.OnUpdateEvent += new Action(OnUpdate);

            var popupSprite = uiPackage.Get<Sprite>("popup");
            popup = new StaticImageElement(popupSprite, 10);
            popup.SetPosition(x, y);
            elements.Add(popup);

            textShadow = new UpgradeTextElement(perk);
            textShadow.SetColor(Color.black);
            textShadow.SetPosition(x + 376, y + 467);
            elements.Add(textShadow);

            text = new UpgradeTextElement(perk);
            text.SetColor(Color.white);
            text.SetPosition(x + 372, y + 470);
            elements.Add(text);

            description = new PerkTextElement("");
            description.SetColor(Color.black);
            description.SetPosition(x + 362, y + 430);
            elements.Add(description);

            var cancelSprite = uiPackage.Get<Sprite>("cancel_button");
            cancelButton = new MouseCollidableStaticImage(cancelSprite, 11);
            cancelButton.GetMouseCollider().OnMouseUpEvent += new System.Action(OnCancel);
            cancelButton.SetPosition(x + 748, y + 494);
            elements.Add(cancelButton);

            var resourceIconSprite = uiPackage.Get<Sprite>("skull_big");
            resourceIcon = new StaticImageElement(resourceIconSprite, 11);
            resourceIcon.SetPosition(x + 410, y + 50);
            elements.Add(resourceIcon);

            price = new PriceTextElement("0");
            price.SetColor(Color.white);
            price.SetPosition(x + 450, y + 84);
            elements.Add(price);

            priceShadow = new PriceTextElement("0");
            priceShadow.SetColor(Color.black);
            priceShadow.SetPosition(x + 452, y + 82);
            elements.Add(priceShadow);

            var arrowIconSprite = uiPackage.Get<Sprite>("arrow");
            arrow = new StaticImageElement(arrowIconSprite, 11);
            arrow.SetPosition(x + 405, y + 30);
            elements.Add(arrow);

            var buyButtonSprite = uiPackage.Get<Sprite>("buyit_active");
            buyButton = new MouseCollidableStaticImage(buyButtonSprite, 12);
            buyButton.GetMouseCollider().OnMouseUpEvent += new System.Action(OnBuy);
            buyButton.SetPosition(x + 534, y + 34);
            elements.Add(buyButton);

            var buyButtonInactiveSprite = uiPackage.Get<Sprite>("buyit_inactive");
            buyInactiveButton = new StaticImageElement(buyButtonInactiveSprite, 11);
            buyInactiveButton.SetPosition(x + 534, y + 34);
            elements.Add(buyInactiveButton);

        }

        void OnBuy()
        {
            if (null == OnBuyEvent)
            {
                return;
            }

            OnBuyEvent(perk);

            OnCancel();
        }

        void OnCancel()
        {
            if (null == OnCancelEvent)
            {
                return;
            }

            OnCancelEvent();
        }

        public void Show(string perk)
        {
            this.perk = perk;

            popup.SetEnabled(true);
            popup.SetHidden(false);

            cancelButton.SetHidden(false);

            

            UnityEngine.Debug.Log(perk);

            text.SetUpgrade("Posion");
            textShadow.SetUpgrade("Posion");


            

            textShadow.SetEnabled(true);
            textShadow.SetHidden(false);
            text.SetEnabled(true);
            text.SetHidden(false);

            description.SetDescription("На рисунке 4 показано применение градиента к сложной форме, а нам надо управлять градиентом на всей фигуре. Кнопка Unite в палитре Pathfinder.");
            description.SetEnabled(true);
            description.SetHidden(false);

            cancelButton.SetHidden(false);
            cancelButton.SetEnabled(true);

            if (true == playerModel.GetPerks().IsPerk(perk))
            {
                return;
            }

            var perkBuyItem = perkBuyCollection.GetItem(perk);
            var pay = perkBuyItem.GetPay();
            foreach (var contractModule in pay)
            {
                UnityEngine.Debug.Log(contractModule);
                var condition = contractModule.GetCondition() as IDictionaryIntCondition;
                foreach (var resourceKVP in condition.GetDictionary())
                {
                    var resource = resourceKVP.Key;
                    var cost = resourceKVP.Value;
                    UnityEngine.Debug.Log(resource);
                    UnityEngine.Debug.Log(cost);
                    var resourceIconSprite = uiPackage.Get<Sprite>( resource + "_big");
                    resourceIcon.ChangeSprite(resourceIconSprite);

                    price.SetPrice(cost.ToString());
                    priceShadow.SetPrice(cost.ToString());
                }
            }

            resourceIcon.SetEnabled(true);
            resourceIcon.SetHidden(false);

            priceShadow.SetEnabled(true);
            priceShadow.SetHidden(false);
            price.SetEnabled(true);
            price.SetHidden(false);

            arrow.SetEnabled(true);
            arrow.SetHidden(false);

            buyButton.SetEnabled(true);
            buyButton.SetHidden(false);

            buyInactiveButton.SetEnabled(true);
            buyInactiveButton.SetHidden(false);
        }



        void OnUpdate()
        {
            if (null == perk)
            {
                return;
            }

            Show(perk);
        }
	}
}
