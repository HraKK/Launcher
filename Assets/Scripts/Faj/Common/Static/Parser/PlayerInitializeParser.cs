using System.Xml.Linq;
using Uddle.Static.Collection;
using Faj.Common.Model.Static.PlayerInitialize.Collection.Item.Interface;
using System.Collections.Generic;
using Faj.Common.Model.Static.PlayerInitialize.Collection.Item;
using Uddle.Static.Collection.Interface;
using Uddle.Static.Parser.Interface;
using Faj.Common.Model.Static.PlayerInitialize.Collection;

namespace Faj.Common.Model.Static.Parser
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

            string level = (string)element.Element("startlevel");
            var item = new PlayerInitializeItem(resources, level);

            return item;
        }
	}
}
