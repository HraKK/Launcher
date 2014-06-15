using Uddle.GUI.Layout.Element.ContainerElement;
using Uddle.GUI.Layout.Element.SpriteElement;
using System;
using Uddle.Service;
using Uddle.Assets.Package.Service.Interface;
using UnityEngine;

namespace Faj.Client.GUI.Layout.Element.UpgradeButton
{
	class UpgradeButtonElement : ContainerElement
	{
        ScaleImageElement upgradeActive;
        string upgrade;
        public event Action<UpgradeButtonElement> OnUpgradeActiveEvent;
        MouseCollidableStaticImage upgradeButton;

        public UpgradeButtonElement(string upgrade, int x, int y)
        {
            this.upgrade = upgrade;
            var packageService = ServiceProvider.Instance.GetService<IPackageService>();
            var uiPackage = packageService.GetPackage("ui");
            var upgradeButtonSprite = uiPackage.Get<Sprite>("upgrade_button");
            upgradeButton = new MouseCollidableStaticImage(upgradeButtonSprite, 3);
            upgradeButton.GetMouseCollider().OnMouseUpEvent += new System.Action(OnMouseUp);
            upgradeButton.SetPosition(x, y);
            elements.Add(upgradeButton);

            var iconSprite = uiPackage.Get<Sprite>("skull_small");
            var icon = new StaticImageElement(iconSprite, 4);
            icon.SetPosition(x + 16, y + 24);
            elements.Add(icon);





            var upgradeActiveButtonSprite = uiPackage.Get<Sprite>("upgrade_button_active");
            upgradeActive = new ScaleImageElement(upgradeActiveButtonSprite, 2);
            upgradeActive.SetPosition(x + 67, y + 70);

            elements.Add(upgradeActive);
        }

        public void SetCollidable(bool isCollidable)
        {
            upgradeButton.SetCollidable(isCollidable);
        }

        void OnMouseUp()
        {
            if (null != OnUpgradeActiveEvent)
            {
                OnUpgradeActiveEvent(this);
            }

            upgradeActive.Scaling(1);
        }

        public void SetInactive()
        {
            upgradeActive.SetScale(0);
        }

        public string GetUpgrade()
        {
            return upgrade;
        }
	}
}
