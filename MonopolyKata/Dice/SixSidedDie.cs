using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyKata.Dice
{
    public class SixSidedDie : IDie
    {
        private Random randomNumber;

        public SixSidedDie()
        {
            randomNumber = new Random();
        }

        public int Roll()
        {
            return (randomNumber.Next(1, 7));
        }
    }
}
