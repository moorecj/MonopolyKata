using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyKata.Dice
{
    public class ConsolePrintingSixSidedDie : SixSidedDie
    {


        public ConsolePrintingSixSidedDie(): base() {}

        public override int Roll()
        {
            int roll = base.Roll();
            Console.WriteLine("Roll was: {0}", roll);
            return roll;
        }
    }
}
