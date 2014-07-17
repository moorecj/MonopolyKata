using System;
namespace MonopolyKata.Dice
{
    interface IDice
    {
        int GetDiceRollTotal();
        bool LastRollWereAllTheSame();
        void Roll();
    }
}
