using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyKata.Board.Spaces
{
    class LuxuryTaxSpace : MonopolyBoardSpace
    {
        private const int LUXURY_TAX_AMOUNT = 75;

        public LuxuryTaxSpace(string name) : base(name) { }

        public override void LandOn(MonopolyPlayer player)
        {
            base.LandOn(player);
            player.Balence -= LUXURY_TAX_AMOUNT;

            Console.WriteLine(player.name + " pays {0}", LUXURY_TAX_AMOUNT);
            Console.WriteLine(player.name + "'s new balence is: {0}\n", player.Balence);
            
        }
    }
}
