using Uddle.GUI.Render.Pool.Item.Interface;
using UnityEngine;
using Uddle.GUI.Collider.Interface;

namespace Uddle.GUI.Render.Pool.Item
{
    class MouseCollidableSpriteItem : SpriteItem, IMouseCollidableSpriteItem
	{
        readonly IMouseCollider mouseCollider;

        public MouseCollidableSpriteItem(GameObject gameObject, SpriteRenderer spriteRenderer, IMouseCollider mouseCollider)
            : base(gameObject, spriteRenderer)
        {
            this.mouseCollider = mouseCollider;
        }

        public IMouseCollider GetMouseCollider()
        {
            return mouseCollider;
        }
	}
}
