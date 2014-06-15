using Uddle.GUI.Layout.Element.TextElement;
using Uddle.Service;
using Faj.Client.Model.Player.Service.Interface;
using Faj.Client.Model.Player.Resource.Interface;
using UnityEngine;

namespace Faj.Client.GUI.Layout.Element.Text
{
    class PriceTextElement : TextElement
    {
        string price;

        public PriceTextElement(string price)
            : base(price)
        {
            this.price = price;
            width = 90;
            SetFont("comic");
            SetSize(44);
            style.alignment = TextAnchor.MiddleCenter;
        }

        public void SetPrice(string price)
        {
            this.price = price;
        }

        protected override string GetText()
        {
            return price;
        }
    }
}
