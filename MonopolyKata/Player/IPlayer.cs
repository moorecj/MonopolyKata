using System;
namespace MonopolyKata.Player
{
    public interface IPlayer
    {
        int Balence { get; set; }
        int lastRoll { get; set; }
        int Location { get; set; }
        string name { get; set; }
    }
}
