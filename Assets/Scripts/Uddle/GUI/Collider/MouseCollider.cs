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

        void Start()
        {
            UnityEngine.Debug.Log("#2");
        }

        void OnMouseDown()
        {
            UnityEngine.Debug.Log("#1");
            if (OnMouseUpEvent == null)
            {
                return;
            }

            OnMouseUpEvent();
        }

        void OnMouseEnter()
        {
            UnityEngine.Debug.Log("#1");
            if (OnMouseEnterEvent == null)
            {
                return;
            }

            OnMouseEnterEvent();
        }

        void OnMouseExit()
        {
            UnityEngine.Debug.Log("#1");
            if (OnMouseExitEvent == null)
            {
                return;
            }

            OnMouseExitEvent();
        }
	}
}
