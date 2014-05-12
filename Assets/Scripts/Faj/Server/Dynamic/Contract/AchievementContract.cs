using Uddle.Static.Contract.Interface;
using Uddle.Model.Player.Interface;
using Faj.Common.Model.Player.Structure;
using Faj.Server.Dynamic.Contract.Interface;
using Faj.Common.Static.Quest.Collection.Item.Interface;

namespace Faj.Server.Dynamic.Contract
{
    class AchievementContract : QuestContract, IAchievementContract
	{

        public AchievementContract(IStaticContract contract, IPlayerModel playerModel)
            : base(contract, playerModel)
        {            
        }

        protected override void CreateIfNotExists(IStaticContract contract)
        {
            item = contract as IValuableItem;
            UnityEngine.Debug.Log("ai:" + item);
            var itemId = item.GetId();

            var commonPlayerModel = playerModel as Faj.Common.Model.Player.Interface.IPlayerModel;

            if (false == commonPlayerModel.GetPlayerStructure().quests.TryGetValue(itemId, out structure))
            {
                structure = new QuestStructure(itemId);
                commonPlayerModel.GetPlayerStructure().achievements.Add(itemId, structure);
            }
        }
	}
}
