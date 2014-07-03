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
        void CheckForTooFewPlayers<T>(T[] players);
        void CheckForTooManyPlayers<T>(T[] players);
        MonopolyPlayer WhoGoesFirst();
        MonopolyPlayer WhoGoesNext(MonopolyPlayer player);
        void PopulatePlayOrderList(String[] players);
    }
}
