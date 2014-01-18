using UnityEngine;
using Uddle.GUI.Render.Pool.Item.Interface;
namespace Uddle.GUI.Render.Pool.Item
{
    class SpriteItem : AbstractItem, ISpriteItem
	{
        readonly SpriteRenderer spriteRenderer;

        public SpriteItem(GameObject gameObject, SpriteRenderer spriteRenderer) : base(gameObject)
        {
            this.spriteRenderer = spriteRenderer;
        }

        public SpriteRenderer GetSpriteRenderer()
        {
            return spriteRenderer;
        }
	}
}
