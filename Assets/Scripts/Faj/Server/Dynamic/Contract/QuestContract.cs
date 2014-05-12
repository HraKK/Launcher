using Uddle.Dynamic.Contract;
using Uddle.Static.Contract.Interface;
using Faj.Common.Model.Player.Structure;
using Faj.Common.Static.Quest.Collection.Item.Interface;
using Faj.Server.Dynamic.Contract.Interface;
using Uddle.Model.Player.Interface;

namespace Faj.Server.Dynamic.Contract
{
    class QuestContract : AbstractContract, IQuestContract
    {
        protected QuestStructure structure;
        protected IValuableItem item;
        protected bool isLocked = false;

        public QuestContract(IStaticContract contract, IPlayerModel playerModel)
            : base(contract, playerModel)
        {
            CreateIfNotExists(contract);
        }

        protected virtual void CreateIfNotExists(IStaticContract contract)
        {

            item = contract as IValuableItem;
            UnityEngine.Debug.Log("qi:" + item);
            var itemId = item.GetId();

            var commonPlayerModel = playerModel as Faj.Common.Model.Player.Interface.IPlayerModel;

            if (false == commonPlayerModel.GetPlayerStructure().quests.TryGetValue(itemId, out structure))
            {
                structure = new QuestStructure(itemId);
                commonPlayerModel.GetPlayerStructure().quests.Add(itemId, structure);
            }
        }

        public Status GetStatus()
        {
            return structure.status;
        }

        public void Increment(int value)
        {
            UnityEngine.Debug.Log("exists!!!!!!" + item);
            UnityEngine.Debug.Log("existss!!!!!!" + structure);
            structure.value += value;

            if (item.GetValue() <= structure.value)
            {

                Lock();
                structure.value = item.GetValue();
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
