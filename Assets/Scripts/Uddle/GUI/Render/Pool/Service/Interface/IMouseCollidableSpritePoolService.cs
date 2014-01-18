using Uddle.Service.Interface;
using Uddle.GUI.Render.Pool.Item.Interface;

namespace Uddle.GUI.Render.Pool.Service.Interface
{
    interface IMouseCollidableSpritePoolService : IService
	{
        IMouseCollidableSpriteItem Spawn();
        void Despawn(IMouseCollidableSpriteItem mouseCollidableSpriteItem);
	}
}