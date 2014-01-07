using UnityEngine;
using System.Collections.Generic;
using Uddle.GUI.Render.Pool.Interface;

namespace Uddle.GUI.Render.Pool
{
    class SpriteRendererPool : ISpriteRendererPool
	{
        GameObject spawnPool;
        int rendererCount;
        List<SpriteRenderer> freeRenderer = new List<SpriteRenderer>();
        List<SpriteRenderer> spawnedRenderer = new List<SpriteRenderer>();

        public SpriteRendererPool(int rendererCount)
        {
            this.rendererCount = rendererCount;

            spawnPool = new GameObject();
            spawnPool.name = "SpriteRendererPool";
            for (var i = 0; i < rendererCount; i++)
            {
                var poolObject = new GameObject();
                poolObject.name = "SpriteRenderer " + i;
                poolObject.transform.parent = spawnPool.transform;
                Despawn(poolObject.AddComponent<SpriteRenderer>() as SpriteRenderer);
            }
        }

        public SpriteRenderer Spawn()
        {
            SpriteRenderer spriteRenderer;

            if (freeRenderer.Count < 1)
            {
                spriteRenderer = spawnPool.AddComponent<SpriteRenderer>() as SpriteRenderer;
                freeRenderer.Add(spriteRenderer);
            }

            spriteRenderer = freeRenderer[0];

            freeRenderer.Remove(spriteRenderer);
            spawnedRenderer.Add(spriteRenderer);

            return spriteRenderer;
        }

        public void Despawn(SpriteRenderer spriteRenderer)
        {
            spawnedRenderer.Remove(spriteRenderer);
            spriteRenderer.enabled = false;
            freeRenderer.Add(spriteRenderer);
        }
	}
}
