using Uddle.Message.Content.Interface;
using Faj.Common.Model.Player.Structure;

namespace Faj.Common.Message.Content.Interface
{
	interface IPlayerContent : IContent
	{
        PlayerStructure GetPlayerStructure();
	}
}
