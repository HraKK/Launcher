using System.Collections.Generic;

namespace Faj.Client.Model.Player.Level.Interface
{
    interface IPlayerLevels
    {
        Dictionary<string, int> GetOpenedLevels();
        bool IsLevelOpen(string level);
        int GetLevelLastTime(string level);
    }
}
