using Uddle.Static.Collection;
using Faj.Common.Static.Perk.Collection.Item.Interface;
using Faj.Common.Static.Perk.Collection.Interface;
using System.Collections.Generic;

namespace Faj.Common.Static.Perk.Collection
{
    class PerkCollection : TypicalStaticCollection<IPerkItem>, IPerkCollection
    {
        public List<IPerkItem> GetPerksByType(string type)
        {
            List<IPerkItem> perks = new List<IPerkItem>();
            foreach (var perk in items.Values)
            {
                if (type != perk.GetType())
                {
                    continue;
                }

                perks.Add(perk);
            }

            return perks;
        }
    }
}
