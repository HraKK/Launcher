using Uddle.GUI.Layout.Element.TextElement;
using Uddle.Service;
using Faj.Client.Model.Player.Service.Interface;
using Faj.Client.Model.Player.Resource.Interface;
using UnityEngine;

namespace Faj.Client.GUI.Layout.Element.Text 
{
    class ResourceTextElement : TextElement
	{
        IPlayerResources resources;

        public ResourceTextElement(string resource) : base(resource)
        {
            width = 90;
            var playerService = ServiceProvider.Instance.GetService<IPlayerService>();
            resources = playerService.GetPlayerModel().GetResources();
            style.alignment = TextAnchor.MiddleCenter;
        }

        protected string GetText()
        {
            return resources.GetResource(text).ToString();
        }

        public override void Notify()
        {
            if (true == isHidden || false == isEnabled)
            {
                return;
            }

            UnityEngine.GUI.Label(position, GetText(), style);
        }
	}
}
