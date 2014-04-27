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
            int i = 0;
            var playerInitializeCollection = new LevelCollection();
            foreach (var element in document.Root.Elements())
            {
                i++;
                var item = ParseItem(element);
                playerInitializeCollection.AddItem(i.ToString(), item);
            }

            return playerInitializeCollection;
        }

        ILevelItem ParseItem(XElement element)
        {

            var id = (string)element.Element("id");
            var chapter = (string)element.Element("id");
            var type = (string)element.Element("id");

            var item = new LevelItem(id, chapter, type);

            return item;
        }
    }
}
