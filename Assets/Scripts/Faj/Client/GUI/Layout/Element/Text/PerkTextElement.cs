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
            text = description;
            style.alignment = TextAnchor.UpperLeft;
            style.wordWrap = true;
        }

        public void SetDescription(string description)
        {
            SetEnabled(false);
            text = description;
            SetEnabled(true);
        }
    }
}
