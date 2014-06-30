using Uddle.GUI.Layout.Element.TextElement;
using Uddle.Service;
using Faj.Client.Model.Player.Service.Interface;
using Faj.Client.Model.Player.Resource.Interface;
using UnityEngine;

namespace Faj.Client.GUI.Layout.Element.Text
{
    class PriceTextElement : TextElement
    {
        public PriceTextElement(string price)
            : base(price)
        {
            text = price;
            width = 90;
            SetFont("comic");
            SetSize(44);
            style.alignment = TextAnchor.MiddleCenter;
        }

        public void SetPrice(string price)
        {
            SetEnabled(false);
            text = price;
            SetEnabled(true);
        }
    }
}
