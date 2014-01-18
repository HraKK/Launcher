using Uddle.GUI.Render.Pool.Service.Interface;
using Uddle.GUI.Render.Pool.Interface;
using Uddle.GUI.Render.Pool.Item.Interface;

namespace Uddle.GUI.Render.Pool.Service
{
    class MouseCollidableSpritePoolService : IMouseCollidableSpritePoolService
    {
        IMouseCollidableSpritePool mouseCollidableSpritePool;

        public MouseCollidableSpritePoolService(IMouseCollidableSpritePool mouseCollidableSpritePool)
        {
            this.mouseCollidableSpritePool = mouseCollidableSpritePool;
        }

        public IMouseCollidableSpriteItem Spawn()
        {
            return mouseCollidableSpritePool.Spawn();
        }

        public void Despawn(IMouseCollidableSpriteItem mouseCollidableSpriteItem)
        {
            mouseCollidableSpritePool.Despawn(mouseCollidableSpriteItem);
        }
    }
}
