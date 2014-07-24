using System;
namespace MonopolyKata.Dice
{
    public interface IDice
    {
        int GetDiceRollTotal();
        bool LastRollWereAllTheSame();
        void Roll();
    }
}
