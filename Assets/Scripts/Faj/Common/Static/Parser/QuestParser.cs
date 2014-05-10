using Uddle.Static.Collection.Interface;
using Uddle.Static.Parser.Interface;
using System.Xml.Linq;
using Faj.Common.Static.Quest.Collection;
using Faj.Common.Static.Quest.Collection.Item.Interface;
using System.Collections.Generic;
using Uddle.Static.Contract.Module.Interface;
using Faj.Common.Static.Contract.Condition;
using Faj.Common.Static.Contract.Module;
using Faj.Common.Static.Quest.Collection.Item;

namespace Faj.Common.Static.Parser
{
	class QuestParser: IStaticParser
    {
        public IStaticCollection Parse(XDocument document)
        {
            var questCollection = new QuestCollection();
            foreach (var element in document.Root.Elements())
            {
                var item = ParseItem(element);
                if (item == null)
                {
                    continue;
                }

                questCollection.AddItem(item.GetId(), item);
            }

            return questCollection;
        }

        IQuestItem ParseItem(XElement element)
        {
            var checkStart = new List<IContractModule>();
            var checkFinish = new List<IContractModule>();
            var award = new List<IContractModule>();

            var id = (string)element.Element("id");
            var level = (string)element.Element("level");
            var action = (string)element.Element("action");
            var target = (string)element.Element("target");
            var value = 0;
            
            if (element.Element("checkstart") != null)
            {
                foreach (var checkStartElement in element.Element("checkstart").Elements())
                {
                    if (checkStartElement.Name == "finishedquests")
                    {
                        var countElement = checkStartElement.Element("count");
                        var countCondition = new CountCondition((int)countElement);
                        var finishedQuestsModule = new FinishedQuestsModule(countCondition);
                        checkStart.Add(finishedQuestsModule);
                    }
                }
            }

            if (element.Element("checkfinish") != null)
            {
                foreach (var checkFinishElement in element.Element("checkfinish").Elements())
                {
                    if (checkFinishElement.Name == "actions")
                    {
                        var countElement = checkFinishElement.Element("count");
                        value = (int)countElement;
                        var countCondition = new CountCondition(value);
                        var actionModule = new ActionModule(countCondition);
                        checkFinish.Add(actionModule);
                    }
                }
            }

            if (element.Element("award") != null)
            {
                Dictionary<string, int> resources = new Dictionary<string, int>();

                foreach (var awardElement in element.Element("award").Elements())
                {
                    if (awardElement.Name == "resources")
                    {
                        foreach (var resourceElement in awardElement.Elements())
                        {
                            var resourceName = resourceElement.Name.ToString();
                            var resourceCount = (int) resourceElement;

                            if (resources.ContainsKey(resourceName))
                            {
                                resources[resourceName] += resourceCount;
                            }
                            else
                            {
                                resources.Add(resourceName, resourceCount);
                            }
                        }
                    }
                }

                if (resources.Count != 0)
                {
                    var DictionaryIntCondition = new DictionaryIntCondition(resources);
                    var resourceModule = new ResourceModule(DictionaryIntCondition);
                    award.Add(resourceModule);
                }
            }

            var item = new QuestItem(id, checkStart, checkFinish, null, award, null, level, action, target, value);

            return item;
        }
    }
}