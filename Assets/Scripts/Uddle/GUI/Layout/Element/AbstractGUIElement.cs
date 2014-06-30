using Uddle.GUI.Layout.Element.Interface;
using System;
using UnityEngine;
using Uddle.Service;
using Uddle.GUI.Render.Pool.Service.Interface;
using Uddle.GUI.Render.Pool.Item.Interface;
using Uddle.Config.Interface;

namespace Uddle.GUI.Layout.Element
{
	abstract class AbstractGUIElement : IGUIElement
	{
        protected ISpriteItem spriteItem;
        protected SpriteRenderer spriteRenderer;

        protected bool isEnabled = true;
        protected bool isHidden = false;

        public event Action<IGUIElement> OnVisibleEvent;
        public event Action<IGUIElement> OnHideEvent;

        protected readonly ISpritePoolService spritePoolService;

        protected float x;
        protected float y;

        protected int screenWidth;
        protected int screenHeight;

        public AbstractGUIElement(int order = 0)
        {
            spritePoolService = ServiceProvider.Instance.GetService<ISpritePoolService>();
            var applicationConfig = ServiceProvider.Instance.GetService<IApplicationConfig>();

            screenWidth = applicationConfig.GetScreenWidth();
            screenHeight = applicationConfig.GetScreenHeight();

            spriteItem = spritePoolService.Spawn();
            spriteRenderer = spriteItem.GetSpriteRenderer();
            spriteRenderer.enabled = false;
            spriteRenderer.sortingOrder = order;
        }

        public virtual void SetPosition(float x, float y)
        {
            this.x = x;
            this.y = y;

            var position = spriteRenderer.transform.position;
            position.x = x - screenWidth / 2;
            position.y = y - screenHeight / 2;

            spriteRenderer.transform.position = position;
        }

        public virtual void SetEnabled(bool isEnabled)
        {
            this.isEnabled = isEnabled;
            Render();
        }

        public bool IsEnabled()
        {
            return isEnabled;
        }

        public virtual void SetHidden(bool isHidden)
        {
            this.isHidden = isHidden;
            Render();
        }

        public virtual void Render()
        {
            if (false == isHidden && true == isEnabled)
            {
                spriteRenderer.enabled = true;

                if (OnVisibleEvent != null)
                {
                    OnVisibleEvent(this);
                }
            }
            else
            {
                spriteRenderer.enabled = false;

                if (OnHideEvent != null)
                {
                    OnHideEvent(this);
                }
            }
        }

        public virtual void Disappear()
        {
            spriteRenderer.sprite = null;
            spritePoolService.Despawn(spriteItem);
        }
	}
}