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
            if (CheckForPassingGo(player))
            {
                GoSpace.Pass(player);
            }
        }

        private bool CheckForPassingGo(IPlayer player)
        {
            return ((player.Location - player.lastRoll) < 0) && player.Location != gameBoard.GetSpaceAddress(gameBoard.Go);
        }

    }
}
