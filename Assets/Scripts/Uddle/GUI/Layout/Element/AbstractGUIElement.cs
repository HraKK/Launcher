using Uddle.GUI.Layout.Element.Interface;
using System;
using UnityEngine;
using Uddle.Service;
using Uddle.GUI.Render.Pool.Service.Interface;

namespace Uddle.GUI.Layout.Element
{
	abstract class AbstractGUIElement : IGUIElement
	{
        protected SpriteRenderer spriteRenderer;
        
        bool isEnabled = false;
        bool isHidden = false;

        public event Action<IGUIElement> OnVisibleEvent;
        public event Action<IGUIElement> OnHideEvent;

        public AbstractGUIElement()
        {
            spriteRenderer = ServiceProvider.Instance.GetService<ISpriteRendererPoolService>().Spawn();
            UnityEngine.Debug.Log(spriteRenderer);
        }

        public void SetPosition(int x, int y)
        {
            var position = spriteRenderer.transform.position;
            position.x = x - Screen.width * 0.5f;
            position.y = y - Screen.height * 0.5f;

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

        void Render()
        {
            

            if (false == isHidden && true == isEnabled)
            {
                spriteRenderer.enabled = true;
            }
            else
            {
                spriteRenderer.enabled = false;
            }
        }

        public abstract void Disappear();
	}
}