using UnityEngine;
using Uddle.GUI.Render.Pool.Item.Interface;
using Uddle.GUI.Collider;
using Uddle.GUI.Collider.Interface;
using Uddle.GUI.Render.Pool.Item;
using Uddle.GUI.Render.Pool.Interface;

namespace Uddle.GUI.Render.Pool
{
    class MouseCollidableSpritePool : AbstractPool<IMouseCollidableSpriteItem>, IMouseCollidableSpritePool
    {
        public MouseCollidableSpritePool(int rendererCount)
            : base(rendererCount)
        {
        }

        protected override void ResetItem(IMouseCollidableSpriteItem spriteItem)
        {
            spriteItem.GetSpriteRenderer().enabled = false;
            var collider = spriteItem.GetGameObject().collider2D;
            UnityEngine.Object.Destroy(collider);
        }

        protected override IMouseCollidableSpriteItem SetUpItem(GameObject poolObject)
        {
            var spriteRenderer = poolObject.AddComponent<SpriteRenderer>() as SpriteRenderer;
            var mouseCollider = poolObject.AddComponent<MouseCollider>() as IMouseCollider;
            return new MouseCollidableSpriteItem(poolObject, spriteRenderer, mouseCollider);
        }
    }
}
