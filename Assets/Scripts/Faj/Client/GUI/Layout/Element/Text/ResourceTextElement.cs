using Uddle.GUI.Layout.Element.TextElement;
using Uddle.Service;
using Faj.Client.Model.Player.Service.Interface;
using Faj.Common.Model.Player.Resource.Interface;

namespace Faj.Client.GUI.Layout.Element.Text 
{
    class ResourceTextElement : TextElement
	{
        IPlayerResources resources;

        public ResourceTextElement(string resource) : base(resource)
        {
            var playerService = ServiceProvider.Instance.GetService<IPlayerService>();
            resources = playerService.GetPlayerModel().GetResources();
        }

        protected override string GetText()
        {
            return resources.GetResource(text).ToString();
        }
	}
}
