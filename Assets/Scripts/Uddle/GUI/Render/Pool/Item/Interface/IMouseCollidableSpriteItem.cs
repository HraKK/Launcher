using Uddle.GUI.Collider.Interface;

namespace Uddle.GUI.Render.Pool.Item.Interface
{
	interface IMouseCollidableSpriteItem : ISpriteItem
	{
        IMouseCollider GetMouseCollider();
	}
}
