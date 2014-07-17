using System;
namespace MonopolyKata.Board
{
    public interface IGameBoard
    {
        void LandOnNewSpace(MonopolyKata.MonopolyPlayer player);
        void Move(MonopolyPlayer player, int roll);
        int GetNumberOfBoardSpaces();
    }
}
