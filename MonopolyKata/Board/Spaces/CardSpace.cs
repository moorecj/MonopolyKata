using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonopolyKata;
using MonopolyKata.Setup;

namespace MonopolyKata.Board.Spaces
{
    public class CardSpace : MonopolyBoardSpace
    {
        PlayerOrderSetup setup;

        public CardSpace(string name, MonopolyGameBoard gameBoard, PlayerOrderSetup setup):base(name, gameBoard)
        {
            this.setup = setup; 
        }

    }
}
