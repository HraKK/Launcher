using Uddle.Static.Contract.Module.Interface;
using Uddle.Static.Collection.Item;
using System.Collections.Generic;

namespace Uddle.Static.Contract.Interface
{
    interface IStaticContract : IStaticItem
	{
        string GetId();
        List<IContractModule> GetCheckStart();
        List<IContractModule> GetCheckFinish();
        List<IContractModule> GetPay();
        List<IContractModule> GetAward();
        List<IContractModule> GetSkip();
	}
}
