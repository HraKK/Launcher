using Uddle.Static.Parser.Interface;
using Uddle.Static.Collection.Interface;
using System.Xml.Linq;
using Faj.Common.Static.Level.Monster.Collection;
using Faj.Common.Static.Level.Monster.Collection.Item.Interface;
using Faj.Common.Static.Level.Monster.Collection.Item;
namespace Faj.Common.Static.Parser
{
	class LevelMonsterParser : IStaticParser
    {
        public IStaticCollection Parse(XDocument document)
        {
            var collection = new LevelMonsterCollection();
            foreach (var element in document.Root.Elements())
            {
                var item = ParseItem(element);
                collection.AddItem(item.GetId(), item);
            }

            return collection;
        }

        ILevelMonsterItem ParseItem(XElement element)
        {
            var id = (string)element.Element("id");
            var levelId = (string)element.Element("level");
            var monsterId = (string)element.Element("monster");
            var count = (int)element.Element("count");

            var item = new LevelMonsterItem(id, levelId, monsterId, count);

            return item;
        }
    }
}
