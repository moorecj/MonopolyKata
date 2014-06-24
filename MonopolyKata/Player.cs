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
        private string name;
        int location;
        int balence;

        public Player()
        {
            location = 0;
        }

        public Player(string name)
        {
            this.name = name;
            location = 0;
            balence = 0;
        }

        public int GetLocation()
        {
            return location;
        }

        public void MoveSpaces( int numberOfSpaces )
        {
            location += numberOfSpaces;

            if (location > NUMBER_OF_LOCATIONS_ON_BOARD)
            {
                location -= NUMBER_OF_LOCATIONS_ON_BOARD;    
            }
        }

        public int GetBalence()
        {
            return balence;
        }

        public void AddToBalence(int fundsToAdd)
        {
            
        }

        public void SubtractFromBalence(int fundsToSubtract)
        {

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

        public override bool Equals(Object obj)
        {
            if (obj == null)
                return false;

            Player playerObj = obj as Player;
            if (playerObj == null)
                return false;
            else
                return Equals(playerObj);
        }

        public static bool operator ==(Player player1, Player player2)
        {
            if ((object)player1 == null || ((object)player2) == null)
                return Object.Equals(player1, player2);

            return player1.Equals(player2);
        }

        public static bool operator !=(Player player1, Player player2)
        {
            if (player1 == null || player2 == null)
                return !Object.Equals(player1, player2);

            return !(player1.Equals(player2));
        }

    }
}
