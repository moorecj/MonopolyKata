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
        private List<MonopolyPlayer> playOrder = new List<MonopolyPlayer>();
        private MonopolyPlayer currentTurnPlayer;

        public Monopoly( params String[] players )
        {

            foreach(String s in players)
            {
                playOrder.Add(new MonopolyPlayer(s));    
            }

            playOrder = playOrder.Shuffle();
            currentTurnPlayer = playOrder[0];

        }

        public void MoveTheCurrentTurnPlayer(int numberOfSpaces)
        {
            currentTurnPlayer.Move(numberOfSpaces);  
        }

        public void GoToNextTurn()
        {
            var nextPlayerIndex = playOrder.FindIndex(p => p == currentTurnPlayer) + 1;

            if (nextPlayerIndex >= playOrder.Count())
            {
                nextPlayerIndex = 0;
            }

            currentTurnPlayer = playOrder[nextPlayerIndex];
        }

        public MonopolyPlayer GetCurrentTurnPlayer()
        {
            return currentTurnPlayer;
        }

        public int GetLocation(string  playerName)
        {
            return playOrder.Find(p => p.name.Equals(playerName)).Location;
        }

        

    }
}
