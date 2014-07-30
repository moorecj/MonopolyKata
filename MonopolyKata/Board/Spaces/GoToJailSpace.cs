using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyKata.Board.Spaces
{
    public class GoToJailSpace : MonopolyBoardSpace
    {
        public GoToJailSpace(string name, IMonopolyGameBoard gameBoard): base(name, gameBoard)
        {
            this.name = name;
        }

        public override void LandOn(MonopolyPlayer player)
        {
            base.LandOn(player);
            gameBoard.Jail.LockUp(player);
            player.Location = gameBoard.GetSpaceAddress(gameBoard.Jail);
        }

    }
}
