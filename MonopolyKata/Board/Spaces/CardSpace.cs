using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonopolyKata;
using MonopolyKata.Deck;


namespace MonopolyKata.Board.Spaces
{
    public class CardSpace : MonopolyBoardSpace
    {
        IDeck deck;

        public CardSpace(string name, IMonopolyGameBoard gameBoard, IDeck deck):base(name, gameBoard)
        {
            this.deck = deck; 
        }

    }
}
