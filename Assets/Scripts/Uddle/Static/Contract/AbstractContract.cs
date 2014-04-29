﻿using System.Collections.Generic;
using Uddle.Static.Contract.Interface;
using Uddle.Static.Contract.Module.Interface;
using System;

namespace Uddle.Static.Contract
{
	abstract class AbstractContract : IStaticContract
	{
        readonly string id;

        readonly List<IContractModule> checkStart;
        readonly List<IContractModule> checkFinish;
        readonly List<IContractModule> pay;
        readonly List<IContractModule> award;

        public AbstractContract(string id,
            List<IContractModule> checkStart,
            List<IContractModule> checkFinish,
            List<IContractModule> pay,
            List<IContractModule> award)
        {
            this.id = id;
            this.checkStart = checkStart;
            this.checkFinish = checkFinish;
            this.pay = pay;
            this.award = award;
        }       

        public string GetId()
        {
            return id;
        }

        public List<IContractModule> GetCheckStart()
        {
            return checkStart;
        }

        public List<IContractModule> GetCheckFinish()
        {
            return checkFinish;
        }

        public List<IContractModule> GetPay()
        {
            return pay;
        }

        public List<IContractModule> GetAward()
        {
            return award;
        }

	}
}
