using Uddle.Static.Parser.Interface;
using Uddle.Static.Collection.Interface;
using System.Xml.Linq;
using Faj.Common.Static.Perk.Collection;
using Faj.Common.Static.Perk.Collection.Item.Interface;
using Faj.Common.Static.Perk.Collection.Item;
namespace Faj.Common.Static.Parser
{
	class PerkParser : IStaticParser
	{
        public IStaticCollection Parse(XDocument document)
        {
            var collection = new PerkCollection();
            foreach (var element in document.Root.Elements())
            {
                var item = ParseItem(element);
                collection.AddItem(item.GetId(), item);
            }

            return collection;
        }

        IPerkItem ParseItem(XElement element)
        {

            var id = (string)element.Element("id");
            var type = (string)element.Element("type");
            var description = (string)element.Element("description");

            var item = new PerkItem(id, type, description);

            return item;
        }
	}
}
