using System.Collections.Generic;
using Uddle.GUI.Layout.Interface;
namespace Uddle.GUI.Layout.Element.ContainerElement
{
	class ContainerElement : AbstractGUIElement
	{
        protected List<AbstractGUIElement> elements = new List<AbstractGUIElement>();

        public override void SetEnabled(bool isEnabled)
        {
            foreach (var element in elements)
            {
                element.SetEnabled(isEnabled);
            }

            this.isEnabled = isEnabled;
            Render();
        }

        public override void SetHidden(bool isHidden)
        {
            foreach (var element in elements)
            {
                element.SetHidden(isHidden);
            }

            this.isHidden = isHidden;
            Render();
        }

        public void AddToLayout(ILayout layout)
        {
            foreach (var element in elements)
            {
                layout.AddElement(element);
            }
        }

        public override void Disappear()
        {
            elements.Clear();
            elements = null;

            base.Disappear();
        }
	}
}
