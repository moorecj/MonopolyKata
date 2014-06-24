using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonopolyKata.Extensions;

namespace MonopolyKata
{
    public class Monopoly
    {

        const int  MAX_NUMBER_OF_PLAYERS = 8;
        const int  MIN_NUMBER_OF_PLAYERS = 2;

        private List<Player> playOrder;

        public Monopoly( List<Player> players)
        {

            if(players.Count() > MAX_NUMBER_OF_PLAYERS)
            {
                throw new TooManyPlayersException(String.Format("Too many players: {0}", players.Count()));
            }

            if (players.Count() < MIN_NUMBER_OF_PLAYERS)
            {
                throw new TooFewPlayersException(String.Format("Too few players: {0}", players.Count()));
            }

            playOrder = players.DeepClone();

            playOrder.Shuffle();


        }

        public void Move(int numberOfSpaces)
        {

        }

        public int GetLocation(int playerNumber)
        {
            return playOrder[playerNumber].GetLocation();
        }

        public List<Player>GetPlayOrder()
        {
            return playOrder;
        }

        

    }
}
