namespace Faj.Server.Model.Player.Achievement.Interface
{
	interface IPlayerAchievements
	{
        void Notify(string action, string target, int value);
	}
}
