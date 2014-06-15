using UnityEngine;
using Uddle.GUI.Layout.Element.TextElement;
namespace Faj.Client.GUI.Layout.Element.Text
{
    class UpgradeTextElement : TextElement
	{
        string upgrade;

        public UpgradeTextElement(string upgrade)
            : base(upgrade)
        {
            width = 300;
            this.upgrade = upgrade;
            style.alignment = TextAnchor.MiddleCenter;            
            SetFont("segoeprb");
            SetSize(43);
        }

        public void SetUpgrade(string upgrade)
        {
            this.upgrade = upgrade;
        }

        protected override string GetText()
        {
            return upgrade;
        }
	}
}
