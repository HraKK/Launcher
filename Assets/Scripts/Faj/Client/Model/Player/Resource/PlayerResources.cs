using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Faj.Client.Model.Player.Resource.Interface;
using Faj.Common.Model.Player.Structure;
using Faj.Common.Model.Player.Interface;

namespace Faj.Client.Model.Player.Resource
{
	class PlayerResources : IPlayerResources
	{
        readonly IPlayerModel playerModel;

        public PlayerResources(IPlayerModel playerModel)
        {
            this.playerModel = playerModel;
        }

        public Dictionary<string, int> GetResources()
        {
            return playerModel.GetPlayerStructure().resources;
        }

        public int GetResource(string resource)
        {
            int value = 0;
            GetResources().TryGetValue(resource, out value);

            return value;
        }

        void SetResources(Dictionary<string, int> resources)
        {
            playerModel.GetPlayerStructure().resources = resources;
        }

        public bool IsEnoughResources(Dictionary<string, int> resources)
        {
            var userResources = GetResources();

            foreach (var resourceKVP in resources)
            {
                int value;

                if (!userResources.TryGetValue(resourceKVP.Key, out value))
                {
                    return false;
                }

                if (value < resourceKVP.Value)
                {
                    return false;
                }
            }

            return true;
        }
	}
}
