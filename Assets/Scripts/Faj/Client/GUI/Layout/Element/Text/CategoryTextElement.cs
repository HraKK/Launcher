using Uddle.GUI.Layout.Element.TextElement;
using Uddle.Service;
using Faj.Client.Model.Player.Service.Interface;
using Faj.Client.Model.Player.Resource.Interface;
using UnityEngine;

namespace Faj.Client.GUI.Layout.Element.Text
{
    class CategoryTextElement : TextElement
    {
        string category;

        public CategoryTextElement(string category)
            : base(category)
        {
            width = 90;
            this.category = category;
            style.alignment = TextAnchor.MiddleCenter;
        }

        protected override string GetText()
        {
            return category;
        }
    }
}
