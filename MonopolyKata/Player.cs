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

        private string name;

        public Player()
        {

        }

        public Player(string name)
        {

            this.name = name;

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
