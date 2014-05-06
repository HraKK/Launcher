using System.Xml.Linq;
using Uddle.Static.Collection;
using System.Collections.Generic;
using Uddle.Static.Collection.Interface;
using Uddle.Static.Parser.Interface;
using Faj.Common.Static.Level.Open.Collection.Item.Interface;
using Faj.Common.Static.Level.Open.Collection.Item;
using Faj.Common.Static.Level.Collection.Open;
using Uddle.Static.Contract.Module.Interface;
using Faj.Common.Static.Contract.Condition;
using Faj.Common.Static.Contract.Module;

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

                levelOpenCollection.AddItem(item.GetId(), item);
            }

            return levelOpenCollection;
        }

        ILevelOpenItem ParseItem(XElement element)
        {
            var checkStart = new List<IContractModule>();
            var checkFinish = new List<IContractModule>();
            var award = new List<IContractModule>();

            var id = (string)element.Element("id");
            
            if (element.Element("checkstart") != null)
            {
                foreach (var checkStartElement in element.Element("checkstart").Elements())
                {
                    if (checkStartElement.Name == "finishedlevel")
                    {
                        var idElement = checkStartElement.Element("id");
                        var idCondition = new IdCondition((string)idElement);
                        var finishedLevelModule = new FinishedLevelModule(idCondition);
                        checkStart.Add(finishedLevelModule);
                    }
                }
            }

            if (element.Element("checkfinish") != null)
            {
                foreach (var checkFinishElement in element.Element("checkfinish").Elements())
                {
                    if (checkFinishElement.Name == "finishedquest")
                    {
                        var idElement = checkFinishElement.Element("id");
                        var idCondition = new IdCondition((string)idElement);
                        var finishedQuestModule = new FinishedQuestModule(idCondition);
                        checkFinish.Add(finishedQuestModule);
                    }
                }
            }

            if (element.Element("award") != null)
            {
                foreach (var awardElement in element.Element("award").Elements())
                {
                    if (awardElement.Name == "finishedlevel")
                    {
                        var idElement = awardElement.Element("id");
                        var idCondition = new IdCondition((string)idElement);
                        var finishedLevelModule = new FinishedLevelModule(idCondition);
                        award.Add(finishedLevelModule);
                    }
                }
            }

            var item = new LevelOpenItem(id, checkStart, checkFinish, null, award);

            return item;
        }
    }
}
