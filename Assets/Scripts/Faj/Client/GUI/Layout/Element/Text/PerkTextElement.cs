using Uddle.GUI.Layout.Element.TextElement;
using UnityEngine;

namespace Faj.Client.GUI.Layout.Element.Text
{
    class PerkTextElement : TextElement
    {
        string description;

        public PerkTextElement(string description)
            : base(description)
        {
            width = 360;
            height = 250;
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
