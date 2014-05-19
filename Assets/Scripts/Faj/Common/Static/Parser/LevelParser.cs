using System.Xml.Linq;
using Uddle.Static.Collection;
using System.Collections.Generic;
using Uddle.Static.Collection.Interface;
using Uddle.Static.Parser.Interface;
using Faj.Common.Model.Static.Level.Collection;
using Faj.Common.Model.Static.Level.Collection.Item.Interface;
using Faj.Common.Model.Static.Level.Collection.Item;

namespace Faj.Common.Model.Static.Parser
{
    class LevelParser : IStaticParser
    {
        public IStaticCollection Parse(XDocument document)
        {
            var collection = new LevelCollection();
            foreach (var element in document.Root.Elements())
            {
                var item = ParseItem(element);
                collection.AddItem(item.GetId(), item);
            }

            return collection;
        }

        ILevelItem ParseItem(XElement element)
        {

            var id = (string)element.Element("id");
            var chapter = (string)element.Element("chapter");
            var type = (string)element.Element("type");

            var item = new LevelItem(id, chapter, type);

            return item;
        }
    }
}
