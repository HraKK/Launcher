using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Faj.Common.Model.Player.Resource.Interface;
using Faj.Common.Model.Player.Structure;

namespace Faj.Common.Model.Player.Resource
{
	class PlayerResources : IPlayerResources
	{
        readonly PlayerStructure playerStructure;

        public PlayerResources(PlayerStructure playerStructure)
        {
            this.playerStructure = playerStructure;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public Dictionary<string, int> GetResources()
        {
            return playerStructure.resources;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        void SetResources(Dictionary<string, int> resources)
        {
            playerStructure.resources = resources;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
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

        [MethodImpl(MethodImplOptions.Synchronized)]
        public void AwardResources(Dictionary<string, int> resources)
        {
            var userResources = GetResources();

            foreach (var resourceKVP in resources)
            {
                int value;

                if (!userResources.TryGetValue(resourceKVP.Key, out value))
                {
                    userResources.Add(resourceKVP.Key, resourceKVP.Value);
                }
                else
                {
                    userResources[resourceKVP.Key] +=  resourceKVP.Value;
                }
            }

            SetResources(userResources);
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public void PayResources(Dictionary<string, int> resources)
        {
            var userResources = GetResources();

            foreach (var resourceKVP in resources)
            {
                int value;

                if (!userResources.TryGetValue(resourceKVP.Key, out value))
                {
                    userResources.Add(resourceKVP.Key, 0 - resourceKVP.Value);
                }
                else
                {
                    userResources[resourceKVP.Key] -= resourceKVP.Value;
                }
            }

            SetResources(userResources);
        }
	}
}
