using Uddle.Static.Collection.Interface;
using Faj.Common.Static.Quest.Collection.Item.Interface;
using System.Collections.Generic;

namespace Faj.Common.Static.Quest.Collection.Interface
{
	interface IQuestCollection : IStaticGenericCollection<IQuestItem>
	{
        List<IQuestItem> GetItemsByActionAndTarget(string action, string target);
        List<IQuestItem> GetItemsByLevel(string level);
	}
}
