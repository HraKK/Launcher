using UnityEngine;
using Uddle.Service;
using Uddle.GUI.Render.Pool.Service.Interface;
namespace Uddle.GUI.Layout.Element
{
	class StaticImageElement : AbstractGUIElement
	{
        Texture2D texture;

        public StaticImageElement(Texture2D texture) : base()
        {
            this.texture = texture;
            Sprite sprite = new Sprite();
            sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0, 0), 1.0f);
            spriteRenderer.sprite = sprite;            
        }

        public override void Disappear()
        {
        }       
	}
}
