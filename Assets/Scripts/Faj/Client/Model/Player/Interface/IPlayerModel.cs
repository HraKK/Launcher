using Faj.Client.Model.Player.Resource.Interface;
using Faj.Common.Model.Player.Structure;
using System;
using Faj.Client.Model.Player.Level.Interface;
using Faj.Client.Model.Player.Upgrade.Interface;
using Faj.Client.Model.Player.Quest.Interface;
using Faj.Client.Model.Player.Achievement.Interface;
using Faj.Client.Model.Player.Perk.Interface;

namespace Faj.Client.Model.Player.Interface
{
    interface IPlayerModel : Faj.Common.Model.Player.Interface.IPlayerModel
	{
        void SetStructure(PlayerStructure playerStructure);

        event Action<LocationEnum> OnChangeLocation;
        event Action OnUpdateEvent;
        void ChangeLocation(LocationEnum location);
        LocationEnum GetLocation();

        IPlayerLevels GetLevels();
        IPlayerUpgrades GetUpgrades();
        IPlayerQuests GetQuests();
        IPlayerAchievements GetAchievements();
        IPlayerResources GetResources();
        IPlayerPerks GetPerks();
	}
}
