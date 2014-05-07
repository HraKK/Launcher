using Uddle.Static.Contract.Module.Condition.Interface;
using System.Collections.Generic;

namespace Faj.Common.Static.Contract.Condition.Interface
{
    interface IDictionaryIntCondition : ICondition
	{
        Dictionary<string, int> GetDictionary();
	}
}