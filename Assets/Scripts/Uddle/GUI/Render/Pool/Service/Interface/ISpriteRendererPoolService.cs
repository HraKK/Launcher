using Uddle.Service.Interface;
using UnityEngine;

namespace Uddle.GUI.Render.Pool.Service.Interface
{
	interface ISpriteRendererPoolService : IService
	{
        SpriteRenderer Spawn();
        void Despawn(SpriteRenderer spriteRenderer);
	}
}
