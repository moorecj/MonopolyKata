using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyKata.Board.Spaces
{
    public class IncomeTaxSpace : MonopolyBoardSpace
    {
        private const int MAX_INCOME_TAX_AMOUNT = 200;

        public IncomeTaxSpace(string name, IMonopolyGameBoard gameBoard) : base(name, gameBoard) { }

        public override void LandOn(MonopolyPlayer player)
        {
            base.LandOn(player);

            int taxAmount;

      
            if( (0.10 * player.Balence ) >= MAX_INCOME_TAX_AMOUNT)
            {
                taxAmount = MAX_INCOME_TAX_AMOUNT;
            }
            else
            {
                taxAmount = (int)((double)player.Balence * 0.10);
            }

            player.Balence -= taxAmount;
            
        }

    }
}
