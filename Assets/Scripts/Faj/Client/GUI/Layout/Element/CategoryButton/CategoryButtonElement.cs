using Uddle.GUI.Layout.Element.ContainerElement;
using System.Collections.Generic;
using Uddle.GUI.Layout.Element.SpriteElement;
using System;
using Uddle.Service;
using Uddle.Assets.Package.Service.Interface;
using UnityEngine;
using Faj.Client.GUI.Layout.Element.Text;

namespace Faj.Client.GUI.Layout.Element.Button
{
    class CategoryButtonElement : ContainerElement
	{
        MouseCollidableStaticImage categoryButton;
        ScaleImageElement categoryActive;
        string category;
        public event Action<CategoryButtonElement> OnCategoryActiveEvent;

        public CategoryButtonElement(string category, int x, int y)
        {
            this.category = category;
            var packageService = ServiceProvider.Instance.GetService<IPackageService>();
            var uiPackage = packageService.GetPackage("ui");
            var categoryButtonSprite = uiPackage.Get<Sprite>("category_button");
            categoryButton = new MouseCollidableStaticImage(categoryButtonSprite, 3);
            categoryButton.GetMouseCollider().OnMouseUpEvent +=new System.Action(OnMouseUp);
            categoryButton.SetPosition(x, y);
            elements.Add(categoryButton);

            var iconSprite = uiPackage.Get<Sprite>("skull_small");
            var icon = new StaticImageElement(iconSprite, 4);
            icon.SetPosition(x + 16, y + 24);
            elements.Add(icon);

            
            var categoryActiveButtonSprite = uiPackage.Get<Sprite>("category_button_active");
            categoryActive = new ScaleImageElement(categoryActiveButtonSprite, 2);
            categoryActive.SetPosition(x + 80, y + 45);
            
            elements.Add(categoryActive);
        }

        public void SetCollidable(bool isCollidable)
        {
            categoryButton.SetCollidable(isCollidable);
        }

        public string GetCategory()
        {
            return category;
        }

        void OnMouseUp()
        {
            if (null != OnCategoryActiveEvent)
            {
                OnCategoryActiveEvent(this);
            }

            categoryActive.Scaling(1);
        }

        public void SetInactive()
        {
            categoryActive.SetScale(0);
        }

        public void SetActive()
        {
            categoryActive.SetScale(1);
        }
	}
}
