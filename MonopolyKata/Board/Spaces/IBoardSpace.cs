using System;
using MonopolyKata.Player;
namespace MonopolyKata.Board.Spaces
{
    public interface IBoardSpace
    {
        int GetForwardDistanceFromLocation(int location);
        int GetMyLocation();
        void LandOn(IPlayer player);
        string name { get; set; }
    }
}
