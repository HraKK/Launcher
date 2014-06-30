using UnityEngine;
using Uddle.GUI.Layout.Element.TextElement;
namespace Faj.Client.GUI.Layout.Element.Text
{
    class UpgradeTextElement : TextElement
	{

        public UpgradeTextElement(string upgrade)
            : base(upgrade)
        {
            width = 300;
            text = upgrade;
            style.alignment = TextAnchor.MiddleCenter;            
            SetFont("segoeprb");
            SetSize(43);
        }

        public void SetUpgrade(string upgrade)
        {
            SetEnabled(false);
            text = upgrade;
            SetEnabled(true);
        }
	}
}
