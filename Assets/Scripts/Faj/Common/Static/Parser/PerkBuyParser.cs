using Uddle.Static.Parser.Interface;
using Uddle.Static.Collection.Interface;
using System.Xml.Linq;
using Faj.Common.Static.Perk.Buy.Collection;
using Faj.Common.Static.Perk.Buy.Collection.Item.Interface;
using System.Collections.Generic;
using Faj.Common.Static.Contract.Condition;
using Faj.Common.Static.Contract.Module;
using Uddle.Static.Contract.Module.Interface;
using Faj.Common.Static.Perk.Buy.Collection.Item;
namespace Faj.Common.Static.Parser
{
    class PerkBuyParser : IStaticParser
    {
        public IStaticCollection Parse(XDocument document)
        {

            var collection = new PerkBuyCollection();
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

        IPerkBuyItem ParseItem(XElement element)
        {
            var checkStart = new List<IContractModule>();
            var pay = new List<IContractModule>();
            var award = new List<IContractModule>();

            var id = (string)element.Element("id");

            if (element.Element("checkstart") != null)
            {
                Dictionary<string, int> resources = new Dictionary<string, int>();

                foreach (var checkStartElement in element.Element("checkstart").Elements())
                {
                    if (checkStartElement.Name == "resources")
                    {
                        foreach (var resourceElement in checkStartElement.Elements())
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
                    checkStart.Add(resourceModule);
                }
            }

            if (element.Element("pay") != null)
            {
                Dictionary<string, int> resources = new Dictionary<string, int>();

                foreach (var payElement in element.Element("pay").Elements())
                {
                    if (payElement.Name == "resources")
                    {
                        foreach (var resourceElement in payElement.Elements())
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
                    pay.Add(resourceModule);
                }
            }

            

            if (element.Element("award") != null)
            {
                foreach (var awardElement in element.Element("award").Elements())
                {
                    if (awardElement.Name == "perks")
                    {
                        var idElement = awardElement.Element("id");
                        var perk = (string)idElement;
                        var idCondition = new IdCondition(perk);

                        var perksModule = new PerksModule(idCondition);
                        award.Add(perksModule);
                    }
                }
            }

            var item = new PerkBuyItem(id, checkStart, null, pay, award, null);

            return item;
        }
    }
}
