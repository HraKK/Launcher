using UnityEngine;
using Uddle.GUI.Render.Pool.Service.Interface;
using Uddle.GUI.Render.Pool.Interface;

using Uddle.GUI.Render.Pool.Item.Interface;

namespace Uddle.GUI.Render.Pool.Service
{
    class SpritePoolService : ISpritePoolService
	{
        ISpritePool spritePool;

        public SpritePoolService(ISpritePool spritePool)
        {
            this.spritePool = spritePool;
        }

        public ISpriteItem Spawn()
        {
            return spritePool.Spawn();
        }

        public void Despawn(ISpriteItem spriteItem)
        {
            spritePool.Despawn(spriteItem);
        }
	}
}
