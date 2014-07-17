using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyKata.Dice
{
    public class PrintDiceRollDecoration : IDice
    {
        private IDice dice;

        public PrintDiceRollDecoration(IDice dice)
        {
            this.dice = dice;
        }

        public int Roll()
        {
            int roll = dice.Roll();
            Console.WriteLine("Roll was: {0}", roll);
            return roll;
        }
    }
}
