using UnityEngine;

namespace Uddle.GUI.Render.Pool.Item.Interface
{
	interface ISpriteItem : IPoolItem
	{
        SpriteRenderer GetSpriteRenderer();
	}
}
