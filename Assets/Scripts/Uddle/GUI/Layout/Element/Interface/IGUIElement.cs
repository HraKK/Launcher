using System;
using Uddle.GUI.Render.Interface;
using UnityEngine;

namespace Uddle.GUI.Layout.Element.Interface
{
	interface IGUIElement
	{
        event Action<IGUIElement> OnVisibleEvent;
        event Action<IGUIElement> OnHideEvent;

        void SetPosition(int x, int y);

        void SetEnabled(bool isEnabled);
        bool IsEnabled();
        void SetHidden(bool isHidden);
        void Disappear();
	}
}
