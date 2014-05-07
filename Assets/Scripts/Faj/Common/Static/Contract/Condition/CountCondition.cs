using Faj.Common.Static.Contract.Condition.Interface;

namespace Faj.Common.Static.Contract.Condition
{
	class CountCondition : ICountCondition
	{
        readonly int count;

        public CountCondition(int count)
        {
            this.count = count;
        }

        public int GetCount()
        {
            return count;
        }
	}
}
