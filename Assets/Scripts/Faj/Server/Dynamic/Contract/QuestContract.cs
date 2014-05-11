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
        protected bool isLocked = false;

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
                Lock();
                structure.value = questItem.GetValue();
                Finish();
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

        public virtual bool Finish()
        {
            if (false == base.Finish())
            {
                Unlock();
                return false;
            }

            Unlock();
            structure.status = Status.FINISHED;

            return true;
        }


        protected void Lock()
        {
            isLocked = true;
        }

        protected void Unlock()
        {
            isLocked = false;
        }

        public bool IsLocked()
        {
            return isLocked;
        }
    }
}
