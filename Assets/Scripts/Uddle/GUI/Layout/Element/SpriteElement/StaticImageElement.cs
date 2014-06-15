using UnityEngine;
using Uddle.Service;
using Uddle.GUI.Render.Pool.Service.Interface;
using Uddle.Observer.Interface;

namespace Uddle.GUI.Layout.Element.SpriteElement
{
	class StaticImageElement : AbstractGUIElement
	{
        public StaticImageElement(Sprite sprite, int order = 0)
            : base(order)
        {
            spriteRenderer.sprite = sprite;            
        }

        public void ChangeSprite(Sprite sprite)
        {
            spriteRenderer.sprite = sprite;
        }
	}
}
