using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceWars.Logic.Actions
{
    internal class PurchaseAction : GamePlayAction
    {
        public override string Name => throw new NotImplementedException();

        public override int Priority => 3;

        public IPurchaseable ItemToPurchase { get; init; }

        public PurchaseAction(IPurchaseable itemToPurchase)
        {
            ItemToPurchase = itemToPurchase;
        }

        public override Result Execute(Player player, GameMap map)
        {
            // check if player has enough money
            // check if player has prerequisites
            // check if item is in shop 
            throw new NotImplementedException();
        }
    }
}
