using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonopolyKata.Extensions;

namespace MonopolyKata.Setup
{
    
    public class MonopolySetup : ISetup
    {
        private const int MAX_NUMBER_OF_PLAYERS = 8;
        private const int MIN_NUMBER_OF_PLAYERS = 2;

        private List<MonopolyPlayer> playOrder;

        public MonopolySetup(params String[] playerNames )
        {
            CheckForTooManyPlayers(playerNames);
            CheckForTooFewPlayers(playerNames);
            PopulatePlayOrderList(playerNames);
            RandomizePlayOrder();
        }

        private void RandomizePlayOrder()
        {
            playOrder = playOrder.Shuffle();
        }

        private void PopulatePlayOrderList(String[] playerNames)
        {
            playOrder = new List<MonopolyPlayer>();

            foreach (String s in playerNames)
            {
                playOrder.Add(new MonopolyPlayer(s));
            }
        }

        public MonopolyPlayer WhoGoesFirst()
        {
            return playOrder[0];
        }

        public void CheckForTooFewPlayers(String[] players)
        {
            if (players.Count() < MIN_NUMBER_OF_PLAYERS)
            {
                throw new TooFewPlayersException(String.Format("Too few players: {0}", players.Count()));
            }
        }

        public void CheckForTooManyPlayers(String[] players)
        {
            if (players.Count() > MAX_NUMBER_OF_PLAYERS)
            {
                throw new TooManyPlayersException(String.Format("Too many players: {0}", players.Count()));
            }
        }

    }
}
