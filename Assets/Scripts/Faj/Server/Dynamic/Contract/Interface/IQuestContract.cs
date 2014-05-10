using Uddle.Dynamic.Contract.Interface;
using Faj.Common.Model.Player.Structure;

namespace Faj.Server.Dynamic.Contract.Interface
{
	interface IQuestContract : IContract
	{
        Status GetStatus();
        void Increment(int value);
	}
}
