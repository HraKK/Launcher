using Uddle.Dynamic.Contract.Module.Interface;
using Uddle.Static.Contract.Interface;
using Uddle.Model.Player.Interface;
using Uddle.Static.Contract.Module.Condition.Interface;
using Faj.Common.Static.Contract.Condition.Interface;

namespace Faj.Server.Dynamic.Contract.Module
{
    class ResourceModule : IContractModule
    {
        public bool Check(IStaticContract contract, IPlayerModel playerModel, ICondition condition)
        {
            var serverPlayerModel = playerModel as Faj.Server.Model.Player.Interface.IPlayerModel;
            var resourceCondition = condition as IDictionaryIntCondition;
            var resources = resourceCondition.GetDictionary();

            return serverPlayerModel.GetResources().IsEnoughResources(resources);
        }

        public void Pay(IStaticContract contract, IPlayerModel playerModel, ICondition condition)
        {
            var serverPlayerModel = playerModel as Faj.Server.Model.Player.Interface.IPlayerModel;
            var resourceCondition = condition as IDictionaryIntCondition;
            var resources = resourceCondition.GetDictionary();

            serverPlayerModel.GetResources().PayResources(resources);

        }

        public void Award(IStaticContract contract, IPlayerModel playerModel, ICondition condition)
        {
            var serverPlayerModel = playerModel as Faj.Server.Model.Player.Interface.IPlayerModel;
            var resourceCondition = condition as IDictionaryIntCondition;
            var resources = resourceCondition.GetDictionary();

            serverPlayerModel.GetResources().AwardResources(resources);
        }
    }
}
