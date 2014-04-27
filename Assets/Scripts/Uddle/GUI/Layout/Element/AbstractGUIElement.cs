using Uddle.GUI.Layout.Element.Interface;
using System;
using UnityEngine;
using Uddle.Service;
using Uddle.GUI.Render.Pool.Service.Interface;
using Uddle.GUI.Render.Pool.Item.Interface;

namespace Uddle.GUI.Layout.Element
{
	abstract class AbstractGUIElement : IGUIElement
	{
        protected ISpriteItem spriteItem;
        protected SpriteRenderer spriteRenderer;

        protected bool isEnabled = false;
        protected bool isHidden = false;

        public event Action<IGUIElement> OnVisibleEvent;
        public event Action<IGUIElement> OnHideEvent;

        protected readonly ISpritePoolService spritePoolService;

        protected float x;
        protected float y;

        public AbstractGUIElement()
        {
            spritePoolService = ServiceProvider.Instance.GetService<ISpritePoolService>();
            spriteItem = spritePoolService.Spawn();
            spriteRenderer = spriteItem.GetSpriteRenderer();
            spriteRenderer.enabled = false;

        }

        public void SetPosition(float x, float y)
        {
            this.x = x;
            this.y = y;

            var position = spriteRenderer.transform.position;

            position.x = x * 0.01f - Screen.width * 0.005f;
            position.y = y * 0.01f - Screen.height * 0.005f;

            spriteRenderer.transform.position = position;
        }

        public void SetEnabled(bool isEnabled)
        {
            this.isEnabled = isEnabled;
            Render();
        }

        public bool IsEnabled()
        {
            return isEnabled;
        }

        public void SetHidden(bool isHidden)
        {
            this.isHidden = isHidden;
            Render();
        }

        protected virtual void Render()
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