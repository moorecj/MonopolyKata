using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonopolyKata.Player;

namespace MonopolyKata.Board.Spaces
{
    public class GoToJailSpace : MonopolyBoardSpace
    {
        public GoToJailSpace(string name, IMonopolyGameBoard gameBoard): base(name, gameBoard)
        {
            this.name = name;
        }

        public override void LandOn(IPlayer player)
        {
            base.LandOn(player);
            gameBoard.PutPlayerInJail(player);
        }

    }
}
