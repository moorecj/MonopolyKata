using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonopolyKata.Player;
using MonopolyKata.Board;

namespace MonopolyKata.Player
{  
    public class MonopolyPlayer : IPlayer  
    {
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

    }
}
