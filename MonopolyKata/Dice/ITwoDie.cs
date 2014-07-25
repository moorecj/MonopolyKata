using System;
namespace MonopolyKata.Dice
{
    interface ITwoDie
    {
        int GetDiceRollTotal();
        bool LastRollWereAllTheSame();
        void Roll();
        bool RollWasDoubles();
    }
}
