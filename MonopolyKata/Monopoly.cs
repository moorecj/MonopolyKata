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

        private Player currentTurnPlayer;

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

            currentTurnPlayer = playOrder[0];


        }

        public void Move(int numberOfSpaces)
        {
            currentTurnPlayer.MoveSpaces(numberOfSpaces);  
        }

        public int GetLocation(int playerNumber)
        {
            return playOrder[playerNumber-1].GetLocation();
        }

        public List<Player>GetPlayOrder()
        {
            return playOrder;
        }

        

    }
}
