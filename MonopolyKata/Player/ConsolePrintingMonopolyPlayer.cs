using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonopolyKata.Player;

namespace MonopolyKata
{
    public class ConsolePrintingMonopolyPlayer : MonopolyPlayer  
    {
        private int _balence;
        override public int Balence
        {
            get { return _balence; }
            set
            {
                _balence = value;
                Console.WriteLine(name + "'s balence is now {0}", _balence);
            }
        }

        public ConsolePrintingMonopolyPlayer(string name) : base(name){}

        public override void Move( int numberOfSpaces )
        {
            base.Move(numberOfSpaces);
            Console.WriteLine(name + " moved {0} spaces", numberOfSpaces);
        }

    }
}
