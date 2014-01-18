using Uddle.GUI.Render.Pool.Item.Interface;

namespace Uddle.GUI.Render.Pool.Interface
{
    interface IPool<TPoolItem> where TPoolItem : IPoolItem
	{
        TPoolItem Spawn();
        void Despawn(TPoolItem spriteItem);
	}
}
