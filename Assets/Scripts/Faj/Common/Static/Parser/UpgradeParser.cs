using Uddle.Static.Collection.Interface;
using Uddle.Static.Parser.Interface;
using System.Xml.Linq;
using Faj.Common.Static.Upgrade.Collection;
using Faj.Common.Static.Upgrade.Collection.Item.Interface;
using Faj.Common.Static.Upgrade.Collection.Item;
namespace Faj.Common.Static.Parser
{
	class UpgradeParser: IStaticParser
    {
        public IStaticCollection Parse(XDocument document)
        {
            var collection = new UpgradeCollection();
            foreach (var element in document.Root.Elements())
            {
                var item = ParseItem(element);
                collection.AddItem(item.GetId(), item);
            }

            return collection;
        }

        IUpgradeItem ParseItem(XElement element)
        {

            var id = (string)element.Element("id");
            var level = (int)element.Element("level");
            var value = (int)element.Element("value");

            var item = new UpgradeItem(id, level, value);

            return item;
        }
    }
}
