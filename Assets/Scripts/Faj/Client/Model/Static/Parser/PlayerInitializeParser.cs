using System.Xml.Linq;
using Uddle.Static.Collection;
using Faj.Client.Model.Static.PlayerInitialize.Collection.Item.Interface;
using System.Collections.Generic;
using Faj.Client.Model.Static.PlayerInitialize.Collection.Item;
using Uddle.Static.Collection.Interface;
using Uddle.Static.Parser.Interface;
using Faj.Client.Model.Static.PlayerInitialize.Collection;

namespace Faj.Client.Model.Static.Parser
{
	class PlayerInitializeParser : IStaticParser
	{
        public IStaticCollection Parse(XDocument document)
        {
            int i = 0;
            var playerInitializeCollection = new PlayerInitializeCollection();
            foreach (var element in document.Root.Elements())
            {
                i++;
                var item = ParseItem(element);
                playerInitializeCollection.AddItem(i.ToString(), item);
            }

            return playerInitializeCollection;
        }

        IPlayerInitializeItem ParseItem(XElement element)
        {
            Dictionary<string, int> resources = new Dictionary<string, int>();

            foreach (var resourceElement in element.Element("resources").Elements())
            {
                resources.Add(resourceElement.Name.LocalName, (int)resourceElement);
            }
            
            var item = new PlayerInitializeItem(resources);

            return item;
        }
	}
}
