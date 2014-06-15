using UnityEngine;
using System;
using Uddle.Observer.Interface;

namespace Uddle.GUI.Layout.Element.SpriteElement
{
	class ScaleImageElement : StaticImageElement, IObserver
	{
        protected float scale;

        public ScaleImageElement(Sprite sprite, int order = 0)
            : base(sprite, order)
        {
        }

        public void SetScale(float scale)
        {
            this.scale = scale;
            spriteRenderer.transform.localScale = new Vector3(scale, scale, 1);
        }

        public void Scaling(float scale)
        {
            this.scale = scale;
        }

        public void Notify()
        {
            if (spriteRenderer.transform.localScale.x != scale)
            {
                if (Math.Abs(spriteRenderer.transform.localScale.x - scale) <= 0.05)
                {
                    SetScale(scale);
                }
                else
                {
                    var localScale = spriteRenderer.transform.localScale;
                    localScale.x = Mathf.Lerp(spriteRenderer.transform.localScale.x, scale, 10 * UnityEngine.Time.deltaTime);
                    localScale.y = localScale.x;
                    spriteRenderer.transform.localScale = localScale;
                }
            }
        }
	}
}
