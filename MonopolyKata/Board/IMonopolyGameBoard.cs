using System;
using MonopolyKata.Player;
using MonopolyKata.Board.Spaces;
using MonopolyKata.Board.Spaces.RealEstate;

namespace MonopolyKata.Board
{
    public interface IMonopolyGameBoard
    {
        void LandOnNewSpace(IPlayer player);
        void Move(IPlayer player, int roll);
        int GetSpaceAddress(IBoardSpace space);
        int GetForwardDistanceToSpace(int location, IBoardSpace space);
        void PutPlayerInJail(IPlayer player);
        bool DidPlayerPassGo(IPlayer player);
        int GetNumberOfBoardSpaces();
    }
}
