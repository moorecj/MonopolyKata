using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonopolyKata.Player;

namespace MonopolyKata
{
    public interface ISetup
    {
        void CheckForTooFewPlayers(String[] players);
        void CheckForTooManyPlayers(String[] players);
        MonopolyPlayer WhoGoesFirst();
    }
}
