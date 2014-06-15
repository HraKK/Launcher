using Uddle.Static.Collection.Interface;
using Faj.Common.Static.Perk.Collection.Item.Interface;
using System.Collections.Generic;

namespace Faj.Common.Static.Perk.Collection.Interface
{
    interface IPerkCollection : IStaticGenericCollection<IPerkItem>
    {
        List<IPerkItem> GetPerksByType(string type);
    }
}
