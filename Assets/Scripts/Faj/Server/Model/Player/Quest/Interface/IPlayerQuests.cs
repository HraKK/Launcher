namespace Faj.Server.Model.Player.Quest.Interface
{
	interface IPlayerQuests
	{
        void Notify(string action, string target, int value);
        int GetFinishedQuestCountByLevel(string level);
        bool IsFinishedQuest(string questId);
	}
}
