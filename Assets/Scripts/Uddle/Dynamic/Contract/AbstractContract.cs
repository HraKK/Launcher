using Uddle.Static.Contract.Interface;
using Uddle.Dynamic.Contract.Module.Interface;
using Uddle.Service;
using Uddle.Model.Player.Interface;
using System.Collections.Generic;
using Uddle.Dynamic.Contract.Interface;

namespace Uddle.Dynamic.Contract
{
	abstract class AbstractContract : IContract
	{
        readonly protected IStaticContract contract;
        readonly protected IPlayerModel playerModel;
        readonly protected IModuleFactory moduleFactory;

        public AbstractContract(IStaticContract contract, IPlayerModel playerModel)
        {
            this.contract = contract;
            this.playerModel = playerModel;

            moduleFactory = ServiceProvider.Instance.GetService<IModuleFactory>();
        }

        public virtual bool Start()
        {
            if (false == CheckStart())
            {
                return false;
            }

            Pay();

            return true;
        }

        public virtual bool Finish()
        {
            if (false == CheckFinish())
            {
                return false;
            }

            Award();

            return true;
        }

        public virtual bool Skip()
        {
            if (false == CheckSkip())
            {
                return false;
            }

            Skip();

            return true;
        }

        protected bool CheckSkip()
        {
            var checkSkipModules = contract.GetSkip();

            return Check(checkSkipModules);
        }

        protected bool CheckStart()
        {
            var checkStartModules = contract.GetCheckStart();
            return Check(checkStartModules);
        }

        protected bool CheckFinish()
        {
            var checkFinishModules = contract.GetCheckFinish();

            return Check(checkFinishModules);
        }

        protected bool Check(List<Uddle.Static.Contract.Module.Interface.IContractModule> checkModules)
        {
            if (null == checkModules)
            {

                return true;
            }

            foreach (var staticModule in checkModules)
            {
                var module = moduleFactory.GetModule(staticModule.GetName());
                var checkResult = module.Check(contract, playerModel, staticModule.GetCondition());

                if (false == checkResult)
                {
                    return false;
                }
            }

            return true;
        }

        protected void Pay()
        {
            var payModules = contract.GetPay();

            if (null == payModules)
            {
                return;
            }

            foreach (var staticModule in payModules)
            {
                var module = moduleFactory.GetModule(staticModule.GetName());
                module.Pay(contract, playerModel, staticModule.GetCondition());
            }
        }

        protected void Award()
        {
            var awardModules = contract.GetAward();

            if (null == awardModules)
            {
                return;
            }

            foreach (var staticModule in awardModules)
            {
                var module = moduleFactory.GetModule(staticModule.GetName());
                module.Award(contract, playerModel, staticModule.GetCondition());
            }
        }
	}
}
