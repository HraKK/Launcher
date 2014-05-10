using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Faj.Common.Model.Player.Structure;
using Faj.Common.Model.Player.Interface;
using Faj.Client.Model.Player.Level.Interface;

namespace Faj.Client.Model.Player.Level
{
    class PlayerLevels : IPlayerLevels
    {
        readonly IPlayerModel playerModel;

        public PlayerLevels(IPlayerModel playerModel)
        {
            this.playerModel = playerModel;
        }

        public Dictionary<string, int> GetOpenedLevels()
        {
            return playerModel.GetPlayerStructure().levels;
        }

        public int GetLevelLastTime(string level)
        {
            int value = 0;
            GetOpenedLevels().TryGetValue(level, out value);

            return value;
        }

        public bool IsLevelOpen(string level)
        {
            return GetOpenedLevels().ContainsKey(level);
        }
    }
}