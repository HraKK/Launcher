using Uddle.Dynamic.Contract.Module.Interface;
using Uddle.Model.Player.Interface;
using Uddle.Static.Contract.Module.Condition.Interface;
using Faj.Common.Static.Contract.Condition.Interface;
using Uddle.Static.Contract.Interface;
using Faj.Common.Static.Level.Play.Collection.Item.Interface;
using System;

namespace Faj.Server.Dynamic.Contract.Module
{
    class LevelTimeModule : IContractModule
    {
        public bool Check(IStaticContract contract, IPlayerModel playerModel, ICondition condition)
        {
            var serverPlayerModel = playerModel as Faj.Server.Model.Player.Interface.IPlayerModel;
            var levelPlayContract = contract as ILevelPlayItem;
            var levelTimeCondition = condition as IIntCondition;
            var passTime = levelTimeCondition.GetValue();
            var levelId = levelPlayContract.GetLevelId();

            var lastPlayedTime = serverPlayerModel.GetLevels().GetLevelLastTime(levelId);
            var currentTime = (int)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;

            return currentTime - lastPlayedTime >= passTime;
        }

        public void Pay(IStaticContract contract, IPlayerModel playerModel, ICondition condition)
        {

        }

        public void Award(IStaticContract contract, IPlayerModel playerModel, ICondition condition)
        {
        }
    }
}