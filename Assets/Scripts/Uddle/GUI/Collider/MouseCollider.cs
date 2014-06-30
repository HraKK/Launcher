using UnityEngine;
using Uddle.GUI.Collider.Interface;
using System;

namespace Uddle.GUI.Collider
{
    class MouseCollider : MonoBehaviour, IMouseCollider
	{
        public event Action OnMouseUpEvent;
        public event Action OnMouseEnterEvent;
        public event Action OnMouseExitEvent;

        void OnMouseDown()
        {
            if (OnMouseUpEvent == null)
            {
                return;
            }

            OnMouseUpEvent();
        }

        void OnMouseEnter()
        {
            if (OnMouseEnterEvent == null)
            {
                return;
            }

            OnMouseEnterEvent();
        }

        void OnMouseExit()
        {
            if (OnMouseExitEvent == null)
            {
                return;
            }

            OnMouseExitEvent();
        }
	}
}
