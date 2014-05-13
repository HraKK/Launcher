using Uddle.Static.Parser.Interface;
using Uddle.Static.Collection.Interface;
using System.Xml.Linq;
using Faj.Common.Static.Achievement.Collection;
using Faj.Common.Static.Achievement.Collection.Item.Interface;
using System.Collections.Generic;
using Uddle.Static.Contract.Module.Interface;
using Faj.Common.Static.Contract.Condition;
using Faj.Common.Static.Contract.Module;
using Faj.Common.Static.Achievement.Collection.Item;
namespace Faj.Common.Static.Parser
{
    class AchievementParser : IStaticParser
    {
        public IStaticCollection Parse(XDocument document)
        {
            var collection = new AchievementCollection();
            foreach (var element in document.Root.Elements())
            {
                var item = ParseItem(element);
                if (item == null)
                {
                    continue;
                }

                collection.AddItem(item.GetId(), item);
            }

            return collection;
        }

        IAchievementItem ParseItem(XElement element)
        {
            var checkStart = new List<IContractModule>();
            var checkFinish = new List<IContractModule>();
            var award = new List<IContractModule>();
            var skip = new List<IContractModule>();

            var id = (string)element.Element("id");
            var action = (string)element.Element("action");
            var target = (string)element.Element("target");
            var value = 0;

            

            if (element.Element("checkfinish") != null)
            {
                foreach (var checkFinishElement in element.Element("checkfinish").Elements())
                {
                    if (checkFinishElement.Name == "actions")
                    {
                        var countElement = checkFinishElement.Element("count");
                        value = (int)countElement;                        
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
                            var resourceCount = (int)resourceElement;

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

            var item = new AchievementItem(id, checkStart, checkFinish, null, award, skip, action, target, value);

            return item;
        }
    }
}
