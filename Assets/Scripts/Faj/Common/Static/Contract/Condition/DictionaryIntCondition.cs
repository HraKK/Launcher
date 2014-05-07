using Faj.Common.Static.Contract.Condition.Interface;
using System.Collections.Generic;

namespace Faj.Common.Static.Contract.Condition
{
    class DictionaryIntCondition : IDictionaryIntCondition
    {
        readonly Dictionary<string, int> dictionary;

        public DictionaryIntCondition(Dictionary<string, int> dictionary)
        {
            this.dictionary = dictionary;
        }

        public Dictionary<string, int> GetDictionary()
        {
            return dictionary;
        }
    }
}
