using System;
using UnityEngine;

namespace Uddle.GUI.Layout.Element.Interface
{
	interface IGUIElement
	{
        event Action<IGUIElement> OnVisibleEvent;
        event Action<IGUIElement> OnHideEvent;

        void SetPosition(float x, float y);

        void SetEnabled(bool isEnabled);
        bool IsEnabled();
        void SetHidden(bool isHidden);
        void Disappear();
	}
}
