using Faj.Client.Model.Player.Interface;
using Faj.Client.Model.Player.Achievement.Interface;
namespace Faj.Client.Model.Player.Achievement
{
	class PlayerAchievements: IPlayerAchievements
	{        
        readonly IPlayerModel playerModel;

        public PlayerAchievements(IPlayerModel playerModel)
        {
            this.playerModel = playerModel;
        }
	}
}
