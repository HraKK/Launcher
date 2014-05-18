using System.Xml.Linq;
using Uddle.Static.Collection.Interface;
using Faj.Common.Static.Configuration.Collection;
using Faj.Common.Static.Configuration.Collection.Item.Interface;
using Faj.Common.Static.Configuration.Collection.Item;
using Uddle.Static.Parser.Interface;

namespace Faj.Common.Static.Parser
{
    class ConfigurationParser : IStaticParser
	{
        public IStaticCollection Parse(XDocument document)
        {
            var collection = new ConfigurationCollection();
            foreach (var element in document.Root.Elements())
            {
                var item = ParseItem(element);
                collection.AddItem(item.GetId(), item);
            }

            return collection;
        }

        IConfigurationItem ParseItem(XElement element)
        {

            var id = (string)element.Element("id");
            var value = (int)element.Element("value");

            var item = new ConfigurationItem(id, value);

            return item;
        }
	}
}
