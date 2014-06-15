using Uddle.Static.Parser.Interface;
using Uddle.Static.Collection.Interface;
using System.Xml.Linq;
using Faj.Common.Static.Upgrade.Type.Collection;
using Faj.Common.Static.Upgrade.Type.Collection.Item.Interface;
using Faj.Common.Static.Upgrade.Type.Collection.Item;

namespace Faj.Common.Static.Parser
{
    class UpgradeTypeParser : IStaticParser
    {
        public IStaticCollection Parse(XDocument document)
        {
            var collection = new UpgradeTypeCollection();
            foreach (var element in document.Root.Elements())
            {
                var item = ParseItem(element);
                collection.AddItem(item.GetId(), item);
            }

            return collection;
        }

        IUpgradeTypeItem ParseItem(XElement element)
        {

            var id = (string)element.Element("id");
            var description = (string)element.Element("description");
            var category = (string)element.Element("category");

            var item = new UpgradeTypeItem(id, description, category);

            return item;
        }
    }
}
