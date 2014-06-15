using Faj.Server.Model.Player.Perk.Interface;
using System.Collections.Generic;
using Faj.Server.Model.Player.Interface;
using System.Runtime.CompilerServices;
using Uddle.Static.Service.Interface;
using Uddle.Service;
using Faj.Common.Static.Perk.Buy.Collection.Interface;
using Faj.Server.Dynamic.Contract;

namespace Faj.Server.Model.Player.Perk
{
	class PlayerPerks : IPlayerPerks
	{
        readonly IPlayerModel playerModel;
        readonly IPerkBuyCollection perkBuyStaticCollection;

        public PlayerPerks(IPlayerModel playerModel)
        {
            this.playerModel = playerModel;
            var staticContainerService = ServiceProvider.Instance.GetService<IStaticContainerService>();
            perkBuyStaticCollection = staticContainerService.GetStaticCollection<IPerkBuyCollection>("perks_buy_contract");
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public List<string> GetPerks()
        {
            return playerModel.GetPlayerStructure().perks;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public bool IsPerk(string perk)
        {
            return playerModel.GetPlayerStructure().perks.Contains(perk);
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public bool Buy(string perk)
        {
            if (true == IsPerk(perk))
            {
                return false;
            }

            var perkContract = perkBuyStaticCollection.GetItem(perk);

            if (null == perkContract)
            {
                return false;
            }

            var contract = new PerkBuyContract(perkContract, playerModel);
            return contract.Start();
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public void AddPerk(string perk)
        {
            if (IsPerk(perk))
            {
                return;
            }

            playerModel.GetPlayerStructure().perks.Add(perk);
        }
	}
}
