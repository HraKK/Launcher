using System;

namespace Uddle.GUI.Collider.Interface
{
	interface IMouseCollider
	{
        event Action OnMouseUpEvent;
        event Action OnMouseEnterEvent;
        event Action OnMouseExitEvent; 
	}
}
