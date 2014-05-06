using Faj.Common.Static.Contract.Condition.Interface;

namespace Faj.Common.Static.Contract.Condition
{
    class IdCondition : IIdCondition
	{
        readonly string id;

        public IdCondition(string id)
        {
            this.id = id;
        }

        public string GetId()
        {
            return id;
        }
	}
}
