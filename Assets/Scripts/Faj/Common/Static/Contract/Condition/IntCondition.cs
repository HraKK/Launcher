using Faj.Common.Static.Contract.Condition.Interface;

namespace Faj.Common.Static.Contract.Condition
{
    class IntCondition : IIntCondition
    {
        readonly int value;

        public IntCondition(int value)
        {
            this.value = value;
        }

        public int GetValue()
        {
            return value;
        }
    }
}
