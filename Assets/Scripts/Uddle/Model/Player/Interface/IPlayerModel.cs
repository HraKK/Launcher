namespace Uddle.Model.Player.Interface
{
    interface IPlayerModel
    {
        string GetId();
        void Load();
        void Save();
	}
}
