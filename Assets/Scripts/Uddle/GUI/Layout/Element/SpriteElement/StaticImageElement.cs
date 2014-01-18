using UnityEngine;
using Uddle.Service;
using Uddle.GUI.Render.Pool.Service.Interface;
using Uddle.Observer.Interface;

namespace Uddle.GUI.Layout.Element.SpriteElement
{
	class StaticImageElement : AbstractGUIElement
	{
        Texture2D texture;

        public StaticImageElement(Texture2D texture) : base()
        {
            this.texture = texture;
            Sprite sprite = new Sprite();
            sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0,0));
            spriteRenderer.sprite = sprite;
        }

        public StaticImageElement(Sprite sprite)
            : base()
        {
            spriteRenderer.sprite = sprite;
        }
	}
}
