using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyKata.Dice
{
    public class TwoDie : MonopolyKata.Dice.IDice
    {
        IDie die;
        int roll1;
        int roll2;

        public TwoDie(IDie die)
        {
            this.die = die;
        }

        public void Roll()
        {
            roll1 = die.Roll();
            roll2 = die.Roll();
        }

        public int GetDiceRollTotal()
        {
            return (roll1 + roll2);
        }

        public bool LastRollWereAllTheSame()
        {
            return (roll1 == roll2);
        }

        public bool RollWasDoubles()
        {
            return LastRollWereAllTheSame();
        }
    }
}
