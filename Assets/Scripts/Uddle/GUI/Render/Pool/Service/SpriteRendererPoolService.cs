using Uddle.GUI.Render.Pool.Service.Interface;
using Uddle.GUI.Render.Pool.Interface;
using UnityEngine;

namespace Uddle.GUI.Render.Pool.Service
{
    class SpriteRendererPoolService : ISpriteRendererPoolService
	{
        ISpriteRendererPool spriteRendererPool;

        public SpriteRendererPoolService(ISpriteRendererPool spriteRendererPool)
        {
            this.spriteRendererPool = spriteRendererPool;
        }

        public SpriteRenderer Spawn()
        {
            return spriteRendererPool.Spawn();
        }

        public void Despawn(SpriteRenderer spriteRenderer)
        {
            spriteRendererPool.Despawn(spriteRenderer);
        }
	}
}
