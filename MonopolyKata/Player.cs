using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyKata
{
    [Serializable]   
    public class Player : IEquatable<Player>
    {
        const int NUMBER_OF_LOCATIONS_ON_BOARD = 40;
        private string name { get; set; }
        public int Location { get; set; }
        public int Balence{ get; set; }


        public Player()
        {
            Location = 0;
        }

        public Player(string name)
        {
            this.name = name;
            Location = 0;
            Balence = 0;
        }

        

        public void MoveSpaces( int numberOfSpaces )
        {
            Location += numberOfSpaces;

            if (Location > NUMBER_OF_LOCATIONS_ON_BOARD)
            {
                Location -= NUMBER_OF_LOCATIONS_ON_BOARD;    
            }
        }

        public bool Equals(Player other)
        {
            if (other == null)
                return false;

            if (this.name.Equals(other.name))
            {
                return true;
            }
            else
                return false;

        }


    }
}
