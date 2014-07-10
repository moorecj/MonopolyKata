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

        protected int _balence;

        public string name { get; set; }
        public int Location { get; set; }
        public virtual int Balence{ get; set; }
        public int lastRoll { get; set; }

        public MonopolyPlayer(string name)
        {
            this.name = name;
            Location = 0;
            Balence = 0;
        }

        public virtual void Move( int roll )
        {
            Location += roll;

            lastRoll = roll;

            while(Location >= NUMBER_OF_LOCATIONS_ON_BOARD)
            {
                Location -= NUMBER_OF_LOCATIONS_ON_BOARD;    
            }
        }

    }
}
