using UnityEngine;
using Uddle.GUI.Render.Pool.Service.Interface;
using Uddle.Service;
using Uddle.GUI.Collider.Interface;
using Uddle.GUI.Render.Pool.Item.Interface;

namespace Uddle.GUI.Layout.Element.SpriteElement
{
    class MouseCollidableStaticImage : AbstractGUIElement
    {
        
        readonly IMouseCollider mouseCollider;
        readonly IMouseCollidableSpriteItem mouseCollidableSpriteItem;
        readonly PolygonCollider2D collider;
        readonly IMouseCollidableSpritePoolService mouseCollidableSpritePoolService;

        public MouseCollidableStaticImage(Sprite sprite, int order = 0)
        {
            mouseCollidableSpritePoolService = ServiceProvider.Instance.GetService<IMouseCollidableSpritePoolService>();
            mouseCollidableSpriteItem = mouseCollidableSpritePoolService.Spawn();
            spriteRenderer = mouseCollidableSpriteItem.GetSpriteRenderer();
            spriteRenderer.enabled = false;
            mouseCollider = mouseCollidableSpriteItem.GetMouseCollider();

            spriteRenderer.sprite = sprite;
            spriteRenderer.sortingOrder = order;

            var gameObject = mouseCollidableSpriteItem.GetGameObject();
            collider = gameObject.AddComponent<PolygonCollider2D>();
            collider.enabled = false;
        }

        protected override void Render()
        {
            if (false == isHidden && true == isEnabled)
            {
                collider.enabled = true;
            }
            else if(true == isHidden && false == isEnabled)
            {
                collider.enabled = false;
            }

            base.Render();
        }

        public IMouseCollider GetMouseCollider()
        {
            return mouseCollider;
        }

        public override void Disappear()
        {
            spriteRenderer.sprite = null;
            UnityEngine.Object.Destroy(collider);
            mouseCollidableSpritePoolService.Despawn(mouseCollidableSpriteItem);
        }

        public void SetCollidable(bool isCollidable)
        {
            collider.enabled = isCollidable;
        }
    }
}
