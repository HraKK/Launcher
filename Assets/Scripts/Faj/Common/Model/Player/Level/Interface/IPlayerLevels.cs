using System.Collections.Generic;

namespace Faj.Common.Model.Player.Level.Interface
{
    interface IPlayerLevels
    {
        Dictionary<string, int> GetOpenedLevels();
        bool IsLevelOpen(string level);
        int GetLevelLastTime(string level);
        void SetLevelLastTime(string level, int time);
    }
}
