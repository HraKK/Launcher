using Uddle.Static.Contract.Interface;
using Uddle.Dynamic.Contract;
using Uddle.Model.Player.Interface;
using Faj.Common.Static.Level.Play.Collection.Item.Interface;
using System;

namespace Faj.Server.Dynamic.Contract
{
	class LevelPlayContract : AbstractContract
	{
        public LevelPlayContract(IStaticContract contract, IPlayerModel playerModel)
            : base(contract, playerModel)
        {
        }

        public virtual bool Start()
        {
            if (false == base.Start())
            {
                return false;
            }

            var serverPlayerModel = playerModel as Faj.Server.Model.Player.Interface.IPlayerModel;
            var levelPlayContract = contract as ILevelPlayItem;
            var levelId = levelPlayContract.GetLevelId();
            var currentTime = (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
            serverPlayerModel.GetLevels().SetLevelLastTime(levelId, currentTime);

            return true;
        }
	}
}
