using Faj.Client.Model.Player.Resource.Interface;
using Faj.Common.Model.Player.Structure;
using System;
using Faj.Client.Model.Player.Level.Interface;

namespace Faj.Client.Model.Player.Interface
{
    interface IPlayerModel : Faj.Common.Model.Player.Interface.IPlayerModel
	{
        void SetStructure(PlayerStructure playerStructure);

        event Action<LocationEnum> OnChangeLocation;
        void ChangeLocation(LocationEnum location);
        LocationEnum GetLocation();

        IPlayerLevels GetLevels();
        IPlayerResources GetResources();
	}
}
