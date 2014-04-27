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

        public MouseCollidableStaticImage(Texture2D texture)           
        {
            mouseCollidableSpritePoolService = ServiceProvider.Instance.GetService<IMouseCollidableSpritePoolService>();
            mouseCollidableSpriteItem = mouseCollidableSpritePoolService.Spawn();
            spriteRenderer = mouseCollidableSpriteItem.GetSpriteRenderer();
            spriteRenderer.enabled = false;
            mouseCollider = mouseCollidableSpriteItem.GetMouseCollider();
            
                        
            Sprite sprite = new Sprite();
            sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0, 0));
            spriteRenderer.sprite = sprite;

            var gameObject = mouseCollidableSpriteItem.GetGameObject();
            collider = gameObject.AddComponent<PolygonCollider2D>();
            collider.enabled = false;
        }

        public MouseCollidableStaticImage(Sprite sprite)
        {
            mouseCollidableSpritePoolService = ServiceProvider.Instance.GetService<IMouseCollidableSpritePoolService>();
            mouseCollidableSpriteItem = mouseCollidableSpritePoolService.Spawn();
            spriteRenderer = mouseCollidableSpriteItem.GetSpriteRenderer();
            spriteRenderer.enabled = false;
            mouseCollider = mouseCollidableSpriteItem.GetMouseCollider();

            spriteRenderer.sprite = sprite;

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
            else
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
    }
}
