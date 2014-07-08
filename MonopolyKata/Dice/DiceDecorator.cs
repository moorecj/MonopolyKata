using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyKata.Dice
{
    public abstract class DiceDecorator : IDice
    {
        protected IDice dice;

        public DiceDecorator(IDice dice)
        {
            this.dice = dice;
        }

        public virtual int Roll()
        {
            return dice.Roll();
        }
    }
}
