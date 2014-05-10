using Uddle.Dynamic.Contract;
using Uddle.Static.Contract.Interface;
using Faj.Common.Model.Player.Interface;
using Faj.Common.Model.Player.Structure;
using Faj.Common.Static.Quest.Collection.Item.Interface;
using Faj.Server.Dynamic.Contract.Interface;

namespace Faj.Server.Dynamic.Contract
{
    class QuestContract : AbstractContract, IQuestContract
    {
        protected QuestStructure structure;
        protected IQuestItem questItem;

        public QuestContract(IStaticContract contract, IPlayerModel playerModel)
            : base(contract, playerModel)
        {
            questItem = contract as IQuestItem;

            var commonPlayerModel = playerModel as Faj.Common.Model.Player.Interface.IPlayerModel;
            var questId = contract.GetId();


            if (false == commonPlayerModel.GetPlayerStructure().quests.TryGetValue(questId, out structure))
            {
                structure = new QuestStructure(questId);
                commonPlayerModel.GetPlayerStructure().quests.Add(questId, structure);
            }
        }

        public Status GetStatus()
        {
            return structure.status;
        }

        public void Increment(int value)
        {
            structure.value += value;

            if (questItem.GetValue() <= structure.value)
            {
                structure.value = questItem.GetValue();
                structure.status = Status.FINISHED;
            }
        }

        public virtual bool Start()
        {
            if (false == base.Start())
            {
                return false;
            }

            structure.status = Status.STARTED;

            return true;
        }
    }
}
