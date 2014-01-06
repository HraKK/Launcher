using Faj.Common.Model.Player.Resource.Interface;
using Faj.Common.Model.Player.Structure;

namespace Faj.Client.Model.Player.Interface
{
    interface IPlayerModel
	{
        void Load();
        void Save();
        IPlayerResources GetResources();
        void Initialize(PlayerStructure playerStructure);
	}
}
