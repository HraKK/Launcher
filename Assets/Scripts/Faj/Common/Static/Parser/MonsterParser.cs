using Uddle.Static.Parser.Interface;
using System.Xml.Linq;
using Uddle.Static.Collection.Interface;
using Faj.Common.Static.Monster.Collection;
using Faj.Common.Static.Monster.Collection.Item.Interface;
using Faj.Common.Static.Monster.Collection.Item;

namespace Faj.Common.Static.Parser
{
	class MonsterParser : IStaticParser
    {
        public IStaticCollection Parse(XDocument document)
        {
            var collection = new MonsterCollection();
            foreach (var element in document.Root.Elements())
            {
                var item = ParseItem(element);
                collection.AddItem(item.GetId(), item);
            }

            return collection;
        }

        IMonsterItem ParseItem(XElement element)
        {

            var id = (string)element.Element("id");
            var type = (string)element.Element("type");
            var heals = (int)element.Element("heals");

            var item = new MonsterItem(id, type, heals);

            return item;
        }
    }
}
