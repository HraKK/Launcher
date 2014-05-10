using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Faj.Common.Model.Player.Structure;
using Faj.Common.Model.Player.Interface;
using Faj.Server.Model.Player.Level.Interface;

namespace Faj.Server.Model.Player.Level
{
    class PlayerLevels : IPlayerLevels
    {
        readonly IPlayerModel playerModel;

        public PlayerLevels(IPlayerModel playerModel)
        {
            this.playerModel = playerModel;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public Dictionary<string, int> GetOpenedLevels()
        {
            return playerModel.GetPlayerStructure().levels;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public int GetLevelLastTime(string level)
        {
            int value = 0;
            GetOpenedLevels().TryGetValue(level, out value);

            return value;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public bool IsLevelOpen(string level)
        {
            return GetOpenedLevels().ContainsKey(level);
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public void SetLevelLastTime(string level, int time)
        {
            if (GetOpenedLevels().ContainsKey(level))
            {
                GetOpenedLevels()[level] = time;
            }
            else
            {
                GetOpenedLevels().Add(level, time);
            }
        }
    }
}
