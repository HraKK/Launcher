using Uddle.Static.Parser.Interface;
using Uddle.Static.Collection.Interface;
using System.Xml.Linq;
using Faj.Common.Static.Level.Play.Collection;
using Faj.Common.Static.Level.Play.Collection.Item.Interface;
using System.Collections.Generic;
using Uddle.Static.Contract.Module.Interface;
using Faj.Common.Static.Contract.Condition;
using Faj.Common.Static.Contract.Module;
using Faj.Common.Static.Level.Play.Collection.Item;
namespace Faj.Common.Static.Parser
{
	class LevelPlayParser : IStaticParser
    {
        public IStaticCollection Parse(XDocument document)
        {
            
            var collection = new LevelPlayCollection();

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

        ILevelPlayItem ParseItem(XElement element)
        {
            var checkStart = new List<IContractModule>();
            var pay = new List<IContractModule>();
            var skip = new List<IContractModule>();

            var id = (string)element.Element("id");
            var rate = (int)element.Element("rate");
            string levelId = null;
            
            if (element.Element("checkstart") != null)
            {
                Dictionary<string, int> resources = new Dictionary<string, int>();

                foreach (var checkStartElement in element.Element("checkstart").Elements())
                {
                    if (checkStartElement.Name == "leveltime")
                    {
                        var valueElement = checkStartElement.Element("elapsed");
                        var idCondition = new IntCondition((int)valueElement);
                        var levelTimeModule = new LevelTimeModule(idCondition);
                        checkStart.Add(levelTimeModule);
                    }
                    if (checkStartElement.Name == "finishedlevel")
                    {
                        var idElement = checkStartElement.Element("id");
                        levelId = (string)idElement;
                        var idCondition = new IdCondition((string)idElement);
                        var finishedLevelModule = new FinishedLevelModule(idCondition);
                        checkStart.Add(finishedLevelModule);
                    }
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

            if (element.Element("skip") != null)
            {
                Dictionary<string, int> resources = new Dictionary<string, int>();

                foreach (var payElement in element.Element("skip").Elements())
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
                    skip.Add(resourceModule);
                }
            }

            var item = new LevelPlayItem(id, checkStart, null, pay, null, skip, rate, levelId);

            return item;
        }
    }
}
