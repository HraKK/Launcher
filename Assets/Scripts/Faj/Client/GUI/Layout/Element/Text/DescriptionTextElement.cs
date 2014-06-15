using Uddle.GUI.Layout.Element.TextElement;
using UnityEngine;

namespace Faj.Client.GUI.Layout.Element.Text
{
	class DescriptionTextElement : TextElement
	{
        string description;

        public DescriptionTextElement(string description)
            : base(description)
        {
            width = 320;
            height = 100;
            SetFont("comic");
            SetSize(30);
            this.description = description;
            style.alignment = TextAnchor.UpperLeft;
            style.wordWrap = true;
        }

        public void SetDescription(string description)
        {
            this.description = description;
        }

        protected override string GetText()
        {
            return description;
        }
	}
}
