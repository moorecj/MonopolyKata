using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyKata
{
    public class Monopoly
    {

        const int  MAX_NUMBER_OF_PLAYERS = 8;

        public Monopoly( List<Player> players)
        {

            if(players.Count() > MAX_NUMBER_OF_PLAYERS)
            {
                throw new TooManyPlayersException(String.Format("Too many players: {0}", players.Count()));
            }


        }

    }
}
