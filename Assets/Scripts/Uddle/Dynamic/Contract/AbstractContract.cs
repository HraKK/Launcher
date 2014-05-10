using Uddle.Static.Contract.Interface;
using Uddle.Dynamic.Contract.Module.Interface;
using Uddle.Service;
using Uddle.Model.Player.Interface;

namespace Uddle.Dynamic.Contract
{
	abstract class AbstractContract
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

        protected bool CheckStart()
        {
            var checkStartModules = contract.GetCheckStart();

            if (null == checkStartModules)
            {
                return true;
            }


            foreach (var staticModule in checkStartModules)
            {
                var module = moduleFactory.GetModule(staticModule.GetName());
                var checkResult = module.Check(playerModel, staticModule.GetCondition());

                if (false == checkResult)
                {
                    return false;
                }
            }

            return true;
        }

        protected void Pay()
        {
        }
	}
}
