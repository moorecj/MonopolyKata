using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonopolyKata.Player;
using MonopolyKata.Board;

namespace MonopolyKata
{
    abstract public class BoardSpace
    {
        public IMonopolyGameBoard gameBoard;
        public string name { get; set; }

        public BoardSpace(string name, IMonopolyGameBoard gameBoard)
        {
            this.name =  name;
            this.gameBoard = gameBoard;
        }

        public int GetMyLocation( )
        {
            return gameBoard.GetSpaceAddress(this);
        }

        public int GetForwardDistanceFromLocation(int location)
        {
            return gameBoard.GetForwardDistanceToSpace(location, this);
        }

        abstract public void LandOn(IPlayer player);

    }

    


}
