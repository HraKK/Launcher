using UnityEngine;

namespace Uddle.GUI.Render.Pool.Interface
{
	interface ISpriteRendererPool
	{
        SpriteRenderer Spawn();
        void Despawn(SpriteRenderer spriteRenderer);
	}
}
