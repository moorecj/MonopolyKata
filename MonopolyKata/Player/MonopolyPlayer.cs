using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonopolyKata.Player;

namespace MonopolyKata
{  
    public class MonopolyPlayer : IPlayer  
    {
        const int NUMBER_OF_LOCATIONS_ON_BOARD = 40;

        public string name { get; set; }
        public int Location { get; set; }
        public int Balence{ get; set; }

        public MonopolyPlayer(string name)
        {
            this.name = name;
            Location = 0;
            Balence = 0;
        }

        public void Move( int numberOfSpaces )
        {
            Location += numberOfSpaces;

            while(Location >= NUMBER_OF_LOCATIONS_ON_BOARD)
            {
                Location -= NUMBER_OF_LOCATIONS_ON_BOARD;    
            }
        }

    }
}
