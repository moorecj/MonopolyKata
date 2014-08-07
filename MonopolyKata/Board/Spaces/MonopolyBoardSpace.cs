using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonopolyKata.Player;

namespace MonopolyKata.Board.Spaces
{
    public class MonopolyBoardSpace : BoardSpace
    {
        public MonopolyBoardSpace(string name, IMonopolyGameBoard gameBoard): base(name, gameBoard)  
        { }

        public override void LandOn(IPlayer player)
        {
            if (gameBoard.DidPlayerPassGo(player))
            {
                GoSpace.Pass(player);
            }
        }

        

    }
}
