using UnityEngine;
using Uddle.GUI.Render.Pool.Item.Interface;
using System.Collections.Generic;
using Uddle.GUI.Render.Pool.Interface;
namespace Uddle.GUI.Render.Pool
{
    abstract class AbstractPool<TPoolItem> : IPool<TPoolItem> where TPoolItem : IPoolItem
	{
        protected GameObject spawnPool;
        protected int rendererCount = 0;
        List<TPoolItem> idleRenderer = new List<TPoolItem>();
        List<TPoolItem> spawnedRenderer = new List<TPoolItem>();

        public AbstractPool(int rendererCount)
        {
            spawnPool = new GameObject();
            spawnPool.name = "RendererPool";
            for (var i = 0; i < rendererCount; i++)
            {
                IncreaseIdleRenderer();
            }
        }

        public TPoolItem Spawn()
        {
            TPoolItem SpriteItem;

            if (idleRenderer.Count < 1)
            {
                IncreaseIdleRenderer();
            }

            SpriteItem = idleRenderer[0];

            idleRenderer.Remove(SpriteItem);
            spawnedRenderer.Add(SpriteItem);

            return SpriteItem;
        }

        public void Despawn(TPoolItem spriteItem)
        {
            spawnedRenderer.Remove(spriteItem);

            ResetItem(spriteItem);


            idleRenderer.Add(spriteItem);
        }

        protected abstract void ResetItem(TPoolItem spriteItem);

        protected virtual void IncreaseIdleRenderer()
        {
            rendererCount++;
            var poolObject = new GameObject();
            poolObject.name = "Renderer " + rendererCount;
            poolObject.transform.parent = spawnPool.transform;

            var spriteItem = SetUpItem(poolObject);

            Despawn(spriteItem);
        }

        protected abstract TPoolItem SetUpItem(GameObject poolObject);
    }
}
