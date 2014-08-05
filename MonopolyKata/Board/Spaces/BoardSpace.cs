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
        public MonopolyGameBoard gameBoard;
        public string name { get; set; }

        public BoardSpace(string name, MonopolyGameBoard gameBoard)
        {
            this.name =  name;
            this.gameBoard = gameBoard;
        }

        public int GetMyLocation( )
        {
            return gameBoard.GetSpaceAddress(this);
        }

        abstract public void LandOn(IPlayer player);

    }

    


}
