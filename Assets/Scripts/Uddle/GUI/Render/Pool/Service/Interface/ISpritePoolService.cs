using Uddle.Service.Interface;
using Uddle.GUI.Render.Pool.Item.Interface;

namespace Uddle.GUI.Render.Pool.Service.Interface
{
	interface ISpritePoolService : IService
	{
        ISpriteItem Spawn();
        void Despawn(ISpriteItem spriteItem);
	}
}
