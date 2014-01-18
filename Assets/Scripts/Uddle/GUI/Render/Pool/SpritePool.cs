using UnityEngine;
using Uddle.GUI.Render.Pool.Item;
using Uddle.GUI.Render.Pool.Item.Interface;
using Uddle.GUI.Render.Pool.Interface;

namespace Uddle.GUI.Render.Pool
{
    class SpritePool : AbstractPool<ISpriteItem>, ISpritePool
	{
        public SpritePool(int rendererCount)
            : base(rendererCount)
        {
        }

        protected override void ResetItem(ISpriteItem spriteItem)
        {
            spriteItem.GetSpriteRenderer().enabled = false;
        }

        protected override ISpriteItem SetUpItem(GameObject poolObject)
        {
            poolObject.name = "SpriteRenderer " + rendererCount;
            poolObject.transform.parent = spawnPool.transform;
            var spriteRenderer = poolObject.AddComponent<SpriteRenderer>() as SpriteRenderer;
            return new SpriteItem(poolObject, spriteRenderer);
        }
	}
}
