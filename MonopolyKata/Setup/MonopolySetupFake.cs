using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyKata.Setup
{
    public class MonopolySetupFake : ISetup
    {

        public int randomizeCount;

        private List<MonopolyPlayer> playOrder;

        public MonopolySetupFake(params String[] playerNames )
        {
            PopulatePlayOrderList(playerNames);
            randomizeCount = 0;
        }
         
        public int GetDiceRolls()
        {
            return (2);
        }

        private void RandomizePlayOrder()
        {
            ++randomizeCount;
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

        public MonopolyPlayer WhoGoesNext( MonopolyPlayer player )
        {
            var nextPlayerIndex = playOrder.FindIndex(p => p == player) + 1;

            if (nextPlayerIndex >= playOrder.Count())
            {
                nextPlayerIndex = 0;
            }

            return playOrder[nextPlayerIndex];
        }

        public void CheckForTooFewPlayers(String[] players)
        {
        }

        public void CheckForTooManyPlayers(String[] players)
        {
        }
    }
}
