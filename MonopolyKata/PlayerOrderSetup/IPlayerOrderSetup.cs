using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonopolyKata.Player;

namespace MonopolyKata
{
    public interface IPlayerOrderSetup
    {
        void CheckForTooFewPlayers<T>(T[] players);
        void CheckForTooManyPlayers<T>(T[] players);
        IPlayer WhoGoesFirst();
        IPlayer WhoGoesNext(IPlayer player);
        void PopulatePlayOrderList(String[] players);
    }
}
