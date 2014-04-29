using System.Xml.Linq;
using Uddle.Static.Collection;
using System.Collections.Generic;
using Uddle.Static.Collection.Interface;
using Uddle.Static.Parser.Interface;
using Faj.Common.Static.Level.Open.Collection.Item.Interface;
using Faj.Common.Static.Level.Open.Collection.Item;
using Faj.Common.Static.Level.Collection.Open;

namespace Faj.Common.Model.Static.Parser
{
    class LevelOpenParser : IStaticParser
    {
        public IStaticCollection Parse(XDocument document)
        {
            int i = 0;
            var levelOpenCollection = new LevelOpenCollection();
            foreach (var element in document.Root.Elements())
            {
                i++;
                var item = ParseItem(element);
                if (item == null)
                {
                    continue;
                }

                levelOpenCollection.AddItem(i.ToString(), item);
            }

            return levelOpenCollection;
        }

        ILevelOpenItem ParseItem(XElement element)
        {

            if (element.Element("resources") != null)
            {
                foreach (var resourceElement in element.Element("resources").Elements())
                {
                    //resources.Add(resourceElement.Name.LocalName, (int)resourceElement);
                }
            }

            //var item = new LevelOpenItem(id, chapter, type);

            return null;
        }
    }
}
