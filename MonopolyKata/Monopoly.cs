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

        private const int  MAX_NUMBER_OF_PLAYERS = 8;
        private const int  MIN_NUMBER_OF_PLAYERS = 2;
        private int round;
        private List<Player> playOrder;
        private Player currentTurnPlayer;

        public Monopoly( List<Player> players)
        {

            CheckForTooManyPlayers(players);

            CheckForTooFewPlayers(players);

            playOrder = players.Shuffle();

            currentTurnPlayer = playOrder[0];

            round = 1;

        }

        private static void CheckForTooFewPlayers(List<Player> players)
        {
            if (players.Count() < MIN_NUMBER_OF_PLAYERS)
            {
                throw new TooFewPlayersException(String.Format("Too few players: {0}", players.Count()));
            }
        }

        private static void CheckForTooManyPlayers(List<Player> players)
        {
            if (players.Count() > MAX_NUMBER_OF_PLAYERS)
            {
                throw new TooManyPlayersException(String.Format("Too many players: {0}", players.Count()));
            }
        }

        public void MoveTheCurrentTurnPlayer(int numberOfSpaces)
        {
            currentTurnPlayer.MoveSpaces(numberOfSpaces);  
        }

        public void GoToNextTurn()
        {
            var nextPlayerIndex = playOrder.FindIndex(p => p == currentTurnPlayer) + 1;

            if (nextPlayerIndex >= playOrder.Count())
            {
                nextPlayerIndex = 0;
                ++round;
            }

            currentTurnPlayer = playOrder[nextPlayerIndex];
        }

        public int GetCurrentTurnPlayer()
        {
            return playOrder.FindIndex(p => p == currentTurnPlayer);
        }

        public int GetLocation(int playerNumber)
        {
            return playOrder[playerNumber - 1].Location;
        }

        public int GetLocation(Player player)
        {
            return playOrder.Find(p => p == player).Location;
        }



        public List<Player>GetPlayOrder()
        {
            return playOrder;
        }

        public int GetRound()
        {
            return round;
        }

        

    }
}
