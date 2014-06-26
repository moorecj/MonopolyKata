using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyKata.Setup
{
    
    public class MonopolySetup : ISetup
    {

        private List<MonopolyPlayer> playOrder;

        public MonopolySetup(params String[] playerNames )
        {
            playOrder = new List<MonopolyPlayer>();

            foreach (String s in playerNames)
            {
                playOrder.Add(new MonopolyPlayer(s));
            }
        }

        public List<MonopolyPlayer> GetPlayOrder()
        {
            return playOrder;
        }

        public void CheckForTooFewPlayers(String[] players)
        {

        }

        public void CheckForTooManyPlayers(String[] players)
        {

        }

    }
}
